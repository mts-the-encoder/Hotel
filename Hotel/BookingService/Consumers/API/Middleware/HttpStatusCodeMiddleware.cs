using Newtonsoft.Json;
using System.Net;
using Data.Exceptions;

public class HttpStatusCodeMiddleware
{
    private readonly RequestDelegate _next;

    public HttpStatusCodeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var result = "";

            var message = error?.Message ?? "";
            if (error?.InnerException != null)
            {
                message = error.InnerException.Message;
            }

            var errorObject = new ErrorObject
            {
                message = message
            };

            switch (error)
            {
                case KeyNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorObject.status = (int)HttpStatusCode.NotFound;
                    result = JsonConvert.SerializeObject(errorObject);
                    break;
                case UnauthorizedAccessException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    errorObject.status = (int)HttpStatusCode.Unauthorized;
                    result = JsonConvert.SerializeObject(errorObject);
                    break;
                case Exception:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorObject.status = (int)HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(errorObject);
                    break;
            }
            await response.WriteAsync(result);
        }
    }

    public class ErrorObject
    {
        [JsonProperty(Order = 1)]
        public int status { get; set; }
        [JsonProperty(Order = 2)]
        public string? path { get; set; }
        [JsonProperty(Order = 3)]
        public string? message { get; set; }

        public ErrorObject() { }

        protected ErrorObject(ErrorObject error)
        {
            status = error.status;
            message = error.message;
        }
    }
    public class ValidationErrorObject : ErrorObject
    {
        [JsonProperty(Order = 4)]
        public dynamic? validation { get; set; }

        public ValidationErrorObject(ErrorObject errorObject) : base(errorObject) { }
    }
}

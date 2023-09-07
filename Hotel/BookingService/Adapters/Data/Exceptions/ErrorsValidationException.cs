using System.Runtime.Serialization;

namespace Data.Exceptions;

public class ErrorsValidationException : ExceptionBase
{
    public List<string> Errors { get; set; }

    public ErrorsValidationException(List<string> errors) : base(string.Empty)
    {
        Errors = errors;
    }
    protected ErrorsValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
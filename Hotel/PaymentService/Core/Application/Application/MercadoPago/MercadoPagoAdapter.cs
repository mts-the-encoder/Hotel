using Application.Base;
using Application.MercadoPago.Exceptions;
using Application.Payment.Dto;
using Application.Payment.Ports;
using Application.Payment.Responses;

namespace Payment.Application.MercadoPago;

public class MercadoPagoAdapter : IPaymentService
{
    public Task<PaymentResponse> PaymentWIthCreditCard(string paymentIntention)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentResponse> PaymentWIthDebitCard(string paymentIntention)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(paymentIntention))
                throw new InvalidPaymentIntentionException();

            paymentIntention += "/success";

            var dto = new PaymentStateDto()
            {
                CreatedDate = DateTime.Now,
                Message = $"Successfully paid {paymentIntention}",
                PaymentId = "123",
                Status = Status.Success
            };

            var response = new PaymentResponse()
            {
                PaymentDto = dto,
                Success = true
            };

            return Task.FromResult(response);
        }
        catch (InvalidPaymentIntentionException)
        {
            var response = new PaymentResponse()
            {
                Success = false,
                ErrorCode = ErrorCodes.PAYMENT_INVLAID_INTENTION
            };

            return Task.FromResult(response);
        }
    }

    public Task<PaymentResponse> PaymentWIthBankTransfer(string paymentIntention)
    {
        throw new NotImplementedException();
    }
}
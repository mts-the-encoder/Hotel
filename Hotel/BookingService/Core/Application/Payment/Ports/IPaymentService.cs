using Application.Payment.Responses;

namespace Application.Payment.Ports;

public interface IPaymentService
{
    Task<PaymentResponse> PaymentWIthCreditCard(string paymentIntention);
    Task<PaymentResponse> PaymentWIthDebitCard(string paymentIntention);
    Task<PaymentResponse> PaymentWIthBankTransfer(string paymentIntention);
}
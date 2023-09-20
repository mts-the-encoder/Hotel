using Application.Payment.Requests;

namespace Application.Payment.Ports;

public interface IPaymentProcessorFactory
{
    IPaymentProcessor GetPaymentProcessor(SupportedPaymentProviders selectedPaymentProvider);
}
using Application.Payment.Ports;
using Application.Payment.Requests;
using Payment.Application.MercadoPago;
using Payment.Application.MercadoPago.Exceptions;

namespace Payment.Application;

public class PaymentProcessorFactory : IPaymentProcessorFactory
{
    public IPaymentProcessor GetPaymentProcessor(SupportedPaymentProviders selectedPaymentProvider)
    {
        switch (selectedPaymentProvider)
        {
            case SupportedPaymentProviders.MercadoPago:
                return new MercadoPagoAdapter();

            default:
                return new NotImplementedPaymentProvider();
        }
    }
}
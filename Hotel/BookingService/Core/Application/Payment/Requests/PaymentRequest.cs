namespace Application.Payment.Requests;

public enum SupportedPaymentProviders
{
    Paypal= 1,
    Stripe = 2,
    PagSeguro = 3,
    MercadoPago = 4,
}

public enum SupportedPaymentMethods
{
    DebitCard = 1,
    CreditCard = 2,
    BankTransfer = 3,
}

public class PaymentRequest
{
    public int BookingId { get; set; }
    public string PaymentIntention { get; set; }
    public SupportedPaymentProviders SelectedPaymentProvider { get; set; }
    public SupportedPaymentMethods SelectedPaymentMethod { get; set; }
}
namespace Application.Base;

public enum ErrorCodes
{
    NOT_FOUND = 1,
    COULD_NOT_STORE_DATA = 2,

    //Payment
    PAYMENT_INVLAID_INTENTION = 3,

    PAYMENT_PROVIDER_NOT_IMPLEMENTED = 4,

    PAYMENT_INVALID_PAYMENT_INTENTION = 5,
}
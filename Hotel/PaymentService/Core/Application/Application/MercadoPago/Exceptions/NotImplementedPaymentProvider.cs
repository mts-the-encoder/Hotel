﻿using Application.Base;
using Application.Payment.Ports;
using Application.Payment.Responses;

namespace Payment.Application.MercadoPago.Exceptions;

public class NotImplementedPaymentProvider : IPaymentProcessor
{
    public Task<PaymentResponse> CapturePayment(string paymentIntention)
    {
        var paymentResponse = new PaymentResponse()
        {
            Success = false,
            ErrorCode = ErrorCodes.PAYMENT_PROVIDER_NOT_IMPLEMENTED,
            Message = "The selected payment provider is not available at the moment"
        };

        return Task.FromResult(paymentResponse);
    }
}
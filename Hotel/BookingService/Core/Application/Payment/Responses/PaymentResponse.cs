﻿using Application.Base;
using Application.Payment.Dto;

namespace Application.Payment.Responses;

public class PaymentResponse : Response
{
    public PaymentStateDto PaymentDto { get; set; }
}
using Application.Payment.Dto;
using Application.Payment.Ports;
using Application.Payment.Requests;
using Application.Payment.Responses;
using Application.UseCases.Booking;
using AutoMapper;
using Domain.Ports;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests
{
    public class BookingManagerTests
    {
        [Fact]
        public async Task Should_PayForABooking()
        {
            var dto = new PaymentRequest
            {
                SelectedPaymentProvider = SupportedPaymentProviders.MercadoPago,
                PaymentIntention = "https://www.mercadopago.com.br/asdf",
                SelectedPaymentMethod = SupportedPaymentMethods.CreditCard
            };

            var bookingRepository = new Mock<IBookingRepository>();
            var paymentProcessorFactory = new Mock<IPaymentProcessorFactory>();
            var paymentProcessor = new Mock<IPaymentProcessor>();
            var autoMapper = new Mock<IMapper>();

            var responseDto = new PaymentStateDto
            {
                CreatedDate = DateTime.Now,
                Message = $"Successfully paid {dto.PaymentIntention}",
                PaymentId = "123",
                Status = Status.Success
            };

            var response = new PaymentResponse
            {
                Data = responseDto,
                Success = true,
                Message = "Payment successfully processed"
            };

            paymentProcessor
                .Setup(x => x.CapturePayment(dto.PaymentIntention))
                .Returns(Task.FromResult(response));

            paymentProcessorFactory
                .Setup(x => x.GetPaymentProcessor(dto.SelectedPaymentProvider))
                .Returns(paymentProcessor.Object);

            var bookingManager = new BookingManager(
                bookingRepository.Object,
                autoMapper.Object,
                paymentProcessorFactory.Object);

            var res = await bookingManager.PayForABooking(dto);

            res.Should().NotBeNull();
            res.Success.Should().BeTrue();
            res.Message.Should().Be("Payment successfully processed");
        }
    }
}

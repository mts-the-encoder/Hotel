using Application.Booking.Dto;
using Application.Booking.Ports;
using Application.Booking.Requests;
using Application.Booking.Responses;
using Application.Payment.Ports;
using Application.Payment.Requests;
using Application.Payment.Responses;
using AutoMapper;
using Domain.Ports;

namespace Application.UseCases.Booking;

public class BookingManager : IBookingManager
{
    private readonly IBookingRepository _repository;
    private readonly IPaymentProcessorFactory _paymentProcessorFactory;
    private readonly IMapper _mapper;

    public BookingManager(IBookingRepository repository, IMapper mapper, IPaymentProcessorFactory paymentProcessorFactory)
    {
        _repository = repository;
        _mapper = mapper;
        _paymentProcessorFactory = paymentProcessorFactory;
    }

    public async Task<BookingResponse> Create(BookingDto dto)
    {
        Validate(dto);

        var booking = _mapper.Map<Domain.Entities.Booking>(dto);

        await _repository.SaveAsync(booking);

        return new BookingResponse(data: dto, success: true);
    }

    public async Task<BookingResponse> GetById(int id)
    {
        return await ExistsBooking(id);
    }

    public async Task<PaymentResponse> PayForABooking(PaymentRequest paymentRequest)
    {
        var processor = _paymentProcessorFactory.GetPaymentProcessor(paymentRequest.SelectedPaymentProvider);

        var response = await processor.CapturePayment(paymentRequest.PaymentIntention);

        return response.Success
            ? new PaymentResponse()
            {
                Success = true,
                Data = response.Data,
                Message = "Payment successfully processed"
            }
            : response;
    }

    private static void Validate(BookingDto booking)
    {
        var validator = new BookingValidator();
        var response = validator.Validate(booking);

        if (!response.IsValid)
        {
            var error = response.Errors.Select(x => x.ErrorMessage).FirstOrDefault();
            throw new FluentValidation.ValidationException(error);
        }
    }

    private async Task<BookingResponse> ExistsBooking(int id)
    {
        var booking = await _repository.GetByIdAsync(id);

        if (booking is null)
            throw new KeyNotFoundException($"Booking with id: {id} not found");

        var bookingDto = _mapper.Map<BookingDto>(booking);

        return new BookingResponse(data: bookingDto,success: true);
    }
}
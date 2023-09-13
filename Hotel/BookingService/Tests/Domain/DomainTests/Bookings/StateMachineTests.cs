using Domain.Enums;
using DomainTests.Entities;
using FluentAssertions;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings;

public class StateMachineTests
{

    [Fact]
    public void ShouldInitializeWithStatusCreated()
    {
        var booking = BookingBuilder.Build();

        booking.CurrentStatus.Should().Be(Status.Created);
        booking.CurrentStatus.Should().HaveSameValueAs(Status.Created);
        booking.CurrentStatus.Should().NotBe(Status.Cancelled);
        booking.CurrentStatus.Should().NotBe(Status.Finished);
        booking.CurrentStatus.Should().NotBe(Status.Paid);
        booking.CurrentStatus.Should().NotBe(Status.Refunded);
    }

    [Fact]
    public void ShouldSetStatusToPaidWhenPayingForABooking()
    {
        #region Arrange
        var booking = BookingBuilder.Build();
        #endregion

        #region Act
        booking.ChangeState(Action.Pay);
        #endregion

        #region Assert
        booking.CurrentStatus.Should().Be(Status.Paid);
        booking.CurrentStatus.Should().HaveSameValueAs(Status.Paid);
        booking.CurrentStatus.Should().NotBe(Status.Cancelled);
        booking.CurrentStatus.Should().NotBe(Status.Created);
        booking.CurrentStatus.Should().NotBe(Status.Finished);
        booking.CurrentStatus.Should().NotBe(Status.Refunded);
        #endregion
    }

    [Fact]
    public void ShouldSetStatusToCancelledWhenCancelABooking()
    {
        var booking = BookingBuilder.Build();

        booking.ChangeState(Action.Cancel);

        booking.CurrentStatus.Should().Be(Status.Cancelled);
        booking.CurrentStatus.Should().HaveSameValueAs(Status.Cancelled);
        booking.CurrentStatus.Should().NotBe(Status.Created);
        booking.CurrentStatus.Should().NotBe(Status.Finished);
        booking.CurrentStatus.Should().NotBe(Status.Paid);
        booking.CurrentStatus.Should().NotBe(Status.Refunded);
    }

    [Fact]
    public void ShouldSetStatusToFinishedWhenFinishingAPaidBooking()
    {
        var booking = BookingBuilder.Build();

        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);

        booking.CurrentStatus.Should().Be(Status.Finished);
        booking.CurrentStatus.Should().HaveSameValueAs(Status.Finished);
        booking.CurrentStatus.Should().NotBe(Status.Cancelled);
        booking.CurrentStatus.Should().NotBe(Status.Created);
        booking.CurrentStatus.Should().NotBe(Status.Paid);
        booking.CurrentStatus.Should().NotBe(Status.Refunded);
    }

    [Fact]
    public void ShouldSetStatusToRefundedWhenRefundingAPaidBooking()
    {
        var booking = BookingBuilder.Build();

        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Refund);

        booking.CurrentStatus.Should().Be(Status.Refunded);
        booking.CurrentStatus.Should().HaveSameValueAs(Status.Refunded);
        booking.CurrentStatus.Should().NotBe(Status.Cancelled);
        booking.CurrentStatus.Should().NotBe(Status.Created);
        booking.CurrentStatus.Should().NotBe(Status.Finished);
        booking.CurrentStatus.Should().NotBe(Status.Paid);
    }

    [Fact]
    public void ShouldSetStatusToCreatedWhenReopenCancelledBooking()
    {
        var booking = BookingBuilder.Build();

        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Reopen);

        booking.CurrentStatus.Should().Be(Status.Created);
        booking.CurrentStatus.Should().HaveSameValueAs(Status.Created);
        booking.CurrentStatus.Should().NotBe(Status.Cancelled);
        booking.CurrentStatus.Should().NotBe(Status.Finished);
        booking.CurrentStatus.Should().NotBe(Status.Paid);
        booking.CurrentStatus.Should().NotBe(Status.Refunded);
    }

    [Fact]
    public void ShouldNotChangeStatusWhenRefundingABookingWithCreatedStatus()
    {
        var booking = BookingBuilder.Build();

        booking.ChangeState(Action.Refund);

        booking.CurrentStatus.Should().Be(Status.Created);
        booking.CurrentStatus.Should().HaveSameValueAs(Status.Created);
        booking.CurrentStatus.Should().NotBe(Status.Cancelled);
        booking.CurrentStatus.Should().NotBe(Status.Finished);
        booking.CurrentStatus.Should().NotBe(Status.Paid);
        booking.CurrentStatus.Should().NotBe(Status.Refunded);
    }

    [Fact]
    public void ShouldNotChangeStatusWhenRefundingAFinishedBooking()
    {
        var booking = BookingBuilder.Build();

        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);
        booking.ChangeState(Action.Refund);

        booking.CurrentStatus.Should().Be(Status.Finished);
        booking.CurrentStatus.Should().HaveSameValueAs(Status.Finished);
        booking.CurrentStatus.Should().NotBe(Status.Cancelled);
        booking.CurrentStatus.Should().NotBe(Status.Created);
        booking.CurrentStatus.Should().NotBe(Status.Paid);
        booking.CurrentStatus.Should().NotBe(Status.Refunded);
    }
}
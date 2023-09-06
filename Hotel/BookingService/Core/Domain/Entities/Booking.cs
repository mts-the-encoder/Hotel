using Domain.Enums;
using Action = Domain.Enums.Action;

namespace Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public DateTime PlacedAt { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Room Room { get; set; }
    public Guest Guest { get; set; }
    public Status Status { get; set; } = Status.Created;

    public Status CurrentStatus => this.Status;

    public void ChangeState(Action action)
    {
        this.Status = (this.Status, action) switch
        {
            (Status.Created, Action.Pay)     => Status.Paid,
            (Status.Created, Action.Cancel)  => Status.Cancelled,
            (Status.Paid, Action.Finish)     => Status.Finished,
            (Status.Paid, Action.Refund)     => Status.Refunded,
            (Status.Cancelled, Action.Reopen) => Status.Created,
            _ => this.Status
        };
    }
}

namespace Domain.Enums;

public enum Action
{
    Pay = 0,
    Finish = 1, // after paid and used
    Cancel = 2, // can never be paid
    Refund = 3, // pain then refund
    Reopen = 4 // canceled
}
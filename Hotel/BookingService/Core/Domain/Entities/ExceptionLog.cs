namespace Domain.Entities;

public class ExceptionLog
{
    public int Id { get; set; }
    public string? Error { get; set; }
    public string? Path { get; set; }
}
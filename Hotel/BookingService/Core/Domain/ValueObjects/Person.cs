using Domain.Enums;

namespace Domain.ValueObjects;

public class Person
{
    public string IdNumber { get; set; }
    public DocumentType DocumentType { get; set; }
}
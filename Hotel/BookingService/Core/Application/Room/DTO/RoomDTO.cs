namespace Application.Room.Dto;

public class RoomDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public bool InMaintenance { get; set; }
    public decimal Value { get; set; }
    public int Currency { get; set; }
    public bool IsAvailable => this.InMaintenance && !this.HasGuest;
    private bool HasGuest => true;
}
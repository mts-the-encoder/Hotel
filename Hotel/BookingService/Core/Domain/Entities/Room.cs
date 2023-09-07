﻿using Domain.ValueObjects;

namespace Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public bool InMaintenance { get; set; }
    public Price Price { get; set; }
    public bool IsAvailable => this.InMaintenance && !this.HasGuest;
    public bool HasGuest => true;
}
﻿namespace Safety.Infraestructure.Models;

public abstract class BaseModel
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public bool IsActive { get; set; }
}
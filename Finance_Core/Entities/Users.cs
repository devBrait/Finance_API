﻿namespace Finance_Core.Entities;

public class Users
{

    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    public DateTime? updated_at { get; set; }
}

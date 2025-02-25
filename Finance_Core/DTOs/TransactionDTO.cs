﻿namespace Finance_Core.DTOs;
public class TransactionDTO
{
    public int id { get; set; }
    public int user_id { get; set; }
    public int category_id { get; set; }
    public Decimal amount { get; set; }
    public DateTime date { get; set; } = DateTime.Now;
    public string description { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    public DateTime? update_at { get; set; }
}

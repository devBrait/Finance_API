namespace Finance_Core.Entities;

public class Budget
{
    public int id { get; set; }
    public int user_id { get; set; }
    public int category_id { get; set; }
    public Decimal amount { get; set; }
    public DateTime start_date { get; set; }
    public DateTime end_date { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}

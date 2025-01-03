using Finance_Core.Enums;

namespace Finance_Core.Entities;

public class Category
{
    public int id { get; set; }
    public string name { get; set; }
    public CategoryEnum type { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}

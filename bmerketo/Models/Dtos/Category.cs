using bmerketo.Models.Entities;

namespace bmerketo.Models.Dtos;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

    public static implicit operator CategoryEntity(Category category)
    {
        return new CategoryEntity
        {
            Id = category.Id,
            CategoryName = category.CategoryName
        };
    }
}

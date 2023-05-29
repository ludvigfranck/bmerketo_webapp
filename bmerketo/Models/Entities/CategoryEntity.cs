using bmerketo.Models.Dtos;

namespace bmerketo.Models.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

    public static implicit operator Category(CategoryEntity entity)
    {
        return new Category
        {
            Id = entity.Id,
            CategoryName = entity.CategoryName
        };
    }
}

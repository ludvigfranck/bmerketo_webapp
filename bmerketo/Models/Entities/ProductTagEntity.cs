using bmerketo.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Models.Entities;

[PrimaryKey(nameof(ArticleNumber), nameof(TagId))]
public class ProductTagEntity
{
    public Guid ArticleNumber { get; set; }
    public ProductEntity Product { get; set; } = null!;

    public int TagId { get; set; }
    public TagEntity Tag { get; set; } = null!;

    public static implicit operator Product(ProductTagEntity entity)
    {
        return new Product
        {
            ArticleNumber = entity.ArticleNumber.ToString()
        };
    }

    public static implicit operator Tag(ProductTagEntity entity)
    {
        return new Tag
        {
            Id = entity.TagId
        };
    }
}

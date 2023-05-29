using bmerketo.Models.Dtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo.Models.Entities;

public class ProductEntity
{
    [Key]
    public Guid ArticleNumber { get; set; } = Guid.NewGuid();
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }
    public string? ImageUrl { get; set; }


    [ForeignKey(nameof(ProductCategory))]
    public int ProductCategoryId { get; set; }
    public CategoryEntity ProductCategory { get; set; } = null!;

    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();


    public static implicit operator Product(ProductEntity entity)
    {
        return new Product
        {
            ArticleNumber = entity.ArticleNumber.ToString(),
            ProductName = entity.ProductName,
            ProductDescription = entity.ProductDescription,
            ProductPrice = entity.ProductPrice,
            ImageUrl = entity.ImageUrl,
            CategoryId = entity.ProductCategoryId
        };
    }
}

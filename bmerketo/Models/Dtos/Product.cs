using bmerketo.Models.Entities;
using bmerketo.Models.ViewModels;

namespace bmerketo.Models.Dtos;

public class Product
{
    public string? ArticleNumber { get; set; }
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();

    public static implicit operator ProductEntity(Product product)
    {
        return new ProductEntity
        {
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            ProductPrice = product.ProductPrice,
            ProductCategoryId = product.CategoryId
        };
    }

    public static implicit operator GridCollectionItemViewModel(Product product)
    {
        return new GridCollectionItemViewModel
        {
            ArticleNumber = product.ArticleNumber,
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            ProductPrice = product.ProductPrice,
            Category = product.Category,
            ImageUrl = product.ImageUrl,
        };
    }
}

using bmerketo.Models.Dtos;

namespace bmerketo.Models.ViewModels;

public class GridCollectionItemViewModel
{
    public string? ArticleNumber { get; set; }
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public Category Category { get; set; } = null!;
    public string? ImageUrl { get; set; }

    public static implicit operator Product(GridCollectionItemViewModel viewModel)
    {
        return new Product
        {
            ArticleNumber = viewModel.ArticleNumber,
            ProductName = viewModel.ProductName,
            ProductDescription = viewModel.ProductDescription,
            ProductPrice = viewModel.ProductPrice,
            Category = viewModel.Category,
            ImageUrl = viewModel.ImageUrl,
        };
    }
}

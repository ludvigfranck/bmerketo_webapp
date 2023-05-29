using bmerketo.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models.ViewModels;

public class AddProductFormViewModel
{
    [Display(Name = "Product Name")]
    [Required(ErrorMessage = "Product Name is required!")]
    public string ProductName { get; set; } = null!;

    [Display(Name = "Product Description")]
    public string? ProductDescription { get; set; }

    [Display(Name = "Product Price")]
    [Required(ErrorMessage = "Product Price is required!")]
    public decimal ProductPrice { get; set; }


    public static implicit operator Product(AddProductFormViewModel viewModel)
    {
        return new Product
        {
            ProductName = viewModel.ProductName,
            ProductDescription = viewModel.ProductDescription,
            ProductPrice = viewModel.ProductPrice
        };
    }
}

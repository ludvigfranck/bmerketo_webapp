using bmerketo.Helpers.Services;
using bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(Guid articleNumber)
    {
        var viewModel = new ProductDetailsViewModel
        {
            Product = await _productService.GetProductAsync(articleNumber),
        };
        return View(viewModel);
    }
}

using bmerketo.Helpers.Services;
using bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public HomeController(ProductService productService, CategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            FeaturedCollection = new GridCollectionViewModel
            {
                Title = "Featured",
                Categories = await _categoryService.GetAllCategoriesNamesAsync(),
                GridItems = await _productService.GetAllProductsAsync("Featured"),
                LoadMore = false
            },
            NewCollection = new GridCollectionViewModel
            {
                Title = "New",
                Categories = await _categoryService.GetAllCategoriesNamesAsync(),
                GridItems = await _productService.GetAllProductsAsync("New"),
                LoadMore = false
            },
            PopularCollection = new GridCollectionViewModel 
            { 
                Title ="Popular",
                Categories = await _categoryService.GetAllCategoriesNamesAsync(),
                GridItems= await _productService.GetAllProductsAsync("Popular"),
                LoadMore = false
            }
        };

        return View(viewModel);
    }
}

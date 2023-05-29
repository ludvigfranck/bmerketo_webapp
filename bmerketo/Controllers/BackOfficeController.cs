using bmerketo.Helpers.Services;
using bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

[Authorize(Roles = "admin")]
public class BackOfficeController : Controller
{
    private readonly ProductService _productService;
    private readonly UserProfileService _userProfileService;
    private readonly UserService _userService;
    private readonly CategoryService _categoryService;
    private readonly TagService _tagService;
    private readonly AuthService _authService;

    public BackOfficeController(ProductService productService, UserProfileService userProfileService, UserService userService, CategoryService categoryService, TagService tagService, AuthService authService)
    {
        _productService = productService;
        _userProfileService = userProfileService;
        _userService = userService;
        _categoryService = categoryService;
        _tagService = tagService;
        _authService = authService;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new BackOfficeViewModel()
        {
            ProductsTitle = "Products",
            Products = await _productService.GetAllProductsAsync(),
            UsersTitle = "Users",
            Users = await _userProfileService.GetAllUsersProfileAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(string roleName, string userId)
    {
        var user = await _userService.GetUserAsync(userId);
        if (user != null)
        {
            await _userService.ChangeUserRoleAsync(roleName, user);
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RegisterProduct()
    {

        ViewBag.Categories = await _categoryService.GetCategoriesAsync();
        ViewBag.Tags = await _tagService.GetTagsAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProduct(AddProductFormViewModel viewModel, string[] tags, string categoryId)
    {
        if (ModelState.IsValid)
        {
            if (await _productService.CreateProductAsync(viewModel, categoryId, tags) != null)
                return LocalRedirect("/backoffice");
        }

        ViewBag.Tags = await _tagService.GetTagsAsync(tags);
        ViewBag.Categories = await _categoryService.GetCategoriesAsync();
        ModelState.AddModelError("", "Something went wrong!");
        return View(viewModel);
    }

    public IActionResult RegisterUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(SignUpFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.UserExistsAsync(viewModel))
            {
                if (await _authService.SignUpUserAsync(viewModel))
                    return LocalRedirect("/backoffice");

                ModelState.AddModelError("", "Something went wrong...");
            }

            ModelState.AddModelError("", "A user with the same email already exists!");
        }

        return View(viewModel);
    }
}

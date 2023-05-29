using bmerketo.Helpers.Services;
using bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

public class ContactController : Controller
{
    private readonly CommentService _commentService;

    public ContactController(CommentService commentService)
    {
        _commentService = commentService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactUsFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _commentService.SaveUserCommentAsync(viewModel) != null)
                return RedirectToAction("index", "home");

            ModelState.AddModelError("", "Something went wrong...");
        }

        return View(viewModel);
    }
}

﻿using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

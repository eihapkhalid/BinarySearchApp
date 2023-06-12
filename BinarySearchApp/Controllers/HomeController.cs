using BinarySearchApp.Models;
using Domains.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BinarySearchApp.Controllers
{
    public class HomeController : Controller
    {
            public IActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Index(BinarySearchViewModel model)
            {
                if (ModelState.IsValid)
                {
                    int[] array = model.SearchArray;
                    int element = model.SearchElement;
                }

                return View(model);
            }
    }
}
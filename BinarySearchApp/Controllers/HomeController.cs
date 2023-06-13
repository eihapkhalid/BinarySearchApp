using BinarySearchApp.Models;
using Domains.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BinarySearchApp.Controllers
{
    public class HomeController : Controller
    {
        #region Index Page
        public IActionResult Index()
        {
            return View();
        } 
        #endregion

        #region Post String Text And Convert It To Array 
        [HttpPost]
        public IActionResult Index(BinarySearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.SearchArray))
                {
                    int[] array = model.SearchArray.Split(' ').Select(int.Parse).ToArray();
                    int element = model.SearchElement;

                    int result = BinarySearch(array, element);

                    if (result != -1)
                    {
                        ViewBag.Result = $"Element {element} found at index {result}";
                    }
                    else
                    {
                        ViewBag.Result = $"Element {element} not found in the array";
                    }
                }
            }

            return View(model);
        } 
        #endregion

        #region BinarySearch
        private int BinarySearch(int[] array, int element)
        {
            int left = 0;
            int right = array.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == element)
                {
                    result = mid;
                    break;
                }

                if (array[mid] < element)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        } 
        #endregion
    }

}

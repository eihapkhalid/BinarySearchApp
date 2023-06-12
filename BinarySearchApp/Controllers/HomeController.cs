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

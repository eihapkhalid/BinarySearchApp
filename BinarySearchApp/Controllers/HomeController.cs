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
                    string text = model.SearchArray;
                    string word = model.SearchElement;

                    int result = text.IndexOf(word);

                    if (result != -1)
                    {
                        ViewBag.Result = $"Word '{word}' found at index {result}";
                    }
                    else
                    {
                        ViewBag.Result = $"Word '{word}' not found in the text";
                    }
                }
            }

            return View(model);
        }
        #endregion

        #region BinarySearch
        private int BinarySearch(string[] array, string element)
        {
            int left = 0;
            int right = array.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid].Contains(element))
                {
                    result = mid;
                    break;
                }

                if (string.Compare(array[mid], element) < 0)
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

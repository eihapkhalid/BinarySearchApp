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
                    string searchTerm = model.SearchElement;
                    bool isNumericOrOrdered = IsNumericOrOrderedString(searchTerm);

                    if (isNumericOrOrdered)
                    {
                        int[] array = model.SearchArray.Split(' ').Where(str => int.TryParse(str, out _)).Select(int.Parse).ToArray();
                        int element = Convert.ToInt32(searchTerm);

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
                    else
                    {
                        string text = model.SearchArray;
                        int result = text.IndexOf(searchTerm);

                        if (result != -1)
                        {
                            ViewBag.Result = $"Word '{searchTerm}' found at index {result}";
                        }
                        else
                        {
                            ViewBag.Result = $"Word '{searchTerm}' not found in the text";
                        }
                    }
                }
            }

            return View(model);
        }

        #region IsNumericOrOrderedString
        private bool IsNumericOrOrderedString(string value)
        {
            bool isNumeric = value.All(char.IsDigit);
            bool isOrdered = IsOrderedString(value);

            return isNumeric || isOrdered;
        }
        #endregion

        #region IsOrderedString
        private bool IsOrderedString(string value)
        {
            for (int i = 1; i < value.Length; i++)
            {
                if (value[i] < value[i - 1])
                {
                    return false;
                }
            }

            return true;
        } 
        #endregion

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

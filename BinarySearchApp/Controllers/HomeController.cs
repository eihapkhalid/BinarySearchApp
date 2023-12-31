﻿using BinarySearchApp.Models;
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
                    //bool isNumericOrOrdered = IsNumericOrOrderedString(searchTerm);
                    bool isNumericOrOrdered = IsNumericOrOrderedString(searchTerm) || IsAlphabeticallyOrderedString(searchTerm);

                    if (isNumericOrOrdered)
                    {
                        //int[] array = model.SearchArray.Split(' ').Where(str => int.TryParse(str, out _)).Select(int.Parse).ToArray();
                        string[] array = model.SearchArray.Split(' ');

                        int result = -1;
                        int element = 0;

                        if (int.TryParse(searchTerm, out int parsedElement))
                        {
                            element = parsedElement;
                            string[] stringArray = array.Select(x => x.ToString()).ToArray();
                            result = BinarySearch(stringArray, element.ToString());
                        }
                        else
                        {
                            result = BinarySearch(array, searchTerm);
                        }

                        if (result != -1)
                        {
                            ViewBag.Result = $"Element {searchTerm} found at index {result}";
                        }
                        else
                        {
                            ViewBag.Result = $"Element {searchTerm} not found in the array";
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
            /*bool isNumeric = value.All(char.IsDigit);
            bool isOrdered = IsOrderedString(value);*/
            bool isNumeric = int.TryParse(value, out _);
            bool isOrdered = string.Concat(value.OrderBy(c => c)) == value;
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

        #region IsAlphabeticallyOrderedString
        private bool IsAlphabeticallyOrderedString(string value)
        {
            string orderedValue = string.Concat(value.OrderBy(c => c));

            return value == orderedValue;
        } 
        #endregion

        #endregion

        #region BinarySearch
        private int BinarySearch(string[] array, string element)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                int result = string.Compare(array[middle], element);

                if (result == 0)
                {
                    return middle;
                }
                else if (result < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }

        #endregion
    }
}

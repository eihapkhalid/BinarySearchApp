# BinarySearchApp

The displayed code is the `Index` function that is called when a POST request is sent to the "/Index" endpoint in the project. The function performs a search on the data using the Binary Search or Text Search algorithm based on the specified conditions.

# The function follows these steps:

1. It checks the validity of the model using `ModelState.IsValid`.
2. It checks that the search data is not empty using `string.IsNullOrEmpty(model.SearchArray)`.
3. The search term value is extracted from the model.
4. It checks whether the desired search value consists of ascending numbers or not using `IsNumericOrOrderedString(searchTerm)`.
5. If the desired value meets the numeric or ordered conditions, the textual data is converted into an array of ordered numbers, and the Binary Search algorithm is executed on it.
6. If the desired value does not meet the numeric or ordered conditions, the text is searched within the textual data using `IndexOf`.
7. The result is determined, and the `ViewBag.Result` value is set based on the search result.
8. The model is returned to the view.

Additionally, two additional functions `IsNumericOrOrderedString` and `IsOrderedString` are defined to check whether the desired value meets the numeric or ordered conditions.

As for the Binary Search algorithm, it is defined in the `BinarySearch` function. The algorithm searches for the desired element in an ascendingly sorted array.

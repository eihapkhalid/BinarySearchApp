# BinarySearchApp

The displayed code is the `Index` function that is called when a POST request is sent to the "/Index" endpoint in the project. The function performs a search on the data using the Binary Search or Text Search algorithm based on the specified conditions.

# The function follows these steps:
Here's a rephrased version of the missing part:

- The `Index` function:
  - Receives a POST request from the Index page and processes the `BinarySearchViewModel` model.
  - Checks the validity of the model using `ModelState.IsValid`.
  - If the input string is not empty, extracts the search item value (`searchTerm`) from the model.
  - Checks whether the input string is numeric or alphabetically ordered using the `IsNumericOrOrderedString` and `IsAlphabeticallyOrderedString` functions.
  - If the string is numeric or ordered, splits the input string into an array of strings (`array`) using the space as a separator.
  - Creates a variable `result` with a default value of -1 and a variable `element` with a default value of 0.
  - If the conversion of `searchTerm` to a number is successful, assigns the converted value to the `element` variable and converts the array of strings `array` to an array of strings (`stringArray`) using the `Select` function and converting each element to a string.
  - Calls the `BinarySearch` function with the array of strings `stringArray` and the search item converted to a string (`element.ToString()`), and stores the result in the `result` variable.
  - If the conversion fails, calls the `BinarySearch` function with the array of strings `array` and the search item (`searchTerm`), and stores the result in the `result` variable.
  - If the result is not -1, displays a success message with the found item and its index in `ViewBag.Result`.
  - If the result is -1, displays a failure message indicating that the item was not found in `ViewBag.Result`.
  - Returns the model to the initial view, `Index`.

- Custom functions:

  - `IsNumericOrOrderedString`: Checks whether the passed string is a numeric value or alphabetically ordered. Uses `int.TryParse` to check if the string can be converted to a number. Uses `string.Concat` and `OrderBy` to check if the string is alphabetically ordered.

  - `IsAlphabeticallyOrderedString`: Checks whether the passed string is alphabetically ordered. Orders the characters in the string and compares it with the original string.

  - `BinarySearch`: Implements the binary search algorithm on the array of strings `array` to find the `element`. Uses the variables `left` and `right` to track the current range boundaries for the search. Uses a `while` loop to repeat the process until the element is found or until the entire range is explored without finding the element. Uses `string.Compare` to compare the middle element in the current range with the searched element and moves to the right or left half of the range based on the result.

- الدالة `Index`:
  - تستقبل طلب POST من صفحة الفهرسة (Index) وتقوم بمعالجة النموذج `BinarySearchViewModel`.
  - تتحقق من صحة النموذج باستخدام `ModelState.IsValid`.
  - إذا كانت السلسلة المدخلة غير فارغة، يتم استخراج قيمة عنصر البحث (`searchTerm`) من النموذج.
  - يتم التحقق مما إذا كانت السلسلة المدخلة رقمية أو مرتبة أبجديًا باستخدام الدوال `IsNumericOrOrderedString` و `IsAlphabeticallyOrderedString`.
  - إذا كانت السلسلة رقمية أو مرتبة، يتم تقسيم السلسلة المدخلة إلى مصفوفة من السلاسل (`array`) بواسطة الفراغ كفاصل.
  - يتم إنشاء متغير `result` بقيمة افتراضية -1 ومتغير `element` بقيمة افتراضية 0.
  - إذا نجحت عملية تحويل `searchTerm` إلى رقم، يتم تعيين القيمة المحولة في المتغير `element` وتحويل مصفوفة السلاسل `array` إلى مصفوفة من السلاسل (`stringArray`) بواسطة دالة `Select` وتحويل كل عنصر إلى سلسلة.
  - يتم استدعاء دالة `BinarySearch` مع مصفوفة السلاسل `stringArray` وعنصر البحث المحول إلى سلسلة (`element.ToString()`) ويتم تخزين النتيجة في المتغير `result`.
  - إذا فشلت عملية التحويل، يتم استدعاء دالة `BinarySearch` مع مصفوفة السلاسل `array` وعنصر البحث (`searchTerm`) ويتم تخزين النتيجة في المتغير `result`.
  - إذا كانت النتيجة ليست -1، يتم عرض رسالة نجاح بالعنصر الموجود ومؤشره في `ViewBag.Result`.
  - إلا إذا كانت النتيجة -1، يتم عرض رسالة فشل بعدم وجود العنصر في `ViewBag.Result`.
  - إلا إذا كانت النتيجة -1، يتم عرض رسالة فشل بعدم وجود العنصر في `ViewBag.Result`.
  - تُرجع النموذج إلى العرض الأولي `Index`.

- الدوال الخاصة:

  - `IsNumericOrOrderedString`: تقوم بالتحقق مما إذا كانت السلسلة الممررة إليها قيمة رقمية أو مرتبة أبجديًا. تستخدم `int.TryParse` للتحقق مما إذا كانت السلسلة قابلة للتحويل إلى رقم. وتستخدم `string.Concat` و `OrderBy` للتحقق مما إذا كانت السلسلة مرتبة أبجديًا.

  - `IsAlphabeticallyOrderedString`: تقوم بالتحقق مما إذا كانت السلسلة الممررة إليها مرتبة أبجديًا. تقوم بترتيب الأحرف في السلسلة ومقارنتها بالسلسلة الأصلية.

  - `BinarySearch`: تقوم بتنفيذ خوارزمية البحث الثنائي على مصفوفة السلاسل `array` للعثور على العنصر `element`. تستخدم المتغيرات `left` و `right` لتتبع حدود النطاق الحالي للبحث. تستخدم حلقة `while` لتكرار العملية حتى يتم العثور على العنصر أو حتى يتم استكشاف كل النطاق وعدم العثور على العنصر. تستخدم `string.Compare` لمقارنة العنصر المتوسط في النطاق الحالي مع العنصر المبحوث عنه وتتحرك إلى النصف الأيمن أو النصف الأيسر من النطاق بناءً على النتيجة.
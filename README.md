# PaginatorTool

The `PaginatorTool` is a .NET library that provides a generic paginator for paginating an `IEnumerable` collection. It allows you to break down large collections into smaller pages, making it easier to navigate and display data incrementally. This tool is particularly useful when you want to present data in a user-friendly manner, such as when building user interfaces with pagination functionality.

## Getting Started

### Prerequisites

To use the `PaginatorTool`, you need to have the following:

- .NET Core 3.1 or higher (or .NET Framework 4.7.2 or higher).
- A C# development environment, such as Visual Studio or Visual Studio Code.

### Usage

After installing the `PaginatorTool` package, you can start using the paginator in your code.

1. First, import the `PaginatorTool` namespace into your code file:

```csharp
using PaginatorTool;
```

2. Create an IEnumerable collection that you want to paginate. For example:

```csharp
IEnumerable<string> myData = GetYourData(); // Replace with your actual data source.
```

3. Use the Paginator class to create a paginator:
```csharp
Paginator<string> paginator = new Paginator<string>(myData, range: 10, prevPageKey: ConsoleKey.LeftArrow, nextPageKey: ConsoleKey.RightArrow, stepChange: 1);
```
4. Now, you can interact with the paginator to navigate through the data:
```csharp
paginator.SetNext(); // Move to the next page.
paginator.SetPrev(); // Move to the previous page.

IEnumerable<string> currentPageData = paginator.CurrentState(); // Get the data for the current page.

(int currentPage, int totalPages) = paginator.GetPageStateInfo(); // Get information about the current page and the total number of pages.
```
Alternatively, you can use the extension method to create a paginator:

```csharp
using PaginatorTool.Extension;

IEnumerable<string> myData = GetYourData(); // Replace with your actual data source.

Paginator<string> paginator = myData.Paginator(range: 10, prevPageKey: ConsoleKey.LeftArrow, nextPageKey: ConsoleKey.RightArrow, stepChange: 1);
```

# API Reference

## `Paginator<T>`

### Properties

- `Range`: Gets the number of items to be displayed per page.
- `StepChange`: Gets the step change value, representing the number of pages to skip when moving forward or backward.
- `Enumerator`: Gets the enumerator of the original `IEnumerable` collection.

### Methods

- `SetRange(int range)`: Sets a new range (number of items per page) and recalculates the total number of pages.
- `SetStepChange(int stepChange)`: Sets a new step change value, representing the number of pages to skip when moving forward or backward.
- `SetNext()`: Moves to the next page if there is one (within the total number of pages).
- `SetPrev()`: Moves to the previous page if there is one (starting from page 1).
- `CurrentState()`: Returns the `IEnumerable` collection representing the current page's items.
- `GetPageStateInfo()`: Gets information about the current page and the total number of pages.
- `ChangePageByKey(ConsoleKey userKeyAction)`: Moves to the next or previous page based on the provided user action.
- `SetNumberOfPages()`: Calculates and sets the total number of pages based on the number of items and the range.

## Extension Method

### Method

- `Paginator<T> Paginator<T>(this IEnumerable<T> enumerator, int range = 10, ConsoleKey prevPageKey = ConsoleKey.LeftArrow, ConsoleKey nextPageKey = ConsoleKey.RightArrow, int stepChange = 1) where T : class`: Creates a `Paginator<T>` instance from the given `IEnumerable` collection with customizable pagination settings.

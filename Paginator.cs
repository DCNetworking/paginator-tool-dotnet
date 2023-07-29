namespace PaginatorTool;
/// <summary>
/// Represents a generic paginator for paginating an IEnumerable collection.
/// </summary>
/// <typeparam name="T">The type of items in the IEnumerable collection.</typeparam>
public class Paginator<T> : IPaginator<T> where T : class
{


    /// <summary>
    /// Gets the number of items to be displayed per page.
    /// </summary>
    public int Range { get; private set; }

    /// <summary>
    /// Gets the step change value, representing the number of pages to skip when moving forward or backward.
    /// </summary>
    public int StepChange { get; private set; }

    #region Private
    private readonly IEnumerable<T> _query;
    private readonly ConsoleKey _prevPageKey;
    private readonly ConsoleKey _nextPageKey;
    private int _numberOfPages;
    private int _currentPage;
    #endregion

    /// <summary>
    /// Initializes a new instance of the Paginator class with the provided parameters.
    /// </summary>
    /// <param name="query">The IEnumerable collection to be paginated.</param>
    /// <param name="range">The number of items to be displayed per page. Must be greater than 0.</param>
    /// <param name="prevPageKey">The ConsoleKey representing the key to navigate to the previous page.</param>
    /// <param name="nextPageKey">The ConsoleKey representing the key to navigate to the next page.</param>
    /// <param name="stepChange">The step change value, representing the number of pages to skip when moving forward or backward.</param>
    /// <exception cref="ArgumentNullException">Thrown when the 'query' parameter is null.</exception>
    /// <exception cref="ArgumentException">Thrown when 'range' is less than or equal to 0.</exception>
    public Paginator(
        IEnumerable<T> query,
        int range = 10,
        ConsoleKey prevPageKey = ConsoleKey.LeftArrow,
        ConsoleKey nextPageKey = ConsoleKey.RightArrow,
        int stepChange = 1)
    {
        if (range <= 0)
            throw new ArgumentException("Cannot be less than or equal to 0", nameof(range));

        _query = query ?? throw new ArgumentNullException(nameof(query));
        Range = range;
        _prevPageKey = prevPageKey;
        _nextPageKey = nextPageKey;
        _currentPage = 1;
        StepChange = stepChange;
        SetNumberOfPages();
    }

    /// <summary>
    /// Sets a new range (number of items per page) and recalculates the total number of pages.
    /// </summary>
    /// <param name="range">The new range value. Must be greater than 0.</param>
    /// <exception cref="ArgumentException">Thrown when 'range' is less than or equal to 0.</exception>
    public virtual void SetRange(int range)
    {
        if (range <= 0)
            throw new ArgumentException("Cannot be less than or equal to 0", nameof(range));

        Range = range;
        SetNumberOfPages();
    }

    /// <summary>
    /// Sets a new step change value, representing the number of pages to skip when moving forward or backward.
    /// </summary>
    /// <param name="stepChange">The new step change value.</param>
    public virtual void SetStepChange(int stepChange)
    {
        StepChange = stepChange;
    }

    /// <summary>
    /// Moves to the next page if there is one (within the total number of pages).
    /// </summary>
    public virtual void SetNext()
    {
        if (_currentPage < _numberOfPages)
        {
            _currentPage += StepChange;
        }
    }

    /// <summary>
    /// Moves to the previous page if there is one (starting from page 1).
    /// </summary>
    public virtual void SetPrev()
    {
        if (_currentPage > 1)
        {
            _currentPage -= StepChange;
        }
    }

    /// <summary>
    /// Returns the IEnumerable collection representing the current page's items.
    /// </summary>
    /// <returns>The IEnumerable collection for the current page.</returns>
    public virtual IEnumerable<T> CurrentState()
    {
        return _query.Skip(Range * (_currentPage - 1)).Take(Range);
    }

    /// <summary>
    /// Gets information about the current page and the total number of pages.
    /// </summary>
    /// <returns>A tuple containing the current page number and the total number of pages.</returns>
    public virtual (int CurrentPage, int NumberOfPages) GetPageStateInfo()
    {
        return (_currentPage, _numberOfPages);
    }

    /// <summary>
    /// Moves to the next or previous page based on the provided user action.
    /// </summary>
    /// <param name="userKeyAction">The ConsoleKey representing the user action.</param>
    public void ChangePageByKey(ConsoleKey userKeyAction)
    {
        if (userKeyAction == _prevPageKey && _currentPage > 1)
        {
            SetPrev();
        }
        else if (userKeyAction == _nextPageKey && _currentPage < _numberOfPages)
        {
            SetNext();
        }
    }

    /// <summary>
    /// Calculates and sets the total number of pages based on the number of items and the range.
    /// </summary>
    protected virtual void SetNumberOfPages()
    {
        decimal pagesCounterHelper = ((decimal)_query.Count() / (decimal)Range);
        _numberOfPages = (int)Math.Ceiling(pagesCounterHelper);
    }
}
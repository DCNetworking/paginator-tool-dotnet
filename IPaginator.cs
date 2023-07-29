using System;
namespace PaginatorTool
{
    /// <summary>
    /// Represents the contract for a generic paginator.
    /// </summary>
    /// <typeparam name="T">The type of items in the IQueryable collection.</typeparam>
    public interface IPaginator<T> where T : class
    {
        /// <summary>
        /// Sets a new range (number of items per page).
        /// </summary>
        /// <param name="range">The new range value. Must be greater than 0.</param>
        void SetRange(int range);

        /// <summary>
        /// Moves to the next page.
        /// </summary>
        void SetNext();

        /// <summary>
        /// Moves to the previous page.
        /// </summary>
        void SetPrev();

        /// <summary>
        /// Returns the IEnumerable collection representing the current page's items.
        /// </summary>
        /// <returns>The IEnumerable collection for the current page.</returns>
        IEnumerable<T> CurrentState();

        /// <summary>
        /// Gets information about the current page and the total number of pages.
        /// </summary>
        /// <returns>A tuple containing the current page number and the total number of pages.</returns>
        (int CurrentPage, int NumberOfPages) GetPageStateInfo();
    }
}


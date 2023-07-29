namespace PaginatorTool.Extension
{
    public static class PaginatorExtension
    {
        public static Paginator<T> Paginator<T>(
            this IEnumerable<T> enumerator,
            int range = 10,
            int stepChange = 1)
            where T : class
        {
            return new Paginator<T>(enumerator, range, stepChange);
        }
    }
}


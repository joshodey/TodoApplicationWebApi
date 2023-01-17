namespace MyTodo_Application.Helper
{
    public class PageList<T> : List<T>
    {
        public MetaData Meta { get; set; }

        public PageList(List<T> items, int count, int pagenumber, int pagesize)
        {
            MetaData metaData = new MetaData
            {
                TotalCount = count,
                Pagesize = pagesize,
                TotalPages = (int)Math.Ceiling(count / (double)pagesize),
                CurrentPage = pagenumber
            };
            AddRange(items);
        }

        public static PageList<T> ToPagedList(IEnumerable<T> sources, int pagenumber, int pagesize)
        {
            var count = sources.Count();
            var items = sources
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize).ToList();
            return new PageList<T>(items, count, pagenumber, pagesize);

        }
    }
}

namespace MyTodo_Application.Helper
{
    public class RequestParameter
    {
        const int MaxPageSize = 10;

        public int PageNumber { get; set; } = 1;
        private int _pagesize;
        public int PageSize { 
            get { return _pagesize; } 
            set { _pagesize = (value > MaxPageSize) ? MaxPageSize : value; } }

    }
}

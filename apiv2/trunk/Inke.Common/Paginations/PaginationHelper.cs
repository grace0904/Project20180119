
namespace Inke.Common.Paginations
{
    public class PaginationHelper
    {
        /// <summary>
        /// 封装分页对象
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public static PaginationParameter GetPaging(int pageIndex)
        {
            var _pagenationParameter = new PaginationParameter();
            _pagenationParameter.StartIndex = (pageIndex - 1) * 8;
            _pagenationParameter.MaxCount = 8;
            //实例化参数
            var _sortingParameter = new SortingParameter<DefaultSortBy>(DefaultSortBy.Default, SortingDirection.Ascending);
            var _sortingParameterArray = new SortingParameter<DefaultSortBy>[1] { _sortingParameter };
            _pagenationParameter.Sortings = _sortingParameterArray;
            return _pagenationParameter;
        }

        /// <summary>
        /// 倒序
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public static PaginationParameter GetPagingByDescend(int pageIndex)
        {
            var _pagenationParameter = new PaginationParameter();
            _pagenationParameter.StartIndex = (pageIndex - 1) * 8;
            _pagenationParameter.MaxCount = 8;
            //实例化参数
            var _sortingParameter = new SortingParameter<DefaultSortBy>(DefaultSortBy.Default, SortingDirection.Descending);
            var _sortingParameterArray = new SortingParameter<DefaultSortBy>[1] { _sortingParameter };
            _pagenationParameter.Sortings = _sortingParameterArray;
            return _pagenationParameter;
        }

        /// <summary>
        /// 倒序
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static PaginationParameter GetPagingByDescend(int pageIndex, int count)
        {
            var _pagenationParameter = new PaginationParameter();
            _pagenationParameter.StartIndex = (pageIndex - 1) * count;
            _pagenationParameter.MaxCount = count;
            //实例化参数
            var _sortingParameter = new SortingParameter<DefaultSortBy>(DefaultSortBy.Default, SortingDirection.Descending);
            var _sortingParameterArray = new SortingParameter<DefaultSortBy>[1] { _sortingParameter };
            _pagenationParameter.Sortings = _sortingParameterArray;
            return _pagenationParameter;
        }

        public static PaginationParameter GetPaging(int pageIndex, int count)
        {
            var _pagenationParameter = new PaginationParameter();
            _pagenationParameter.StartIndex = (pageIndex - 1) * count;
            _pagenationParameter.MaxCount = count;
            //实例化参数
            var _sortingParameter = new SortingParameter<DefaultSortBy>(DefaultSortBy.Default, SortingDirection.Ascending);
            var _sortingParameterArray = new SortingParameter<DefaultSortBy>[1] { _sortingParameter };
            _pagenationParameter.Sortings = _sortingParameterArray;
            return _pagenationParameter;
        }

        /// <summary>
        /// 获取pageSize
        /// </summary>
        public static int GetPageSize(int? pageSize)
        {
            int _pageSize = pageSize ?? 10;
            if (pageSize != null && pageSize > 100)
                _pageSize = 100;

            if (pageSize != null && pageSize < 10)
                _pageSize = 10;

            return _pageSize;
        }

        /// <summary>
        /// 获取最大的pageSize
        /// </summary>
        public static int GetMaxPageCount(int? pageSize)
        {
            int _pageSize = pageSize ?? 100;
            if (pageSize != null && pageSize > 100)
                _pageSize = 100;

            if (pageSize != null && pageSize < 10)
                _pageSize = 10;

            return _pageSize;
        }

        public static PaginationParameter<TSortBy> GetPaging<TSortBy>(
            int pageIndex, int count, TSortBy defaultSortBy, int OrderDirection=2)
        {
            var pagenationParameter = new PaginationParameter<TSortBy>();
            pagenationParameter.StartIndex = (pageIndex - 1) * count;
            pagenationParameter.MaxCount = count;
            //实例化参数
            //var sortingParameter = new SortingParameter<TSortBy>(defaultSortBy,
            //SortingDirection.Ascending);
            //修改为默认降序排列
            var sortingParameter = new SortingParameter<TSortBy>(defaultSortBy,
                SortingDirection.Descending);
            if (OrderDirection == 1)
            {
                sortingParameter = new SortingParameter<TSortBy>(defaultSortBy,
          SortingDirection.Ascending);
            }
            var sortingParameterArray = new[] { sortingParameter };
            pagenationParameter.Sortings = sortingParameterArray;
            return pagenationParameter;
        }
        /// <summary>
        /// 分页方法重载（根据传入参数的OrderDirection顺序排序）
        /// </summary>
        /// <typeparam name="TSortBy"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="count"></param>
        /// <param name="defaultSortBy"></param>
        /// <param name="OrderDirection">1: asc, 2: desc</param>
        /// <returns></returns>
      /*  public static PaginationParameter<TSortBy> GetPaging<TSortBy>(
           int pageIndex, int count, TSortBy defaultSortBy, int OrderDirection)
        {
            var pagenationParameter = new PaginationParameter<TSortBy>();
            pagenationParameter.StartIndex = (pageIndex - 1) * count;
            pagenationParameter.MaxCount = count;
            var sortingParameter = new SortingParameter<TSortBy>(defaultSortBy,
         SortingDirection.Ascending);
            if (OrderDirection == 2)
            {
                sortingParameter = new SortingParameter<TSortBy>(defaultSortBy,
          SortingDirection.Descending);
            }

            var sortingParameterArray = new[] { sortingParameter };
            pagenationParameter.Sortings = sortingParameterArray;
            return pagenationParameter;
        }*/
    }
}

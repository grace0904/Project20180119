
namespace Inke.Common.Paginations
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PaginationParameter : PaginationParameter<DefaultSortBy>
    {
    };

    public class PaginationParameter<TSortBy>
    {
        public int? StartIndex { get; set; }

        public int? MaxCount { get; set; }

        public SortingParameter<TSortBy>[] Sortings { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            var instance = obj as PaginationParameter<TSortBy>;
            if (instance == null)
                return false;

            return StartIndex == instance.StartIndex && MaxCount == instance.MaxCount &&
                   IsEquals(Sortings, instance.Sortings);
        }

        public override int GetHashCode()
        {
            return StartIndex.GetHashCode() * 179 + MaxCount.GetHashCode() * 31 +
                   (Sortings == null ? 0 : Sortings.GetHashCode());
        }

        private bool IsEquals(SortingParameter<TSortBy>[] pSortings, SortingParameter<TSortBy>[] pSortings2)
        {
            if (pSortings == null && pSortings2 == null)
            {
                return true;
            }
            if (pSortings == null || pSortings2 == null)
            {
                return false;
            }
            if (pSortings.Length != pSortings2.Length)
            {
                return false;
            }
            var result = false;
            for (var i = 0; i < pSortings.Length; i++)
            {
                if (pSortings[i].Direction != pSortings2[i].Direction)
                {
                    return false;
                }
                if (pSortings[i].SortBy.Equals(pSortings2[i].SortBy))
                {
                    result = true;
                }
                else
                {
                    return false;
                }
            }
            return result;
        }
    };
}

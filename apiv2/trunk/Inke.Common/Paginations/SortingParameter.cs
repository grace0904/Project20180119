using System;

namespace Inke.Common.Paginations
{
    [Serializable]
    public class SortingParameter<TSortBy>
    {
        public SortingParameter(TSortBy sortBy)
            : this(sortBy, SortingDirection.Ascending)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="direction"></param>
        public SortingParameter(TSortBy sortBy, SortingDirection direction)
        {
            SortBy = sortBy;
            Direction = direction;
        }

        public TSortBy SortBy { get; private set; }

        public SortingDirection Direction { get; private set; }
    }
}

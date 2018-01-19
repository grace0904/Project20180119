using Inke.Common.Paginations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Inke.Common.Extentions
{
    public class KeySelectors<TSource, TSortBy>
    {
        private readonly IDictionary<TSortBy, Action<IOrderByBuilder<TSource>, SortingParameter<TSortBy>>> _keySelectors
            = new Dictionary<TSortBy, Action<IOrderByBuilder<TSource>, SortingParameter<TSortBy>>>();

        public KeySelectors<TSource, TSortBy> Add<TKey>(TSortBy sorting, Expression<Func<TSource, TKey>> keySelector)
        {
            return Add(sorting, (builder, p) => builder.Append(keySelector, p.Direction));
        }

        public KeySelectors<TSource, TSortBy> Add(TSortBy sorting,
            Action<IOrderByBuilder<TSource>, SortingParameter<TSortBy>> keySelector)
        {
            _keySelectors.Add(sorting, keySelector);
            return this;
        }

        public void AppendTo(IOrderByBuilder<TSource> orderByBuilder, SortingParameter<TSortBy> sorting)
        {
            _keySelectors[sorting.SortBy](orderByBuilder, sorting);
        }
    }
}

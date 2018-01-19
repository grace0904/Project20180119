using Inke.Common.Paginations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inke.Common.Extentions
{
    internal class OrderByBuilder<TSource> : IOrderByBuilder<TSource>
    {
        private System.Linq.IOrderedQueryable<TSource> _orderedQueryable;
        private readonly System.Linq.IQueryable<TSource> _queryable;

        public OrderByBuilder(System.Linq.IQueryable<TSource> queryable)
        {
            _queryable = queryable;
        }

        public OrderByBuilder(System.Linq.IOrderedQueryable<TSource> orderedQueryable)
        {
            _queryable = null;
            _orderedQueryable = orderedQueryable;
        }

        public System.Linq.IOrderedQueryable<TSource> OrderedQueryable
        {
            get
            {
                if (_orderedQueryable == null)
                    throw new InvalidOperationException("No sorting applied");
                return _orderedQueryable;
            }
        }

        public IOrderByBuilder<TSource> Append<TKey>(Expression<Func<TSource, TKey>> keySelector,
            SortingDirection direction)
        {
            if (_orderedQueryable == null)
            {
                _orderedQueryable = _queryable.OrderBy(keySelector, direction);
            }
            else
            {
                _orderedQueryable = _orderedQueryable.ThenBy(keySelector, direction);
            }

            return this;
        }
    }
}

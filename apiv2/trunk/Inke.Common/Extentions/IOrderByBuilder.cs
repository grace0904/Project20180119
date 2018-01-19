using Inke.Common.Paginations;
using System;
using System.Linq.Expressions;

namespace Inke.Common.Extentions
{
    public interface IOrderByBuilder<TSource>
    {
        IOrderByBuilder<TSource> Append<TKey>(Expression<Func<TSource, TKey>> keySelector, SortingDirection direction);
    }
}

using Inke.Common.Paginations;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Inke.Common.Extentions
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector, SortingDirection direction)
        {
            switch (direction)
            {
                case SortingDirection.Ascending:
                    return source.OrderBy(keySelector);

                case SortingDirection.Descending:
                    return source.OrderByDescending(keySelector);

                default:
                    throw new NotSupportedException("Unsupported direction");
            }
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector, SortingDirection direction)
        {
            switch (direction)
            {
                case SortingDirection.Ascending:
                    return source.ThenBy(keySelector);

                case SortingDirection.Descending:
                    return source.ThenByDescending(keySelector);

                default:
                    throw new NotSupportedException("Unsupported direction");
            }
        }

        private static IOrderedQueryable<TSource> OrderBy<TSource, TSortBy>(this IQueryable<TSource> source,
            Action<IOrderByBuilder<TSource>, SortingParameter<TSortBy>> keySelector,
            params SortingParameter<TSortBy>[] sortings)
        {
            if (sortings == null)
                throw new ArgumentNullException("sortings");

            if (sortings.Length == 0)
                throw new ArgumentException("at least one sorting required", "sortings");

            var ks = new OrderByBuilder<TSource>(source);

            foreach (var sorting in sortings)
            {
                keySelector(ks, sorting);
            }

            return ks.OrderedQueryable;
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource, TSortBy>(this IOrderedQueryable<TSource> source,
            Action<IOrderByBuilder<TSource>, SortingParameter<TSortBy>> keySelector,
            params SortingParameter<TSortBy>[] sortings)
        {
            if (sortings == null)
                throw new ArgumentNullException("sortings");

            if (sortings.Length == 0)
                throw new ArgumentException("at least one sorting required", "sortings");

            var ks = new OrderByBuilder<TSource>(source);

            foreach (var sorting in sortings)
            {
                keySelector(ks, sorting);
            }

            return ks.OrderedQueryable;
        }

        private static IQueryable<TSource> Paginate<TSource, TSortBy>(this IQueryable<TSource> source,
            Action<IOrderByBuilder<TSource>, SortingParameter<TSortBy>> keySelector,
            PaginationParameter<TSortBy> pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException("pagination");

            IQueryable<TSource> query = source.OrderBy(keySelector, pagination.Sortings);

            if (pagination.StartIndex.HasValue)
                query = query.Skip(pagination.StartIndex.Value);

            if (pagination.MaxCount.HasValue)
                query = query.Take(pagination.MaxCount.Value);

            return query;
        }

        public static IQueryable<TSource> Paginater<TSource, TSortBy>(this IQueryable<TSource> source,
            KeySelectors<TSource, TSortBy> keySelector, PaginationParameter<TSortBy> pagination) where TSource : class
        {
            return source.Paginate(keySelector.AppendTo, pagination);
        }
    }
}

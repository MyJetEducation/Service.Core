using System;
using System.Linq;
using System.Linq.Expressions;

namespace Service.Core.Domain.Extensions
{
	public static class QueriableExtensions
	{
		public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, bool predicate, Expression<Func<T, bool>> expression) => predicate
			? queryable.Where(expression)
			: queryable;
	}
}
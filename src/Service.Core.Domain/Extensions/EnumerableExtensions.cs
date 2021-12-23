using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Core.Domain.Extensions
{
	public static class EnumerableExtensions
	{
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) => enumerable == null || !enumerable.Any();

		public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> enumerable, bool predicate, Func<T, bool> expression) => predicate
			? enumerable.Where(expression)
			: enumerable;
	}
}
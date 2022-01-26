using System.Linq;
using NUnit.Framework;
using Service.Core.Client.Extensions;

namespace Service.Core.Client.Tests.Extensions
{
	public class QueriableExtensionsTests
	{
		[Test]
		public void WhereIf_filter_collection_if_predicate_true()
		{
			IQueryable<int> queryable = new[] {1, 2}.AsQueryable();

			int[] result = queryable.WhereIf(true, i => i != 1).ToArray();

			Assert.AreEqual(1, result.Length);
			Assert.AreEqual(2, result[0]);
		}

		[Test]
		public void WhereIf_not_filter_collection_if_predicate_false()
		{
			IQueryable<int> queryable = new[] {1, 2}.AsQueryable();

			int[] result = queryable.WhereIf(false, i => i != 1).ToArray();

			Assert.AreEqual(2, result.Length);
			Assert.AreEqual(1, result[0]);
			Assert.AreEqual(2, result[1]);
		}
	}
}
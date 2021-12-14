using System;
using System.Collections.Generic;
using NUnit.Framework;
using Service.Core.Domain.Extensions;

namespace Service.Core.Tests.Extensions
{
	public class EnumerableExtensionsTests
	{
		[Test]
		public void IsNullOrEmpty_return_true_for_null_enumerable()
		{
			bool result = ((IEnumerable<string>) null).IsNullOrEmpty();

			Assert.IsTrue(result);
		}

		[Test]
		public void IsNullOrEmpty_return_true_for_empty_enumerable()
		{
			bool result = Array.Empty<bool>().IsNullOrEmpty();

			Assert.IsTrue(result);
		}

		[Test]
		public void IsNullOrEmpty_return_false_for_enumerable_with_elements()
		{
			bool result = new[] {"1"}.IsNullOrEmpty();

			Assert.IsFalse(result);
		}
	}
}
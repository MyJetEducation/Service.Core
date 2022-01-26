using System;
using System.Collections.Generic;
using NUnit.Framework;
using Service.Core.Extensions;

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

		[Test]
		public void Sum_by_time_span_return_total_value()
		{
			var items = new[]
			{
				new TestTimeSpanDto {Duration = new TimeSpan(1, 0, 5, 0, 1)},
				new TestTimeSpanDto {Duration = new TimeSpan(2, 3, 0, 7, 2)},
				new TestTimeSpanDto {Duration = new TimeSpan(0, 4, 6, 8, 3)}
			};

			TimeSpan result = items.Sum(dto => dto.Duration);

			Assert.AreEqual(3, result.Days);
			Assert.AreEqual(7, result.Hours);
			Assert.AreEqual(11, result.Minutes);
			Assert.AreEqual(15, result.Seconds);
			Assert.AreEqual(6, result.Milliseconds);
		}

		private class TestTimeSpanDto
		{
			public TimeSpan Duration { get; init; }
		}
	}
}
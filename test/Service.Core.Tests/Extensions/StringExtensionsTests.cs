using NUnit.Framework;
using Service.Core.Domain.Extensions;

namespace Service.Core.Tests.Extensions
{
	public class StringExtensionsTests
	{
		[TestCase(null)]
		[TestCase("")]
		public void IsNullOrEmpty_return_true(string value)
		{
			bool result = value.IsNullOrEmpty();

			Assert.IsTrue(result);
		}

		[Test]
		public void IsNullOrEmpty_return_false_for_filled_value()
		{
			bool result = "123".IsNullOrEmpty();

			Assert.IsFalse(result);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		[TestCase("  ")]
		public void IsNullOrWhiteSpace_return_true(string value)
		{
			bool result = value.IsNullOrWhiteSpace();

			Assert.IsTrue(result);
		}

		[Test]
		public void IsNullOrWhiteSpace_return_false_for_filled_value()
		{
			bool result = "123".IsNullOrWhiteSpace();

			Assert.IsFalse(result);
		}

		[TestCase("some_email@domain.com", "som**.co")]
		[TestCase("so@d.com", "s**m")]
		[TestCase("s@d.c", "*****")]
		public void Mask_return_masked_email(string email, string expected)
		{
			string masked = email.Mask();

			Assert.AreEqual(expected, masked);
		}
	}
}
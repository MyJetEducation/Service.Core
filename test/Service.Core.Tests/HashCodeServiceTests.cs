using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Service.Core.Domain;
using Service.Core.Domain.Models;

namespace Service.Core.Tests
{
	public class HashCodeServiceTests
	{
		private Mock<ISystemClock> _systemClock;
		private HashCodeService<TestDto> _hashCodeService;

		private class TestDto
		{
			public TestDto(string testField) => TestField = testField;

			public string TestField { get; set; }
		}

		[SetUp]
		public void Setup()
		{
			_systemClock = new Mock<ISystemClock>();

			_systemClock
				.Setup(clock => clock.Now)
				.Returns(new DateTime(2022, 10, 12));

			_hashCodeService = new HashCodeService<TestDto>(_systemClock.Object);
			_hashCodeService.SetTimeOut(30);
		}

		[Test]
		public void New_should_return_hash()
		{
			string hash = _hashCodeService.New(new TestDto("text"));

			Assert.IsNotNull(hash);
		}

		[Test]
		public void Get_should_return_data_by_hash()
		{
			string hash = _hashCodeService.New(new TestDto("text"));

			TestDto data = _hashCodeService.Get(hash);

			Assert.IsNotNull(data);
			Assert.AreEqual("text", data.TestField);
		}

		[Test]
		public void Get_should_remove_data_from_cache()
		{
			string hash = _hashCodeService.New(new TestDto("text"));

			_hashCodeService.Get(hash);

			TestDto data = _hashCodeService.Get(hash);

			Assert.IsNull(data);
		}

		[Test]
		public void New_not_return_data_by_hash_if_record_expired()
		{
			_hashCodeService.SetTimeOut(-1);

			string hash = _hashCodeService.New(new TestDto("text"));

			TestDto data = _hashCodeService.Get(hash);

			Assert.IsNull(data);
		}

		[Test]
		public void Test_parallel()
		{
			Parallel.For(1, 3000, (i, state) =>
			{
				var text = i.ToString();

				string hash = _hashCodeService.New(new TestDto(text));

				TestDto data = _hashCodeService.Get(hash);

				Assert.AreEqual(text, data.TestField);
			});
		}
	}
}
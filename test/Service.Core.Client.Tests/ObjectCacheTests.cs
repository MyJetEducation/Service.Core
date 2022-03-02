using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Service.Core.Client.Services;

namespace Service.Core.Client.Tests
{
	public class ObjectCacheTests
	{
		private Mock<ISystemClock> _systemClock;

		private ObjectCache<Guid> _sut;

		private readonly DateTime _nowTime = new(2022, 10, 12);

		[SetUp]
		public void Setup()
		{
			_systemClock = new Mock<ISystemClock>();

			_systemClock
				.Setup(clock => clock.Now)
				.Returns(_nowTime);

			_sut = new ObjectCache<Guid>(_systemClock.Object);
		}

		[Test]
		public void Exists_return_true_for_added_item()
		{
			var data = new Guid("8a9b18d5-0d84-45b7-a0fb-9c0e38c0c092");

			_sut.Add(data, _nowTime.AddDays(1));

			bool result = _sut.Exists(data);

			Assert.IsTrue(result);
		}

		[Test]
		public void Exists_return_false_for_not_added_item()
		{
			var data = new Guid("42ad9139-a03f-4983-bc5b-0e4ea866150d");

			bool result = _sut.Exists(data);

			Assert.IsFalse(result);
		}

		[Test]
		public void Exists_return_false_for_expired_item()
		{
			var data = new Guid("4a063f47-198a-4683-9a67-1c361c7fc75d");

			_sut.Add(data, _nowTime.AddDays(-1));

			bool result = _sut.Exists(data);

			Assert.IsFalse(result);
		}

		[Test]
		public void Exists_return_false_if_item_expired()
		{
			var data = new Guid("b406e4d6-726d-4207-86b4-809fdca9fe27");

			_sut.Add(data, _nowTime.AddSeconds(1));

			bool result1 = _sut.Exists(data);

			Assert.IsTrue(result1);

			_systemClock
				.Setup(clock => clock.Now)
				.Returns(_nowTime.AddSeconds(2));

			bool result2 = _sut.Exists(data);

			Assert.IsFalse(result2);
		}

		[Test]
		public void Add_update_expire_date_to_current_item()
		{
			var data = new Guid("5667c949-b951-4b5a-8303-bf93e6ee26b1");

			_sut.Add(data, _nowTime.AddSeconds(1));

			_sut.Add(data, _nowTime.AddDays(1));

			_systemClock
				.Setup(clock => clock.Now)
				.Returns(_nowTime.AddSeconds(2));

			bool result = _sut.Exists(data);

			Assert.IsTrue(result);
		}

		[Test]
		public void Test_parallel()
		{
			Parallel.For(1, 3000, _ =>
			{
				var data = Guid.NewGuid();

				_sut.Add(data, _nowTime.AddMinutes(1));

				bool result = _sut.Exists(data);

				Assert.IsTrue(result);
			});
		}
	}
}
using System;

namespace Service.Core.Services
{
	public interface ISystemClock
	{
		public DateTime Now { get; }

		public DateTime Today { get; }
	}
}
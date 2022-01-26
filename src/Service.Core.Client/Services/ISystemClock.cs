using System;

namespace Service.Core.Client.Services
{
	public interface ISystemClock
	{
		public DateTime Now { get; }

		public DateTime Today { get; }
	}
}
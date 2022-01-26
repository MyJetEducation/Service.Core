using System;

namespace Service.Core.Services
{
	public class SystemClock : ISystemClock
	{
		public DateTime Now => DateTime.UtcNow;

		public DateTime Today => DateTime.UtcNow.Date;
	}
}
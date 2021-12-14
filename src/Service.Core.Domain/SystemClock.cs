using System;
using Service.Core.Domain.Models;

namespace Service.Core.Domain
{
	public class SystemClock : ISystemClock
	{
		public DateTime Now => DateTime.UtcNow;

		public DateTime Today => DateTime.UtcNow.Date;
	}
}
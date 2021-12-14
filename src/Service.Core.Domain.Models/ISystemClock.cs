using System;

namespace Service.Core.Domain.Models
{
	public interface ISystemClock
	{
		public DateTime Now { get; }

		public DateTime Today { get; }
	}
}
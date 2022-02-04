using System;

namespace Service.Core.Client.Services
{
	public interface IHashCodeService<TData>
	{
		TData Get(string hashCode);

		string New(TData data);

		bool Contains(Func<TData, bool> predicate);

		void SetTimeOut(int timeoutMinutes);
	}
}
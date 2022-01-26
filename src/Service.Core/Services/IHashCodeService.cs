﻿namespace Service.Core.Services
{
	public interface IHashCodeService<TData>
	{
		TData Get(string hashCode);

		string New(TData data);

		void SetTimeOut(int timeoutMinutes);
	}
}
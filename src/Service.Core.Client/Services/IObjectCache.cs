using System;

namespace Service.Core.Client.Services
{
	public interface IObjectCache<in T>
	{
		bool Exists(T data);

		void Add(T data, DateTime expire);

		void Remove(T data);
	}
}
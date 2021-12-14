using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Service.Core.Domain.Models;

namespace Service.Core.Domain
{
	public class HashCodeService<TData> : IHashCodeService<TData> where TData : class
	{
		private const int HashLiveTimeMinutesDefault = 30;

		// ReSharper disable once StaticMemberInGenericType
		private static int _hashLiveTime;

		private static readonly ConcurrentDictionary<string, (DateTime created, TData data)> Dictionary;

		static HashCodeService()
		{
			Dictionary = new ConcurrentDictionary<string, (DateTime created, TData data)>();
			_hashLiveTime = HashLiveTimeMinutesDefault;
		}

		public void SetTimeOut(int timeoutMinutes) => _hashLiveTime = timeoutMinutes;

		public TData Get(string hashCode)
		{
			CheckHash();

			if (string.IsNullOrWhiteSpace(hashCode))
				return null;

			return Dictionary.TryGetValue(hashCode, out (DateTime created, TData data) info)
				? info.data
				: null;
		}

		public string New(TData data)
		{
			CheckHash();

			string hashCode = HashGenerator.New;

			Dictionary.TryAdd(hashCode, (DateTime.UtcNow, data));

			return hashCode;
		}

		private static void CheckHash()
		{
			KeyValuePair<string, (DateTime created, TData data)>[] pairs = Dictionary
				.Where(pair => pair.Value.created.AddMinutes(_hashLiveTime) > DateTime.UtcNow)
				.ToArray();

			foreach (KeyValuePair<string, (DateTime created, TData data)> pair in pairs)
				Dictionary.TryRemove(pair);
		}
	}
}
﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Service.Core.Client.Services
{
	public class ObjectCache<T> : IObjectCache<T>
	{
		private readonly ISystemClock _systemClock;

		private static readonly ConcurrentDictionary<T, DateTime> Dictionary;

		static ObjectCache() => Dictionary = new ConcurrentDictionary<T, DateTime>();

		public ObjectCache(ISystemClock systemClock) => _systemClock = systemClock;

		public bool Exists(T data)
		{
			Clean();

			return Dictionary.ContainsKey(data);
		}

		public void Add(T data, DateTime expire)
		{
			Clean();

			Dictionary.AddOrUpdate(data, _ => expire, (_, _) => expire);
		}

		public void Remove(T data)
		{
			Clean();

			Dictionary.TryRemove(data, out DateTime _);
		}

		private void Clean()
		{
			KeyValuePair<T, DateTime>[] expiredPairs = Dictionary
				.Where(pair => pair.Value < _systemClock.Now)
				.ToArray();

			foreach (KeyValuePair<T, DateTime> pair in expiredPairs)
				Dictionary.TryRemove(pair);
		}
	}
}
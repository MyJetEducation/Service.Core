using System;
using System.Text.RegularExpressions;

namespace Service.Core.Domain
{
	public static class HashGenerator
	{
		public static string New => Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
	}
}
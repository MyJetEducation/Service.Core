using JetBrains.Annotations;

namespace Service.Core.Extensions
{
	public static class StringExtensions
	{
		[ContractAnnotation("null=>true")]
		public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

		[ContractAnnotation("null=>true")]
		public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

		public static string Mask(this string email)
		{
			if (email.Length <= 8)
				return email.Length <= 5
					? "*****"
					: $"{email[0]}**{email[^1]}";

			return $"{email[..3]}**{email.Substring(email.Length - 4, 3)}";
		}
	}
}
using NUnit.Framework;
using Service.Core.Client.Extensions;

namespace Service.Core.Client.Tests.Extensions
{
	public class HexConverterUtilsTests
	{
		private static object[] _testData =
		{
			new object[] {new byte[] {0x1, 0x2, 0x4}, "010204"},
			new object[] {new byte[] {0x3, 0x2, 0x5b}, "03025B"},
			new object[] {new byte[] {0x1, 0x4, 0x6a}, "01046A"}
		};

		[TestCaseSource(nameof(_testData))]
		public void ToHexString_return_string_from_byte(byte[] bytes, string str)
		{
			string resultStr = bytes.ToHexString();

			Assert.AreEqual(str, resultStr);
		}

		[TestCaseSource(nameof(_testData))]
		public void HexStringToByteArray_return_bytes_from_string(byte[] bytes, string str)
		{
			byte[] resultBytes = str.HexStringToByteArray();

			Assert.AreEqual(bytes, resultBytes);
		}
	}
}
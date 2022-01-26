using NUnit.Framework;
using Service.Core.Client.Services;

namespace Service.Core.Client.Tests
{
	public class EncoderDecoderTests
	{
		private EncoderDecoder _encoderDecoder;

		[SetUp]
		public void Setup()
		{
			_encoderDecoder = new EncoderDecoder("key");
		}

		[Test]
		public void Encode_return_coded_string()
		{
			string codedValue = _encoderDecoder.Encode("value");

			Assert.IsNotNull(codedValue);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public void Encode_return_null_for_null_or_whitespace_value(string value)
		{
			string codedValue = _encoderDecoder.Encode(value);

			Assert.IsNull(codedValue);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public void Decode_return_null_for_null_or_whitespace_value(string value)
		{
			string decodedValue = _encoderDecoder.Decode(value);

			Assert.IsNull(decodedValue);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public void Hash_return_null_for_null_or_whitespace_value(string value)
		{
			string hash = _encoderDecoder.Hash(value);

			Assert.IsNull(hash);
		}

		[Test]
		public void Hash_return_value()
		{
			string hash = _encoderDecoder.Hash("value");

			Assert.AreEqual("tL/nwx+0t80kXnSrif22byKG3GgxtX8RIjngthMdMhw=", hash);
		}

		[Test]
		public void Decode_return_source_string()
		{
			string codedValue = _encoderDecoder.Encode("value");

			string value = _encoderDecoder.Decode(codedValue);

			Assert.AreEqual("value", value);
		}
	}
}
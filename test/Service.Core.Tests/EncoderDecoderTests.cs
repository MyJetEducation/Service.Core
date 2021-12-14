using NUnit.Framework;
using Service.Core.Domain;

namespace Service.Core.Tests
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

		[Test]
		public void Decode_return_source_string()
		{
			string codedValue = _encoderDecoder.Encode("value");

			string value = _encoderDecoder.Decode(codedValue);

			Assert.AreEqual("value", value);
		}
	}
}
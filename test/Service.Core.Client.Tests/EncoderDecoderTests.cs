using System;
using System.Runtime.Serialization;
using NUnit.Framework;
using Service.Core.Client.Services;

namespace Service.Core.Client.Tests
{
	public class EncoderDecoderTests
	{
		private EncoderDecoder _encoderDecoder;

		private readonly GrpcTestModel _testGrpcModel = new()
		{
			Id = new Guid("d7dd9e61-f82a-4b00-b769-3a8d88a98673"),
			Date = new DateTime(2021, 01, 02),
			Number = 10,
			Value = "value"
		};

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
		public void EncodeBase64_return_coded_string()
		{
			string codedValue = _encoderDecoder.EncodeBase64("value");

			Assert.IsNotNull(codedValue);
		}

		[Test]
		public void EncodeBytes_return_coded_string()
		{
			string codedValue = _encoderDecoder.EncodeBytes(new byte[] {0x1b, 0x2b});

			Assert.IsNotNull(codedValue);
		}

		[Test]
		public void EncodeBytesBase64_return_coded_string()
		{
			string codedValue = _encoderDecoder.EncodeBytesBase64(new byte[] {0x1b, 0x2b});

			Assert.IsNotNull(codedValue);
		}

		[Test]
		public void EncodeProto_return_coded_string()
		{
			string codedValue = _encoderDecoder.EncodeProto(_testGrpcModel);

			Assert.IsNotNull(codedValue);
		}

		[Test]
		public void EncodeProtoBase64_return_coded_string()
		{
			string codedValue = _encoderDecoder.EncodeProtoBase64(_testGrpcModel);

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
		public void EncodeBase64_return_null_for_null_or_whitespace_value(string value)
		{
			string codedValue = _encoderDecoder.EncodeBase64(value);

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
		public void DecodeBase64_return_null_for_null_or_whitespace_value(string value)
		{
			string decodedValue = _encoderDecoder.DecodeBase64(value);

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
			string value = _encoderDecoder.Decode("F4403E9CBF3A2B08FE1759D299ECB67814F2967228A0D0E00D1B75BB06E5A115");

			Assert.AreEqual("value", value);
		}

		[Test]
		public void DecodeBase64_return_source_string()
		{
			string value = _encoderDecoder.DecodeBase64("pLO2ubD29QRyW4RGgTFAVlPl4mU9T5l8TTwZzEZc/W8=");

			Assert.AreEqual("value", value);
		}

		[Test]
		public void DecodeBytes_return_source_string()
		{
			byte[] value = _encoderDecoder.DecodeBytes("970138D8CCB2F311ABB0A3A6F7E753A255923B09EACE4AE61835B7412CBC8960");

			Assert.AreEqual(new byte[] {0x1b, 0x2b}, value);
		}

		[Test]
		public void DecodeBytesBase64_return_source_string()
		{
			byte[] value = _encoderDecoder.DecodeBytesBase64("pHE0O/xegIk67eMrCLxZjpdx0ru6r9vZmAsHSB0ToIs=");

			Assert.AreEqual(new byte[] {0x1b, 0x2b}, value);
		}

		[Test]
		public void DecodeProto_return_source_string()
		{
			var value = _encoderDecoder.DecodeProto<GrpcTestModel>("359E22F5816E8906FBC74582FECFDF468DA5A698696E7AE7F46B52FC4CBA297072F24B8B02C574ECBE1E296503DA0A74016F60A8A2E32E0C171B9E71F60B3FDA");

			Assert.IsNotNull(value);
			Assert.AreNotSame(_testGrpcModel, value);
		}

		[Test]
		public void DecodeProtoBase64_return_source_string()
		{
			var value = _encoderDecoder.DecodeProtoBase64<GrpcTestModel>("zm86epShm7HAhCDhkR52M3vLZN6JU+U1o0vyN/yl2ZQKrEdW0fY7Cc+9Cm2lR161aC1ssUUw+RDl37naIkeBEg==");

			Assert.IsNotNull(value);
			Assert.AreNotSame(_testGrpcModel, value);
		}

		[DataContract]
		public class GrpcTestModel
		{
			[DataMember(Order = 1)]
			public Guid Id { get; set; }

			[DataMember(Order = 2)]
			public DateTime Date { get; set; }

			[DataMember(Order = 3)]
			public int Number { get; set; }

			[DataMember(Order = 4)]
			public string Value { get; set; }
		}
	}
}
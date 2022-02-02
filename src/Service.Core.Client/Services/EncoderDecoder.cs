using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ProtoBuf;
using Service.Core.Client.Extensions;
using SimpleTrading.Common.Helpers;
using HexConverterUtils = Service.Core.Client.Extensions.HexConverterUtils;

namespace Service.Core.Client.Services
{
	public class EncoderDecoder : IEncoderDecoder
	{
		private readonly byte[] _encodingKeyBytes;
		private readonly string _encodingKey;

		public EncoderDecoder(string encodingKey)
		{
			_encodingKey = encodingKey;
			_encodingKeyBytes = Encoding.UTF8.GetBytes(encodingKey);
		}

		public string EncodeProto(object obj)
		{
			try
			{
				using var stream = new MemoryStream();

				stream.WriteByte(0); // First byte is a version contract;

				Serializer.Serialize(stream, obj);

				byte[] bytes = stream.ToArray();

				return EncodeBytes(bytes);
			}
			catch (Exception ex)
			{
				throw new Exception($"Cannot serialize {obj.GetType().Name}: {ex.Message}", ex);
			}
		}

		public string Encode(string str)
		{
			if (str.IsNullOrWhiteSpace())
				return null;

			byte[] data = Encoding.UTF8.GetBytes(str);

			return EncodeBytes(data);
		}

		public string EncodeBytes(byte[] data)
		{
			if (data.IsNullOrEmpty())
				return null;

			byte[] result = AesEncodeDecode.Encode(data, _encodingKeyBytes);

			return HexConverterUtils.ToHexString(result);
		}

		public string Decode(string str)
		{
			if (str.IsNullOrWhiteSpace())
				return null;

			byte[] bytes = DecodeBytes(str);

			return Encoding.UTF8.GetString(bytes);
		}

		public byte[] DecodeBytes(string str)
		{
			if (str.IsNullOrWhiteSpace())
				return null;

			byte[] data = HexConverterUtils.HexStringToByteArray(str);

			byte[] decode = AesEncodeDecode.Decode(data, _encodingKeyBytes);

			return decode;
		}

		public T DecodeProto<T>(string str) where T : class
		{
			byte[] data = DecodeBytes(str);
			if (data.IsNullOrEmpty())
				return null;

			if (data[0] != 0) 
				throw new Exception("Not supported version of Contract");

			try
			{
				byte[] body = data.Skip(1).ToArray();
				var mem = new MemoryStream(data.Length);
				mem.Write(body);
				mem.Position = 0;
				return Serializer.Deserialize<T>(mem);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Cannot deserialize message {typeof (T).Name}. Data: '{str}'");

				throw new Exception($"Cannot deserialize message {typeof (T).Name}: {ex.Message}", ex);
			}
		}

		public string Hash(string str)
		{
			if (str.IsNullOrWhiteSpace())
				return null;

			using var sha256 = SHA256.Create();

			var saltedPassword = $"{_encodingKey}{str}";

			byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);

			byte[] computeHash = sha256.ComputeHash(saltedPasswordAsBytes);

			return Convert.ToBase64String(computeHash);
		}
	}
}
﻿using System;
using System.Security.Cryptography;
using System.Text;
using Service.Core.Client.Extensions;
using SimpleTrading.Common.Helpers;
using HexConverterUtils = MyJetWallet.Sdk.Service.HexConverterUtils;

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

		public string Encode(string str)
		{
			if (str.IsNullOrWhiteSpace())
				return null;

			byte[] data = Encoding.UTF8.GetBytes(str);

			byte[] result = AesEncodeDecode.Encode(data, _encodingKeyBytes);

			return HexConverterUtils.ToHexString(result);
		}

		public string Decode(string str)
		{
			if (str.IsNullOrWhiteSpace())
				return null;

			byte[] data = HexConverterUtils.HexStringToByteArray(str);

			byte[] decode = AesEncodeDecode.Decode(data, _encodingKeyBytes);

			return Encoding.UTF8.GetString(decode);
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
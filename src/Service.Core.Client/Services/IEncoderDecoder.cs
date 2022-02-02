namespace Service.Core.Client.Services
{
	public interface IEncoderDecoder
	{
		string Encode(string str);
		string EncodeBytes(byte[] data);
		string EncodeProto(object obj);

		string Decode(string str);
		byte[] DecodeBytes(string str);
		T DecodeProto<T>(string str) where T : class;

		string Hash(string str);
	}
}
namespace Service.Core.Domain.Models
{
	public interface IEncoderDecoder
	{
		string Encode(string str);

		string Decode(string str);

		string Hash(string str);
	}
}
using System.Runtime.Serialization;

namespace Service.Core.Client.Models
{
	[DataContract]
	public class CommonGrpcResponse
	{
		[DataMember(Order = 1)]
		public bool IsSuccess { get; set; }

		public static CommonGrpcResponse Success => new CommonGrpcResponse {IsSuccess = true};
		public static CommonGrpcResponse Fail => new CommonGrpcResponse();
		public static CommonGrpcResponse Result(bool result) => new CommonGrpcResponse {IsSuccess = result};
	}
}
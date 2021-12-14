using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;

namespace Service.Core.Client
{
	[UsedImplicitly]
	public class CoreClientFactory : MyGrpcClientFactory
	{
		public CoreClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
		{
		}
	}
}
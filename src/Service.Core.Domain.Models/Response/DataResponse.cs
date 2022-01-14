using Microsoft.AspNetCore.Mvc;
using Service.Core.Domain.Models.Constants;

namespace Service.Core.Domain.Models.Response
{
	public class DataResponse<T> : StatusResponse
	{
		public T Data { get; set; }

		public static IActionResult Ok(T data) => new OkObjectResult(
			new DataResponse<T>
			{
				Data = data,
				Status = data == null ? ResponseCode.Fail : ResponseCode.Ok
			});
	}
}
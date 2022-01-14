using Microsoft.AspNetCore.Mvc;
using Service.Core.Domain.Models.Constants;

namespace Service.Core.Domain.Models.Response
{
	public class StatusResponse
	{
		public int Status { get; set; }

		public static IActionResult Error(int code = ResponseCode.Fail) => new OkObjectResult(
			new StatusResponse
			{
				Status = code
			});

		public static IActionResult Ok() => new OkObjectResult(
			new StatusResponse
			{
				Status = ResponseCode.Ok
			});

		public static IActionResult Result(bool isSuccess) => new OkObjectResult(
			new StatusResponse
			{
				Status = isSuccess ? ResponseCode.Ok : ResponseCode.Fail
			});
	}
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MudBlazorPage.Server.Repository.Interface;
using MudBlazorPage.Shared.Entities.RequestFeatures;
using Newtonsoft.Json;

namespace MudBlazorPage.Server.Controllers
{
	[Route("api/usertables")]
	[ApiController]
	public class UserTableController : ControllerBase
	{
		private readonly IUserTableRepository _repo;

		public UserTableController(IUserTableRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] Parameters parameters)
		{
			var usertables = await _repo.GetUserTables(parameters);

			Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(usertables.MetaData));

			return Ok(usertables);
		}
	}
}

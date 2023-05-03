using MudBlazorPage.Client.Features;
using MudBlazorPage.Shared.Entities.Models;
using MudBlazorPage.Shared.Entities.RequestFeatures;

namespace MudBlazorPage.Client.HttpService.Interface
{
	public interface IHttpClientService
	{
		Task<PagingResponse<UserTable>> GetUserTables(Parameters parameters);
	}
}

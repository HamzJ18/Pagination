using MudBlazorPage.Server.Data;
using MudBlazorPage.Shared.Entities.Models;
using MudBlazorPage.Shared.Entities.RequestFeatures;
using MudBlazorPage.Server.Paging;

namespace MudBlazorPage.Server.Repository.Interface
{
	public interface IUserTableRepository
	{
		Task<PagedList<UserTable>> GetUserTables(Parameters parameters);
	}
}

using MudBlazorPage.Server.Data;
using MudBlazorPage.Server.Paging;
using MudBlazorPage.Server.Repository.Interface;
using MudBlazorPage.Shared.Entities.Models;
using MudBlazorPage.Shared.Entities.RequestFeatures;
using MudBlazorPage.Server.Repository.RepositoryExtensions;
using Microsoft.EntityFrameworkCore;

namespace MudBlazorPage.Server.Repository
{
	public class UserTableRepository : IUserTableRepository
	{
		private readonly RecordContext _context;

		public UserTableRepository(RecordContext context)
		{
			_context = context;
		}

		public async Task<PagedList<UserTable>> GetUserTables(Parameters parameters)
		{
			var products = await _context.UserTables
				.Search(parameters.SearchTerm)
				.Sort(parameters.OrderBy)
				.ToListAsync();

			return PagedList<UserTable>
				.ToPagedList(products, parameters.PageNumber, parameters.PageSize);
		}
	}
}

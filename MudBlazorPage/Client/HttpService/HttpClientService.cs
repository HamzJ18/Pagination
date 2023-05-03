using Microsoft.AspNetCore.WebUtilities;
using MudBlazorPage.Client.Features;
using MudBlazorPage.Client.HttpService.Interface;
using MudBlazorPage.Shared.Entities.Models;
using MudBlazorPage.Shared.Entities.RequestFeatures;
using System.Text.Json;

namespace MudBlazorPage.Client.HttpService
{
	public class HttpClientService : IHttpClientService
	{
		private readonly HttpClient _client;
		private readonly JsonSerializerOptions _options;

		public HttpClientService(HttpClient client)
		{
			_client = client;
			_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
		}

		public async Task<PagingResponse<UserTable>> GetUserTables(Parameters parameters)
		{
			var queryStringParam = new Dictionary<string, string>
			{
				["pageNumber"] = parameters.PageNumber.ToString(),
				["pageSize"] = parameters.PageSize.ToString(),
				["searchTerm"] = parameters.SearchTerm ?? "",
				["orderBy"] = parameters.OrderBy ?? "name"
			};

			using (var response = await _client.GetAsync(QueryHelpers
				.AddQueryString("usertables", queryStringParam)))
			{
				response.EnsureSuccessStatusCode();

				var metaData = JsonSerializer
					.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options);

				var stream = await response.Content.ReadAsStreamAsync();

				var pagingResponse = new PagingResponse<UserTable>
				{
					Items = await JsonSerializer.DeserializeAsync<List<UserTable>>(stream, _options),
					MetaData = metaData
				};

				return pagingResponse;
			}
		}
	}
}

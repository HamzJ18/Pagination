using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudBlazorPage.Client;
using MudBlazorPage.Client.HttpService;
using MudBlazorPage.Client.HttpService.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorPage
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddScoped(sp => new HttpClient
			{
				BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
			});

			//builder.Services.AddScoped(sp => new HttpClient
			//{
			//	BaseAddress = new Uri("https://localhost:5001/api/")
			//});
			builder.Services.AddMudServices();
			builder.Services.AddScoped<IHttpClientService, HttpClientService>();

			await builder.Build().RunAsync();
		}
	}
}


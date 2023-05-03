using MudBlazorPage.Shared.Entities.Models;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorPage.Server.Repository.RepositoryExtensions
{
	public static class RepositoryUserTableExtensions
	{
		public static IQueryable<UserTable> Search(this IQueryable<UserTable> usertables, string searchTearm)
		{
			if (string.IsNullOrWhiteSpace(searchTearm))
				return usertables;

			var lowerCaseSearchTerm = searchTearm.Trim().ToLower();

			return usertables.Where(p => p.UserId.ToLower().Contains(lowerCaseSearchTerm));
		}
		public static IQueryable<UserTable> Sort(this IQueryable<UserTable> usertables, string orderByQueryString)
		{
			if (string.IsNullOrWhiteSpace(orderByQueryString))
				return usertables.OrderBy(e => e.UserId);

			var orderParams = orderByQueryString.Trim().Split(',');
			var propertyInfos = typeof(UserTable).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var orderQueryBuilder = new StringBuilder();

			foreach (var param in orderParams)
			{
				if (string.IsNullOrWhiteSpace(param))
					continue;

				var propertyFromQueryName = param.Split(" ")[0];
				var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

				if (objectProperty == null)
					continue;

				var direction = param.EndsWith(" desc") ? "descending" : "ascending";
				orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
			}

			var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
			if (string.IsNullOrWhiteSpace(orderQuery))
				return usertables.OrderBy(e => e.UserId);

			return usertables.OrderBy(orderQuery);
		}
	}
}

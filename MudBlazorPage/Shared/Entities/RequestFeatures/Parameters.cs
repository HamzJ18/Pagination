using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorPage.Shared.Entities.RequestFeatures
{
	public class Parameters
	{
		const int maxPageSize = 50;
		public int PageNumber { get; set; } = 1;
		private int _pageSize = 4;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}

		public string SearchTerm { get; set; }
		public string OrderBy { get; set; } = "name";
	}
}

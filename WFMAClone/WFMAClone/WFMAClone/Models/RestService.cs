using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WFMAClone
{
	class RestService
	{
		HttpClient client;
		public RestService()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}
		public async Task<TaskList> RefreshDataAsync()
		{
			var uri = new Uri("http://w4api.azurewebsites.net/api/TaskList");
			var response = await client.GetAsync(uri);
			var Items = new TaskList();
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				Items = JsonConvert.DeserializeObject<TaskList>(content);
			}
			return Items;
		}
	}
	
}

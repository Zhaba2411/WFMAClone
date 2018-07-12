using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		public async Task<MyTaskList> getTaskListAsync()
		{
            var uri = new Uri("http://w4api.azurewebsites.net/api/TaskList");
			var response = await client.GetAsync(uri);
			var Items = new MyTaskList();
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				Items = JsonConvert.DeserializeObject<MyTaskList>(content);
			}
			return Items;
		}

        public async Task<MyTaskDetails> getTaskByIdAsync(int id)
        {
            string uri = string.Format("http://w4api.azurewebsites.net/api/Task/{0}", id);

            var response = await client.GetAsync(uri);
            var Items = new MyTaskDetails();

            // json settings = ignore null fields:
            var jsonSettings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            };

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<MyTaskDetails>(content, jsonSettings);
            }
            return Items;
        }

        public async void AcceptTask(int id){
            Console.WriteLine("AcceptTask called, but lacks permission. Id is: " + id);
			string uri = string.Format("http://w4api.azurewebsites.net/api/Task/Accept/{0}", id);

            var response = await client.GetAsync(uri);
            if(response.IsSuccessStatusCode){
                Debug.WriteLine("Succesfully written");
            }
        }

        public async void FinalizeTask(int id)
        {
            Console.WriteLine("FinalizeTask called, but lacks permission. Id is: " + id);
            string uri = string.Format("http://w4api.azurewebsites.net/api/Task/Finalize/{0}", id);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Succesfully written");
            }
        }

    }
	
}

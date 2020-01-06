using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rest.HTTP.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace Rest.HTTP.Controllers
{
    public class AppStatusController
    {
        static HttpClient client = new HttpClient();
        public async Task<JObject> GetStatusAsync(string vhostName)
        {
            /*curl -i -u guest:guest -X GET \
             * "http://localhost:15672/api/vhosts/ss2"
             * To do: read amqp broker address from config file*/

            JObject jsonObj = null;

            string uri = "http://localhost:15672/api/vhosts/" + vhostName;

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsAsync<ConnectionList>();
                jsonObj = JObject.Parse(responseMessage.cluster_state.rabbitPDD1); 
            }

            return jsonObj;            
        }
    }
}

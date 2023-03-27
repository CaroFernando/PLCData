using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using PLCData.PLCConnectionObj.APIHelperObj;
using System.Text.Json;

namespace PLCData.PLCConnectionObj
{
    public class APICallDataCallback :  DataCallback
    {

        private string url = "https://localhost:44300/OverbakeLogs/InsertOverbakeLog";
        private static readonly HttpClient client = new HttpClient();

        public override void dataRetrieved(DataStatus dataStatus)
        {
            APILog log = new APILog();
            log.Time = dataStatus.status.log.Time.ToString("yyyy-MM-dd HH:mm:ss");
            log.PlcId = dataStatus.deviceID;
            log.SerialNumber = dataStatus.data.serialNumber.ToString();
            log.Status = dataStatus.data.status.ToString();
            log.Message = dataStatus.status.log.Message;
            

            // serialize and sent to api
            string json = JsonSerializer.Serialize(log);

            Console.WriteLine(json);

            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(url, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

using PLCData.PLCConnectionObj.APIHelperObj;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace PLCData.PLCConnectionObj
{
    public class APIConnectionCallback : ConnectionCallback
    {
        private string updateurl = "https://localhost:44300/Plc/UpdatePlc";
        private string inserturl = "https://localhost:44300/PlcLogs/InsertPlcLog";
        private static readonly HttpClient client = new HttpClient();

        public object JsonConvert { get; private set; }

        public override void OnConnectionFailed(Log log)
        {

            APIPLCConnectionLog plcConnectionLog = new APIPLCConnectionLog();
            plcConnectionLog.PlcId = log.deviceID;
            plcConnectionLog.Message = "Connection failed";
            plcConnectionLog.Time = log.Time.ToString("yyyy-MM-dd HH:mm:ss");
            plcConnectionLog.Enabled = 0;

            APIPLCStatusUpdate statusUpdate = new APIPLCStatusUpdate();
            statusUpdate.Enabled = 0;
            statusUpdate.LastConection = log.Time.ToString("yyyy-MM-dd HH:mm:ss");
            statusUpdate.Id = log.deviceID;


            // serialize to json and sent to api

            try
            {
                string json = JsonSerializer.Serialize(plcConnectionLog);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(inserturl, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseString);
            }
            catch (Exception e)
            {
                Console.WriteLine("API connection call 1 failed: " + e.Message);
            }

            try
            {
                string json = JsonSerializer.Serialize(statusUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(updateurl, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseString);
            }
            catch (Exception e)
            {
                Console.WriteLine("API connection call 2 failed: " + e.Message);
            }

        }

        public override void OnConnectionStatusChanged(bool status)
        {
            throw new NotImplementedException();
        }

        public override void OnConnectionSuccess(Log log)
        {

            APIPLCConnectionLog plcConnectionLog = new APIPLCConnectionLog();
            plcConnectionLog.PlcId = log.deviceID;
            plcConnectionLog.Message = "Connection succes";
            plcConnectionLog.Time = log.Time.ToString("yyyy-MM-dd HH:mm:ss");
            plcConnectionLog.Enabled = 1;

            APIPLCStatusUpdate statusUpdate = new APIPLCStatusUpdate();
            statusUpdate.Enabled = 1;
            statusUpdate.LastConection = log.Time.ToString("yyyy-MM-dd HH:mm:ss");
            statusUpdate.Id = log.deviceID;


            // serialize to json and sent to api

            try
            {
                string json = JsonSerializer.Serialize(plcConnectionLog);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(inserturl, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                string json = JsonSerializer.Serialize(statusUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(updateurl, content).Result;
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

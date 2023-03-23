using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj
{
    public class TestConnectionCallback : ConnectionCallback
    {
        public override void OnConnectionSuccess(Log log)
        {
            Console.WriteLine("Connection success " + log.deviceID.ToString() + ": " + log.Message);
        }

        public override void OnConnectionFailed(Log log)
        {
            Console.WriteLine("Connection failed " + log.deviceID.ToString() + ": " + log.Message);
        }

        public override void OnConnectionStatusChanged(bool status)
        {
            Console.WriteLine("Connection status changed");
        }
    }
}

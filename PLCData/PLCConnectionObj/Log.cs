using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj
{
    public class Log
    {
        public int deviceID;
        public string Message;
        public DateTime Time;

        public Log(int deviceID, string Message)
        {
            this.deviceID = deviceID;
            this.Message = Message;
            this.Time = DateTime.Now;
        }

        public override string ToString()
        {
            return Time.ToString() + " - " + Message;
        }
    }
}

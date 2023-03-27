using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj.APIHelperObj
{
    public class APILog
    {
        public string Time { get; set; }
        public int PlcId { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj
{
    public class DataStatus
    {

        // atribute data is dynamic, so it can be any type of data
        public dynamic data;
        public Status status;
        public int deviceID;

        public DataStatus(int id, dynamic data, Status status)
        {
            this.deviceID = id;
            this.data = data;
            this.status = status;
        }
    }
}

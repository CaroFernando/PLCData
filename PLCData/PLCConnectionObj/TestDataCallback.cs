using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PLCData.PLCConnectionObj
{
    public class TestDataCallback: DataCallback
    {

        public override void dataRetrieved(DataStatus dataStatus)
        {
            Console.WriteLine("Data retrieved from " + dataStatus.deviceID + ": " + dataStatus.data);
        }
    }
}

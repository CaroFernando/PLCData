using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj
{
    public abstract class DataCallback
    {
        public abstract void dataRetrieved(DataStatus dataStatus);
    }
}

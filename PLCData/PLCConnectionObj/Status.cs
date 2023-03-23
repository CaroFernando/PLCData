using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj
{
    public class Status
    {
        public bool ok;
        public Log log;

        public Status(bool ok, Log log)
        {
            this.ok = ok;
            this.log = log;
        }

        
    }
}

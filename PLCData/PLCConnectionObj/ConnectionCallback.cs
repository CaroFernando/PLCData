using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj
{
    public abstract class ConnectionCallback
    {
        public abstract void OnConnectionSuccess(Log log);
        public abstract void OnConnectionFailed(Log log);
        public abstract void OnConnectionStatusChanged(bool status);
    }
}

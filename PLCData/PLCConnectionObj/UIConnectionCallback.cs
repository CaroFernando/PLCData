using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj
{
    public class UIConnectionCallback : ConnectionCallback
    {
        private UIPLCStatus call;
        public UIConnectionCallback(UIPLCStatus sender)
        {
            this.call = sender;
        }
        public override void OnConnectionFailed(Log log)
        {
            this.call.ChangeStatus(false);
        }

        public override void OnConnectionStatusChanged(bool status)
        {
            throw new NotImplementedException();
        }

        public override void OnConnectionSuccess(Log log)
        {
            this.call.ChangeStatus(true);
        }
    }
}

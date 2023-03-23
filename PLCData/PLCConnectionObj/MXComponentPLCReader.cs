using ActUtlTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj
{
    public class MXComponentPLCReader : PLCReader
    {
        private ActUtlType PLC = new ActUtlType();
        private int deviceID;
        private string readAddress = "";
        private string okAddress = "";

        public MXComponentPLCReader(int deviceID, string readAdress, string okAddress) : base(deviceID)
        {
            this.deviceID = deviceID;
            this.readAddress = readAdress;
            this.okAddress = okAddress;
        }

        public override DataStatus readOk()
        {
            int value = 0;
            PLC.ReadDeviceBlock(this.okAddress, 1, out value);
            return new DataStatus(this.PLCId, value != 0, new Status(true, new Log(this.PLCId, "ok")));
        }

        public override DataStatus readData()
        {
            int value = 0;
            PLC.ReadDeviceBlock(this.readAddress, 1, out value);
            return new DataStatus(this.PLCId, value, new Status(true, new Log(this.PLCId, "ok")));
        }
    }
}

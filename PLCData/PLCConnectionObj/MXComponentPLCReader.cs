using ActUtlTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
        private string PLCName = "";

        public MXComponentPLCReader(int deviceID, string readAdress, string okAddress) : base(deviceID)
        {
            this.deviceID = deviceID;
            this.readAddress = readAdress;
            this.okAddress = okAddress;

            PLC.ActLogicalStationNumber = Convert.ToInt16(deviceID);
            PLC.Open();
            
            int code = 0;

            PLC.GetCpuType(out this.PLCName, out code);
            this.PLCName += " " + code;
        }

        public override DataStatus readOk()
        {
            try
            {
                int value = 0;
                PLC.GetDevice(this.okAddress, out value);

                // print value
                Console.WriteLine("Read ok from " + this.PLCName + ": " + value);

                if (value == 1)
                {
                    PLC.SetDevice(this.okAddress, 0);
                }
                
                return new DataStatus(this.PLCId, value != 0, new Status(true, new Log(this.PLCId, "ok")));

            }
            catch(Exception e)
            {
                return new DataStatus(
                    this.PLCId, 
                    false, 
                    new Status(
                        false, 
                        new Log(this.PLCId, e.Message)
                    )
                );
            }
            
        }

        public override DataStatus readData()
        {
            try
            {
                
                int value = 0;
                PLC.ReadDeviceBlock(this.readAddress, 1, out value);

                // print value
                Console.WriteLine("Read data from " + this.PLCName + ": " + value);
                
                return new DataStatus(
                    this.PLCId, 
                    value, 
                    new Status(
                    true, new Log(this.PLCId, "ok")));

            }
            catch (Exception e)
            {
                return new DataStatus(
                    this.PLCId,
                    false,
                    new Status(
                        false,
                        new Log(this.PLCId, e.Message)
                    )
                );
            }
        }
    }
}

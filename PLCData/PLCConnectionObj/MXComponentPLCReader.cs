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

        private string serialNumberAdress = "";
        private int serialNumberStartAdress = 0;
        private int serialNumberLength = 0;

        private string PLCName = "";

        private const int STATUS_OK_BIT = 0;
        private const int STATUS_OVERBAKE_BIT = 1;
        private const int STATUS_UNDERBAKE_BIT = 2;
        
        private const int SERVER_CONNECTION_FLAG_BIT = 4;
        private const int MASTER_PLC_CONECTION_BIT = 5;
        
        private const int READ_BIT = 8;
        private const int READING_BIT = 9;
        private const int READ_COMPLETED_BIT = 10;

        private static int TurnBitOn(int value, int bit)
        {
            int res = value | (1 << bit);
            return res;
        }

        private static int TurnBitOff(int value, int bit)
        {
            int res = value & ~(1 << bit);
            return res;
        }

        public MXComponentPLCReader(
            int deviceID, 
            string readAdress, 
            string okAddress, 
            string serialNumberAdress, 
            int startAddress, 
            int serialNumberLength
        ) : base(deviceID)
        {
            this.deviceID = deviceID;
            this.readAddress = readAdress;
            this.okAddress = okAddress;

            this.serialNumberAdress = serialNumberAdress;
            this.serialNumberStartAdress = startAddress;
            this.serialNumberLength = serialNumberLength;

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
                //value = 0b0000_0000_0000_0001;

                PLC.GetDevice(this.okAddress, out value);
                
                bool can_read = (value & (1 << READ_BIT)) != 0;

                // if is disconnected
                if ((value & (1 << SERVER_CONNECTION_FLAG_BIT)) != 0)
                {
                    return new DataStatus(
                        this.PLCId,
                        "failed",
                        new Status(
                            false,
                            new Log(this.PLCId, "Master PLC is not connected to PLC")
                        )
                    );
                }

                // print value
                Console.WriteLine("Value: " + value);

                return new DataStatus(
                    this.PLCId, 
                    can_read, 
                    new Status(
                        true, 
                        new Log(this.PLCId, "ok")
                    )
                );

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
                
                int status = 0;
                PLC.GetDevice(this.readAddress, out status);

                // check if master plc is connected to plc

                if ((status & (1 << MASTER_PLC_CONECTION_BIT)) == 0)
                {
                    return new DataStatus(
                        this.PLCId,
                        false,
                        new Status(
                            false,
                            new Log(this.PLCId, "Master PLC is not connected to PLC")
                        )
                    );
                }


                // set reading bit on and send it
                status = TurnBitOn(status, READING_BIT);
                PLC.SetDevice(this.readAddress, status);

                string serialNumber = "";

                for(int i = this.serialNumberStartAdress; i < this.serialNumberStartAdress + this.serialNumberLength; i++)
                {
                    int value = 0;
                    PLC.GetDevice(this.serialNumberAdress + i, out value);
                    // ascii to char
                    serialNumber += (char)value;
                }

                // set reading bit off and read completed bit on and send it
                status = TurnBitOff(status, READING_BIT);
                status = TurnBitOn(status, READ_COMPLETED_BIT);
                PLC.SetDevice(this.readAddress, status);

                string state = "";
                string gng = "G";
                
                // check state bits of ok, overbake and underbake

                if ((status & (1 << STATUS_OK_BIT)) != 0)
                {
                    state = "ok";
                }
                else if ((status & (1 << STATUS_OVERBAKE_BIT)) != 0)
                {
                    state = "overbake";
                    gng = "NG";
                }
                else if ((status & (1 << STATUS_UNDERBAKE_BIT)) != 0)
                {
                    state = "underbake";
                    gng = "NG";
                }

                // print value
                Console.WriteLine("Read data from " + this.PLCName + ": " + status);

                dynamic data = new
                {
                    serialNumber = serialNumber,
                    status = gng
                };

                return new DataStatus(
                    this.PLCId,
                    data,
                    new Status(
                        true, 
                        new Log(
                            this.PLCId, state
                        )
                    )
                );

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

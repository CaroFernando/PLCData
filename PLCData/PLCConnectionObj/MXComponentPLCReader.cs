using ActUtlTypeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
// json
using Newtonsoft.Json;

namespace PLCData.PLCConnectionObj
{
    public class MXComponentPLCReader : PLCReader
    {
        public ActUtlType PLC = new ActUtlType();

        public string NAME = "";

        public int PHYSICAL_ID = 0;
        public int VIRTUAL_ID = 0;

        public string STATUS_OK_MEM = "";
        public string STATUS_OVERBAKE_MEM = "";
        public string STATUS_UNDERBAKE_MEM = "";

        public string SERVER_CONNECTION_FLAG_MEM = "";
        public string MASTER_PLC_CONECTION_MEM = "";

        public string READ_MEM = "";
        public string READING_MEM = "";
        public string READ_COMPLETED_MEM = "";

        public List<string> SERIAL_NUMBER_MEMS = new List<string>();

        public MXComponentPLCReader(
            int physicalID,
            int deviceID
        ) : base(deviceID)
        {
            this.PHYSICAL_ID = physicalID;
            this.VIRTUAL_ID = deviceID;

            PLC.ActLogicalStationNumber = Convert.ToInt16(physicalID);
            PLC.Open();
        }

        public void LoadFromJSON(string json)
        {
            dynamic data = JsonConvert.DeserializeObject(json);

            this.NAME = data["NAME"];
            this.STATUS_OK_MEM = data["STATUS_OK_MEM"];
            this.STATUS_OVERBAKE_MEM = data["STATUS_OVERBAKE_MEM"];
            this.STATUS_UNDERBAKE_MEM = data["STATUS_UNDERBAKE_MEM"];
            this.SERVER_CONNECTION_FLAG_MEM = data["SERVER_CONNECTION_FLAG_MEM"];
            this.MASTER_PLC_CONECTION_MEM = data["MASTER_PLC_CONECTION_MEM"];
            this.READ_MEM = data["READ_MEM"];
            this.READING_MEM = data["READING_MEM"];
            this.READ_COMPLETED_MEM = data["READ_COMPLETED_MEM"];

            foreach (var mem in data["SERIAL_NUMBER_MEMS"])
            {
                this.SERIAL_NUMBER_MEMS.Add((string)mem);
            }
        }

        public override DataStatus readOk()
        {
            try
            {
                //Console.WriteLine("Trynig to read OK status from PLC " + this.PHYSICAL_ID + " " + this.VIRTUAL_ID);
                // check if the slave plc is connected
                int master_to_slave_disconnection = 0;
                PLC.GetDevice(this.MASTER_PLC_CONECTION_MEM, out master_to_slave_disconnection);

                if(master_to_slave_disconnection != 0)
                {
                    return new DataStatus(
                        this.PLCId,
                        "failed",
                        new Status(
                            false,
                            new Log(this.PLCId, "Dispositivo desconectado de PLC maestro")
                        )
                    );
                }

                //Console.WriteLine("Master to slave connection is OK");

                //check of plc is connected to server
                int server_connection_flag = 0;
                PLC.GetDevice(this.SERVER_CONNECTION_FLAG_MEM, out server_connection_flag);

                if (server_connection_flag != 1)
                {
                    return new DataStatus(
                        this.PLCId,
                        "failed",
                        new Status(
                            false,
                            new Log(this.PLCId, "PLC maestro desconectado del servidor")
                        )
                    );
                }

                //Console.WriteLine("PLC is connected to server");

                int can_read = 0;
                PLC.GetDevice(this.READ_MEM, out can_read);

                //Console.WriteLine("can_read: " + can_read);

                return new DataStatus(
                    this.PLCId, 
                    can_read != 0, 
                    new Status(
                        true, 
                        new Log(this.PLCId, "OK")
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

                int master_to_slave_disconnection = 0;
                PLC.GetDevice(this.MASTER_PLC_CONECTION_MEM, out master_to_slave_disconnection);

                if (master_to_slave_disconnection != 0)
                {
                    return new DataStatus(
                        this.PLCId,
                        "failed",
                        new Status(
                            false,
                            new Log(this.PLCId, "Dispositivo desconectado de PLC maestro")
                        )
                    );
                }

                //check of plc is connected to server
                int server_connection_flag = 0;
                PLC.GetDevice(this.SERVER_CONNECTION_FLAG_MEM, out server_connection_flag);

                if (server_connection_flag != 1)
                {
                    return new DataStatus(
                        this.PLCId,
                        "failed",
                        new Status(
                            false,
                            new Log(this.PLCId, "PLC maestro desconectado del servidor")
                        )
                    );
                }

                // set reading bit on and send it
                PLC.SetDevice(READING_MEM, 1);

                // read serial number
                string serialNumber = "";
                foreach (var mem in this.SERIAL_NUMBER_MEMS)
                {
                    int serialNumberPart = 0;
                    PLC.GetDevice(mem, out serialNumberPart);
                    //Console.WriteLine("Reading from memory: " + mem + " value: " + serialNumberPart);
                    serialNumber += serialNumberPart.ToString();
                }

                int overbake = 0;
                PLC.GetDevice(this.STATUS_OVERBAKE_MEM, out overbake);

                int underbake = 0;
                PLC.GetDevice(this.STATUS_UNDERBAKE_MEM, out underbake);

                int ok = 0;
                PLC.GetDevice(this.STATUS_OK_MEM, out ok);

                PLC.SetDevice(READING_MEM, 0);

                string status = ok == 1 ? "G" : "NG";
                string log = overbake == 1 ? "Sobre horneado" : underbake == 1 ? "Bajo horneado" : "OK";


                dynamic data = new
                {
                    serialNumber = serialNumber,
                    status = status
                };

                return new DataStatus(
                    this.PLCId,
                    data,
                    new Status(
                        true, 
                        new Log(
                            this.PLCId, log
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

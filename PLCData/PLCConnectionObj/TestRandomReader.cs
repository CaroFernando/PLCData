using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLCData.PLCConnectionObj
{
    public class TestRandomReader : PLCReader
    {

        private int counter = 0;
        public bool ok = true;
        public TestRandomReader(int id) : base(id)
        {
        }


        public override DataStatus readOk()
        {
            counter++;
            if (counter == 5)
            {
                counter = 0;

                return new DataStatus(this.PLCId, true, new Status(this.ok, new Log(this.PLCId, "data ok")));
            }
            else
            {
                return new DataStatus(this.PLCId, false, new Status(this.ok, new Log(this.PLCId, "data ok")));
            }
        }

        public override DataStatus readData()
        {
            string serialNumber = "";
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                serialNumber += (char)random.Next(65, 90);
            }

            // randomly choose between ok, overbaked and underbake
            string status = "gg";
            string state = "";
            
            switch (new Random().Next(0, 3))
            {
                case 0:
                    state = "ok";
                    break;
                case 1:
                    state = "overbaked";
                    status = "ng";
                    break;
                case 2:
                    state = "underbaked";
                    status = "ng";
                    break;
            }

            dynamic data = new
            {
                serialNumber = serialNumber,
                status = status
            };

            return new DataStatus(this.PLCId, data, new Status(true, new Log(this.PLCId, state)));
        }
    }
}

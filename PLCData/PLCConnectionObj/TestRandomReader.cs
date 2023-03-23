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
            int num = new Random().Next(0, 100);
            return new DataStatus(this.PLCId, num, new Status(true, new Log(this.PLCId, "ok")));
        }
    }
}

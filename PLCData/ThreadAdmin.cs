using PLCData.PLCConnectionObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PLCData
{
    public class ThreadAdmin
    {
        // mutable list of threads
        private List<PLCReader> readers = new List<PLCReader>();
        public ThreadAdmin()
        {
        }

        public void add(PLCReader reader)
        {
            this.readers.Add(reader);
        }

        public void start()
        {
            foreach (PLCReader reader in this.readers)
            {
                if (reader.started == false)
                {
                    Console.WriteLine("reader " + reader.ToString() + " started");
                    reader.start();
                }
            }
        }
    }
}

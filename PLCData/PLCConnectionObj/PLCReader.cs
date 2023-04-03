using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace PLCData.PLCConnectionObj
{
    public abstract class PLCReader
    {
        private static readonly object _lock = new object();
        public bool started = false;
        private bool readFlag = false;
        protected int PLCId = 0;

        // protected list of callback objects
        protected List<ConnectionCallback> connectionCallbacks = new List<ConnectionCallback>();
        protected List<DataCallback> dataCallbacks = new List<DataCallback>();

        public PLCReader(int id)
        {
            this.PLCId = id;
        }

        public void addConnectionCallback(ConnectionCallback callback)
        {
            this.connectionCallbacks.Add(callback);
        }
        public void addDataCallback(DataCallback callback)
        {
            this.dataCallbacks.Add(callback);
        }

        private void CallbackOnConnectionSuccess(Log log)
        {
            foreach (ConnectionCallback callback in this.connectionCallbacks)
            {
                callback.OnConnectionSuccess(log);
            }
        }

        private void CallbackOnConnectionFailed(Log log)
        {
            foreach (ConnectionCallback callback in this.connectionCallbacks)
            {
                callback.OnConnectionFailed(log);
            }
        }

        private void CallbackDataRetrieved(DataStatus data)
        {
            foreach (DataCallback callback in this.dataCallbacks)
            {
                callback.dataRetrieved(data);
            }
        }

        public abstract DataStatus readOk();
        public abstract DataStatus readData();

        public void start()
        {
            started = true;
            bool inactiveStatusCalled = false;

            bool intialConnection = true;

            Task.Run(() =>
            {
                while (started)
                {
                    lock (_lock)
                    {
                        DataStatus readok = this.readOk();

                        if (intialConnection)
                        {
                            intialConnection = false;
                            if (readok.status.ok)
                            {
                                CallbackOnConnectionSuccess(readok.status.log);
                            }
                            else
                            {
                                CallbackOnConnectionFailed(readok.status.log);
                            }
                        }

                        if (readok.status.ok == false)
                        {
                            if (inactiveStatusCalled == true)
                            {
                                CallbackOnConnectionFailed(readok.status.log);
                                inactiveStatusCalled = false;
                            }
                        }
                        else
                        {
                            if (inactiveStatusCalled == false)
                            {
                                CallbackOnConnectionSuccess(readok.status.log);
                                inactiveStatusCalled = true;
                            }
                            
                            if ((bool)readok.data == true)
                            {
                                DataStatus value = this.readData();
                                
                                if (value.status.ok && this.readFlag == false)
                                {
                                    if (this.readFlag == false)
                                    {
                                        this.readFlag = true;
                                        this.CallbackDataRetrieved(value);
                                    }
                                    
                                }
                                else if (value.status.ok == false)
                                {
                                    this.CallbackOnConnectionFailed(value.status.log);
                                }
                            }
                            else
                            {
                                this.readFlag = false;
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(20);
                }
            });
        }
        public void stop()
        {
            started = false;
        }
    }
}

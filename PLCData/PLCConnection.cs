﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;
using PLCData.PLCConnectionObj;
using System.Runtime.InteropServices;

namespace PLCData
{
    public partial class PLCConnection : Form
    {
        MXComponentPLCReader EDReader, FILLERReader, TOPCOAT1Reader, TOPCOAT2Reader;
        
        // TestRandomReader testReader;

        private void Form1_Load(object sender, EventArgs e)
        {
            UIPLCStatus2.ManualStartStop();
            UIPLCStatus3.ManualStartStop();
            UIPLCStatus4.ManualStartStop();
            UIPLCStatus5.ManualStartStop();

            // testReader.start();
        }

        public PLCConnection()
        {
            InitializeComponent();
            // -----------------------------------------------
            // this.testReader = new TestRandomReader(1);
            // this.testReader.ok = false;
            // -----------------------------------------------
            
            this.EDReader = new MXComponentPLCReader(1, 1);

            // load EDReader atributes from ED.json
            EDReader.LoadFromJSON(System.IO.File.ReadAllText("PLCMemoryRegions/ED.json"));
            
            this.EDReader.addConnectionCallback(new TestConnectionCallback());
            this.EDReader.addConnectionCallback(new APIConnectionCallback());
            this.EDReader.addDataCallback(new TestDataCallback());
            this.EDReader.addDataCallback(new APICallDataCallback());
            this.UIPLCStatus2.setReader(this.EDReader);
            this.UIPLCStatus2.setName("ED");

            this.FILLERReader = new MXComponentPLCReader(1, 2);

            // load FILLERReader atributes from FILLER.json
            FILLERReader.LoadFromJSON(System.IO.File.ReadAllText("PLCMemoryRegions/FILLER.json"));

            this.FILLERReader.addConnectionCallback(new TestConnectionCallback());
            this.FILLERReader.addConnectionCallback(new APIConnectionCallback());
            this.FILLERReader.addDataCallback(new TestDataCallback());
            this.FILLERReader.addDataCallback(new APICallDataCallback());
            this.UIPLCStatus3.setReader(this.FILLERReader);
            this.UIPLCStatus3.setName("FILLER");

            this.TOPCOAT1Reader = new MXComponentPLCReader(1, 3);

            // load TOPCOAT1Reader atributes from TOPCOAT1.json
            TOPCOAT1Reader.LoadFromJSON(System.IO.File.ReadAllText("PLCMemoryRegions/TOP_COAT_1.json"));

            this.TOPCOAT1Reader.addConnectionCallback(new TestConnectionCallback());
            this.TOPCOAT1Reader.addConnectionCallback(new APIConnectionCallback());
            this.TOPCOAT1Reader.addDataCallback(new TestDataCallback());
            this.TOPCOAT1Reader.addDataCallback(new APICallDataCallback());
            this.UIPLCStatus4.setReader(this.TOPCOAT1Reader);
            this.UIPLCStatus4.setName("TOP-COAT 1");

            this.TOPCOAT2Reader = new MXComponentPLCReader(1, 4);

            // load TOPCOAT2Reader atributes from TOPCOAT2.json
            TOPCOAT2Reader.LoadFromJSON(System.IO.File.ReadAllText("PLCMemoryRegions/TOP_COAT_2.json"));

            this.TOPCOAT2Reader.addConnectionCallback(new TestConnectionCallback());
            this.TOPCOAT2Reader.addConnectionCallback(new APIConnectionCallback());
            this.TOPCOAT2Reader.addDataCallback(new TestDataCallback());
            this.TOPCOAT2Reader.addDataCallback(new APICallDataCallback());
            this.UIPLCStatus5.setReader(this.TOPCOAT2Reader);
            this.UIPLCStatus5.setName("TOP-COAT 2");

        }
    }
}

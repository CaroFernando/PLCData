using System;
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
    public partial class Form1 : Form
    {

        TestRandomReader testreader;
        MXComponentPLCReader reader1, reader2, reader3, reader4;
        public Form1()
        {
            InitializeComponent();
            this.testreader = new TestRandomReader(1);

            this.testreader.addConnectionCallback(new TestConnectionCallback());
            this.testreader.addConnectionCallback(new APIConnectionCallback());
            this.testreader.addDataCallback(new APICallDataCallback());
            this.testreader.addDataCallback(new TestDataCallback());
            this.UIPLCStatus1.setReader(this.testreader);
            this.UIPLCStatus1.setName("Test1");

            this.reader1 = new MXComponentPLCReader(1, "D000", "D000", "D50", 0, 10);

            this.reader1.addConnectionCallback(new TestConnectionCallback());
            this.reader1.addDataCallback(new TestDataCallback());
            this.UIPLCStatus2.setReader(this.reader1);
            this.UIPLCStatus2.setName("Test2");

            this.reader2 = new MXComponentPLCReader(2, "D001", "D001", "D51", 0, 10);

            this.reader2.addConnectionCallback(new TestConnectionCallback());
            this.reader2.addDataCallback(new TestDataCallback());
            this.UIPLCStatus3.setReader(this.reader2);
            this.UIPLCStatus3.setName("Test3");

            this.reader3 = new MXComponentPLCReader(3, "D002", "D002", "D52", 0, 10);

            this.reader3.addConnectionCallback(new TestConnectionCallback());
            this.reader3.addDataCallback(new TestDataCallback());
            this.UIPLCStatus4.setReader(this.reader3);
            this.UIPLCStatus4.setName("Test4");

            this.reader4 = new MXComponentPLCReader(4, "D003", "D003", "D53", 0, 10);

            this.reader4.addConnectionCallback(new TestConnectionCallback());
            this.reader4.addDataCallback(new TestDataCallback());
            this.UIPLCStatus5.setReader(this.reader4);
            this.UIPLCStatus5.setName("Test5");


        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            //this.reader2.ok = !this.reader2.ok;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.testreader.ok = !this.testreader.ok;
        }

        private void uiplcStatus1_Load(object sender, EventArgs e)
        {

        }
    }
}

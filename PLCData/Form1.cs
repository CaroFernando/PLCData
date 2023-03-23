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

        TestRandomReader reader1, reader2;
        public Form1()
        {
            InitializeComponent();
            this.reader1 = new TestRandomReader(1);

            this.reader1.addConnectionCallback(new TestConnectionCallback());
            this.reader1.addDataCallback(new TestDataCallback());
            this.UIPLCStatus1.setReader(this.reader1);
            this.UIPLCStatus1.setName("Test1");

            this.reader2 = new TestRandomReader(2);

            this.reader2.addConnectionCallback(new TestConnectionCallback());
            this.reader2.addDataCallback(new TestDataCallback());
            this.UIPLCStatus2.setReader(this.reader2);
            this.UIPLCStatus2.setName("Test2");

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            this.reader2.ok = !this.reader2.ok;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.reader1.ok = !this.reader1.ok;
        }

        private void uiplcStatus1_Load(object sender, EventArgs e)
        {

        }
    }
}

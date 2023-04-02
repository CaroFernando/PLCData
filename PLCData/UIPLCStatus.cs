using PLCData.PLCConnectionObj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCData
{
    public partial class UIPLCStatus : UserControl
    {
        private string name;
        public bool status = false;
        private UIConnectionCallback callback;
        public PLCReader reader;
        public bool AutoStart = false;

        public UIPLCStatus()
        {
            InitializeComponent();
            
        }

        public UIPLCStatus(string name, PLCReader reader, bool autostart = true)
        {
            InitializeComponent();
            this.name = name;
            this.NameLabel.Text = name;
            this.reader = reader;
            this.callback = new UIConnectionCallback(this);
            this.reader.addConnectionCallback(this.callback);
            this.AutoStart = autostart;
        }

        public void setName(string name)
        {
            this.name = name;
            this.NameLabel.Text = name;
        }

        public void setReader(PLCReader reader)
        {
            this.reader = reader;
            this.callback = new UIConnectionCallback(this);
            this.reader.addConnectionCallback(this.callback);
        }

        private void StartStopBtn_Click(object sender, EventArgs e)
        {
            if (this.reader.started)
            {
                this.reader.stop();
                this.StartStopBtn.Text = "Start";
            }
            else
            {
                this.reader.start();
                this.StartStopBtn.Text = "Stop";
            }

        }

        public void ChangeStatus(bool status)
        {
            Console.WriteLine("STATUS CHANGED UI " + status);
            this.status = status;
            if (this.status)
            {
                this.StatusLabel.Invoke(
                    new Action(() => this.StatusLabel.Text = "Conectado")
                );
                this.StartStopBtn.Invoke(
                    new Action(() => this.BackColor = Color.Green)
                );     
            }
            else
            {
                this.StatusLabel.Invoke(
                    new Action(() => this.StatusLabel.Text = "Desconectado")
                );
                this.StartStopBtn.Invoke(
                    new Action(() => this.BackColor = Color.Red)
                );
            }
        }

        private void UIPLCStatus_Load(object sender, EventArgs e)
        {
            
        }
    }
}

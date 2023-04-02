namespace PLCData
{
    partial class PLCConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UIPLCStatus5 = new PLCData.UIPLCStatus();
            this.UIPLCStatus4 = new PLCData.UIPLCStatus();
            this.UIPLCStatus3 = new PLCData.UIPLCStatus();
            this.UIPLCStatus2 = new PLCData.UIPLCStatus();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UIPLCStatus5
            // 
            this.UIPLCStatus5.Location = new System.Drawing.Point(357, 321);
            this.UIPLCStatus5.Name = "UIPLCStatus5";
            this.UIPLCStatus5.Size = new System.Drawing.Size(311, 286);
            this.UIPLCStatus5.TabIndex = 9;
            // 
            // UIPLCStatus4
            // 
            this.UIPLCStatus4.Location = new System.Drawing.Point(12, 321);
            this.UIPLCStatus4.Name = "UIPLCStatus4";
            this.UIPLCStatus4.Size = new System.Drawing.Size(311, 286);
            this.UIPLCStatus4.TabIndex = 8;
            // 
            // UIPLCStatus3
            // 
            this.UIPLCStatus3.Location = new System.Drawing.Point(357, 12);
            this.UIPLCStatus3.Name = "UIPLCStatus3";
            this.UIPLCStatus3.Size = new System.Drawing.Size(311, 286);
            this.UIPLCStatus3.TabIndex = 7;
            // 
            // UIPLCStatus2
            // 
            this.UIPLCStatus2.Location = new System.Drawing.Point(12, 12);
            this.UIPLCStatus2.Name = "UIPLCStatus2";
            this.UIPLCStatus2.Size = new System.Drawing.Size(311, 286);
            this.UIPLCStatus2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(561, 641);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PLCConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 676);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UIPLCStatus5);
            this.Controls.Add(this.UIPLCStatus4);
            this.Controls.Add(this.UIPLCStatus3);
            this.Controls.Add(this.UIPLCStatus2);
            this.Name = "PLCConnection";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private UIPLCStatus UIPLCStatus2;
        private UIPLCStatus UIPLCStatus3;
        private UIPLCStatus UIPLCStatus4;
        private UIPLCStatus UIPLCStatus5;
        private System.Windows.Forms.Button button1;
    }
}


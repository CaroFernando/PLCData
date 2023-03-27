namespace PLCData
{
    partial class Form1
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
            this.State2 = new System.Windows.Forms.Button();
            this.State1 = new System.Windows.Forms.Button();
            this.UIPLCStatus1 = new PLCData.UIPLCStatus();
            this.UIPLCStatus2 = new PLCData.UIPLCStatus();
            this.UIPLCStatus3 = new PLCData.UIPLCStatus();
            this.UIPLCStatus4 = new PLCData.UIPLCStatus();
            this.UIPLCStatus5 = new PLCData.UIPLCStatus();
            this.SuspendLayout();
            // 
            // State2
            // 
            this.State2.Location = new System.Drawing.Point(407, 475);
            this.State2.Name = "State2";
            this.State2.Size = new System.Drawing.Size(75, 23);
            this.State2.TabIndex = 0;
            this.State2.Text = "State";
            this.State2.UseVisualStyleBackColor = true;
            this.State2.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // State1
            // 
            this.State1.Location = new System.Drawing.Point(54, 475);
            this.State1.Name = "State1";
            this.State1.Size = new System.Drawing.Size(75, 23);
            this.State1.TabIndex = 4;
            this.State1.Text = "State";
            this.State1.UseVisualStyleBackColor = true;
            this.State1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UIPLCStatus1
            // 
            this.UIPLCStatus1.Location = new System.Drawing.Point(54, 25);
            this.UIPLCStatus1.Name = "UIPLCStatus1";
            this.UIPLCStatus1.Size = new System.Drawing.Size(207, 283);
            this.UIPLCStatus1.TabIndex = 5;
            // 
            // UIPLCStatus2
            // 
            this.UIPLCStatus2.Location = new System.Drawing.Point(292, 25);
            this.UIPLCStatus2.Name = "UIPLCStatus2";
            this.UIPLCStatus2.Size = new System.Drawing.Size(211, 286);
            this.UIPLCStatus2.TabIndex = 6;
            // 
            // UIPLCStatus3
            // 
            this.UIPLCStatus3.Location = new System.Drawing.Point(532, 25);
            this.UIPLCStatus3.Name = "UIPLCStatus3";
            this.UIPLCStatus3.Size = new System.Drawing.Size(192, 286);
            this.UIPLCStatus3.TabIndex = 7;
            // 
            // UIPLCStatus4
            // 
            this.UIPLCStatus4.Location = new System.Drawing.Point(745, 25);
            this.UIPLCStatus4.Name = "UIPLCStatus4";
            this.UIPLCStatus4.Size = new System.Drawing.Size(186, 286);
            this.UIPLCStatus4.TabIndex = 8;
            // 
            // UIPLCStatus5
            // 
            this.UIPLCStatus5.Location = new System.Drawing.Point(972, 25);
            this.UIPLCStatus5.Name = "UIPLCStatus5";
            this.UIPLCStatus5.Size = new System.Drawing.Size(180, 286);
            this.UIPLCStatus5.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 552);
            this.Controls.Add(this.UIPLCStatus5);
            this.Controls.Add(this.UIPLCStatus4);
            this.Controls.Add(this.UIPLCStatus3);
            this.Controls.Add(this.UIPLCStatus2);
            this.Controls.Add(this.UIPLCStatus1);
            this.Controls.Add(this.State1);
            this.Controls.Add(this.State2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button State2;
        private System.Windows.Forms.Button State1;
        private UIPLCStatus UIPLCStatus1;
        private UIPLCStatus UIPLCStatus2;
        private UIPLCStatus UIPLCStatus3;
        private UIPLCStatus UIPLCStatus4;
        private UIPLCStatus UIPLCStatus5;
    }
}


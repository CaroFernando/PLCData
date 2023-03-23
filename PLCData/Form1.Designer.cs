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
            this.UIPLCStatus1.Size = new System.Drawing.Size(281, 283);
            this.UIPLCStatus1.TabIndex = 5;
            // 
            // UIPLCStatus2
            // 
            this.UIPLCStatus2.Location = new System.Drawing.Point(407, 25);
            this.UIPLCStatus2.Name = "UIPLCStatus2";
            this.UIPLCStatus2.Size = new System.Drawing.Size(289, 286);
            this.UIPLCStatus2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 544);
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
    }
}


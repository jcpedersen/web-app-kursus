namespace WCF_Client_Windows_Forms
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
            this.btnRetrieveWCF = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbWCFinput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRetrieveSavedWCF = new System.Windows.Forms.Button();
            this.lblRetrievedWCF = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRetrieveWCF
            // 
            this.btnRetrieveWCF.Location = new System.Drawing.Point(20, 25);
            this.btnRetrieveWCF.Name = "btnRetrieveWCF";
            this.btnRetrieveWCF.Size = new System.Drawing.Size(108, 23);
            this.btnRetrieveWCF.TabIndex = 0;
            this.btnRetrieveWCF.Text = "Retrieve WCF";
            this.btnRetrieveWCF.UseVisualStyleBackColor = true;
            this.btnRetrieveWCF.Click += new System.EventHandler(this.btnRetrieveWCF_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Location = new System.Drawing.Point(136, 30);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(175, 13);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "label for showing the retrieved WCF";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(32, 36);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbWCFinput
            // 
            this.tbWCFinput.Location = new System.Drawing.Point(116, 39);
            this.tbWCFinput.Name = "tbWCFinput";
            this.tbWCFinput.Size = new System.Drawing.Size(435, 20);
            this.tbWCFinput.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRetrievedWCF);
            this.groupBox1.Controls.Add(this.btnRetrieveSavedWCF);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 143);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WCF";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblUserInfo);
            this.groupBox2.Controls.Add(this.btnRetrieveWCF);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 80);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Debug WCF";
            // 
            // btnRetrieveSavedWCF
            // 
            this.btnRetrieveSavedWCF.Location = new System.Drawing.Point(20, 80);
            this.btnRetrieveSavedWCF.Name = "btnRetrieveSavedWCF";
            this.btnRetrieveSavedWCF.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieveSavedWCF.TabIndex = 0;
            this.btnRetrieveSavedWCF.Text = "Retrieve";
            this.btnRetrieveSavedWCF.UseVisualStyleBackColor = true;
            this.btnRetrieveSavedWCF.Click += new System.EventHandler(this.btnRetrieveSavedWCF_Click);
            // 
            // lblRetrievedWCF
            // 
            this.lblRetrievedWCF.AutoSize = true;
            this.lblRetrievedWCF.Location = new System.Drawing.Point(101, 90);
            this.lblRetrievedWCF.Name = "lblRetrievedWCF";
            this.lblRetrievedWCF.Size = new System.Drawing.Size(175, 13);
            this.lblRetrievedWCF.TabIndex = 1;
            this.lblRetrievedWCF.Text = "label for showing the retrieved WCF";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 289);
            this.Controls.Add(this.tbWCFinput);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "WCF Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetrieveWCF;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbWCFinput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRetrievedWCF;
        private System.Windows.Forms.Button btnRetrieveSavedWCF;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}


namespace Monitor
{
    /// <summary>
    /// 
    /// </summary>
    partial class AddContact
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
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_Name = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Phone = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox_Notes = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox_Password = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_IMEI = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // richTextBox_Name
            // 
            this.richTextBox_Name.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Name.Location = new System.Drawing.Point(86, 15);
            this.richTextBox_Name.Multiline = false;
            this.richTextBox_Name.Name = "richTextBox_Name";
            this.richTextBox_Name.Size = new System.Drawing.Size(240, 32);
            this.richTextBox_Name.TabIndex = 2;
            this.richTextBox_Name.Text = "";
            // 
            // richTextBox_Phone
            // 
            this.richTextBox_Phone.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Phone.Location = new System.Drawing.Point(86, 53);
            this.richTextBox_Phone.Multiline = false;
            this.richTextBox_Phone.Name = "richTextBox_Phone";
            this.richTextBox_Phone.Size = new System.Drawing.Size(240, 32);
            this.richTextBox_Phone.TabIndex = 4;
            this.richTextBox_Phone.Text = "";
            this.richTextBox_Phone.TextChanged += new System.EventHandler(this.RichTextBox_Phone_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phone:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(310, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(206, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // richTextBox_Notes
            // 
            this.richTextBox_Notes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Notes.Location = new System.Drawing.Point(86, 165);
            this.richTextBox_Notes.Multiline = false;
            this.richTextBox_Notes.Name = "richTextBox_Notes";
            this.richTextBox_Notes.Size = new System.Drawing.Size(240, 75);
            this.richTextBox_Notes.TabIndex = 6;
            this.richTextBox_Notes.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Notes:";
            // 
            // richTextBox_Password
            // 
            this.richTextBox_Password.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Password.Location = new System.Drawing.Point(86, 91);
            this.richTextBox_Password.Multiline = false;
            this.richTextBox_Password.Name = "richTextBox_Password";
            this.richTextBox_Password.Size = new System.Drawing.Size(240, 32);
            this.richTextBox_Password.TabIndex = 5;
            this.richTextBox_Password.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // richTextBox_IMEI
            // 
            this.richTextBox_IMEI.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_IMEI.Location = new System.Drawing.Point(86, 129);
            this.richTextBox_IMEI.Multiline = false;
            this.richTextBox_IMEI.Name = "richTextBox_IMEI";
            this.richTextBox_IMEI.Size = new System.Drawing.Size(240, 32);
            this.richTextBox_IMEI.TabIndex = 9;
            this.richTextBox_IMEI.Text = "";
            this.richTextBox_IMEI.TextChanged += new System.EventHandler(this.RichTextBox_IMEI_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "IMEI:";
            // 
            // AddContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 319);
            this.Controls.Add(this.richTextBox_IMEI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox_Password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox_Notes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox_Phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox_Name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddContact";
            this.Text = "AddContact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_Name;
        private System.Windows.Forms.RichTextBox richTextBox_Phone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox_Notes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox_IMEI;
        private System.Windows.Forms.Label label5;

    }
}
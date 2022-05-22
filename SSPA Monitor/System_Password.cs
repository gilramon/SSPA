using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class System_Password : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnValue2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ComboBox ConnectionNumbers
        {
            get { return comboBox_ConnectionNumber; }
            set { comboBox_ConnectionNumber = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public RichTextBox PasswordText
        {
            get { return richTextBox_SysPassword; }
            set { richTextBox_SysPassword = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public System_Password()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox_ConnectionNumber.SelectedItem != null)
            {
                this.Password = richTextBox_SysPassword.Text;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Password = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        
        }
    }
}

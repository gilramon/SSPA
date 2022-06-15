using System;
using System.Windows.Forms;

namespace Monitor
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SMSCommand : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TextBoxCommand
        {
            get { return richTextBox_Command.Text; }
            set { richTextBox_Command.Text = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public SMSCommand()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Command = richTextBox_Command.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            this.Command = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}

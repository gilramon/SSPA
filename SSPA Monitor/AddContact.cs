using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Monitor
{
    public partial class AddContact : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public string ContactIMEI { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactNotes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContactPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TextBoxName
        {
            get { return richTextBox_Name.Text; }
            set { richTextBox_Name.Text = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TextBoxPhone
        {
            get { return richTextBox_Phone.Text; }
            set { richTextBox_Phone.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TextBoxNotes
        {
            get { return richTextBox_Notes.Text; }
            set { richTextBox_Notes.Text = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string TextBoxPassword
        {
            get { return richTextBox_Password.Text; }
            set { richTextBox_Password.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TextBoxIMEI
        {
            get { return richTextBox_IMEI.Text; }
            set { richTextBox_IMEI.Text = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public AddContact()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (richTextBox_Phone.BackColor == Color.Red)
            {

            }
            else
            {
                this.ContactName = richTextBox_Name.Text;
                this.ContactPhone = richTextBox_Phone.Text;
                this.ContactNotes = richTextBox_Notes.Text;
                this.ContactPassword = richTextBox_Password.Text;
                this.ContactIMEI = richTextBox_IMEI.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.ContactName = null;
            this.ContactPhone = null;
            this.ContactNotes = null;
            this.ContactPassword = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        enum ConfigDataType
        {
            Angel,
            PeriodStatus,
            SpeedLimit,
            Number,
            Float,
            BatLevel,
            JammingSens,
            EveryThing,
            AlarmViaSMS,
            Unit_ID,
            Subscriber,
            Password,
            Boolean,
            IpAddress,
            Port,
            GPRSDisconnectNum
        };


               bool CheckSubscriberValid(string i_String,ConfigDataType i_DataType)
       {
           bool ret;
           try
           {
               

               switch (i_DataType)
               {

                   case ConfigDataType.Subscriber:
                                                    if (i_String.Length < 6)
                                                    {
                                                        ret = false;
                                                    }
                                                    else
                                                    if (i_String.Length < 20 && i_String.StartsWith("+") && Regex.IsMatch(i_String.Substring(1), @"^[0-9]+$"))
                                                   {
                                                       ret = true;
                                                   }
                                                   else
                                                   {
                                                       ret = false;
                                                   }
                                                   break;

                   

                   default:
                       ret = false;
                       break;
               }
           }
           catch
           {
               ret = false;
           }
           
           return ret;
       }

        void CheckConfigTextboxValidData(RichTextBox i_TextBox, ConfigDataType i_ConfigDataType)
        {

            i_TextBox.Invoke(new EventHandler(delegate
            {
                if (i_TextBox.Text == "" || i_TextBox.Text == "@%@")
                {
                    i_TextBox.Text = "";
                    i_TextBox.BackColor = default;
                }
                else
                    if (CheckSubscriberValid(i_TextBox.Text, i_ConfigDataType) == true)
                    {
                        i_TextBox.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        i_TextBox.Visible = true;
                        i_TextBox.BackColor = Color.Red;
                    }
            }));
        }

        private void RichTextBox_Name_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void RichTextBox_Phone_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((RichTextBox)sender, ConfigDataType.Subscriber);
        }

        private void RichTextBox_Phone_TextChanged_1(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((RichTextBox)sender, ConfigDataType.Subscriber);
        }

        private void RichTextBox_IMEI_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

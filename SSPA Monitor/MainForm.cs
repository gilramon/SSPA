using DSPLib;
using Monitor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace SocketServer
{


    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// 
        /// </summary>
		public AsyncCallback pfnWorkerCallBack;
        /// <summary>
        /// 
        /// </summary>
		public Socket m_socListener;
        /// <summary>
        /// 
        /// </summary>
		public Socket m_socWorker;
        private System.Windows.Forms.GroupBox groupBox_ServerSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPortNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDataTx;
        private System.Windows.Forms.Button button1;
        //TcpListener tcpListener;
        //private Thread listenThread;
        private CheckBox ListenBox;
        //NetworkStream clientStream;

        bool New_Line = false;
        bool Show_Time;
        private TabControl tabControl_Main;
        private TabPage tabPage_SerialPort;
        private IContainer components;
        private GroupBox groupBox5;
        private CheckBox checkBox_S1Pause;
        private Button txtS1_Clear;
        private RichTextBox SerialPortLogger_TextBox;
        private GroupBox S1_Configuration;
        private GroupBox groupBox12;
        private Button button13;
        private GroupBox groupBox22;
        private Button button19;
        private GroupBox groupBox28;
        private Button button25;
        private TextBox textBox_ModemPrimeryPort;
        private TextBox textBox_ModemPrimeryHost;
        private GroupBox groupBox30;
        private TextBox textBox_ForginPassword;
        private Button button27;
        private TextBox textBox_ForginAcessPoint;
        private TextBox textBox_ForginSecondaryDNS;
        private TextBox textBox_ForginUserName;
        private TextBox textBox_ForginPrimeryDNS;
        private GroupBox groupBox29;
        private TextBox textBox_HomePassword;
        private Button button26;
        private TextBox textBox_HomeAcessPoint;
        private TextBox textBox_HomeSecondaryDNS;
        private TextBox textBox_HomeUserName;
        private TextBox textBox_HomePrimeryDNS;
        private GroupBox groupBox27;
        private Button button24;
        private GroupBox groupBox26;
        private Button button23;
        private GroupBox groupBox25;
        private Button button22;
        private GroupBox groupBox24;
        private ComboBox comboBox_DispatchSpeed;
        private Button button21;
        private GroupBox groupBox23;
        private ComboBox comboBox_KillEngine;
        private Button button20;
        private GroupBox groupBox21;
        private ComboBox comboBox_TiltTowSensState;
        private Button button18;
        private GroupBox groupBox20;
        private ComboBox comboBox_HitState;
        private Button button17;
        private GroupBox groupBox19;
        private ComboBox comboBox_ShockState;
        private Button button16;
        private GroupBox groupBox18;
        private ComboBox comboBox1_TiltState;
        private Button button15;
        private GroupBox groupBox17;
        private Button button14;
        private GroupBox groupBox11;
        private ComboBox comboBox_SleepPolicy;
        private Button button12;
        private GroupBox groupBox10;
        private ComboBox comboBox_AlarmPilicy;
        private Button button11;
        private GroupBox groupBox9;
        private DateTimePicker dateTimePicker_SetTimeDate;
        private Button button10;
        private GroupBox groupBox8;
        private ComboBox comboBox_BatThreshold;
        private Button button9;
        private GroupBox groupBox7;
        private ComboBox comboBox_OutputNum;
        private ComboBox comboBox_OutputControl;
        private Button button8;
        private ComboBox comboBox_OutputPulseLevel;
        private GroupBox groupBox6;
        private ComboBox comboBox_InputNum1;
        private ComboBox comboBox_Interupt;
        private Button button7;
        private GroupBox groupBox13;
        private Button btn_ChangePassword;
        private TextBox textBox_NewPassword;
        private GroupBox groupBox14;
        private ComboBox comboBox_SMSControl;
        private Button button_SMSControl;
        private GroupBox groupBox15;
        private ComboBox comboBox_InputIndex;
        private Button button_SetFreeText;
        private GroupBox groupBox16;
        private Button button4;
        private TabPage tabPage5;
        private TextBox maskedTextBox3_Subscriber3;
        private TextBox maskedTextBox2_Subscriber2;
        private TextBox maskedTextBox1_Subscriber1;
        private TextBox maskedTextBox_OutputDuration;
        private TextBox maskedTextBox_InputDuration;
        private TextBox maskedTextBox1;
        private TextBox TextBox_NormalStatusDuration;
        private TextBox textBox_FreeText;
        private TextBox textBox_ModemSocket;
        private TextBox textBox_ModemRetries;
        private TextBox textBox_ModemTimeOut;
        private TextBox TextBox_Odometer;
        private TextBox maskedTextBox_TowDetectNum;
        private TextBox maskedTextBox_TowWindow;
        private TextBox maskedTextBox_TowAngle;
        private TextBox maskedTextBox_TiltDetectNum;
        private TextBox maskedTextBox_TiltWindow;
        private TextBox maskedTextBox_TiltAngle;
        private TextBox maskedTextBox_ShockDetectNum;
        private TextBox maskedTextBox_ShockWindow;
        private TextBox maskedTextBox_SpeedLimit2;
        private TextBox maskedTextBox_SpeedLimit3;
        private TextBox maskedTextBox_SpeedLimit1;
        private TextBox maskedTextBox_TiltTowSens;
        private TextBox maskedTextBox_HitSensitivity;
        private OpenFileDialog openFileDialog1;
        private CheckBox checkBox_S1RecordLog;
        private System.Windows.Forms.Timer timer_General_100ms;
        private TextBox textBox_NumberOfOpenConnections;
        private System.Windows.Forms.Timer timer_General_1Second;
        private GroupBox gbPortSettings;
        private ComboBox cmb_PortName;
        private ComboBox cmbBaudRate;
        private ComboBox cmb_StopBits;
        private ComboBox cmbParity;
        private ComboBox cmbDataBits;
        private Label lblComPort;
        private Label lblStopBits;
        private Label lblBaudRate;
        private Label lblDataBits;
        private Label label3;
        private System.IO.Ports.SerialPort serialPort;
        private GroupBox groupBox_ConnectionTimedOut;
        private TextBox textBox_ConnectionTimedOut;
        private Button button_SetTimedOut;
        private TextBox textBox_CurrentTimeOut;
        private TextBox textBox_ServerOpen;
        private TabPage tabPage_ServerTCP;
        private TabPage tabPage4;
        private GroupBox groupBox36;
        private TextBox textBox_SMSPhoneNumber;
        private GroupBox groupBox_PhoneNumber;
        private CheckBox checkBox_EchoResponse;
        private GroupBox groupBox_FOTA;
        private Button button5;
        private TextBox textBox_FOTA;
        private TextBox textBox_TotalFrames1280Bytes;
        private Button button_StartFOTA;
        private Button button35;
        private ComboBox comboBox_ConnectionNumber;
        private GroupBox groupBox_SendSerialOrMonitorCommands;
        private Button button_SendSerialPort;
        private TextBox textBox_SerialPortRecognizePattern;
        private RichTextBox textBox_MaximumNumberReceivedRequest;
        private TextBox textBox_TotalFileLength;
        private Button button_StartFOTAProcess;
        private RichTextBox textBox_IDKey;
        private TextBox textBox_SerialPortRecognizePattern2;
        private TextBox textBox_SerialPortRecognizePattern3;
        private Button button_ReScanComPort;
        private Button button_StopwatchReset;
        private Button button_Stopwatch_Start_Stop;
        private TextBox textBox_StopWatch;
        private GroupBox groupBox_Stopwatch;
        private Button button_TimerLog;
        private CheckBox checkBox_ParseMessages;
        private GroupBox groupBox_Timer;
        private Button button_StartStopTimer;
        private Button button_ResetTimer;
        private TextBox textBox_SetTimerTime;
        private TextBox textBox_TimerTime;
        private Button button_OpenFolder;
        private CheckBox checkBox_DeleteCommand;
        private TabPage tabPage_charts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button button_ScreenShot;
        private TextBox textBox_SendSerialPort;
        private TextBox textBox_graph_XY;
        private Button button_ResetGraphs;
        private Button Button_Export_excel;
        private Button button_GraphPause;
        private Button button_OpenFolder2;
        private TabPage tabPage_ClientTCP;
        private Button button43;
        private Button button_ClientClose;
        private Button button_ClientConnect;
        private Button button3;
        private RichTextBox richTextBox_ClientTx;
        private TextBox textBox_ClientPort;
        private TextBox textBox_ClientIP;
        private Label label8;
        private Label label7;
        private Label label10;
        private Label label9;
        private Button button_ClearRx;
        private RichTextBox richTextBox_ClientRx;
        private ListBox listBox_Charts;
        private Label Label_SerialPortRx;
        private Label label_SerialPortConnected;
        private Label Label_SerialPortTx;
        private GroupBox groupBox_SerialPort;
        private Button button28;
        private CheckBox checkBox_RxHex;
        private CheckBox checkBox_SendHexdata;
        private Button button_OpenPort;
        private ComboBox comboBox_ChartUpdateTime;
        private GroupBox groupBox4;
        private TextBox textBox_SystemStatus;
        private PictureBox pictureBox1;
        private TabPage tabPage_GenericFrame;
        private Button button_SendProtocolTCPIP;
        private TextBox textBox_data;
        private TextBox textBox_Opcode;
        private TextBox textBox_Preamble;
        private Label label11;
        private Label label6;
        private Label label4;
        private GroupBox groupBox_ClentTCPStatus;
        private Label label12;
        private Label label_ClientTCPConnected;
        private Label label14;
        private Button button_ClearServer;
        private GroupBox groupBox31;
        private Label label13;
        private TextBox textBox_RxClientPreamble;
        private TextBox textBox_RxClientOpcode;
        private TextBox textBox_RxClientData;
        private Label label15;
        private Label label16;
        private GroupBox groupBox_clientTX;
        private Label label_SerialPortStatus;
        private Label label_TCPClient;
        private TabPage tabPage_Commands;
        private GroupBox groupBox40;
        private GroupBox groupBox32;
        private RichTextBox richTextBox_SSPA;
        private CheckBox checkBox_RecordMiniAda;
        private CheckBox checkBox_PauseMiniAda;
        private Button button_ClearMiniAda;
        private Label label17;
        private Label label18;
        private Button button45;
        private Button button46;
        private Button button52;
        private TabControl tabControl_System;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button59;
        private Button button60;
        private Button button61;
        private Button button62;
        private TextBox textBox_RxClientDataLength;
        private Label label23;
        private Label label24;
        private GroupBox groupBox3;
        private CheckBox checkBox_StopLogging;
        private RichTextBox TextBox_Server;
        private CheckBox checkBox_RecordGeneral;
        private CheckBox PauseCheck;
        private Button Clear_btn;
        private Button button63;
        private TextBox textBox_SetADCMode;
        private Button button64;
        private Button button65;
        private Button button66;
        private Button button67;
        private Button button68;
        private TextBox textBox_ServerActive;
        private TextBox textBox_SetPSUOutput;
        private Button button69;
        private Button button_Ping;
        private CheckBox checkBox_ServerRecord;
        private CheckBox checkBox_ServerPause;
        private TextBox textBox_SetDCAWithBusMode;
        private Button button87;
        private TextBox textBox_SetVVAAtt;
        private Button button88;
        private TextBox textBox_SetSystemMode;
        private Button button89;
        private TextBox textBox_MinXAxis;
        private TextBox textBox_MaxXAxis;
        private Label label37;
        private Button button97;
        private Button button99;
        private GroupBox groupBox41;
        private TextBox textBox_SentChecksum;
        private Label label48;
        private Label label42;
        private TextBox textBox_SentDataLength;
        private Label label43;
        private Label label44;
        private Label label45;
        private TextBox textBox_SentPreamble;
        private TextBox textBox_SentOpcode;
        private TextBox textBox_SentData;
        private Label label46;
        private Label label47;
        private TextBox textBox_RxClientCheckSum;
        private Label label41;
        private CheckedListBox checkedListBox_PhoneBook;
        private Button button_AddContact;
        private Button button_RemoveContact;
        private Button button_ExportToXML;
        private Button button_ImportToXML;
        private Button button33;
        private RichTextBox richTextBox_ContactDetails;
        private Button button34;
        private RichTextBox richTextBox_TextSendSMS;
        private Button button_SendAllCheckedSMS;
        private Button button_SendSelectedSMS;
        private Label label_SMSSendCharacters;
        private CheckBox checkBox1;
        private CheckBox checkBox_SendSMSAsIs;
        private CheckBox checkBox_SMSencrypted;
        private GroupBox GrooupBox_Encryption;
        private TextBox textBox_UnitIDForSMS;
        private Label label2;
        private TextBox textBox_CodeArrayForSMS;
        private Label label5;
        private Button button_Ring;
        private RichTextBox richTextBox_ModemStatus;
        private ComboBox comboBox_ComportSMS;
        private Button button36;
        private CheckBox checkBox_OpenPortSMS;
        private CheckBox checkBox_DebugSMS;
        private Button button_ClearSMSConsole;
        private CheckBox checkBox_PauseSMSConsole;
        private CheckBox checkBox_RecordSMSConsole;
        private RichTextBox richTextBox_SMSConsole;
        private Button button41;
        private Button button40;
        private Button button39;
        private Button button38;
        private Button button37;
        private ListBox listBox_SMSCommands;
        private GroupBox groupBox42;
        private RadioButton radioButton_TCPIP;
        private RadioButton radioButton_SerialPort;
        private Button button_SendProtocolSerialPort;
        private Button button108;
        private Button button109;
        private Button button47;
        private Button button48;
        private TextBox textBox16;
        private Button button117;
        private Button button116;
        private TextBox textBox15;
        private Button button115;
        private Button button114;
        private TextBox textBox14;
        private Button button113;
        private TextBox textBox13;
        private Button button112;
        private TextBox textBox12;
        private Button button111;
        private TextBox textBox_RFGenParms;
        private Button button_SetRFGen;
        private TextBox textBox10;
        private Button button58;
        private TextBox textBox_PulseGenParms;
        private Button button_GPparms;
        private TextBox textBox8;
        private Button button56;
        private TextBox textBox7;
        private Button button55;
        private TextBox textBox6;
        private Button button54;
        private TextBox textBox5;
        private Button button53;
        private TextBox textBox4;
        private Button button51;
        private Button button50;
        private TextBox textBox3;
        private Button button49;
        private TextBox textBox_TxInhibit;
        private TextBox textBox22;
        private Button button122;
        private TextBox textBox21;
        private Button button121;
        private TextBox textBox20;
        private Button button120;
        private TextBox textBox19;
        private Button button119;
        private TextBox textBox_ControlCal;
        private Button button118;
        private TextBox textBox17;
        private Button button_WriteCatalinas;
        private RichTextBox textBox_FilesToWriteForTheCatalinas;
        private RichTextBox richTextBox_SyntisazerL1;
        private RichTextBox richTextBox_SyntisazerL2;
        private ComboBox comboBox1;
        private Label label20;
        private Label label21;
        private Label label22;
        private ComboBox comboBox_SystemType;
        private Button button_WriteSystemType;
        private Button button_SynthL1;
        private Button button_WriteAllToFlash;
        private Button button_SynthL2;
        private ProgressBar progressBar_WriteToFlash;
        private TabPage tabPage3;
        private GroupBox groupBox43;
        private TabControl tabControl1;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private GroupBox groupBox45;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        private TextBox textBox27;
        private TextBox textBox26;
        private TextBox textBox25;
        private TextBox textBox24;
        private Label label25;
        private GroupBox groupBox44;
        private Button button70;
        private Label label27;
        private Label label26;
        private Label label19;
        private GroupBox groupBox46;
        private Label label38;
        private Label label34;
        private Label label35;
        private TextBox textBox29;
        private TextBox textBox30;
        private TextBox textBox31;
        private Label label36;
        private Button button71;
        private GroupBox groupBox47;
        private Button button72;
        private Label label56;
        private TextBox textBox_StatusUUT12;
        private Label label57;
        private TextBox textBox_StatusUUT22;
        private Label label58;
        private TextBox textBox_StatusUUT21;
        private Label label59;
        private TextBox textBox_StatusUUT20;
        private Label label60;
        private TextBox textBox_StatusUUT19;
        private Label label61;
        private TextBox textBox_StatusUUT18;
        private Label label62;
        private TextBox textBox_StatusUUT17;
        private Label label63;
        private TextBox textBox_StatusUUT16;
        private Label label64;
        private TextBox textBox_StatusUUT15;
        private Label label65;
        private TextBox textBox_StatusUUT14;
        private Label label66;
        private TextBox textBox_StatusUUT13;
        private Label label55;
        private TextBox textBox_StatusUUT1;
        private Label label54;
        private TextBox textBox_StatusUUT11;
        private Label label53;
        private TextBox textBox_StatusUUT10;
        private Label label52;
        private TextBox textBox_StatusUUT9;
        private Label label51;
        private TextBox textBox_StatusUUT8;
        private Label label50;
        private TextBox textBox_StatusUUT7;
        private Label label49;
        private TextBox textBox_StatusUUT6;
        private Label label40;
        private TextBox textBox_StatusUUT5;
        private Label label39;
        private TextBox textBox_StatusUUT4;
        private Label label33;
        private TextBox textBox_StatusUUT3;
        private Label label32;
        private TextBox textBox_StatusUUT2;
        private Label label70;
        private Label label67;
        private TextBox textBox_StatusUUT24;
        private TextBox textBox_StatusUUT26;
        private Label label69;
        private TextBox textBox_StatusUUT25;
        private Label label74;
        private TextBox textBox60;
        private Label label73;
        private TextBox textBox59;
        private Label label68;
        private Label label71;
        private TextBox textBox56;
        private TextBox textBox57;
        private Label label72;
        private TextBox textBox58;
        private TabPage tabPage13;
        private Button button30;
        private Button button2;
        private Label label75;
        private DataGridView dataGridView_DC4;
        private Label label76;
        private DataGridView dataGridView_OverUnder;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Column3;
        private Label label82;
        private TextBox textBox66;
        private Label label78;
        private TextBox textBox62;
        private Label label77;
        private TextBox textBox61;
        private Label label89;
        private DataGridView dataGridView_VVAOffset1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private Label label88;
        private DataGridView dataGridView_VVAOffset2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private Label label87;
        private Label label86;
        private DataGridView dataGridView_PAVVA;
        private Label label92;
        private DataGridView dataGridView10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private Label label91;
        private DataGridView dataGridView9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private Label label90;
        private DataGridView dataGridView8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private GroupBox groupBox33;
        private Button button32;
        private TextBox textBox_RFDelay;
        private Label label100;
        private TextBox textBox_RFPeriod;
        private Label label99;
        private TextBox textBox_RFWidth;
        private Label label98;
        private GroupBox groupBox1;
        private Label label97;
        private TextBox textBox_SimulatorSN;
        private Label label96;
        private TextBox textBox_SimulatorID;
        private Button button31;
        private Label label93;
        private Label label94;
        private TextBox textBox_SimulatorFWVersion;
        private TextBox textBox_SimulatorHWVersion;
        private Label label95;
        private GroupBox groupBox37;
        private Button button73;
        private Label label114;
        private Label label113;
        private Label label112;
        private TextBox textBox85;
        private Label label111;
        private Label label110;
        private TextBox textBox82;
        private Label label107;
        private TextBox textBox83;
        private Label label108;
        private TextBox textBox84;
        private Label label109;
        private GroupBox groupBox35;
        private Button button44;
        private TextBox textBox_PulseDelay2;
        private Label label104;
        private TextBox textBox_PulsePeriod2;
        private Label label105;
        private TextBox textBox_PulseWidth2;
        private Label label106;
        private GroupBox groupBox34;
        private Button button42;
        private TextBox textBox_PulseDelay;
        private Label label101;
        private TextBox textBox_PulsePeriod;
        private Label label102;
        private TextBox textBox_PulseWidth;
        private Label label103;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private Button button75;
        private GroupBox groupBox39;
        private Label label120;
        private TextBox textBox_StatusUUT23;
        private TextBox textBox2;
        private TextBox textBox1;
        private ToolTip toolTip1;
        private CheckBox checkBox6;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private Label label115;
        private TextBox textBox9;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox9;
        private CheckBox checkBox2;
        private Label label81;
        private Label label117;
        private Label label116;
        private DataGridView dataGridView_Page1_4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridView dataGridView_ValPage0;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
        private DataGridViewTextBoxColumn Column17;
        private DataGridViewTextBoxColumn Column18;
        private DataGridViewTextBoxColumn Column19;
        private DataGridViewTextBoxColumn Column20;
        private DataGridViewTextBoxColumn Column21;
        private Button button57;
        private GroupBox groupBox48;
        private Button button6;
        private Button button29;
        private GroupBox groupBox38;
        static readonly string PREAMBLE = "23";
        //bool m_Exit = false;

        ///// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        ///// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        ///// <returns> Returns an array of bytes. </returns>
        //private byte[] HexStringToByteArray(string s)
        //{
        //    s = s.Replace(" ", "");
        //    byte[] buffer = new byte[s.Length / 2];
        //    for (int i = 0; i < s.Length; i += 2)
        //    {
        //        buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
        //    }
        //    return buffer;
        //}

        ///// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        ///// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        ///// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        //private string ByteArrayToHexString(byte[] data)
        //{
        //    StringBuilder sb = new StringBuilder(data.Length * 3);
        //    foreach (byte b in data)
        //    {
        //        if (b == 0)
        //        {
        //            //sb.Append("00 ");
        //        }
        //        else
        //        {
        //            sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
        //        }
        //    }
        //    return sb.ToString().ToUpper();
        //}


        class LogClass
        {
            public string Msg { get; set; }
            public Color Log_Color { get; set; }
            public Color Log_TextBackgroundColor { get; set; }
        }







        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            try
            {
                //if( disposing )
                //{
                //    //if (components != null) 
                //    //{
                //    //    components.Dispose();
                //    //}
                //}

                base.Dispose(disposing);

                //if (this.tcpListener != null)
                //{
                //    //this.tcpListener.Server.Disconnect(false);
                //    if (this.clientStream != null)
                //    {
                //        this.clientStream.Close();
                //    }
                //    this.tcpListener.Server.Close();
                //    this.tcpListener.Stop();

                //}

                //if (listenThread != null)
                //{
                //    listenThread.Abort();
                //    m_Exit = true;

                //}

                if (m_Server != null)
                {
                    m_Server.Close_Server();
                }


            }
            catch
            {
            }


        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox_ServerSettings = new System.Windows.Forms.GroupBox();
            this.textBox_ServerOpen = new System.Windows.Forms.TextBox();
            this.textBox_ServerActive = new System.Windows.Forms.TextBox();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.textBox_NumberOfOpenConnections = new System.Windows.Forms.TextBox();
            this.ListenBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_ConnectionNumber = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDataTx = new System.Windows.Forms.TextBox();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_charts = new System.Windows.Forms.TabPage();
            this.button99 = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox_MaxXAxis = new System.Windows.Forms.TextBox();
            this.textBox_MinXAxis = new System.Windows.Forms.TextBox();
            this.comboBox_ChartUpdateTime = new System.Windows.Forms.ComboBox();
            this.button28 = new System.Windows.Forms.Button();
            this.listBox_Charts = new System.Windows.Forms.ListBox();
            this.button_OpenFolder2 = new System.Windows.Forms.Button();
            this.button_GraphPause = new System.Windows.Forms.Button();
            this.Button_Export_excel = new System.Windows.Forms.Button();
            this.button_ResetGraphs = new System.Windows.Forms.Button();
            this.textBox_graph_XY = new System.Windows.Forms.TextBox();
            this.button_ScreenShot = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage_ServerTCP = new System.Windows.Forms.TabPage();
            this.checkBox_ParseMessages = new System.Windows.Forms.CheckBox();
            this.textBox_IDKey = new System.Windows.Forms.RichTextBox();
            this.groupBox_FOTA = new System.Windows.Forms.GroupBox();
            this.button_StartFOTAProcess = new System.Windows.Forms.Button();
            this.textBox_TotalFileLength = new System.Windows.Forms.TextBox();
            this.textBox_MaximumNumberReceivedRequest = new System.Windows.Forms.RichTextBox();
            this.button35 = new System.Windows.Forms.Button();
            this.button_StartFOTA = new System.Windows.Forms.Button();
            this.textBox_TotalFrames1280Bytes = new System.Windows.Forms.TextBox();
            this.textBox_FOTA = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox_EchoResponse = new System.Windows.Forms.CheckBox();
            this.groupBox_ConnectionTimedOut = new System.Windows.Forms.GroupBox();
            this.textBox_CurrentTimeOut = new System.Windows.Forms.TextBox();
            this.button_SetTimedOut = new System.Windows.Forms.Button();
            this.textBox_ConnectionTimedOut = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_ServerRecord = new System.Windows.Forms.CheckBox();
            this.checkBox_ServerPause = new System.Windows.Forms.CheckBox();
            this.button_ClearServer = new System.Windows.Forms.Button();
            this.checkBox_StopLogging = new System.Windows.Forms.CheckBox();
            this.TextBox_Server = new System.Windows.Forms.RichTextBox();
            this.checkBox_RecordGeneral = new System.Windows.Forms.CheckBox();
            this.PauseCheck = new System.Windows.Forms.CheckBox();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.tabPage_ClientTCP = new System.Windows.Forms.TabPage();
            this.button_Ping = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_ClearRx = new System.Windows.Forms.Button();
            this.richTextBox_ClientRx = new System.Windows.Forms.RichTextBox();
            this.button43 = new System.Windows.Forms.Button();
            this.button_ClientClose = new System.Windows.Forms.Button();
            this.button_ClientConnect = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox_ClientTx = new System.Windows.Forms.RichTextBox();
            this.textBox_ClientPort = new System.Windows.Forms.TextBox();
            this.textBox_ClientIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage_SerialPort = new System.Windows.Forms.TabPage();
            this.groupBox_SendSerialOrMonitorCommands = new System.Windows.Forms.GroupBox();
            this.checkBox_SendHexdata = new System.Windows.Forms.CheckBox();
            this.textBox_SendSerialPort = new System.Windows.Forms.TextBox();
            this.checkBox_DeleteCommand = new System.Windows.Forms.CheckBox();
            this.button_SendSerialPort = new System.Windows.Forms.Button();
            this.gbPortSettings = new System.Windows.Forms.GroupBox();
            this.button_OpenPort = new System.Windows.Forms.Button();
            this.button_ReScanComPort = new System.Windows.Forms.Button();
            this.cmb_PortName = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmb_StopBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox_Timer = new System.Windows.Forms.GroupBox();
            this.textBox_TimerTime = new System.Windows.Forms.TextBox();
            this.button_StartStopTimer = new System.Windows.Forms.Button();
            this.button_ResetTimer = new System.Windows.Forms.Button();
            this.textBox_SetTimerTime = new System.Windows.Forms.TextBox();
            this.groupBox_Stopwatch = new System.Windows.Forms.GroupBox();
            this.button_TimerLog = new System.Windows.Forms.Button();
            this.button_Stopwatch_Start_Stop = new System.Windows.Forms.Button();
            this.button_StopwatchReset = new System.Windows.Forms.Button();
            this.textBox_StopWatch = new System.Windows.Forms.TextBox();
            this.checkBox_RxHex = new System.Windows.Forms.CheckBox();
            this.textBox_SerialPortRecognizePattern3 = new System.Windows.Forms.TextBox();
            this.textBox_SerialPortRecognizePattern2 = new System.Windows.Forms.TextBox();
            this.textBox_SerialPortRecognizePattern = new System.Windows.Forms.TextBox();
            this.checkBox_S1RecordLog = new System.Windows.Forms.CheckBox();
            this.checkBox_S1Pause = new System.Windows.Forms.CheckBox();
            this.txtS1_Clear = new System.Windows.Forms.Button();
            this.SerialPortLogger_TextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage_GenericFrame = new System.Windows.Forms.TabPage();
            this.button52 = new System.Windows.Forms.Button();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.textBox_RxClientCheckSum = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.textBox_RxClientDataLength = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_RxClientPreamble = new System.Windows.Forms.TextBox();
            this.textBox_RxClientOpcode = new System.Windows.Forms.TextBox();
            this.textBox_RxClientData = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox_clientTX = new System.Windows.Forms.GroupBox();
            this.button_SendProtocolSerialPort = new System.Windows.Forms.Button();
            this.groupBox41 = new System.Windows.Forms.GroupBox();
            this.textBox_SentChecksum = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.textBox_SentDataLength = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.textBox_SentPreamble = new System.Windows.Forms.TextBox();
            this.textBox_SentOpcode = new System.Windows.Forms.TextBox();
            this.textBox_SentData = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Preamble = new System.Windows.Forms.TextBox();
            this.button_SendProtocolTCPIP = new System.Windows.Forms.Button();
            this.textBox_Opcode = new System.Windows.Forms.TextBox();
            this.textBox_data = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage_Commands = new System.Windows.Forms.TabPage();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.tabControl_System = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.button117 = new System.Windows.Forms.Button();
            this.button116 = new System.Windows.Forms.Button();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.button115 = new System.Windows.Forms.Button();
            this.button114 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.button113 = new System.Windows.Forms.Button();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.button112 = new System.Windows.Forms.Button();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button111 = new System.Windows.Forms.Button();
            this.textBox_RFGenParms = new System.Windows.Forms.TextBox();
            this.button_SetRFGen = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button58 = new System.Windows.Forms.Button();
            this.textBox_PulseGenParms = new System.Windows.Forms.TextBox();
            this.button_GPparms = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button56 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button55 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button54 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button53 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button51 = new System.Windows.Forms.Button();
            this.button50 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button49 = new System.Windows.Forms.Button();
            this.textBox_TxInhibit = new System.Windows.Forms.TextBox();
            this.button47 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.button108 = new System.Windows.Forms.Button();
            this.button109 = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.button46 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.button122 = new System.Windows.Forms.Button();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.button121 = new System.Windows.Forms.Button();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.button120 = new System.Windows.Forms.Button();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.button119 = new System.Windows.Forms.Button();
            this.textBox_ControlCal = new System.Windows.Forms.TextBox();
            this.button118 = new System.Windows.Forms.Button();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox_SetSystemMode = new System.Windows.Forms.TextBox();
            this.button89 = new System.Windows.Forms.Button();
            this.textBox_SetDCAWithBusMode = new System.Windows.Forms.TextBox();
            this.button87 = new System.Windows.Forms.Button();
            this.textBox_SetVVAAtt = new System.Windows.Forms.TextBox();
            this.button88 = new System.Windows.Forms.Button();
            this.textBox_SetPSUOutput = new System.Windows.Forms.TextBox();
            this.button69 = new System.Windows.Forms.Button();
            this.button68 = new System.Windows.Forms.Button();
            this.button67 = new System.Windows.Forms.Button();
            this.button66 = new System.Windows.Forms.Button();
            this.button65 = new System.Windows.Forms.Button();
            this.textBox_SetADCMode = new System.Windows.Forms.TextBox();
            this.button64 = new System.Windows.Forms.Button();
            this.button63 = new System.Windows.Forms.Button();
            this.button62 = new System.Windows.Forms.Button();
            this.button61 = new System.Windows.Forms.Button();
            this.button60 = new System.Windows.Forms.Button();
            this.button59 = new System.Windows.Forms.Button();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.richTextBox_SSPA = new System.Windows.Forms.RichTextBox();
            this.checkBox_RecordMiniAda = new System.Windows.Forms.CheckBox();
            this.checkBox_PauseMiniAda = new System.Windows.Forms.CheckBox();
            this.button_ClearMiniAda = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox43 = new System.Windows.Forms.GroupBox();
            this.button30 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button73 = new System.Windows.Forms.Button();
            this.label114 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.textBox85 = new System.Windows.Forms.TextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.textBox82 = new System.Windows.Forms.TextBox();
            this.label107 = new System.Windows.Forms.Label();
            this.textBox83 = new System.Windows.Forms.TextBox();
            this.label108 = new System.Windows.Forms.Label();
            this.textBox84 = new System.Windows.Forms.TextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.button71 = new System.Windows.Forms.Button();
            this.groupBox47 = new System.Windows.Forms.GroupBox();
            this.button72 = new System.Windows.Forms.Button();
            this.textBox_StatusUUT25 = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT26 = new System.Windows.Forms.TextBox();
            this.textBox_StatusUUT23 = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT24 = new System.Windows.Forms.TextBox();
            this.textBox_StatusUUT12 = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT22 = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT21 = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT20 = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT19 = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT18 = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT17 = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT16 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT15 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT14 = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT13 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT1 = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT11 = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT10 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT9 = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT8 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT7 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT6 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT5 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT4 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT3 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox_StatusUUT2 = new System.Windows.Forms.TextBox();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.label115 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.textBox60 = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.textBox59 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.textBox58 = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.textBox56 = new System.Windows.Forms.TextBox();
            this.textBox57 = new System.Windows.Forms.TextBox();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.button44 = new System.Windows.Forms.Button();
            this.textBox_PulseDelay2 = new System.Windows.Forms.TextBox();
            this.label104 = new System.Windows.Forms.Label();
            this.textBox_PulsePeriod2 = new System.Windows.Forms.TextBox();
            this.label105 = new System.Windows.Forms.Label();
            this.textBox_PulseWidth2 = new System.Windows.Forms.TextBox();
            this.label106 = new System.Windows.Forms.Label();
            this.groupBox46 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox45 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.button42 = new System.Windows.Forms.Button();
            this.textBox_PulseDelay = new System.Windows.Forms.TextBox();
            this.label101 = new System.Windows.Forms.Label();
            this.textBox_PulsePeriod = new System.Windows.Forms.TextBox();
            this.label102 = new System.Windows.Forms.Label();
            this.textBox_PulseWidth = new System.Windows.Forms.TextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.groupBox44 = new System.Windows.Forms.GroupBox();
            this.button57 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button70 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button75 = new System.Windows.Forms.Button();
            this.label97 = new System.Windows.Forms.Label();
            this.textBox_SimulatorSN = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.textBox_SimulatorID = new System.Windows.Forms.TextBox();
            this.button31 = new System.Windows.Forms.Button();
            this.label93 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.textBox_SimulatorFWVersion = new System.Windows.Forms.TextBox();
            this.textBox_SimulatorHWVersion = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button32 = new System.Windows.Forms.Button();
            this.textBox_RFDelay = new System.Windows.Forms.TextBox();
            this.label100 = new System.Windows.Forms.Label();
            this.textBox_RFPeriod = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.textBox_RFWidth = new System.Windows.Forms.TextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.dataGridView_ValPage0 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label81 = new System.Windows.Forms.Label();
            this.dataGridView_OverUnder = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label82 = new System.Windows.Forms.Label();
            this.textBox66 = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.textBox62 = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.textBox61 = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label117 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.dataGridView_Page1_4 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.label89 = new System.Windows.Forms.Label();
            this.dataGridView_VVAOffset1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label88 = new System.Windows.Forms.Label();
            this.dataGridView_VVAOffset2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label87 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.dataGridView_PAVVA = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.dataGridView_DC4 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label92 = new System.Windows.Forms.Label();
            this.dataGridView10 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label91 = new System.Windows.Forms.Label();
            this.dataGridView9 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label90 = new System.Windows.Forms.Label();
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox42 = new System.Windows.Forms.GroupBox();
            this.radioButton_TCPIP = new System.Windows.Forms.RadioButton();
            this.radioButton_SerialPort = new System.Windows.Forms.RadioButton();
            this.button_OpenFolder = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.S1_Configuration = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.TextBox_Odometer = new System.Windows.Forms.TextBox();
            this.button19 = new System.Windows.Forms.Button();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.textBox_ModemSocket = new System.Windows.Forms.TextBox();
            this.textBox_ModemRetries = new System.Windows.Forms.TextBox();
            this.textBox_ModemTimeOut = new System.Windows.Forms.TextBox();
            this.button25 = new System.Windows.Forms.Button();
            this.textBox_ModemPrimeryPort = new System.Windows.Forms.TextBox();
            this.textBox_ModemPrimeryHost = new System.Windows.Forms.TextBox();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.textBox_ForginPassword = new System.Windows.Forms.TextBox();
            this.button27 = new System.Windows.Forms.Button();
            this.textBox_ForginAcessPoint = new System.Windows.Forms.TextBox();
            this.textBox_ForginSecondaryDNS = new System.Windows.Forms.TextBox();
            this.textBox_ForginUserName = new System.Windows.Forms.TextBox();
            this.textBox_ForginPrimeryDNS = new System.Windows.Forms.TextBox();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.textBox_HomePassword = new System.Windows.Forms.TextBox();
            this.button26 = new System.Windows.Forms.Button();
            this.textBox_HomeAcessPoint = new System.Windows.Forms.TextBox();
            this.textBox_HomeSecondaryDNS = new System.Windows.Forms.TextBox();
            this.textBox_HomeUserName = new System.Windows.Forms.TextBox();
            this.textBox_HomePrimeryDNS = new System.Windows.Forms.TextBox();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.TextBox();
            this.button24 = new System.Windows.Forms.Button();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.TextBox_NormalStatusDuration = new System.Windows.Forms.TextBox();
            this.button23 = new System.Windows.Forms.Button();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_SpeedLimit2 = new System.Windows.Forms.TextBox();
            this.maskedTextBox_SpeedLimit3 = new System.Windows.Forms.TextBox();
            this.maskedTextBox_SpeedLimit1 = new System.Windows.Forms.TextBox();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.comboBox_DispatchSpeed = new System.Windows.Forms.ComboBox();
            this.button21 = new System.Windows.Forms.Button();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.comboBox_KillEngine = new System.Windows.Forms.ComboBox();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TiltTowSens = new System.Windows.Forms.TextBox();
            this.comboBox_TiltTowSensState = new System.Windows.Forms.ComboBox();
            this.button18 = new System.Windows.Forms.Button();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_HitSensitivity = new System.Windows.Forms.TextBox();
            this.comboBox_HitState = new System.Windows.Forms.ComboBox();
            this.button17 = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_ShockDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_ShockWindow = new System.Windows.Forms.TextBox();
            this.comboBox_ShockState = new System.Windows.Forms.ComboBox();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TiltDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TiltWindow = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TiltAngle = new System.Windows.Forms.TextBox();
            this.comboBox1_TiltState = new System.Windows.Forms.ComboBox();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TowDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TowWindow = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TowAngle = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.comboBox_SleepPolicy = new System.Windows.Forms.ComboBox();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox_AlarmPilicy = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_SetTimeDate = new System.Windows.Forms.DateTimePicker();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox_BatThreshold = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_OutputDuration = new System.Windows.Forms.TextBox();
            this.comboBox_OutputNum = new System.Windows.Forms.ComboBox();
            this.comboBox_OutputControl = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox_OutputPulseLevel = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_InputDuration = new System.Windows.Forms.TextBox();
            this.comboBox_InputNum1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Interupt = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.textBox_NewPassword = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.comboBox_SMSControl = new System.Windows.Forms.ComboBox();
            this.button_SMSControl = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.textBox_FreeText = new System.Windows.Forms.TextBox();
            this.comboBox_InputIndex = new System.Windows.Forms.ComboBox();
            this.button_SetFreeText = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox3_Subscriber3 = new System.Windows.Forms.TextBox();
            this.maskedTextBox2_Subscriber2 = new System.Windows.Forms.TextBox();
            this.maskedTextBox1_Subscriber1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox_SMSPhoneNumber = new System.Windows.Forms.TextBox();
            this.button_SendAllCheckedSMS = new System.Windows.Forms.Button();
            this.button_SendSelectedSMS = new System.Windows.Forms.Button();
            this.button_Ring = new System.Windows.Forms.Button();
            this.comboBox_SystemType = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer_General_100ms = new System.Windows.Forms.Timer(this.components);
            this.timer_General_1Second = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.groupBox_PhoneNumber = new System.Windows.Forms.GroupBox();
            this.Label_SerialPortRx = new System.Windows.Forms.Label();
            this.label_SerialPortConnected = new System.Windows.Forms.Label();
            this.Label_SerialPortTx = new System.Windows.Forms.Label();
            this.groupBox_SerialPort = new System.Windows.Forms.GroupBox();
            this.label_SerialPortStatus = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button97 = new System.Windows.Forms.Button();
            this.textBox_SystemStatus = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_ClentTCPStatus = new System.Windows.Forms.GroupBox();
            this.label_TCPClient = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_ClientTCPConnected = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkedListBox_PhoneBook = new System.Windows.Forms.CheckedListBox();
            this.button_AddContact = new System.Windows.Forms.Button();
            this.button_RemoveContact = new System.Windows.Forms.Button();
            this.button_ExportToXML = new System.Windows.Forms.Button();
            this.button_ImportToXML = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.richTextBox_ContactDetails = new System.Windows.Forms.RichTextBox();
            this.button34 = new System.Windows.Forms.Button();
            this.richTextBox_TextSendSMS = new System.Windows.Forms.RichTextBox();
            this.label_SMSSendCharacters = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox_SendSMSAsIs = new System.Windows.Forms.CheckBox();
            this.checkBox_SMSencrypted = new System.Windows.Forms.CheckBox();
            this.GrooupBox_Encryption = new System.Windows.Forms.GroupBox();
            this.textBox_UnitIDForSMS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_CodeArrayForSMS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox_ModemStatus = new System.Windows.Forms.RichTextBox();
            this.comboBox_ComportSMS = new System.Windows.Forms.ComboBox();
            this.button36 = new System.Windows.Forms.Button();
            this.checkBox_OpenPortSMS = new System.Windows.Forms.CheckBox();
            this.checkBox_DebugSMS = new System.Windows.Forms.CheckBox();
            this.button_ClearSMSConsole = new System.Windows.Forms.Button();
            this.checkBox_PauseSMSConsole = new System.Windows.Forms.CheckBox();
            this.checkBox_RecordSMSConsole = new System.Windows.Forms.CheckBox();
            this.richTextBox_SMSConsole = new System.Windows.Forms.RichTextBox();
            this.button41 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.listBox_SMSCommands = new System.Windows.Forms.ListBox();
            this.button_WriteCatalinas = new System.Windows.Forms.Button();
            this.textBox_FilesToWriteForTheCatalinas = new System.Windows.Forms.RichTextBox();
            this.richTextBox_SyntisazerL1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox_SyntisazerL2 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button_WriteSystemType = new System.Windows.Forms.Button();
            this.button_SynthL1 = new System.Windows.Forms.Button();
            this.button_WriteAllToFlash = new System.Windows.Forms.Button();
            this.button_SynthL2 = new System.Windows.Forms.Button();
            this.progressBar_WriteToFlash = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.groupBox48 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.groupBox_ServerSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_charts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage_ServerTCP.SuspendLayout();
            this.groupBox_FOTA.SuspendLayout();
            this.groupBox_ConnectionTimedOut.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage_ClientTCP.SuspendLayout();
            this.tabPage_SerialPort.SuspendLayout();
            this.groupBox_SendSerialOrMonitorCommands.SuspendLayout();
            this.gbPortSettings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox_Timer.SuspendLayout();
            this.groupBox_Stopwatch.SuspendLayout();
            this.tabPage_GenericFrame.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox_clientTX.SuspendLayout();
            this.groupBox41.SuspendLayout();
            this.tabPage_Commands.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.tabControl_System.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox43.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox47.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox46.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.groupBox44.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ValPage0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OverUnder)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Page1_4)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VVAOffset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VVAOffset2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PAVVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DC4)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            this.groupBox42.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.S1_Configuration.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox_PhoneNumber.SuspendLayout();
            this.groupBox_SerialPort.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_ClentTCPStatus.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_ServerSettings
            // 
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ServerOpen);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ServerActive);
            this.groupBox_ServerSettings.Controls.Add(this.txtPortNo);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_NumberOfOpenConnections);
            this.groupBox_ServerSettings.Controls.Add(this.ListenBox);
            this.groupBox_ServerSettings.Controls.Add(this.label1);
            this.groupBox_ServerSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ServerSettings.Location = new System.Drawing.Point(6, 3);
            this.groupBox_ServerSettings.Name = "groupBox_ServerSettings";
            this.groupBox_ServerSettings.Size = new System.Drawing.Size(414, 58);
            this.groupBox_ServerSettings.TabIndex = 0;
            this.groupBox_ServerSettings.TabStop = false;
            this.groupBox_ServerSettings.Text = "Server Settings";
            // 
            // textBox_ServerOpen
            // 
            this.textBox_ServerOpen.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ServerOpen.ForeColor = System.Drawing.Color.White;
            this.textBox_ServerOpen.Location = new System.Drawing.Point(276, 17);
            this.textBox_ServerOpen.Multiline = true;
            this.textBox_ServerOpen.Name = "textBox_ServerOpen";
            this.textBox_ServerOpen.ReadOnly = true;
            this.textBox_ServerOpen.Size = new System.Drawing.Size(89, 25);
            this.textBox_ServerOpen.TabIndex = 7;
            this.textBox_ServerOpen.Text = "Connected";
            // 
            // textBox_ServerActive
            // 
            this.textBox_ServerActive.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ServerActive.ForeColor = System.Drawing.Color.White;
            this.textBox_ServerActive.Location = new System.Drawing.Point(210, 17);
            this.textBox_ServerActive.Multiline = true;
            this.textBox_ServerActive.Name = "textBox_ServerActive";
            this.textBox_ServerActive.ReadOnly = true;
            this.textBox_ServerActive.Size = new System.Drawing.Size(60, 25);
            this.textBox_ServerActive.TabIndex = 6;
            this.textBox_ServerActive.Text = "Active";
            // 
            // txtPortNo
            // 
            this.txtPortNo.Location = new System.Drawing.Point(86, 16);
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Size = new System.Drawing.Size(40, 23);
            this.txtPortNo.TabIndex = 1;
            this.txtPortNo.Text = "7000";
            this.txtPortNo.TextChanged += new System.EventHandler(this.TxtPortNo_TextChanged);
            // 
            // textBox_NumberOfOpenConnections
            // 
            this.textBox_NumberOfOpenConnections.ForeColor = System.Drawing.Color.White;
            this.textBox_NumberOfOpenConnections.Location = new System.Drawing.Point(371, 17);
            this.textBox_NumberOfOpenConnections.Name = "textBox_NumberOfOpenConnections";
            this.textBox_NumberOfOpenConnections.ReadOnly = true;
            this.textBox_NumberOfOpenConnections.Size = new System.Drawing.Size(25, 23);
            this.textBox_NumberOfOpenConnections.TabIndex = 5;
            this.textBox_NumberOfOpenConnections.TextChanged += new System.EventHandler(this.TextBox_NumberOfOpenConnections_TextChanged);
            // 
            // ListenBox
            // 
            this.ListenBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ListenBox.AutoSize = true;
            this.ListenBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenBox.Location = new System.Drawing.Point(132, 15);
            this.ListenBox.Name = "ListenBox";
            this.ListenBox.Size = new System.Drawing.Size(74, 28);
            this.ListenBox.TabIndex = 4;
            this.ListenBox.Text = "Listening";
            this.ListenBox.UseVisualStyleBackColor = true;
            this.ListenBox.CheckedChanged += new System.EventHandler(this.ListenBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Number:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_ConnectionNumber);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtDataTx);
            this.groupBox2.Location = new System.Drawing.Point(3, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 217);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Data";
            // 
            // comboBox_ConnectionNumber
            // 
            this.comboBox_ConnectionNumber.FormattingEnabled = true;
            this.comboBox_ConnectionNumber.Location = new System.Drawing.Point(84, 188);
            this.comboBox_ConnectionNumber.Name = "comboBox_ConnectionNumber";
            this.comboBox_ConnectionNumber.Size = new System.Drawing.Size(170, 26);
            this.comboBox_ConnectionNumber.TabIndex = 2;
            this.comboBox_ConnectionNumber.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(14, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtDataTx
            // 
            this.txtDataTx.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDataTx.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataTx.Location = new System.Drawing.Point(14, 19);
            this.txtDataTx.Multiline = true;
            this.txtDataTx.Name = "txtDataTx";
            this.txtDataTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataTx.Size = new System.Drawing.Size(257, 162);
            this.txtDataTx.TabIndex = 0;
            this.txtDataTx.TextChanged += new System.EventHandler(this.TxtDataTx_TextChanged);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_charts);
            this.tabControl_Main.Controls.Add(this.tabPage_ServerTCP);
            this.tabControl_Main.Controls.Add(this.tabPage_ClientTCP);
            this.tabControl_Main.Controls.Add(this.tabPage_SerialPort);
            this.tabControl_Main.Controls.Add(this.tabPage_GenericFrame);
            this.tabControl_Main.Controls.Add(this.tabPage_Commands);
            this.tabControl_Main.Controls.Add(this.tabPage3);
            this.tabControl_Main.Location = new System.Drawing.Point(4, 5);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1555, 713);
            this.tabControl_Main.TabIndex = 8;
            this.tabControl_Main.TabStop = false;
            this.tabControl_Main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl1_KeyDown);
            // 
            // tabPage_charts
            // 
            this.tabPage_charts.Controls.Add(this.button99);
            this.tabPage_charts.Controls.Add(this.label37);
            this.tabPage_charts.Controls.Add(this.textBox_MaxXAxis);
            this.tabPage_charts.Controls.Add(this.textBox_MinXAxis);
            this.tabPage_charts.Controls.Add(this.comboBox_ChartUpdateTime);
            this.tabPage_charts.Controls.Add(this.button28);
            this.tabPage_charts.Controls.Add(this.listBox_Charts);
            this.tabPage_charts.Controls.Add(this.button_OpenFolder2);
            this.tabPage_charts.Controls.Add(this.button_GraphPause);
            this.tabPage_charts.Controls.Add(this.Button_Export_excel);
            this.tabPage_charts.Controls.Add(this.button_ResetGraphs);
            this.tabPage_charts.Controls.Add(this.textBox_graph_XY);
            this.tabPage_charts.Controls.Add(this.button_ScreenShot);
            this.tabPage_charts.Controls.Add(this.chart1);
            this.tabPage_charts.Location = new System.Drawing.Point(4, 27);
            this.tabPage_charts.Name = "tabPage_charts";
            this.tabPage_charts.Size = new System.Drawing.Size(1547, 682);
            this.tabPage_charts.TabIndex = 7;
            this.tabPage_charts.Text = "Charts";
            this.tabPage_charts.UseVisualStyleBackColor = true;
            // 
            // button99
            // 
            this.button99.Location = new System.Drawing.Point(132, 379);
            this.button99.Name = "button99";
            this.button99.Size = new System.Drawing.Size(45, 23);
            this.button99.TabIndex = 84;
            this.button99.Text = "auto";
            this.button99.UseVisualStyleBackColor = true;
            this.button99.Click += new System.EventHandler(this.button99_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(2, 354);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(102, 18);
            this.label37.TabIndex = 83;
            this.label37.Text = "Min/Max X axis";
            // 
            // textBox_MaxXAxis
            // 
            this.textBox_MaxXAxis.Location = new System.Drawing.Point(61, 378);
            this.textBox_MaxXAxis.Name = "textBox_MaxXAxis";
            this.textBox_MaxXAxis.Size = new System.Drawing.Size(64, 26);
            this.textBox_MaxXAxis.TabIndex = 82;
            this.textBox_MaxXAxis.TextChanged += new System.EventHandler(this.textBox_MaxXAxis_TextChanged);
            // 
            // textBox_MinXAxis
            // 
            this.textBox_MinXAxis.Location = new System.Drawing.Point(3, 378);
            this.textBox_MinXAxis.Name = "textBox_MinXAxis";
            this.textBox_MinXAxis.Size = new System.Drawing.Size(47, 26);
            this.textBox_MinXAxis.TabIndex = 81;
            this.textBox_MinXAxis.TextChanged += new System.EventHandler(this.textBox_MinXAxis_TextChanged);
            // 
            // comboBox_ChartUpdateTime
            // 
            this.comboBox_ChartUpdateTime.FormattingEnabled = true;
            this.comboBox_ChartUpdateTime.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000",
            "10000"});
            this.comboBox_ChartUpdateTime.Location = new System.Drawing.Point(5, 612);
            this.comboBox_ChartUpdateTime.Name = "comboBox_ChartUpdateTime";
            this.comboBox_ChartUpdateTime.Size = new System.Drawing.Size(184, 26);
            this.comboBox_ChartUpdateTime.TabIndex = 80;
            this.comboBox_ChartUpdateTime.Text = "Update time ms";
            this.comboBox_ChartUpdateTime.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ChartUpdateTime_SelectedIndexChanged);
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(3, 555);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(186, 23);
            this.button28.TabIndex = 79;
            this.button28.Text = "Reset X point";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.Button28_Click_2);
            // 
            // listBox_Charts
            // 
            this.listBox_Charts.FormattingEnabled = true;
            this.listBox_Charts.ItemHeight = 18;
            this.listBox_Charts.Location = new System.Drawing.Point(3, 167);
            this.listBox_Charts.Name = "listBox_Charts";
            this.listBox_Charts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Charts.Size = new System.Drawing.Size(184, 184);
            this.listBox_Charts.TabIndex = 78;
            this.listBox_Charts.SelectedIndexChanged += new System.EventHandler(this.ListBox_Charts_SelectedIndexChanged);
            this.listBox_Charts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_Charts_KeyDown);
            this.listBox_Charts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox_Charts_KeyPress);
            // 
            // button_OpenFolder2
            // 
            this.button_OpenFolder2.Location = new System.Drawing.Point(4, 434);
            this.button_OpenFolder2.Name = "button_OpenFolder2";
            this.button_OpenFolder2.Size = new System.Drawing.Size(185, 26);
            this.button_OpenFolder2.TabIndex = 77;
            this.button_OpenFolder2.Text = "Open Local Folder";
            this.button_OpenFolder2.UseVisualStyleBackColor = true;
            this.button_OpenFolder2.Click += new System.EventHandler(this.Button_OpenFolder2_Click);
            // 
            // button_GraphPause
            // 
            this.button_GraphPause.Location = new System.Drawing.Point(3, 583);
            this.button_GraphPause.Name = "button_GraphPause";
            this.button_GraphPause.Size = new System.Drawing.Size(186, 23);
            this.button_GraphPause.TabIndex = 8;
            this.button_GraphPause.Text = "Pause";
            this.button_GraphPause.UseVisualStyleBackColor = true;
            this.button_GraphPause.Click += new System.EventHandler(this.Button_GraphPause_Click);
            // 
            // Button_Export_excel
            // 
            this.Button_Export_excel.Location = new System.Drawing.Point(3, 466);
            this.Button_Export_excel.Name = "Button_Export_excel";
            this.Button_Export_excel.Size = new System.Drawing.Size(186, 23);
            this.Button_Export_excel.TabIndex = 7;
            this.Button_Export_excel.Text = "Export to excel";
            this.Button_Export_excel.UseVisualStyleBackColor = true;
            this.Button_Export_excel.Click += new System.EventHandler(this.Button_Export_excel_Click);
            // 
            // button_ResetGraphs
            // 
            this.button_ResetGraphs.Location = new System.Drawing.Point(3, 525);
            this.button_ResetGraphs.Name = "button_ResetGraphs";
            this.button_ResetGraphs.Size = new System.Drawing.Size(186, 23);
            this.button_ResetGraphs.TabIndex = 6;
            this.button_ResetGraphs.Text = "Reset chart data";
            this.button_ResetGraphs.UseVisualStyleBackColor = true;
            this.button_ResetGraphs.Click += new System.EventHandler(this.Button_ResetGraphs_Click);
            // 
            // textBox_graph_XY
            // 
            this.textBox_graph_XY.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_graph_XY.Location = new System.Drawing.Point(4, 8);
            this.textBox_graph_XY.Multiline = true;
            this.textBox_graph_XY.Name = "textBox_graph_XY";
            this.textBox_graph_XY.ReadOnly = true;
            this.textBox_graph_XY.Size = new System.Drawing.Size(185, 153);
            this.textBox_graph_XY.TabIndex = 4;
            this.textBox_graph_XY.Text = "Message box ";
            this.textBox_graph_XY.TextChanged += new System.EventHandler(this.TextBox_graph_XY_TextChanged);
            // 
            // button_ScreenShot
            // 
            this.button_ScreenShot.Location = new System.Drawing.Point(3, 494);
            this.button_ScreenShot.Name = "button_ScreenShot";
            this.button_ScreenShot.Size = new System.Drawing.Size(186, 23);
            this.button_ScreenShot.TabIndex = 1;
            this.button_ScreenShot.Text = "Take screen shot";
            this.button_ScreenShot.UseVisualStyleBackColor = true;
            this.button_ScreenShot.Click += new System.EventHandler(this.Button_ScreenShot_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "Freq";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Title = "Power [dBm]";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(194, 2);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1350, 665);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseClick);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseMove);
            // 
            // tabPage_ServerTCP
            // 
            this.tabPage_ServerTCP.Controls.Add(this.checkBox_ParseMessages);
            this.tabPage_ServerTCP.Controls.Add(this.textBox_IDKey);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox_FOTA);
            this.tabPage_ServerTCP.Controls.Add(this.checkBox_EchoResponse);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox_ServerSettings);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox_ConnectionTimedOut);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox2);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox3);
            this.tabPage_ServerTCP.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ServerTCP.Name = "tabPage_ServerTCP";
            this.tabPage_ServerTCP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ServerTCP.Size = new System.Drawing.Size(1547, 687);
            this.tabPage_ServerTCP.TabIndex = 0;
            this.tabPage_ServerTCP.Text = "Server TCP";
            this.tabPage_ServerTCP.UseVisualStyleBackColor = true;
            // 
            // checkBox_ParseMessages
            // 
            this.checkBox_ParseMessages.AutoSize = true;
            this.checkBox_ParseMessages.Location = new System.Drawing.Point(116, 343);
            this.checkBox_ParseMessages.Name = "checkBox_ParseMessages";
            this.checkBox_ParseMessages.Size = new System.Drawing.Size(124, 22);
            this.checkBox_ParseMessages.TabIndex = 103;
            this.checkBox_ParseMessages.Text = "Parse messages";
            this.checkBox_ParseMessages.UseVisualStyleBackColor = true;
            this.checkBox_ParseMessages.CheckedChanged += new System.EventHandler(this.CheckBox_ParseMessages_CheckedChanged);
            // 
            // textBox_IDKey
            // 
            this.textBox_IDKey.Location = new System.Drawing.Point(1224, 78);
            this.textBox_IDKey.Name = "textBox_IDKey";
            this.textBox_IDKey.Size = new System.Drawing.Size(317, 152);
            this.textBox_IDKey.TabIndex = 102;
            this.textBox_IDKey.Text = "";
            this.textBox_IDKey.Visible = false;
            // 
            // groupBox_FOTA
            // 
            this.groupBox_FOTA.Controls.Add(this.button_StartFOTAProcess);
            this.groupBox_FOTA.Controls.Add(this.textBox_TotalFileLength);
            this.groupBox_FOTA.Controls.Add(this.textBox_MaximumNumberReceivedRequest);
            this.groupBox_FOTA.Controls.Add(this.button35);
            this.groupBox_FOTA.Controls.Add(this.button_StartFOTA);
            this.groupBox_FOTA.Controls.Add(this.textBox_TotalFrames1280Bytes);
            this.groupBox_FOTA.Controls.Add(this.textBox_FOTA);
            this.groupBox_FOTA.Controls.Add(this.button5);
            this.groupBox_FOTA.Location = new System.Drawing.Point(3, 364);
            this.groupBox_FOTA.Name = "groupBox_FOTA";
            this.groupBox_FOTA.Size = new System.Drawing.Size(268, 213);
            this.groupBox_FOTA.TabIndex = 12;
            this.groupBox_FOTA.TabStop = false;
            this.groupBox_FOTA.Text = "FOTA";
            this.groupBox_FOTA.Visible = false;
            // 
            // button_StartFOTAProcess
            // 
            this.button_StartFOTAProcess.Enabled = false;
            this.button_StartFOTAProcess.Location = new System.Drawing.Point(206, 107);
            this.button_StartFOTAProcess.Name = "button_StartFOTAProcess";
            this.button_StartFOTAProcess.Size = new System.Drawing.Size(57, 44);
            this.button_StartFOTAProcess.TabIndex = 21;
            this.button_StartFOTAProcess.Text = "Start FOTA";
            this.button_StartFOTAProcess.UseVisualStyleBackColor = true;
            this.button_StartFOTAProcess.Click += new System.EventHandler(this.Button34_Click_1);
            // 
            // textBox_TotalFileLength
            // 
            this.textBox_TotalFileLength.Location = new System.Drawing.Point(206, 78);
            this.textBox_TotalFileLength.Name = "textBox_TotalFileLength";
            this.textBox_TotalFileLength.ReadOnly = true;
            this.textBox_TotalFileLength.Size = new System.Drawing.Size(57, 26);
            this.textBox_TotalFileLength.TabIndex = 20;
            // 
            // textBox_MaximumNumberReceivedRequest
            // 
            this.textBox_MaximumNumberReceivedRequest.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MaximumNumberReceivedRequest.Location = new System.Drawing.Point(4, 106);
            this.textBox_MaximumNumberReceivedRequest.Name = "textBox_MaximumNumberReceivedRequest";
            this.textBox_MaximumNumberReceivedRequest.Size = new System.Drawing.Size(196, 89);
            this.textBox_MaximumNumberReceivedRequest.TabIndex = 19;
            this.textBox_MaximumNumberReceivedRequest.Text = "";
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(206, 300);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(57, 23);
            this.button35.TabIndex = 18;
            this.button35.Text = "Clear";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.Button35_Click);
            // 
            // button_StartFOTA
            // 
            this.button_StartFOTA.Enabled = false;
            this.button_StartFOTA.Location = new System.Drawing.Point(206, 273);
            this.button_StartFOTA.Name = "button_StartFOTA";
            this.button_StartFOTA.Size = new System.Drawing.Size(57, 23);
            this.button_StartFOTA.TabIndex = 16;
            this.button_StartFOTA.Text = "--->";
            this.button_StartFOTA.UseVisualStyleBackColor = true;
            this.button_StartFOTA.Click += new System.EventHandler(this.Button33_Click);
            // 
            // textBox_TotalFrames1280Bytes
            // 
            this.textBox_TotalFrames1280Bytes.Location = new System.Drawing.Point(206, 49);
            this.textBox_TotalFrames1280Bytes.Name = "textBox_TotalFrames1280Bytes";
            this.textBox_TotalFrames1280Bytes.ReadOnly = true;
            this.textBox_TotalFrames1280Bytes.Size = new System.Drawing.Size(57, 26);
            this.textBox_TotalFrames1280Bytes.TabIndex = 14;
            this.textBox_TotalFrames1280Bytes.TextChanged += new System.EventHandler(this.TextBox_TotalFrames256Bytes_TextChanged);
            // 
            // textBox_FOTA
            // 
            this.textBox_FOTA.Location = new System.Drawing.Point(7, 49);
            this.textBox_FOTA.Multiline = true;
            this.textBox_FOTA.Name = "textBox_FOTA";
            this.textBox_FOTA.Size = new System.Drawing.Size(193, 52);
            this.textBox_FOTA.TabIndex = 13;
            this.textBox_FOTA.TextChanged += new System.EventHandler(this.TextBox_FOTA_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Choose File";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // checkBox_EchoResponse
            // 
            this.checkBox_EchoResponse.AutoSize = true;
            this.checkBox_EchoResponse.Location = new System.Drawing.Point(5, 343);
            this.checkBox_EchoResponse.Name = "checkBox_EchoResponse";
            this.checkBox_EchoResponse.Size = new System.Drawing.Size(117, 22);
            this.checkBox_EchoResponse.TabIndex = 10;
            this.checkBox_EchoResponse.Text = "Send ACK Back";
            this.checkBox_EchoResponse.UseVisualStyleBackColor = true;
            this.checkBox_EchoResponse.CheckedChanged += new System.EventHandler(this.CheckBox_EchoResponse_CheckedChanged);
            // 
            // groupBox_ConnectionTimedOut
            // 
            this.groupBox_ConnectionTimedOut.Controls.Add(this.textBox_CurrentTimeOut);
            this.groupBox_ConnectionTimedOut.Controls.Add(this.button_SetTimedOut);
            this.groupBox_ConnectionTimedOut.Controls.Add(this.textBox_ConnectionTimedOut);
            this.groupBox_ConnectionTimedOut.Location = new System.Drawing.Point(3, 288);
            this.groupBox_ConnectionTimedOut.Name = "groupBox_ConnectionTimedOut";
            this.groupBox_ConnectionTimedOut.Size = new System.Drawing.Size(273, 53);
            this.groupBox_ConnectionTimedOut.TabIndex = 9;
            this.groupBox_ConnectionTimedOut.TabStop = false;
            this.groupBox_ConnectionTimedOut.Text = "Server Connection Timed Out (seconds)";
            this.groupBox_ConnectionTimedOut.Visible = false;
            // 
            // textBox_CurrentTimeOut
            // 
            this.textBox_CurrentTimeOut.Location = new System.Drawing.Point(146, 21);
            this.textBox_CurrentTimeOut.Name = "textBox_CurrentTimeOut";
            this.textBox_CurrentTimeOut.ReadOnly = true;
            this.textBox_CurrentTimeOut.Size = new System.Drawing.Size(62, 26);
            this.textBox_CurrentTimeOut.TabIndex = 10;
            // 
            // button_SetTimedOut
            // 
            this.button_SetTimedOut.Location = new System.Drawing.Point(65, 21);
            this.button_SetTimedOut.Name = "button_SetTimedOut";
            this.button_SetTimedOut.Size = new System.Drawing.Size(75, 23);
            this.button_SetTimedOut.TabIndex = 9;
            this.button_SetTimedOut.Text = "Set";
            this.button_SetTimedOut.UseVisualStyleBackColor = true;
            this.button_SetTimedOut.Click += new System.EventHandler(this.Button_SetTimedOut_Click);
            // 
            // textBox_ConnectionTimedOut
            // 
            this.textBox_ConnectionTimedOut.Location = new System.Drawing.Point(6, 22);
            this.textBox_ConnectionTimedOut.Name = "textBox_ConnectionTimedOut";
            this.textBox_ConnectionTimedOut.Size = new System.Drawing.Size(53, 26);
            this.textBox_ConnectionTimedOut.TabIndex = 8;
            this.textBox_ConnectionTimedOut.Text = "300";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_ServerRecord);
            this.groupBox3.Controls.Add(this.checkBox_ServerPause);
            this.groupBox3.Controls.Add(this.button_ClearServer);
            this.groupBox3.Controls.Add(this.checkBox_StopLogging);
            this.groupBox3.Controls.Add(this.TextBox_Server);
            this.groupBox3.Controls.Add(this.checkBox_RecordGeneral);
            this.groupBox3.Controls.Add(this.PauseCheck);
            this.groupBox3.Controls.Add(this.Clear_btn);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(282, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(936, 611);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Console";
            // 
            // checkBox_ServerRecord
            // 
            this.checkBox_ServerRecord.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_ServerRecord.AutoSize = true;
            this.checkBox_ServerRecord.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ServerRecord.Location = new System.Drawing.Point(152, 578);
            this.checkBox_ServerRecord.Name = "checkBox_ServerRecord";
            this.checkBox_ServerRecord.Size = new System.Drawing.Size(64, 29);
            this.checkBox_ServerRecord.TabIndex = 108;
            this.checkBox_ServerRecord.Text = "Record";
            this.checkBox_ServerRecord.UseVisualStyleBackColor = true;
            // 
            // checkBox_ServerPause
            // 
            this.checkBox_ServerPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_ServerPause.AutoSize = true;
            this.checkBox_ServerPause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ServerPause.Location = new System.Drawing.Point(88, 578);
            this.checkBox_ServerPause.Name = "checkBox_ServerPause";
            this.checkBox_ServerPause.Size = new System.Drawing.Size(58, 29);
            this.checkBox_ServerPause.TabIndex = 107;
            this.checkBox_ServerPause.Text = "Pause";
            this.checkBox_ServerPause.UseVisualStyleBackColor = true;
            // 
            // button_ClearServer
            // 
            this.button_ClearServer.Location = new System.Drawing.Point(6, 578);
            this.button_ClearServer.Name = "button_ClearServer";
            this.button_ClearServer.Size = new System.Drawing.Size(75, 23);
            this.button_ClearServer.TabIndex = 104;
            this.button_ClearServer.Text = "Clear";
            this.button_ClearServer.UseVisualStyleBackColor = true;
            // 
            // checkBox_StopLogging
            // 
            this.checkBox_StopLogging.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_StopLogging.AutoSize = true;
            this.checkBox_StopLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_StopLogging.Location = new System.Drawing.Point(305, 629);
            this.checkBox_StopLogging.Name = "checkBox_StopLogging";
            this.checkBox_StopLogging.Size = new System.Drawing.Size(106, 26);
            this.checkBox_StopLogging.TabIndex = 8;
            this.checkBox_StopLogging.Text = "Stop Printing";
            this.checkBox_StopLogging.UseVisualStyleBackColor = true;
            // 
            // TextBox_Server
            // 
            this.TextBox_Server.BackColor = System.Drawing.Color.LightGray;
            this.TextBox_Server.EnableAutoDragDrop = true;
            this.TextBox_Server.Location = new System.Drawing.Point(7, 20);
            this.TextBox_Server.Name = "TextBox_Server";
            this.TextBox_Server.Size = new System.Drawing.Size(923, 552);
            this.TextBox_Server.TabIndex = 0;
            this.TextBox_Server.Text = "";
            this.TextBox_Server.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // checkBox_RecordGeneral
            // 
            this.checkBox_RecordGeneral.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordGeneral.AutoSize = true;
            this.checkBox_RecordGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordGeneral.Location = new System.Drawing.Point(417, 629);
            this.checkBox_RecordGeneral.Name = "checkBox_RecordGeneral";
            this.checkBox_RecordGeneral.Size = new System.Drawing.Size(99, 26);
            this.checkBox_RecordGeneral.TabIndex = 7;
            this.checkBox_RecordGeneral.Text = "Record Log";
            this.checkBox_RecordGeneral.UseVisualStyleBackColor = true;
            this.checkBox_RecordGeneral.CheckedChanged += new System.EventHandler(this.CheckBox_RecordGeneral_CheckedChanged);
            // 
            // PauseCheck
            // 
            this.PauseCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.PauseCheck.AutoSize = true;
            this.PauseCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseCheck.Location = new System.Drawing.Point(522, 629);
            this.PauseCheck.Name = "PauseCheck";
            this.PauseCheck.Size = new System.Drawing.Size(62, 26);
            this.PauseCheck.TabIndex = 5;
            this.PauseCheck.Text = "Pause";
            this.PauseCheck.UseVisualStyleBackColor = true;
            // 
            // Clear_btn
            // 
            this.Clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_btn.Location = new System.Drawing.Point(590, 629);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(62, 26);
            this.Clear_btn.TabIndex = 6;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            // 
            // tabPage_ClientTCP
            // 
            this.tabPage_ClientTCP.Controls.Add(this.button_Ping);
            this.tabPage_ClientTCP.Controls.Add(this.label10);
            this.tabPage_ClientTCP.Controls.Add(this.label9);
            this.tabPage_ClientTCP.Controls.Add(this.button_ClearRx);
            this.tabPage_ClientTCP.Controls.Add(this.richTextBox_ClientRx);
            this.tabPage_ClientTCP.Controls.Add(this.button43);
            this.tabPage_ClientTCP.Controls.Add(this.button_ClientClose);
            this.tabPage_ClientTCP.Controls.Add(this.button_ClientConnect);
            this.tabPage_ClientTCP.Controls.Add(this.button3);
            this.tabPage_ClientTCP.Controls.Add(this.richTextBox_ClientTx);
            this.tabPage_ClientTCP.Controls.Add(this.textBox_ClientPort);
            this.tabPage_ClientTCP.Controls.Add(this.textBox_ClientIP);
            this.tabPage_ClientTCP.Controls.Add(this.label8);
            this.tabPage_ClientTCP.Controls.Add(this.label7);
            this.tabPage_ClientTCP.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ClientTCP.Name = "tabPage_ClientTCP";
            this.tabPage_ClientTCP.Size = new System.Drawing.Size(1547, 687);
            this.tabPage_ClientTCP.TabIndex = 9;
            this.tabPage_ClientTCP.Text = "Client TCP";
            this.tabPage_ClientTCP.UseVisualStyleBackColor = true;
            // 
            // button_Ping
            // 
            this.button_Ping.Location = new System.Drawing.Point(195, 78);
            this.button_Ping.Name = "button_Ping";
            this.button_Ping.Size = new System.Drawing.Size(100, 23);
            this.button_Ping.TabIndex = 14;
            this.button_Ping.Text = "Ping";
            this.button_Ping.UseVisualStyleBackColor = true;
            this.button_Ping.Click += new System.EventHandler(this.button72_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(599, 303);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "Rx - Data Received";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(599, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tx - Data Send";
            // 
            // button_ClearRx
            // 
            this.button_ClearRx.Location = new System.Drawing.Point(1186, 333);
            this.button_ClearRx.Name = "button_ClearRx";
            this.button_ClearRx.Size = new System.Drawing.Size(75, 23);
            this.button_ClearRx.TabIndex = 11;
            this.button_ClearRx.Text = "Clear Rx";
            this.button_ClearRx.UseVisualStyleBackColor = true;
            this.button_ClearRx.Click += new System.EventHandler(this.Button_ClearRx_Click);
            // 
            // richTextBox_ClientRx
            // 
            this.richTextBox_ClientRx.Location = new System.Drawing.Point(34, 334);
            this.richTextBox_ClientRx.Name = "richTextBox_ClientRx";
            this.richTextBox_ClientRx.ReadOnly = true;
            this.richTextBox_ClientRx.Size = new System.Drawing.Size(1146, 167);
            this.richTextBox_ClientRx.TabIndex = 9;
            this.richTextBox_ClientRx.Text = "";
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(1187, 145);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(75, 24);
            this.button43.TabIndex = 8;
            this.button43.Text = "Clear Tx";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.Button43_Click_1);
            // 
            // button_ClientClose
            // 
            this.button_ClientClose.Location = new System.Drawing.Point(115, 79);
            this.button_ClientClose.Name = "button_ClientClose";
            this.button_ClientClose.Size = new System.Drawing.Size(75, 23);
            this.button_ClientClose.TabIndex = 7;
            this.button_ClientClose.Text = "Close";
            this.button_ClientClose.UseVisualStyleBackColor = true;
            this.button_ClientClose.Click += new System.EventHandler(this.Button42_Click_1);
            // 
            // button_ClientConnect
            // 
            this.button_ClientConnect.Location = new System.Drawing.Point(34, 80);
            this.button_ClientConnect.Name = "button_ClientConnect";
            this.button_ClientConnect.Size = new System.Drawing.Size(75, 23);
            this.button_ClientConnect.TabIndex = 6;
            this.button_ClientConnect.Text = "Connect";
            this.button_ClientConnect.UseVisualStyleBackColor = true;
            this.button_ClientConnect.Click += new System.EventHandler(this.Button_ClientConnect_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1187, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click_4);
            // 
            // richTextBox_ClientTx
            // 
            this.richTextBox_ClientTx.Location = new System.Drawing.Point(34, 117);
            this.richTextBox_ClientTx.Name = "richTextBox_ClientTx";
            this.richTextBox_ClientTx.Size = new System.Drawing.Size(1148, 167);
            this.richTextBox_ClientTx.TabIndex = 4;
            this.richTextBox_ClientTx.Text = "Send Data to Server";
            // 
            // textBox_ClientPort
            // 
            this.textBox_ClientPort.Location = new System.Drawing.Point(124, 47);
            this.textBox_ClientPort.Name = "textBox_ClientPort";
            this.textBox_ClientPort.Size = new System.Drawing.Size(100, 26);
            this.textBox_ClientPort.TabIndex = 3;
            this.textBox_ClientPort.Text = "7000";
            // 
            // textBox_ClientIP
            // 
            this.textBox_ClientIP.Location = new System.Drawing.Point(124, 17);
            this.textBox_ClientIP.Name = "textBox_ClientIP";
            this.textBox_ClientIP.Size = new System.Drawing.Size(100, 26);
            this.textBox_ClientIP.TabIndex = 2;
            this.textBox_ClientIP.Text = "10.0.1.10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Host or IP";
            // 
            // tabPage_SerialPort
            // 
            this.tabPage_SerialPort.Controls.Add(this.groupBox_SendSerialOrMonitorCommands);
            this.tabPage_SerialPort.Controls.Add(this.gbPortSettings);
            this.tabPage_SerialPort.Controls.Add(this.groupBox5);
            this.tabPage_SerialPort.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SerialPort.Name = "tabPage_SerialPort";
            this.tabPage_SerialPort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SerialPort.Size = new System.Drawing.Size(1547, 687);
            this.tabPage_SerialPort.TabIndex = 1;
            this.tabPage_SerialPort.Text = "Serial Port";
            this.tabPage_SerialPort.UseVisualStyleBackColor = true;
            // 
            // groupBox_SendSerialOrMonitorCommands
            // 
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.checkBox_SendHexdata);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.textBox_SendSerialPort);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.checkBox_DeleteCommand);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.button_SendSerialPort);
            this.groupBox_SendSerialOrMonitorCommands.Location = new System.Drawing.Point(4, 6);
            this.groupBox_SendSerialOrMonitorCommands.Name = "groupBox_SendSerialOrMonitorCommands";
            this.groupBox_SendSerialOrMonitorCommands.Size = new System.Drawing.Size(626, 93);
            this.groupBox_SendSerialOrMonitorCommands.TabIndex = 69;
            this.groupBox_SendSerialOrMonitorCommands.TabStop = false;
            this.groupBox_SendSerialOrMonitorCommands.Text = "Send Data to Serial Port";
            // 
            // checkBox_SendHexdata
            // 
            this.checkBox_SendHexdata.AutoSize = true;
            this.checkBox_SendHexdata.Checked = true;
            this.checkBox_SendHexdata.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SendHexdata.Location = new System.Drawing.Point(262, 60);
            this.checkBox_SendHexdata.Name = "checkBox_SendHexdata";
            this.checkBox_SendHexdata.Size = new System.Drawing.Size(115, 22);
            this.checkBox_SendHexdata.TabIndex = 5;
            this.checkBox_SendHexdata.Text = "Send Hex data";
            this.checkBox_SendHexdata.UseVisualStyleBackColor = true;
            this.checkBox_SendHexdata.CheckedChanged += new System.EventHandler(this.CheckBox_SendHexdata_CheckedChanged);
            // 
            // textBox_SendSerialPort
            // 
            this.textBox_SendSerialPort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_SendSerialPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_SendSerialPort.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SendSerialPort.Location = new System.Drawing.Point(9, 21);
            this.textBox_SendSerialPort.Name = "textBox_SendSerialPort";
            this.textBox_SendSerialPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SendSerialPort.Size = new System.Drawing.Size(611, 31);
            this.textBox_SendSerialPort.TabIndex = 0;
            this.textBox_SendSerialPort.TextChanged += new System.EventHandler(this.TextBox_SendSerialPort_TextChanged_1);
            this.textBox_SendSerialPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_SendSerialPort_KeyDown);
            this.textBox_SendSerialPort.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_SendSerialPort_PreviewKeyDown);
            // 
            // checkBox_DeleteCommand
            // 
            this.checkBox_DeleteCommand.AutoSize = true;
            this.checkBox_DeleteCommand.Location = new System.Drawing.Point(126, 61);
            this.checkBox_DeleteCommand.Name = "checkBox_DeleteCommand";
            this.checkBox_DeleteCommand.Size = new System.Drawing.Size(135, 22);
            this.checkBox_DeleteCommand.TabIndex = 4;
            this.checkBox_DeleteCommand.Text = "Delete after Send";
            this.checkBox_DeleteCommand.UseVisualStyleBackColor = true;
            // 
            // button_SendSerialPort
            // 
            this.button_SendSerialPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SendSerialPort.Location = new System.Drawing.Point(9, 58);
            this.button_SendSerialPort.Name = "button_SendSerialPort";
            this.button_SendSerialPort.Size = new System.Drawing.Size(105, 24);
            this.button_SendSerialPort.TabIndex = 1;
            this.button_SendSerialPort.Text = "Send";
            this.button_SendSerialPort.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // gbPortSettings
            // 
            this.gbPortSettings.Controls.Add(this.button_OpenPort);
            this.gbPortSettings.Controls.Add(this.button_ReScanComPort);
            this.gbPortSettings.Controls.Add(this.cmb_PortName);
            this.gbPortSettings.Controls.Add(this.cmbBaudRate);
            this.gbPortSettings.Controls.Add(this.cmb_StopBits);
            this.gbPortSettings.Controls.Add(this.cmbParity);
            this.gbPortSettings.Controls.Add(this.cmbDataBits);
            this.gbPortSettings.Controls.Add(this.lblComPort);
            this.gbPortSettings.Controls.Add(this.lblStopBits);
            this.gbPortSettings.Controls.Add(this.lblBaudRate);
            this.gbPortSettings.Controls.Add(this.lblDataBits);
            this.gbPortSettings.Controls.Add(this.label3);
            this.gbPortSettings.Location = new System.Drawing.Point(636, 6);
            this.gbPortSettings.Name = "gbPortSettings";
            this.gbPortSettings.Size = new System.Drawing.Size(905, 92);
            this.gbPortSettings.TabIndex = 10;
            this.gbPortSettings.TabStop = false;
            this.gbPortSettings.Text = "COM Serial Port Settings";
            // 
            // button_OpenPort
            // 
            this.button_OpenPort.Location = new System.Drawing.Point(507, 34);
            this.button_OpenPort.Name = "button_OpenPort";
            this.button_OpenPort.Size = new System.Drawing.Size(91, 33);
            this.button_OpenPort.TabIndex = 11;
            this.button_OpenPort.Text = "Open ";
            this.button_OpenPort.UseVisualStyleBackColor = true;
            this.button_OpenPort.Click += new System.EventHandler(this.Button_OpenPort_Click);
            // 
            // button_ReScanComPort
            // 
            this.button_ReScanComPort.AutoSize = true;
            this.button_ReScanComPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReScanComPort.Location = new System.Drawing.Point(414, 34);
            this.button_ReScanComPort.Name = "button_ReScanComPort";
            this.button_ReScanComPort.Size = new System.Drawing.Size(87, 34);
            this.button_ReScanComPort.TabIndex = 10;
            this.button_ReScanComPort.Text = "ReScan";
            this.button_ReScanComPort.UseVisualStyleBackColor = true;
            this.button_ReScanComPort.Click += new System.EventHandler(this.Button_ReScanComPort_Click);
            // 
            // cmb_PortName
            // 
            this.cmb_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PortName.FormattingEnabled = true;
            this.cmb_PortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cmb_PortName.Location = new System.Drawing.Point(8, 38);
            this.cmb_PortName.Name = "cmb_PortName";
            this.cmb_PortName.Size = new System.Drawing.Size(67, 26);
            this.cmb_PortName.TabIndex = 1;
            this.cmb_PortName.Tag = "1";
            this.cmb_PortName.SelectedIndexChanged += new System.EventHandler(this.CmbPortName_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(81, 38);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(89, 26);
            this.cmbBaudRate.TabIndex = 3;
            this.cmbBaudRate.Text = "38400";
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.CmbBaudRate_SelectedIndexChanged);
            // 
            // cmb_StopBits
            // 
            this.cmb_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopBits.FormattingEnabled = true;
            this.cmb_StopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmb_StopBits.Location = new System.Drawing.Point(308, 37);
            this.cmb_StopBits.Name = "cmb_StopBits";
            this.cmb_StopBits.Size = new System.Drawing.Size(88, 26);
            this.cmb_StopBits.TabIndex = 9;
            // 
            // cmbParity
            // 
            this.cmbParity.DisplayMember = "1";
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(176, 37);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(60, 26);
            this.cmbParity.TabIndex = 5;
            this.cmbParity.Tag = "1";
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBits.Location = new System.Drawing.Point(241, 37);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(60, 26);
            this.cmbDataBits.TabIndex = 7;
            this.cmbDataBits.Text = "8";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(7, 22);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(71, 18);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port:";
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(310, 21);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(66, 18);
            this.lblStopBits.TabIndex = 8;
            this.lblStopBits.Text = "Stop Bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(80, 22);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(74, 18);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(244, 21);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(66, 18);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parity:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox_Timer);
            this.groupBox5.Controls.Add(this.groupBox_Stopwatch);
            this.groupBox5.Controls.Add(this.checkBox_RxHex);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern3);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern2);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern);
            this.groupBox5.Controls.Add(this.checkBox_S1RecordLog);
            this.groupBox5.Controls.Add(this.checkBox_S1Pause);
            this.groupBox5.Controls.Add(this.txtS1_Clear);
            this.groupBox5.Controls.Add(this.SerialPortLogger_TextBox);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(4, 105);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1537, 571);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Serial Port Console";
            this.groupBox5.Enter += new System.EventHandler(this.GroupBox5_Enter);
            // 
            // groupBox_Timer
            // 
            this.groupBox_Timer.Controls.Add(this.textBox_TimerTime);
            this.groupBox_Timer.Controls.Add(this.button_StartStopTimer);
            this.groupBox_Timer.Controls.Add(this.button_ResetTimer);
            this.groupBox_Timer.Controls.Add(this.textBox_SetTimerTime);
            this.groupBox_Timer.Location = new System.Drawing.Point(41, 727);
            this.groupBox_Timer.Name = "groupBox_Timer";
            this.groupBox_Timer.Size = new System.Drawing.Size(270, 111);
            this.groupBox_Timer.TabIndex = 107;
            this.groupBox_Timer.TabStop = false;
            this.groupBox_Timer.Text = "Timer";
            this.groupBox_Timer.Visible = false;
            // 
            // textBox_TimerTime
            // 
            this.textBox_TimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimerTime.Location = new System.Drawing.Point(119, 66);
            this.textBox_TimerTime.Name = "textBox_TimerTime";
            this.textBox_TimerTime.ReadOnly = true;
            this.textBox_TimerTime.Size = new System.Drawing.Size(70, 31);
            this.textBox_TimerTime.TabIndex = 106;
            this.textBox_TimerTime.Text = "0";
            // 
            // button_StartStopTimer
            // 
            this.button_StartStopTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartStopTimer.Location = new System.Drawing.Point(9, 23);
            this.button_StartStopTimer.Name = "button_StartStopTimer";
            this.button_StartStopTimer.Size = new System.Drawing.Size(110, 37);
            this.button_StartStopTimer.TabIndex = 104;
            this.button_StartStopTimer.Text = "Start/Stop";
            this.button_StartStopTimer.UseVisualStyleBackColor = true;
            this.button_StartStopTimer.Click += new System.EventHandler(this.Button_StartStopTimer_Click);
            // 
            // button_ResetTimer
            // 
            this.button_ResetTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ResetTimer.Location = new System.Drawing.Point(119, 23);
            this.button_ResetTimer.Name = "button_ResetTimer";
            this.button_ResetTimer.Size = new System.Drawing.Size(110, 37);
            this.button_ResetTimer.TabIndex = 105;
            this.button_ResetTimer.Text = "Reset (0)";
            this.button_ResetTimer.UseVisualStyleBackColor = true;
            this.button_ResetTimer.Click += new System.EventHandler(this.Button_ResetTimer_Click);
            // 
            // textBox_SetTimerTime
            // 
            this.textBox_SetTimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SetTimerTime.Location = new System.Drawing.Point(9, 66);
            this.textBox_SetTimerTime.Name = "textBox_SetTimerTime";
            this.textBox_SetTimerTime.Size = new System.Drawing.Size(104, 31);
            this.textBox_SetTimerTime.TabIndex = 103;
            this.textBox_SetTimerTime.Text = "0";
            // 
            // groupBox_Stopwatch
            // 
            this.groupBox_Stopwatch.Controls.Add(this.button_TimerLog);
            this.groupBox_Stopwatch.Controls.Add(this.button_Stopwatch_Start_Stop);
            this.groupBox_Stopwatch.Controls.Add(this.button_StopwatchReset);
            this.groupBox_Stopwatch.Controls.Add(this.textBox_StopWatch);
            this.groupBox_Stopwatch.Location = new System.Drawing.Point(41, 609);
            this.groupBox_Stopwatch.Name = "groupBox_Stopwatch";
            this.groupBox_Stopwatch.Size = new System.Drawing.Size(270, 111);
            this.groupBox_Stopwatch.TabIndex = 106;
            this.groupBox_Stopwatch.TabStop = false;
            this.groupBox_Stopwatch.Text = "Stopwatch";
            this.groupBox_Stopwatch.Visible = false;
            // 
            // button_TimerLog
            // 
            this.button_TimerLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TimerLog.Location = new System.Drawing.Point(189, 23);
            this.button_TimerLog.Name = "button_TimerLog";
            this.button_TimerLog.Size = new System.Drawing.Size(75, 37);
            this.button_TimerLog.TabIndex = 106;
            this.button_TimerLog.Text = "Log ->";
            this.button_TimerLog.UseVisualStyleBackColor = true;
            this.button_TimerLog.Click += new System.EventHandler(this.Button_TimerLog_Click);
            // 
            // button_Stopwatch_Start_Stop
            // 
            this.button_Stopwatch_Start_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Stopwatch_Start_Stop.Location = new System.Drawing.Point(9, 23);
            this.button_Stopwatch_Start_Stop.Name = "button_Stopwatch_Start_Stop";
            this.button_Stopwatch_Start_Stop.Size = new System.Drawing.Size(110, 37);
            this.button_Stopwatch_Start_Stop.TabIndex = 104;
            this.button_Stopwatch_Start_Stop.Text = "Start/Stop";
            this.button_Stopwatch_Start_Stop.UseVisualStyleBackColor = true;
            this.button_Stopwatch_Start_Stop.Click += new System.EventHandler(this.Button_Stopwatch_Start_Stop_Click);
            // 
            // button_StopwatchReset
            // 
            this.button_StopwatchReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StopwatchReset.Location = new System.Drawing.Point(119, 23);
            this.button_StopwatchReset.Name = "button_StopwatchReset";
            this.button_StopwatchReset.Size = new System.Drawing.Size(70, 37);
            this.button_StopwatchReset.TabIndex = 105;
            this.button_StopwatchReset.Text = "Reset";
            this.button_StopwatchReset.UseVisualStyleBackColor = true;
            this.button_StopwatchReset.Click += new System.EventHandler(this.Button_StopwatchReset_Click);
            // 
            // textBox_StopWatch
            // 
            this.textBox_StopWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_StopWatch.Location = new System.Drawing.Point(9, 66);
            this.textBox_StopWatch.Name = "textBox_StopWatch";
            this.textBox_StopWatch.ReadOnly = true;
            this.textBox_StopWatch.Size = new System.Drawing.Size(200, 31);
            this.textBox_StopWatch.TabIndex = 103;
            this.textBox_StopWatch.Text = "0";
            this.textBox_StopWatch.TextChanged += new System.EventHandler(this.TextBox_StopWatch_TextChanged);
            // 
            // checkBox_RxHex
            // 
            this.checkBox_RxHex.AutoSize = true;
            this.checkBox_RxHex.Checked = true;
            this.checkBox_RxHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RxHex.Location = new System.Drawing.Point(1194, 20);
            this.checkBox_RxHex.Name = "checkBox_RxHex";
            this.checkBox_RxHex.Size = new System.Drawing.Size(111, 23);
            this.checkBox_RxHex.TabIndex = 6;
            this.checkBox_RxHex.Text = "Show Rx Hex";
            this.checkBox_RxHex.UseVisualStyleBackColor = true;
            // 
            // textBox_SerialPortRecognizePattern3
            // 
            this.textBox_SerialPortRecognizePattern3.Location = new System.Drawing.Point(252, 17);
            this.textBox_SerialPortRecognizePattern3.Name = "textBox_SerialPortRecognizePattern3";
            this.textBox_SerialPortRecognizePattern3.Size = new System.Drawing.Size(117, 27);
            this.textBox_SerialPortRecognizePattern3.TabIndex = 75;
            // 
            // textBox_SerialPortRecognizePattern2
            // 
            this.textBox_SerialPortRecognizePattern2.Location = new System.Drawing.Point(129, 18);
            this.textBox_SerialPortRecognizePattern2.Name = "textBox_SerialPortRecognizePattern2";
            this.textBox_SerialPortRecognizePattern2.Size = new System.Drawing.Size(117, 27);
            this.textBox_SerialPortRecognizePattern2.TabIndex = 74;
            // 
            // textBox_SerialPortRecognizePattern
            // 
            this.textBox_SerialPortRecognizePattern.Location = new System.Drawing.Point(6, 18);
            this.textBox_SerialPortRecognizePattern.Name = "textBox_SerialPortRecognizePattern";
            this.textBox_SerialPortRecognizePattern.Size = new System.Drawing.Size(117, 27);
            this.textBox_SerialPortRecognizePattern.TabIndex = 73;
            // 
            // checkBox_S1RecordLog
            // 
            this.checkBox_S1RecordLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_S1RecordLog.AutoSize = true;
            this.checkBox_S1RecordLog.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_S1RecordLog.Location = new System.Drawing.Point(1311, 17);
            this.checkBox_S1RecordLog.Name = "checkBox_S1RecordLog";
            this.checkBox_S1RecordLog.Size = new System.Drawing.Size(83, 29);
            this.checkBox_S1RecordLog.TabIndex = 69;
            this.checkBox_S1RecordLog.Text = "Log to file";
            this.checkBox_S1RecordLog.UseVisualStyleBackColor = true;
            this.checkBox_S1RecordLog.CheckedChanged += new System.EventHandler(this.CheckBox_S1RecordLog_CheckedChanged);
            // 
            // checkBox_S1Pause
            // 
            this.checkBox_S1Pause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_S1Pause.AutoSize = true;
            this.checkBox_S1Pause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_S1Pause.Location = new System.Drawing.Point(1403, 17);
            this.checkBox_S1Pause.Name = "checkBox_S1Pause";
            this.checkBox_S1Pause.Size = new System.Drawing.Size(58, 29);
            this.checkBox_S1Pause.TabIndex = 70;
            this.checkBox_S1Pause.Text = "Pause";
            this.checkBox_S1Pause.UseVisualStyleBackColor = true;
            this.checkBox_S1Pause.CheckedChanged += new System.EventHandler(this.CheckBox_S1Pause_CheckedChanged);
            // 
            // txtS1_Clear
            // 
            this.txtS1_Clear.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtS1_Clear.Location = new System.Drawing.Point(1468, 17);
            this.txtS1_Clear.Name = "txtS1_Clear";
            this.txtS1_Clear.Size = new System.Drawing.Size(62, 26);
            this.txtS1_Clear.TabIndex = 69;
            this.txtS1_Clear.Text = "Clear";
            this.txtS1_Clear.UseVisualStyleBackColor = true;
            this.txtS1_Clear.Click += new System.EventHandler(this.txtS1_Clear_Click);
            // 
            // SerialPortLogger_TextBox
            // 
            this.SerialPortLogger_TextBox.BackColor = System.Drawing.Color.LightGray;
            this.SerialPortLogger_TextBox.EnableAutoDragDrop = true;
            this.SerialPortLogger_TextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialPortLogger_TextBox.Location = new System.Drawing.Point(4, 49);
            this.SerialPortLogger_TextBox.Name = "SerialPortLogger_TextBox";
            this.SerialPortLogger_TextBox.Size = new System.Drawing.Size(1536, 516);
            this.SerialPortLogger_TextBox.TabIndex = 0;
            this.SerialPortLogger_TextBox.Text = "";
            this.SerialPortLogger_TextBox.TextChanged += new System.EventHandler(this.SerialPortLogger_TextBox_TextChanged);
            // 
            // tabPage_GenericFrame
            // 
            this.tabPage_GenericFrame.Controls.Add(this.button52);
            this.tabPage_GenericFrame.Controls.Add(this.groupBox31);
            this.tabPage_GenericFrame.Controls.Add(this.groupBox_clientTX);
            this.tabPage_GenericFrame.Location = new System.Drawing.Point(4, 22);
            this.tabPage_GenericFrame.Name = "tabPage_GenericFrame";
            this.tabPage_GenericFrame.Size = new System.Drawing.Size(1547, 687);
            this.tabPage_GenericFrame.TabIndex = 10;
            this.tabPage_GenericFrame.Text = "Generic Kratos frame";
            this.tabPage_GenericFrame.UseVisualStyleBackColor = true;
            this.tabPage_GenericFrame.Enter += new System.EventHandler(this.tabPage_GenericFrame_Enter);
            this.tabPage_GenericFrame.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tabPage_GenericFrame_PreviewKeyDown);
            // 
            // button52
            // 
            this.button52.Location = new System.Drawing.Point(20, 439);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(75, 23);
            this.button52.TabIndex = 15;
            this.button52.Text = "Clear";
            this.button52.UseVisualStyleBackColor = true;
            this.button52.Click += new System.EventHandler(this.button52_Click);
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.textBox_RxClientCheckSum);
            this.groupBox31.Controls.Add(this.label24);
            this.groupBox31.Controls.Add(this.label41);
            this.groupBox31.Controls.Add(this.textBox_RxClientDataLength);
            this.groupBox31.Controls.Add(this.label23);
            this.groupBox31.Controls.Add(this.label18);
            this.groupBox31.Controls.Add(this.label13);
            this.groupBox31.Controls.Add(this.textBox_RxClientPreamble);
            this.groupBox31.Controls.Add(this.textBox_RxClientOpcode);
            this.groupBox31.Controls.Add(this.textBox_RxClientData);
            this.groupBox31.Controls.Add(this.label15);
            this.groupBox31.Controls.Add(this.label16);
            this.groupBox31.Location = new System.Drawing.Point(1165, 16);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(372, 214);
            this.groupBox31.TabIndex = 14;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Data received";
            // 
            // textBox_RxClientCheckSum
            // 
            this.textBox_RxClientCheckSum.Location = new System.Drawing.Point(97, 160);
            this.textBox_RxClientCheckSum.MaxLength = 4;
            this.textBox_RxClientCheckSum.Name = "textBox_RxClientCheckSum";
            this.textBox_RxClientCheckSum.ReadOnly = true;
            this.textBox_RxClientCheckSum.Size = new System.Drawing.Size(100, 26);
            this.textBox_RxClientCheckSum.TabIndex = 15;
            this.textBox_RxClientCheckSum.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Maroon;
            this.label24.Location = new System.Drawing.Point(203, 126);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 21);
            this.label24.TabIndex = 11;
            this.label24.Text = "Decimal";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(10, 164);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(75, 18);
            this.label41.TabIndex = 14;
            this.label41.Text = "Check Sum";
            // 
            // textBox_RxClientDataLength
            // 
            this.textBox_RxClientDataLength.Location = new System.Drawing.Point(97, 125);
            this.textBox_RxClientDataLength.MaxLength = 4;
            this.textBox_RxClientDataLength.Name = "textBox_RxClientDataLength";
            this.textBox_RxClientDataLength.ReadOnly = true;
            this.textBox_RxClientDataLength.Size = new System.Drawing.Size(100, 26);
            this.textBox_RxClientDataLength.TabIndex = 10;
            this.textBox_RxClientDataLength.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 129);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 18);
            this.label23.TabIndex = 9;
            this.label23.Text = "Data Length";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Maroon;
            this.label18.Location = new System.Drawing.Point(269, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 21);
            this.label18.TabIndex = 8;
            this.label18.Text = "Hexadecimal";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 18);
            this.label13.TabIndex = 4;
            this.label13.Text = "Preamble";
            // 
            // textBox_RxClientPreamble
            // 
            this.textBox_RxClientPreamble.Location = new System.Drawing.Point(97, 18);
            this.textBox_RxClientPreamble.MaxLength = 4;
            this.textBox_RxClientPreamble.Name = "textBox_RxClientPreamble";
            this.textBox_RxClientPreamble.ReadOnly = true;
            this.textBox_RxClientPreamble.Size = new System.Drawing.Size(100, 26);
            this.textBox_RxClientPreamble.TabIndex = 0;
            this.textBox_RxClientPreamble.TabStop = false;
            this.textBox_RxClientPreamble.TextChanged += new System.EventHandler(this.textBox_RxClientPreamble_TextChanged);
            // 
            // textBox_RxClientOpcode
            // 
            this.textBox_RxClientOpcode.Location = new System.Drawing.Point(97, 54);
            this.textBox_RxClientOpcode.MaxLength = 4;
            this.textBox_RxClientOpcode.Name = "textBox_RxClientOpcode";
            this.textBox_RxClientOpcode.ReadOnly = true;
            this.textBox_RxClientOpcode.Size = new System.Drawing.Size(100, 26);
            this.textBox_RxClientOpcode.TabIndex = 1;
            this.textBox_RxClientOpcode.TabStop = false;
            // 
            // textBox_RxClientData
            // 
            this.textBox_RxClientData.Location = new System.Drawing.Point(97, 88);
            this.textBox_RxClientData.Name = "textBox_RxClientData";
            this.textBox_RxClientData.ReadOnly = true;
            this.textBox_RxClientData.Size = new System.Drawing.Size(225, 26);
            this.textBox_RxClientData.TabIndex = 2;
            this.textBox_RxClientData.TabStop = false;
            this.textBox_RxClientData.TextChanged += new System.EventHandler(this.textBox_RxClientData_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 18);
            this.label15.TabIndex = 5;
            this.label15.Text = "Opcode";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 91);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 18);
            this.label16.TabIndex = 6;
            this.label16.Text = "Data";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // groupBox_clientTX
            // 
            this.groupBox_clientTX.Controls.Add(this.button_SendProtocolSerialPort);
            this.groupBox_clientTX.Controls.Add(this.groupBox41);
            this.groupBox_clientTX.Controls.Add(this.label17);
            this.groupBox_clientTX.Controls.Add(this.label4);
            this.groupBox_clientTX.Controls.Add(this.textBox_Preamble);
            this.groupBox_clientTX.Controls.Add(this.button_SendProtocolTCPIP);
            this.groupBox_clientTX.Controls.Add(this.textBox_Opcode);
            this.groupBox_clientTX.Controls.Add(this.textBox_data);
            this.groupBox_clientTX.Controls.Add(this.label6);
            this.groupBox_clientTX.Controls.Add(this.label11);
            this.groupBox_clientTX.Location = new System.Drawing.Point(14, 12);
            this.groupBox_clientTX.Name = "groupBox_clientTX";
            this.groupBox_clientTX.Size = new System.Drawing.Size(1145, 421);
            this.groupBox_clientTX.TabIndex = 13;
            this.groupBox_clientTX.TabStop = false;
            this.groupBox_clientTX.Text = "Send Data";
            this.groupBox_clientTX.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox_clientTX_PreviewKeyDown);
            // 
            // button_SendProtocolSerialPort
            // 
            this.button_SendProtocolSerialPort.Location = new System.Drawing.Point(131, 126);
            this.button_SendProtocolSerialPort.Name = "button_SendProtocolSerialPort";
            this.button_SendProtocolSerialPort.Size = new System.Drawing.Size(121, 23);
            this.button_SendProtocolSerialPort.TabIndex = 16;
            this.button_SendProtocolSerialPort.TabStop = false;
            this.button_SendProtocolSerialPort.Text = "Send SerialPort";
            this.button_SendProtocolSerialPort.UseVisualStyleBackColor = true;
            this.button_SendProtocolSerialPort.Click += new System.EventHandler(this.button_SendProtocolSerialPort_Click);
            // 
            // groupBox41
            // 
            this.groupBox41.Controls.Add(this.textBox_SentChecksum);
            this.groupBox41.Controls.Add(this.label48);
            this.groupBox41.Controls.Add(this.label42);
            this.groupBox41.Controls.Add(this.textBox_SentDataLength);
            this.groupBox41.Controls.Add(this.label43);
            this.groupBox41.Controls.Add(this.label44);
            this.groupBox41.Controls.Add(this.label45);
            this.groupBox41.Controls.Add(this.textBox_SentPreamble);
            this.groupBox41.Controls.Add(this.textBox_SentOpcode);
            this.groupBox41.Controls.Add(this.textBox_SentData);
            this.groupBox41.Controls.Add(this.label46);
            this.groupBox41.Controls.Add(this.label47);
            this.groupBox41.Location = new System.Drawing.Point(6, 179);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Size = new System.Drawing.Size(1133, 230);
            this.groupBox41.TabIndex = 15;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "Data Sent";
            // 
            // textBox_SentChecksum
            // 
            this.textBox_SentChecksum.Location = new System.Drawing.Point(97, 162);
            this.textBox_SentChecksum.MaxLength = 4;
            this.textBox_SentChecksum.Name = "textBox_SentChecksum";
            this.textBox_SentChecksum.ReadOnly = true;
            this.textBox_SentChecksum.Size = new System.Drawing.Size(100, 26);
            this.textBox_SentChecksum.TabIndex = 13;
            this.textBox_SentChecksum.TabStop = false;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(10, 166);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(75, 18);
            this.label48.TabIndex = 12;
            this.label48.Text = "Check Sum";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.Maroon;
            this.label42.Location = new System.Drawing.Point(203, 126);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(65, 21);
            this.label42.TabIndex = 11;
            this.label42.Text = "Decimal";
            // 
            // textBox_SentDataLength
            // 
            this.textBox_SentDataLength.Location = new System.Drawing.Point(97, 125);
            this.textBox_SentDataLength.MaxLength = 4;
            this.textBox_SentDataLength.Name = "textBox_SentDataLength";
            this.textBox_SentDataLength.ReadOnly = true;
            this.textBox_SentDataLength.Size = new System.Drawing.Size(100, 26);
            this.textBox_SentDataLength.TabIndex = 10;
            this.textBox_SentDataLength.TabStop = false;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(10, 129);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(81, 18);
            this.label43.TabIndex = 9;
            this.label43.Text = "Data Length";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label44.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Maroon;
            this.label44.Location = new System.Drawing.Point(269, 16);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(97, 21);
            this.label44.TabIndex = 8;
            this.label44.Text = "Hexadecimal";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(10, 21);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(68, 18);
            this.label45.TabIndex = 4;
            this.label45.Text = "Preamble";
            // 
            // textBox_SentPreamble
            // 
            this.textBox_SentPreamble.Location = new System.Drawing.Point(97, 18);
            this.textBox_SentPreamble.MaxLength = 4;
            this.textBox_SentPreamble.Name = "textBox_SentPreamble";
            this.textBox_SentPreamble.ReadOnly = true;
            this.textBox_SentPreamble.Size = new System.Drawing.Size(100, 26);
            this.textBox_SentPreamble.TabIndex = 0;
            this.textBox_SentPreamble.TabStop = false;
            // 
            // textBox_SentOpcode
            // 
            this.textBox_SentOpcode.Location = new System.Drawing.Point(97, 54);
            this.textBox_SentOpcode.MaxLength = 4;
            this.textBox_SentOpcode.Name = "textBox_SentOpcode";
            this.textBox_SentOpcode.ReadOnly = true;
            this.textBox_SentOpcode.Size = new System.Drawing.Size(100, 26);
            this.textBox_SentOpcode.TabIndex = 1;
            this.textBox_SentOpcode.TabStop = false;
            // 
            // textBox_SentData
            // 
            this.textBox_SentData.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SentData.Location = new System.Drawing.Point(97, 88);
            this.textBox_SentData.Name = "textBox_SentData";
            this.textBox_SentData.ReadOnly = true;
            this.textBox_SentData.Size = new System.Drawing.Size(1030, 26);
            this.textBox_SentData.TabIndex = 2;
            this.textBox_SentData.TabStop = false;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(10, 60);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(56, 18);
            this.label46.TabIndex = 5;
            this.label46.Text = "Opcode";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(10, 91);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(36, 18);
            this.label47.TabIndex = 6;
            this.label47.Text = "Data";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Maroon;
            this.label17.Location = new System.Drawing.Point(627, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 21);
            this.label17.TabIndex = 7;
            this.label17.Text = "Hexadecimal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Preamble";
            // 
            // textBox_Preamble
            // 
            this.textBox_Preamble.Location = new System.Drawing.Point(97, 18);
            this.textBox_Preamble.MaxLength = 5;
            this.textBox_Preamble.Name = "textBox_Preamble";
            this.textBox_Preamble.Size = new System.Drawing.Size(100, 26);
            this.textBox_Preamble.TabIndex = 0;
            this.textBox_Preamble.Text = "23";
            this.textBox_Preamble.TextChanged += new System.EventHandler(this.textBox_Preamble_TextChanged);
            this.textBox_Preamble.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Preamble_KeyDown);
            // 
            // button_SendProtocolTCPIP
            // 
            this.button_SendProtocolTCPIP.Location = new System.Drawing.Point(6, 126);
            this.button_SendProtocolTCPIP.Name = "button_SendProtocolTCPIP";
            this.button_SendProtocolTCPIP.Size = new System.Drawing.Size(119, 23);
            this.button_SendProtocolTCPIP.TabIndex = 3;
            this.button_SendProtocolTCPIP.TabStop = false;
            this.button_SendProtocolTCPIP.Text = "Send TCP/IP";
            this.button_SendProtocolTCPIP.UseVisualStyleBackColor = true;
            this.button_SendProtocolTCPIP.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // textBox_Opcode
            // 
            this.textBox_Opcode.Location = new System.Drawing.Point(97, 54);
            this.textBox_Opcode.MaxLength = 5;
            this.textBox_Opcode.Name = "textBox_Opcode";
            this.textBox_Opcode.Size = new System.Drawing.Size(100, 26);
            this.textBox_Opcode.TabIndex = 1;
            this.textBox_Opcode.Text = "70 00";
            this.textBox_Opcode.TextChanged += new System.EventHandler(this.textBox_Opcode_TextChanged);
            this.textBox_Opcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Opcode_KeyDown);
            // 
            // textBox_data
            // 
            this.textBox_data.Location = new System.Drawing.Point(97, 88);
            this.textBox_data.Name = "textBox_data";
            this.textBox_data.Size = new System.Drawing.Size(225, 26);
            this.textBox_data.TabIndex = 2;
            this.textBox_data.Text = "04 00 00 00";
            this.textBox_data.TextChanged += new System.EventHandler(this.textBox_data_TextChanged);
            this.textBox_data.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_data_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Opcode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 18);
            this.label11.TabIndex = 6;
            this.label11.Text = "Data";
            // 
            // tabPage_Commands
            // 
            this.tabPage_Commands.Controls.Add(this.groupBox40);
            this.tabPage_Commands.Controls.Add(this.groupBox32);
            this.tabPage_Commands.Location = new System.Drawing.Point(4, 27);
            this.tabPage_Commands.Name = "tabPage_Commands";
            this.tabPage_Commands.Size = new System.Drawing.Size(1547, 682);
            this.tabPage_Commands.TabIndex = 11;
            this.tabPage_Commands.Text = "SSPA Commands";
            this.tabPage_Commands.UseVisualStyleBackColor = true;
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.tabControl_System);
            this.groupBox40.Location = new System.Drawing.Point(10, 8);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Size = new System.Drawing.Size(969, 663);
            this.groupBox40.TabIndex = 11;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = "Commands for SSPA (press right click on mouse for help)";
            // 
            // tabControl_System
            // 
            this.tabControl_System.Controls.Add(this.tabPage1);
            this.tabControl_System.Controls.Add(this.tabPage2);
            this.tabControl_System.Location = new System.Drawing.Point(6, 23);
            this.tabControl_System.Name = "tabControl_System";
            this.tabControl_System.SelectedIndex = 0;
            this.tabControl_System.Size = new System.Drawing.Size(957, 635);
            this.tabControl_System.TabIndex = 21;
            this.tabControl_System.SelectedIndexChanged += new System.EventHandler(this.tabControl_MiniAda_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox16);
            this.tabPage1.Controls.Add(this.button117);
            this.tabPage1.Controls.Add(this.button116);
            this.tabPage1.Controls.Add(this.textBox15);
            this.tabPage1.Controls.Add(this.button115);
            this.tabPage1.Controls.Add(this.button114);
            this.tabPage1.Controls.Add(this.textBox14);
            this.tabPage1.Controls.Add(this.button113);
            this.tabPage1.Controls.Add(this.textBox13);
            this.tabPage1.Controls.Add(this.button112);
            this.tabPage1.Controls.Add(this.textBox12);
            this.tabPage1.Controls.Add(this.button111);
            this.tabPage1.Controls.Add(this.textBox_RFGenParms);
            this.tabPage1.Controls.Add(this.button_SetRFGen);
            this.tabPage1.Controls.Add(this.textBox10);
            this.tabPage1.Controls.Add(this.button58);
            this.tabPage1.Controls.Add(this.textBox_PulseGenParms);
            this.tabPage1.Controls.Add(this.button_GPparms);
            this.tabPage1.Controls.Add(this.textBox8);
            this.tabPage1.Controls.Add(this.button56);
            this.tabPage1.Controls.Add(this.textBox7);
            this.tabPage1.Controls.Add(this.button55);
            this.tabPage1.Controls.Add(this.textBox6);
            this.tabPage1.Controls.Add(this.button54);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.button53);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.button51);
            this.tabPage1.Controls.Add(this.button50);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.button49);
            this.tabPage1.Controls.Add(this.textBox_TxInhibit);
            this.tabPage1.Controls.Add(this.button47);
            this.tabPage1.Controls.Add(this.button48);
            this.tabPage1.Controls.Add(this.button108);
            this.tabPage1.Controls.Add(this.button109);
            this.tabPage1.Controls.Add(this.button45);
            this.tabPage1.Controls.Add(this.button46);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(949, 604);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simulator";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(655, 319);
            this.textBox16.MaxLength = 30;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(129, 26);
            this.textBox16.TabIndex = 86;
            this.textBox16.Text = "00";
            this.textBox16.TextChanged += new System.EventHandler(this.textBox16_TextChanged);
            // 
            // button117
            // 
            this.button117.Location = new System.Drawing.Point(402, 320);
            this.button117.Name = "button117";
            this.button117.Size = new System.Drawing.Size(244, 23);
            this.button117.TabIndex = 85;
            this.button117.Text = "Simulator discrete Tx_OVT_Check control";
            this.button117.UseVisualStyleBackColor = true;
            this.button117.Click += new System.EventHandler(this.button117_Click);
            // 
            // button116
            // 
            this.button116.Location = new System.Drawing.Point(402, 290);
            this.button116.Name = "button116";
            this.button116.Size = new System.Drawing.Size(244, 23);
            this.button116.TabIndex = 84;
            this.button116.Text = "Simulator discrete SEU_Recover control";
            this.button116.UseVisualStyleBackColor = true;
            this.button116.Click += new System.EventHandler(this.button116_Click);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(655, 261);
            this.textBox15.MaxLength = 30;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(129, 26);
            this.textBox15.TabIndex = 83;
            this.textBox15.Text = "00";
            this.textBox15.TextChanged += new System.EventHandler(this.textBox15_TextChanged);
            // 
            // button115
            // 
            this.button115.Location = new System.Drawing.Point(402, 263);
            this.button115.Name = "button115";
            this.button115.Size = new System.Drawing.Size(244, 23);
            this.button115.TabIndex = 82;
            this.button115.Text = "Set Simulator discrete DC4 ";
            this.button115.UseVisualStyleBackColor = true;
            this.button115.Click += new System.EventHandler(this.button115_Click);
            // 
            // button114
            // 
            this.button114.Location = new System.Drawing.Point(402, 234);
            this.button114.Name = "button114";
            this.button114.Size = new System.Drawing.Size(244, 23);
            this.button114.TabIndex = 81;
            this.button114.Text = "Get Thermal Supervisor ";
            this.button114.UseVisualStyleBackColor = true;
            this.button114.Click += new System.EventHandler(this.button114_Click);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(655, 200);
            this.textBox14.MaxLength = 30;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(129, 26);
            this.textBox14.TabIndex = 80;
            this.textBox14.Text = "00";
            this.textBox14.TextChanged += new System.EventHandler(this.textBox14_TextChanged);
            // 
            // button113
            // 
            this.button113.Location = new System.Drawing.Point(402, 202);
            this.button113.Name = "button113";
            this.button113.Size = new System.Drawing.Size(244, 23);
            this.button113.TabIndex = 79;
            this.button113.Text = "Set Synchronized Tx-Strobe ";
            this.button113.UseVisualStyleBackColor = true;
            this.button113.Click += new System.EventHandler(this.button113_Click);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(253, 567);
            this.textBox13.MaxLength = 30;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(129, 26);
            this.textBox13.TabIndex = 78;
            this.textBox13.Text = "00";
            this.textBox13.TextChanged += new System.EventHandler(this.textBox13_TextChanged);
            // 
            // button112
            // 
            this.button112.Location = new System.Drawing.Point(0, 569);
            this.button112.Name = "button112";
            this.button112.Size = new System.Drawing.Size(244, 23);
            this.button112.TabIndex = 77;
            this.button112.Text = "Set SEU Recover ";
            this.button112.UseVisualStyleBackColor = true;
            this.button112.Click += new System.EventHandler(this.button112_Click);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(253, 536);
            this.textBox12.MaxLength = 30;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(129, 26);
            this.textBox12.TabIndex = 76;
            this.textBox12.Text = "00";
            this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            // 
            // button111
            // 
            this.button111.Location = new System.Drawing.Point(0, 538);
            this.button111.Name = "button111";
            this.button111.Size = new System.Drawing.Size(244, 23);
            this.button111.TabIndex = 75;
            this.button111.Text = "Set RF Gen. Enable ";
            this.button111.UseVisualStyleBackColor = true;
            this.button111.Click += new System.EventHandler(this.button111_Click);
            // 
            // textBox_RFGenParms
            // 
            this.textBox_RFGenParms.Location = new System.Drawing.Point(253, 502);
            this.textBox_RFGenParms.MaxLength = 30;
            this.textBox_RFGenParms.Name = "textBox_RFGenParms";
            this.textBox_RFGenParms.Size = new System.Drawing.Size(129, 26);
            this.textBox_RFGenParms.TabIndex = 74;
            this.textBox_RFGenParms.Text = "0000 0000 0000";
            this.textBox_RFGenParms.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // button_SetRFGen
            // 
            this.button_SetRFGen.Location = new System.Drawing.Point(0, 504);
            this.button_SetRFGen.Name = "button_SetRFGen";
            this.button_SetRFGen.Size = new System.Drawing.Size(244, 23);
            this.button_SetRFGen.TabIndex = 73;
            this.button_SetRFGen.Text = "Set RF Gen. Parameters ";
            this.button_SetRFGen.UseVisualStyleBackColor = true;
            this.button_SetRFGen.Click += new System.EventHandler(this.button110_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(253, 469);
            this.textBox10.MaxLength = 30;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(129, 26);
            this.textBox10.TabIndex = 72;
            this.textBox10.Text = "00";
            this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // button58
            // 
            this.button58.Location = new System.Drawing.Point(0, 471);
            this.button58.Name = "button58";
            this.button58.Size = new System.Drawing.Size(244, 23);
            this.button58.TabIndex = 71;
            this.button58.Text = "Set GP Enable ";
            this.button58.UseVisualStyleBackColor = true;
            this.button58.Click += new System.EventHandler(this.button58_Click_1);
            // 
            // textBox_PulseGenParms
            // 
            this.textBox_PulseGenParms.Location = new System.Drawing.Point(253, 438);
            this.textBox_PulseGenParms.MaxLength = 30;
            this.textBox_PulseGenParms.Name = "textBox_PulseGenParms";
            this.textBox_PulseGenParms.Size = new System.Drawing.Size(129, 26);
            this.textBox_PulseGenParms.TabIndex = 70;
            this.textBox_PulseGenParms.Text = "0000 0000 0000";
            this.textBox_PulseGenParms.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // button_GPparms
            // 
            this.button_GPparms.Location = new System.Drawing.Point(0, 440);
            this.button_GPparms.Name = "button_GPparms";
            this.button_GPparms.Size = new System.Drawing.Size(244, 23);
            this.button_GPparms.TabIndex = 69;
            this.button_GPparms.Text = "Set GP Parameters ";
            this.button_GPparms.UseVisualStyleBackColor = true;
            this.button_GPparms.Click += new System.EventHandler(this.button57_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(253, 407);
            this.textBox8.MaxLength = 30;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(129, 26);
            this.textBox8.TabIndex = 68;
            this.textBox8.Text = "00";
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // button56
            // 
            this.button56.Location = new System.Drawing.Point(0, 409);
            this.button56.Name = "button56";
            this.button56.Size = new System.Drawing.Size(244, 23);
            this.button56.TabIndex = 67;
            this.button56.Text = "Set DCA Discretes ";
            this.button56.UseVisualStyleBackColor = true;
            this.button56.Click += new System.EventHandler(this.button56_Click_1);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(253, 378);
            this.textBox7.MaxLength = 30;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(129, 26);
            this.textBox7.TabIndex = 66;
            this.textBox7.Text = "00";
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // button55
            // 
            this.button55.Location = new System.Drawing.Point(0, 380);
            this.button55.Name = "button55";
            this.button55.Size = new System.Drawing.Size(244, 23);
            this.button55.TabIndex = 65;
            this.button55.Text = "Set Freq. Band ";
            this.button55.UseVisualStyleBackColor = true;
            this.button55.Click += new System.EventHandler(this.button55_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(253, 349);
            this.textBox6.MaxLength = 30;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(129, 26);
            this.textBox6.TabIndex = 64;
            this.textBox6.Text = "00";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // button54
            // 
            this.button54.Location = new System.Drawing.Point(0, 351);
            this.button54.Name = "button54";
            this.button54.Size = new System.Drawing.Size(244, 23);
            this.button54.TabIndex = 63;
            this.button54.Text = "Set OUT-TUNE ";
            this.button54.UseVisualStyleBackColor = true;
            this.button54.Click += new System.EventHandler(this.button54_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(253, 320);
            this.textBox5.MaxLength = 30;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(129, 26);
            this.textBox5.TabIndex = 62;
            this.textBox5.Text = "00";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // button53
            // 
            this.button53.Location = new System.Drawing.Point(0, 322);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(244, 23);
            this.button53.TabIndex = 61;
            this.button53.Text = "Set TX-STROBE ";
            this.button53.UseVisualStyleBackColor = true;
            this.button53.Click += new System.EventHandler(this.button53_Click_1);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(253, 291);
            this.textBox4.MaxLength = 30;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(129, 26);
            this.textBox4.TabIndex = 60;
            this.textBox4.Text = "00";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button51
            // 
            this.button51.Location = new System.Drawing.Point(0, 293);
            this.button51.Name = "button51";
            this.button51.Size = new System.Drawing.Size(244, 23);
            this.button51.TabIndex = 59;
            this.button51.Text = "Set Int_Set_Preserve ";
            this.button51.UseVisualStyleBackColor = true;
            this.button51.Click += new System.EventHandler(this.button51_Click);
            // 
            // button50
            // 
            this.button50.Location = new System.Drawing.Point(0, 265);
            this.button50.Name = "button50";
            this.button50.Size = new System.Drawing.Size(244, 23);
            this.button50.TabIndex = 58;
            this.button50.Text = "Get Simulator Status";
            this.button50.UseVisualStyleBackColor = true;
            this.button50.Click += new System.EventHandler(this.button50_Click_1);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(253, 233);
            this.textBox3.MaxLength = 30;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(129, 26);
            this.textBox3.TabIndex = 57;
            this.textBox3.Text = "00";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button49
            // 
            this.button49.Location = new System.Drawing.Point(0, 235);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(244, 23);
            this.button49.TabIndex = 56;
            this.button49.Text = "Set TX-INHIBIT Enable ";
            this.button49.UseVisualStyleBackColor = true;
            this.button49.Click += new System.EventHandler(this.button49_Click_1);
            // 
            // textBox_TxInhibit
            // 
            this.textBox_TxInhibit.Location = new System.Drawing.Point(253, 202);
            this.textBox_TxInhibit.MaxLength = 30;
            this.textBox_TxInhibit.Name = "textBox_TxInhibit";
            this.textBox_TxInhibit.Size = new System.Drawing.Size(129, 26);
            this.textBox_TxInhibit.TabIndex = 55;
            this.textBox_TxInhibit.Text = "0000 0000 0000";
            this.textBox_TxInhibit.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // button47
            // 
            this.button47.Location = new System.Drawing.Point(0, 204);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(244, 23);
            this.button47.TabIndex = 37;
            this.button47.Text = "Set TX-INHIBIT Params ";
            this.button47.UseVisualStyleBackColor = true;
            this.button47.Click += new System.EventHandler(this.button47_Click);
            // 
            // button48
            // 
            this.button48.Location = new System.Drawing.Point(-2, 126);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(244, 23);
            this.button48.TabIndex = 36;
            this.button48.Text = "Get Simulator serial number";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.button48_Click_2);
            // 
            // button108
            // 
            this.button108.Location = new System.Drawing.Point(0, 6);
            this.button108.Name = "button108";
            this.button108.Size = new System.Drawing.Size(244, 23);
            this.button108.TabIndex = 35;
            this.button108.Text = "Get Simulator ID";
            this.button108.UseVisualStyleBackColor = true;
            this.button108.Click += new System.EventHandler(this.button108_Click);
            // 
            // button109
            // 
            this.button109.Location = new System.Drawing.Point(0, 36);
            this.button109.Name = "button109";
            this.button109.Size = new System.Drawing.Size(244, 23);
            this.button109.TabIndex = 10;
            this.button109.Text = "Get Simulator Software version";
            this.button109.UseVisualStyleBackColor = true;
            this.button109.Click += new System.EventHandler(this.button_GetSoftwareVersion_Click);
            // 
            // button45
            // 
            this.button45.Location = new System.Drawing.Point(2, 65);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(244, 23);
            this.button45.TabIndex = 11;
            this.button45.Text = "Get Simulator Firmware version";
            this.button45.UseVisualStyleBackColor = true;
            this.button45.Click += new System.EventHandler(this.button45_Click);
            // 
            // button46
            // 
            this.button46.Location = new System.Drawing.Point(0, 98);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(244, 23);
            this.button46.TabIndex = 12;
            this.button46.Text = "Get Simulator Hardware version";
            this.button46.UseVisualStyleBackColor = true;
            this.button46.Click += new System.EventHandler(this.button46_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox22);
            this.tabPage2.Controls.Add(this.button122);
            this.tabPage2.Controls.Add(this.textBox21);
            this.tabPage2.Controls.Add(this.button121);
            this.tabPage2.Controls.Add(this.textBox20);
            this.tabPage2.Controls.Add(this.button120);
            this.tabPage2.Controls.Add(this.textBox19);
            this.tabPage2.Controls.Add(this.button119);
            this.tabPage2.Controls.Add(this.textBox_ControlCal);
            this.tabPage2.Controls.Add(this.button118);
            this.tabPage2.Controls.Add(this.textBox17);
            this.tabPage2.Controls.Add(this.textBox_SetSystemMode);
            this.tabPage2.Controls.Add(this.button89);
            this.tabPage2.Controls.Add(this.textBox_SetDCAWithBusMode);
            this.tabPage2.Controls.Add(this.button87);
            this.tabPage2.Controls.Add(this.textBox_SetVVAAtt);
            this.tabPage2.Controls.Add(this.button88);
            this.tabPage2.Controls.Add(this.textBox_SetPSUOutput);
            this.tabPage2.Controls.Add(this.button69);
            this.tabPage2.Controls.Add(this.button68);
            this.tabPage2.Controls.Add(this.button67);
            this.tabPage2.Controls.Add(this.button66);
            this.tabPage2.Controls.Add(this.button65);
            this.tabPage2.Controls.Add(this.textBox_SetADCMode);
            this.tabPage2.Controls.Add(this.button64);
            this.tabPage2.Controls.Add(this.button63);
            this.tabPage2.Controls.Add(this.button62);
            this.tabPage2.Controls.Add(this.button61);
            this.tabPage2.Controls.Add(this.button60);
            this.tabPage2.Controls.Add(this.button59);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(949, 609);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WB UUT";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(251, 584);
            this.textBox22.MaxLength = 30;
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(130, 26);
            this.textBox22.TabIndex = 77;
            this.textBox22.Text = "00";
            this.textBox22.TextChanged += new System.EventHandler(this.textBox22_TextChanged);
            // 
            // button122
            // 
            this.button122.Location = new System.Drawing.Point(4, 585);
            this.button122.Name = "button122";
            this.button122.Size = new System.Drawing.Size(244, 23);
            this.button122.TabIndex = 76;
            this.button122.Text = "Erase flash";
            this.button122.UseVisualStyleBackColor = true;
            this.button122.Click += new System.EventHandler(this.button122_Click);
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(253, 554);
            this.textBox21.MaxLength = 30;
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(693, 26);
            this.textBox21.TabIndex = 75;
            this.textBox21.Text = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0" +
    "000 0000 0000 0000 0000 0000 ";
            this.textBox21.TextChanged += new System.EventHandler(this.textBox21_TextChanged);
            // 
            // button121
            // 
            this.button121.Location = new System.Drawing.Point(4, 557);
            this.button121.Name = "button121";
            this.button121.Size = new System.Drawing.Size(244, 23);
            this.button121.TabIndex = 74;
            this.button121.Text = "Write Flash";
            this.button121.UseVisualStyleBackColor = true;
            this.button121.Click += new System.EventHandler(this.button121_Click);
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(254, 525);
            this.textBox20.MaxLength = 30;
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(130, 26);
            this.textBox20.TabIndex = 73;
            this.textBox20.Text = "0000";
            this.textBox20.TextChanged += new System.EventHandler(this.textBox20_TextChanged);
            // 
            // button120
            // 
            this.button120.Location = new System.Drawing.Point(4, 526);
            this.button120.Name = "button120";
            this.button120.Size = new System.Drawing.Size(244, 23);
            this.button120.TabIndex = 72;
            this.button120.Text = "Read Flash ";
            this.button120.UseVisualStyleBackColor = true;
            this.button120.Click += new System.EventHandler(this.button120_Click);
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(253, 494);
            this.textBox19.MaxLength = 30;
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(693, 26);
            this.textBox19.TabIndex = 71;
            this.textBox19.Text = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0" +
    "000 0000 0000 0000 0000 0000 ";
            this.textBox19.TextChanged += new System.EventHandler(this.textBox19_TextChanged);
            // 
            // button119
            // 
            this.button119.Location = new System.Drawing.Point(4, 497);
            this.button119.Name = "button119";
            this.button119.Size = new System.Drawing.Size(244, 23);
            this.button119.TabIndex = 70;
            this.button119.Text = "Set ADC value in debug mode";
            this.button119.UseVisualStyleBackColor = true;
            this.button119.Click += new System.EventHandler(this.button119_Click);
            // 
            // textBox_ControlCal
            // 
            this.textBox_ControlCal.Location = new System.Drawing.Point(251, 465);
            this.textBox_ControlCal.MaxLength = 30;
            this.textBox_ControlCal.Name = "textBox_ControlCal";
            this.textBox_ControlCal.Size = new System.Drawing.Size(130, 26);
            this.textBox_ControlCal.TabIndex = 69;
            this.textBox_ControlCal.Text = "00";
            this.textBox_ControlCal.TextChanged += new System.EventHandler(this.textBox_ControlCal_TextChanged);
            // 
            // button118
            // 
            this.button118.Location = new System.Drawing.Point(4, 466);
            this.button118.Name = "button118";
            this.button118.Size = new System.Drawing.Size(244, 23);
            this.button118.TabIndex = 68;
            this.button118.Text = "Control CAL_SAR switches ";
            this.button118.UseVisualStyleBackColor = true;
            this.button118.Click += new System.EventHandler(this.button118_Click);
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(251, 436);
            this.textBox17.MaxLength = 30;
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(130, 26);
            this.textBox17.TabIndex = 67;
            this.textBox17.Text = "00";
            this.textBox17.TextChanged += new System.EventHandler(this.textBox17_TextChanged);
            // 
            // textBox_SetSystemMode
            // 
            this.textBox_SetSystemMode.Location = new System.Drawing.Point(252, 335);
            this.textBox_SetSystemMode.MaxLength = 30;
            this.textBox_SetSystemMode.Name = "textBox_SetSystemMode";
            this.textBox_SetSystemMode.Size = new System.Drawing.Size(156, 26);
            this.textBox_SetSystemMode.TabIndex = 66;
            this.textBox_SetSystemMode.Text = "0000";
            this.textBox_SetSystemMode.TextChanged += new System.EventHandler(this.textBox_Erase4KsectorQSPI_TextChanged);
            // 
            // button89
            // 
            this.button89.Location = new System.Drawing.Point(3, 338);
            this.button89.Name = "button89";
            this.button89.Size = new System.Drawing.Size(244, 23);
            this.button89.TabIndex = 65;
            this.button89.Text = "Set System Mode";
            this.button89.UseVisualStyleBackColor = true;
            this.button89.Click += new System.EventHandler(this.button89_Click);
            this.button89.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button89_MouseDown);
            // 
            // textBox_SetDCAWithBusMode
            // 
            this.textBox_SetDCAWithBusMode.Location = new System.Drawing.Point(252, 295);
            this.textBox_SetDCAWithBusMode.MaxLength = 30;
            this.textBox_SetDCAWithBusMode.Name = "textBox_SetDCAWithBusMode";
            this.textBox_SetDCAWithBusMode.Size = new System.Drawing.Size(156, 26);
            this.textBox_SetDCAWithBusMode.TabIndex = 64;
            this.textBox_SetDCAWithBusMode.Text = "0000";
            this.textBox_SetDCAWithBusMode.TextChanged += new System.EventHandler(this.textBox_ReadQSPIFlashData_TextChanged);
            // 
            // button87
            // 
            this.button87.Location = new System.Drawing.Point(3, 298);
            this.button87.Name = "button87";
            this.button87.Size = new System.Drawing.Size(244, 23);
            this.button87.TabIndex = 63;
            this.button87.Text = "Set DCA with Bus Mode";
            this.button87.UseVisualStyleBackColor = true;
            this.button87.Click += new System.EventHandler(this.button87_Click);
            this.button87.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button87_MouseDown);
            // 
            // textBox_SetVVAAtt
            // 
            this.textBox_SetVVAAtt.Location = new System.Drawing.Point(252, 262);
            this.textBox_SetVVAAtt.MaxLength = 30;
            this.textBox_SetVVAAtt.Name = "textBox_SetVVAAtt";
            this.textBox_SetVVAAtt.Size = new System.Drawing.Size(156, 26);
            this.textBox_SetVVAAtt.TabIndex = 62;
            this.textBox_SetVVAAtt.Text = "0000";
            this.textBox_SetVVAAtt.TextChanged += new System.EventHandler(this.textBox_WriteQSPIFlashData_TextChanged);
            // 
            // button88
            // 
            this.button88.Location = new System.Drawing.Point(3, 265);
            this.button88.Name = "button88";
            this.button88.Size = new System.Drawing.Size(244, 23);
            this.button88.TabIndex = 61;
            this.button88.Text = "Set VVA Attenuation";
            this.button88.UseVisualStyleBackColor = true;
            this.button88.Click += new System.EventHandler(this.button88_Click);
            this.button88.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button88_MouseDown);
            // 
            // textBox_SetPSUOutput
            // 
            this.textBox_SetPSUOutput.Location = new System.Drawing.Point(252, 231);
            this.textBox_SetPSUOutput.MaxLength = 30;
            this.textBox_SetPSUOutput.Name = "textBox_SetPSUOutput";
            this.textBox_SetPSUOutput.Size = new System.Drawing.Size(129, 26);
            this.textBox_SetPSUOutput.TabIndex = 54;
            this.textBox_SetPSUOutput.Text = "0000 0000 0000 0000";
            this.textBox_SetPSUOutput.TextChanged += new System.EventHandler(this.textBox_SetTCXOTrim_TextChanged);
            // 
            // button69
            // 
            this.button69.Location = new System.Drawing.Point(3, 234);
            this.button69.Name = "button69";
            this.button69.Size = new System.Drawing.Size(244, 23);
            this.button69.TabIndex = 53;
            this.button69.Text = "Set PSU Output Voltage";
            this.button69.UseVisualStyleBackColor = true;
            this.button69.Click += new System.EventHandler(this.button69_Click);
            this.button69.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button69_MouseDown);
            // 
            // button68
            // 
            this.button68.Location = new System.Drawing.Point(3, 201);
            this.button68.Name = "button68";
            this.button68.Size = new System.Drawing.Size(244, 23);
            this.button68.TabIndex = 50;
            this.button68.Text = "Get Discrete Status – Bus mode";
            this.button68.UseVisualStyleBackColor = true;
            this.button68.Click += new System.EventHandler(this.button68_Click);
            this.button68.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button68_MouseDown);
            // 
            // button67
            // 
            this.button67.Location = new System.Drawing.Point(2, 166);
            this.button67.Name = "button67";
            this.button67.Size = new System.Drawing.Size(244, 23);
            this.button67.TabIndex = 49;
            this.button67.Text = "Get Status";
            this.button67.UseVisualStyleBackColor = true;
            this.button67.Click += new System.EventHandler(this.button67_Click);
            this.button67.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button67_MouseDown);
            // 
            // button66
            // 
            this.button66.Location = new System.Drawing.Point(3, 135);
            this.button66.Name = "button66";
            this.button66.Size = new System.Drawing.Size(244, 23);
            this.button66.TabIndex = 46;
            this.button66.Text = "Get Serial Number";
            this.button66.UseVisualStyleBackColor = true;
            this.button66.Click += new System.EventHandler(this.button66_Click);
            this.button66.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button66_MouseDown);
            // 
            // button65
            // 
            this.button65.Location = new System.Drawing.Point(4, 437);
            this.button65.Name = "button65";
            this.button65.Size = new System.Drawing.Size(244, 23);
            this.button65.TabIndex = 45;
            this.button65.Text = "Set DC4 ON and OFF";
            this.button65.UseVisualStyleBackColor = true;
            this.button65.Click += new System.EventHandler(this.button65_Click);
            this.button65.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button65_MouseDown);
            // 
            // textBox_SetADCMode
            // 
            this.textBox_SetADCMode.Location = new System.Drawing.Point(254, 377);
            this.textBox_SetADCMode.MaxLength = 30;
            this.textBox_SetADCMode.Name = "textBox_SetADCMode";
            this.textBox_SetADCMode.Size = new System.Drawing.Size(130, 26);
            this.textBox_SetADCMode.TabIndex = 43;
            this.textBox_SetADCMode.Text = "0000";
            this.textBox_SetADCMode.TextChanged += new System.EventHandler(this.textBox_SetSyestemState_TextChanged);
            // 
            // button64
            // 
            this.button64.Location = new System.Drawing.Point(4, 378);
            this.button64.Name = "button64";
            this.button64.Size = new System.Drawing.Size(244, 23);
            this.button64.TabIndex = 42;
            this.button64.Text = "Set ADC System Mode";
            this.button64.UseVisualStyleBackColor = true;
            this.button64.Click += new System.EventHandler(this.button64_Click);
            this.button64.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button64_MouseDown);
            // 
            // button63
            // 
            this.button63.Location = new System.Drawing.Point(4, 408);
            this.button63.Name = "button63";
            this.button63.Size = new System.Drawing.Size(244, 23);
            this.button63.TabIndex = 41;
            this.button63.Text = "Get System Table Indexes";
            this.button63.UseVisualStyleBackColor = true;
            this.button63.Click += new System.EventHandler(this.button63_Click);
            this.button63.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button63_MouseDown);
            // 
            // button62
            // 
            this.button62.Location = new System.Drawing.Point(3, 103);
            this.button62.Name = "button62";
            this.button62.Size = new System.Drawing.Size(244, 23);
            this.button62.TabIndex = 38;
            this.button62.Text = "Get Hardware Version";
            this.button62.UseVisualStyleBackColor = true;
            this.button62.Click += new System.EventHandler(this.button62_Click);
            this.button62.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button62_MouseDown);
            // 
            // button61
            // 
            this.button61.Location = new System.Drawing.Point(3, 72);
            this.button61.Name = "button61";
            this.button61.Size = new System.Drawing.Size(244, 23);
            this.button61.TabIndex = 35;
            this.button61.Text = "Get Firmware Version";
            this.button61.UseVisualStyleBackColor = true;
            this.button61.Click += new System.EventHandler(this.button61_Click);
            this.button61.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button61_MouseDown);
            // 
            // button60
            // 
            this.button60.Location = new System.Drawing.Point(2, 42);
            this.button60.Name = "button60";
            this.button60.Size = new System.Drawing.Size(244, 23);
            this.button60.TabIndex = 32;
            this.button60.Text = "Get Software Version";
            this.button60.UseVisualStyleBackColor = true;
            this.button60.Click += new System.EventHandler(this.button60_Click);
            this.button60.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button60_MouseDown);
            // 
            // button59
            // 
            this.button59.Location = new System.Drawing.Point(3, 11);
            this.button59.Name = "button59";
            this.button59.Size = new System.Drawing.Size(244, 23);
            this.button59.TabIndex = 29;
            this.button59.Text = "Get ID";
            this.button59.UseVisualStyleBackColor = true;
            this.button59.Click += new System.EventHandler(this.button59_Click);
            this.button59.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button59_MouseClick);
            this.button59.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button59_MouseDown);
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.richTextBox_SSPA);
            this.groupBox32.Controls.Add(this.checkBox_RecordMiniAda);
            this.groupBox32.Controls.Add(this.checkBox_PauseMiniAda);
            this.groupBox32.Controls.Add(this.button_ClearMiniAda);
            this.groupBox32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox32.Location = new System.Drawing.Point(985, 3);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(558, 668);
            this.groupBox32.TabIndex = 9;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "SSPA Monitor";
            // 
            // richTextBox_SSPA
            // 
            this.richTextBox_SSPA.BackColor = System.Drawing.Color.LightGray;
            this.richTextBox_SSPA.EnableAutoDragDrop = true;
            this.richTextBox_SSPA.Location = new System.Drawing.Point(6, 17);
            this.richTextBox_SSPA.Name = "richTextBox_SSPA";
            this.richTextBox_SSPA.Size = new System.Drawing.Size(553, 607);
            this.richTextBox_SSPA.TabIndex = 0;
            this.richTextBox_SSPA.Text = "";
            // 
            // checkBox_RecordMiniAda
            // 
            this.checkBox_RecordMiniAda.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordMiniAda.AutoSize = true;
            this.checkBox_RecordMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordMiniAda.Location = new System.Drawing.Point(7, 630);
            this.checkBox_RecordMiniAda.Name = "checkBox_RecordMiniAda";
            this.checkBox_RecordMiniAda.Size = new System.Drawing.Size(99, 26);
            this.checkBox_RecordMiniAda.TabIndex = 7;
            this.checkBox_RecordMiniAda.Text = "Record Log";
            this.checkBox_RecordMiniAda.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseMiniAda
            // 
            this.checkBox_PauseMiniAda.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_PauseMiniAda.AutoSize = true;
            this.checkBox_PauseMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_PauseMiniAda.Location = new System.Drawing.Point(112, 630);
            this.checkBox_PauseMiniAda.Name = "checkBox_PauseMiniAda";
            this.checkBox_PauseMiniAda.Size = new System.Drawing.Size(62, 26);
            this.checkBox_PauseMiniAda.TabIndex = 5;
            this.checkBox_PauseMiniAda.Text = "Pause";
            this.checkBox_PauseMiniAda.UseVisualStyleBackColor = true;
            // 
            // button_ClearMiniAda
            // 
            this.button_ClearMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearMiniAda.Location = new System.Drawing.Point(180, 630);
            this.button_ClearMiniAda.Name = "button_ClearMiniAda";
            this.button_ClearMiniAda.Size = new System.Drawing.Size(62, 26);
            this.button_ClearMiniAda.TabIndex = 6;
            this.button_ClearMiniAda.Text = "Clear";
            this.button_ClearMiniAda.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox43);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1547, 682);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Text = "3038 - WB PAA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox43
            // 
            this.groupBox43.Controls.Add(this.groupBox48);
            this.groupBox43.Controls.Add(this.groupBox38);
            this.groupBox43.Controls.Add(this.tabControl1);
            this.groupBox43.Location = new System.Drawing.Point(3, 8);
            this.groupBox43.Name = "groupBox43";
            this.groupBox43.Size = new System.Drawing.Size(1541, 667);
            this.groupBox43.TabIndex = 0;
            this.groupBox43.TabStop = false;
            this.groupBox43.Text = "3038 - WB PAA";
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.Red;
            this.button30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button30.Location = new System.Drawing.Point(6, 79);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(139, 45);
            this.button30.TabIndex = 21;
            this.button30.Text = "Write all to flash";
            this.button30.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(6, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 45);
            this.button2.TabIndex = 18;
            this.button2.Text = "Read all from flash ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Location = new System.Drawing.Point(5, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1358, 644);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox37);
            this.tabPage6.Controls.Add(this.button71);
            this.tabPage6.Controls.Add(this.groupBox47);
            this.tabPage6.Controls.Add(this.groupBox35);
            this.tabPage6.Controls.Add(this.groupBox46);
            this.tabPage6.Controls.Add(this.groupBox45);
            this.tabPage6.Controls.Add(this.groupBox34);
            this.tabPage6.Controls.Add(this.groupBox44);
            this.tabPage6.Controls.Add(this.groupBox1);
            this.tabPage6.Controls.Add(this.groupBox33);
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1350, 613);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Main";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.checkBox4);
            this.groupBox37.Controls.Add(this.checkBox3);
            this.groupBox37.Controls.Add(this.checkBox9);
            this.groupBox37.Controls.Add(this.checkBox2);
            this.groupBox37.Controls.Add(this.button73);
            this.groupBox37.Controls.Add(this.label114);
            this.groupBox37.Controls.Add(this.label113);
            this.groupBox37.Controls.Add(this.label112);
            this.groupBox37.Controls.Add(this.textBox85);
            this.groupBox37.Controls.Add(this.label111);
            this.groupBox37.Controls.Add(this.label110);
            this.groupBox37.Controls.Add(this.textBox82);
            this.groupBox37.Controls.Add(this.label107);
            this.groupBox37.Controls.Add(this.textBox83);
            this.groupBox37.Controls.Add(this.label108);
            this.groupBox37.Controls.Add(this.textBox84);
            this.groupBox37.Controls.Add(this.label109);
            this.groupBox37.Location = new System.Drawing.Point(728, 332);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(616, 149);
            this.groupBox37.TabIndex = 17;
            this.groupBox37.TabStop = false;
            // 
            // checkBox4
            // 
            this.checkBox4.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(550, 55);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(36, 28);
            this.checkBox4.TabIndex = 28;
            this.checkBox4.Text = "On";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged_1);
            // 
            // checkBox3
            // 
            this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(483, 53);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(36, 28);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Text = "On";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged_1);
            // 
            // checkBox9
            // 
            this.checkBox9.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(406, 52);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(36, 28);
            this.checkBox9.TabIndex = 26;
            this.checkBox9.Text = "On";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(254, 55);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(36, 28);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "On";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_1);
            // 
            // button73
            // 
            this.button73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button73.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button73.Location = new System.Drawing.Point(274, 89);
            this.button73.Name = "button73";
            this.button73.Size = new System.Drawing.Size(151, 41);
            this.button73.TabIndex = 17;
            this.button73.Text = "Strobe";
            this.button73.UseVisualStyleBackColor = false;
            this.button73.Click += new System.EventHandler(this.button73_Click_3);
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(547, 29);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(63, 18);
            this.label114.TabIndex = 24;
            this.label114.Text = "Preserve";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(469, 32);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(72, 18);
            this.label113.TabIndex = 22;
            this.label113.Text = "OVT check";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(382, 30);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(81, 18);
            this.label112.TabIndex = 20;
            this.label112.Text = "SEU recover";
            // 
            // textBox85
            // 
            this.textBox85.Location = new System.Drawing.Point(312, 57);
            this.textBox85.Name = "textBox85";
            this.textBox85.Size = new System.Drawing.Size(57, 26);
            this.textBox85.TabIndex = 19;
            this.textBox85.Text = "0";
            this.textBox85.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox85_KeyDown);
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(309, 31);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(58, 18);
            this.label111.TabIndex = 18;
            this.label111.Text = "CAL SAR";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(255, 31);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(32, 18);
            this.label110.TabIndex = 16;
            this.label110.Text = "DC4";
            // 
            // textBox82
            // 
            this.textBox82.Location = new System.Drawing.Point(180, 57);
            this.textBox82.Name = "textBox82";
            this.textBox82.Size = new System.Drawing.Size(57, 26);
            this.textBox82.TabIndex = 15;
            this.textBox82.Text = "0";
            this.textBox82.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox82_KeyDown);
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(177, 31);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(50, 18);
            this.label107.TabIndex = 14;
            this.label107.Text = "ATT bit";
            // 
            // textBox83
            // 
            this.textBox83.Location = new System.Drawing.Point(95, 57);
            this.textBox83.Name = "textBox83";
            this.textBox83.Size = new System.Drawing.Size(57, 26);
            this.textBox83.TabIndex = 13;
            this.textBox83.Text = "0";
            this.textBox83.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox83_KeyDown);
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(97, 30);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(42, 18);
            this.label108.TabIndex = 12;
            this.label108.Text = "FT bit";
            // 
            // textBox84
            // 
            this.textBox84.Location = new System.Drawing.Point(20, 57);
            this.textBox84.Name = "textBox84";
            this.textBox84.Size = new System.Drawing.Size(57, 26);
            this.textBox84.TabIndex = 11;
            this.textBox84.Text = "0";
            this.textBox84.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox84_KeyDown);
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(13, 31);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(56, 18);
            this.label109.TabIndex = 1;
            this.label109.Text = "Freq bit";
            // 
            // button71
            // 
            this.button71.Location = new System.Drawing.Point(604, 190);
            this.button71.Name = "button71";
            this.button71.Size = new System.Drawing.Size(75, 23);
            this.button71.TabIndex = 16;
            this.button71.Text = "Save CSV";
            this.button71.UseVisualStyleBackColor = true;
            // 
            // groupBox47
            // 
            this.groupBox47.Controls.Add(this.button72);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT25);
            this.groupBox47.Controls.Add(this.label69);
            this.groupBox47.Controls.Add(this.label120);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT26);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT23);
            this.groupBox47.Controls.Add(this.label56);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT24);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT12);
            this.groupBox47.Controls.Add(this.label57);
            this.groupBox47.Controls.Add(this.label67);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT22);
            this.groupBox47.Controls.Add(this.label58);
            this.groupBox47.Controls.Add(this.label70);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT21);
            this.groupBox47.Controls.Add(this.label59);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT20);
            this.groupBox47.Controls.Add(this.label60);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT19);
            this.groupBox47.Controls.Add(this.label61);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT18);
            this.groupBox47.Controls.Add(this.label62);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT17);
            this.groupBox47.Controls.Add(this.label63);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT16);
            this.groupBox47.Controls.Add(this.label64);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT15);
            this.groupBox47.Controls.Add(this.label65);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT14);
            this.groupBox47.Controls.Add(this.label66);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT13);
            this.groupBox47.Controls.Add(this.label55);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT1);
            this.groupBox47.Controls.Add(this.label54);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT11);
            this.groupBox47.Controls.Add(this.label53);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT10);
            this.groupBox47.Controls.Add(this.label52);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT9);
            this.groupBox47.Controls.Add(this.label51);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT8);
            this.groupBox47.Controls.Add(this.label50);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT7);
            this.groupBox47.Controls.Add(this.label49);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT6);
            this.groupBox47.Controls.Add(this.label40);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT5);
            this.groupBox47.Controls.Add(this.label39);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT4);
            this.groupBox47.Controls.Add(this.label33);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT3);
            this.groupBox47.Controls.Add(this.label32);
            this.groupBox47.Controls.Add(this.textBox_StatusUUT2);
            this.groupBox47.Controls.Add(this.groupBox39);
            this.groupBox47.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox47.Location = new System.Drawing.Point(6, 216);
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Size = new System.Drawing.Size(704, 391);
            this.groupBox47.TabIndex = 15;
            this.groupBox47.TabStop = false;
            this.groupBox47.Text = " Status UUT";
            // 
            // button72
            // 
            this.button72.Location = new System.Drawing.Point(487, 336);
            this.button72.Name = "button72";
            this.button72.Size = new System.Drawing.Size(195, 45);
            this.button72.TabIndex = 17;
            this.button72.Text = "Get Status";
            this.button72.UseVisualStyleBackColor = true;
            this.button72.Click += new System.EventHandler(this.button72_Click_4);
            // 
            // textBox_StatusUUT25
            // 
            this.textBox_StatusUUT25.Location = new System.Drawing.Point(581, 272);
            this.textBox_StatusUUT25.Name = "textBox_StatusUUT25";
            this.textBox_StatusUUT25.ReadOnly = true;
            this.textBox_StatusUUT25.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT25.TabIndex = 57;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.Black;
            this.label69.Location = new System.Drawing.Point(487, 277);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(76, 19);
            this.label69.TabIndex = 58;
            this.label69.Text = "DC1 value";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label120.ForeColor = System.Drawing.Color.Black;
            this.label120.Location = new System.Drawing.Point(263, 363);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(90, 19);
            this.label120.TabIndex = 75;
            this.label120.Text = "CAL SAR BIT";
            // 
            // textBox_StatusUUT26
            // 
            this.textBox_StatusUUT26.Location = new System.Drawing.Point(581, 306);
            this.textBox_StatusUUT26.Name = "textBox_StatusUUT26";
            this.textBox_StatusUUT26.ReadOnly = true;
            this.textBox_StatusUUT26.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT26.TabIndex = 59;
            // 
            // textBox_StatusUUT23
            // 
            this.textBox_StatusUUT23.Location = new System.Drawing.Point(357, 363);
            this.textBox_StatusUUT23.Name = "textBox_StatusUUT23";
            this.textBox_StatusUUT23.ReadOnly = true;
            this.textBox_StatusUUT23.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT23.TabIndex = 74;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.Color.Black;
            this.label56.Location = new System.Drawing.Point(262, 14);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(85, 19);
            this.label56.TabIndex = 56;
            this.label56.Text = "PRM_temp";
            // 
            // textBox_StatusUUT24
            // 
            this.textBox_StatusUUT24.Location = new System.Drawing.Point(581, 242);
            this.textBox_StatusUUT24.Name = "textBox_StatusUUT24";
            this.textBox_StatusUUT24.ReadOnly = true;
            this.textBox_StatusUUT24.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT24.TabIndex = 61;
            // 
            // textBox_StatusUUT12
            // 
            this.textBox_StatusUUT12.Location = new System.Drawing.Point(356, 9);
            this.textBox_StatusUUT12.Name = "textBox_StatusUUT12";
            this.textBox_StatusUUT12.ReadOnly = true;
            this.textBox_StatusUUT12.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT12.TabIndex = 55;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.Black;
            this.label57.Location = new System.Drawing.Point(263, 338);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(60, 19);
            this.label57.TabIndex = 54;
            this.label57.Text = "DCA bit";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.Black;
            this.label67.Location = new System.Drawing.Point(487, 247);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(77, 19);
            this.label67.TabIndex = 62;
            this.label67.Text = "VVA value";
            // 
            // textBox_StatusUUT22
            // 
            this.textBox_StatusUUT22.Location = new System.Drawing.Point(357, 333);
            this.textBox_StatusUUT22.Name = "textBox_StatusUUT22";
            this.textBox_StatusUUT22.ReadOnly = true;
            this.textBox_StatusUUT22.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT22.TabIndex = 53;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Black;
            this.label58.Location = new System.Drawing.Point(263, 306);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(47, 19);
            this.label58.TabIndex = 52;
            this.label58.Text = "FT bit";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(488, 310);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(76, 19);
            this.label70.TabIndex = 63;
            this.label70.Text = "DC2 value";
            // 
            // textBox_StatusUUT21
            // 
            this.textBox_StatusUUT21.Location = new System.Drawing.Point(357, 301);
            this.textBox_StatusUUT21.Name = "textBox_StatusUUT21";
            this.textBox_StatusUUT21.ReadOnly = true;
            this.textBox_StatusUUT21.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT21.TabIndex = 51;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.Color.Black;
            this.label59.Location = new System.Drawing.Point(263, 273);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(60, 19);
            this.label59.TabIndex = 50;
            this.label59.Text = "freq bit";
            // 
            // textBox_StatusUUT20
            // 
            this.textBox_StatusUUT20.Location = new System.Drawing.Point(357, 268);
            this.textBox_StatusUUT20.Name = "textBox_StatusUUT20";
            this.textBox_StatusUUT20.ReadOnly = true;
            this.textBox_StatusUUT20.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT20.TabIndex = 49;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(263, 241);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(94, 19);
            this.label60.TabIndex = 48;
            this.label60.Text = "Pulse period";
            // 
            // textBox_StatusUUT19
            // 
            this.textBox_StatusUUT19.Location = new System.Drawing.Point(357, 236);
            this.textBox_StatusUUT19.Name = "textBox_StatusUUT19";
            this.textBox_StatusUUT19.ReadOnly = true;
            this.textBox_StatusUUT19.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT19.TabIndex = 47;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.Black;
            this.label61.Location = new System.Drawing.Point(262, 209);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(89, 19);
            this.label61.TabIndex = 46;
            this.label61.Text = "Pulse width";
            // 
            // textBox_StatusUUT18
            // 
            this.textBox_StatusUUT18.Location = new System.Drawing.Point(356, 204);
            this.textBox_StatusUUT18.Name = "textBox_StatusUUT18";
            this.textBox_StatusUUT18.ReadOnly = true;
            this.textBox_StatusUUT18.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT18.TabIndex = 45;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.ForeColor = System.Drawing.Color.Black;
            this.label62.Location = new System.Drawing.Point(262, 177);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(76, 19);
            this.label62.TabIndex = 44;
            this.label62.Text = "PSU temp";
            // 
            // textBox_StatusUUT17
            // 
            this.textBox_StatusUUT17.Location = new System.Drawing.Point(356, 172);
            this.textBox_StatusUUT17.Name = "textBox_StatusUUT17";
            this.textBox_StatusUUT17.ReadOnly = true;
            this.textBox_StatusUUT17.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT17.TabIndex = 43;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.Color.Black;
            this.label63.Location = new System.Drawing.Point(262, 142);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(80, 19);
            this.label63.TabIndex = 42;
            this.label63.Text = "VTM temp";
            // 
            // textBox_StatusUUT16
            // 
            this.textBox_StatusUUT16.Location = new System.Drawing.Point(356, 137);
            this.textBox_StatusUUT16.Name = "textBox_StatusUUT16";
            this.textBox_StatusUUT16.ReadOnly = true;
            this.textBox_StatusUUT16.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT16.TabIndex = 41;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.Color.Black;
            this.label64.Location = new System.Drawing.Point(262, 110);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(85, 19);
            this.label64.TabIndex = 40;
            this.label64.Text = "48V in rush";
            // 
            // textBox_StatusUUT15
            // 
            this.textBox_StatusUUT15.Location = new System.Drawing.Point(356, 105);
            this.textBox_StatusUUT15.Name = "textBox_StatusUUT15";
            this.textBox_StatusUUT15.ReadOnly = true;
            this.textBox_StatusUUT15.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT15.TabIndex = 39;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.Color.Black;
            this.label65.Location = new System.Drawing.Point(262, 78);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(71, 19);
            this.label65.TabIndex = 38;
            this.label65.Text = "48V filter";
            // 
            // textBox_StatusUUT14
            // 
            this.textBox_StatusUUT14.Location = new System.Drawing.Point(356, 73);
            this.textBox_StatusUUT14.Name = "textBox_StatusUUT14";
            this.textBox_StatusUUT14.ReadOnly = true;
            this.textBox_StatusUUT14.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT14.TabIndex = 37;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(262, 44);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(89, 19);
            this.label66.TabIndex = 36;
            this.label66.Text = "48V current";
            // 
            // textBox_StatusUUT13
            // 
            this.textBox_StatusUUT13.Location = new System.Drawing.Point(356, 39);
            this.textBox_StatusUUT13.Name = "textBox_StatusUUT13";
            this.textBox_StatusUUT13.ReadOnly = true;
            this.textBox_StatusUUT13.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT13.TabIndex = 35;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(6, 16);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(136, 19);
            this.label55.TabIndex = 34;
            this.label55.Text = "Main Temperature";
            // 
            // textBox_StatusUUT1
            // 
            this.textBox_StatusUUT1.Location = new System.Drawing.Point(148, 12);
            this.textBox_StatusUUT1.Name = "textBox_StatusUUT1";
            this.textBox_StatusUUT1.ReadOnly = true;
            this.textBox_StatusUUT1.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT1.TabIndex = 33;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.Black;
            this.label54.Location = new System.Drawing.Point(7, 340);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(54, 19);
            this.label54.TabIndex = 32;
            this.label54.Text = "Detect";
            // 
            // textBox_StatusUUT11
            // 
            this.textBox_StatusUUT11.Location = new System.Drawing.Point(149, 336);
            this.textBox_StatusUUT11.Name = "textBox_StatusUUT11";
            this.textBox_StatusUUT11.ReadOnly = true;
            this.textBox_StatusUUT11.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT11.TabIndex = 31;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(7, 308);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(65, 19);
            this.label53.TabIndex = 30;
            this.label53.Text = "Vgg N5V";
            // 
            // textBox_StatusUUT10
            // 
            this.textBox_StatusUUT10.Location = new System.Drawing.Point(149, 304);
            this.textBox_StatusUUT10.Name = "textBox_StatusUUT10";
            this.textBox_StatusUUT10.ReadOnly = true;
            this.textBox_StatusUUT10.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT10.TabIndex = 29;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Black;
            this.label52.Location = new System.Drawing.Point(7, 275);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(60, 19);
            this.label52.TabIndex = 28;
            this.label52.Text = "Vdd_4V";
            // 
            // textBox_StatusUUT9
            // 
            this.textBox_StatusUUT9.Location = new System.Drawing.Point(149, 271);
            this.textBox_StatusUUT9.Name = "textBox_StatusUUT9";
            this.textBox_StatusUUT9.ReadOnly = true;
            this.textBox_StatusUUT9.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT9.TabIndex = 27;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(7, 243);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(60, 19);
            this.label51.TabIndex = 26;
            this.label51.Text = "Vdd_5V";
            // 
            // textBox_StatusUUT8
            // 
            this.textBox_StatusUUT8.Location = new System.Drawing.Point(149, 239);
            this.textBox_StatusUUT8.Name = "textBox_StatusUUT8";
            this.textBox_StatusUUT8.ReadOnly = true;
            this.textBox_StatusUUT8.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT8.TabIndex = 25;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(6, 211);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(60, 19);
            this.label50.TabIndex = 24;
            this.label50.Text = "Vdd_9V";
            // 
            // textBox_StatusUUT7
            // 
            this.textBox_StatusUUT7.Location = new System.Drawing.Point(148, 207);
            this.textBox_StatusUUT7.Name = "textBox_StatusUUT7";
            this.textBox_StatusUUT7.ReadOnly = true;
            this.textBox_StatusUUT7.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT7.TabIndex = 23;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(6, 179);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(68, 19);
            this.label49.TabIndex = 22;
            this.label49.Text = "Vdd_28V";
            // 
            // textBox_StatusUUT6
            // 
            this.textBox_StatusUUT6.Location = new System.Drawing.Point(148, 175);
            this.textBox_StatusUUT6.Name = "textBox_StatusUUT6";
            this.textBox_StatusUUT6.ReadOnly = true;
            this.textBox_StatusUUT6.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT6.TabIndex = 21;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(6, 144);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(81, 19);
            this.label40.TabIndex = 20;
            this.label40.Text = "9V current";
            // 
            // textBox_StatusUUT5
            // 
            this.textBox_StatusUUT5.Location = new System.Drawing.Point(148, 140);
            this.textBox_StatusUUT5.Name = "textBox_StatusUUT5";
            this.textBox_StatusUUT5.ReadOnly = true;
            this.textBox_StatusUUT5.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT5.TabIndex = 19;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(6, 112);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(89, 19);
            this.label39.TabIndex = 18;
            this.label39.Text = "28V current";
            // 
            // textBox_StatusUUT4
            // 
            this.textBox_StatusUUT4.Location = new System.Drawing.Point(148, 108);
            this.textBox_StatusUUT4.Name = "textBox_StatusUUT4";
            this.textBox_StatusUUT4.ReadOnly = true;
            this.textBox_StatusUUT4.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT4.TabIndex = 17;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(6, 80);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(81, 19);
            this.label33.TabIndex = 16;
            this.label33.Text = "5V current";
            // 
            // textBox_StatusUUT3
            // 
            this.textBox_StatusUUT3.Location = new System.Drawing.Point(148, 76);
            this.textBox_StatusUUT3.Name = "textBox_StatusUUT3";
            this.textBox_StatusUUT3.ReadOnly = true;
            this.textBox_StatusUUT3.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT3.TabIndex = 15;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(6, 46);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(85, 19);
            this.label32.TabIndex = 14;
            this.label32.Text = "Main Index";
            // 
            // textBox_StatusUUT2
            // 
            this.textBox_StatusUUT2.Location = new System.Drawing.Point(148, 42);
            this.textBox_StatusUUT2.Name = "textBox_StatusUUT2";
            this.textBox_StatusUUT2.ReadOnly = true;
            this.textBox_StatusUUT2.Size = new System.Drawing.Size(100, 26);
            this.textBox_StatusUUT2.TabIndex = 0;
            // 
            // groupBox39
            // 
            this.groupBox39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox39.Controls.Add(this.label115);
            this.groupBox39.Controls.Add(this.textBox9);
            this.groupBox39.Controls.Add(this.label71);
            this.groupBox39.Controls.Add(this.label74);
            this.groupBox39.Controls.Add(this.textBox60);
            this.groupBox39.Controls.Add(this.label73);
            this.groupBox39.Controls.Add(this.textBox59);
            this.groupBox39.Controls.Add(this.label68);
            this.groupBox39.Controls.Add(this.textBox58);
            this.groupBox39.Controls.Add(this.label72);
            this.groupBox39.Controls.Add(this.textBox56);
            this.groupBox39.Controls.Add(this.textBox57);
            this.groupBox39.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox39.Location = new System.Drawing.Point(463, 14);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(231, 222);
            this.groupBox39.TabIndex = 76;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "Status Simulator";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.ForeColor = System.Drawing.Color.Black;
            this.label115.Location = new System.Drawing.Point(2, 195);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(105, 19);
            this.label115.TabIndex = 75;
            this.label115.Text = "Tx OVT hazard";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(113, 191);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(100, 26);
            this.textBox9.TabIndex = 74;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.Black;
            this.label71.Location = new System.Drawing.Point(19, 36);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(51, 19);
            this.label71.TabIndex = 68;
            this.label71.Text = "Ready";
            this.label71.Click += new System.EventHandler(this.label71_Click);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.Black;
            this.label74.Location = new System.Drawing.Point(20, 164);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(35, 19);
            this.label74.TabIndex = 73;
            this.label74.Text = "SEU";
            this.label74.Click += new System.EventHandler(this.label74_Click);
            // 
            // textBox60
            // 
            this.textBox60.Location = new System.Drawing.Point(113, 160);
            this.textBox60.Name = "textBox60";
            this.textBox60.ReadOnly = true;
            this.textBox60.Size = new System.Drawing.Size(100, 26);
            this.textBox60.TabIndex = 72;
            this.textBox60.TextChanged += new System.EventHandler(this.textBox60_TextChanged);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.Black;
            this.label73.Location = new System.Drawing.Point(20, 134);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(81, 19);
            this.label73.TabIndex = 71;
            this.label73.Text = "Protection";
            this.label73.Click += new System.EventHandler(this.label73_Click);
            // 
            // textBox59
            // 
            this.textBox59.Location = new System.Drawing.Point(113, 126);
            this.textBox59.Name = "textBox59";
            this.textBox59.ReadOnly = true;
            this.textBox59.Size = new System.Drawing.Size(100, 26);
            this.textBox59.TabIndex = 70;
            this.textBox59.TextChanged += new System.EventHandler(this.textBox59_TextChanged);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.Color.Black;
            this.label68.Location = new System.Drawing.Point(9, 99);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(97, 19);
            this.label68.TabIndex = 69;
            this.label68.Text = "Over voltage";
            this.label68.Click += new System.EventHandler(this.label68_Click);
            // 
            // textBox58
            // 
            this.textBox58.Location = new System.Drawing.Point(113, 94);
            this.textBox58.Name = "textBox58";
            this.textBox58.ReadOnly = true;
            this.textBox58.Size = new System.Drawing.Size(100, 26);
            this.textBox58.TabIndex = 64;
            this.textBox58.TextChanged += new System.EventHandler(this.textBox58_TextChanged);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.Black;
            this.label72.Location = new System.Drawing.Point(6, 65);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(106, 19);
            this.label72.TabIndex = 65;
            this.label72.Text = "Under voltage";
            this.label72.Click += new System.EventHandler(this.label72_Click);
            // 
            // textBox56
            // 
            this.textBox56.Location = new System.Drawing.Point(113, 31);
            this.textBox56.Name = "textBox56";
            this.textBox56.ReadOnly = true;
            this.textBox56.Size = new System.Drawing.Size(100, 26);
            this.textBox56.TabIndex = 67;
            this.textBox56.TextChanged += new System.EventHandler(this.textBox56_TextChanged);
            // 
            // textBox57
            // 
            this.textBox57.Location = new System.Drawing.Point(113, 63);
            this.textBox57.Name = "textBox57";
            this.textBox57.ReadOnly = true;
            this.textBox57.Size = new System.Drawing.Size(100, 26);
            this.textBox57.TabIndex = 66;
            this.textBox57.TextChanged += new System.EventHandler(this.textBox57_TextChanged);
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.checkBox8);
            this.groupBox35.Controls.Add(this.button44);
            this.groupBox35.Controls.Add(this.textBox_PulseDelay2);
            this.groupBox35.Controls.Add(this.label104);
            this.groupBox35.Controls.Add(this.textBox_PulsePeriod2);
            this.groupBox35.Controls.Add(this.label105);
            this.groupBox35.Controls.Add(this.textBox_PulseWidth2);
            this.groupBox35.Controls.Add(this.label106);
            this.groupBox35.Location = new System.Drawing.Point(728, 226);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(387, 100);
            this.groupBox35.TabIndex = 18;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "GP pulse gen";
            // 
            // checkBox8
            // 
            this.checkBox8.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(293, 21);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(64, 28);
            this.checkBox8.TabIndex = 19;
            this.checkBox8.Text = "Control";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // button44
            // 
            this.button44.Location = new System.Drawing.Point(243, 60);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(123, 23);
            this.button44.TabIndex = 16;
            this.button44.Text = "Set GP parms";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Click += new System.EventHandler(this.button44_Click);
            // 
            // textBox_PulseDelay2
            // 
            this.textBox_PulseDelay2.Location = new System.Drawing.Point(180, 57);
            this.textBox_PulseDelay2.Name = "textBox_PulseDelay2";
            this.textBox_PulseDelay2.Size = new System.Drawing.Size(57, 26);
            this.textBox_PulseDelay2.TabIndex = 15;
            this.textBox_PulseDelay2.Text = "0";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(177, 31);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(70, 18);
            this.label104.TabIndex = 14;
            this.label104.Text = "Delay (us)";
            // 
            // textBox_PulsePeriod2
            // 
            this.textBox_PulsePeriod2.Location = new System.Drawing.Point(95, 57);
            this.textBox_PulsePeriod2.Name = "textBox_PulsePeriod2";
            this.textBox_PulsePeriod2.Size = new System.Drawing.Size(57, 26);
            this.textBox_PulsePeriod2.TabIndex = 13;
            this.textBox_PulsePeriod2.Text = "16";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(92, 31);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(76, 18);
            this.label105.TabIndex = 12;
            this.label105.Text = "Period (us)";
            // 
            // textBox_PulseWidth2
            // 
            this.textBox_PulseWidth2.Location = new System.Drawing.Point(20, 57);
            this.textBox_PulseWidth2.Name = "textBox_PulseWidth2";
            this.textBox_PulseWidth2.Size = new System.Drawing.Size(57, 26);
            this.textBox_PulseWidth2.TabIndex = 11;
            this.textBox_PulseWidth2.Text = "2";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(13, 31);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(73, 18);
            this.label106.TabIndex = 1;
            this.label106.Text = "Width (us)";
            // 
            // groupBox46
            // 
            this.groupBox46.Controls.Add(this.label38);
            this.groupBox46.Controls.Add(this.label34);
            this.groupBox46.Controls.Add(this.label35);
            this.groupBox46.Controls.Add(this.textBox29);
            this.groupBox46.Controls.Add(this.textBox30);
            this.groupBox46.Controls.Add(this.textBox31);
            this.groupBox46.Controls.Add(this.label36);
            this.groupBox46.Location = new System.Drawing.Point(339, 110);
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Size = new System.Drawing.Size(253, 107);
            this.groupBox46.TabIndex = 14;
            this.groupBox46.TabStop = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(131, 46);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(45, 19);
            this.label38.TabIndex = 14;
            this.label38.Text = "DCA2";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(80, 46);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(45, 19);
            this.label34.TabIndex = 11;
            this.label34.Text = "DCA1";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(16, 47);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(36, 19);
            this.label35.TabIndex = 7;
            this.label35.Text = "VVA";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(71, 71);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(54, 26);
            this.textBox29.TabIndex = 9;
            this.textBox29.Text = "0";
            this.toolTip1.SetToolTip(this.textBox29, "Press Enter to update");
            this.textBox29.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox29_KeyDown);
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(135, 70);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(54, 26);
            this.textBox30.TabIndex = 8;
            this.textBox30.Text = "0";
            this.toolTip1.SetToolTip(this.textBox30, "Press Enter to update");
            this.textBox30.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox30_KeyDown);
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(8, 71);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(54, 26);
            this.textBox31.TabIndex = 7;
            this.textBox31.Text = "0";
            this.toolTip1.SetToolTip(this.textBox31, "Press Enter to update");
            this.textBox31.TextChanged += new System.EventHandler(this.textBox31_TextChanged);
            this.textBox31.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox31_KeyDown);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Red;
            this.label36.Location = new System.Drawing.Point(56, 15);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(133, 23);
            this.label36.TabIndex = 7;
            this.label36.Text = "Set Attenuation";
            // 
            // groupBox45
            // 
            this.groupBox45.Controls.Add(this.label31);
            this.groupBox45.Controls.Add(this.label30);
            this.groupBox45.Controls.Add(this.label29);
            this.groupBox45.Controls.Add(this.label28);
            this.groupBox45.Controls.Add(this.textBox27);
            this.groupBox45.Controls.Add(this.textBox26);
            this.groupBox45.Controls.Add(this.textBox25);
            this.groupBox45.Controls.Add(this.textBox24);
            this.groupBox45.Controls.Add(this.label25);
            this.groupBox45.Location = new System.Drawing.Point(6, 106);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Size = new System.Drawing.Size(323, 108);
            this.groupBox45.TabIndex = 1;
            this.groupBox45.TabStop = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(198, 47);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(26, 19);
            this.label31.TabIndex = 13;
            this.label31.Text = "4V";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(145, 46);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(26, 19);
            this.label30.TabIndex = 12;
            this.label30.Text = "5V";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(79, 46);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(26, 19);
            this.label29.TabIndex = 11;
            this.label29.Text = "9V";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(15, 47);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 19);
            this.label28.TabIndex = 7;
            this.label28.Text = "28V";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(187, 71);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(54, 26);
            this.textBox27.TabIndex = 10;
            this.textBox27.Text = "0";
            this.toolTip1.SetToolTip(this.textBox27, "Press Enter to update");
            this.textBox27.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox27_KeyDown);
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(127, 71);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(54, 26);
            this.textBox26.TabIndex = 9;
            this.textBox26.Text = "0";
            this.toolTip1.SetToolTip(this.textBox26, "Press Enter to update");
            this.textBox26.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox26_KeyDown);
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(67, 71);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(54, 26);
            this.textBox25.TabIndex = 8;
            this.textBox25.Text = "0";
            this.toolTip1.SetToolTip(this.textBox25, "Press Enter to update");
            this.textBox25.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox25_KeyDown);
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(7, 71);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(54, 26);
            this.textBox24.TabIndex = 7;
            this.textBox24.Text = "0";
            this.toolTip1.SetToolTip(this.textBox24, "Press Enter to update");
            this.textBox24.TextChanged += new System.EventHandler(this.textBox24_TextChanged);
            this.textBox24.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox24_KeyDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(56, 15);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(134, 23);
            this.label25.TabIndex = 7;
            this.label25.Text = "Set PSU voltage";
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.checkBox7);
            this.groupBox34.Controls.Add(this.button42);
            this.groupBox34.Controls.Add(this.textBox_PulseDelay);
            this.groupBox34.Controls.Add(this.label101);
            this.groupBox34.Controls.Add(this.textBox_PulsePeriod);
            this.groupBox34.Controls.Add(this.label102);
            this.groupBox34.Controls.Add(this.textBox_PulseWidth);
            this.groupBox34.Controls.Add(this.label103);
            this.groupBox34.Location = new System.Drawing.Point(728, 117);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(387, 100);
            this.groupBox34.TabIndex = 17;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "Pulse gen";
            // 
            // checkBox7
            // 
            this.checkBox7.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(293, 20);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(64, 28);
            this.checkBox7.TabIndex = 18;
            this.checkBox7.Text = "Control";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // button42
            // 
            this.button42.Location = new System.Drawing.Point(243, 60);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(123, 23);
            this.button42.TabIndex = 16;
            this.button42.Text = "Set Tx Inhabit";
            this.button42.UseVisualStyleBackColor = true;
            this.button42.Click += new System.EventHandler(this.button42_Click_2);
            // 
            // textBox_PulseDelay
            // 
            this.textBox_PulseDelay.Location = new System.Drawing.Point(180, 57);
            this.textBox_PulseDelay.Name = "textBox_PulseDelay";
            this.textBox_PulseDelay.Size = new System.Drawing.Size(57, 26);
            this.textBox_PulseDelay.TabIndex = 15;
            this.textBox_PulseDelay.Text = "0";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(177, 31);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(70, 18);
            this.label101.TabIndex = 14;
            this.label101.Text = "Delay (us)";
            // 
            // textBox_PulsePeriod
            // 
            this.textBox_PulsePeriod.Location = new System.Drawing.Point(95, 57);
            this.textBox_PulsePeriod.Name = "textBox_PulsePeriod";
            this.textBox_PulsePeriod.Size = new System.Drawing.Size(57, 26);
            this.textBox_PulsePeriod.TabIndex = 13;
            this.textBox_PulsePeriod.Text = "16";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(92, 31);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(76, 18);
            this.label102.TabIndex = 12;
            this.label102.Text = "Period (us)";
            // 
            // textBox_PulseWidth
            // 
            this.textBox_PulseWidth.Location = new System.Drawing.Point(20, 57);
            this.textBox_PulseWidth.Name = "textBox_PulseWidth";
            this.textBox_PulseWidth.Size = new System.Drawing.Size(57, 26);
            this.textBox_PulseWidth.TabIndex = 11;
            this.textBox_PulseWidth.Text = "2";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(13, 31);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(73, 18);
            this.label103.TabIndex = 1;
            this.label103.Text = "Width (us)";
            // 
            // groupBox44
            // 
            this.groupBox44.Controls.Add(this.button57);
            this.groupBox44.Controls.Add(this.textBox2);
            this.groupBox44.Controls.Add(this.textBox1);
            this.groupBox44.Controls.Add(this.button70);
            this.groupBox44.Controls.Add(this.label27);
            this.groupBox44.Controls.Add(this.label26);
            this.groupBox44.Controls.Add(this.label19);
            this.groupBox44.Location = new System.Drawing.Point(7, 4);
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Size = new System.Drawing.Size(322, 100);
            this.groupBox44.TabIndex = 0;
            this.groupBox44.TabStop = false;
            // 
            // button57
            // 
            this.button57.Location = new System.Drawing.Point(6, 76);
            this.button57.Name = "button57";
            this.button57.Size = new System.Drawing.Size(75, 23);
            this.button57.TabIndex = 12;
            this.button57.Text = "Clear";
            this.button57.UseVisualStyleBackColor = true;
            this.button57.Click += new System.EventHandler(this.button57_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(217, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(216, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 12;
            // 
            // button70
            // 
            this.button70.Location = new System.Drawing.Point(6, 44);
            this.button70.Name = "button70";
            this.button70.Size = new System.Drawing.Size(75, 23);
            this.button70.TabIndex = 6;
            this.button70.Text = "Get";
            this.button70.UseVisualStyleBackColor = true;
            this.button70.Click += new System.EventHandler(this.button70_Click_1);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(130, 54);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(81, 18);
            this.label27.TabIndex = 5;
            this.label27.Text = "FW version:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(127, 22);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 18);
            this.label26.TabIndex = 4;
            this.label26.Text = "HW version:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(5, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "System";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button75);
            this.groupBox1.Controls.Add(this.label97);
            this.groupBox1.Controls.Add(this.textBox_SimulatorSN);
            this.groupBox1.Controls.Add(this.label96);
            this.groupBox1.Controls.Add(this.textBox_SimulatorID);
            this.groupBox1.Controls.Add(this.button31);
            this.groupBox1.Controls.Add(this.label93);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.textBox_SimulatorFWVersion);
            this.groupBox1.Controls.Add(this.textBox_SimulatorHWVersion);
            this.groupBox1.Controls.Add(this.label95);
            this.groupBox1.Location = new System.Drawing.Point(334, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // button75
            // 
            this.button75.Location = new System.Drawing.Point(7, 67);
            this.button75.Name = "button75";
            this.button75.Size = new System.Drawing.Size(75, 23);
            this.button75.TabIndex = 11;
            this.button75.Text = "Clear";
            this.button75.UseVisualStyleBackColor = true;
            this.button75.Click += new System.EventHandler(this.button75_Click_1);
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(288, 55);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(29, 18);
            this.label97.TabIndex = 10;
            this.label97.Text = "SN:";
            // 
            // textBox_SimulatorSN
            // 
            this.textBox_SimulatorSN.Location = new System.Drawing.Point(319, 48);
            this.textBox_SimulatorSN.Name = "textBox_SimulatorSN";
            this.textBox_SimulatorSN.ReadOnly = true;
            this.textBox_SimulatorSN.Size = new System.Drawing.Size(50, 26);
            this.textBox_SimulatorSN.TabIndex = 9;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(288, 23);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(25, 18);
            this.label96.TabIndex = 8;
            this.label96.Text = "ID:";
            // 
            // textBox_SimulatorID
            // 
            this.textBox_SimulatorID.Location = new System.Drawing.Point(319, 16);
            this.textBox_SimulatorID.Name = "textBox_SimulatorID";
            this.textBox_SimulatorID.ReadOnly = true;
            this.textBox_SimulatorID.Size = new System.Drawing.Size(50, 26);
            this.textBox_SimulatorID.TabIndex = 7;
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(6, 40);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(75, 23);
            this.button31.TabIndex = 6;
            this.button31.Text = "Get";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click_1);
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(95, 51);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(81, 18);
            this.label93.TabIndex = 5;
            this.label93.Text = "FW version:";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(92, 19);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(83, 18);
            this.label94.TabIndex = 4;
            this.label94.Text = "HW version:";
            // 
            // textBox_SimulatorFWVersion
            // 
            this.textBox_SimulatorFWVersion.Location = new System.Drawing.Point(181, 48);
            this.textBox_SimulatorFWVersion.Name = "textBox_SimulatorFWVersion";
            this.textBox_SimulatorFWVersion.ReadOnly = true;
            this.textBox_SimulatorFWVersion.Size = new System.Drawing.Size(100, 26);
            this.textBox_SimulatorFWVersion.TabIndex = 3;
            // 
            // textBox_SimulatorHWVersion
            // 
            this.textBox_SimulatorHWVersion.Location = new System.Drawing.Point(181, 17);
            this.textBox_SimulatorHWVersion.Name = "textBox_SimulatorHWVersion";
            this.textBox_SimulatorHWVersion.ReadOnly = true;
            this.textBox_SimulatorHWVersion.Size = new System.Drawing.Size(100, 26);
            this.textBox_SimulatorHWVersion.TabIndex = 1;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.Location = new System.Drawing.Point(4, 14);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(87, 23);
            this.label95.TabIndex = 0;
            this.label95.Text = "Simulator";
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.checkBox6);
            this.groupBox33.Controls.Add(this.button32);
            this.groupBox33.Controls.Add(this.textBox_RFDelay);
            this.groupBox33.Controls.Add(this.label100);
            this.groupBox33.Controls.Add(this.textBox_RFPeriod);
            this.groupBox33.Controls.Add(this.label99);
            this.groupBox33.Controls.Add(this.textBox_RFWidth);
            this.groupBox33.Controls.Add(this.label98);
            this.groupBox33.Location = new System.Drawing.Point(728, 9);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(387, 100);
            this.groupBox33.TabIndex = 2;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "RF gen";
            // 
            // checkBox6
            // 
            this.checkBox6.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(293, 19);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(64, 28);
            this.checkBox6.TabIndex = 17;
            this.checkBox6.Text = "Control";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(243, 60);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(123, 23);
            this.button32.TabIndex = 16;
            this.button32.Text = "Set Tx Inhabit";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click_1);
            // 
            // textBox_RFDelay
            // 
            this.textBox_RFDelay.Location = new System.Drawing.Point(180, 57);
            this.textBox_RFDelay.Name = "textBox_RFDelay";
            this.textBox_RFDelay.Size = new System.Drawing.Size(57, 26);
            this.textBox_RFDelay.TabIndex = 15;
            this.textBox_RFDelay.Text = "0";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(177, 31);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(70, 18);
            this.label100.TabIndex = 14;
            this.label100.Text = "Delay (us)";
            // 
            // textBox_RFPeriod
            // 
            this.textBox_RFPeriod.Location = new System.Drawing.Point(95, 57);
            this.textBox_RFPeriod.Name = "textBox_RFPeriod";
            this.textBox_RFPeriod.Size = new System.Drawing.Size(57, 26);
            this.textBox_RFPeriod.TabIndex = 13;
            this.textBox_RFPeriod.Text = "16";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(92, 31);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(76, 18);
            this.label99.TabIndex = 12;
            this.label99.Text = "Period (us)";
            // 
            // textBox_RFWidth
            // 
            this.textBox_RFWidth.Location = new System.Drawing.Point(20, 57);
            this.textBox_RFWidth.Name = "textBox_RFWidth";
            this.textBox_RFWidth.Size = new System.Drawing.Size(57, 26);
            this.textBox_RFWidth.TabIndex = 11;
            this.textBox_RFWidth.Text = "2";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(13, 31);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(73, 18);
            this.label98.TabIndex = 1;
            this.label98.Text = "Width (us)";
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.dataGridView_ValPage0);
            this.tabPage13.Controls.Add(this.label81);
            this.tabPage13.Controls.Add(this.dataGridView_OverUnder);
            this.tabPage13.Controls.Add(this.label82);
            this.tabPage13.Controls.Add(this.textBox66);
            this.tabPage13.Controls.Add(this.label78);
            this.tabPage13.Controls.Add(this.textBox62);
            this.tabPage13.Controls.Add(this.label77);
            this.tabPage13.Controls.Add(this.textBox61);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(1350, 618);
            this.tabPage13.TabIndex = 4;
            this.tabPage13.Text = "Page 0";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // dataGridView_ValPage0
            // 
            this.dataGridView_ValPage0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ValPage0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn29});
            this.dataGridView_ValPage0.Location = new System.Drawing.Point(476, 241);
            this.dataGridView_ValPage0.Name = "dataGridView_ValPage0";
            this.dataGridView_ValPage0.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_ValPage0.Size = new System.Drawing.Size(336, 361);
            this.dataGridView_ValPage0.TabIndex = 27;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.HeaderText = "Value";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(529, 704);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(115, 18);
            this.label81.TabIndex = 26;
            this.label81.Text = "TGA2700 DC4 Vdd";
            // 
            // dataGridView_OverUnder
            // 
            this.dataGridView_OverUnder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_OverUnder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column3});
            this.dataGridView_OverUnder.Location = new System.Drawing.Point(7, 241);
            this.dataGridView_OverUnder.Name = "dataGridView_OverUnder";
            this.dataGridView_OverUnder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_OverUnder.Size = new System.Drawing.Size(463, 361);
            this.dataGridView_OverUnder.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Over";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Under";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Hystersis";
            this.Column3.Name = "Column3";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(20, 190);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(106, 18);
            this.label82.TabIndex = 16;
            this.label82.Text = "Calibration date";
            // 
            // textBox66
            // 
            this.textBox66.Location = new System.Drawing.Point(136, 184);
            this.textBox66.Name = "textBox66";
            this.textBox66.Size = new System.Drawing.Size(100, 26);
            this.textBox66.TabIndex = 15;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(304, 44);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(83, 18);
            this.label78.TabIndex = 8;
            this.label78.Text = "HW version:";
            // 
            // textBox62
            // 
            this.textBox62.Location = new System.Drawing.Point(440, 43);
            this.textBox62.Name = "textBox62";
            this.textBox62.Size = new System.Drawing.Size(100, 26);
            this.textBox62.TabIndex = 7;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(19, 45);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(99, 18);
            this.label77.TabIndex = 6;
            this.label77.Text = "Serial number:";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox61
            // 
            this.textBox61.Location = new System.Drawing.Point(136, 42);
            this.textBox61.Name = "textBox61";
            this.textBox61.Size = new System.Drawing.Size(100, 26);
            this.textBox61.TabIndex = 5;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label117);
            this.tabPage7.Controls.Add(this.label116);
            this.tabPage7.Controls.Add(this.dataGridView_Page1_4);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1350, 613);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Page 1-4";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.Location = new System.Drawing.Point(519, 4);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(108, 23);
            this.label117.TabIndex = 31;
            this.label117.Text = "DC4-40 dBm";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(189, 3);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(70, 23);
            this.label116.TabIndex = 30;
            this.label116.Text = "46 dBm";
            // 
            // dataGridView_Page1_4
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Page1_4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Page1_4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_Page1_4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView_Page1_4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21});
            this.dataGridView_Page1_4.Location = new System.Drawing.Point(10, 37);
            this.dataGridView_Page1_4.Name = "dataGridView_Page1_4";
            this.dataGridView_Page1_4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Page1_4.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Page1_4.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Page1_4.Size = new System.Drawing.Size(1025, 570);
            this.dataGridView_Page1_4.TabIndex = 28;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "F0";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 47;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "F1";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 47;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.HeaderText = "F2";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Width = 47;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "F3";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.Width = 47;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.HeaderText = "F4";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.Width = 47;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.HeaderText = "F5";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.Width = 47;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.HeaderText = "F6";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Width = 47;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.HeaderText = "F7";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Width = 47;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "F0";
            this.Column14.Name = "Column14";
            this.Column14.Width = 47;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "F1";
            this.Column15.Name = "Column15";
            this.Column15.Width = 47;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "F2";
            this.Column16.Name = "Column16";
            this.Column16.Width = 47;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "F3";
            this.Column17.Name = "Column17";
            this.Column17.Width = 47;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "F4";
            this.Column18.Name = "Column18";
            this.Column18.Width = 47;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "F5";
            this.Column19.Name = "Column19";
            this.Column19.Width = 47;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "F6";
            this.Column20.Name = "Column20";
            this.Column20.Width = 47;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "F7";
            this.Column21.Name = "Column21";
            this.Column21.Width = 47;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.label89);
            this.tabPage8.Controls.Add(this.dataGridView_VVAOffset1);
            this.tabPage8.Controls.Add(this.label88);
            this.tabPage8.Controls.Add(this.dataGridView_VVAOffset2);
            this.tabPage8.Controls.Add(this.label87);
            this.tabPage8.Controls.Add(this.label86);
            this.tabPage8.Controls.Add(this.dataGridView_PAVVA);
            this.tabPage8.Controls.Add(this.label76);
            this.tabPage8.Controls.Add(this.label75);
            this.tabPage8.Controls.Add(this.dataGridView_DC4);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1350, 618);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Page 5-7";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(826, 314);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(100, 23);
            this.label89.TabIndex = 12;
            this.label89.Text = "Vdd offset1";
            // 
            // dataGridView_VVAOffset1
            // 
            this.dataGridView_VVAOffset1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_VVAOffset1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_VVAOffset1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17});
            this.dataGridView_VVAOffset1.Location = new System.Drawing.Point(779, 340);
            this.dataGridView_VVAOffset1.Name = "dataGridView_VVAOffset1";
            this.dataGridView_VVAOffset1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_VVAOffset1.Size = new System.Drawing.Size(555, 265);
            this.dataGridView_VVAOffset1.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "F0";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 47;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "F1";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 47;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "F2";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 47;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "F3";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 47;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "F4";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 47;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "F5";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 47;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "F6";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 47;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "F7";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 47;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(826, 10);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(103, 23);
            this.label88.TabIndex = 10;
            this.label88.Text = "VVA offset2";
            // 
            // dataGridView_VVAOffset2
            // 
            this.dataGridView_VVAOffset2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_VVAOffset2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView_VVAOffset2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_VVAOffset2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView_VVAOffset2.Location = new System.Drawing.Point(779, 42);
            this.dataGridView_VVAOffset2.Name = "dataGridView_VVAOffset2";
            this.dataGridView_VVAOffset2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_VVAOffset2.Size = new System.Drawing.Size(557, 270);
            this.dataGridView_VVAOffset2.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "F0";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 47;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "F1";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 47;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "F2";
            this.Column4.Name = "Column4";
            this.Column4.Width = 47;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "F3";
            this.Column5.Name = "Column5";
            this.Column5.Width = 47;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "F4";
            this.Column6.Name = "Column6";
            this.Column6.Width = 47;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "F5";
            this.Column7.Name = "Column7";
            this.Column7.Width = 47;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "F6";
            this.Column8.Name = "Column8";
            this.Column8.Width = 47;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "F7";
            this.Column9.Name = "Column9";
            this.Column9.Width = 47;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(482, 8);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(105, 23);
            this.label87.TabIndex = 8;
            this.label87.Text = "DCA control";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.Location = new System.Drawing.Point(362, 8);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(118, 23);
            this.label86.TabIndex = 6;
            this.label86.Text = "PA VVA offset";
            // 
            // dataGridView_PAVVA
            // 
            this.dataGridView_PAVVA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_PAVVA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PAVVA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.Column12,
            this.Column13});
            this.dataGridView_PAVVA.Location = new System.Drawing.Point(378, 42);
            this.dataGridView_PAVVA.Name = "dataGridView_PAVVA";
            this.dataGridView_PAVVA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_PAVVA.Size = new System.Drawing.Size(395, 563);
            this.dataGridView_PAVVA.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "VVA";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 59;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "DCA1";
            this.Column12.Name = "Column12";
            this.Column12.Width = 66;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "DCA2";
            this.Column13.Name = "Column13";
            this.Column13.Width = 66;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(283, 12);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(66, 23);
            this.label76.TabIndex = 4;
            this.label76.Text = "DC4 on";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(177, 10);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(67, 23);
            this.label75.TabIndex = 2;
            this.label75.Text = "DC4 off";
            // 
            // dataGridView_DC4
            // 
            this.dataGridView_DC4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_DC4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DC4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column10,
            this.Column11});
            this.dataGridView_DC4.Location = new System.Drawing.Point(3, 45);
            this.dataGridView_DC4.Name = "dataGridView_DC4";
            this.dataGridView_DC4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_DC4.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_DC4.Size = new System.Drawing.Size(369, 563);
            this.dataGridView_DC4.TabIndex = 1;
            this.dataGridView_DC4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "28V";
            this.Column1.Name = "Column1";
            this.Column1.Width = 56;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Vgg";
            this.Column2.Name = "Column2";
            this.Column2.Width = 55;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "28V";
            this.Column10.Name = "Column10";
            this.Column10.Width = 56;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Vgg";
            this.Column11.Name = "Column11";
            this.Column11.Width = 55;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.label92);
            this.tabPage9.Controls.Add(this.dataGridView10);
            this.tabPage9.Controls.Add(this.label91);
            this.tabPage9.Controls.Add(this.dataGridView9);
            this.tabPage9.Controls.Add(this.label90);
            this.tabPage9.Controls.Add(this.dataGridView8);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1350, 618);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "Page 8";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.Location = new System.Drawing.Point(535, 13);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(169, 23);
            this.label92.TabIndex = 12;
            this.label92.Text = "Pulse fall time delay";
            // 
            // dataGridView10
            // 
            this.dataGridView10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22});
            this.dataGridView10.Location = new System.Drawing.Point(532, 44);
            this.dataGridView10.Name = "dataGridView10";
            this.dataGridView10.Size = new System.Drawing.Size(165, 563);
            this.dataGridView10.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "MPA";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Width = 61;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "SPA";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Width = 56;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.Location = new System.Drawing.Point(286, 13);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(181, 23);
            this.label91.TabIndex = 10;
            this.label91.Text = "Pulse Rise Time delay";
            // 
            // dataGridView9
            // 
            this.dataGridView9.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView9.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20});
            this.dataGridView9.Location = new System.Drawing.Point(283, 44);
            this.dataGridView9.Name = "dataGridView9";
            this.dataGridView9.Size = new System.Drawing.Size(165, 563);
            this.dataGridView9.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "MPA";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 61;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "SPA";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Width = 56;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(12, 13);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(77, 23);
            this.label90.TabIndex = 8;
            this.label90.Text = "SAR-SAT";
            // 
            // dataGridView8
            // 
            this.dataGridView8.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn18});
            this.dataGridView8.Location = new System.Drawing.Point(13, 47);
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView8.Size = new System.Drawing.Size(241, 563);
            this.dataGridView8.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Value";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 68;
            // 
            // groupBox42
            // 
            this.groupBox42.Controls.Add(this.radioButton_TCPIP);
            this.groupBox42.Controls.Add(this.radioButton_SerialPort);
            this.groupBox42.Location = new System.Drawing.Point(1561, 343);
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Size = new System.Drawing.Size(200, 100);
            this.groupBox42.TabIndex = 33;
            this.groupBox42.TabStop = false;
            this.groupBox42.Text = "Communication gatway";
            // 
            // radioButton_TCPIP
            // 
            this.radioButton_TCPIP.AutoSize = true;
            this.radioButton_TCPIP.Location = new System.Drawing.Point(20, 56);
            this.radioButton_TCPIP.Name = "radioButton_TCPIP";
            this.radioButton_TCPIP.Size = new System.Drawing.Size(66, 22);
            this.radioButton_TCPIP.TabIndex = 1;
            this.radioButton_TCPIP.TabStop = true;
            this.radioButton_TCPIP.Text = "TCP/IP";
            this.radioButton_TCPIP.UseVisualStyleBackColor = true;
            // 
            // radioButton_SerialPort
            // 
            this.radioButton_SerialPort.AutoSize = true;
            this.radioButton_SerialPort.Checked = true;
            this.radioButton_SerialPort.Location = new System.Drawing.Point(20, 26);
            this.radioButton_SerialPort.Name = "radioButton_SerialPort";
            this.radioButton_SerialPort.Size = new System.Drawing.Size(90, 22);
            this.radioButton_SerialPort.TabIndex = 0;
            this.radioButton_SerialPort.TabStop = true;
            this.radioButton_SerialPort.Text = "Serial Port";
            this.radioButton_SerialPort.UseVisualStyleBackColor = true;
            // 
            // button_OpenFolder
            // 
            this.button_OpenFolder.Location = new System.Drawing.Point(1561, 304);
            this.button_OpenFolder.Name = "button_OpenFolder";
            this.button_OpenFolder.Size = new System.Drawing.Size(191, 26);
            this.button_OpenFolder.TabIndex = 76;
            this.button_OpenFolder.Text = "Open Folder";
            this.button_OpenFolder.UseVisualStyleBackColor = true;
            this.button_OpenFolder.Click += new System.EventHandler(this.Button43_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.S1_Configuration);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1406, 776);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "S1 Configuration";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // S1_Configuration
            // 
            this.S1_Configuration.Controls.Add(this.groupBox12);
            this.S1_Configuration.Controls.Add(this.groupBox22);
            this.S1_Configuration.Controls.Add(this.groupBox28);
            this.S1_Configuration.Controls.Add(this.groupBox30);
            this.S1_Configuration.Controls.Add(this.groupBox29);
            this.S1_Configuration.Controls.Add(this.groupBox27);
            this.S1_Configuration.Controls.Add(this.groupBox26);
            this.S1_Configuration.Controls.Add(this.groupBox25);
            this.S1_Configuration.Controls.Add(this.groupBox24);
            this.S1_Configuration.Controls.Add(this.groupBox23);
            this.S1_Configuration.Controls.Add(this.groupBox21);
            this.S1_Configuration.Controls.Add(this.groupBox20);
            this.S1_Configuration.Controls.Add(this.groupBox19);
            this.S1_Configuration.Controls.Add(this.groupBox18);
            this.S1_Configuration.Controls.Add(this.groupBox17);
            this.S1_Configuration.Controls.Add(this.groupBox11);
            this.S1_Configuration.Controls.Add(this.groupBox10);
            this.S1_Configuration.Controls.Add(this.groupBox9);
            this.S1_Configuration.Controls.Add(this.groupBox8);
            this.S1_Configuration.Controls.Add(this.groupBox7);
            this.S1_Configuration.Controls.Add(this.groupBox6);
            this.S1_Configuration.Controls.Add(this.groupBox13);
            this.S1_Configuration.Controls.Add(this.groupBox14);
            this.S1_Configuration.Controls.Add(this.groupBox15);
            this.S1_Configuration.Controls.Add(this.groupBox16);
            this.S1_Configuration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S1_Configuration.Location = new System.Drawing.Point(3, 3);
            this.S1_Configuration.Name = "S1_Configuration";
            this.S1_Configuration.Size = new System.Drawing.Size(924, 741);
            this.S1_Configuration.TabIndex = 12;
            this.S1_Configuration.TabStop = false;
            this.S1_Configuration.Text = "S1 Configuration";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.button13);
            this.groupBox12.Location = new System.Drawing.Point(716, 24);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(164, 58);
            this.groupBox12.TabIndex = 67;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "RF pairing";
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(10, 20);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(152, 26);
            this.button13.TabIndex = 49;
            this.button13.Text = "RF Pairing";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Button13_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.TextBox_Odometer);
            this.groupBox22.Controls.Add(this.button19);
            this.groupBox22.Location = new System.Drawing.Point(718, 88);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(200, 78);
            this.groupBox22.TabIndex = 68;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Odometer";
            // 
            // TextBox_Odometer
            // 
            this.TextBox_Odometer.Location = new System.Drawing.Point(6, 23);
            this.TextBox_Odometer.Name = "TextBox_Odometer";
            this.TextBox_Odometer.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Odometer.TabIndex = 64;
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(6, 50);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(74, 26);
            this.button19.TabIndex = 63;
            this.button19.Text = "Odometer Config";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.Button19_Click);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.textBox_ModemSocket);
            this.groupBox28.Controls.Add(this.textBox_ModemRetries);
            this.groupBox28.Controls.Add(this.textBox_ModemTimeOut);
            this.groupBox28.Controls.Add(this.button25);
            this.groupBox28.Controls.Add(this.textBox_ModemPrimeryPort);
            this.groupBox28.Controls.Add(this.textBox_ModemPrimeryHost);
            this.groupBox28.Location = new System.Drawing.Point(188, 499);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(146, 195);
            this.groupBox28.TabIndex = 45;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Modem Config";
            // 
            // textBox_ModemSocket
            // 
            this.textBox_ModemSocket.Location = new System.Drawing.Point(8, 77);
            this.textBox_ModemSocket.Name = "textBox_ModemSocket";
            this.textBox_ModemSocket.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemSocket.TabIndex = 80;
            // 
            // textBox_ModemRetries
            // 
            this.textBox_ModemRetries.Location = new System.Drawing.Point(8, 50);
            this.textBox_ModemRetries.Name = "textBox_ModemRetries";
            this.textBox_ModemRetries.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemRetries.TabIndex = 79;
            // 
            // textBox_ModemTimeOut
            // 
            this.textBox_ModemTimeOut.Location = new System.Drawing.Point(8, 23);
            this.textBox_ModemTimeOut.Name = "textBox_ModemTimeOut";
            this.textBox_ModemTimeOut.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemTimeOut.TabIndex = 78;
            // 
            // button25
            // 
            this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.Location = new System.Drawing.Point(8, 157);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(132, 26);
            this.button25.TabIndex = 44;
            this.button25.Text = "Config Modem";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.Button25_Click);
            // 
            // textBox_ModemPrimeryPort
            // 
            this.textBox_ModemPrimeryPort.Location = new System.Drawing.Point(8, 129);
            this.textBox_ModemPrimeryPort.Name = "textBox_ModemPrimeryPort";
            this.textBox_ModemPrimeryPort.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemPrimeryPort.TabIndex = 37;
            // 
            // textBox_ModemPrimeryHost
            // 
            this.textBox_ModemPrimeryHost.Location = new System.Drawing.Point(8, 101);
            this.textBox_ModemPrimeryHost.Name = "textBox_ModemPrimeryHost";
            this.textBox_ModemPrimeryHost.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemPrimeryHost.TabIndex = 36;
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.textBox_ForginPassword);
            this.groupBox30.Controls.Add(this.button27);
            this.groupBox30.Controls.Add(this.textBox_ForginAcessPoint);
            this.groupBox30.Controls.Add(this.textBox_ForginSecondaryDNS);
            this.groupBox30.Controls.Add(this.textBox_ForginUserName);
            this.groupBox30.Controls.Add(this.textBox_ForginPrimeryDNS);
            this.groupBox30.Location = new System.Drawing.Point(344, 499);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(160, 195);
            this.groupBox30.TabIndex = 47;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Config Forgin Network";
            // 
            // textBox_ForginPassword
            // 
            this.textBox_ForginPassword.Location = new System.Drawing.Point(8, 77);
            this.textBox_ForginPassword.Name = "textBox_ForginPassword";
            this.textBox_ForginPassword.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginPassword.TabIndex = 35;
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.Location = new System.Drawing.Point(8, 157);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(146, 26);
            this.button27.TabIndex = 44;
            this.button27.Text = "Config Forgin Net";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.Button27_Click);
            // 
            // textBox_ForginAcessPoint
            // 
            this.textBox_ForginAcessPoint.Location = new System.Drawing.Point(7, 23);
            this.textBox_ForginAcessPoint.Name = "textBox_ForginAcessPoint";
            this.textBox_ForginAcessPoint.Size = new System.Drawing.Size(147, 22);
            this.textBox_ForginAcessPoint.TabIndex = 33;
            // 
            // textBox_ForginSecondaryDNS
            // 
            this.textBox_ForginSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            this.textBox_ForginSecondaryDNS.Name = "textBox_ForginSecondaryDNS";
            this.textBox_ForginSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginSecondaryDNS.TabIndex = 37;
            // 
            // textBox_ForginUserName
            // 
            this.textBox_ForginUserName.Location = new System.Drawing.Point(8, 51);
            this.textBox_ForginUserName.Name = "textBox_ForginUserName";
            this.textBox_ForginUserName.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginUserName.TabIndex = 34;
            // 
            // textBox_ForginPrimeryDNS
            // 
            this.textBox_ForginPrimeryDNS.Location = new System.Drawing.Point(8, 101);
            this.textBox_ForginPrimeryDNS.Name = "textBox_ForginPrimeryDNS";
            this.textBox_ForginPrimeryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginPrimeryDNS.TabIndex = 36;
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.textBox_HomePassword);
            this.groupBox29.Controls.Add(this.button26);
            this.groupBox29.Controls.Add(this.textBox_HomeAcessPoint);
            this.groupBox29.Controls.Add(this.textBox_HomeSecondaryDNS);
            this.groupBox29.Controls.Add(this.textBox_HomeUserName);
            this.groupBox29.Controls.Add(this.textBox_HomePrimeryDNS);
            this.groupBox29.Location = new System.Drawing.Point(345, 298);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(160, 195);
            this.groupBox29.TabIndex = 46;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Config Home Net";
            // 
            // textBox_HomePassword
            // 
            this.textBox_HomePassword.Location = new System.Drawing.Point(8, 77);
            this.textBox_HomePassword.Name = "textBox_HomePassword";
            this.textBox_HomePassword.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomePassword.TabIndex = 35;
            this.textBox_HomePassword.Text = "Password";
            // 
            // button26
            // 
            this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.Location = new System.Drawing.Point(8, 157);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(146, 26);
            this.button26.TabIndex = 44;
            this.button26.Text = "Config Home Net";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.Button26_Click);
            // 
            // textBox_HomeAcessPoint
            // 
            this.textBox_HomeAcessPoint.Location = new System.Drawing.Point(7, 23);
            this.textBox_HomeAcessPoint.Name = "textBox_HomeAcessPoint";
            this.textBox_HomeAcessPoint.Size = new System.Drawing.Size(147, 22);
            this.textBox_HomeAcessPoint.TabIndex = 33;
            this.textBox_HomeAcessPoint.Text = "Aceess point";
            // 
            // textBox_HomeSecondaryDNS
            // 
            this.textBox_HomeSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            this.textBox_HomeSecondaryDNS.Name = "textBox_HomeSecondaryDNS";
            this.textBox_HomeSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomeSecondaryDNS.TabIndex = 37;
            this.textBox_HomeSecondaryDNS.Text = "Secondary DNS";
            // 
            // textBox_HomeUserName
            // 
            this.textBox_HomeUserName.Location = new System.Drawing.Point(8, 51);
            this.textBox_HomeUserName.Name = "textBox_HomeUserName";
            this.textBox_HomeUserName.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomeUserName.TabIndex = 34;
            this.textBox_HomeUserName.Text = "User Name";
            // 
            // textBox_HomePrimeryDNS
            // 
            this.textBox_HomePrimeryDNS.Location = new System.Drawing.Point(8, 101);
            this.textBox_HomePrimeryDNS.Name = "textBox_HomePrimeryDNS";
            this.textBox_HomePrimeryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomePrimeryDNS.TabIndex = 36;
            this.textBox_HomePrimeryDNS.Text = "Primery DNS";
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.maskedTextBox1);
            this.groupBox27.Controls.Add(this.button24);
            this.groupBox27.Location = new System.Drawing.Point(315, 107);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(145, 78);
            this.groupBox27.TabIndex = 72;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Sleep Status Duration";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(6, 18);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox1.TabIndex = 71;
            // 
            // button24
            // 
            this.button24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.Location = new System.Drawing.Point(6, 45);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(131, 26);
            this.button24.TabIndex = 70;
            this.button24.Text = "Duration sleep";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.Button24_Click);
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.TextBox_NormalStatusDuration);
            this.groupBox26.Controls.Add(this.button23);
            this.groupBox26.Location = new System.Drawing.Point(334, 24);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(171, 77);
            this.groupBox26.TabIndex = 71;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Normal Status Duration";
            // 
            // TextBox_NormalStatusDuration
            // 
            this.TextBox_NormalStatusDuration.Location = new System.Drawing.Point(6, 17);
            this.TextBox_NormalStatusDuration.Name = "TextBox_NormalStatusDuration";
            this.TextBox_NormalStatusDuration.Size = new System.Drawing.Size(100, 22);
            this.TextBox_NormalStatusDuration.TabIndex = 71;
            // 
            // button23
            // 
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.Location = new System.Drawing.Point(6, 45);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(111, 26);
            this.button23.TabIndex = 70;
            this.button23.Text = "Set Duration";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.Button23_Click);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit2);
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit3);
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit1);
            this.groupBox25.Controls.Add(this.button22);
            this.groupBox25.Location = new System.Drawing.Point(510, 557);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(200, 89);
            this.groupBox25.TabIndex = 70;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Speed Limit Config";
            // 
            // maskedTextBox_SpeedLimit2
            // 
            this.maskedTextBox_SpeedLimit2.Location = new System.Drawing.Point(53, 20);
            this.maskedTextBox_SpeedLimit2.Name = "maskedTextBox_SpeedLimit2";
            this.maskedTextBox_SpeedLimit2.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit2.TabIndex = 80;
            // 
            // maskedTextBox_SpeedLimit3
            // 
            this.maskedTextBox_SpeedLimit3.Location = new System.Drawing.Point(101, 19);
            this.maskedTextBox_SpeedLimit3.Name = "maskedTextBox_SpeedLimit3";
            this.maskedTextBox_SpeedLimit3.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit3.TabIndex = 79;
            // 
            // maskedTextBox_SpeedLimit1
            // 
            this.maskedTextBox_SpeedLimit1.Location = new System.Drawing.Point(6, 20);
            this.maskedTextBox_SpeedLimit1.Name = "maskedTextBox_SpeedLimit1";
            this.maskedTextBox_SpeedLimit1.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit1.TabIndex = 78;
            // 
            // button22
            // 
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.Location = new System.Drawing.Point(6, 47);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(140, 26);
            this.button22.TabIndex = 65;
            this.button22.Text = "Speed Limit Alert";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.Button22_Click);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.comboBox_DispatchSpeed);
            this.groupBox24.Controls.Add(this.button21);
            this.groupBox24.Location = new System.Drawing.Point(228, 377);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(106, 103);
            this.groupBox24.TabIndex = 68;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Dispatch Speed Limit";
            // 
            // comboBox_DispatchSpeed
            // 
            this.comboBox_DispatchSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_DispatchSpeed.FormattingEnabled = true;
            this.comboBox_DispatchSpeed.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_DispatchSpeed.Location = new System.Drawing.Point(8, 44);
            this.comboBox_DispatchSpeed.Name = "comboBox_DispatchSpeed";
            this.comboBox_DispatchSpeed.Size = new System.Drawing.Size(94, 21);
            this.comboBox_DispatchSpeed.TabIndex = 63;
            this.comboBox_DispatchSpeed.Text = "Speed";
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Location = new System.Drawing.Point(8, 71);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(94, 26);
            this.button21.TabIndex = 64;
            this.button21.Text = "Dispatch Speed";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.Button21_Click);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.comboBox_KillEngine);
            this.groupBox23.Controls.Add(this.button20);
            this.groupBox23.Location = new System.Drawing.Point(230, 287);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(109, 91);
            this.groupBox23.TabIndex = 67;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Kill Engine";
            // 
            // comboBox_KillEngine
            // 
            this.comboBox_KillEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_KillEngine.FormattingEnabled = true;
            this.comboBox_KillEngine.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_KillEngine.Location = new System.Drawing.Point(6, 20);
            this.comboBox_KillEngine.Name = "comboBox_KillEngine";
            this.comboBox_KillEngine.Size = new System.Drawing.Size(58, 21);
            this.comboBox_KillEngine.TabIndex = 63;
            this.comboBox_KillEngine.Text = "Engine";
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(6, 43);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(98, 26);
            this.button20.TabIndex = 64;
            this.button20.Text = "Kill Engine";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.Button20_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.maskedTextBox_TiltTowSens);
            this.groupBox21.Controls.Add(this.comboBox_TiltTowSensState);
            this.groupBox21.Controls.Add(this.button18);
            this.groupBox21.Location = new System.Drawing.Point(510, 451);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(200, 100);
            this.groupBox21.TabIndex = 65;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Tilt Tow Sensitivity";
            // 
            // maskedTextBox_TiltTowSens
            // 
            this.maskedTextBox_TiltTowSens.Location = new System.Drawing.Point(81, 32);
            this.maskedTextBox_TiltTowSens.Name = "maskedTextBox_TiltTowSens";
            this.maskedTextBox_TiltTowSens.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_TiltTowSens.TabIndex = 83;
            // 
            // comboBox_TiltTowSensState
            // 
            this.comboBox_TiltTowSensState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_TiltTowSensState.FormattingEnabled = true;
            this.comboBox_TiltTowSensState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_TiltTowSensState.Location = new System.Drawing.Point(17, 32);
            this.comboBox_TiltTowSensState.Name = "comboBox_TiltTowSensState";
            this.comboBox_TiltTowSensState.Size = new System.Drawing.Size(58, 21);
            this.comboBox_TiltTowSensState.TabIndex = 82;
            this.comboBox_TiltTowSensState.Text = "State";
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(17, 59);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(140, 26);
            this.button18.TabIndex = 61;
            this.button18.Text = "Tilt/Tow Sensitivity";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.Button18_Click);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.maskedTextBox_HitSensitivity);
            this.groupBox20.Controls.Add(this.comboBox_HitState);
            this.groupBox20.Controls.Add(this.button17);
            this.groupBox20.Location = new System.Drawing.Point(510, 345);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(200, 100);
            this.groupBox20.TabIndex = 64;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Hit Sensitivity";
            // 
            // maskedTextBox_HitSensitivity
            // 
            this.maskedTextBox_HitSensitivity.Location = new System.Drawing.Point(81, 32);
            this.maskedTextBox_HitSensitivity.Name = "maskedTextBox_HitSensitivity";
            this.maskedTextBox_HitSensitivity.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_HitSensitivity.TabIndex = 82;
            // 
            // comboBox_HitState
            // 
            this.comboBox_HitState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_HitState.FormattingEnabled = true;
            this.comboBox_HitState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_HitState.Location = new System.Drawing.Point(17, 32);
            this.comboBox_HitState.Name = "comboBox_HitState";
            this.comboBox_HitState.Size = new System.Drawing.Size(58, 21);
            this.comboBox_HitState.TabIndex = 62;
            this.comboBox_HitState.Text = "State";
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(17, 59);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(140, 26);
            this.button17.TabIndex = 61;
            this.button17.Text = "Hit Sensitivity";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.Button17_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.maskedTextBox_ShockDetectNum);
            this.groupBox19.Controls.Add(this.maskedTextBox_ShockWindow);
            this.groupBox19.Controls.Add(this.comboBox_ShockState);
            this.groupBox19.Controls.Add(this.button16);
            this.groupBox19.Location = new System.Drawing.Point(718, 276);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(200, 100);
            this.groupBox19.TabIndex = 63;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Config Shock";
            // 
            // maskedTextBox_ShockDetectNum
            // 
            this.maskedTextBox_ShockDetectNum.Location = new System.Drawing.Point(111, 24);
            this.maskedTextBox_ShockDetectNum.Name = "maskedTextBox_ShockDetectNum";
            this.maskedTextBox_ShockDetectNum.Size = new System.Drawing.Size(46, 22);
            this.maskedTextBox_ShockDetectNum.TabIndex = 82;
            // 
            // maskedTextBox_ShockWindow
            // 
            this.maskedTextBox_ShockWindow.Location = new System.Drawing.Point(59, 24);
            this.maskedTextBox_ShockWindow.Name = "maskedTextBox_ShockWindow";
            this.maskedTextBox_ShockWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_ShockWindow.TabIndex = 81;
            // 
            // comboBox_ShockState
            // 
            this.comboBox_ShockState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ShockState.FormattingEnabled = true;
            this.comboBox_ShockState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_ShockState.Location = new System.Drawing.Point(1, 24);
            this.comboBox_ShockState.Name = "comboBox_ShockState";
            this.comboBox_ShockState.Size = new System.Drawing.Size(48, 21);
            this.comboBox_ShockState.TabIndex = 61;
            this.comboBox_ShockState.Text = "State";
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(6, 54);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(140, 26);
            this.button16.TabIndex = 42;
            this.button16.Text = "Config Shock";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Button16_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltDetectNum);
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltWindow);
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltAngle);
            this.groupBox18.Controls.Add(this.comboBox1_TiltState);
            this.groupBox18.Controls.Add(this.button15);
            this.groupBox18.Location = new System.Drawing.Point(718, 170);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(200, 100);
            this.groupBox18.TabIndex = 62;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Config Tow";
            // 
            // maskedTextBox_TiltDetectNum
            // 
            this.maskedTextBox_TiltDetectNum.Location = new System.Drawing.Point(100, 29);
            this.maskedTextBox_TiltDetectNum.Name = "maskedTextBox_TiltDetectNum";
            this.maskedTextBox_TiltDetectNum.Size = new System.Drawing.Size(42, 22);
            this.maskedTextBox_TiltDetectNum.TabIndex = 83;
            // 
            // maskedTextBox_TiltWindow
            // 
            this.maskedTextBox_TiltWindow.Location = new System.Drawing.Point(53, 29);
            this.maskedTextBox_TiltWindow.Name = "maskedTextBox_TiltWindow";
            this.maskedTextBox_TiltWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_TiltWindow.TabIndex = 82;
            // 
            // maskedTextBox_TiltAngle
            // 
            this.maskedTextBox_TiltAngle.Location = new System.Drawing.Point(10, 29);
            this.maskedTextBox_TiltAngle.Name = "maskedTextBox_TiltAngle";
            this.maskedTextBox_TiltAngle.Size = new System.Drawing.Size(37, 22);
            this.maskedTextBox_TiltAngle.TabIndex = 81;
            // 
            // comboBox1_TiltState
            // 
            this.comboBox1_TiltState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1_TiltState.FormattingEnabled = true;
            this.comboBox1_TiltState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox1_TiltState.Location = new System.Drawing.Point(152, 29);
            this.comboBox1_TiltState.Name = "comboBox1_TiltState";
            this.comboBox1_TiltState.Size = new System.Drawing.Size(42, 21);
            this.comboBox1_TiltState.TabIndex = 38;
            this.comboBox1_TiltState.Text = "State";
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(6, 56);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(140, 26);
            this.button15.TabIndex = 42;
            this.button15.Text = "Config Tilt";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Button15_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.maskedTextBox_TowDetectNum);
            this.groupBox17.Controls.Add(this.maskedTextBox_TowWindow);
            this.groupBox17.Controls.Add(this.maskedTextBox_TowAngle);
            this.groupBox17.Controls.Add(this.button14);
            this.groupBox17.Location = new System.Drawing.Point(516, 17);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(157, 100);
            this.groupBox17.TabIndex = 61;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Tow Configuration";
            // 
            // maskedTextBox_TowDetectNum
            // 
            this.maskedTextBox_TowDetectNum.Location = new System.Drawing.Point(100, 24);
            this.maskedTextBox_TowDetectNum.Name = "maskedTextBox_TowDetectNum";
            this.maskedTextBox_TowDetectNum.Size = new System.Drawing.Size(42, 22);
            this.maskedTextBox_TowDetectNum.TabIndex = 80;
            // 
            // maskedTextBox_TowWindow
            // 
            this.maskedTextBox_TowWindow.Location = new System.Drawing.Point(53, 24);
            this.maskedTextBox_TowWindow.Name = "maskedTextBox_TowWindow";
            this.maskedTextBox_TowWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_TowWindow.TabIndex = 79;
            // 
            // maskedTextBox_TowAngle
            // 
            this.maskedTextBox_TowAngle.Location = new System.Drawing.Point(10, 24);
            this.maskedTextBox_TowAngle.Name = "maskedTextBox_TowAngle";
            this.maskedTextBox_TowAngle.Size = new System.Drawing.Size(37, 22);
            this.maskedTextBox_TowAngle.TabIndex = 78;
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(6, 54);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(140, 26);
            this.button14.TabIndex = 42;
            this.button14.Text = "Config Tow";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Button14_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.comboBox_SleepPolicy);
            this.groupBox11.Controls.Add(this.button12);
            this.groupBox11.Location = new System.Drawing.Point(15, 598);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(167, 84);
            this.groupBox11.TabIndex = 57;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Sleep Policy";
            // 
            // comboBox_SleepPolicy
            // 
            this.comboBox_SleepPolicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SleepPolicy.FormattingEnabled = true;
            this.comboBox_SleepPolicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_SleepPolicy.Location = new System.Drawing.Point(6, 27);
            this.comboBox_SleepPolicy.Name = "comboBox_SleepPolicy";
            this.comboBox_SleepPolicy.Size = new System.Drawing.Size(80, 21);
            this.comboBox_SleepPolicy.TabIndex = 47;
            this.comboBox_SleepPolicy.Text = "Sleep Policy";
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(6, 51);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(152, 26);
            this.button12.TabIndex = 48;
            this.button12.Text = "Set Sleep Policy";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button12_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.comboBox_AlarmPilicy);
            this.groupBox10.Controls.Add(this.button11);
            this.groupBox10.Location = new System.Drawing.Point(15, 492);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(166, 100);
            this.groupBox10.TabIndex = 56;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Set Alarm Configuration";
            // 
            // comboBox_AlarmPilicy
            // 
            this.comboBox_AlarmPilicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_AlarmPilicy.FormattingEnabled = true;
            this.comboBox_AlarmPilicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_AlarmPilicy.Location = new System.Drawing.Point(8, 28);
            this.comboBox_AlarmPilicy.Name = "comboBox_AlarmPilicy";
            this.comboBox_AlarmPilicy.Size = new System.Drawing.Size(80, 21);
            this.comboBox_AlarmPilicy.TabIndex = 42;
            this.comboBox_AlarmPilicy.Text = "Alarm Policy";
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(8, 52);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(152, 26);
            this.button11.TabIndex = 43;
            this.button11.Text = "Set Alarm Policy";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dateTimePicker_SetTimeDate);
            this.groupBox9.Controls.Add(this.button10);
            this.groupBox9.Location = new System.Drawing.Point(353, 193);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(204, 81);
            this.groupBox9.TabIndex = 55;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Set Time and Date";
            // 
            // dateTimePicker_SetTimeDate
            // 
            this.dateTimePicker_SetTimeDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker_SetTimeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_SetTimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_SetTimeDate.Location = new System.Drawing.Point(6, 20);
            this.dateTimePicker_SetTimeDate.Name = "dateTimePicker_SetTimeDate";
            this.dateTimePicker_SetTimeDate.Size = new System.Drawing.Size(179, 21);
            this.dateTimePicker_SetTimeDate.TabIndex = 41;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(6, 47);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 26);
            this.button10.TabIndex = 40;
            this.button10.Text = "Time Date Config";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox_BatThreshold);
            this.groupBox8.Controls.Add(this.button9);
            this.groupBox8.Location = new System.Drawing.Point(187, 183);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(160, 91);
            this.groupBox8.TabIndex = 54;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Vehicle Battery threshold ";
            // 
            // comboBox_BatThreshold
            // 
            this.comboBox_BatThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_BatThreshold.FormattingEnabled = true;
            this.comboBox_BatThreshold.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_BatThreshold.Location = new System.Drawing.Point(6, 20);
            this.comboBox_BatThreshold.Name = "comboBox_BatThreshold";
            this.comboBox_BatThreshold.Size = new System.Drawing.Size(49, 21);
            this.comboBox_BatThreshold.TabIndex = 39;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(6, 47);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(135, 26);
            this.button9.TabIndex = 38;
            this.button9.Text = "Vehicle Battery";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.maskedTextBox_OutputDuration);
            this.groupBox7.Controls.Add(this.comboBox_OutputNum);
            this.groupBox7.Controls.Add(this.comboBox_OutputControl);
            this.groupBox7.Controls.Add(this.button8);
            this.groupBox7.Controls.Add(this.comboBox_OutputPulseLevel);
            this.groupBox7.Location = new System.Drawing.Point(9, 386);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(215, 94);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Set Input Config";
            // 
            // maskedTextBox_OutputDuration
            // 
            this.maskedTextBox_OutputDuration.Location = new System.Drawing.Point(164, 48);
            this.maskedTextBox_OutputDuration.Name = "maskedTextBox_OutputDuration";
            this.maskedTextBox_OutputDuration.Size = new System.Drawing.Size(39, 22);
            this.maskedTextBox_OutputDuration.TabIndex = 38;
            // 
            // comboBox_OutputNum
            // 
            this.comboBox_OutputNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputNum.FormattingEnabled = true;
            this.comboBox_OutputNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_OutputNum.Location = new System.Drawing.Point(6, 20);
            this.comboBox_OutputNum.Name = "comboBox_OutputNum";
            this.comboBox_OutputNum.Size = new System.Drawing.Size(71, 21);
            this.comboBox_OutputNum.TabIndex = 33;
            this.comboBox_OutputNum.Text = "Output Num";
            // 
            // comboBox_OutputControl
            // 
            this.comboBox_OutputControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputControl.FormattingEnabled = true;
            this.comboBox_OutputControl.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_OutputControl.Location = new System.Drawing.Point(83, 20);
            this.comboBox_OutputControl.Name = "comboBox_OutputControl";
            this.comboBox_OutputControl.Size = new System.Drawing.Size(71, 21);
            this.comboBox_OutputControl.TabIndex = 34;
            this.comboBox_OutputControl.Text = "Cntl";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(5, 47);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(152, 26);
            this.button8.TabIndex = 36;
            this.button8.Text = "Set Output Config";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // comboBox_OutputPulseLevel
            // 
            this.comboBox_OutputPulseLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputPulseLevel.FormattingEnabled = true;
            this.comboBox_OutputPulseLevel.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_OutputPulseLevel.Location = new System.Drawing.Point(160, 20);
            this.comboBox_OutputPulseLevel.Name = "comboBox_OutputPulseLevel";
            this.comboBox_OutputPulseLevel.Size = new System.Drawing.Size(43, 21);
            this.comboBox_OutputPulseLevel.TabIndex = 37;
            this.comboBox_OutputPulseLevel.Text = "Pulse\\Level";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.maskedTextBox_InputDuration);
            this.groupBox6.Controls.Add(this.comboBox_InputNum1);
            this.groupBox6.Controls.Add(this.comboBox_Interupt);
            this.groupBox6.Controls.Add(this.button7);
            this.groupBox6.Location = new System.Drawing.Point(9, 280);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(215, 100);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input Configuration";
            // 
            // maskedTextBox_InputDuration
            // 
            this.maskedTextBox_InputDuration.Location = new System.Drawing.Point(157, 31);
            this.maskedTextBox_InputDuration.Name = "maskedTextBox_InputDuration";
            this.maskedTextBox_InputDuration.Size = new System.Drawing.Size(46, 22);
            this.maskedTextBox_InputDuration.TabIndex = 33;
            // 
            // comboBox_InputNum1
            // 
            this.comboBox_InputNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_InputNum1.FormattingEnabled = true;
            this.comboBox_InputNum1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_InputNum1.Location = new System.Drawing.Point(6, 31);
            this.comboBox_InputNum1.Name = "comboBox_InputNum1";
            this.comboBox_InputNum1.Size = new System.Drawing.Size(71, 21);
            this.comboBox_InputNum1.TabIndex = 29;
            this.comboBox_InputNum1.Text = "Input Num";
            // 
            // comboBox_Interupt
            // 
            this.comboBox_Interupt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Interupt.FormattingEnabled = true;
            this.comboBox_Interupt.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_Interupt.Location = new System.Drawing.Point(83, 31);
            this.comboBox_Interupt.Name = "comboBox_Interupt";
            this.comboBox_Interupt.Size = new System.Drawing.Size(71, 21);
            this.comboBox_Interupt.TabIndex = 30;
            this.comboBox_Interupt.Text = "Interrupt";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(5, 58);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(152, 26);
            this.button7.TabIndex = 32;
            this.button7.Text = "Set Input Config";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btn_ChangePassword);
            this.groupBox13.Controls.Add(this.textBox_NewPassword);
            this.groupBox13.Location = new System.Drawing.Point(9, 174);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(172, 100);
            this.groupBox13.TabIndex = 52;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Change Password";
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangePassword.Location = new System.Drawing.Point(8, 48);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(152, 26);
            this.btn_ChangePassword.TabIndex = 28;
            this.btn_ChangePassword.Text = "Change Password";
            this.btn_ChangePassword.UseVisualStyleBackColor = true;
            // 
            // textBox_NewPassword
            // 
            this.textBox_NewPassword.Location = new System.Drawing.Point(6, 19);
            this.textBox_NewPassword.Name = "textBox_NewPassword";
            this.textBox_NewPassword.Size = new System.Drawing.Size(120, 22);
            this.textBox_NewPassword.TabIndex = 27;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.comboBox_SMSControl);
            this.groupBox14.Controls.Add(this.button_SMSControl);
            this.groupBox14.Location = new System.Drawing.Point(187, 105);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(122, 80);
            this.groupBox14.TabIndex = 51;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "SMS Control";
            // 
            // comboBox_SMSControl
            // 
            this.comboBox_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SMSControl.FormattingEnabled = true;
            this.comboBox_SMSControl.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_SMSControl.Location = new System.Drawing.Point(6, 20);
            this.comboBox_SMSControl.Name = "comboBox_SMSControl";
            this.comboBox_SMSControl.Size = new System.Drawing.Size(101, 21);
            this.comboBox_SMSControl.TabIndex = 25;
            // 
            // button_SMSControl
            // 
            this.button_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SMSControl.Location = new System.Drawing.Point(6, 47);
            this.button_SMSControl.Name = "button_SMSControl";
            this.button_SMSControl.Size = new System.Drawing.Size(113, 26);
            this.button_SMSControl.TabIndex = 26;
            this.button_SMSControl.Text = "SMS Control";
            this.button_SMSControl.UseVisualStyleBackColor = true;
            this.button_SMSControl.Click += new System.EventHandler(this.Button_SMSControl_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.textBox_FreeText);
            this.groupBox15.Controls.Add(this.comboBox_InputIndex);
            this.groupBox15.Controls.Add(this.button_SetFreeText);
            this.groupBox15.Location = new System.Drawing.Point(187, 24);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(141, 75);
            this.groupBox15.TabIndex = 50;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Set Input Free Text";
            // 
            // textBox_FreeText
            // 
            this.textBox_FreeText.Location = new System.Drawing.Point(52, 16);
            this.textBox_FreeText.Name = "textBox_FreeText";
            this.textBox_FreeText.Size = new System.Drawing.Size(67, 22);
            this.textBox_FreeText.TabIndex = 25;
            // 
            // comboBox_InputIndex
            // 
            this.comboBox_InputIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_InputIndex.FormattingEnabled = true;
            this.comboBox_InputIndex.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_InputIndex.Location = new System.Drawing.Point(8, 17);
            this.comboBox_InputIndex.Name = "comboBox_InputIndex";
            this.comboBox_InputIndex.Size = new System.Drawing.Size(37, 21);
            this.comboBox_InputIndex.TabIndex = 20;
            // 
            // button_SetFreeText
            // 
            this.button_SetFreeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SetFreeText.Location = new System.Drawing.Point(8, 40);
            this.button_SetFreeText.Name = "button_SetFreeText";
            this.button_SetFreeText.Size = new System.Drawing.Size(111, 26);
            this.button_SetFreeText.TabIndex = 24;
            this.button_SetFreeText.Text = "Set Free Text";
            this.button_SetFreeText.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.maskedTextBox3_Subscriber3);
            this.groupBox16.Controls.Add(this.maskedTextBox2_Subscriber2);
            this.groupBox16.Controls.Add(this.maskedTextBox1_Subscriber1);
            this.groupBox16.Controls.Add(this.button4);
            this.groupBox16.Location = new System.Drawing.Point(9, 20);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(172, 149);
            this.groupBox16.TabIndex = 20;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Subscribers";
            // 
            // maskedTextBox3_Subscriber3
            // 
            this.maskedTextBox3_Subscriber3.Location = new System.Drawing.Point(8, 76);
            this.maskedTextBox3_Subscriber3.Name = "maskedTextBox3_Subscriber3";
            this.maskedTextBox3_Subscriber3.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox3_Subscriber3.TabIndex = 28;
            // 
            // maskedTextBox2_Subscriber2
            // 
            this.maskedTextBox2_Subscriber2.Location = new System.Drawing.Point(8, 49);
            this.maskedTextBox2_Subscriber2.Name = "maskedTextBox2_Subscriber2";
            this.maskedTextBox2_Subscriber2.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox2_Subscriber2.TabIndex = 27;
            // 
            // maskedTextBox1_Subscriber1
            // 
            this.maskedTextBox1_Subscriber1.Location = new System.Drawing.Point(8, 24);
            this.maskedTextBox1_Subscriber1.Name = "maskedTextBox1_Subscriber1";
            this.maskedTextBox1_Subscriber1.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox1_Subscriber1.TabIndex = 26;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(6, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 26);
            this.button4.TabIndex = 20;
            this.button4.Text = "Set Subscribers";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1406, 776);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "S1 Requests and Qureies";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox_SMSPhoneNumber
            // 
            this.textBox_SMSPhoneNumber.Location = new System.Drawing.Point(6, 22);
            this.textBox_SMSPhoneNumber.Name = "textBox_SMSPhoneNumber";
            this.textBox_SMSPhoneNumber.Size = new System.Drawing.Size(156, 26);
            this.textBox_SMSPhoneNumber.TabIndex = 10;
            // 
            // button_SendAllCheckedSMS
            // 
            this.button_SendAllCheckedSMS.Location = new System.Drawing.Point(353, 115);
            this.button_SendAllCheckedSMS.Name = "button_SendAllCheckedSMS";
            this.button_SendAllCheckedSMS.Size = new System.Drawing.Size(123, 23);
            this.button_SendAllCheckedSMS.TabIndex = 7;
            this.button_SendAllCheckedSMS.Text = "Send SMS Multi";
            this.button_SendAllCheckedSMS.UseVisualStyleBackColor = true;
            this.button_SendAllCheckedSMS.Click += new System.EventHandler(this.Button39_Click);
            // 
            // button_SendSelectedSMS
            // 
            this.button_SendSelectedSMS.Location = new System.Drawing.Point(482, 115);
            this.button_SendSelectedSMS.Name = "button_SendSelectedSMS";
            this.button_SendSelectedSMS.Size = new System.Drawing.Size(107, 23);
            this.button_SendSelectedSMS.TabIndex = 8;
            this.button_SendSelectedSMS.Text = "Send SMS One";
            this.button_SendSelectedSMS.UseVisualStyleBackColor = true;
            this.button_SendSelectedSMS.Click += new System.EventHandler(this.Button_SendSelectedSMS_Click);
            // 
            // button_Ring
            // 
            this.button_Ring.Location = new System.Drawing.Point(88, 112);
            this.button_Ring.Name = "button_Ring";
            this.button_Ring.Size = new System.Drawing.Size(141, 23);
            this.button_Ring.TabIndex = 14;
            this.button_Ring.Text = "Ring";
            this.button_Ring.UseVisualStyleBackColor = true;
            // 
            // comboBox_SystemType
            // 
            this.comboBox_SystemType.FormattingEnabled = true;
            this.comboBox_SystemType.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.comboBox_SystemType.Location = new System.Drawing.Point(5, 45);
            this.comboBox_SystemType.Name = "comboBox_SystemType";
            this.comboBox_SystemType.Size = new System.Drawing.Size(78, 21);
            this.comboBox_SystemType.TabIndex = 77;
            this.comboBox_SystemType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox2_MouseDown);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer_General_100ms
            // 
            this.timer_General_100ms.Enabled = true;
            this.timer_General_100ms.Tick += new System.EventHandler(this.Timer_ConectionKeepAlive_Tick);
            // 
            // timer_General_1Second
            // 
            this.timer_General_1Second.Enabled = true;
            this.timer_General_1Second.Interval = 1000;
            this.timer_General_1Second.Tick += new System.EventHandler(this.Timer_General_Tick);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // groupBox36
            // 
            this.groupBox36.Location = new System.Drawing.Point(0, -60);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(138, 57);
            this.groupBox36.TabIndex = 11;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "Comm Interface";
            // 
            // groupBox_PhoneNumber
            // 
            this.groupBox_PhoneNumber.Controls.Add(this.textBox_SMSPhoneNumber);
            this.groupBox_PhoneNumber.Location = new System.Drawing.Point(973, 5);
            this.groupBox_PhoneNumber.Name = "groupBox_PhoneNumber";
            this.groupBox_PhoneNumber.Size = new System.Drawing.Size(172, 55);
            this.groupBox_PhoneNumber.TabIndex = 12;
            this.groupBox_PhoneNumber.TabStop = false;
            this.groupBox_PhoneNumber.Text = "Phone Number";
            this.groupBox_PhoneNumber.Visible = false;
            // 
            // Label_SerialPortRx
            // 
            this.Label_SerialPortRx.AutoSize = true;
            this.Label_SerialPortRx.Location = new System.Drawing.Point(21, 54);
            this.Label_SerialPortRx.Name = "Label_SerialPortRx";
            this.Label_SerialPortRx.Size = new System.Drawing.Size(23, 18);
            this.Label_SerialPortRx.TabIndex = 108;
            this.Label_SerialPortRx.Text = "Rx";
            // 
            // label_SerialPortConnected
            // 
            this.label_SerialPortConnected.AutoSize = true;
            this.label_SerialPortConnected.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerialPortConnected.Location = new System.Drawing.Point(17, 29);
            this.label_SerialPortConnected.Name = "label_SerialPortConnected";
            this.label_SerialPortConnected.Size = new System.Drawing.Size(69, 18);
            this.label_SerialPortConnected.TabIndex = 109;
            this.label_SerialPortConnected.Text = "Conneted";
            // 
            // Label_SerialPortTx
            // 
            this.Label_SerialPortTx.AutoSize = true;
            this.Label_SerialPortTx.Location = new System.Drawing.Point(65, 54);
            this.Label_SerialPortTx.Name = "Label_SerialPortTx";
            this.Label_SerialPortTx.Size = new System.Drawing.Size(21, 18);
            this.Label_SerialPortTx.TabIndex = 110;
            this.Label_SerialPortTx.Text = "Tx";
            // 
            // groupBox_SerialPort
            // 
            this.groupBox_SerialPort.Controls.Add(this.label_SerialPortStatus);
            this.groupBox_SerialPort.Controls.Add(this.Label_SerialPortTx);
            this.groupBox_SerialPort.Controls.Add(this.label_SerialPortConnected);
            this.groupBox_SerialPort.Controls.Add(this.Label_SerialPortRx);
            this.groupBox_SerialPort.Location = new System.Drawing.Point(1561, 77);
            this.groupBox_SerialPort.Name = "groupBox_SerialPort";
            this.groupBox_SerialPort.Size = new System.Drawing.Size(191, 106);
            this.groupBox_SerialPort.TabIndex = 111;
            this.groupBox_SerialPort.TabStop = false;
            this.groupBox_SerialPort.Text = "Serial port";
            this.groupBox_SerialPort.Enter += new System.EventHandler(this.groupBox_SerialPort_Enter);
            // 
            // label_SerialPortStatus
            // 
            this.label_SerialPortStatus.AutoSize = true;
            this.label_SerialPortStatus.Location = new System.Drawing.Point(95, 29);
            this.label_SerialPortStatus.Name = "label_SerialPortStatus";
            this.label_SerialPortStatus.Size = new System.Drawing.Size(42, 18);
            this.label_SerialPortStatus.TabIndex = 111;
            this.label_SerialPortStatus.Text = "None";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button97);
            this.groupBox4.Controls.Add(this.textBox_SystemStatus);
            this.groupBox4.Location = new System.Drawing.Point(1561, 458);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(191, 217);
            this.groupBox4.TabIndex = 114;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "User information";
            // 
            // button97
            // 
            this.button97.Location = new System.Drawing.Point(5, 188);
            this.button97.Name = "button97";
            this.button97.Size = new System.Drawing.Size(58, 23);
            this.button97.TabIndex = 114;
            this.button97.Text = "Clear";
            this.button97.UseVisualStyleBackColor = true;
            this.button97.Click += new System.EventHandler(this.button97_Click);
            // 
            // textBox_SystemStatus
            // 
            this.textBox_SystemStatus.Location = new System.Drawing.Point(6, 17);
            this.textBox_SystemStatus.Multiline = true;
            this.textBox_SystemStatus.Name = "textBox_SystemStatus";
            this.textBox_SystemStatus.ReadOnly = true;
            this.textBox_SystemStatus.Size = new System.Drawing.Size(180, 168);
            this.textBox_SystemStatus.TabIndex = 113;
            this.textBox_SystemStatus.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1561, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 38);
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox_ClentTCPStatus
            // 
            this.groupBox_ClentTCPStatus.Controls.Add(this.label_TCPClient);
            this.groupBox_ClentTCPStatus.Controls.Add(this.label12);
            this.groupBox_ClentTCPStatus.Controls.Add(this.label_ClientTCPConnected);
            this.groupBox_ClentTCPStatus.Controls.Add(this.label14);
            this.groupBox_ClentTCPStatus.Location = new System.Drawing.Point(1561, 192);
            this.groupBox_ClentTCPStatus.Name = "groupBox_ClentTCPStatus";
            this.groupBox_ClentTCPStatus.Size = new System.Drawing.Size(191, 106);
            this.groupBox_ClentTCPStatus.TabIndex = 112;
            this.groupBox_ClentTCPStatus.TabStop = false;
            this.groupBox_ClentTCPStatus.Text = "Client TCP";
            // 
            // label_TCPClient
            // 
            this.label_TCPClient.AutoSize = true;
            this.label_TCPClient.Location = new System.Drawing.Point(92, 29);
            this.label_TCPClient.Name = "label_TCPClient";
            this.label_TCPClient.Size = new System.Drawing.Size(45, 18);
            this.label_TCPClient.TabIndex = 111;
            this.label_TCPClient.Text = " None";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 18);
            this.label12.TabIndex = 110;
            this.label12.Text = "Tx";
            // 
            // label_ClientTCPConnected
            // 
            this.label_ClientTCPConnected.AutoSize = true;
            this.label_ClientTCPConnected.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ClientTCPConnected.Location = new System.Drawing.Point(17, 29);
            this.label_ClientTCPConnected.Name = "label_ClientTCPConnected";
            this.label_ClientTCPConnected.Size = new System.Drawing.Size(69, 18);
            this.label_ClientTCPConnected.TabIndex = 109;
            this.label_ClientTCPConnected.Text = "Conneted";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 18);
            this.label14.TabIndex = 108;
            this.label14.Text = "Rx";
            // 
            // checkedListBox_PhoneBook
            // 
            this.checkedListBox_PhoneBook.FormattingEnabled = true;
            this.checkedListBox_PhoneBook.Location = new System.Drawing.Point(5, 19);
            this.checkedListBox_PhoneBook.Name = "checkedListBox_PhoneBook";
            this.checkedListBox_PhoneBook.Size = new System.Drawing.Size(279, 289);
            this.checkedListBox_PhoneBook.TabIndex = 0;
            this.checkedListBox_PhoneBook.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox_PhoneBook_SelectedIndexChanged);
            this.checkedListBox_PhoneBook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckedListBox_PhoneBook_KeyDown);
            this.checkedListBox_PhoneBook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckedListBox_PhoneBook_MouseDown);
            // 
            // button_AddContact
            // 
            this.button_AddContact.Location = new System.Drawing.Point(7, 371);
            this.button_AddContact.Name = "button_AddContact";
            this.button_AddContact.Size = new System.Drawing.Size(75, 23);
            this.button_AddContact.TabIndex = 1;
            this.button_AddContact.Text = "Add";
            this.button_AddContact.UseVisualStyleBackColor = true;
            this.button_AddContact.Click += new System.EventHandler(this.Button33_Click_1);
            // 
            // button_RemoveContact
            // 
            this.button_RemoveContact.Location = new System.Drawing.Point(88, 371);
            this.button_RemoveContact.Name = "button_RemoveContact";
            this.button_RemoveContact.Size = new System.Drawing.Size(75, 23);
            this.button_RemoveContact.TabIndex = 2;
            this.button_RemoveContact.Text = "Remove";
            this.button_RemoveContact.UseVisualStyleBackColor = true;
            this.button_RemoveContact.Click += new System.EventHandler(this.Button_RemoveContact_Click);
            // 
            // button_ExportToXML
            // 
            this.button_ExportToXML.Location = new System.Drawing.Point(7, 400);
            this.button_ExportToXML.Name = "button_ExportToXML";
            this.button_ExportToXML.Size = new System.Drawing.Size(75, 23);
            this.button_ExportToXML.TabIndex = 3;
            this.button_ExportToXML.Text = "Export";
            this.button_ExportToXML.UseVisualStyleBackColor = true;
            this.button_ExportToXML.Click += new System.EventHandler(this.Button_ExportToXML_Click);
            // 
            // button_ImportToXML
            // 
            this.button_ImportToXML.Location = new System.Drawing.Point(88, 400);
            this.button_ImportToXML.Name = "button_ImportToXML";
            this.button_ImportToXML.Size = new System.Drawing.Size(75, 23);
            this.button_ImportToXML.TabIndex = 4;
            this.button_ImportToXML.Text = "Import";
            this.button_ImportToXML.UseVisualStyleBackColor = true;
            this.button_ImportToXML.Click += new System.EventHandler(this.Button_ImportToXML_Click);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(169, 371);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(75, 23);
            this.button33.TabIndex = 5;
            this.button33.Text = "Edit";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.Button33_Click_2);
            // 
            // richTextBox_ContactDetails
            // 
            this.richTextBox_ContactDetails.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_ContactDetails.Location = new System.Drawing.Point(290, 19);
            this.richTextBox_ContactDetails.Name = "richTextBox_ContactDetails";
            this.richTextBox_ContactDetails.Size = new System.Drawing.Size(166, 328);
            this.richTextBox_ContactDetails.TabIndex = 6;
            this.richTextBox_ContactDetails.Text = "";
            this.richTextBox_ContactDetails.TextChanged += new System.EventHandler(this.RichTextBox_ContactDetails_TextChanged);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(169, 400);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(75, 23);
            this.button34.TabIndex = 7;
            this.button34.Text = "Backup";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.Button34_Click_2);
            // 
            // richTextBox_TextSendSMS
            // 
            this.richTextBox_TextSendSMS.AutoWordSelection = true;
            this.richTextBox_TextSendSMS.EnableAutoDragDrop = true;
            this.richTextBox_TextSendSMS.Location = new System.Drawing.Point(10, 18);
            this.richTextBox_TextSendSMS.Name = "richTextBox_TextSendSMS";
            this.richTextBox_TextSendSMS.Size = new System.Drawing.Size(579, 91);
            this.richTextBox_TextSendSMS.TabIndex = 2;
            this.richTextBox_TextSendSMS.Text = "";
            this.richTextBox_TextSendSMS.TextChanged += new System.EventHandler(this.RichTextBox_TextSendSMS_TextChanged);
            // 
            // label_SMSSendCharacters
            // 
            this.label_SMSSendCharacters.AutoSize = true;
            this.label_SMSSendCharacters.Location = new System.Drawing.Point(12, 119);
            this.label_SMSSendCharacters.Name = "label_SMSSendCharacters";
            this.label_SMSSendCharacters.Size = new System.Drawing.Size(36, 13);
            this.label_SMSSendCharacters.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(145, 145);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 22);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox_SendSMSAsIs
            // 
            this.checkBox_SendSMSAsIs.AutoSize = true;
            this.checkBox_SendSMSAsIs.Location = new System.Drawing.Point(240, 115);
            this.checkBox_SendSMSAsIs.Name = "checkBox_SendSMSAsIs";
            this.checkBox_SendSMSAsIs.Size = new System.Drawing.Size(116, 22);
            this.checkBox_SendSMSAsIs.TabIndex = 11;
            this.checkBox_SendSMSAsIs.Text = "Send SMS as is";
            this.checkBox_SendSMSAsIs.UseVisualStyleBackColor = true;
            this.checkBox_SendSMSAsIs.CheckedChanged += new System.EventHandler(this.CheckBox_SendSMSAsIs_CheckedChanged);
            // 
            // checkBox_SMSencrypted
            // 
            this.checkBox_SMSencrypted.AutoSize = true;
            this.checkBox_SMSencrypted.Location = new System.Drawing.Point(595, 20);
            this.checkBox_SMSencrypted.Name = "checkBox_SMSencrypted";
            this.checkBox_SMSencrypted.Size = new System.Drawing.Size(89, 22);
            this.checkBox_SMSencrypted.TabIndex = 12;
            this.checkBox_SMSencrypted.Text = "Encrypted";
            this.checkBox_SMSencrypted.UseVisualStyleBackColor = true;
            this.checkBox_SMSencrypted.CheckedChanged += new System.EventHandler(this.CheckBox_SMSencrypted_CheckedChanged);
            // 
            // GrooupBox_Encryption
            // 
            this.GrooupBox_Encryption.Enabled = false;
            this.GrooupBox_Encryption.Location = new System.Drawing.Point(595, 38);
            this.GrooupBox_Encryption.Name = "GrooupBox_Encryption";
            this.GrooupBox_Encryption.Size = new System.Drawing.Size(184, 103);
            this.GrooupBox_Encryption.TabIndex = 13;
            this.GrooupBox_Encryption.TabStop = false;
            // 
            // textBox_UnitIDForSMS
            // 
            this.textBox_UnitIDForSMS.Location = new System.Drawing.Point(54, 17);
            this.textBox_UnitIDForSMS.MaxLength = 16;
            this.textBox_UnitIDForSMS.Name = "textBox_UnitIDForSMS";
            this.textBox_UnitIDForSMS.Size = new System.Drawing.Size(124, 20);
            this.textBox_UnitIDForSMS.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            // 
            // textBox_CodeArrayForSMS
            // 
            this.textBox_CodeArrayForSMS.Location = new System.Drawing.Point(54, 46);
            this.textBox_CodeArrayForSMS.MaxLength = 4;
            this.textBox_CodeArrayForSMS.Name = "textBox_CodeArrayForSMS";
            this.textBox_CodeArrayForSMS.Size = new System.Drawing.Size(124, 20);
            this.textBox_CodeArrayForSMS.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 3;
            // 
            // richTextBox_ModemStatus
            // 
            this.richTextBox_ModemStatus.Location = new System.Drawing.Point(7, 19);
            this.richTextBox_ModemStatus.Name = "richTextBox_ModemStatus";
            this.richTextBox_ModemStatus.Size = new System.Drawing.Size(256, 115);
            this.richTextBox_ModemStatus.TabIndex = 0;
            this.richTextBox_ModemStatus.Text = "";
            // 
            // comboBox_ComportSMS
            // 
            this.comboBox_ComportSMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ComportSMS.FormattingEnabled = true;
            this.comboBox_ComportSMS.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.comboBox_ComportSMS.Location = new System.Drawing.Point(290, 22);
            this.comboBox_ComportSMS.Name = "comboBox_ComportSMS";
            this.comboBox_ComportSMS.Size = new System.Drawing.Size(67, 21);
            this.comboBox_ComportSMS.TabIndex = 9;
            this.comboBox_ComportSMS.Tag = "1";
            this.comboBox_ComportSMS.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged_2);
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(269, 109);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(75, 23);
            this.button36.TabIndex = 6;
            this.button36.Text = "Clear";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.Button36_Click);
            // 
            // checkBox_OpenPortSMS
            // 
            this.checkBox_OpenPortSMS.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_OpenPortSMS.AutoSize = true;
            this.checkBox_OpenPortSMS.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_OpenPortSMS.Location = new System.Drawing.Point(363, 20);
            this.checkBox_OpenPortSMS.Name = "checkBox_OpenPortSMS";
            this.checkBox_OpenPortSMS.Size = new System.Drawing.Size(84, 29);
            this.checkBox_OpenPortSMS.TabIndex = 10;
            this.checkBox_OpenPortSMS.Text = "Open Port";
            this.checkBox_OpenPortSMS.UseVisualStyleBackColor = true;
            this.checkBox_OpenPortSMS.CheckedChanged += new System.EventHandler(this.CheckBox_OpenPortSMS_CheckedChanged);
            // 
            // checkBox_DebugSMS
            // 
            this.checkBox_DebugSMS.AutoSize = true;
            this.checkBox_DebugSMS.Location = new System.Drawing.Point(390, 54);
            this.checkBox_DebugSMS.Name = "checkBox_DebugSMS";
            this.checkBox_DebugSMS.Size = new System.Drawing.Size(67, 22);
            this.checkBox_DebugSMS.TabIndex = 11;
            this.checkBox_DebugSMS.Text = "Debug";
            this.checkBox_DebugSMS.UseVisualStyleBackColor = true;
            // 
            // button_ClearSMSConsole
            // 
            this.button_ClearSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearSMSConsole.Location = new System.Drawing.Point(395, 630);
            this.button_ClearSMSConsole.Name = "button_ClearSMSConsole";
            this.button_ClearSMSConsole.Size = new System.Drawing.Size(62, 26);
            this.button_ClearSMSConsole.TabIndex = 6;
            this.button_ClearSMSConsole.Text = "Clear";
            this.button_ClearSMSConsole.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseSMSConsole
            // 
            this.checkBox_PauseSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_PauseSMSConsole.AutoSize = true;
            this.checkBox_PauseSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_PauseSMSConsole.Location = new System.Drawing.Point(327, 630);
            this.checkBox_PauseSMSConsole.Name = "checkBox_PauseSMSConsole";
            this.checkBox_PauseSMSConsole.Size = new System.Drawing.Size(62, 26);
            this.checkBox_PauseSMSConsole.TabIndex = 5;
            this.checkBox_PauseSMSConsole.Text = "Pause";
            this.checkBox_PauseSMSConsole.UseVisualStyleBackColor = true;
            // 
            // checkBox_RecordSMSConsole
            // 
            this.checkBox_RecordSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordSMSConsole.AutoSize = true;
            this.checkBox_RecordSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordSMSConsole.Location = new System.Drawing.Point(222, 630);
            this.checkBox_RecordSMSConsole.Name = "checkBox_RecordSMSConsole";
            this.checkBox_RecordSMSConsole.Size = new System.Drawing.Size(99, 26);
            this.checkBox_RecordSMSConsole.TabIndex = 7;
            this.checkBox_RecordSMSConsole.Text = "Record Log";
            this.checkBox_RecordSMSConsole.UseVisualStyleBackColor = true;
            // 
            // richTextBox_SMSConsole
            // 
            this.richTextBox_SMSConsole.EnableAutoDragDrop = true;
            this.richTextBox_SMSConsole.Location = new System.Drawing.Point(6, 17);
            this.richTextBox_SMSConsole.Name = "richTextBox_SMSConsole";
            this.richTextBox_SMSConsole.Size = new System.Drawing.Size(451, 607);
            this.richTextBox_SMSConsole.TabIndex = 0;
            this.richTextBox_SMSConsole.Text = "";
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(7, 359);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(75, 23);
            this.button41.TabIndex = 1;
            this.button41.Text = "Add";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.Button41_Click);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(88, 359);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(75, 23);
            this.button40.TabIndex = 2;
            this.button40.Text = "Remove";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.Button40_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(7, 395);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(75, 23);
            this.button39.TabIndex = 3;
            this.button39.Text = "Export";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.Button39_Click_1);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(88, 395);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(75, 23);
            this.button38.TabIndex = 4;
            this.button38.Text = "Import";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.Button38_Click);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(169, 359);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(75, 23);
            this.button37.TabIndex = 5;
            this.button37.Text = "Edit";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.Button37_Click);
            // 
            // listBox_SMSCommands
            // 
            this.listBox_SMSCommands.FormattingEnabled = true;
            this.listBox_SMSCommands.Location = new System.Drawing.Point(6, 17);
            this.listBox_SMSCommands.Name = "listBox_SMSCommands";
            this.listBox_SMSCommands.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_SMSCommands.Size = new System.Drawing.Size(303, 290);
            this.listBox_SMSCommands.TabIndex = 6;
            this.listBox_SMSCommands.SelectedIndexChanged += new System.EventHandler(this.ListBox_SMSCommands_SelectedIndexChanged_1);
            // 
            // button_WriteCatalinas
            // 
            this.button_WriteCatalinas.Location = new System.Drawing.Point(789, 449);
            this.button_WriteCatalinas.Name = "button_WriteCatalinas";
            this.button_WriteCatalinas.Size = new System.Drawing.Size(144, 23);
            this.button_WriteCatalinas.TabIndex = 69;
            this.button_WriteCatalinas.Text = "Write Files To Flash";
            this.button_WriteCatalinas.UseVisualStyleBackColor = true;
            this.button_WriteCatalinas.Click += new System.EventHandler(this.button72_Click_2);
            // 
            // textBox_FilesToWriteForTheCatalinas
            // 
            this.textBox_FilesToWriteForTheCatalinas.Location = new System.Drawing.Point(0, 311);
            this.textBox_FilesToWriteForTheCatalinas.Name = "textBox_FilesToWriteForTheCatalinas";
            this.textBox_FilesToWriteForTheCatalinas.Size = new System.Drawing.Size(933, 131);
            this.textBox_FilesToWriteForTheCatalinas.TabIndex = 70;
            this.textBox_FilesToWriteForTheCatalinas.Text = "";
            this.textBox_FilesToWriteForTheCatalinas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_FilesToWriteForTheCatalinas2_MouseDown);
            // 
            // richTextBox_SyntisazerL1
            // 
            this.richTextBox_SyntisazerL1.Location = new System.Drawing.Point(5, 111);
            this.richTextBox_SyntisazerL1.Name = "richTextBox_SyntisazerL1";
            this.richTextBox_SyntisazerL1.Size = new System.Drawing.Size(161, 124);
            this.richTextBox_SyntisazerL1.TabIndex = 71;
            this.richTextBox_SyntisazerL1.Text = "";
            this.richTextBox_SyntisazerL1.TextChanged += new System.EventHandler(this.richTextBox_SyntisazerL1_TextChanged);
            this.richTextBox_SyntisazerL1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox_SyntisazerL1_MouseDown);
            // 
            // richTextBox_SyntisazerL2
            // 
            this.richTextBox_SyntisazerL2.Location = new System.Drawing.Point(243, 108);
            this.richTextBox_SyntisazerL2.Name = "richTextBox_SyntisazerL2";
            this.richTextBox_SyntisazerL2.Size = new System.Drawing.Size(161, 132);
            this.richTextBox_SyntisazerL2.TabIndex = 72;
            this.richTextBox_SyntisazerL2.Text = "";
            this.richTextBox_SyntisazerL2.TextChanged += new System.EventHandler(this.richTextBox_SyntisazerL2_TextChanged);
            this.richTextBox_SyntisazerL2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox_SyntisazerL2_MouseDown);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A",
            "B"});
            this.comboBox1.Location = new System.Drawing.Point(371, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(37, 21);
            this.comboBox1.TabIndex = 73;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_3);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 87);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 13);
            this.label20.TabIndex = 74;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(240, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 13);
            this.label21.TabIndex = 75;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 76;
            // 
            // button_WriteSystemType
            // 
            this.button_WriteSystemType.Location = new System.Drawing.Point(89, 45);
            this.button_WriteSystemType.Name = "button_WriteSystemType";
            this.button_WriteSystemType.Size = new System.Drawing.Size(188, 23);
            this.button_WriteSystemType.TabIndex = 78;
            this.button_WriteSystemType.Text = "Write System type to flash";
            this.button_WriteSystemType.UseVisualStyleBackColor = true;
            this.button_WriteSystemType.Click += new System.EventHandler(this.button73_Click_1);
            // 
            // button_SynthL1
            // 
            this.button_SynthL1.Location = new System.Drawing.Point(2, 244);
            this.button_SynthL1.Name = "button_SynthL1";
            this.button_SynthL1.Size = new System.Drawing.Size(227, 23);
            this.button_SynthL1.TabIndex = 79;
            this.button_SynthL1.Text = "Write Synthesizer L1";
            this.button_SynthL1.UseVisualStyleBackColor = true;
            this.button_SynthL1.Click += new System.EventHandler(this.button96_Click_2);
            // 
            // button_WriteAllToFlash
            // 
            this.button_WriteAllToFlash.BackColor = System.Drawing.Color.Transparent;
            this.button_WriteAllToFlash.Location = new System.Drawing.Point(789, 24);
            this.button_WriteAllToFlash.Name = "button_WriteAllToFlash";
            this.button_WriteAllToFlash.Size = new System.Drawing.Size(144, 34);
            this.button_WriteAllToFlash.TabIndex = 80;
            this.button_WriteAllToFlash.Text = "Write all to flash";
            this.button_WriteAllToFlash.UseVisualStyleBackColor = false;
            this.button_WriteAllToFlash.Click += new System.EventHandler(this.button100_Click_2);
            // 
            // button_SynthL2
            // 
            this.button_SynthL2.Location = new System.Drawing.Point(243, 244);
            this.button_SynthL2.Name = "button_SynthL2";
            this.button_SynthL2.Size = new System.Drawing.Size(227, 23);
            this.button_SynthL2.TabIndex = 81;
            this.button_SynthL2.Text = "Write Synthesizer L2";
            this.button_SynthL2.UseVisualStyleBackColor = true;
            this.button_SynthL2.Click += new System.EventHandler(this.button101_Click);
            // 
            // progressBar_WriteToFlash
            // 
            this.progressBar_WriteToFlash.Location = new System.Drawing.Point(789, 68);
            this.progressBar_WriteToFlash.Name = "progressBar_WriteToFlash";
            this.progressBar_WriteToFlash.Size = new System.Drawing.Size(144, 23);
            this.progressBar_WriteToFlash.TabIndex = 82;
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.button2);
            this.groupBox38.Controls.Add(this.button30);
            this.groupBox38.Location = new System.Drawing.Point(1365, 44);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(154, 134);
            this.groupBox38.TabIndex = 22;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Flash";
            // 
            // groupBox48
            // 
            this.groupBox48.Controls.Add(this.button6);
            this.groupBox48.Controls.Add(this.button29);
            this.groupBox48.Location = new System.Drawing.Point(1365, 190);
            this.groupBox48.Name = "groupBox48";
            this.groupBox48.Size = new System.Drawing.Size(154, 134);
            this.groupBox48.TabIndex = 23;
            this.groupBox48.TabStop = false;
            this.groupBox48.Text = "CSV file";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(6, 23);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(139, 45);
            this.button6.TabIndex = 18;
            this.button6.Text = "Read CSV file";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.Transparent;
            this.button29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button29.Location = new System.Drawing.Point(6, 79);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(139, 45);
            this.button29.TabIndex = 21;
            this.button29.Text = "Write CSV file";
            this.button29.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1801, 761);
            this.Controls.Add(this.groupBox_ClentTCPStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button_OpenFolder);
            this.Controls.Add(this.groupBox_SerialPort);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.groupBox36);
            this.Controls.Add(this.groupBox_PhoneNumber);
            this.Controls.Add(this.groupBox42);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "3038 - WB PAA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed_1);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox_ServerSettings.ResumeLayout(false);
            this.groupBox_ServerSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_charts.ResumeLayout(false);
            this.tabPage_charts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage_ServerTCP.ResumeLayout(false);
            this.tabPage_ServerTCP.PerformLayout();
            this.groupBox_FOTA.ResumeLayout(false);
            this.groupBox_FOTA.PerformLayout();
            this.groupBox_ConnectionTimedOut.ResumeLayout(false);
            this.groupBox_ConnectionTimedOut.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage_ClientTCP.ResumeLayout(false);
            this.tabPage_ClientTCP.PerformLayout();
            this.tabPage_SerialPort.ResumeLayout(false);
            this.groupBox_SendSerialOrMonitorCommands.ResumeLayout(false);
            this.groupBox_SendSerialOrMonitorCommands.PerformLayout();
            this.gbPortSettings.ResumeLayout(false);
            this.gbPortSettings.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox_Timer.ResumeLayout(false);
            this.groupBox_Timer.PerformLayout();
            this.groupBox_Stopwatch.ResumeLayout(false);
            this.groupBox_Stopwatch.PerformLayout();
            this.tabPage_GenericFrame.ResumeLayout(false);
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            this.groupBox_clientTX.ResumeLayout(false);
            this.groupBox_clientTX.PerformLayout();
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            this.tabPage_Commands.ResumeLayout(false);
            this.groupBox40.ResumeLayout(false);
            this.tabControl_System.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox43.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox47.ResumeLayout(false);
            this.groupBox47.PerformLayout();
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox46.ResumeLayout(false);
            this.groupBox46.PerformLayout();
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            this.groupBox44.ResumeLayout(false);
            this.groupBox44.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ValPage0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OverUnder)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Page1_4)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VVAOffset1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VVAOffset2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PAVVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DC4)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            this.groupBox42.ResumeLayout(false);
            this.groupBox42.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.S1_Configuration.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox_PhoneNumber.ResumeLayout(false);
            this.groupBox_PhoneNumber.PerformLayout();
            this.groupBox_SerialPort.ResumeLayout(false);
            this.groupBox_SerialPort.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_ClentTCPStatus.ResumeLayout(false);
            this.groupBox_ClentTCPStatus.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox48.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        readonly List<String> CommandsHistoy = new List<String>();
        int HistoryIndex = -1;
        // bool SelfMonitorCommandsMode = false;


        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //Change appearance of tabcontrol
            Brush backBrush;
            Brush foreBrush;

            backBrush = new SolidBrush(Color.Red);
            foreBrush = new SolidBrush(Color.Blue);

            e.Graphics.FillRectangle(backBrush, e.Bounds);

            //You may need to write the label here also?
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString("my label", e.Font, foreBrush, r, sf);
        }

        private void ListBox_SMSCommands_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < listBox_SMSCommands.Items.Count)
            {
                Graphics g = e.Graphics;

                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.Red : Color.White);
                g.FillRectangle(backgroundColorBrush, e.Bounds);

                // Set text color
                string itemText = listBox_SMSCommands.Items[itemIndex].ToString();

                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.White) : new SolidBrush(Color.Black);
                g.DrawString(itemText, e.Font, itemTextColorBrush, listBox_SMSCommands.GetItemRectangle(itemIndex).Location);

                // Clean up
                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        void ListBox_SMSCommands_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedCommand();
            }
        }

        void CheckedListBox_PhoneBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedContact();
            }
        }

        static Boolean PhoneBookIsChecked = false;
        void CheckedListBox_PhoneBook_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PhoneBookIsChecked = !PhoneBookIsChecked;

                if (PhoneBookIsChecked == true)
                {
                    for (int x = 0; x < checkedListBox_PhoneBook.Items.Count; x++)
                    {
                        checkedListBox_PhoneBook.SetItemChecked(x, true);
                    }
                }
                else
                {
                    for (int x = 0; x < checkedListBox_PhoneBook.Items.Count; x++)
                    {
                        checkedListBox_PhoneBook.SetItemChecked(x, false);
                    }
                }

            }
        }

        void TextBox_GeneralMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Then Enter key was pressed

                //button29.PerformClick();
            }
        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.Run(new MainForm());


        }











        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (comboBox_ConnectionNumber.Text == "None")
            {
                return;
            }
            try
            {
                //int ConNum = int.Parse(comboBox_ConnectionNumber.Text);
                string SendString =/*tempcount.ToString() + "  " +*/ txtDataTx.Text;
                Object objData = SendString;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                SendDataToServer(comboBox_ConnectionNumber.SelectedItem.ToString(), byData);
            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }
        }

        //bool SerialPortSMSSendData(byte[] i_SendData)
        //{

        //    //if (serialPort_SMS.IsOpen)
        //    //{
        //    //    // Send the binary data out the port
        //    //    serialPort_SMS.Write(i_SendData, 0, i_SendData.Length);

        //    //    if (checkBox_DebugSMS.Checked == true)
        //    //    {
        //    //        //LogSMS.LogMessage(Color.Black, Color.LightGray, "", New_Line = false, Show_Time = true);
        //    //      //  LogSMS.LogMessage(Color.DarkViolet, Color.LightGray, "Send Data: ", false, false);
        //    //       // LogSMS.LogMessage(Color.DarkGreen, Color.LightGray, Encoding.ASCII.GetString(i_SendData), true, false);
        //    //    }

        //    //    return true;

        //    //}

        //    //return false;
        //}

        bool SerialPortSendData(byte[] i_SendData)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    // Send the binary data out the port
                    serialPort.Write(i_SendData, 0, i_SendData.Length);

                    return true;

                }
            }
            catch (Exception ex)
            {
                SendExceptionToTheMonitor(ex.Message.ToString());

            }


            return false;
        }

        private void SendExceptionToTheMonitor(String i_Message)
        {
            SerialPortLogger.LogMessage(Color.Red, Color.LightGray, i_Message, New_Line = true, Show_Time = true);
        }
        //Color oldColor;
        Gil_Server.Server m_Server;
        private void ListenBox_CheckedChanged(object sender, EventArgs e)
        {
            // Gil: Just to remove the warnings
            New_Line = !New_Line;
            Show_Time = !Show_Time;


            if (ListenBox.Checked)
            {
                //m_Exit = false;
                //oldColor = ListenBox.BackColor;
                ListenBox.BackColor = Color.Gray;
                try
                {


                    m_Server = new Gil_Server.Server(txtPortNo.Text);
                    m_Server.DataRecievedNotifyDelegate += new EventHandler(GilServer_DataRecievedNotifyDelegate);
                    m_Server.InformationNotifyDelegate += new EventHandler(Server_InformationNotifyDelegate);

                    m_Server.Open_Server();

                    txtPortNo.Enabled = false;



                }
                catch (SocketException se)
                {
                    ServerLogger.LogMessage(Color.Black, Color.White, "Exception:  " + se.ToString(), true, true);
                }
            }
            else
            {
                ListenBox.BackColor = default;

                m_Server.Close_Server();

                txtPortNo.Enabled = true;

            }
        }

        void Server_InformationNotifyDelegate(object sender, EventArgs e)
        {
            Gil_Server.Server.stringEventArgs mye = (Gil_Server.Server.stringEventArgs)e;

            ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            ServerLogger.LogMessage(Color.Brown, Color.White, "[Internal Server] ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.Black, Color.White, mye.StrData, New_Line = true, Show_Time = false);
        }

        static int LastIgn = 1;
        static int TimerStatusRingWait = 0;

        //string[] UnitNumberToConnections = new string[30];
        readonly Dictionary<string, string> ConnectionToIDdictionary = new Dictionary<string, string>();
        readonly Dictionary<string, string> IDToFOTA_Status = new Dictionary<string, string>();
        void GilServer_DataRecievedNotifyDelegate(object sender, EventArgs e)
        {

            Gil_Server.Server.DataEventArgs mye = (Gil_Server.Server.DataEventArgs)e;

            ASCIIEncoding encoder = new ASCIIEncoding();

            // string IncomingString = System.Text.Encoding.Default.GetString(mye.BytesData);
            string IncomingString = ByteArrayToString(mye.BytesData.Take(40).ToArray());
            //IncomingString = IncomingString.Replace("\0", "");

            ServerLogger.LogMessage(Color.Black, Color.White, "\n\nData Received: ", New_Line = false, Show_Time = true);
            ServerLogger.LogMessage(Color.Blue, Color.White, "Connection: " + mye.ConnectionNumber, New_Line = false, Show_Time = false);
            //     ServerLogger.LogMessage(Color.Black, Color.White, " \" ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.DarkGreen, Color.White, "    " + IncomingString, New_Line = true, Show_Time = false);

            if (checkBox_EchoResponse.Checked == true)
            {

                string ACKBack = string.Format("[{0}],ACK", IncomingString);
                byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                SendDataToServer(mye.ConnectionNumber, b2);
            }


            if (checkBox_ParseMessages.Checked == false)
            {
                return;
            }

            string[] ParseStrings = { "" };
            string[] Key = { "" };
            try
            {
                if (IncomingString.Contains(","))
                {
                    ParseStrings = IncomingString.Split(',');
                    Key = ParseStrings[1].Split('=');
                }
            }
            catch
            {
                ServerLogger.LogMessage(Color.Black, Color.White, "Data Not Valid: " + IncomingString, New_Line = true, Show_Time = true);
                return;
            }

            //string[] UnitNumberToConnections = new List<string>();

            if (ConnectionToIDdictionary.ContainsKey(mye.ConnectionNumber) == false)
            {
                ConnectionToIDdictionary.Add(mye.ConnectionNumber, ParseStrings[0]);
            }
            PrintDictineryIDKeys();
            //UnitNumberToConnections[mye.ConnectionNumber] = ParseStrings[0];

            //dataSource.Add("None");
            //comboBox_ConnectionNumber.DataSource = dataSource;

            //comboBox_ConnectionNumber.DataSource = mye.ConnectionNumber + " " + IncomingString[0];

            if (Key[0] == "POS")
            {

                //if (checkBox_ServerView.Checked == true)
                //{

                //    LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: Server", New_Line = false, Show_Time = true);
                //    LogIWatcher.LogMessage(Color.Brown, Color.White, "POSITION Message Received: ", New_Line = false, Show_Time = true);

                //    string PositionString =
                //        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                //        "\n STATE = " + Key[1] +
                //        "\n GSM LINK QUALITY = " + ParseStrings[2] +
                //        "\n GPS STATUS = " + ParseStrings[3] +
                //        "\n GPS NUM OF SATELLITES = " + ParseStrings[4] +
                //        "\n CURRENT TIME AND DATE = " + ParseStrings[5] + " " + ParseStrings[6] +
                //        "\n LAST GPS TIME AND DATE = " + ParseStrings[7] + " " + ParseStrings[8] +
                //        "\n GPS LATITUDE = " + ParseStrings[9] +
                //        "\n GPS LONGTITUDE = " + ParseStrings[10] +
                //        "\n GPS SPEED = " + ParseStrings[11] +
                //        "\n GPS DIRECTION =" + ParseStrings[12] +
                //        "\n TRIP DISTANCE  = " + ParseStrings[13] +
                //        "\n TOTAL DISTANCE = " + ParseStrings[14] +
                //        "\n ANALOG 1  = " + ParseStrings[15] +
                //        "\n ANALOG 2  = " + ParseStrings[16] +
                //        "\n MESSAGE NUMBER  = " + ParseStrings[17];
                //    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                //    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                //    LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                //}

                //  string ret = "";
                //if (checkBox_ShowURL.Checked)
                //{
                //    ret = "http://maps.google.com/maps?q=" + ParseStrings[9] + "," + ParseStrings[10] + "( " + " Current Time: " + DateTime.Now + "\r\n   S1TimeStamp: " + " )" + "&z=14&ll=" + "," + "&z=17";
                //    Show_WebBrowserUrl(ret);
                //}

                //if (checkBox_RecordLatLong.Checked)
                //{

                //    NumOfPositionMessage++;
                //    //354869050154426,POS=1,GSMLinkQual,5,8,12/9/2013,10:55:11,12/9/2013,10:55:11,32.155636,34.920308,0,304.2,


                //    KMl_text.Add("<Placemark>");
                //    KMl_text.Add("<name>" + "[" + NumOfPositionMessage + "]" + " " + DateTime.Now + "  </name>");
                //    KMl_text.Add("<Point>");
                //    KMl_text.Add("<coordinates>" + ParseStrings[10] + "," + ParseStrings[9] + "</coordinates> ");
                //    KMl_text.Add("</Point>");
                //    KMl_text.Add("</Placemark> ");
                //    KMl_text.Add("</Document> \n");
                //    KMl_text.Add("</kml> \n");

                //    File.Delete(log_file_S1_LatLong);
                //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(log_file_S1_LatLong))
                //    {
                //        foreach (string str in KMl_text)
                //        {
                //            file.WriteLine(str);
                //        }
                //        //for (int i = 0; i < KML_Index; i++)
                //        //{

                //        //}
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        // KML_Index -= 2;
                //    }


                //}

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }


            }
            else
            if (Key[0] == "STAT")
            {

                //if (checkBox_ServerView.Checked == true)
                //{

                //    LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: Server", New_Line = false, Show_Time = true);
                //    LogIWatcher.LogMessage(Color.Red, Color.White, "STATUS Message Received: ", New_Line = false, Show_Time = true);

                //    string PositionString =
                //        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                //        "\n SYSTEM STATE = " + Key[1] +
                //        "\n IGN STATE = " + ParseStrings[2] +
                //        "\n GP1 = " + ParseStrings[3] +
                //        "\n GP2 = " + ParseStrings[4] +
                //        "\n GP3 = " + ParseStrings[5] +
                //        "\n Main Power Source = " + ParseStrings[6] +
                //        "\n Back Up Battery problem indication = " + ParseStrings[7] +
                //        "\n OUTPUT 1  STATE = " + ParseStrings[8] +
                //        "\n OUTPUT 2  STATE = " + ParseStrings[9] +
                //        "\n OUTPUT 3  STATE = " + ParseStrings[10] +
                //        "\n OUTPUT 4  STATE = " + ParseStrings[11] +
                //        "\n DATE = " + ParseStrings[12] +
                //        "\n TIME  = " + ParseStrings[13] +
                //        "\n GPS LATITUDE = " + ParseStrings[14] +
                //        "\n GPS LONGTITUDE = " + ParseStrings[15] +
                //        "\n VEHICLE SPEED = " + ParseStrings[16] +
                //        "\n SPEED EVENT  = " + ParseStrings[17] +
                //        "\n BATTERY LOW EVENT =" + ParseStrings[18] +
                //        "\n BATTERY CUT OFF EVENT  = " + ParseStrings[19] +
                //        "\n ACCIDENT EVENT = " + ParseStrings[20] +
                //        "\n TOWING EVENT = " + ParseStrings[21] +
                //        "\n TILT EVENT = " + ParseStrings[22] +
                //        "\n ANTI JAMMING  EVENT = " + ParseStrings[23] +
                //        "\n MESSAGE NUMBER = " + ParseStrings[24];
                //    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                //    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                //    LogIWatcher.LogMessage(Color.Red, Color.White, PositionString, New_Line = true, Show_Time = false);
                //}

                string[] ign = ParseStrings[1].Split('=');
                int Newign = int.Parse(ign[1]);
                if (Newign == 1 && LastIgn == 0)
                {
                    ServerLogger.LogMessage(Color.Blue, Color.White, "New Driving Log Opened", New_Line = true, Show_Time = true);

                    //checkBox_RecordLatLong.Invoke(new EventHandler(delegate
                    //{

                    //    checkBox_RecordLatLong.Checked = false;
                    //    checkBox_RecordLatLong.Checked = true;

                    //}));


                }

                LastIgn = Newign;

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

                // Gil: Comare if the Unit ID is the target Unit ID For encrypted GPRS
                if (TimerStatusRingWait > 0 && SendOneTimeFlag == 1)
                {
                    if (ParseStrings[0].Replace(";", "") == textBox_UnitIDForSMS.Text)
                    {
                        //TimerStatusRingWait = 0;
                        SendOneTimeFlag = 0;
                        byte[] b2 = System.Text.Encoding.ASCII.GetBytes(txtDataTx.Text);
                        SendDataToServer(mye.ConnectionNumber, b2);

                        button_Ring.Invoke(new EventHandler(delegate
                        {
                            button_Ring.BackColor = Color.Orange;
                        }));
                    }
                }
            }
            else
            if (ParseStrings[1].Contains("ACK"))
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

                if (Key[0] == OpcodeToCompare)
                {
                    OpcodeToCompare = "";
                    ServerLogger.LogMessage(Color.Black, Color.Yellow, "Command Recieved OK!! ", true, true);
                    button_Ring.Invoke(new EventHandler(delegate
                    {
                        button_Ring.BackColor = Color.Green;
                        button_Ring.Text = "Ring Ok";
                    }));

                }
            }
            else
            if (Key[0] == "SMSSTAT?")
            {

                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }
            }
            else
                if (Key[0] == "FMS1" || Key[0] == "FMS2" || Key[0] == "FMS3")
            {

                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                    if (Key[0] == "MBL1")
            {


                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                        if (Key[0] == "MBL2")
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                    if (Key[0] == "OBD")
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                        if (Key[0] == "GRM") //Gil: Garmin message
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                            if (Key[0] == "DATA1") //Gil: Garmin message
            {


                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
            if (Key[0] == "GETCONFIG?")
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {
                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                if (Key[0] == "CONFIG")
            {

                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

                //SendToConfigPage(IncomingString, "Server");

            }
            else
                        if (Key[0] == "FOTAU")
            {


                int PacketNumber = int.Parse(ParseStrings[2]);
                //int NumOfTransmitPackets = int.Parse(FOTAStrings[3]);
                //if (NumOfTransmitPackets > 5 || NumOfTransmitPackets < 1)
                //{
                //    ServerLogger.LogMessage(Color.Red, Color.White, "Warning: Number Of Received Packets is no between 1-5", New_Line = true, Show_Time = true);
                //    return;
                //}

                //byte[] buffer = new byte[256];
                if (ConfigFileName != null)
                {
                    // m_BinaryReader = new BinaryReader(File.Open(ConfigFileName, FileMode.Open));
                    string TotalStrToSend = string.Empty;
                    //for (int i = 0; i < NumOfTransmitPackets ; i++)
                    //{
                    int FrameNumber = (PacketNumber);
                    if (FrameNumber == 999999)
                    {
                        //textBox_FOTAEnd.Invoke(new EventHandler(delegate
                        //{
                        IDToFOTA_Status[ParseStrings[0].Replace(";", "")] = "Finish";

                        PrintFotaIDStatus();
                        //textBox_FOTAEnd.BackColor = Color.Green;
                        //textBox_FOTAEnd.Text = "Finish";
                        //}));

                        string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                        //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                        byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                        SendDataToServer(mye.ConnectionNumber, b2);
                    }
                    else
                        if (FrameNumber < int.Parse(textBox_TotalFrames1280Bytes.Text))
                    {


                        //m_BinaryReader.BaseStream.Position = 0;
                        //int PositionInFile = 1280 * FrameNumber;
                        //m_BinaryReader.ReadBytes(PositionInFile);
                        //byte[] buffer = new byte[1280];
                        //for(int i=0;i < 1280 ; i++)
                        //{
                        //    buffer[i] = 0x30;
                        //}
                        //byte[] temp = m_BinaryReader.ReadBytes(1280);

                        //temp.CopyTo(buffer, 0);
                        ////m_BinaryReader.Read(buffer, PositionInFile, 256);
                        //// CS,@%@, @$@FOTAS,PACK NUM,256 bytes
                        //string str = Encoding.ASCII.GetString(buffer);
                        //byte b = CalcCheckSumbuffer(buffer);
                        string SendString = string.Format("{0},{1},@%@", FOTAData[FrameNumber], ParseStrings[ParseStrings.Length - 1].Replace(";", ""));

                        TotalStrToSend = SendString;


                        IDToFOTA_Status[ParseStrings[0].Replace(";", "")] = FrameNumber.ToString() + " / " + textBox_TotalFrames1280Bytes.Text;

                        PrintFotaIDStatus();
                        //textBox_MaximumNumberReceivedRequest.Invoke(new EventHandler(delegate
                        //{
                        //    textBox_MaximumNumberReceivedRequest.Text = "";

                        //    IDToFOTA_Status[ParseStrings[0]] = FrameNumber.ToString();

                        //    foreach (var pair in IDToFOTA_Status)
                        //    {

                        //        textBox_MaximumNumberReceivedRequest.AppendText(pair.Key + " | " + pair.Value + " \n");

                        //    }

                        //    //textBox_MaximumNumberReceivedRequest.Text += "," + FrameNumber.ToString();
                        //    //textBox_MaximumNumberReceivedRequest.SelectionStart = textBox_MaximumNumberReceivedRequest.TextLength;
                        //    //textBox_MaximumNumberReceivedRequest.ScrollToCaret();

                        //}));
                    }
                    //}

                    if (TotalStrToSend != string.Empty)
                    {
                        byte[] ByteArr = Encoding.ASCII.GetBytes(TotalStrToSend);
                        byte[] DataToSend = new byte[1500];
                        for (int i = 0; i < 1500; i++)
                        {
                            DataToSend[i] = 0;
                        }

                        ByteArr.CopyTo(DataToSend, 0);
                        //ServerLogger.LogMessage(Color.Black, Color.White, "Send Data Length : " + ByteArr.Length, New_Line = true, Show_Time = true);
                        SendDataToServer(mye.ConnectionNumber, DataToSend);
                    }

                    m_BinaryReader.Close();

                }
                else
                {
                    ServerLogger.LogMessage(Color.Red, Color.White, "Warning: FOTA file wasn't Chosen", New_Line = true, Show_Time = true);
                }

            }



        }

        void PrintFotaIDStatus()
        {
            textBox_MaximumNumberReceivedRequest.Invoke(new EventHandler(delegate
            {
                textBox_MaximumNumberReceivedRequest.Text = "";



                foreach (var pair in IDToFOTA_Status)
                {
                    PhoneBookContact ContactFound = MyPhoneBook.GetContactByUnitID(pair.Key);

                    if (ContactFound != null)
                    {
                        textBox_MaximumNumberReceivedRequest.AppendText(ContactFound.Name + "   " + pair.Value + " \n");
                    }
                    else
                    {
                        textBox_MaximumNumberReceivedRequest.AppendText(pair.Key + "   " + pair.Value + " \n");
                    }
                }

                //textBox_MaximumNumberReceivedRequest.Text += "," + FrameNumber.ToString();
                //textBox_MaximumNumberReceivedRequest.SelectionStart = textBox_MaximumNumberReceivedRequest.TextLength;
                //textBox_MaximumNumberReceivedRequest.ScrollToCaret();

            }));
        }

        //void SendToConfigPage(string i_ConfigString, string i_Source)
        //{
        //    bool SuccessParse = ParseConfigString(i_ConfigString);

        //    if (SuccessParse == true)
        //    {
        //        textBox_SourceConfig.Invoke(new EventHandler(delegate
        //        {
        //            textBox_SourceConfig.Text = "Configuration Loaded successfully from " + i_Source + "\nDate: " + DateTime.Now.ToString();
        //            textBox_SourceConfig.BackColor = Color.LightGreen;
        //        }));

        //    }
        //    else
        //    {
        //    }
        //}

        byte CalcCheckSumbufferSize(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < i_buffer.Length; i++)
            {
                ret += i_buffer[i];
            }
            return (byte)ret;
        }

        byte CalcCheckSumbuffer(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < 1280; i++)
            {
                ret += i_buffer[i];
            }
            return (byte)ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        void SendDataToServer(string i_Connection, byte[] i_Data)
        {
            bool Issent;

            Issent = WriteDataToServer(i_Connection, i_Data);

            ASCIIEncoding encoder = new ASCIIEncoding();

            string Str = encoder.GetString(i_Data);

            if (Issent == true)
            {
                ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                ServerLogger.LogMessage(Color.DarkViolet, Color.White, "Send Data: ", false, false);
                ServerLogger.LogMessage(Color.DarkViolet, Color.White, " Connection: " + i_Connection, false, false);
                ServerLogger.LogMessage(Color.DarkGreen, Color.White, "   " + Str, true, false);

            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void TxtDataTx_TextChanged(object sender, EventArgs e)
        {
            Monitor.Properties.Settings.Default.Default_Server_Message = txtDataTx.Text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                //List<string> S1frameArray = new List<string>();
                //S1frameArray.Add(S1_Protocol.S1_Messege_Builder.Get_Status());
                //SendS1Message(S1frameArray);


            }
            catch (SocketException ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
        }


        //private void button5_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        List<string> S1frameArray = new List<string>();
        //        S1frameArray.Add(S1_Protocol.S1_Messege_Builder.Arm_Disarm_Unit(comboBox_ArmDisArm.Text));
        //        SendS1Message(S1frameArray);


        //    }
        //    catch (SocketException ex)
        //    {
        //        ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
        //    }
        //}




        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="i_S1frameArray"></param>
        ///// <returns>return bool if sent or not</returns>
        //bool SendS1Message(List<string> i_S1frameArray)
        //{
        //    bool ret = false;

        //    return ret;
        //}

        private bool WriteDataToServer(string i_ConnectionNumber, byte[] i_Data)
        {
            if (m_Server != null && m_Server.IsConnectedToClient && m_Server.IsServerActive)
            {
                m_Server.WriteDataToServer(i_ConnectionNumber, i_Data);
                return true;
            }

            return false;
        }



        private void ComboBox_InputIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void Button23_Click(object sender, EventArgs e)
        {

        }


        private void Button24_Click(object sender, EventArgs e)
        {

        }

        private void Button_SMSControl_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void Button13_Click(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {

        }

        private void Button19_Click(object sender, EventArgs e)
        {

        }

        private void Button22_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }

        private void Button21_Click(object sender, EventArgs e)
        {

        }

        private void Button14_Click(object sender, EventArgs e)
        {

        }


        private void Button15_Click(object sender, EventArgs e)
        {

        }

        private void Button16_Click(object sender, EventArgs e)
        {

        }

        private void Button17_Click(object sender, EventArgs e)
        {

        }

        private void Button18_Click(object sender, EventArgs e)
        {

        }

        private void Button26_Click(object sender, EventArgs e)
        {

        }

        private void Button27_Click(object sender, EventArgs e)
        {

        }

        private void Button25_Click(object sender, EventArgs e)
        {

        }

        private void Button20_Click(object sender, EventArgs e)
        {

        }

        private void TxtS1_Clear_Click_1(object sender, EventArgs e)
        {
            try
            {
                SerialPortLogger_TextBox.Invoke(new EventHandler(delegate
                {

                    SerialPortLogger_TextBox.Text = "";

                }));
            }
            catch
            {
            }
        }

        private void Btn_GetPosition_Click(object sender, EventArgs e)
        {

        }

        private void Btn_ResetUnit_Click(object sender, EventArgs e)
        {

        }

        private void Button_GetTripInfo_Click(object sender, EventArgs e)
        {

        }



        private void Btn_GetSet1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_GetSet2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        void UpdateDefaultsContacts()
        {

        }

        void UpdateDefaultsCommands()
        {


        }

        void UpdateSMSCommands()
        {
            //string[] strArray = new string[Monitor.Properties.Settings.Default.SMS_Commands.Count];
            //Monitor.Properties.Settings.Default.PhoneBook.CopyTo(strArray, 0);




        }

        void UpdatePhoneBook()
        {


        }

        //void ClacPhoneBookTimeForPeriodOfSystem()
        //{
        //    System.Windows.Forms.Application.Exit();
        //}
        TextBox_Logger SystemLogger;
        TextBox_Logger ServerLogger;
        TextBox_Logger SerialPortLogger;
        //   Logger LogIWatcher;
        // TextBox_Logger LogSMS;
        PhoneBook MyPhoneBook;
        //    readonly List<Series> List_SeriesCharts = new List<Series>();
        //    readonly Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series
        //    {
        //        Name = "Raw Data",
        //        //    Color = System.Drawing.Color.Green,
        //        IsVisibleInLegend = true,
        //        IsXValueIndexed = false,
        //        ChartType = SeriesChartType.Line,
        //        MarkerStyle = MarkerStyle.Diamond

        //};
        //    readonly Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series
        //    {
        //        Name = "Moving Avarage 30",
        //        //    Color = System.Drawing.Color.Blue,
        //        IsVisibleInLegend = true,
        //        IsXValueIndexed = false,
        //        ChartType = SeriesChartType.Line
        //    };
        //    readonly Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series
        //    {
        //        Name = "0-100",
        //        //    Color = System.Drawing.Color.Blue,
        //        IsVisibleInLegend = true,
        //        IsXValueIndexed = false,
        //        ChartType = SeriesChartType.Line,
        //        MarkerStyle = MarkerStyle.Circle
        //    };

        Point? prevPosition = null;
        readonly ToolTip tooltip = new ToolTip();

        void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 3 &&
                            Math.Abs(pos.Y - pointYPixel) < 3)
                        {
                            //textBox_graph_XY.Text = "Chart=" + result.Series.Name + "\n, X=" + prop.XValue.ToString() + ", Y=" + prop.YValues[0].ToString();

                            tooltip.Show("X=" + prop.XValue.ToString("0.##E+0") + ", Y=" + prop.YValues[0], this.chart1,
                                            pos.X, pos.Y - 15, 9999999);
                        }
                    }
                }
            }
        }

        void Chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            //if (prevPosition.HasValue && pos == prevPosition.Value)
            //    return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 3 &&
                            Math.Abs(pos.Y - pointYPixel) < 3)
                        {
                            // chart1.Series[result.Series.Name].Points[(int)prop.XValue].Label = "X=" + prop.XValue + ", Y=" + prop.YValues[0].ToString("0.00");
                            prop.Label = "X=" + prop.XValue.ToString(".#E+0") + ", Y=" + prop.YValues[0].ToString("0.00");
                        }
                    }
                }
            }
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            ClientSocket.Close();

            if (this.ReceiveThread != null)
            {
                ReceiveThread.Abort();
                //   m_Exit = true;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_cmd"></param>
        /// <param name="i_InputArgs"></param>
        public void System1_parser_sum_CB(OneSystemCommand i_cmd, String[] i_InputArgs)
        {
            int sum = 0;
            if (i_InputArgs[0] == "?")
            {
                SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "Sum CB: " + i_cmd.Help, New_Line = true, Show_Time = true);
            }
            else
            {
                foreach (String str in i_InputArgs)
                {
                    sum += Int32.Parse(str);

                }

                SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "Sum CB: sum = " + sum, New_Line = true, Show_Time = true);
            }
        }

        class System1_parser : CLI_Parser
        {


            public override void Parse(object sender, String i_InputString)
            {
                String[] tempStr = i_InputString.Split(' ');

                String Opcode_name = tempStr[0];


                //Gil: remove the first Opcode
                int indexToRemove = 0;
                tempStr = tempStr.Where((source, index) => index != indexToRemove).ToArray();

                //Gil Check if Opcode exists;
                foreach (OneSystemCommand cmd in ALLCommandsList)
                {
                    if (Opcode_name == cmd.Opcode)
                    {

                        //cmd.Run_Operation(tempStr);
                        String MethodName = this.GetType().Name + "_" + Opcode_name + "_CB";

                        //Get the method information using the method info class
                        var method = sender.GetType().GetMethod(MethodName);
                        var parameters = new object[] { cmd, tempStr };


                        //Invoke the method
                        // (null- no parameter for the method call
                        // or you can pass the array of parameters...)
                        method.Invoke(sender, parameters);

                        //Type thisType = this.GetType();
                        //MethodInfo theMethod = thisType.GetMethod(MethodName);
                        //theMethod.Invoke(this, tempStr);
                    }
                }
            }
        }

        readonly System1_parser system1_Parser = new System1_parser();


        // List<S1_Protocol.S1_Messege_Builder.Command_Description> CommandsDescription;
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

                tabControl_Main.TabPages.RemoveAt(0);
                tabControl_Main.TabPages.RemoveAt(0);
                tabControl_Main.TabPages.RemoveAt(0);

                system1_Parser.AddCommand("sum", " sum all the elements \n Format: sum 1 2 3");
                //System1_parser.AddCommand("sum", "sum args", "sum all the numbers");
                //List_SeriesCharts.Add(series1);
                //List_SeriesCharts.Add(series2);
                //List_SeriesCharts.Add(series3);
                // this.TopMost = true;
                //// this.FormBorderStyle = FormBorderStyle.None;
                // this.WindowState = FormWindowState.Maximized;
                //foreach(Series ser in chart1.Series)
                //{
                //    listBox_Charts.Items.Add(ser.Name);
                //}
                // textBox_SendSerialPort.PreviewKeyDown += TextBox_SendSerialPort_PreviewKeyDown;
                // this.FormClosed += MainForm_FormClosed;
                // chart1.Series.Clear();
                // chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                // chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                //chart1.Series.Add(series1);
                //chart1.Series.Add(series2);
                //chart1.Series.Add(series3);
                //chart1.Series[0].BorderWidth = 2;
                //chart1.Series[1].BorderWidth = 2;

                //chart1.Series[0].IsValueShownAsLabel = true;
                //chart1.Series[1].IsValueShownAsLabel = false;
                //chart1.Series[1].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                //chart1.Series[0].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                //chart1.Series[1].SmartLabelStyle.Enabled = true;

                //chart1.ChartAreas[0].AxisX.IsLogarithmic = true;
                //comboBox_WindowsDSPLib.DataSource = Enum.GetNames(typeof(DSPLib.DSP.Window.Type));
                // chart1.MouseMove += Chart1_MouseMove;
                //chart1.MouseClick += Chart1_MouseClick;
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "0.###E+0";
                // tabControl_Main.DrawItem += TabControl1_DrawItem1;
                //  textBox_SendSerialPort.KeyDown += TextBox_SendSerialPort_KeyDown;

                //tabControl1.TabPages.RemoveAt(2);
                //      UpdatePhoneBook();
                //   UpdateSMSCommands();


                txtPortNo.Text = Monitor.Properties.Settings.Default.Start_Port;
                txtDataTx.Text = Monitor.Properties.Settings.Default.Default_Server_Message;
                //  richTextBox_RegisterCommands.Text = Monitor.Properties.Settings.Default.RegisterCommands;


                //pictureBox_logo.BringToFront();

                //Gil: Generate all the loggers
                ServerLogger = new TextBox_Logger("Server", TextBox_Server, button_ClearServer, checkBox_ServerPause, checkBox_ServerRecord, null, null, null, checkBox_StopLogging);
                SerialPortLogger = new TextBox_Logger("Serial_Port", SerialPortLogger_TextBox, txtS1_Clear, checkBox_S1Pause, checkBox_S1RecordLog, textBox_SerialPortRecognizePattern, textBox_SerialPortRecognizePattern2, textBox_SerialPortRecognizePattern3, null);
                SystemLogger = new TextBox_Logger("SystemLogger", richTextBox_SSPA, button_ClearMiniAda, checkBox_PauseMiniAda, checkBox_RecordMiniAda, null, null, null, checkBox_StopLogging);


                // LogSMS = new TextBox_Logger("Log_SMS", richTextBox_SMSConsole, button_ClearSMSConsole, checkBox_PauseSMSConsole, checkBox_RecordSMSConsole, null, null, null, null);

                //Gil: Active All the recorders
                //  checkBox_RecordGeneral.Checked = !checkBox_RecordGeneral.Checked;
                // checkBox_S1RecordLog.Checked = !checkBox_S1RecordLog.Checked;
                //checkBox_RecordLatLong.Checked = !checkBox_RecordLatLong.Checked;

                //        checkBox_RecordTrace.Checked = !checkBox_RecordTrace.Checked;

                //Gil: Initialize the serial ports
                //serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);

                ScanComports();
                cmb_StopBits.DataSource = Enum.GetValues(typeof(StopBits));
                cmb_StopBits.SelectedIndex = (int)StopBits.One;

                cmbParity.DataSource = Enum.GetValues(typeof(Parity));
                cmbParity.SelectedIndex = (int)Parity.None;

                //cmbDataBits.DataSource = Enum.GetValues(typeof(Data));

                cmbBaudRate.Text = Monitor.Properties.Settings.Default.Comport_BaudRate;
                cmbDataBits.Text = Monitor.Properties.Settings.Default.Comport_DataBits;
                cmb_StopBits.Text = Monitor.Properties.Settings.Default.Comport_StopBit;
                cmbParity.Text = Monitor.Properties.Settings.Default.Comport_Parity;
                cmb_PortName.Text = Monitor.Properties.Settings.Default.Comport_Port;







                //cmbBaudRate.Text = Monitor.Properties.Settings.Default.Comport_BaudRate;
                //cmbDataBits.Text = Monitor.Properties.Settings.Default.Comport_DataBits;
                //cmbStopBits.Text = Monitor.Properties.Settings.Default.Comport_StopBit;
                //cmbParity.Text = Monitor.Properties.Settings.Default.Comport_Parity;
                //cmbPortName.Text = Monitor.Properties.Settings.Default.Comport_Port;


                //Gil: Set Versions Names
                string path = Directory.GetCurrentDirectory();
                string lastFolderName = Path.GetFileName(path);
                //string[] dir = Directory.GetCurrentDirectory().Split('\\');
                string version = lastFolderName;
                //if (ApplicationDeployment.IsNetworkDeployed)
                //{
                //    version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                //}
                //else
                //{
                //    version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //}

                this.Text = this.Text + " [ " + ", Version: " + version + ", Compiled: " + RetrieveLinkerTimestamp().ToString() + " ]";







                foreach (TextBox txtbx in List_ConfigurationTextBoxes)
                {
                    txtbx.GotFocus += Txtbx_GotFocus;
                }


                UpdateSerialPortComboBox();

                //ShowHidePages();





                TimeSpan TimeFromLastRunTime = DateTime.Now - Monitor.Properties.Settings.Default.LastRunTime;
                //      TimeSpan TimeFromCompilation = DateTime.Now - RetrieveLinkerTimestamp();
                TimeSpan TimeForRunPhoneBookAtTime = DateTime.Now - RetrieveLinkerTimestamp();
                Monitor.Properties.Settings.Default.LastRunTime = DateTime.Now;
                Monitor.Properties.Settings.Default.Save();

                ///////////////////////////////// Leonid: Compilation time span (Remember this!!!!!!!!)
                if (TimeForRunPhoneBookAtTime.Days > 90)
                {
                    //   ClacPhoneBookTimeForPeriodOfSystem();

                }
                ///////////////////////////////
                //if (TimeFromLastSave.Days > 3)
                //{
                //    SaveCommandsAndContacts();


                //}


                EditDataGridForSSPAWB();



                SerialPortLogger.LogMessage(Color.Yellow, Color.LightGray, "Press F1 for help", New_Line = true, Show_Time = true);

                foreach (Control allContrls in this.Controls)
                {
                    FindControls(allContrls);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //  ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }

        }

        void EditDataGridForSSPAWB()
        {
            int i = 0;

            this.dataGridView_DC4.TopLeftHeaderCell.Value = "Temperature (C)";
            this.dataGridView8.TopLeftHeaderCell.Value = "Temperature (C)";
            this.dataGridView_PAVVA.TopLeftHeaderCell.Value = "Power (dBm)";

            this.dataGridView_VVAOffset2.TopLeftHeaderCell.Value = "Power (dBm)";
            this.dataGridView_VVAOffset1.TopLeftHeaderCell.Value = "Power (dBm)";
            this.dataGridView_OverUnder.TopLeftHeaderCell.Value = "Volts (V)";
            this.dataGridView_Page1_4.TopLeftHeaderCell.Value = "VVA";





            int RowText = -31;
            int Temperature = -31;

            //this.dataGridView_Page1_4.RowTemplate.Height = 20;
            ////this.dataGridView_Page1_4.RowsDefaultCellStyle.Font = new Font("Calibri", 8);
            //this.dataGridView_DC4.RowTemplate.Height = 20;
            //this.dataGridView8.RowTemplate.Height = 20;

            for (i = 0; i < 32; i++)
            {

                this.dataGridView_Page1_4.Rows.Add();
                this.dataGridView_Page1_4.Rows[i].HeaderCell.Value = String.Format("{0}C", Temperature);


                this.dataGridView8.Rows.Add();
                this.dataGridView8.Rows[i].HeaderCell.Value = String.Format("{0}..{1}C", RowText, RowText + 3);

                this.dataGridView_DC4.Rows.Add();
                this.dataGridView_DC4.Rows[i].HeaderCell.Value = String.Format("{0}..{1}C", RowText, RowText + 3);
                RowText += 3;
                Temperature += 4;
            }

            RowText = -3;
            for (i = 0; i < 21; i++)
            {
                this.dataGridView_PAVVA.Rows.Add();
                this.dataGridView_PAVVA.Rows[i].HeaderCell.Value = String.Format("{0} dBm", RowText);
                RowText--;
            }

            this.dataGridView_PAVVA.Rows[0].HeaderCell.Value += " <";
            this.dataGridView_PAVVA.Rows[20].HeaderCell.Value += " >";


            double RowText2 = 46;
            for (i = 0; i < 9; i++)
            {

                this.dataGridView_VVAOffset1.Rows.Add();
                this.dataGridView_VVAOffset1.Rows[i].HeaderCell.Value = String.Format("{0} dBm", RowText);

                this.dataGridView_VVAOffset2.Rows.Add();
                this.dataGridView_VVAOffset2.Rows[i].HeaderCell.Value = String.Format("{0} dBm", RowText);

                RowText2 -= 0.2;
            }
            this.dataGridView_VVAOffset2.Rows[8].HeaderCell.Value += "<";
            this.dataGridView_VVAOffset2.Rows.Add();
            this.dataGridView_VVAOffset2.Rows[9].HeaderCell.Value = "40- DC4";

            this.dataGridView_VVAOffset1.Rows[8].HeaderCell.Value += "<";
            this.dataGridView_VVAOffset1.Rows.Add();
            this.dataGridView_VVAOffset1.Rows[9].HeaderCell.Value = "40- DC4";

            i = 0;
            dataGridView_OverUnder.Rows.Add();
            dataGridView_OverUnder.Rows[i].HeaderCell.Value = "28V";
            i++;

            dataGridView_OverUnder.Rows.Add();
            dataGridView_OverUnder.Rows[i].HeaderCell.Value = "-5V";
            i++;
            dataGridView_OverUnder.Rows.Add();
            dataGridView_OverUnder.Rows[i].HeaderCell.Value = "3.3V";
            i++;
            dataGridView_OverUnder.Rows.Add();
            dataGridView_OverUnder.Rows[i].HeaderCell.Value = "4V";
            i++;
            dataGridView_OverUnder.Rows.Add();
            dataGridView_OverUnder.Rows[i].HeaderCell.Value = "5V";
            i++;
            dataGridView_OverUnder.Rows.Add();
            dataGridView_OverUnder.Rows[i].HeaderCell.Value = "8V";
            i++;
            dataGridView_OverUnder.Rows.Add();
            dataGridView_OverUnder.Rows[i].HeaderCell.Value = "48V";
            i++;
            dataGridView_OverUnder.Rows.Add();
            dataGridView_OverUnder.Rows[i].HeaderCell.Value = "48V current";
            i++;


            i = 0;

            dataGridView_ValPage0.Rows.Add();
            dataGridView_ValPage0.Rows[i].HeaderCell.Value = "FW clamping (uS)";
            i++;

            dataGridView_ValPage0.Rows.Add();
            dataGridView_ValPage0.Rows[i].HeaderCell.Value = "Pulse over DC clamping";
            i++;

            dataGridView_ValPage0.Rows.Add();
            dataGridView_ValPage0.Rows[i].HeaderCell.Value = "TGA2700 Vgg";
            i++;

            dataGridView_ValPage0.Rows.Add();
            dataGridView_ValPage0.Rows[i].HeaderCell.Value = "TGA2700 Vdd";
            i++;

            dataGridView_ValPage0.Rows.Add();
            dataGridView_ValPage0.Rows[i].HeaderCell.Value = "TGA2700 DC4 Vdd";
            i++;



        }

        private void FindControls(Control ctl)
        {

            if (ctl.GetType().FullName == "System.Windows.Forms.TextBox")
            {
                TextBox txt = (TextBox)ctl;
                String temp = txt.Text;
                txt.Text = " ";
                txt.Text = temp;
            }

            if (ctl.GetType().FullName == "System.Windows.Forms.RichTextBox")
            {
                RichTextBox txt = (RichTextBox)ctl;

                txt.Invoke(new EventHandler(delegate
                 {

                     String temp = txt.Text;
                     txt.Text = "";
                     txt.AppendText(temp);
                 }));

            }

            if (ctl.GetType().FullName == "System.Windows.Forms.CheckBox")
            {
                CheckBox chk = (CheckBox)ctl;
            }

            foreach (Control ctrl in ctl.Controls)
            {
                FindControls(ctrl);
            }

        }



        private void Txtbx_GotFocus(object sender, EventArgs e)
        {
            //  TextBox txtbx = (TextBox)sender;
            // textBox_ConfigurationHelp.Text = "";
            //textBox_ConfigurationHelp.Text = txtbx.Name + "\n" + toolTip1.GetToolTip(txtbx);

        }

        private void TextBox_SerialPortRecognizePattern3_GotFocus(object sender, EventArgs e)
        {
            SerialPortLogger.LogMessage(Color.Black, Color.Yellow, "Got focus", New_Line = true, Show_Time = true);
        }

        private void TextBox_SendSerialPort_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                // MessageBox.Show("Tab");
                e.IsInputKey = true;
            }
            if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                //  MessageBox.Show("Shift + Tab");
                e.IsInputKey = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseClentConnection();
        }

        //Color Tab0Color;
        //Color Tab1Color;
        //Color Tab2Color;
        //Color Tab3Color;
        private void TabControl1_DrawItem1(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl_Main.TabPages[e.Index];
            Color TabColor;
            if (e.Index == tabControl_Main.SelectedIndex)
            {
                TabColor = Color.Aqua;
            }
            else
            {
                TabColor = default;
            }

            //switch (e.Index)
            //{
            //    case 0:
            //        e.Graphics.FillRectangle(new SolidBrush(Tab0Color), e.Bounds);
            //        break;
            //    case 1:
            //        e.Graphics.FillRectangle(new SolidBrush(Tab1Color), e.Bounds);
            //        break;
            //    default:
            //        break;
            //}

            e.Graphics.FillRectangle(new SolidBrush(TabColor), e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, page.ForeColor);
        }

        private void TextBox_SendNumberOfTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_SendSerialDiff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void SaveCommandsAndContacts()
        {
            string subPath = Directory.GetCurrentDirectory() + "\\SMS_Backup\\";
            string m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_Contacts" + ".xml";
            string filesName = m_log_file_name;

            bool isExists = System.IO.Directory.Exists(subPath);

            if (!isExists)
            {
                System.IO.Directory.CreateDirectory(subPath);
            }

            using (Stream myStream = File.Create(subPath + m_log_file_name))
            {
                MyPhoneBook.ExportToXML(myStream);
                // Code to write the stream goes here.
                myStream.Close();
            }

            m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "____________Commands" + ".xml";
            filesName += "\n" + m_log_file_name;
            using (Stream myStream = File.Create(subPath + m_log_file_name))
            {
                List<string> templist = new List<string>();
                foreach (var item in listBox_SMSCommands.Items)
                {
                    templist.Add((string)item);
                }
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                TextWriter textWriter = new StreamWriter(myStream);

                serializer.Serialize(textWriter, templist);
                textWriter.Close();
                // Code to write the stream goes here.
                myStream.Close();
            }


            Monitor.Properties.Settings.Default.Save();

            // LogSMS.LogMessage(Color.Brown, Color.White, " 2 Backup files of contacts and commands Created at \n" + subPath + "\n" + filesName, New_Line = true, Show_Time = true);


        }

        //void ShowHidePages()
        //{
        //    if (Monitor.Properties.Settings.Default.RemovePages != null)
        //    {
        //        int i = 0;
        //        foreach (string str in Monitor.Properties.Settings.Default.RemovePages)
        //        {
        //            try
        //            {
        //                // comboBox_SerialPortHistory.Items.Add((object)str);
        //                // comboBox_SMSCommands.Items.Add(str);
        //                Int32 indexToRemove = Int32.Parse(str);

        //                tabControl1.TabPages.RemoveAt(indexToRemove - i);
        //                i++;
        //            }
        //            catch
        //            {
        //                break;
        //            }

        //        }
        //    }
        //}

        // Dictionary<string, TextBox> Dictionary_ConfigurationTextBoxes;
        readonly List<TextBox> List_ConfigurationTextBoxes = new List<TextBox>();


        //static public List<string> GetAllCommands()
        //{
        //    Type type = typeof(S1_Protocol.S1_Messege_Builder);
        //    MethodInfo[] info = type.GetMethods();
        //    List<string> ret = new List<string>();

        //    Type type_Object = typeof(Object);
        //    MethodInfo[] info_Object = type_Object.GetMethods();
        //    foreach (MethodInfo inf in info)
        //    {
        //        bool Add = true;
        //        foreach (MethodInfo inf_Obj in info_Object)
        //        {
        //            if (inf_Obj.Name == inf.Name)
        //            {
        //                Add = false;
        //            }
        //        }
        //        if (Add)
        //        {
        //            ret.Add(inf.Name);
        //        }

        //    }
        //    return ret;

        //}

        //void toolStripMenuItem_CopyToSingle_Click(object sender, EventArgs e)
        //{
        //    textBox_AddSendSingleCommand.Text = richTextBox_GetConfig.SelectedText;
        //}




        private void Txtbox_Password_TextChanged(object sender, EventArgs e)
        {
            //if (txtbox_Password.Text.Length < 4)
            //{
            //    txtbox_Password.BackColor = Color.OrangeRed;
            //}
            //else
            //{
            //    txtbox_Password.BackColor = Color.White;
            //}
        }


        string ConfigFileName;
        private void Button28_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                //TextBox_File_Name.Text = openFileDialog1.FileName;



            }


        }


        int NumOfRemainCommands = 0;
        private void BackgroundWorker_ConfigSystem_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            NumOfRemainCommands = 0;
            //ConfigProcessExit = false;

            // Gil Calculate the percentage
            //int percent = CalculateProgressDonePercentage();
            worker.ReportProgress(0);

            while (CalculateProgressDonePercentage() < 100)
            {





            }

            //Config_Sys.Invoke(new EventHandler(delegate
            //        {
            //            Config_Sys.Enabled = true;
            //        }));
            //worker.ReportProgress(CalculateProgressDonePercentage());
        }









        private int CalculateProgressDonePercentage()
        {
            float ret = ((float)NumOfRemainCommands / (float)CommandsToSend.Count) * 100;
            return (int)ret;
        }






        //Color originColor_LatLong;
        //string log_file_S1_LatLong;
        //  readonly List<string> KMl_text = new List<string>();
        //       int KML_Index = 0;
        //   int DrivingNumber = 0;
        private void CheckBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            //if (checkBox_RecordLatLong.Checked)
            //{
            //    KMl_text.Clear();
            //    DrivingNumber++;
            //    originColor_LatLong = checkBox_RecordLatLong.BackColor;
            //    checkBox_RecordLatLong.BackColor = Color.Yellow;

            //    log_file_S1_LatLong = "Log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_LatLong_Record_DRVNUM_" + DrivingNumber + ".kml";
            //    try
            //    {

            //        while (File.Exists(log_file_S1_LatLong))
            //        {
            //            log_file_S1_LatLong = "Log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_LatLong_Record" + ".kml";
            //        }


            //        NumOfPositionMessage = 0;
            //        KMl_text.Add("<?xml version=\"1.0\" encoding=\"UTF-8\"?>"); 
            //        KMl_text.Add("<kml xmlns=\"http://www.google.com/earth/kml/2\">");
            //        KMl_text.Add("<Document>");




            //        SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "File " + log_file_S1_LatLong + " opened in directory \" " + Directory.GetCurrentDirectory() + "\" \n\n", true, true);
            //        //}


            //    }
            //    catch (Exception)
            //    {
            //        SerialPortLogger.LogMessage(Color.Orange, Color.LightGray, "Can't Open File", true, true);
            //    }

            //}
            //else
            //{
            //    checkBox_RecordLatLong.BackColor = default(Color);

            //    SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "File " + log_file_S1_LatLong + " closed \n\n", true, true);
            //}
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        readonly List<List<string>> CommandsToSend = new List<List<string>>();












        private void Button29_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox_GeneralMessage_TextChanged(object sender, EventArgs e)
        {

        }
        Double ChartCntX = 0, ChartCntY = 0;
        Double ChartCntY2 = 0;
        Double ChartCntY3 = 0;
        bool OppositeCount = false, SerialRxBlinklled = false, SerialTxBlinklled = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string PrintTimeSpan(TimeSpan t)
        {
            string answer;
            if (t.TotalMinutes < 1.0)
            {
                answer = String.Format("{0}.{1:D2}s", t.Seconds, t.Milliseconds / 10);
            }
            else if (t.TotalHours < 1.0)
            {
                //answer = String.Format("{0}m:{1:D2}.{2:D2}s", t.Minutes, t.Seconds, t.Milliseconds % 100);
                answer = String.Format("{0}m:{1:D2}", t.Minutes, t.Seconds);
            }
            else // more than 1 hour
            {
                answer = String.Format("{0}h:{1:D2}m:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
            }

            return answer;
        }


        static int GetDataIntervalCounter;
        bool IsTimedOutTimerEnabled = false;
        /// <summary>
        /// 
        /// </summary>
        int Timer_100ms = 0;

        void ClientTCpipProcessing()
        {
            try
            {
                if (ClientSocket == null || ClientSocket.Client == null)
                {
                    button_ClientConnect.BackColor = default;
                }
                else

                    if (ClientSocket.Connected && ClientSocket.Client.Connected && ClientSocket.GetStream() != null)
                {
                    button_ClientConnect.BackColor = Color.LightGreen;
                }
                else
                {
                    button_ClientConnect.BackColor = default;
                }




            }
            catch
            {
                button_ClientConnect.BackColor = default;
            }

        }

        private int TimeOutKeepAlivein100ms = 3000000;
        private int RxLabelTimerBlink = 0, TxLabelTimerBlink = 0;
        private void Timer_ConectionKeepAlive_Tick(object sender, EventArgs e)
        {
            Timer_100ms++;

            ClientTCpipProcessing();

            if (stopwatch.IsRunning == true)
            {
                textBox_StopWatch.Text = PrintTimeSpan(stopwatch.Elapsed);
            }

            // Gil: In case Time Out Expiered close all the threads and connections
            if (IsTimedOutTimerEnabled == true)
            {
                GetDataIntervalCounter++;
                if (GetDataIntervalCounter >= TimeOutKeepAlivein100ms)
                {
                    //IsTimedOutTimerEnabled = false;
                    GetDataIntervalCounter = 0;
                    ServerLogger.LogMessage(Color.Orange, Color.White, "Connection Time Out ", New_Line = true, Show_Time = true);
                    ListenBox.Checked = !ListenBox.Checked;
                    ListenBox.Checked = !ListenBox.Checked;
                }
            }




            if (m_Server != null)
            {
                try
                {
                    if (m_Server.IsServerActive)
                    {
                        textBox_ServerActive.BackColor = Color.Green;
                    }
                    else
                    {
                        textBox_ServerActive.BackColor = default;
                    }


                    if (m_Server.IsConnectedToClient)
                    {
                        IsTimedOutTimerEnabled = true;
                        textBox_ServerOpen.BackColor = Color.Green;
                        //ListenBox.BackColor = Color.Green;
                    }
                    else
                    {
                        IsTimedOutTimerEnabled = false;
                        textBox_ServerOpen.BackColor = default;
                        // ListenBox.BackColor = Color.Yellow;
                    }


                    textBox_NumberOfOpenConnections.Text = m_Server.NumberOfOpenConnections.ToString();

                }
                catch (Exception ex)
                {
                    ServerLogger.LogMessage(Color.Red, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
                }
            }



            if (IsPauseGraphs == false)
            {

                if (Timer_100ms % (ChartUpdateTime / 100) == 0)
                {
                    //GraphPrint();
                }
            }

            if (RxLabelTimerBlink > 0)
            {
                RxLabelTimerBlink--;
                if (Timer_100ms % 2 == 0)
                {
                    SerialRxBlinklled = !SerialRxBlinklled;
                    if (SerialRxBlinklled == true)
                    {
                        Label_SerialPortRx.BackColor = Color.Green;
                    }
                    else
                    {
                        Label_SerialPortRx.BackColor = default;
                    }
                }
            }
            else
            if (RxLabelTimerBlink == 0)
            {
                Label_SerialPortRx.BackColor = default;
            }

            if (TxLabelTimerBlink > 0)
            {
                TxLabelTimerBlink--;
                if (Timer_100ms % 2 == 0)
                {
                    SerialTxBlinklled = !SerialTxBlinklled;
                    if (SerialTxBlinklled == true)
                    {
                        Label_SerialPortTx.BackColor = Color.Green;
                    }
                    else
                    {
                        Label_SerialPortTx.BackColor = default;
                    }
                }
            }
            else
            if (TxLabelTimerBlink == 0)
            {
                Label_SerialPortTx.BackColor = default;
            }







        }

        readonly List<double> ChartMem = new List<double>();
        readonly List<double> ChartMem2 = new List<double>();
        readonly Random rand = new Random();
        int GreenCnt = 0, RedCnt = 0;
        private const int MOVING_AVARAGE_SIZE = 30;
        void GraphPrint()
        {
            try
            {



                if (OppositeCount == true)
                {
                    ChartCntY3++;
                    ChartCntY3 *= 1.1;
                    if (ChartCntY3 >= 100)
                    {
                        OppositeCount = false;
                    }
                }
                else
                {
                    ChartCntY3--;
                    ChartCntY3 *= 0.9;
                    if (ChartCntY3 <= 0)
                    {
                        OppositeCount = true;
                    }
                }

                ChartCntY2 = 0;
                int cnt = 0;
                for (int i = chart1.Series[0].Points.Count - 1; i >= (chart1.Series[0].Points.Count - MOVING_AVARAGE_SIZE) && i >= 0; i--)
                {
                    cnt++;
                    ChartCntY2 += (int)chart1.Series[0].Points[i].YValues[0];
                }
                ChartCntY2 /= cnt;

                if (IsPauseGraphs == false)
                {
                    chart1.Series[0].Points.AddXY(ChartCntX, ChartCntY);
                    chart1.Series[0].Name = $"Data 1 [{ChartCntY}]";

                    chart1.Series[1].Points.AddXY(ChartCntX, ChartCntY2);
                    chart1.Series[1].Name = $"Data 2 [{ChartCntY2}]";

                    chart1.Series[2].Points.AddXY(ChartCntX, ChartCntY3);
                    chart1.Series[2].Name = $"Data 3 [{ChartCntY3}]";
                }
                else
                {
                    ChartMem.Add(ChartCntY);
                    ChartMem2.Add(ChartCntY2);
                }

                ChartCntX++;
                double temp = rand.Next(-1, 2);
                temp *= rand.NextDouble();
                ChartCntY += temp;

                if (ChartCntY > ChartCntY2)
                {
                    chart1.BackColor = Color.LightGreen;
                    GreenCnt++;
                }
                else
                {
                    chart1.BackColor = Color.Red;
                    RedCnt++;
                }
                if (Timer_100ms % 50 == 0)
                {
                    textBox_graph_XY.Text = "Green = " + GreenCnt + "  Red = " + RedCnt;
                }
                //  ChartCntY2 = ChartCntY2 + rnd.Next(-1, 2);

                if (ChartCntX % 1000 == 0)
                {
                    chart1.ChartAreas[0].AxisX.Minimum = ChartCntX;
                }


                chart1.Refresh();
                chart1.Invalidate();
            }
            catch (Exception ex)
            {
                textBox_graph_XY.Text = ex.Message;
                textBox_graph_XY.BackColor = Color.Red;
            }

        }

        //static float NextFloat(Random random)
        //{
        //    double mantissa = (random.NextDouble() * 2.0) - 1.0;
        //    // choose -149 instead of -126 to also generate subnormal floats (*)
        //    double exponent = Math.Pow(2.0, random.Next(-126, 128));
        //    return (float)(mantissa * exponent);
        //}

        private void TakeCroppedScreenShot()
        {
            string FileLocation = @".\MyPanelImage.bmp";
            Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
            chart1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(FileLocation);

            var filePath = FileLocation;
            ProcessStartInfo Info = new ProcessStartInfo()
            {
                FileName = "mspaint.exe",
                WindowStyle = ProcessWindowStyle.Maximized,
                Arguments = filePath
            };
            Process.Start(Info);
        }


        private void TabPage6_Click(object sender, EventArgs e)
        {

        }

        private void Button_Set2_Click(object sender, EventArgs e)
        {

        }

        private void Button_GenerateConfigFile_Click(object sender, EventArgs e)
        {

        }

        private void Button_Set1_Click(object sender, EventArgs e)
        {



        }


        int FindZeroPaddingSize(int i_SignalLength)
        {
            UInt32 mLogN = 0;
            bool found = false;
            double FFTBufferSize = i_SignalLength;

            while (found != true)
            {

                mLogN++;
                FFTBufferSize = Math.Pow(2.0, mLogN);
                if (FFTBufferSize > i_SignalLength)
                {
                    found = true;
                }
            }

            return (int)FFTBufferSize - i_SignalLength;
        }

        int WaitforBufferFull = -1;
        //DSPLib.DSP.Window.Type windowToApply;
        void CheckForMiniAdaDataFFT(SSPA_Parser i_MiniAdaParser)
        {



            //  double samplingRate = Convert.ToDouble(TextBoxFsSamplingRate.Text); ;
            //UInt32 zeroPadding = 9000;
            double scale = 2 ^ 11 - 1;


            double[] IQ1Sigal = new double[i_MiniAdaParser.IQData.I1.Length];
            double[] IQ2Sigal = new double[i_MiniAdaParser.IQData.I2.Length];

            for (int i = 0; i < i_MiniAdaParser.IQData.I1.Length; i++)
            {
                IQ1Sigal[i] = (double)(i_MiniAdaParser.IQData.I1[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q1[i] / scale / 2);
            }


            for (int i = 0; i < i_MiniAdaParser.IQData.I2.Length; i++)
            {
                IQ2Sigal[i] = (double)(i_MiniAdaParser.IQData.I2[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q2[i] / scale / 2);
            }

            int zeroPadding = FindZeroPaddingSize(IQ1Sigal.Length);
            int zeroPadding2 = FindZeroPaddingSize(IQ2Sigal.Length);



 

            // Instantiate & Initialize a new DFT
            DSPLib.FFT fft = new DSPLib.FFT();
            DSPLib.FFT fft2 = new DSPLib.FFT();
            //DSPLib.DFT dft = new DSPLib.DFT();
            fft.Initialize((uint)IQ1Sigal.Length, (uint)zeroPadding); // NOTE: Zero Padding
            fft2.Initialize((uint)IQ2Sigal.Length, (uint)zeroPadding2);

            // Call the DFT and get the scaled spectrum back

            // Convert the complex spectrum to note: Magnitude Format


            //double[] lmSpectrum = DSP.ConvertMagnitude.ToMagnitudeDBV(temp);
            // double[] lmSpectrum2 = DSP.ConvertMagnitude.ToMagnitudeDBV(temp2);
            // Properly scale the spectrum for the added window




            // For plotting on an XY Scatter plot generate the X Axis frequency Span
            //   double[] freqSpan = fft.FrequencySpan(samplingRate);
            //  double[] freqSpan2 = fft2.FrequencySpan(samplingRate);
            // At this point a XY Scatter plot can be generated from,
            // X axis => freqSpan
            // Y axis => lmSpectrum
            //double Mean = DSP.Analyze.FindMean(IQ1Sigal);
            //double Mean2 = DSP.Analyze.FindMean(IQ2Sigal);

            //double RMS = DSP.Analyze.FindRms(IQ1Sigal);
            //double RMS2 = DSP.Analyze.FindRms(IQ2Sigal);

            //double MaxAmplitude = DSP.Analyze.FindMaxAmplitude(lmSpectrum);
            //double MaxPosition = DSP.Analyze.FindMaxPosition(lmSpectrum);
            //double MaxFrequency = DSP.Analyze.FindMaxFrequency(lmSpectrum, freqSpan);

            //textBox_graph_XY.BeginInvoke(new EventHandler(delegate
            //{
            //    textBox_graph_XY.Text = String.Format(" \n CH1 : Mean [{0}] RMS [{1}] \n", Mean.ToString("0.00"),RMS.ToString("0.00"));
            //    textBox_graph_XY.Text += String.Format(" \n CH2 : Mean [{0}] RMS [{1}]  \n ", Mean2.ToString("0.00"), RMS2.ToString("0.00"));
            //    textBox_graph_XY.Text += String.Format(" \n CH1 : MaxAmplitude [{0}] MaxPosition [{1}] MaxFrequency [{2}] \n ", MaxAmplitude.ToString("0.00"), MaxPosition.ToString("0.00"), MaxFrequency.ToString("0.00"));

            //}));

            listBox_Charts.BeginInvoke(new EventHandler(delegate
            {
                var series1 = new Series("CH1 " + ChartIndex.ToString());
                //var series2 = new Series("IQ1 Time " + ChartIndex.ToString());
                var series3 = new Series("CH2 " + ChartIndex.ToString());
                //  var series4 = new Series("IQ2 Time " + ChartIndex.ToString());

                series1.ChartType = SeriesChartType.Line;
                series3.ChartType = SeriesChartType.Line;

                ChartIndex++;

                //  listBox_Charts.Items.Add(series4.Name);
                // Frist parameter is X-Axis and Second is Collection of Y- Axis
                // double[] xData = DSP.Generate.LinSpace(-(freqSpan.Length) / 2 , (freqSpan.Length) / 2, (UInt32)(freqSpan.Length));
                //       series1.Points.DataBindXY(freqSpan, lmSpectrum);
                for (int i = 0; i < IQ1Sigal.Length; i++)
                {
                    //         series2.Points.AddXY(i, IQ1Sigal[i]);
                }
                //     series2.ChartType = SeriesChartType.Line;
                chart1.Series.Add(series1);
                //     chart1.Series.Add(series2);

                //  series3.Points.DataBindXY(freqSpan, lmSpectrum2);

                for (int i = 0; i < IQ1Sigal.Length; i++)
                {
                    //         series4.Points.AddXY(i, IQ1Sigal[i]);
                }
                //      series4.ChartType = SeriesChartType.Line;
                chart1.Series.Add(series3);
                //   chart1.Series.Add(series4);

                PlotGraphTimer = -1;
                textBox_SystemStatus.Text = "Graphs is ready;\n";
                textBox_SystemStatus.BackColor = Color.LightGreen;

                //Gil: Find the maximum and minimum points
                //      MarkTheBiggestFreq(series1, lmSpectrum, freqSpan);
                //      MarkTheBiggestFreq(series3, lmSpectrum2, freqSpan2);


            }));


        }

        void MarkTheBiggestFreq(Series i_serias, double[] i_lmSpectrum, double[] i_freqSpan)
        {
            double minX = i_serias.Points.Select(v => v.XValue).Min();
            double maxX = i_serias.Points.Select(v => v.XValue).Max();
            double minY = i_serias.Points.Select(v => v.YValues[0]).Min();
            double maxY = i_serias.Points.Select(v => v.YValues[0]).Max();

            // find datapoints from left..
            DataPoint minXpt = i_serias.Points.Select(p => p)
                                .Where(p => p.XValue == minX)
                                .DefaultIfEmpty(i_serias.Points.First()).First();
            DataPoint minYpt = i_serias.Points.Select(p => p)
                                .Where(p => p.YValues[0] == minY)
                                .DefaultIfEmpty(i_serias.Points.First()).First();
            //..or from right
            DataPoint maxXpt = i_serias.Points.Select(p => p)
                                .Where(p => p.XValue == maxX)
                                .DefaultIfEmpty(i_serias.Points.Last()).Last();
            DataPoint maxYpt = i_serias.Points.Select(p => p)
                                .Where(p => p.YValues[0] == maxY)
                                .DefaultIfEmpty(i_serias.Points.Last()).Last();

            textBox_MaxXAxis.Text = maxXpt.XValue.ToString();
            textBox_MinXAxis.Text = minXpt.XValue.ToString();

            // textBox_SystemStatus.Text += maxYpt.ToString();




            Color c = Color.Red;
            //  minXpt.MarkerColor = c;
            //   minYpt.MarkerColor = c;
            //   maxXpt.MarkerColor = c;
            maxYpt.MarkerColor = c;
            //   minXpt.MarkerSize = 12;
            //   minYpt.MarkerSize = 12;
            //    maxXpt.MarkerSize = 12;
            maxYpt.MarkerSize = 20;
            maxYpt.MarkerStyle = MarkerStyle.Triangle;
            maxYpt.Label = String.Format("X= {0} Y= {1} dBm", maxYpt.XValue.ToString("0.##E+0"), maxYpt.YValues[0].ToString("0.00"));
            //Plot fig3 = new Plot("Figure 3 - FFT Log Magnitude ", "Frequency (Hz)", "Mag (dBV)");
            //fig3.PlotData(freqSpan, lmSpectrum);


            double MaxAmplitude = DSP.Analyze.FindMaxAmplitude(i_lmSpectrum);
            double MaxPosition = DSP.Analyze.FindMaxPosition(i_lmSpectrum);
            double MaxFrequency = DSP.Analyze.FindMaxFrequency(i_lmSpectrum, i_freqSpan);

            double Mean = DSP.Analyze.FindMean(i_lmSpectrum);


            double RMS = DSP.Analyze.FindRms(i_lmSpectrum);



            // Create a new legend called "Legend2".
            //  chart1.Legends.Add(new Legend(i_serias.Name));
            // Set Docking of the Legend chart to the Default Chart Area.
            //chart1.Legends[i_serias.Name].DockToChartArea = "Default";
            // Assign the legend to Series1.

            DataPoint prop = new DataPoint(0, 0);
            //chart1.Series[i_serias.Name].Points[(int)prop.XValue].Label = String.Format(" \n Mean [{0}] RMS [{1}]  MaxAmplitude [{2}] MaxPosition [{3}] MaxFrequency [{4}] \n \n", Mean.ToString("0.00"), RMS.ToString("0.00"), MaxAmplitude.ToString("0.00"), MaxPosition.ToString("0.00"), MaxFrequency.ToString("0.00"));

            int index = listBox_Charts.Items.Add(i_serias.Name);
            i_serias.LegendToolTip = String.Format(" \n{0} \n Mean [{1}] \n RMS [{2}] \n MaxAmplitude [{3}] \n MaxPosition [{4}] \n MaxFrequency [{5}] \n \n", i_serias.Name, Mean.ToString("0.00"), RMS.ToString("0.00"), MaxAmplitude.ToString("0.00"), MaxPosition.ToString("0.00"), MaxFrequency.ToString("0.##E+0"));
        }

        void CheckForMiniAdaDataDFT(SSPA_Parser i_MiniAdaParser)
        {
            //// Same Input Signal as Example 1 - Except a fractional cycle for frequency.
            //double amplitude = 1.0; double frequency = 20000.5;
            //UInt32 length = 1000; UInt32 zeroPadding = 9000; // NOTE: Zero Padding
            //double samplingRate = 100000;
            //double[] inputSignal = DSPLib.DSP.Generate.ToneSampling(amplitude, frequency, samplingRate, length);
            //// Apply window to the Input Data & calculate Scale Factor
            //double[] wCoefs = DSP.Window.Coefficients(DSP.Window.Type.FTNI, length);
            //double[] wInputData = DSP.Math.Multiply(inputSignal, wCoefs);
            //double wScaleFactor = DSP.Window.ScaleFactor.Signal(wCoefs);
            //// Instantiate & Initialize a new DFT
            //DSPLib.DFT dft = new DSPLib.DFT();
            //dft.Initialize(length, zeroPadding); // NOTE: Zero Padding
            //                                     // Call the DFT and get the scaled spectrum back
            //Complex[] cSpectrum = dft.Execute(wInputData);
            //// Convert the complex spectrum to note: Magnitude Format
            //double[] lmSpectrum = DSPLib.DSP.ConvertComplex.ToMagnitude(cSpectrum);
            //// Properly scale the spectrum for the added window
            //lmSpectrum = DSP.Math.Multiply(lmSpectrum, wScaleFactor);
            //// For plotting on an XY Scatter plot generate the X Axis frequency Span
            //double[] freqSpan = dft.FrequencySpan(samplingRate);
            //// At this point a XY Scatter plot can be generated from,
            //// X axis => freqSpan
            //// Y axis => lmSpectrum

            //var series = new Series("Freq 2");
            //var series2 = new Series("Time 2");
            //listBox_Charts.Items.Add(series.Name);
            //listBox_Charts.Items.Add(series2.Name);
            //// Frist parameter is X-Axis and Second is Collection of Y- Axis
            //series.Points.DataBindXY(freqSpan, lmSpectrum);

            //for (int i = 0; i < inputSignal.Length / 10; i++)
            //{
            //    series2.Points.AddXY(i, inputSignal[i]);
            //}
            //series2.ChartType = SeriesChartType.Line;
            //chart1.Series.Add(series);
            //chart1.Series.Add(series2);

            //  double samplingRate = Convert.ToDouble(TextBoxFsSamplingRate.Text); ;
            //UInt32 zeroPadding = 9000;
            double scale = 2 ^ 11 - 1;


            double[] IQ1Sigal = new double[i_MiniAdaParser.IQData.I1.Length];
            double[] IQ2Sigal = new double[i_MiniAdaParser.IQData.I2.Length];

            for (int i = 0; i < i_MiniAdaParser.IQData.I1.Length; i++)
            {
                IQ1Sigal[i] = (double)(i_MiniAdaParser.IQData.I1[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q1[i] / scale / 2);
            }


            for (int i = 0; i < i_MiniAdaParser.IQData.I2.Length; i++)
            {
                IQ2Sigal[i] = (double)(i_MiniAdaParser.IQData.I2[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q2[i] / scale / 2);
            }

            int zeroPadding = 0;
            //   Int32.TryParse(TextBox_Zeropadding.Text, out zeroPadding);



            // Instantiate & Initialize a new DFT
            DSPLib.DFT dft = new DSPLib.DFT();
            DSPLib.DFT dft2 = new DSPLib.DFT();
            //DSPLib.DFT dft = new DSPLib.DFT();
            dft.Initialize((uint)IQ1Sigal.Length, (uint)zeroPadding); // NOTE: Zero Padding
            dft2.Initialize((uint)IQ2Sigal.Length, (uint)zeroPadding);

            // Call the DFT and get the scaled spectrum back

            // Convert the complex spectrum to note: Magnitude Format

            // Properly scale the spectrum for the added window

            // For plotting on an XY Scatter plot generate the X Axis frequency Span
            //double[] freqSpan = dft.FrequencySpan(samplingRate);
            //double[] freqSpan2 = dft2.FrequencySpan(samplingRate);
            // At this point a XY Scatter plot can be generated from,
            // X axis => freqSpan
            // Y axis => lmSpectrum

            listBox_Charts.BeginInvoke(new EventHandler(delegate
            {
                var series1 = new Series("IQ1 Freq " + ChartIndex.ToString());
                var series2 = new Series("IQ1 Time " + ChartIndex.ToString());
                var series3 = new Series("IQ2 Freq " + ChartIndex.ToString());
                var series4 = new Series("IQ2 Time " + ChartIndex.ToString());

                ChartIndex++;
                listBox_Charts.Items.Add(series1.Name);
                listBox_Charts.Items.Add(series2.Name);
                listBox_Charts.Items.Add(series3.Name);
                listBox_Charts.Items.Add(series4.Name);
                // Frist parameter is X-Axis and Second is Collection of Y- Axis
                //       series1.Points.DataBindXY(freqSpan, lmSpectrum);

                for (int i = 0; i < IQ1Sigal.Length; i++)
                {
                    series2.Points.AddXY(i, IQ1Sigal[i]);
                }
                series2.ChartType = SeriesChartType.Line;
                chart1.Series.Add(series1);
                chart1.Series.Add(series2);

                //    series3.Points.DataBindXY(freqSpan, lmSpectrum);

                for (int i = 0; i < IQ1Sigal.Length; i++)
                {
                    series4.Points.AddXY(i, IQ1Sigal[i]);
                }
                series4.ChartType = SeriesChartType.Line;
                chart1.Series.Add(series3);
                chart1.Series.Add(series4);

                PlotGraphTimer = -1;
                textBox_SystemStatus.Text = "Graphs is ready;";
                textBox_SystemStatus.BackColor = Color.LightGreen;
            }));


        }

        void ParseKratosIncomeFrame(byte[] i_IncomeBuffer)
        {
            try
            {
                KratosProtocolFrame Result = new KratosProtocolFrame();
                Result = Kratos_Protocol.DecodeKratusProtocol_Standard(i_IncomeBuffer);
                TCPClientBuffer = new byte[0];

                textBox_RxClientPreamble.BeginInvoke(new EventHandler(delegate
                {
                    if (Result != null)
                    {
                        textBox_RxClientPreamble.BackColor = Color.LightGreen;
                        textBox_RxClientPreamble.Text = Result.Preamble;

                        textBox_RxClientOpcode.BackColor = Color.LightGreen;
                        textBox_RxClientOpcode.Text = Result.Opcode;

                        textBox_RxClientData.BackColor = Color.LightGreen;
                        textBox_RxClientData.Text = Result.Data;

                        textBox_RxClientDataLength.BackColor = Color.LightGreen;
                        textBox_RxClientDataLength.Text = Result.DataLength + " Bytes";

                        textBox_RxClientCheckSum.BackColor = Color.LightGreen;
                        textBox_RxClientCheckSum.Text = Result.CheckSum;

                        MiniAdaParser = new SSPA_Parser();
                        string SystemResultReceived = MiniAdaParser.ParseKratosFrame(Result);

                        SystemLogger.LogMessage(Color.Blue, Color.Azure, "", New_Line = false, Show_Time = true);
                        SystemLogger.LogMessage(Color.Blue, Color.Azure, "Rx:>", false, false);

                        if (SystemResultReceived.Contains("ACK") == true)
                        {
                            SystemLogger.LogMessage(Color.DarkGreen, Color.White, SystemResultReceived, true, false);
                        }
                        else
                        {
                            SystemLogger.LogMessage(Color.Blue, Color.Azure, SystemResultReceived, true, false);
                        }


                        GlobalSystemResultReceived += SystemResultReceived;



                        richTextBox_ClientRx.Invoke(new EventHandler(delegate
                        {
                            byte[] Onlythe40FirstBytes = i_IncomeBuffer.Skip(0).Take(200).ToArray();
                            richTextBox_ClientRxPrintText("[" + DateTime.Now.TimeOfDay.ToString().Substring(0, 11) + "] " + ByteArrayToString(Onlythe40FirstBytes) + "\n \n");
                            //richTextBox_ClientRx.AppendText("[" + dt.TimeOfDay.ToString().Substring(0, 11) + "] " + Encoding.ASCII.GetString(buffer) + " \n");



                        }));

                    }


                }));
            }
            catch (Exception ex)
            {
                SystemLogger.LogMessage(Color.Red, Color.White, ex.Message, true, false);
            }
        }

        String GlobalSystemResultReceived;
        int ChartIndex = 0;
        SSPA_Parser MiniAdaParser = new SSPA_Parser();
        void ParseIncomeBuffer_TCPIP()
        {
            try
            {
                TcpClient PClientSocket = ClientSocket;
                if (TCPClientBuffer.Length > 0)
                {

                    ParseKratosIncomeFrame(TCPClientBuffer);

                    PClientSocket = ClientSocket;
                }
            }
            catch (Exception ex)
            {
                SystemLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = false, Show_Time = true);
            }
        }

        void TCPClientConnection()
        {
            if (ClientSocket == null || ClientSocket.Client == null)
            {
                button_ClientConnect.BackColor = default;
            }
            label_ClientTCPConnected.BackColor = button_ClientConnect.BackColor;


            if (label_ClientTCPConnected.BackColor == Color.LightGreen)
            {
                label_TCPClient.Text = textBox_ClientIP.Text + "  \n" + textBox_ClientPort.Text;
            }
            else
            {
                label_TCPClient.Text = "None";
            }

            if (WaitforBufferFull > 0)
            {
                WaitforBufferFull--;
                textBox_SystemStatus.Text = string.Format("Wait for income buffer [{0}] ", WaitforBufferFull);
                textBox_SystemStatus.BackColor = Color.Yellow;


            }
            else
            {


                ParseIncomeBuffer_TCPIP();




            }

        }

        void CheckIfSerialPortOpen()
        {
            if (serialPort.IsOpen == true)
            {
                groupBox43.Enabled = true;
            }
            else
            {
                groupBox43.Enabled = false;
            }
        }
        //bool timer_General_TranssmitionPeriodicallyEnable = false;
        //uint NumbeOfTransmmitions = 0;
        int TimerClearModemStatus = 0;
        //uint IntervalTimeBetweenTransmitions = 1;
        private void Timer_General_Tick(object sender, EventArgs e)
        {

            // CheckIfSerialPortOpen();


            TCPClientConnection();

            if (PlotGraphTimer > 0)
            {
                textBox_SystemStatus.Text = string.Format("Generating graph [{0}] ", PlotGraphTimer);
                textBox_SystemStatus.BackColor = Color.AliceBlue;
                PlotGraphTimer--;
            }
            else
            {
                if (PlotGraphTimer == 0)
                {
                    textBox_SystemStatus.Text = string.Empty;
                    textBox_SystemStatus.BackColor = default;
                    PlotGraphTimer--;
                }
            }
            //Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab0Color = randomColor;

            //randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab1Color = randomColor;

            //randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab2Color = randomColor;

            //randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab3Color = randomColor;
            tabControl_Main.Invalidate();

            if (IsTimerRunning == true)
            {
                int.TryParse(textBox_TimerTime.Text, out int Result);
                if (Result != 0)
                {
                    Result--;
                    if (Result == 0)
                    {
                        SerialPortLogger.LogMessage(Color.White, Color.DarkOrange, "Timer End", true, true);
                        checkBox_S1Pause.Checked = true;

                        ResetTimer();
                    }
                    else
                    {

                    }
                    textBox_TimerTime.Text = Result.ToString();
                }
            }


            //         label_TimeDate.Text = DateTime.Now.ToString();
            //label_TimeDate2.Text = DateTime.Now.ToString();
            //label_TimeDate3.Text = DateTime.Now.ToString();

            if (TimerStatusRingWait > 0)
            {
                TimerStatusRingWait--;
                button_Ring.Text = "Ring Processing (" + TimerStatusRingWait + ")" + "(" + SendOneTimeFlag + ")";

            }
            else
            {
                button_Ring.BackColor = default;
                button_Ring.Text = "Ring";
            }

            //  TimerCounter100ms++;

            TimerClearModemStatus++;

            //TimerExportContactsCommandsToFile++;



            if (m_Server != null)
            {
                textBox_CurrentTimeOut.Text = ((TimeOutKeepAlivein100ms / 10) - (GetDataIntervalCounter / 10)).ToString();

            }




            if (CloseSerialPortTimer == true)
            {
                CloseSerialPortConter++;
                if (CloseSerialPortConter > 1)
                {
                    SerialPort_DataReceived(null, null);
                    CloseSerialPortConter = 0;
                }
            }
            try
            {
                if (m_Server != null)
                {

                    if (m_Server.NumberOfOpenConnections == 0)
                    {
                        var dataSource = new List<string>
                        {
                            "None"
                        };
                        comboBox_ConnectionNumber.DataSource = dataSource;
                        LastConNum = m_Server.NumberOfOpenConnections;

                        ConnectionToIDdictionary.Clear();
                        //for (int i = 0; i < UnitNumberToConnections.Length; i++)
                        //{
                        //    UnitNumberToConnections[i] = "";
                        //}
                    }
                    else
                        if (LastConNum != m_Server.NumberOfOpenConnections)
                    {
                        List<string> ret = m_Server.GetAllOpenConnections();

                        List<string> listkeys = new List<string>(ConnectionToIDdictionary.Keys);
                        foreach (string str in listkeys)
                        {
                            bool found = false;

                            foreach (string str2 in ret)
                            {
                                if (str == str2)
                                {
                                    found = true;

                                }
                            }

                            if (found == false)
                            {
                                ConnectionToIDdictionary.Remove(str);
                            }
                        }

                        comboBox_ConnectionNumber.DataSource = ret;

                        LastConNum = m_Server.NumberOfOpenConnections;


                    }
                    PrintDictineryIDKeys();
                }



            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Red, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
            //if (ComPortClosing == true)
            //{
            //    Thread.Sleep(4000);
            //    serialPort_DataReceived(null, null);
            //}


        }

        void PrintDictineryIDKeys()
        {
            textBox_IDKey.Invoke(new EventHandler(delegate
            {
                textBox_IDKey.Text = "Connection       |      Unit ID \n";
                textBox_IDKey.AppendText("------------------------------------- \n");
            }));

            foreach (var pair in ConnectionToIDdictionary)
            {
                textBox_IDKey.Invoke(new EventHandler(delegate
                {
                    textBox_IDKey.AppendText(pair.Key + " | " + pair.Value.Replace(';', ' ') + " \n");
                }));
            }

        }

        static int LastConNum = 0;
        static int CloseSerialPortConter = 0;


        bool CloseSerialPortTimer = false;

        bool ComPortClosing = false;
        //List<byte> temp_serialBuff = new List<byte>();
        void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            // If the com port has been closed, do nothing
            if (!serialPort.IsOpen) return;


            if (ComPortClosing == true)
            {
                //Thread.Sleep(400);
                serialPort.Close();
                ComPortClosing = false;

                //checkBox_ComportOpen.Checked = false;

                cmbBaudRate.Invoke(new EventHandler(delegate
                 {
                     //button_OpenPort.Checked = false;
                     button_OpenPort.Enabled = true;
                     gbPortSettings.Enabled = true;

                     button_OpenPort.BackColor = default;
                     label_SerialPortConnected.BackColor = default;
                     label_SerialPortStatus.Text = "";

                     cmbBaudRate.Enabled = true;
                     cmbDataBits.Enabled = true;
                     cmbParity.Enabled = true;
                     cmb_PortName.Enabled = true;
                     cmb_StopBits.Enabled = true;
                 }));

                CloseSerialPortTimer = false;

                SerialPortLogger.LogMessage(Color.Orange, Color.LightGray, "Serial port Closed", New_Line = true, Show_Time = true);
                return;
            }

            // This method will be called when there is data waiting in the port's buffer
            Thread.Sleep(300);

            if (!serialPort.IsOpen) return;

            RxLabelTimerBlink = 5;

            // Obtain the number of bytes waiting in the port's buffer
            int bytes = serialPort.BytesToRead;

            // Create a byte array buffer to hold the incoming data
            byte[] buffer = new byte[bytes];

            // Read the data from the port and store it in our buffer
            serialPort.Read(buffer, 0, bytes);

            SerialPortLogger.LogMessage(Color.Blue, Color.Azure, "", New_Line = false, Show_Time = true);
            SerialPortLogger.LogMessage(Color.Blue, Color.Azure, "Rx:>", false, false);

            if (checkBox_RxHex.Checked == true)
            {

                string IncomingHexMessage = ConvertByteArraytToString(buffer);

                SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, IncomingHexMessage, New_Line = true, Show_Time = false);

                ParseKratosIncomeFrame(buffer);
            }
            else
            {

                string IncomingString = System.Text.Encoding.Default.GetString(buffer);




                string[] lines = Regex.Split(IncomingString, "\r\n");

                foreach (string line in lines)
                {
                    SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, line, New_Line = true, Show_Time = false);
                }


                ParseSerialPortString(IncomingString);
            }



        }

        private byte[] StringToByteArray(string hex)
        {
            try
            {
                return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();

            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.Message, New_Line = true, Show_Time = false);
                return null;
            }
        }

        String ConvertByteArraytToString(byte[] i_Buffer)
        {
            string IncomingHexMessage = "";
            foreach (byte by in i_Buffer)
            {
                IncomingHexMessage += by.ToString("X2") + " ";

            }

            return IncomingHexMessage;
        }



        enum SourceMessage
        {
            SMS,
            SerialPort,
            Server
        };

        void ParseStatuPos(string IncomingString)
        {
            string[] ParseStrings = { "" };
            string[] Key = { "" };
            try
            {
                if (IncomingString.Contains(","))
                {
                    ParseStrings = IncomingString.Split(',');
                    Key = ParseStrings[1].Split('=');
                }
            }
            catch
            {
                //ServerLogger.LogMessage(Color.Black, Color.White, "Data Not Valid: " + IncomingString, New_Line = true, Show_Time = true);
                return;
            }

            Boolean IwatcherPrint = false;


            if (Key[0] == "POS")
            {

                if (IwatcherPrint == true)
                {

                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n STATE = " + Key[1] +
                        "\n GSM LINK QUALITY = " + ParseStrings[2] +
                        "\n GPS STATUS = " + ParseStrings[3] +
                        "\n GPS NUM OF SATELLITES = " + ParseStrings[4] +
                        "\n CURRENT TIME AND DATE = " + ParseStrings[5] + " " + ParseStrings[6] +
                        "\n LAST GPS TIME AND DATE = " + ParseStrings[7] + " " + ParseStrings[8] +
                        "\n GPS LATITUDE = " + ParseStrings[9] +
                        "\n GPS LONGTITUDE = " + ParseStrings[10] +
                        "\n GPS SPEED = " + ParseStrings[11] +
                        "\n GPS DIRECTION =" + ParseStrings[12] +
                        "\n TRIP DISTANCE  = " + ParseStrings[13] +
                        "\n TOTAL DISTANCE = " + ParseStrings[14];
                    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                }

                //string ret = "";
                //if (checkBox_ShowURL.Checked)
                //{
                //    string ret = "http://maps.google.com/maps?q=" + ParseStrings[9] + "," + ParseStrings[10] + "( " + " Current Time: " + DateTime.Now + "\r\n   S1TimeStamp: " + " )" + "&z=14&ll=" + "," + "&z=17";
                //    Show_WebBrowserUrl(ret);
                //}

                //if (checkBox_RecordLatLong.Checked)
                //{

                //    NumOfPositionMessage++;
                //    //354869050154426,POS=1,GSMLinkQual,5,8,12/9/2013,10:55:11,12/9/2013,10:55:11,32.155636,34.920308,0,304.2,


                //    KMl_text.Add("<Placemark>");
                //    KMl_text.Add("<name>" + "[" + NumOfPositionMessage + "]" + " " + DateTime.Now + "  </name>");
                //    KMl_text.Add("<Point>");
                //    KMl_text.Add("<coordinates>" + ParseStrings[10] + "," + ParseStrings[9] + "</coordinates> ");
                //    KMl_text.Add("</Point>");
                //    KMl_text.Add("</Placemark> ");
                //    KMl_text.Add("</Document> \n");
                //    KMl_text.Add("</kml> \n");

                //    File.Delete(log_file_S1_LatLong);
                //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(log_file_S1_LatLong))
                //    {
                //        foreach (string str in KMl_text)
                //        {
                //            file.WriteLine(str);
                //        }
                //        //for (int i = 0; i < KML_Index; i++)
                //        //{

                //        //}
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        // KML_Index -= 2;
                //    }


                //}

                //if (checkBox_EchoResponse.Checked == true)
                //{

                //    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                //    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                //    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                //    SendDataToServer(mye.ConnectionNumber, b2);
                //}


            }
            else
                if (Key[0] == "STAT")
            {
                if (IwatcherPrint == true)
                {
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: " + i_SourceMessage.ToString(), New_Line = false, Show_Time = true);
                    //if (i_Contact != null)
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: " + i_Contact.Name, New_Line = false, Show_Time = false);
                    //}
                    //else
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: ", New_Line = false, Show_Time = false);
                    //}
                    //LogIWatcher.LogMessage(Color.DarkOrange, Color.White, "\nSTATUS Message Received: ", New_Line = false, Show_Time = false);

                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n SYSTEM STATE = " + Key[1] +
                        "\n IGN STATE = " + ParseStrings[2] +
                        "\n GP1 = " + ParseStrings[3] +
                        "\n GP2 = " + ParseStrings[4] +
                        "\n GP3 = " + ParseStrings[5] +
                        "\n Main Power Source = " + ParseStrings[6] +
                        "\n Back Up Battery problem indication = " + ParseStrings[7] +
                        "\n OUTPUT 1  STATE = " + ParseStrings[8] +
                        "\n OUTPUT 2  STATE = " + ParseStrings[9] +
                        "\n OUTPUT 3  STATE = " + ParseStrings[10] +
                        "\n OUTPUT 4  STATE = " + ParseStrings[11] +
                        "\n DATE = " + ParseStrings[12] +
                        "\n TIME  = " + ParseStrings[13] +
                        "\n GPS LATITUDE = " + ParseStrings[14] +
                        "\n GPS LONGTITUDE = " + ParseStrings[15] +
                        "\n VEHICLE SPEED = " + ParseStrings[16] +
                        "\n SPEED EVENT  = " + ParseStrings[17] +
                        "\n BATTERY LOW EVENT =" + ParseStrings[18] +
                        "\n BATTERY CUT OFF EVENT  = " + ParseStrings[19] +
                        "\n ACCIDENT EVENT = " + ParseStrings[20] +
                        "\n TOWING EVENT = " + ParseStrings[21] +
                        "\n TILT EVENT = " + ParseStrings[22];

                    //LogIWatcher.LogMessage(Color.Blue, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
            else
                    if (Key[0] == "GETCONFIG?")
            {
                if (IwatcherPrint == true)
                {


                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n SUBSCRIBER 1 = " + ParseStrings[2] +
                        "\n SUBSCRIBER 2 = " + ParseStrings[3] +
                        "\n SUBSCRIBER 3 = " + ParseStrings[4] +
                        "\n SPEED LIMIT = " + ParseStrings[5] +
                        "\n vehicle battery threshold = " + ParseStrings[6] +
                        "\n pos message duration time interval = " + ParseStrings[7] +
                        "\n pos message according distance interval = " + ParseStrings[8] +
                        "\n status message duration time interval on sleep = " + ParseStrings[9] +
                        "\n Logger Counter = " + ParseStrings[10] +
                        "\n Tilt angle= " + ParseStrings[11] +
                        "\n Tilt sensitivity = " + ParseStrings[12] +
                        "\n Tilt Constant = " + ParseStrings[13] +
                        "\n TOW angle  = " + ParseStrings[14] +
                        "\n TOW sensitivity = " + ParseStrings[15] +
                        "\n TOW Constant = " + ParseStrings[16] +
                        "\n Anti Jamming detection = " + ParseStrings[17] +
                        "\n Anti Jamming configuration = " + ParseStrings[18] +
                        "\n GPRS reconnection = " + ParseStrings[19] +
                        "\n Satellite type = " + ParseStrings[20];

                    //LogIWatcher.LogMessage(Color.Blue, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
            else
                        if (Key[0] == "GETCONFIG2?")
            {
                if (IwatcherPrint == true)
                {

                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n password = " + ParseStrings[2] +
                        "\n primary host address + port = " + ParseStrings[3] +
                        "\n primary access point name = " + ParseStrings[4] +
                        "\n fota host address + port = " + ParseStrings[5] +
                        "\n fota access point name = " + ParseStrings[6] +
                        "\n software version = " + ParseStrings[7] +
                        "\n GPS num of used satellites = " + ParseStrings[8] +
                        "\n GPS last timestamp  = " + ParseStrings[9];

                    //LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
        }
        private static readonly Mutex mutexACKSMSReceived = new Mutex();

        void ParseSerialPortSMSString(string IncomingString)
        {

        }

        void ParseSerialPortString(string IncomingString)
        {
            // Boolean ret;
            try
            {
                ParseUnitVersion(IncomingString.Replace(System.Environment.NewLine, " "));
                IncomingString = IncomingString.Replace(System.Environment.NewLine, "");
                ParseConfigCommand(IncomingString);
                //ret = ParseSMSCommand(IncomingString);

                ParseStatuPos(IncomingString);

                // ParseUnitVersion(IncomingString);





            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = true, Show_Time = true);
                //    return;
            }
        }

        Boolean ParseSMSCommand(string IncomingString)
        {
            Boolean ret = false;
            Boolean IsCommandFound = true;
            while (IsCommandFound == true)
            {

                int StartCommand = IncomingString.IndexOf("{COMMAND_SMS_START}");
                int EndCommand = IncomingString.IndexOf("{COMMAND_SMS_END}");
                if (StartCommand >= 0 && EndCommand >= 0 && (EndCommand > StartCommand))
                {
                    ret = true;
                    StartCommand += "{COMMAND_SMS_START}".Length;
                    string CommandString = IncomingString.Substring(StartCommand, EndCommand - StartCommand);

                    //       LogSMS.LogMessage(Color.Cyan, Color.White, CommandString, New_Line = true, Show_Time = true);

                    EndCommand += "{COMMAND_SMS_END}".Length;
                    IncomingString = IncomingString.Substring(EndCommand);
                    IsCommandFound = true;

                    ModemStatus mdmStat = new ModemStatus(ref CommandString);

                    if (mdmStat.Valid == true)
                    {
                        richTextBox_ModemStatus.Invoke(new EventHandler(delegate
                        {
                            TimerClearModemStatus = 0;
                            if ((mdmStat.ModemRegistrationStatus == "1" || mdmStat.ModemRegistrationStatus == "5") && mdmStat.SIMStatus == "1")
                            {
                                richTextBox_ModemStatus.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                richTextBox_ModemStatus.BackColor = Color.Red;
                            }

                            richTextBox_ModemStatus.Text =
                                  " Modem Registered: " + mdmStat.ModemRegistrationStatus +
                                "\n Sim: " + mdmStat.SIMStatus +
                                "\n Modem RSSI: " + mdmStat.RSSI +
                                "\n Operator Name: " + mdmStat.Operator +
                                "\n Modem IMEI: " + mdmStat.ModemIMEI +
                                "\n Sim IMSI: " + mdmStat.SimIMSI +
                                "\n Modem Update Counter: " + mdmStat.ModemEUpdateCounter;
                        }));

                    }

                    if (CommandString.Contains("SMS was Send To the Modem"))
                    {
                        mutexACKSMSReceived.WaitOne();
                        //   ACKSMSReceived = true;
                        mutexACKSMSReceived.ReleaseMutex();

                        //LogSMS.LogMessage(Color.DarkBlue, Color.White, "SMS Send ACK received", New_Line = true, Show_Time = true);

                        if (checkBox_SMSencrypted.Checked == true)
                        {
                            string[] temp = CommandString.Split('[', ']');
                            //   LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                            //   LogSMS.LogMessage(Color.Green, Color.White, "Encrypted SMS (Copy to server Tab):\n" + temp[5], New_Line = true, Show_Time = false);

                            txtDataTx.Invoke(new EventHandler(delegate
                            {
                                txtDataTx.Text = temp[5];
                            }));

                        }
                    }
                    else
                    if (CommandString.Contains("Modem ring to Contact."))
                    {
                        string[] temp = CommandString.Split('[', ']');
                        //LogSMS.LogMessage(Color.DarkBlue, Color.White, "Ring to contact, Phone Number: " + temp[3] + " Hangout: " + temp[5], New_Line = true, Show_Time = true);

                    }

                    if (CommandString.Contains("SMS_received Decrypted"))
                    {
                        string[] strsplit = CommandString.Split('[', ']');


                        ParseSMSText(strsplit[1], strsplit[3], Color.Brown);
                    }
                    else
                        if (CommandString.Contains("SMS_received"))
                    {
                        string[] strsplit = CommandString.Split('[', ']');


                        ParseSMSText(strsplit[1], strsplit[3], Color.Blue);
                    }
                }
                else
                {
                    IsCommandFound = false;
                }
            }

            return ret;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        void ParseSMSText(string i_Subscriber, string i_SMSText, Color i_ColorDisplay)
        {
            i_Subscriber = i_Subscriber.Replace("\"", "");
            PhoneBookContact ContactFound = MyPhoneBook.IsNumberExist(i_Subscriber);

            string ReceivedUnitID = String.Empty;




            if (ContactFound != null)
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                //    LogSMS.LogMessage(i_ColorDisplay, Color.White, "\n SMS Received: ", New_Line = false, Show_Time = false);
                //    LogSMS.LogMessage(Color.DarkBlue, Color.Yellow, "\n Contact:  " + ContactFound.ToString(), New_Line = false, Show_Time = false);
                //    LogSMS.LogMessage(i_ColorDisplay, Color.White, "\n Text:  " + i_SMSText, New_Line = true, Show_Time = false);

                if (ReceivedUnitID != String.Empty)
                {
                    if (IsDigitsOnly(ReceivedUnitID))
                    {
                        if (ContactFound.UnitID != ReceivedUnitID)
                        {
                            ContactFound.UnitID = ReceivedUnitID;

                            UpdateDefaultsContacts();

                            UpdatePhoneBook();
                        }
                    }
                }
            }
            else
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                //       LogSMS.LogMessage(i_ColorDisplay, Color.White, "SMS Received: " + "\n Number:  " + i_Subscriber + "\n Text:  " + i_SMSText, New_Line = true, Show_Time = false);



                PhoneBookContact NewContact = new PhoneBookContact
                {
                    Name = "",            //values preserved after close
                    Phone = i_Subscriber,
                    Notes = ""
                };

                if (ReceivedUnitID != String.Empty)
                {
                    if (IsDigitsOnly(ReceivedUnitID))
                    {
                        NewContact.UnitID = ReceivedUnitID;
                    }
                }
                //Do something here with these values

                MyPhoneBook.AddContactToPhoneBook(NewContact);

                UpdateDefaultsContacts();

                UpdatePhoneBook();

            }



            ParseStatuPos(i_SMSText);



        }
        string UnitVersion;
        void ParseUnitVersion(string IncomingString)
        {
            if (IncomingString.Contains("******START******") == true)
            {
                int StartConfig = IncomingString.IndexOf("******START******");
                StartConfig += "******START******".Length;
                UnitVersion = IncomingString.Substring(StartConfig);
                int EndConfig = UnitVersion.IndexOf("*********************");
                UnitVersion = UnitVersion.Substring(0, EndConfig);



            }

        }

        void ParseConfigCommand(string IncomingString)
        {
            int StartConfig = IncomingString.IndexOf("{CONFIG_START}");
            int EndConfig = IncomingString.IndexOf("{CONFIG_END}");
            if (StartConfig >= 0 && EndConfig > 0 && (EndConfig > StartConfig))
            {
                StartConfig += "{CONFIG_START}".Length;
                string ConfigString = IncomingString.Substring(StartConfig, EndConfig - StartConfig);

                if (ConfigString.Contains("CONFIGOK"))
                {
                    //TextBox_GenerateConfigFile_Text("Config OK", Color.LightGreen);
                }
                else
                {
                    //SendToConfigPage(ConfigString, "Serial Port");
                }
            }
        }


        private void Button_StopPeriodaclly_Click(object sender, EventArgs e)
        {


        }

        private DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }


        private void Button_SetTimedOut_Click(object sender, EventArgs e)
        {

            try
            {
                int Timeoutvalue = int.Parse(textBox_ConnectionTimedOut.Text);

                //if(m_Server != null)
                //{
                //     m_Server.SetTimeoutinSeconds = Timeoutvalue * 10;
                //}
                TimeOutKeepAlivein100ms = Timeoutvalue * 10;
                GetDataIntervalCounter = 0;


            }
            catch
            {
                textBox_ConnectionTimedOut.Text = "300";
            }
        }

        //  static int LastNumOfConnections = 0;
        private void TextBox_NumberOfOpenConnections_TextChanged(object sender, EventArgs e)
        {

            if (m_Server != null)
            {

                if (m_Server.NumberOfOpenConnections > 1)
                {
                    // IsTimedOutTimerEnabled = true;
                    textBox_NumberOfOpenConnections.BackColor = Color.Orange;
                    //ListenBox.BackColor = Color.Green;

                    ServerLogger.LogMessage(Color.Orange, Color.White, "Num Of Connections is bigger than one, " + m_Server.NumberOfOpenConnections, true, true);

                }
                else
                    if (m_Server.NumberOfOpenConnections == 1)
                {
                    //IsTimedOutTimerEnabled = true;
                    //ListenBox.BackColor = Color.Green;
                    textBox_NumberOfOpenConnections.BackColor = Color.Green;
                }
                else
                {
                    // IsTimedOutTimerEnabled = false;
                    textBox_NumberOfOpenConnections.BackColor = default;
                }

                GetDataIntervalCounter = 0;


                //if (LastNumOfConnections > m_Server.NumberOfOpenConnections)
                //{
                //    //ListenBox.BackColor = Color.Yellow;
                //}

                // LastNumOfConnections = m_Server.NumberOfOpenConnections;
            }

        }

        private void Button_AddDendSingleCommand_Click(object sender, EventArgs e)
        {
            try
            {
                //textBox_AddSendSingleCommand.Text = CommandsDescription[comboBox_AddSendSingleCommand.SelectedIndex].Format;
            }
            catch
            {
            }
        }

        private void ComboBox_AddSendSingleCommand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button_ValidateCommand_Click(object sender, EventArgs e)
        {


        }


        private void Button6_Click(object sender, EventArgs e)
        {
            //button_ValidateCommand.Enabled = true;
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            //Config_Sys.Enabled = true;
            //ConfigProcessExit = true;
        }


        private void CheckBox_EchoResponse_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        BinaryReader m_BinaryReader;
        readonly Dictionary<int, string> FOTAData = new Dictionary<int, string>();
        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                textBox_FOTA.Text = openFileDialog1.FileName;

                try
                {
                    m_BinaryReader = new BinaryReader(File.Open(ConfigFileName, FileMode.Open));

                    int length = (int)m_BinaryReader.BaseStream.Length;
                    textBox_TotalFileLength.Text = length.ToString();
                    textBox_TotalFrames1280Bytes.Text = (Math.Ceiling((decimal)length / 1280)).ToString();

                    textBox_MaximumNumberReceivedRequest.Invoke(new EventHandler(delegate
                    {

                        textBox_MaximumNumberReceivedRequest.Text = "";

                    }));


                    //txtDataTx.Text = ";<1234>STARTFOTA=," + (Math.Ceiling((decimal)length / 1280)).ToString() + "," + length.ToString() + ",;";
                    string StartFota = string.Format(";<{0}>STARTFOTA=,{1},{2},;", "", textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);
                    txtDataTx.Text = StartFota;
                    richTextBox_TextSendSMS.Text = StartFota;
                    //AddCommandToCommands(StartFota);

                    FOTAData.Clear();
                    for (int i = 0; i < int.Parse(textBox_TotalFrames1280Bytes.Text); i++)
                    {


                        // int PositionInFile = 1280 * i;
                        //  m_BinaryReader.ReadBytes(PositionInFile);
                        byte[] buffer = new byte[1280];

                        for (int k = 0; k < 1280; k++)
                        {
                            buffer[k] = 0x30;
                        }
                        byte[] temp = m_BinaryReader.ReadBytes(1280);

                        temp.CopyTo(buffer, 0);

                        string str = Encoding.ASCII.GetString(buffer);
                        byte b = CalcCheckSumbuffer(buffer);
                        string SendString = string.Format("@$@FOTAS,{0},{1},{2}", i, Encoding.ASCII.GetString(buffer), CalcCheckSumbuffer(buffer).ToString("x2"));

                        FOTAData[i] = SendString;


                    }

                    m_BinaryReader.Close();




                    button_StartFOTAProcess.Enabled = true;



                }
                catch (Exception ex)
                {
                    ServerLogger.LogMessage(Color.Blue, Color.White, ex.ToString(), New_Line = true, Show_Time = false);
                }

                if (m_BinaryReader != null && ConfigFileName != null)
                {
                    button_StartFOTA.Enabled = true;
                }
                //AllFileLines = File.ReadAllText(ConfigFileName);



            }
        }

        private void TextBox_FOTA_TextChanged(object sender, EventArgs e)
        {
            if (textBox_FOTA.Text.Length > 0)
            {
                textBox_FOTA.BackColor = Color.White;
            }
        }

        private void TextBox_MaximumNumberReceivedRequest_TextChanged(object sender, EventArgs e)
        {
            if (textBox_MaximumNumberReceivedRequest.Text.Length > 0)
            {
                textBox_MaximumNumberReceivedRequest.BackColor = Color.White;
            }
        }

        private void TextBox_TotalFrames256Bytes_TextChanged(object sender, EventArgs e)
        {
            //if (textBox_TotalFrames256Bytes.Text.Length > 0)
            //{
            //    textBox_TotalFrames256Bytes.BackColor = Color.White;
            //}
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            //if (textBox_TotalFrames1280Bytes.Text.Length > 0 && textBox_TotalFileLength.Text.Length > 0)
            //{
            //    //txtDataTx.Text = ";<" + Monitor.Properties.Settings.Default.SystemPassword + ">STARTFOTA=," + textBox_TotalFrames1280Bytes.Text + "," + textBox_TotalFileLength.Text + ",;";
            //    txtDataTx.Text = string.Format(";<{0}>STARTFOTA=,{1},{2},;", Monitor.Properties.Settings.Default.SystemPassword, textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);           
            //}


            ServerLogger.LogMessage(Color.Blue, Color.White, "****************** System ID's Status ****************** ", New_Line = true, Show_Time = true);
            foreach (var pair in IDToFOTA_Status)
            {
                ServerLogger.LogMessage(Color.Blue, Color.White, pair.Key + "   " + pair.Value + " \n", New_Line = false, Show_Time = false);

            }
        }

        private void Button35_Click(object sender, EventArgs e)
        {
            //textBox_MaximumNumberReceivedRequest.Text = "";
            IDToFOTA_Status.Clear();
            PrintFotaIDStatus();
            //textBox_FOTAEnd.BackColor = default(Color);
            //textBox_FOTAEnd.Text = "";
        }

        private void Button34_Click(object sender, EventArgs e)
        {
            int NumOfSendingPackets = 0, NumOfMissingPackets = 0;
            string[] StringSplt = textBox_MaximumNumberReceivedRequest.Text.Split(',');
            try
            {
                int NumOfPacketes = int.Parse(textBox_TotalFrames1280Bytes.Text);

                ServerLogger.LogMessage(Color.Blue, Color.White, "****************** Packets Reusults Which Didn't Found ****************** ", New_Line = true, Show_Time = true);
                for (int i = 0; i < NumOfPacketes; i++)
                {
                    bool found = false;
                    foreach (string str in StringSplt)
                    {
                        try
                        {
                            int PacketNum = int.Parse(str);
                            if (i == 0)
                            {
                                NumOfSendingPackets++;
                            }
                            if (i == PacketNum)
                            {
                                found = true;
                            }
                        }
                        catch
                        {
                        }
                    }
                    if (found == true)
                    {
                        //   ServerLogger.LogMessage(Color.Blue, Color.White,  i + " X ", New_Line = true, Show_Time = false);
                    }
                    else
                    {
                        NumOfMissingPackets++;
                        ServerLogger.LogMessage(Color.Blue, Color.White, i + ",  ", New_Line = false, Show_Time = false);
                    }
                }
                ServerLogger.LogMessage(Color.Blue, Color.White, "\n\nTotal Packets: " + NumOfPacketes + ", ToTal Sending Packets: " + NumOfSendingPackets + ", ToTal Missing Packets: " + NumOfMissingPackets, New_Line = true, Show_Time = false);
                ServerLogger.LogMessage(Color.Blue, Color.White, "****************** Packets Reusults End ****************** ", New_Line = true, Show_Time = true);
            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void UpdateSerialPortHistory(string i_SendString)
        {
            Boolean Found = false;

            foreach (string str in Monitor.Properties.Settings.Default.SerialPort_History)
            {
                //comboBox_SerialPortHistory.Items.Add((object)str);
                // comboBox_SMSCommands.Items.Add(str);
                if (str == i_SendString)
                {
                    Found = true;
                }
            }

            if (Found == false)
            {
                Monitor.Properties.Settings.Default.SerialPort_History.Add(i_SendString);
                Monitor.Properties.Settings.Default.Save();
            }

            if (CommandsHistoy.Count > 0)
            {
                String LastCommand = CommandsHistoy[CommandsHistoy.Count - 1];

                if (LastCommand != i_SendString)
                {
                    CommandsHistoy.Add(i_SendString);
                }
            }




            //if (Monitor.Properties.Settings.Default.SerialPort_History != null)
            //{
            //    CommandsHistoy.Clear();
            //    foreach (string str in Monitor.Properties.Settings.Default.SerialPort_History)
            //    {
            //        CommandsHistoy.Add(str);
            //        // comboBox_SMSCommands.Items.Add(str);
            //    }
            //}
        }

        void UpdateSerialPortComboBox()
        {
            if (Monitor.Properties.Settings.Default.SerialPort_History != null)
            {
                CommandsHistoy.Clear();
                foreach (string str in Monitor.Properties.Settings.Default.SerialPort_History)
                {
                    CommandsHistoy.Add(str);
                    // comboBox_SMSCommands.Items.Add(str);
                }
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            bool IsSent = false;
            if (checkBox_SendHexdata.Checked == true)
            {
                String tempStr = textBox_SendSerialPort.Text.Replace(" ", "");

                byte[] buffer = StringToByteArray(tempStr);

                if (buffer != null)
                {
                    IsSent = SerialPortSendData(buffer);
                }
                else
                {
                    SerialPortLogger.LogMessage(Color.Red, Color.LightGray, "Not Hex data format for example: aabbcc is 0xAA 0xBB 0xCC", New_Line = true, Show_Time = false);
                }

                if (IsSent == true)
                {
                    UpdateSerialPortHistory(textBox_SendSerialPort.Text);

                    //    UpdateSerialPortComboBox();

                    if (checkBox_DeleteCommand.Checked == true)
                    {
                        textBox_SendSerialPort.Text = "";
                    }



                    SerialPortLogger.LogMessage(Color.Purple, Color.Azure, "", New_Line = false, Show_Time = true);
                    SerialPortLogger.LogMessage(Color.Purple, Color.Azure, "Tx:>", false, false);
                    SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, ConvertByteArraytToString(buffer), true, false);



                }


            }
            else
            {


                String tempStr = textBox_SendSerialPort.Text.Replace("\\n", "\n");
                tempStr = tempStr.Replace("\\r", "\r");
                byte[] buffer = Encoding.ASCII.GetBytes(tempStr);

                IsSent = SerialPortSendData(buffer);

                if (IsSent == true)
                {
                    UpdateSerialPortHistory(textBox_SendSerialPort.Text);

                    //    UpdateSerialPortComboBox();

                    if (checkBox_DeleteCommand.Checked == true)
                    {
                        textBox_SendSerialPort.Text = "";
                    }



                    SerialPortLogger.LogMessage(Color.Purple, Color.Azure, "", New_Line = false, Show_Time = true);
                    SerialPortLogger.LogMessage(Color.Purple, Color.Azure, "Tx:>", false, false);
                    SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, Encoding.ASCII.GetString(buffer), true, false);

                }


            }
            TxLabelTimerBlink = 5;






        }

        private void Button29_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox_GenerateConfigFile_Clear();
                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {
                    //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
                }

                //  string UnitID = textBox_ConfigUnitID.Text;
                string UnitID = "00000000000";
                string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";

                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "Text Files | *.txt",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.Delete(saveFileDialog1.FileName);
                    using (StreamWriter sw = File.AppendText(saveFileDialog1.FileName))
                    {
                        //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();

                        sw.WriteLine("// " + "Date: " + DateTime.Now.ToString() + "  Unit ID: " + UnitID);
                        sw.WriteLine();
                        sw.WriteLine();

                        string SendStr = GenerateConfigCommand();

                        SendStr = SendStr.Replace(";", ",");

                        byte[] buf = Encoding.ASCII.GetBytes(SendStr);
                        int Size = buf.Length;
                        Byte CheckSum = CalcCheckSumbufferSize(buf);


                        SendStr = ";{CONFIG_START}," + SendStr + "," + Size + "," + CheckSum + ",{CONFIG_END};";

                        sw.Write(SendStr);

                    }
                }

                // This text is always added, making the file longer over time 
                // if it is not deleted. 


                //textBox_GenerateConfigFile.BackColor = Color.Green;
                //textBox_GenerateConfigFile.Text = "File has been saved: \n" + saveFileDialog1.FileName ;
                //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {

                ex.ToString(); //Gil: just remove warning.
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void Button31_Click(object sender, EventArgs e)
        {
            //TextBox_SourceConfig_Clear();

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                //textBox_SourceConfig.Text = "File have been chosen: \n" + openFileDialog1.FileName;

                string[] lines = System.IO.File.ReadAllLines(ConfigFileName);

                foreach (string line in lines)
                {
                    if (line.Contains("//") || line == "")
                    {

                    }
                    else
                    {
                        string str;
                        //";{CONFIG_START}," + SendStr + ",{CONFIG_END};";
                        str = line.Replace(";{CONFIG_START},,", "");
                        str = str.Replace(",{CONFIG_END};", "");
                        //SendToConfigPage(str, "File");
                    }
                }


            }



            //ParseConfigString(";23421342134,CONFIG=,12321321,434343434,656565656,55554,43434,66665,6565645456,6,6,6,6,6,6,6,6,5,5,5,5,5,5,5,5,5,4,4,4,4,4,4,4,4,4,3,3,3,3,6,6,6,41,3;");

        }

        bool ParseConfigString(string i_Config)
        {
            try
            {

                string[] StringSplit = i_Config.Replace(";", "").Split(',');

                if (StringSplit[0].Length > 17 || StringSplit[0].Length < 12)
                {
                    return false;
                }



                // Store keys in a List
                //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
                //// Loop through list
                //int i = 2;
                //foreach (string k in list)
                //{
                //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];

                //    temp.Invoke(new EventHandler(delegate
                //    {
                //        if (i < StringSplit.Length)
                //        {
                //            temp.Text = StringSplit[i];
                //        }
                //    }));
                //    i++;
                //}
                //textBox_Config1.Text = StringSplit[2];
                //textBox_Config2.Text = StringSplit[3];
                //textBox_Config3.Text = StringSplit[4];
                //textBox_Config4.Text = StringSplit[5];
                //textBox_Config5.Text = StringSplit[6];
                //textBox_Config6.Text = StringSplit[7];
                //textBox_Config7.Text = StringSplit[8];
                //textBox_Config8.Text = StringSplit[9];
                //textBox_Config9.Text = StringSplit[10];
                //textBox_Config10.Text = StringSplit[11];
                //textBox_Config11.Text = StringSplit[12];
                //textBox_Config12.Text = StringSplit[13];
                //textBox_Config13.Text = StringSplit[14];
                //textBox_Config14.Text = StringSplit[15];
                //textBox_Config15.Text = StringSplit[16];
                //textBox_Config16.Text = StringSplit[17];
                //textBox_Config17.Text = StringSplit[18];
                //textBox_Config18.Text = StringSplit[19];
                //textBox_Config19.Text = StringSplit[20];
                //textBox_Config20.Text = StringSplit[21];
                //textBox_Config21.Text = StringSplit[22];
                //textBox_Config22.Text = StringSplit[23];
                //textBox_Config23.Text = StringSplit[24];
                //textBox_Config24.Text = StringSplit[25];
                //textBox_Config25.Text = StringSplit[26];
                //textBox_Config26.Text = StringSplit[27];
                //textBox_Config27.Text = StringSplit[28];

                return true;
            }
            catch 
            {
                //textBox_SourceConfig.Invoke(new EventHandler(delegate
                //{
                //    textBox_SourceConfig.Text = ex.ToString();
                //    textBox_SourceConfig.BackColor = Color.Red;
                //}));


                return false;
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Button6_Click_2(object sender, EventArgs e)
        {
            //   textBox_SendSerialPort.Text = "<1234>READ?,;";
            //TextBox_SourceConfig_Clear();

            string Sendstr = string.Format(";READ?,;");
            byte[] buffer = Encoding.ASCII.GetBytes(Sendstr);
            bool IsSent = SerialPortSendData(buffer);

            if (IsSent == true)
            {
                //textBox_SourceConfig.Text = "Command sent";

            }

        }

        private void TextBox_GenerateConfigFile_TextChanged(object sender, EventArgs e)
        {

        }

        //bool IsDigitsOnly(string str)
        //{
        //    foreach (char c in str)
        //    {
        //        if (c < '0' || c > '9')
        //            return false;
        //    }

        //    return true;
        //}

        enum ConfigDataType
        {
            PosPeriod5Sec,
            AutoARM,
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
            GPRSDisconnectNum,
            GPSType,
            DISARMCODE,
            CutSpeed
        };
        bool CheckSubscriberValid(string i_String, ConfigDataType i_DataType)
        {
            bool ret;
            try
            {


                switch (i_DataType)
                {
                    case ConfigDataType.CutSpeed:
                        if (i_String.Length <= 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 20 || Num == 255)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.DISARMCODE:
                        if (i_String.Length == 4 && (Regex.IsMatch(i_String, @"^[1-5]+$") || Regex.IsMatch(i_String, @"^[0]+$") || i_String == "9999"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.GPSType:
                        if (i_String.Length == 1 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 2)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.PosPeriod5Sec:
                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num > 0)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.AutoARM:
                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 2 && Num <= 300)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.EveryThing:
                        ret = true;
                        break;

                    case ConfigDataType.PeriodStatus:

                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 96)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Angel:

                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 360)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.SpeedLimit:

                        ret = false;

                        break;

                    case ConfigDataType.BatLevel:

                        if (i_String.Length < 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 9)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.JammingSens:

                        if (i_String.Length < 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Jamming = int.Parse(i_String);

                            if (Jamming >= 20 && Jamming <= 70)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Float:
                        float f;

                        if (float.TryParse(i_String, out f))
                        {

                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }



                        break;

                    case ConfigDataType.Number:
                        if (Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.GPRSDisconnectNum:
                        if (i_String.Length < 6 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.Port:
                        if (i_String.Length < 6 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.AlarmViaSMS:
                        if (i_String.Length < 8 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                            UpdateAlarmCheckBoxes();
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.IpAddress:
                        //                IPAddress address;
                        //if (IPAddress.TryParse(i_String, out address))
                        if (i_String.Length > 4)
                        {
                            //Valid IP, with address containing the IP
                            ret = true;
                        }
                        else
                        {
                            //Invalid IP
                            ret = false;
                        }
                        break;
                    case ConfigDataType.Subscriber:
                        if (i_String == "0")
                        {
                            ret = true;
                        }
                        else
                        if (i_String.Length < 6)
                        {
                            ret = false;
                        }
                        else
                            if (i_String.Length < 20 && (i_String.StartsWith("+") || i_String.StartsWith("00")) && Regex.IsMatch(i_String.Substring(1), @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Password:

                        if (i_String.Length < 15)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Boolean:
                        if (i_String == "0" || i_String == "1")
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Unit_ID:
                        if (i_String.Length > 14 && i_String.Length < 17 && Regex.IsMatch(i_String, @"^[0-9]+$"))
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
                //TextBox_GenerateConfigFile_Text(ex.ToString(), Color.Red);
                ret = false;
            }

            return ret;
        }

        bool CheckAllTextboxConfig()
        {

            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list
            ////bool IsAllGreen = true;
            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    if (temp.BackColor == Color.Red && temp.Visible == true)
            //    {
            //        return false;
            //    }
            //}

            return true;
        }

        private void TextBox_Config1_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        private void TextBox_Config2_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        private void TextBox_Config3_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        void CheckConfigTextboxValidData(TextBox i_TextBox, ConfigDataType i_ConfigDataType)
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
                    //  i_TextBox.Visible = true;
                    i_TextBox.BackColor = Color.Red;
                }
            }));
        }

        private void TextBox_Config4_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Password);
        }

        private void TextBox_Config5_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.BatLevel);
        }

        //void TextBox_SourceConfig_Clear()
        //{
        //    textBox_SourceConfig.BackColor = default;
        //    textBox_SourceConfig.Text = "";
        //}

        private void Button3_Click_2(object sender, EventArgs e)
        {
            //   textBox_SendSerialPort.Text = "<1234>READ?,;"

            //TextBox_SourceConfig_Clear();

        }

        void Password_form_Load(object sender, EventArgs e)
        {

        }

        string GenerateConfigCommand()
        {

            //sw.Write(";" + UnitID + ",CONFIG=,");
            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list

            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    string Field = temp.Text;
            //    if (Field == "")
            //    {
            //        Field = "@%@";
            //    }
            //    SendStr += Field + ",";
            //}

            string SendStr = ";";

            return SendStr;
        }


        //void CleartextBox_GenerateConfigFile()
        //{
        //    textBox_GenerateConfigFile.Text = "";
        //    textBox_GenerateConfigFile.BackColor = default(Color);
        //}

        private void Button28_Click_1(object sender, EventArgs e)
        {
            try
            {
                TextBox_GenerateConfigFile_Clear();

                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {
                    //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
                }



                
                

                //string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";


                // This text is always added, making the file longer over time 
                // if it is not deleted. 

                //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();




                //textBox_GenerateConfigFile.BackColor = Color.Green;

            }
            catch (Exception ex)
            {
                ex.ToString(); //Gil: just remove warning.
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void Button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                TextBox_GenerateConfigFile_Clear();
                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {

                }


                //string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";


                // This text is always added, making the file longer over time 
                // if it is not deleted. 

                //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();

                string SendStr = GenerateConfigCommand();

                SendStr = SendStr.Replace(";", ",");

                byte[] buf = Encoding.ASCII.GetBytes(SendStr);
                int Size = buf.Length;
                Byte CheckSum = CalcCheckSumbufferSize(buf);


                SendStr = ";{CONFIG_START}," + SendStr + "," + Size + "," + CheckSum + ",{CONFIG_END};";
                byte[] buffer = Encoding.ASCII.GetBytes(SendStr);
                bool IsSent = SerialPortSendData(buffer);

                if (IsSent == true)
                {
                    //textBox_GenerateConfigFile.BackColor = Color.Yellow;
                    //textBox_GenerateConfigFile.Text = "Config has been sent";

                }

                //textBox_GenerateConfigFile.BackColor = Color.Green;
                //textBox_GenerateConfigFile.Text = "File " +  + " saved in directory \n" + Directory.GetCurrentDirectory();
            }
            catch (Exception ex)
            {
                ex.ToString(); //Gil: just remove warning.
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void Button30_Click(object sender, EventArgs e)
        {

        }

        //textBox_UnitVersion



        void TextBox_GenerateConfigFile_Clear()
        {
            //textBox_GenerateConfigFile.Invoke(new EventHandler(delegate
            //    {
            //        textBox_GenerateConfigFile.Text = "";
            //        textBox_GenerateConfigFile.BackColor = default(Color);
            //    }));
        }




        private void TextBox_ConfigUnitID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list

            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    temp.Visible = true;
            //}

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox_LoadedConfig_Enter(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void TextBox_Config13_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.AlarmViaSMS);

        }

        void UpdateAlarmCheckBoxes()
        {

        }

        private void CheckBox_config_Bit0_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        void UpdateTextBox13()
        {



        }

        private void CheckBox_config_Bit4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit6_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit7_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit8_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit9_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit10_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void TextBox_Config10_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.IpAddress);
        }

        private void TextBox_Config11_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.IpAddress);
        }

        private void TextBox_Config12_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Port);
        }

        private void TextBox_Config24_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config23_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config27_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPRSDisconnectNum);
        }

        private void TextBox_Config9_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void TextBox_Config29_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config26_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.JammingSens);
        }

        private void TextBox_Config6_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Port);
        }

        private void TextBox_Config7_TextChanged(object sender, EventArgs e)
        {

            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.SpeedLimit);


        }

        private void TextBox_Config8_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.PeriodStatus);
        }

        private void TextBox_Config14_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void TextBox_Config15_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config16_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config17_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void TextBox_Config18_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config19_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config20_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void TextBox_Config21_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config22_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.PosPeriod5Sec);
        }

        private void TextBox_Config28_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config30_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config25_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Float);
        }

        private void CheckBox_RecordGeneral_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void TextBox_IDKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPortNo_TextChanged(object sender, EventArgs e)
        {
            Monitor.Properties.Settings.Default.Start_Port = txtPortNo.Text.ToString();

            Monitor.Properties.Settings.Default.Save();
        }

        private void Button33_Click_1(object sender, EventArgs e)
        {
            using (var form = new AddContact())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {

                    PhoneBookContact NewContact = new PhoneBookContact
                    {
                        Name = form.ContactName,            //values preserved after close
                        Phone = form.ContactPhone,
                        Notes = form.ContactNotes,
                        Password = form.ContactPassword,
                        UnitID = form.ContactIMEI
                    };
                    //Do something here with these values

                    MyPhoneBook.AddContactToPhoneBook(NewContact);

                    UpdateDefaultsContacts();

                    UpdatePhoneBook();


                }
            }
        }

        bool CheckValidSMS(string i_SMS)
        {
            return true;
        }

        string ReturnCommandWithPassword(string i_Command, PhoneBookContact i_Contact)
        {
            string temp;
            string command = i_Command;
            int endindex = command.IndexOf('>');
            if (endindex >= 0 && checkBox_SendSMSAsIs.Checked == false)
            {
                temp = ";<" + i_Contact.Password + ">" + command.Substring(endindex + 1);
            }
            else
            {
                temp = command;
            }

            return temp;
        }

        private void Button39_Click(object sender, EventArgs e)
        {
            //groupBox34.Enabled = false;
            foreach (var item in checkedListBox_PhoneBook.CheckedItems)
            {
                if (item != null)
                {
                    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)item);
                    //SendSMSToContact((PhoneBookContact)item, SMSText);
                }
            }
            //     AddCommandToCommands(richTextBox_TextSendSMS.Text);
            //    groupBox34.Enabled = true;
        }

        void RemoveSelectedContact()
        {

        }

        private void Button_RemoveContact_Click(object sender, EventArgs e)
        {
            RemoveSelectedContact();
        }

        private void Button_ExportToXML_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                FileName = "MyContacts",
                Filter = "XML files (*.xml)|*.xml",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    MyPhoneBook.ExportToXML(myStream);
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }







        }

        private void Button_ImportToXML_Click(object sender, EventArgs e)
        {


        }

        void AddCommandToCommands(string i_SMSText)
        {

        }

        /// <summary>
        /// 
        /// </summary>
      //  bool ACKSMSReceived = false;
        //void SendSMSToContact(PhoneBookContact i_Contact, string i_SMSText)
        //{
        //    // AddCommandToCommands(i_SMSText);
        //    int PosStr = 0;
        //    if (i_Contact == null)
        //    {
        //        return;
        //    }

        //    //i_SMSText = i_SMSText.Replace("\n", string.Empty);
        //    //i_SMSText = i_SMSText.Replace("\r", string.Empty);
        //    while (PosStr < i_SMSText.Length)
        //    {

        //        string SMSToSend ;
        //        int CharsLeft = i_SMSText.Length - PosStr;
        //        //.SubString( 0, dec.Length > 240 ? 240 : dec.Length )

        //        if (CharsLeft > 160)
        //        {
        //            SMSToSend = i_SMSText.Substring(PosStr, 160);

        //        }
        //        else
        //        {
        //            SMSToSend = i_SMSText.Substring(PosStr, CharsLeft);
        //        }
        //        PosStr += 160;

        //        string StrToSend = "{SMS_SEND}," + i_Contact.Phone + "," + SMSToSend + "\r{SMS_END}";

        //        StrToSend = ReturnSMSEncryiepted(StrToSend);

        //        byte[] buffer = Encoding.ASCII.GetBytes(StrToSend);

        //        bool IsSent = SerialPortSMSSendData(buffer);

        //        if (IsSent == true)
        //        {

        //  //          LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
        //            //LogSMS.LogMessage(Color.Green, Color.White, "  SMS was Sent:\n Contact: " + i_Contact.ToString() + "\n Text:  " + SMSToSend, New_Line = true, Show_Time = false);

        //            Thread.Sleep(1500);

        //        }
        //    }
        //}

        //bool ACKSMSReceived = false;
        void RingToContact(PhoneBookContact i_Contact)
        {
            // AddCommandToCommands(i_SMSText);
            //  int PosStr = 0;
            if (i_Contact == null)
            {
                return;
            }



            string StrToSend = "{RING," + i_Contact.Phone + ",}";

            byte[] buffer = Encoding.ASCII.GetBytes(StrToSend);

            // bool IsSent = SerialPortSMSSendData(buffer);

            //if (IsSent == true)
            //{
            //    //  mutexACKSMSReceived.WaitOne();
            //    //ACKSMSReceived = false;
            //    //   ACKSMSReceived = true;
            //    //Thread.Sleep(1000);
            //    //   mutexACKSMSReceived.ReleaseMutex();

            //    //int cnt = 0;
            //    //while (ACKSMSReceived == false && cnt < 100)
            //    //{
            //    //    Thread.Sleep(50);
            //    //    cnt++;
            //    //}
            //    //if (ACKSMSReceived)
            //    //{
            //    //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            ////    LogSMS.LogMessage(Color.Green, Color.White, "  Ring to Contact:\n Contact: " + i_Contact.ToString(), New_Line = true, Show_Time = false);

            //    Thread.Sleep(1500);
            //    //}
            //    //else
            //    //{
            //    //    LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            //    //    LogSMS.LogMessage(Color.Red, Color.White, "  SMS wasn't Sent to " + i_Contact.ToString() + "  Text:  " + SMSToSend, New_Line = true, Show_Time = false);
            //    //}

            //    //return true;
            //}

        }

        string ReturnSMSEncryiepted(string i_SMSText)
        {
            if (checkBox_SMSencrypted.Checked == true)
            {
                return "{ENCRYPED," + textBox_UnitIDForSMS.Text + "," + textBox_CodeArrayForSMS.Text + "," + i_SMSText;
            }
            else
            {
                return i_SMSText;
            }
        }

        private void Button_SendSelectedSMS_Click(object sender, EventArgs e)
        {

            if (checkedListBox_PhoneBook.SelectedItem != null)
            {
                //groupBox34.Enabled = false;

                string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                if (CheckValidSMS(SMSText))
                {


                    //SendSMSToContact((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem, SMSText);
                }
                else
                {
                    //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                    //        LogSMS.LogMessage(Color.Red, Color.White, "SMS Not Valid", New_Line = true, Show_Time = false);
                }

                // AddCommandToCommands(richTextBox_TextSendSMS.Text);
                //groupBox34.Enabled = true;
            }
        }

        private void Button33_Click_2(object sender, EventArgs e)
        {
            using (var form = new AddContact())
            {
                PhoneBookContact Contact = (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem;
                form.Load += new EventHandler(Form_Load);

                if (Contact != null)
                {
                    form.ContactName = Contact.Name;
                    form.ContactName = Contact.Phone;
                    form.ContactNotes = Contact.Notes;
                    form.ContactPassword = Contact.Password;
                    form.ContactIMEI = Contact.UnitID;

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Contact.Name = form.ContactName;            //values preserved after close
                        Contact.Phone = form.ContactPhone;
                        Contact.Notes = form.ContactNotes;
                        Contact.Password = form.ContactPassword;
                        Contact.UnitID = form.ContactIMEI;
                        //Do something here with these values

                        //MyPhoneBook.AddContactToPhoneBook(NewContact);

                        UpdateDefaultsContacts();

                        UpdatePhoneBook();


                    }
                }
            }
        }

        void Form_Load(object sender, EventArgs e)
        {
            PhoneBookContact Contact = (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem;
            if (Contact != null)
            {
                AddContact form = (AddContact)sender;
                form.TextBoxName = Contact.Name;
                form.TextBoxPhone = Contact.Phone;
                form.TextBoxNotes = Contact.Notes;
                form.TextBoxPassword = Contact.Password;
                form.TextBoxIMEI = Contact.UnitID;
            }
        }

        private void Button36_Click(object sender, EventArgs e)
        {
            richTextBox_ModemStatus.BackColor = default;
            richTextBox_ModemStatus.Text = "";
        }

        private void RichTextBox_TextSendSMS_TextChanged(object sender, EventArgs e)
        {
            label_SMSSendCharacters.Text = richTextBox_TextSendSMS.Text.Length.ToString() + "/160 = " + (richTextBox_TextSendSMS.Text.Length / 160 + 1);
            //if (richTextBox_TextSendSMS.Text.Length < 160)
            //{
            //    richTextBox_TextSendSMS.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    richTextBox_TextSendSMS.BackColor = Color.Red;
            //}
        }

        private void Button_SMSOpenPort_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_Config31_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.AutoARM);
        }

        private void PictureBox_logo_Click(object sender, EventArgs e)
        {

        }

        private void Button_SetConfigSMS_Click(object sender, EventArgs e)
        {

        }

        private void Button_EndFOTAReset_Click(object sender, EventArgs e)
        {
            if (textBox_TotalFrames1280Bytes.Text.Length > 0 && textBox_TotalFileLength.Text.Length > 0)
            {
                //txtDataTx.Text = ";<1234>ENDFOTA=," + textBox_TotalFrames1280Bytes.Text + "," + textBox_TotalFileLength.Text + ",;";
                txtDataTx.Text = string.Format(";<{0}>ENDFOT=,{1},{2},;", "", textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);
            }
        }

        private void TextBox_Config32_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void CheckBox_S1RecordLog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button_AddToSendSMS_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_Config33_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.DISARMCODE);
        }

        private void ComboBox_SMSCommands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void ListBox_SMSCommands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button41_Click(object sender, EventArgs e)
        {

        }

        private void Button37_Click(object sender, EventArgs e)
        {
           
        }

        void SortSMSCommands()
        {
            ArrayList q = new ArrayList();
            foreach (object o in listBox_SMSCommands.Items)
            {
                q.Add(o);
            }
            q.Sort();
            listBox_SMSCommands.Items.Clear();
            foreach (object o in q)
            {

                listBox_SMSCommands.Items.Add(o);
            }
        }

        void SMSCommandForm_Load(object sender, EventArgs e)
        {

        }

        ///
        void RemoveSelectedCommand()
        {




        }

        private void Button40_Click(object sender, EventArgs e)
        {
            RemoveSelectedCommand();

        }

        private void Button39_Click_1(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                FileName = "MySMSCommands",
                Filter = "XML files (*.xml)|*.xml",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    List<string> templist = new List<string>();
                    foreach (var item in listBox_SMSCommands.Items)
                    {
                        templist.Add((string)item);
                    }
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    TextWriter textWriter = new StreamWriter(myStream);

                    serializer.Serialize(textWriter, templist);
                    textWriter.Close();
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void Button38_Click(object sender, EventArgs e)
        {



        }





        private void CheckedListBox_PhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox_PhoneBook.SelectedItem != null)
            {
                PhoneBookContact contact = (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem;

                richTextBox_ContactDetails.Text = string.Format("Name: \n{0}\n\nPhone: \n{1}\n\nPassword: \n{3}\n\nUnit ID: \n{4}\n\nNotes: \n{2}\n ", contact.Name, contact.Phone, contact.Notes, contact.Password, contact.UnitID);

                textBox_UnitIDForSMS.Text = contact.UnitID;

            }

        }

        private void TextBox_Config34_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void Button34_Click_1(object sender, EventArgs e)
        {
            string StartFota = string.Format(";<{0}>STARTFOTA=,{1},{2},;", "", textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);
            txtDataTx.Text = StartFota;
            richTextBox_TextSendSMS.Text = StartFota;
        }

        private void Label_Config12_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config32_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config31_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config11_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config3_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config28_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config29_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void CheckBox_OpenPortSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OpenPortSMS.Checked)
            {

                checkBox_OpenPortSMS.BackColor = Color.Yellow;


                //serialPort_SMS.BaudRate = 38400;
                //serialPort_SMS.DataBits = 8;
                //serialPort_SMS.StopBits = StopBits.One;
                //serialPort_SMS.Parity = Parity.None;
                //serialPort_SMS.PortName = comboBox_ComportSMS.Text;






                //serialPort_SMS.Open();





                checkBox_OpenPortSMS.BackColor = Color.Green;

                // serialPort_SMS.DataReceived += new SerialDataReceivedEventHandler(SerialPort_SMS_DataReceived);

                comboBox_ComportSMS.Enabled = false;






            }
            else
            {

                checkBox_OpenPortSMS.BackColor = default;
                //checkBox_ComportOpen.Enabled = false;


                //serialPort_SMS.Close();

                comboBox_ComportSMS.Enabled = true;
                //groupBox_ServerSettings.Enabled = true;
            }
        }

        //void SerialPort_SMS_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    // If the com port has been closed, do nothing
        //    if (!serialPort_SMS.IsOpen) return;

        //    // This method will be called when there is data waiting in the port's buffer
        //    Thread.Sleep(300);

        //    if (!serialPort_SMS.IsOpen) return;

        //    // Obtain the number of bytes waiting in the port's buffer
        //    int bytes = serialPort_SMS.BytesToRead;

        //    // Create a byte array buffer to hold the incoming data
        //    byte[] buffer = new byte[bytes];

        //    // Read the data from the port and store it in our buffer
        //    //serialPort_SMS.Read(buffer, 0, bytes);


        //    string IncomingString = System.Text.Encoding.Default.GetString(buffer);

        //    if (checkBox_DebugSMS.Checked == true)
        //    {

        //        //LogSMS.LogMessage(Color.Black, Color.LightGray, "", New_Line = false, Show_Time = true);
        //      //  LogSMS.LogMessage(Color.Black, Color.LightGray, IncomingString, New_Line = true, Show_Time = false);
        //    }


        //    ParseSerialPortSMSString(IncomingString);
        //}

        private void TextBox_Config35_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void TextBox_Config36_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void Button_SerialPortAdd_Click(object sender, EventArgs e)
        {
            //if (comboBox_SerialPortHistory.SelectedItem != null)
            //{
            //    textBox_SendSerialPort.Text = comboBox_SerialPortHistory.SelectedItem.ToString();
            //}
        }

        private void TextBox_Config37_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config38_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);

        }

        private void CheckBox_SendSMSAsIs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_SMSencrypted_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SMSencrypted.Checked == true)
            {
                GrooupBox_Encryption.Enabled = true;
            }
            else
            {
                GrooupBox_Encryption.Enabled = false;
            }
        }

        private void TextBox_SpeedLimit1_TextChanged(object sender, EventArgs e)
        {

            SetSpeedThreeSpeedLimit();
        }

        void SetSpeedThreeSpeedLimit()
        {

            //Int32.TryParse(textBox_SpeedLimit1.Text, out int Speed1);
            //Int32.TryParse(textBox_SpeedLimit2.Text, out int Speed2);
            //Int32.TryParse(textBox_SpeedLimit3.Text, out int Speed3);


            //int temp;




        }

        private void TextBox_SpeedLimit2_TextChanged(object sender, EventArgs e)
        {
            SetSpeedThreeSpeedLimit();
        }

        private void TextBox_SpeedLimit3_TextChanged(object sender, EventArgs e)
        {
            SetSpeedThreeSpeedLimit();
        }

        private void Label_Config37_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config27_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config7_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox_Configuration_Enter(object sender, EventArgs e)
        {

        }

        private void Label_Config1_Click(object sender, EventArgs e)
        {

        }

        private void Label_Config2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_Config39_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void Button34_Click_2(object sender, EventArgs e)
        {
            SaveCommandsAndContacts();
        }

        private void CheckBox_S1Pause_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox33_Enter(object sender, EventArgs e)
        {

        }

        private void RichTextBox_ContactDetails_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox39_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox_Config40_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.CutSpeed);
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        string OpcodeToCompare = "";
        int SendOneTimeFlag = 0;
        //        private void Button_Ring_Click(object sender, EventArgs e)
        //        {
        //            if (checkedListBox_PhoneBook.SelectedItem != null
        //                //           && checkBox_SMSencrypted.Checked == true 
        //                && listBox_SMSCommands.SelectedItem != null
        //                && listBox_SMSCommands.SelectedItem != null
        //                && textBox_UnitIDForSMS.Text.Length >= 10
        //                //        && textBox_CodeArrayForSMS.Text.Length == 4
        //                && serialPort_SMS.IsOpen
        //                && ((checkBox_SMSencrypted.Checked == false) || (textBox_CodeArrayForSMS.Text.Length == 4))
        //                )
        //            {


        //                groupBox34.Enabled = false;

        //                button_Ring.BackColor = Color.Yellow;
        //                button_Ring.Text = "Ring Processing";

        //                SendOneTimeFlag = 1;
        //                TimerStatusRingWait = 300;
        //                RingToContact((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

        //                Thread.Sleep(1000);



        //                if (checkBox_SMSencrypted.Checked == true)
        //                {


        //                    string[] temp = richTextBox_TextSendSMS.Text.Split('>', '=');

        //                    OpcodeToCompare = temp[1];

        //                    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

        //                    //SMSText = ReturnSMSEncryiepted(SMSText);

        //                    if (CheckValidSMS(SMSText))
        //                    {
        //                        PhoneBookContact Temp = new PhoneBookContact
        //                        {
        //                            Phone = "+00000000000"
        //                        };

        //                        //SendSMSToContact(Temp, SMSText);
        //                    }
        //                    else
        //                    {
        //                        //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
        //                   //     LogSMS.LogMessage(Color.Red, Color.White, "SMS Not Valid", New_Line = true, Show_Time = false);
        //                    }

        //                    // AddCommandToCommands(richTextBox_TextSendSMS.Text);

        //                }
        //                else
        //                {
        //                    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);
        //                    txtDataTx.Text = SMSText;
        //                }

        //                groupBox34.Enabled = true;

        //            }
        //            else
        //            {
        //                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
        ////                string RingExplain = @"In Order to Ring you have to:
        ////1. Select the contact 
        ////2. Select the command
        ////3. Check that the password is the right password
        ////4. Check the Encripted checkbox
        ////5. Check the unit ID (IMEI),it should be the same IMEI target ID (when the status received it compare the IMEI recieved vs the UnitID TextBox)
        ////6. Check the Unit code it the right code
        ////7. Comport must be open ";
        //                //LogSMS.LogMessage(Color.Red, Color.White, RingExplain, New_Line = true, Show_Time = false);

        //                button_Ring.BackColor = default;
        //                button_Ring.Text = "Ring";
        //                SendOneTimeFlag = 0;
        //                TimerStatusRingWait = 0;

        //            }
        //        }

        void ScanComports()
        {
            cmb_PortName.Items.Clear();
            comboBox_ComportSMS.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmb_PortName.Items.Add(port);
                comboBox_ComportSMS.Items.Add(port);
            }
            if (ports.Length > 0)
            {
                cmb_PortName.SelectedIndex = 0;
                comboBox_ComportSMS.SelectedIndex = 0;
            }
        }

        private void Button_ReScanComPort_Click(object sender, EventArgs e)
        {
            ScanComports();
        }

        private void TextBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        readonly Stopwatch stopwatch = new Stopwatch();

        private void TextBox_StopWatch_TextChanged(object sender, EventArgs e)
        {

        }

        int TimerLogNumber = 0;
        private void Button_StopwatchReset_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            TimerLogNumber = 0;
            textBox_StopWatch.Text = PrintTimeSpan(stopwatch.Elapsed);
            button_Stopwatch_Start_Stop.BackColor = default;
        }

        private void Button_Stopwatch_Start_Stop_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning == false)
            {
                button_Stopwatch_Start_Stop.BackColor = Color.LightGreen;
                stopwatch.Start();
            }
            else
            {
                button_Stopwatch_Start_Stop.BackColor = default;
                stopwatch.Stop();
            }

        }

        private void Button_TimerLog_Click(object sender, EventArgs e)
        {
            TimerLogNumber++;
            SerialPortLogger.LogMessage(Color.DarkBlue, Color.White, "Stopwatch Log: " + TimerLogNumber + ">  " + PrintTimeSpan(stopwatch.Elapsed), true, true);
        }

        private void CheckBox_ParseMessages_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_Config42_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        Boolean IsTimerRunning = false;
        int TimerMemory = 0;
        private void Button_StartStopTimer_Click(object sender, EventArgs e)
        {
            IsTimerRunning = !IsTimerRunning;
            if (IsTimerRunning == true && (textBox_SetTimerTime.Text != "0" || textBox_TimerTime.Text != "0"))
            {


                int.TryParse(textBox_SetTimerTime.Text, out int Result);
                if (Result != 0)
                {
                    button_StartStopTimer.BackColor = Color.LightGreen;
                    TimerMemory = Result;
                    button_ResetTimer.Text = "Reset (" + TimerMemory + ")";
                    textBox_TimerTime.Text = textBox_SetTimerTime.Text;
                    textBox_SetTimerTime.Text = "0";
                }
                else
                {

                }
            }
            else
            {
                button_StartStopTimer.BackColor = default;

            }
        }

        private void CmbPortName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button42_Click(object sender, EventArgs e)
        {
            tabControl_Main.TabPages[5].BackColor = Color.Red;
        }

        private void Button43_Click(object sender, EventArgs e)
        {
            Process.Start(@".");
        }

        private void TextBox_SendSerialPort_TextChanged(object sender, EventArgs e)
        {
            //textBox_SendSerialPort.SelectionStart = textBox_SendSerialPort.Text.Length;
            //textBox_SendSerialPort.SelectionLength = 0;
        }

        private void TextBox_SourceConfig_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_SendTimer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_SendSerialDiff_TextChanged(object sender, EventArgs e)
        {

        }

        // private Random rnd = new Random();

        private void Button_ScreenShot_Click(object sender, EventArgs e)
        {
            TakeCroppedScreenShot();


        }


        private void ListBox_SMSCommands_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //      LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            for (int i = 0; i < listBox_SMSCommands.Items.Count; i++)
            {
                if (listBox_SMSCommands.GetSelected(i) == true)
                {
                    //           LogSMS.LogMessage(Color.Black, Color.White, "[" + listBox_SMSCommands.Items[i].ToString() + "]", New_Line = true, Show_Time = false);
                }
            }
            //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = true, Show_Time = false);
        }

        private void Button_ResetGraphs_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            ChartCntX = 0;
            foreach (var ser in chart1.Series)
            {
                ser.Points.Clear();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public System.Data.DataTable ExportToExcel(Series ser)
        //{
        //    System.Data.DataTable table = new System.Data.DataTable();
        //    table.Columns.Add("Chart name", typeof(string));
        //    table.Columns.Add("X", typeof(double));
        //    table.Columns.Add("Y", typeof(double));

        //    //foreach (var ser in chart1.Series)
        //    //{
        //    DataPoint[] TotalPoints = new DataPoint[ser.Points.Count];
        //    ser.Points.CopyTo(TotalPoints,0);
        //        foreach(var Point in TotalPoints)
        //        {
        //            table.Rows.Add(ser.Name , Point.XValue,Point.YValues[0]);
        //        }
        //    //}

        //    //table.Columns.Add("Chart", typeof(int));
        //    //table.Columns.Add("X", typeof(string));
        //    //table.Columns.Add("Y", typeof(string));

        //    //table.Columns.Add("Subject1", typeof(int));
        //    //table.Columns.Add("Subject2", typeof(int));
        //    //table.Columns.Add("Subject3", typeof(int));
        //    //table.Columns.Add("Subject4", typeof(int));
        //    //table.Columns.Add("Subject5", typeof(int));
        //    //table.Columns.Add("Subject6", typeof(int));
        //    //table.Rows.Add(1, "Amar", "M", 78, 59, 72, 95, 83, 77);
        //    //table.Rows.Add(2, "Mohit", "M", 76, 65, 85, 87, 72, 90);
        //    //table.Rows.Add(3, "Garima", "F", 77, 73, 83, 64, 86, 63);
        //    //table.Rows.Add(4, "jyoti", "F", 55, 77, 85, 69, 70, 86);
        //    //table.Rows.Add(5, "Avinash", "M", 87, 73, 69, 75, 67, 81);
        //    //table.Rows.Add(6, "Devesh", "M", 92, 87, 78, 73, 75, 72);
        //    return table;
        //}


        private void Button_Export_excel_Click(object sender, EventArgs e)
        {
            // writetext.WriteLine("writing in text file");


            this.Invoke((MethodInvoker)delegate ()
            {
                textBox_graph_XY.Text = "";
            });

            Series[] Serias_Graphs = new Series[chart1.Series.Count];
            chart1.Series.CopyTo(Serias_Graphs, 0);
            foreach (var ser in Serias_Graphs)
            {
                String fileName = ser.Name;
                String Location = AppDomain.CurrentDomain.BaseDirectory + fileName + DateTime.Now.ToString("MM_DD_HH_mm_ss") + ".csv";
                using (StreamWriter writetext = new StreamWriter(@Location))
                {

                    foreach (DataPoint point_ in ser.Points)
                    {
                        writetext.WriteLine(point_.XValue + "," + point_.YValues[0]);
                    }

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        textBox_graph_XY.Text += "Excel Generated at " + Location;
                    });
                }
            }


        }

        private void Button3_Click_3(object sender, EventArgs e)
        {
            // Color randomColor ;
            //Tab0Color = randomColor;
        }

        bool IsPauseGraphs = false;
        private void Button_GraphPause_Click(object sender, EventArgs e)
        {

            if (IsPauseGraphs == false)
            {
                IsPauseGraphs = true;
                button_GraphPause.BackColor = Color.Yellow;
            }
            else
            {

                IsPauseGraphs = false;
                button_GraphPause.BackColor = default;
            }
        }

        private void Button1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "helpfile.chm", HelpNavigator.TopicId, "1234");
        }

        private void Button_OpenFolder2_Click(object sender, EventArgs e)
        {
            Process.Start(@".");
        }

        void CloseClentConnection()
        {
            if (ClientSocket != null)
            {
                //ClientSocket.GetStream().Close();
                ClientSocket.Close();
            }

            if (ReceiveThread != null)
            {
                ReceiveThread.Abort();
                //   m_Exit = true;

            }

            button_Ping.BackColor = default;
            button_ClientConnect.BackColor = default;

            richTextBox_ClientRx.AppendText("Connection closed \n");
        }
        private void Button42_Click_1(object sender, EventArgs e)
        {
            CloseClentConnection();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString();
        }

        byte[] TCPClientBuffer = new byte[0];
        void ReceiveData()
        {
            TcpClient PClientSocket = ClientSocket;
            try
            {
                while (true)
                {
                    if (m_Exit == true)
                    {
                        return;
                    }

                    if (PClientSocket != null)
                    {
                        try
                        {
                            byte[] buffer = new byte[1000000];
                            Stream stm = PClientSocket.GetStream();



                            int NumOfReceivedBytes = stm.Read(buffer, 0, buffer.Length);
                            if (WaitforBufferFull == 0)
                            {
                                TCPClientBuffer = new byte[NumOfReceivedBytes];
                                Array.Copy(buffer, 0, TCPClientBuffer, 0, NumOfReceivedBytes);


                            }
                            else
                            {
                                byte[] temp = new byte[NumOfReceivedBytes + TCPClientBuffer.Length];
                                TCPClientBuffer.CopyTo(temp, 0);
                                Array.Copy(buffer, 0, temp, TCPClientBuffer.Length, NumOfReceivedBytes);
                                //buffer.CopyTo(temp, NumOfReceivedBytes);
                                TCPClientBuffer = temp;


                            }






                        }
                        catch (Exception ex)
                        {


                            SystemLogger.LogMessage(Color.Black, Color.Red, "Gil: " + ex.ToString(), New_Line = true, Show_Time = true);


                            return;



                        }
                    }
                    else
                    {
                        PClientSocket.Close();
                    }

                }
            }
            catch (System.Net.Sockets.SocketException se)
            {
                se.ToString(); //Gil: just remove warning.
                //MessageBox.Show(se.Message);
            }
        }

        bool m_Exit = false;
        TcpClient ClientSocket;
        Thread ReceiveThread;
        private void Button_ClientConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //create a new client socket ...
                m_Exit = false;
                //m_socWorker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                String szIPSelected = textBox_ClientIP.Text;
                String szPort = textBox_ClientPort.Text;
                int alPort = System.Convert.ToInt16(szPort, 10);

                ClientSocket = new TcpClient();
                var result = ClientSocket.BeginConnect(textBox_ClientIP.Text, alPort, null, null);

                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                if (!success)
                {
                    richTextBox_ClientRxPrintText(String.Format("Failed to connect to [{0}] [{1}]\n", szIPSelected, szPort));
                    return;
                }
                // we have connected
                ClientSocket.EndConnect(result);


                //System.Net.IPAddress	remoteIPAddress	 = System.Net.IPAddress.Parse(szIPSelected);
                //System.Net.IPEndPoint	remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);
                //m_socWorker.Connect(remoteEndPoint);

                if (ClientSocket.Connected)
                {
                    this.ReceiveThread = new Thread(new ThreadStart(ReceiveData));
                    this.ReceiveThread.Start();
                }
            }
            catch (System.Net.Sockets.SocketException se)
            {
                richTextBox_ClientRx.AppendText(se.Message + "\n");
            }
        }

        int ClentSendData = 0;
        private void Button3_Click_4(object sender, EventArgs e)
        {
            try
            {
                String str = richTextBox_ClientTx.Text;
                Stream stm = ClientSocket.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);

                //byte[] sspData = SSP_Protocol.SSP_Protocol.SSPPacket_Encoder(SSP_Protocol.eMessegeType.TRACE, ba);

                // Console.WriteLine("Sending...");

                stm.Write(ba, 0, ba.Length);

                ClentSendData++;
                richTextBox_ClientTx.Text = "Send Data to Server " + ClentSendData;

                // byte[] bb = new byte[100];

            }
            catch
            {
                //MessageBox.Show (se.Message );
            }
        }

        private void Button43_Click_1(object sender, EventArgs e)
        {
            richTextBox_ClientTx.Text = "";
        }

        private void Button28_Click_2(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = ChartCntX;
        }

        private void TextBox_graph_XY_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_SendSerialPort_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        void SerialTerminalPrintHelp()
        {
            SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "F1 function - Help", New_Line = true, Show_Time = true);
        }

        private void TextBox_SendSerialPort_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        SerialTerminalPrintHelp();

                        break;

                    case Keys.F2:
                        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "F2 function reads all commands to history", New_Line = true, Show_Time = true);
                        break;

                    //case Keys.ControlKey:
                    //    SelfMonitorCommandsMode = !SelfMonitorCommandsMode;
                    //    if (SelfMonitorCommandsMode == true)
                    //    {
                    //        textBox_SendSerialPort.BackColor = SystemColors.Info;
                    //        groupBox_SendSerialOrMonitorCommands.BackColor = SystemColors.Info;
                    //        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "Change to Monitor commands mode", New_Line = true, Show_Time = true);
                    //    }
                    //    else
                    //    {
                    //        groupBox_SendSerialOrMonitorCommands.BackColor = default(Color);
                    //        textBox_SendSerialPort.BackColor = SystemColors.ActiveCaption;
                    //        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "Change to Send to serial port mode", New_Line = true, Show_Time = true);


                    //    }
                    //    break;


                    case Keys.Enter:
                        //if (SelfMonitorCommandsMode == true)
                        //{

                        //}
                        //else
                        //{
                        button_SendSerialPort.PerformClick();
                        //}

                        break;

                    case Keys.Up:
                        //SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, " History Index: " + HistoryIndex.ToString(), New_Line = true, Show_Time = false);
                        if (HistoryIndex > CommandsHistoy.Count - 1 || HistoryIndex < 0)
                        {
                            HistoryIndex = CommandsHistoy.Count;
                        }

                        //if(textBox_SendSerialPort.Text == string.Empty)
                        //{
                        //    HistoryIndex = CommandsHistoy.Count;
                        //}


                        if (HistoryIndex > 0)
                        {
                            HistoryIndex--;
                        }
                        textBox_SendSerialPort.Text = CommandsHistoy[HistoryIndex];
                        break;

                    case Keys.Down:

                        textBox_SendSerialPort.Text = CommandsHistoy[HistoryIndex];
                        if (HistoryIndex < CommandsHistoy.Count - 1)
                        {
                            HistoryIndex++;
                        }
                        break;

                    case Keys.Tab:
                        List<String> Strlist = new List<String>();
                        foreach (String str in CommandsHistoy)
                        {
                            if (str.StartsWith(textBox_SendSerialPort.Text))
                            {
                                Strlist.Add(str);
                            }
                        }

                        if (Strlist.Count > 1)
                        {
                            SerialPortLogger.LogMessage(Color.Black, Color.Yellow, "Total sub commands: " + Strlist.Count.ToString() + " ", New_Line = true, Show_Time = true);
                            foreach (String str in Strlist)
                            {
                                SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, str, New_Line = true, Show_Time = false);
                                if (HistoryIndex == Strlist.IndexOf(str))
                                {
                                    SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "<------", New_Line = false, Show_Time = false);
                                }
                            }
                        }
                        else
                            if (Strlist.Count == 1)
                        {
                            textBox_SendSerialPort.Text = Strlist[0];
                        }
                        break;

                    default:
                        HistoryIndex = CommandsHistoy.Count - 1;
                        break;
                }

                //  CommandsHistoy.SelectedIndex = HistoryIndex;
            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Blue, Color.White, ex.ToString(), New_Line = true, Show_Time = false);
            }
        }


        private void Button_OpenPort_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == false)
            {
                try
                {
                    button_OpenPort.BackColor = Color.Yellow;
                    label_SerialPortConnected.BackColor = Color.Yellow;

                    ComPortClosing = false;

                    CloseSerialPortTimer = false;



                    // Set the port's settings

                    serialPort.BaudRate = int.Parse(cmbBaudRate.Text);

                    if (cmbBaudRate.Items.Contains(cmbBaudRate.Text) == false)
                    {
                        cmbBaudRate.Items.Add(cmbBaudRate.Text);
                    }

                    serialPort.DataBits = int.Parse(cmbDataBits.Text);
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmb_StopBits.Text);
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                    serialPort.PortName = cmb_PortName.Text;




                    serialPort.WriteTimeout = 500;
                    serialPort.Open();

                    //ListenBox.Checked = false;
                    //groupBox_ServerSettings.Enabled = false;
                    IsTimedOutTimerEnabled = false;

                    SerialPortLogger.LogMessage(Color.Green, Color.LightGray,
                     " Serial port Opened with  " + " ,PortName = " + serialPort.PortName
                     + " ,BaudRate = " + serialPort.BaudRate +
                     " ,DataBits = " + serialPort.DataBits +
                     " ,StopBits = " + serialPort.StopBits +
                     " ,Parity = " + serialPort.Parity,
                     New_Line = true, Show_Time = true);

                    button_OpenPort.Text = "Close";
                    button_OpenPort.BackColor = Color.LightGreen;
                    label_SerialPortConnected.BackColor = Color.LightGreen;
                    label_SerialPortStatus.Text = cmb_PortName.Text + "   \n" + cmbBaudRate.Text;


                    cmbBaudRate.Enabled = false;
                    cmbDataBits.Enabled = false;
                    cmbParity.Enabled = false;
                    cmb_PortName.Enabled = false;
                    cmb_StopBits.Enabled = false;

                    Monitor.Properties.Settings.Default.Comport_BaudRate = cmbBaudRate.Text;
                    Monitor.Properties.Settings.Default.Comport_DataBits = cmbDataBits.Text;
                    Monitor.Properties.Settings.Default.Comport_StopBit = cmb_StopBits.Text;
                    Monitor.Properties.Settings.Default.Comport_Parity = cmbParity.Text;
                    Monitor.Properties.Settings.Default.Comport_Port = cmb_PortName.Text;

                    Monitor.Properties.Settings.Default.Save();


                }
                catch (Exception ex)
                {
                    //checkBox_ComportOpen.Checked = false;

                    //SerialException = true;

                    SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.Message.ToString(), New_Line = true, Show_Time = true);
                    return;
                }




            }
            else
            {

                ComPortClosing = true;
                button_OpenPort.BackColor = default;
                label_SerialPortConnected.BackColor = default;
                label_SerialPortStatus.Text = "";
                gbPortSettings.Enabled = false;
                //checkBox_ComportOpen.Enabled = false;
                button_OpenPort.Text = "Open";

                CloseSerialPortTimer = true;
                CloseSerialPortConter = 0;




                //groupBox_ServerSettings.Enabled = true;
            }
        }

        private void TabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        SerialTerminalPrintHelp();

                        break;

                    case Keys.F2:
                        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "F2 function reads all commands to history", New_Line = true, Show_Time = true);
                        break;

                    case Keys.Enter:
                        if (tabControl_Main.SelectedIndex == 3 && button_ClientConnect.BackColor == Color.LightGreen)
                        {
                            button_Send_Click(this, new EventArgs());
                        }
                        break;
                }


            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Black, Color.Red, ex.Message, New_Line = true, Show_Time = true);
            }

        }



        int ChartUpdateTime = 100;
        private void ComboBox_ChartUpdateTime_SelectedIndexChanged(object sender, EventArgs e)
        {

            int.TryParse(comboBox_ChartUpdateTime.Text, out int UpdateTime);
            ChartUpdateTime = UpdateTime;


        }

        private void CheckBox_SendHexdata_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SerialPortLogger_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_3(object sender, EventArgs e)
        {
            //Color TextColor = Color.FromName(textBox1.Text);
            //if(TextColor.ToArgb() == 0)
            //{
            //    textBox1.BackColor = default;
            //}
            //else
            //{
            //    textBox1.BackColor = TextColor;
            //}




        }

        private void TextBox_SendSerialPort_TextChanged_1(object sender, EventArgs e)
        {

        }



        private void Button_ClearRx_Click(object sender, EventArgs e)
        {
            richTextBox_ClientRx.Text = "";
        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {

        }

        void ClearRxTextBox()
        {
            textBox_RxClientPreamble.BackColor = default;
            textBox_RxClientPreamble.Text = "";

            textBox_RxClientOpcode.BackColor = default;
            textBox_RxClientOpcode.Text = "";

            textBox_RxClientData.BackColor = default;
            textBox_RxClientData.Text = "";

        }

        void ClearallTextBoxsTCPClient()
        {
            textBox_RxClientPreamble.BackColor = default;
            textBox_RxClientPreamble.Text = "";

            textBox_RxClientOpcode.BackColor = default;
            textBox_RxClientOpcode.Text = "";

            textBox_RxClientData.BackColor = default;
            textBox_RxClientData.Text = "";

            textBox_Preamble.BackColor = default;
            textBox_Preamble.Text = "";

            textBox_Opcode.BackColor = default;
            textBox_Opcode.Text = "";

            textBox_data.BackColor = default;
            textBox_data.Text = "";

            textBox_data.BackColor = default;
            textBox_data.Text = "";

            textBox_RxClientDataLength.BackColor = default;
            textBox_RxClientDataLength.Text = "";

            textBox_RxClientCheckSum.BackColor = default;
            textBox_RxClientCheckSum.Text = "";

            textBox_SentPreamble.Text = "";
            textBox_SentOpcode.Text = "";
            textBox_SentData.Text = "";
            textBox_SentDataLength.Text = "";
            textBox_SentChecksum.Text = "";
            textBox_SentPreamble.Text = "";

        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientSocket == null)
                {
                    return;
                }
                ClearRxTextBox();
                textBox_Preamble_TextChanged(null, null);
                textBox_Opcode_TextChanged(null, null);
                textBox_data_TextChanged(null, null);

                if (!(textBox_Preamble.BackColor == Color.LightGreen && textBox_Opcode.BackColor == Color.LightGreen && textBox_data.BackColor == Color.LightGreen))
                {
                    button_SendProtocolTCPIP.BackColor = Color.Red;
                    return;
                }
                else
                {
                    button_SendProtocolTCPIP.BackColor = Color.LightGreen;
                }

                List<byte> ListBytes = new List<byte>();
                // Kratos_Protocol KratusP = new Kratos_Protocol();

                Stream stm = ClientSocket.GetStream();

                if (stm != null)
                {
                    KratosProtocolFrame KratosFrame = new KratosProtocolFrame();
                    KratosFrame.Preamble = Regex.Replace(textBox_Preamble.Text, @"\s+", "");
                    KratosFrame.Opcode = Regex.Replace(textBox_Opcode.Text, @"\s+", "");
                    KratosFrame.Data = Regex.Replace(textBox_data.Text, @"\s+", "");
                    byte[] Result = Kratos_Protocol.EncodeKratusProtocol_Standard(KratosFrame);

                    KratosProtocolFrame SentFrame = Kratos_Protocol.DecodeKratusProtocol_Standard(Result);
                    //textBox_AllDataSent.Text = String.Format("Preamble: [{0}] Opcode: [{1}] Data : [{2}] Data length: [{3}] CheckSum: [{4}]",Ret.Preamble,Ret.Opcode,Ret.Data,Ret.DataLength,Ret.CheckSum);
                    textBox_SentPreamble.Text = SentFrame.Preamble;
                    textBox_SentOpcode.Text = SentFrame.Opcode;
                    textBox_SentData.Text = SentFrame.Data;
                    textBox_SentDataLength.Text = SentFrame.DataLength;
                    textBox_SentChecksum.Text = SentFrame.CheckSum;


                    stm.Write(Result, 0, Result.Length);
                }



            }
            catch
            {
                //MessageBox.Show (se.Message );
            }
        }

        private void textBox_Preamble_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_Preamble.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && textBox_Preamble.Text.Length <= 5)
            {
                textBox_Preamble.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_Preamble.BackColor = Color.Red;
            }
        }

        private void textBox_Opcode_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_Opcode.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && textBox_Opcode.Text.Length <= 5)
            {
                textBox_Opcode.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_Opcode.BackColor = Color.Red;
            }
        }

        private void textBox_data_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(textBox_data.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                textBox_data.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_data.BackColor = Color.Red;
            }
        }

        private void txtS1_Clear_Click(object sender, EventArgs e)
        {

        }

        private void textBox_RxClientData_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_SerialPort_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage_GenericFrame_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage_GenericFrame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void groupBox_clientTX_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void textBox_Preamble_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void textBox_Opcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void textBox_data_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        void SendThrouthSerialPort()
        {
            //button_Send_Click(null, null);

            if (serialPort.IsOpen == false)
            {
                SystemLogger.LogMessage(Color.Red, Color.White, "Serial Port is not open", true, true);
                return;
            }
            else
            {
                button_SendProtocolSerialPort_Click(null, null);
                //button_SendProtocolSerialPort.PerformClick();

                if (button_SendProtocolSerialPort.BackColor == Color.LightGreen)
                {
                    SystemLogger.LogMessage(Color.Purple, Color.LightYellow, "", New_Line = false, Show_Time = true);
                    SystemLogger.LogMessage(Color.Purple, Color.LightYellow, "Tx:>", false, false);
                    String str = String.Format("Preamble [{0}],Opcode [{1}],Data [{2}] ", textBox_Preamble.Text, textBox_Opcode.Text, textBox_data.Text);
                    SystemLogger.LogMessage(Color.Purple, Color.LightYellow, str, true, false);
                }
                else
                {
                    SystemLogger.LogMessage(Color.Red, Color.White, "Connection Problem or bad data", true, true);

                }
            }
        }

        void SendThrouthTCPIP()
        {
            button_Send_Click(null, null);

            if (button_SendProtocolTCPIP.BackColor == Color.LightGreen)
            {
                SystemLogger.LogMessage(Color.Purple, Color.LightYellow, "", New_Line = false, Show_Time = true);
                SystemLogger.LogMessage(Color.Purple, Color.LightYellow, "Tx:>", false, false);
                String str = String.Format("Preamble [{0}],Opcode [{1}],Data [{2}] ", textBox_Preamble.Text, textBox_Opcode.Text, textBox_data.Text);
                SystemLogger.LogMessage(Color.Purple, Color.LightYellow, str, true, false);
            }
            else
            {
                SystemLogger.LogMessage(Color.Orange, Color.White, "Connection Problem or bad data", true, true);

            }
        }
        void SendDataToSystem()
        {
            if (radioButton_SerialPort.Checked == true)
            {
                SendThrouthSerialPort();
            }

            if (radioButton_TCPIP.Checked == true)
            {
                SendThrouthTCPIP();

            }


        }

        private void button_GetSoftwareVersion_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "81";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "82";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "83";
            textBox_data.Text = "";

            SendDataToSystem();
        }





        private void button48_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "07 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "08 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "10 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }



        private void button52_Click(object sender, EventArgs e)
        {
            ClearallTextBoxsTCPClient();

        }

        private void button53_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "12 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void MainForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            CloseClentConnection();
            m_Exit = true;
            System.GC.Collect();
        }


        private void button56_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "14 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }


        private void button58_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "16 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }





















        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox_RxClientPreamble_TextChanged(object sender, EventArgs e)
        {

        }

        private void button59_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void button59_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Set register value to synthesizer L1
Command: 	0x1E
TX data: 	4 bytes – 32bit register value
TX frame: 	0x004D 0x0016 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0016 0x00000000 0x63


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button61_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"Help:
Set Tx AD936X data :
4 bytes 
byte – band type: 0x00 - L1, 0x01 - L2 
2 bytes – address 
1 bytes - data");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "37";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void textBox_SetSyestemState_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }





        private void button64_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"Description:   Set the system state: 
 Command: 0x28
 TX data: 1 byte – System state: 0x1 – CAL; 0x2 - Normal
 TX frame: 	0x004D 0x0028 0x00000001 + TX Data + checksum
 RX data: 	N.A
 RX frame: 0x004D 0x0028 0x00000000 0x75
");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }





        private void button67_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "11";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button66_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Set system output power in dBm by Band type
Command: 	0x2A
TX data: 	5 bytes
		1 byte – Band type: 0x0 – Both, 0x1 – L1; 0x2 – L2
		4 byte – System output power in dBm -117.0 ÷ -49.0, Float type
TX frame: 	0x004D 0x002A 0x00000005 + TX Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x002A 0x00000000 0x77
");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }





        private void textBox_SetTCXOTrim_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void button69_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "26";
            textBox_data.Text = textBox_SetPSUOutput.Text;

            SendDataToSystem();
        }

        private void tabControl_MiniAda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button71_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "70 00";
            //textBox_data.Text = textBox_ReadFPGARegister.Text;

            //SendDataToSystem();
        }

        private void textBox_ReadFPGARegister_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_ReadFPGARegister.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length <= 4)
            //{
            //    textBox_ReadFPGARegister.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_ReadFPGARegister.BackColor = Color.Red;
            //}
        }

        private void textBox_WriteFPGARegister_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_WriteFPGARegister.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 8)
            //{
            //    textBox_WriteFPGARegister.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_WriteFPGARegister.BackColor = Color.Red;
            //}
        }

        private void button70_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "71 00";
            //textBox_data.Text = textBox_WriteFPGARegister.Text;

            //SendDataToSystem();
        }

        void richTextBox_ClientRxPrintText(String i_string)
        {
            richTextBox_ClientRx.BeginInvoke(new EventHandler(delegate
            {
                richTextBox_ClientRx.AppendText(i_string);
                richTextBox_ClientRx.ScrollToCaret();
            }));
        }

        // int PingWaitTime = 0;
        private void button72_Click(object sender, EventArgs e)
        {

            try
            {
                String szIPSelected = textBox_ClientIP.Text;

                new Thread(() =>
                {
                    button_Ping.BackColor = Color.Yellow;

                    Thread.CurrentThread.IsBackground = true;
                    /* run your code here */
                    Ping myPing = new Ping();
                    PingReply reply = myPing.Send(szIPSelected);
                    if (reply != null)
                    {
                        //  PingWaitTime = 0;
                        // richTextBox_ClientRx.AppendText(String.Format("Failed to connect to [{0}] [{1}]\n", szIPSelected, szPort));
                        richTextBox_ClientRxPrintText("\n Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);

                        button_Ping.Text = "Ping";
                        if (reply.Status == IPStatus.Success)
                        {
                            button_Ping.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            button_Ping.BackColor = Color.Orange;
                        }
                    }
                }).Start();



                //System.Threading.Thread.Sleep(500);


                //Console.WriteLine(reply.ToString());

            }

            catch
            {
                richTextBox_ClientRx.AppendText("ERROR: You have Some TIMEOUT issue");
            }
        }

        private void textBox_StoreDatainFlash_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null)
            //{
            //    textBox_StoreDatainFlash.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_StoreDatainFlash.BackColor = Color.Red;
            //}
        }

        private void button72_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"4.2.2.12	Store data in Flash 
Description:   Store data in flash device 
Command: 	0x0030
TX data: 	8 bytes + N byte:
		4 bytes – address
		4 bytes – size of data to be stored
		N bytes – data to be stored
TX frame: 	0x0044 0x0030 + size + TX Data + CRC
RX data: 	N.A
RX frame: 	0x0044 0x0030 0x00000000 + CRC

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button72_Click_1(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "30 00";
            //textBox_data.Text = textBox_StoreDatainFlash.Text;

            //SendDataToSystem();
        }

        private void textBox_LoadDatainFlash_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_LoadDatainFlash.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 8)
            //{
            //    textBox_LoadDatainFlash.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_LoadDatainFlash.BackColor = Color.Red;
            //}
        }

        private void button73_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "31 00";
            //textBox_data.Text = textBox_LoadDatainFlash.Text;

            //SendDataToSystem();
        }

        private void button73_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"4.2.2.13	Load data from Flash by address 
Description:   Load data from flash by address
Command: 	0x0031
TX data: 	8 bytes:
4 byte – address
4 bytes – bytes to read. 
TX frame: 	0x0044 0x0031 0x00000008 + TX Data + CRC
RX data: 	N bytes – read data content 
RX frame: 	0x0044 0x0031 + size + RX Data + CRC

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button77_Click(object sender, EventArgs e)
        {
            //textBox_SetRXChannelGain_TextChanged(null, null); //Gil: a trick for send event of text changed
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "56 00";
            //textBox_data.Text = textBox_SetRXChannelGain.Text;

            //SendDataToSystem();
        }

        private void textBox_SetRXChannelGain_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SetRXChannelGain.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 2)
            //{
            //    textBox_SetRXChannelGain.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SetRXChannelGain.BackColor = Color.Red;
            //}
        }

        private void button76_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "57 00";
            //textBox_data.Text = textBox_GetRXChannelGain.Text;

            //SendDataToSystem();
        }

        private void textBox_GetRXChannelGain_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_GetRXChannelGain.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 1)
            //{
            //    textBox_GetRXChannelGain.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_GetRXChannelGain.BackColor = Color.Red;
            //}
        }


        private void textBox_SetDCA_TextChanged(object sender, EventArgs e)
        {

            //float DCA = 0; 
            //bool Succees =float.TryParse(textBox_SetDCA.Text, out DCA);
            //if (Succees == true)
            //{
            //    byte[] buffer = BitConverter.GetBytes(DCA);

            //    if (buffer != null)
            //    {
            //        textBox_SetDCAHex.Text = ByteArrayToString(buffer);
            //        textBox_SetDCAHex.BackColor = Color.LightGreen;
            //        textBox_SetDCA.BackColor = Color.LightGreen;
            //    }
            //    else
            //    {
            //        textBox_SetDCA.BackColor = Color.Red;
            //    }
            //}
            //else
            //{
            //    textBox_SetDCA.BackColor = Color.Red;
            //}
        }

        private void button75_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "58 00";
            //textBox_data.Text = textBox_SetDCAHex.Text;

            //SendDataToSystem();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "59 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void textBox_RxRFPLL_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_RxRFPLL.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 2)
            //{
            //    textBox_RxRFPLL.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_RxRFPLL.BackColor = Color.Red;
            //}
        }

        private void button78_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "5C 00";
            //textBox_data.Text = textBox_RxRFPLL.Text;

            //SendDataToSystem();
        }

        private void textBox_TxRFPLL_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_TxRFPLL.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 2)
            //{
            //    textBox_TxRFPLL.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_TxRFPLL.BackColor = Color.Red;
            //}
        }

        private void button79_Click(object sender, EventArgs e)
        {
            //textBox_TxRFPLL_TextChanged(null, null);

            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "5D 00";
            //textBox_data.Text = textBox_TxRFPLL.Text;

            //SendDataToSystem();
        }

        private void button78_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"Help:
4.2.3.7	AD9361 Rx RF PLL lock detect 

Description:   Get RF PLL lock detect
Command: 	0x5C
TX data: 	2 byte
1 byte – Xcvr ID: 0x0 ÷ 0x3
1 byte – RF Synth.: 0x1 = Tx; 0x0 = Rx	
TX frame: 	0x004D 0x005C 0x00000002 + TX Data + checksum
RX data: 	1 byte 
Lock detect: 0x1=Locked; 0x0 = Not locked
RX frame: 	0x004D 0x005C 0x00000001 + RX Data + checksum

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void textBox_SetGPIODir_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SetGPIODir.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length <= 2)
            //{
            //    textBox_SetGPIODir.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SetGPIODir.BackColor = Color.Red;
            //}
        }

        private void textBox_GetGPIODir_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_GetGPIODir.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length <= 1)
            //{
            //    textBox_GetGPIODir.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_GetGPIODir.BackColor = Color.Red;
            //}
        }

        private void textBox_SetGPIOVal_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SetGPIOVal.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length <= 2)
            //{
            //    textBox_SetGPIOVal.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SetGPIOVal.BackColor = Color.Red;
            //}
        }

        private void textBox_GetGPIOVal_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_GetGPIOVal.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length <= 1)
            //{
            //    textBox_GetGPIOVal.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_GetGPIOVal.BackColor = Color.Red;
            //}
        }

        private void button81_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "74 00";
            //textBox_data.Text = textBox_SetGPIODir.Text;

            //SendDataToSystem();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "75 00";
            //       textBox_data.Text = textBox_GetGPIODir.Text;

            SendDataToSystem();
        }

        private void button83_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "76 00";
            //   textBox_data.Text = textBox_SetGPIOVal.Text;

            SendDataToSystem();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "77 00";
            //textBox_data.Text = textBox_GetGPIOVal.Text;

            //SendDataToSystem();
        }

        private void textBox_RecordIQData_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_RecordIQData.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length <= 5)
            //{
            //    textBox_RecordIQData.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_RecordIQData.BackColor = Color.Red;
            //}
        }

        private void button_RecordIQData_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "80 00";
            //textBox_data.Text = textBox_RecordIQData.Text;

            //WaitforBufferFull = 6;

            //SendDataToSystem();
        }

        private void textBox_RecordIQSourceSealect_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_RecordIQSourceSealect.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 3)
            //{
            //    textBox_RecordIQSourceSealect.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_RecordIQSourceSealect.BackColor = Color.Red;
            //}
        }

        private void textBox_SetRxChannelState_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SetRxChannelState.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length <= 2)
            //{
            //    textBox_SetRxChannelState.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SetRxChannelState.BackColor = Color.Red;
            //}
        }

        private void button84_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "81 00";
            //textBox_data.Text = textBox_RecordIQSourceSealect.Text;

            //SendDataToSystem();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "87 00";
            //textBox_data.Text = textBox_SetRxChannelState.Text;

            //SendDataToSystem();

        }

        private void button86_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "D0 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void textBox_WriteQSPIFlashData_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void button88_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "27";
            textBox_data.Text = textBox_SetVVAAtt.Text;

            SendDataToSystem();
        }

        private void button87_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "33";
            textBox_data.Text = textBox_SetDCAWithBusMode.Text;

            SendDataToSystem();
        }

        private void textBox_ReadQSPIFlashData_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox_Erase4KsectorQSPI_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox_SetInternalLOFreq_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SetInternalLOFreq.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 9)
            //{
            //    textBox_SetInternalLOFreq.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SetInternalLOFreq.BackColor = Color.Red;
            //}
        }

        private void button91_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "5A 00";
            //textBox_data.Text = textBox_SetInternalLOFreq.Text;

            //SendDataToSystem();
        }

        private void textBox_GetInternalLOFreq_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_GetInternalLOFreq.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 1)
            //{
            //    textBox_GetInternalLOFreq.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_GetInternalLOFreq.BackColor = Color.Red;
            //}
        }

        private void button90_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "5B 00";
            //textBox_data.Text = textBox_GetInternalLOFreq.Text;

            //SendDataToSystem();
        }

        private void button_RecordIQData_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
                4.2.5.1 Record IQ data - day 1

Description: Initiate recording of I/ Q data and send the data on completion
Command: 	0x80
TX data: 	5 bytes
1 byte -Number of data blocks
4 byte -Number of samples
TX frame: 	0x004D 0x0080 0x00000005 + Tx Data + checksum
RX data: 	N bytes
Recorded samples
RX frame: 	0x004D 0x0080 + Length + RX Data + checksum

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }

        }

        private void button77_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Set the Gain to the RX channels
Command: 	0x56
TX data: 	2 bytes 
1 byte – band: 	0 – Broadcast; 1 – Band L1; 2 – Band L2
1 byte - Gain Value 1 ÷ 76 (dB)
TX frame: 	0x004D 0x0056 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0056 0x00000000 0xA3


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button76_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
                4.2.5.1 Record IQ data - day 1

Description: Initiate recording of I/ Q data and send the data on completion
Command: 	0x80
TX data: 	5 bytes
1 byte -Number of data blocks
4 byte -Number of samples
TX frame: 	0x004D 0x0080 0x00000005 + Tx Data + checksum
RX data: 	N bytes
Recorded samples
RX frame: 	0x004D 0x0080 + Length + RX Data + checksum

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button75_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Set DCA in the system
Command: 	0x58
TX data: 	4 bytes 
DCA value [Float]
TX frame: 	0x004D 0x0058 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0058 0x00000000 0xA5


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button91_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Set internal LO frequency in Hz
Command: 	0x5A
TX data: 	9 byte
		1 byte – Band type: 0x0 – L1; 0x1 – L2
		8 byte - Frequency [Hz]		
TX frame: 	0x004D 0x005A 0x00000009 + TX Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x005A 0x00000000 0xA7


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button69_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
4.2.2.11	Set TCXO Trim 
Description:   Change the frequency of the clock generation TCXO
Command: 	0x2F
TX data: 	4 byte – fraction of pulse per minute [-10:10]
TX frame: 	0x004D 0x002F 0x00000004+ TX Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x002F 0x00000000 0x7A


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button84_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Initiate recording of I/Q data and send the data on completion
Command: 	0x81
TX data: 	3 bytes 
1 byte – Record source :
 0x00 - Xcvr RX
 0x01 – Playback
 0x02 -  Counter
 0x03 -  Zero
		1 byte - Channel 1 data source:
0x00 – Catalina 1, channel 1
0x01 – Catalina 1, channel 2
0x02 -  Catalina 2, channel 1
0x03 -  Catalina 2 channel 2
0x04 – Catalina 3, channel 1
0x05 – Catalina 3, channel 2
0x06 -  Catalina 4, channel 1
0x07 -  Catalina 4 channel 2

1 byte - Channel 2 data source – same as Channel 1			  
		
TX frame: 	0x004D 0x0081 0x00000001 + Tx Data + checksum
RX data: 	N.A 
RX frame: 	0x004D 0x0081 0x00000000 0xCE

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button85_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Set the state to RX Channel
Command: 	0x87
TX data: 	2 bytes 
1 byte - Channel number: 0 ÷7
1 byte – State: 0x0 – Rx; 0x1 - CAL
TX frame: 	0x004D 0x0087 0x00000002 + Tx Data + checksum
RX data: 	N.A 
RX frame: 	0x004D 0x0087 0x00000000 0xD4


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void textBox_PlayIQData_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_PlayIQData.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null )
            //{
            //    textBox_PlayIQData.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_PlayIQData.BackColor = Color.Red;
            //}
        }

        private void button93_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "82 00";
            //textBox_data.Text = textBox_PlayIQData.Text;

            //SendDataToSystem();
        }

        private void textBox_RetriveIQData_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_RetriveIQData.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null)
            //{
            //    if (buffer.Length == 5)
            //    { 
            //        textBox_RetriveIQData.BackColor = Color.LightGreen;
            //    }
            //    else
            //    {
            //        textBox_RetriveIQData.BackColor = Color.Red;
            //    }
            //}
        }

        private void button92_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "84 00";
            //textBox_data.Text = textBox_RetriveIQData.Text;

            //SendDataToSystem();
        }

        private void button94_Click(object sender, EventArgs e)
        {
            // Generate a test signal,
            //  1 Vrms at 20,000 Hz
            //  Sampling Rate = 100,000 Hz
            //  DFT Length is 1000 Points
            double amplitude = 1.0;
            double frequency = 20000;
            UInt32 length = 1000;
            double samplingRate = 100000;
            double[] inputSignal = DSP.Generate.ToneSampling(amplitude, frequency, samplingRate, length);
            // Instantiate a new DFT
            DFT dft = new DFT();
            // Initialize the DFT
            // You only need to do this once or if you change any of the DFT parameters.
            dft.Initialize(length);
            // Call the DFT and get the scaled spectrum back
            Complex[] cSpectrum = dft.Execute(inputSignal);
            // Convert the complex spectrum to magnitude
            double[] lmSpectrum = DSP.ConvertComplex.ToMagnitude(cSpectrum);
            // Note: At this point, lmSpectrum is a 501 byte array that 
            // contains a properly scaled Spectrum from 0 - 50,000 Hz (1/2 the Sampling Frequency)
            // For plotting on an XY Scatter plot, generate the X Axis frequency Span
            double[] freqSpan = dft.FrequencySpan(samplingRate);
            // At this point a XY Scatter plot can be generated from,
            // X axis => freqSpan
            // Y axis => lmSpectrum
            // In this example, the maximum value of 1 Vrms is located at bin 200 (20,000 Hz)
            var series = new Series("Freq");
            var series2 = new Series("Time");
            listBox_Charts.Items.Add(series.Name);
            listBox_Charts.Items.Add(series2.Name);
            // Frist parameter is X-Axis and Second is Collection of Y- Axis
            series.Points.DataBindXY(freqSpan, lmSpectrum);

            for (int i = 0; i < inputSignal.Length / 10; i++)
            {
                series2.Points.AddXY(i, inputSignal[i]);
            }
            series2.ChartType = SeriesChartType.Line;
            chart1.Series.Add(series);
            chart1.Series.Add(series2);

        }

        private void button95_Click(object sender, EventArgs e)
        {
            // Same Input Signal as Example 1 - Except a fractional cycle for frequency.
            double amplitude = 1.0; double frequency = 20000.5;
            UInt32 length = 1000; UInt32 zeroPadding = 9000; // NOTE: Zero Padding
            double samplingRate = 100000;
            double[] inputSignal = DSPLib.DSP.Generate.ToneSampling(amplitude, frequency, samplingRate, length);
            // Apply window to the Input Data & calculate Scale Factor
            double[] wCoefs = DSP.Window.Coefficients(DSP.Window.Type.FTNI, length);
            double[] wInputData = DSP.Math.Multiply(inputSignal, wCoefs);
            double wScaleFactor = DSP.Window.ScaleFactor.Signal(wCoefs);
            // Instantiate & Initialize a new DFT
            DSPLib.DFT dft = new DSPLib.DFT();
            dft.Initialize(length, zeroPadding); // NOTE: Zero Padding
                                                 // Call the DFT and get the scaled spectrum back
            Complex[] cSpectrum = dft.Execute(wInputData);
            // Convert the complex spectrum to note: Magnitude Format
            double[] lmSpectrum = DSPLib.DSP.ConvertComplex.ToMagnitude(cSpectrum);
            // Properly scale the spectrum for the added window
            lmSpectrum = DSP.Math.Multiply(lmSpectrum, wScaleFactor);
            // For plotting on an XY Scatter plot generate the X Axis frequency Span
            double[] freqSpan = dft.FrequencySpan(samplingRate);
            // At this point a XY Scatter plot can be generated from,
            // X axis => freqSpan
            // Y axis => lmSpectrum

            var series = new Series("Freq 2");
            var series2 = new Series("Time 2");
            listBox_Charts.Items.Add(series.Name);
            listBox_Charts.Items.Add(series2.Name);
            // Frist parameter is X-Axis and Second is Collection of Y- Axis
            series.Points.DataBindXY(freqSpan, lmSpectrum);

            for (int i = 0; i < inputSignal.Length / 10; i++)
            {
                series2.Points.AddXY(i, inputSignal[i]);
            }
            series2.ChartType = SeriesChartType.Line;
            chart1.Series.Add(series);
            chart1.Series.Add(series2);
        }

        private void textBox_MinXAxis_TextChanged(object sender, EventArgs e)
        {
            long x = 0;
            if (long.TryParse(textBox_MinXAxis.Text, out x))
            {
                if (x < chart1.ChartAreas[0].AxisX.Maximum)
                {
                    // you know that the parsing attempt
                    // was successful
                    textBox_MinXAxis.BackColor = Color.LightGreen;
                    chart1.ChartAreas[0].AxisX.Minimum = x;
                }
                else
                {
                    textBox_MinXAxis.BackColor = Color.Orange;
                }
            }
            else
            {
                textBox_MinXAxis.BackColor = Color.Orange;
            }

        }

        private void textBox_MaxXAxis_TextChanged(object sender, EventArgs e)
        {
            long x = 0;
            if (long.TryParse(textBox_MaxXAxis.Text, out x))
            {
                if (x > chart1.ChartAreas[0].AxisX.Minimum)
                {
                    // you know that the parsing attempt
                    // was successful
                    textBox_MaxXAxis.BackColor = Color.LightGreen;
                    chart1.ChartAreas[0].AxisX.Maximum = x;
                }
                else
                {
                    textBox_MaxXAxis.BackColor = Color.Orange;
                }
            }
            else
            {
                textBox_MaxXAxis.BackColor = Color.Orange;
            }

        }
        int PlotGraphTimer = 0;
        private void button96_Click(object sender, EventArgs e)
        {
            PlotGraphTimer = 60;
            new Thread(() =>
            {
                CheckForMiniAdaDataFFT(MiniAdaParser);

            }).Start();

        }

        private void button97_Click(object sender, EventArgs e)
        {
            textBox_SystemStatus.Text = string.Empty;
            textBox_SystemStatus.BackColor = default;
        }

        private void comboBox_WindowsDSPLib_SelectedIndexChanged(object sender, EventArgs e)
        {
            //       string selectedWindowName = comboBox_WindowsDSPLib.SelectedValue.ToString();
            //  windowToApply = (DSPLib.DSP.Window.Type)Enum.Parse(typeof(DSPLib.DSP.Window.Type), selectedWindowName);
        }

        private void button98_Click(object sender, EventArgs e)
        {
            PlotGraphTimer = 120;
            new Thread(() =>
            {


                CheckForMiniAdaDataDFT(MiniAdaParser);

            }).Start();
        }

        private void button99_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisX.RoundAxisValues();
            // textBox_MinXAxis.Text = "3000"
            //chart1.ChartAreas[0].AxisX.Minimum = -30000;
            //  chart1.ChartAreas[0].AxisX.Maximum = 30000;
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void listBox_Charts_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listBox_Charts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listBox_Charts.SelectedItem != null)
            {
                chart1.Series.Remove(chart1.Series[listBox_Charts.SelectedItem.ToString()]);
                listBox_Charts.Items.Remove(listBox_Charts.SelectedItem);
                if (listBox_Charts.Items.Count > 0)
                {
                    listBox_Charts.SelectedIndex = 0;
                }

            }
        }

        private void textBox_RecordIQDataNumbers_TextChanged(object sender, EventArgs e)
        {
            // try
            // {
            //     string[] words = textBox_RecordIQDataNumbers.Text.Split(',');
            //     if (words.Length == 2)
            //     {
            //         byte.TryParse(words[0], out byte NumOfBlocks);
            //         int.TryParse(words[1], out int BlockSize);

            //         byte[] BSize = BitConverter.GetBytes(BlockSize);

            //         byte[] SendArray = new byte[5];
            //         SendArray[0] = NumOfBlocks;
            //         SendArray[1] = BSize[0];
            //         SendArray[2] = BSize[1];
            //         SendArray[3] = BSize[2];
            //         SendArray[4] = BSize[3];

            //         //textBox_RecordIQData.Text = ByteArrayToString(SendArray);
            //      //   textBox_RecordIQDataNumbers.BackColor = Color.LightGreen;
            //         //Array.Reverse(intBytes);
            //         //byte[] result = intBytes;
            //     }

            // }
            // catch(Exception ex)
            // {
            //     SystemLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), true, true);
            ////     textBox_RecordIQDataNumbers.BackColor = Color.Red;
            // }
        }

        private void button71_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
4.2.4.1	Read FPGA register 

Description:   Read register value from FPGA
Command: 	0x70
TX data: 	4 bytes 
address
TX frame: 	0x004D 0x0070 0x00000004 + Tx Data + checksum
RX data: 	4 bytes 
value
RX frame: 	0x004D 0x0056 0x00000004 + RX Data + checksum



");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button70_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
4.2.4.2	Write FPGA register 

Description:   Write register value to FPGA
Command: 	0x71
TX data: 	8 bytes 
4 byte - address
4 byte - value
TX frame: 	0x004D 0x0071 0x00000008 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0071 0x00000000 0Xbe


");

                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }


        }

        private void button60_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
4.2.2.2	Set Synthesizer L2 register - day 1

Description:   Set register value to synthesizer L2
Command: 	0x1F
TX data: 	4 bytes – 32bit register value
TX frame: 	0x004D 0x0017 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0017 0x00000000 0x64


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button62_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Get Tx AD9361 register
Command: 	0x21
TX data: 	3 byte
1 byte – Band type
2 bytes – Address
TX frame: 	0x004D 0x0021 0x00000003 + Tx Data + checksum
RX data: 	1 byte - data
RX frame: 	0x004D 0x0021 0x00000001 + Rx Date + checksum


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button63_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button65_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
4.2.2.7	Get system state - day 1

Description:   Get the system state: Cal/Normal
Command: 	0x29
TX data: 	N.A
TX frame: 	0x004D 0x0029 0x00000000 0x76
RX data: 	1 byte – System state: 0x1 – CAL; 0x2 – Normal
RX frame: 	0x004D 0x0029 0x00000000 + RX Data + checksum


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button67_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button68_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
4.2.2.10	Switch TCXO on/off 

Description:   Switch the TCXO on or off
Command: 	0x2E
TX data: 	1 byte – Switch 0x1 - On; 0x0 - Off
TX frame: 	0x004D 0x002E 0x00000001 + TX Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x002E 0x00000000 0x79


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button89_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button87_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button88_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
The textbox contain 4 files for the 4 Catalinas
Raw1 - Catalina 1
Raw2 - Catalina 2
Raw3 - Catalina 3
Raw4 - Catalina 4


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }


        void WriteFileToFlash(String i_FilePathName, string i_AD936X_ADDR)
        {
            String DataToSend = "";
            int DataLength = 0;
            byte CheckSumCalc = 0;
            //Gil: Catalina 1
            var lines = File.ReadAllLines(i_FilePathName);
            for (var i = 0; i < lines.Length; i++)
            {
                String line = lines[i];
                // Process line
                DataToSend += line;
                line = Regex.Replace(line, @"\s+", "");
                byte[] LineBytes = StringToByteArray(line);

                DataLength += LineBytes.Length;
                foreach (byte by in LineBytes)
                {
                    CheckSumCalc += by;
                }
            }
            //CheckSumCalc = CheckSumCalc % 256;
            //            % Header Structure:
            //% ver_major   1
            //% ver_minor   1
            //% ver_day     1
            //% ver_month   1
            //% ver_year    2
            //% Block_size  4
            //% CHK         1
            //% Dummy(0)   1

            // 1	0	17	3	230	7	16	11	0	0	219	0
            byte[] FlashHeader = CreateMiniAdaFlashHeader(0, 0, DateTime.Now, DataLength, CheckSumCalc);
            //byte[] FlashHeader = new byte[12];
            //FlashHeader[0] = 1;
            //FlashHeader[1] = 0;
            //FlashHeader[2] = (byte)DateTime.Now.Day;
            //FlashHeader[3] = (byte)DateTime.Now.Month;
            //FlashHeader[4] = (byte)(DateTime.Now.Year);
            //FlashHeader[5] = (byte)(DateTime.Now.Year >> 8);
            //FlashHeader[6] = (byte)(DataLength);
            //FlashHeader[7] = (byte)(DataLength >> 8);
            //FlashHeader[8] = (byte)(DataLength >> 16);
            //FlashHeader[9] = (byte)(DataLength >> 24);
            //FlashHeader[10] = (byte)(CheckSumCalc);
            //FlashHeader[11] = (byte)(0);

            DataLength += 12;
            string TotalframeDataToSend = ConvertByteArraytToString(FlashHeader) + DataToSend;
            byte[] temp = StringToByteArray(Regex.Replace(TotalframeDataToSend, @"\s+", ""));
            // Erase the Sector
            //textBox_EraseDataFromFlash.Text = i_AD936X_ADDR;
            //button_EraseFlash.PerformClick();
            //wait(2000);
            ////Store the Data in flash
            //byte[] intBytes = BitConverter.GetBytes(DataLength);
            //String NumOfBytesstr = ConvertByteArraytToString(intBytes);
            //textBox_StoreDatainFlash.Text = i_AD936X_ADDR /* + NumOfBytesstr */+ TotalframeDataToSend;
            //temp = StringToByteArray(Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", "") );
            //button_StoreDatainFlash.PerformClick();
        }
        private void button_WriteFilesToFlash_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[0], "00500000");
            //    wait(2000);
            //    WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[1], "00600000");
            //    wait(2000);
            //    WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[2], "00700000");
            //    wait(2000);
            //    WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[3], "00800000");
            //}
            //catch(Exception ex)
            //{
            //    SystemLogger.LogMessage(Color.Red, Color.White, ex.Message, true, false);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="milliseconds"></param>
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        private void textBox_EraseDataFromFlash_TextChanged(object sender, EventArgs e)
        {

            //string WithoutSpaces = Regex.Replace(textBox_EraseDataFromFlash.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 4)
            //{
            //    textBox_EraseDataFromFlash.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_EraseDataFromFlash.BackColor = Color.Red;
            //}
        }

        private void button100_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "32 00";
            //textBox_data.Text = textBox_EraseDataFromFlash.Text;

            //SendDataToSystem();
        }

        private void textBox_FilesToWriteForTheCatalinas_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
The textbox contain 4 files for the 4 Catalinas
Raw1 - Catalina 1
Raw2 - Catalina 2
Raw3 - Catalina 3
Raw4 - Catalina 4


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void textBox_SetRxChannelGainNumber_TextChanged(object sender, EventArgs e)
        {
            //int gain;
            //bool result = int.TryParse(textBox_SetRxChannelGainNumber.Text, out gain);
            //if (result == true)
            //{
            //    if (gain >= 0 && gain <= 76)
            //    {
            //        string hexValue = gain.ToString("X2");
            //        textBox_SetRXChannelGain.Text = textBox_SetRXChannelGain.Text.Substring(0,2) + " " + hexValue;
            //        textBox_SetRxChannelGainNumber.BackColor = Color.LightGreen;
            //    }
            //    else
            //    {
            //        textBox_SetRxChannelGainNumber.BackColor = Color.Red;
            //    }
            //}
            //else
            //{
            //    textBox_SetRxChannelGainNumber.BackColor = Color.Red;
            //}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_HexString"></param>
        /// <returns></returns>
        String ReverseHexStringLittleBigEndian(String i_HexString)
        {
            byte[] temp = StringToByteArray(i_HexString);
            temp = temp.Reverse().ToArray();
            return ConvertByteArraytToString(temp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_SetInternalLOFreqNumber_TextChanged(object sender, EventArgs e)
        {
            //long freq =0;
            //bool result = long.TryParse(textBox_SetInternalLOFreqNumber.Text, out freq);
            //if (result == true)
            //{
            //    if (freq >= 0 && freq <= 9999999999999)
            //    {
            //        string hexValue = freq.ToString("X16");

            //        textBox_SetInternalLOFreq.Text = textBox_SetInternalLOFreq.Text.Substring(0, 2) + " " + ReverseHexStringLittleBigEndian(hexValue);

            //        textBox_SetInternalLOFreqNumber.BackColor = Color.LightGreen;
            //    }
            //    else
            //    {
            //        textBox_SetInternalLOFreqNumber.BackColor = Color.Red;
            //    }
            //}
            //else
            //{
            //    textBox_SetInternalLOFreqNumber.BackColor = Color.Red;
            //}
        }

        private void button98_Click_1(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "31 00";
            //textBox_data.Text = textBox_LoadDatainFlash.Text;

            //SendDataToSystem();
        }

        private void button100_Click_1(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "30 00";
            //textBox_data.Text = textBox_StoreDatainFlash.Text;

            //SendDataToSystem();
        }

        private void button98_Click_2(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "31 00";
            //textBox_data.Text = textBox_LoadDatainFlash.Text;

            //SendDataToSystem();
        }

        private void button96_Click_1(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "32 00";
            // textBox_data.Text = textBox_EraseDataFromFlash.Text;

            SendDataToSystem();
        }

        String CATALINA_1_ADDRESS = "00500000";
        String CATALINA_2_ADDRESS = "00600000";
        String CATALINA_3_ADDRESS = "00700000";
        String CATALINA_4_ADDRESS = "00800000";
        private void button72_Click_2(object sender, EventArgs e)
        {
            try
            {
                WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[0], CATALINA_1_ADDRESS);
                wait(2000);
                progressBar_WriteToFlash.Value = 70;
                WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[1], CATALINA_2_ADDRESS);
                wait(2000);
                progressBar_WriteToFlash.Value = 80;
                WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[2], CATALINA_3_ADDRESS);
                wait(2000);
                progressBar_WriteToFlash.Value = 90;
                WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[3], CATALINA_4_ADDRESS);
            }
            catch (Exception ex)
            {
                SystemLogger.LogMessage(Color.Red, Color.White, ex.Message, true, false);
            }
        }

        private void textBox_FilesToWriteForTheCatalinas2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
The textbox contain 4 files for the 4 Catalinas
Raw1 - Catalina 1
Raw2 - Catalina 2
Raw3 - Catalina 3
Raw4 - Catalina 4


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void richTextBox_SyntisazerL2_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(richTextBox_SyntisazerL2.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                richTextBox_SyntisazerL2.BackColor = Color.LightGreen;
            }
            else
            {
                richTextBox_SyntisazerL2.BackColor = Color.Red;
            }
        }

        private void comboBox1_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox_SyntisazerL2.Text =
@"00618000
08008011
00004542
004004B3
00883034
00580005
";
            }
            else
            {
                richTextBox_SyntisazerL2.Text =
@"004B0000
08008011
00004542
004004B3
00883024
00580005
";
            }
        }

        private void richTextBox_SyntisazerL1_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(richTextBox_SyntisazerL1.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                richTextBox_SyntisazerL1.BackColor = Color.LightGreen;
            }
            else
            {
                richTextBox_SyntisazerL1.BackColor = Color.Red;
            }
        }

        private void textBox_StoreDatainFlash_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox_SyntisazerL1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
%synth_data_L1=[hex2dec('00C08000') ...   % Frequency change  % LO_L1=2*(1575.42)=2*1575.42 MHz. INT-N. Fpfd=16.368 MHz.
synth_data_L1=[hex2dec('00618000') ...   % Frequency change  % LO_L1=2*(1575.42+20.46)=2*1595.88 MHz. INT-N. Fpfd=16.368 MHz.
    hex2dec('08008011') ...              %
    hex2dec('00004542') ...              % charge pump change (4542 for 0.94mA , 4742 for 1.25mA) (for LO = 1595.88 SET 00004542 for LO = 1575.42 SET 00008542)
    hex2dec('004004B3') ...
    hex2dec('00883034') ...             %   Arie : hex2dec('0088303C') . 15dBm Required after Amplifier (34 instead 3C)

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void comboBox2_MouseDown(object sender, MouseEventArgs e)
        {

            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
            % mini_ada_write_sys_type(type)
%
% PURPOSE: To write system mini ADA TYPE to proper location in data FLASH.
% INPUT: type - '0' - ALL L1(A) , '1' - L1 & L2(B) , '2' - L1 - CAT4 & 1 ONLY(C).

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }


        }

        private void richTextBox_SyntisazerL2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
%synth_data_L1=[hex2dec('00C08000') ...   % Frequency change  % LO_L1=2*(1575.42)=2*1575.42 MHz. INT-N. Fpfd=16.368 MHz.
synth_data_L1=[hex2dec('00618000') ...   % Frequency change  % LO_L1=2*(1575.42+20.46)=2*1595.88 MHz. INT-N. Fpfd=16.368 MHz.
    hex2dec('08008011') ...              %
    hex2dec('00004542') ...              % charge pump change (4542 for 0.94mA , 4742 for 1.25mA) (for LO = 1595.88 SET 00004542 for LO = 1575.42 SET 00008542)
    hex2dec('004004B3') ...
    hex2dec('00883034') ...             %   Arie : hex2dec('0088303C') . 15dBm Required after Amplifier (34 instead 3C)

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }


        byte[] CreateMiniAdaFlashHeader(byte i_ver_major, byte i_ver_minor, DateTime i_ver_date, int i_block_size, byte i_checksum)
        {
            //CheckSumCalc = CheckSumCalc % 256;
            //            % Header Structure:
            //% ver_major   1
            //% ver_minor   1
            //% ver_day     1
            //% ver_month   1
            //% ver_year    2
            //% Block_size  4
            //% CHK         1
            //% Dummy(0)   1
            byte[] FlashHeader = new byte[12];
            FlashHeader[0] = i_ver_major;
            FlashHeader[1] = i_ver_minor;
            FlashHeader[2] = (byte)i_ver_date.Day;
            FlashHeader[3] = (byte)i_ver_date.Month;
            FlashHeader[4] = (byte)(i_ver_date.Year);
            FlashHeader[5] = (byte)(i_ver_date.Year >> 8);
            FlashHeader[6] = (byte)(i_block_size);
            FlashHeader[7] = (byte)(i_block_size >> 8);
            FlashHeader[8] = (byte)(i_block_size >> 16);
            FlashHeader[9] = (byte)(i_block_size >> 24);
            FlashHeader[10] = (byte)(i_checksum); // Check Sum is the same as the system type
            FlashHeader[11] = (byte)(0);

            return FlashHeader;
        }
        String SYSTEM_TYPE_ADDRESS = "00000000";
        private void button73_Click_1(object sender, EventArgs e)
        {
            String DataToSend = "";
            int DataLength = 1;
            //  byte CheckSumCalc = 0;
            byte SystemType = (byte)comboBox_SystemType.SelectedIndex;


            //            % mini_ada_write_sys_type(type)
            //%
            //% PURPOSE: To write system mini ADA TYPE to proper location in data FLASH.
            //% INPUT: type - '0' - ALL L1(A) , '1' - L1 & L2(B) , '2' - L1 - CAT4 & 1 ONLY(C).
            //Gil: Catalina 1

            //CheckSumCalc = CheckSumCalc % 256;
            //            % Header Structure:
            //% ver_major   1
            //% ver_minor   1
            //% ver_day     1
            //% ver_month   1
            //% ver_year    2
            //% Block_size  4
            //% CHK         1
            //% Dummy(0)   1

            // 1	0	17	3	230	7	16	11	0	0	219	0

            DataToSend = SystemType.ToString("X2");

            byte[] FlashHeader = CreateMiniAdaFlashHeader(0, 0, DateTime.Now, DataLength, (byte)SystemType);

            DataLength += 12;
            string TotalframeDataToSend = ConvertByteArraytToString(FlashHeader) + DataToSend;
            byte[] temp = StringToByteArray(Regex.Replace(TotalframeDataToSend, @"\s+", ""));
            // Erase the Sector
            //textBox_EraseDataFromFlash.Text = SYSTEM_TYPE_ADDRESS;
            //button_EraseFlash.PerformClick();
            //wait(2000);
            ////Store the Data in flash
            //byte[] intBytes = BitConverter.GetBytes(DataLength);
            //String NumOfBytesstr = ConvertByteArraytToString(intBytes);
            //textBox_StoreDatainFlash.Text = "00000000" /* + NumOfBytesstr */+ TotalframeDataToSend;
            //temp = StringToByteArray(Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", ""));
            //button_StoreDatainFlash.PerformClick();
        }

        String SYNTHESIZER_L1_ADDRESS = "00300000";
        private void button96_Click_2(object sender, EventArgs e)
        {
            //// 1	0	21	3	230	7	24	0	0	0	65	0	5	0	88	0	52	48	136	0	179	4	64	0	66	69	0	0	17	128	0	8	0	128	97	0
            //String DataToSend = "";
            //int DataLength = 0;
            //byte CheckSumCalc = 0;

            //var lines = richTextBox_SyntisazerL1.Lines;
            //for (var i = 0; i < lines.Length ; i++)
            //{
            //    String line = lines[i];
            //    // Process line


            //    line = Regex.Replace(line, @"\s+", "");

            //    byte[] LineBytes = StringToByteArray(line);
            //    LineBytes = LineBytes.Reverse().ToArray();
            //    DataToSend = ByteArrayToString(LineBytes) + DataToSend;// Gil: We need to make it in reverse order, Icompare it exactly to the Matlab code.

            //    DataLength += LineBytes.Length;
            //    foreach (byte by in LineBytes)
            //    {
            //        CheckSumCalc += by;
            //    }
            //}



            //byte[] FlashHeader = CreateMiniAdaFlashHeader(1, 0, DateTime.Now, DataLength, CheckSumCalc);


            //DataLength += 12;
            //string TotalframeDataToSend = ConvertByteArraytToString(FlashHeader) + DataToSend;
            //byte[] temp = StringToByteArray(Regex.Replace(TotalframeDataToSend, @"\s+", ""));
            //// Erase the Sector
            //textBox_EraseDataFromFlash.Text = SYNTHESIZER_L1_ADDRESS;
            //button_EraseFlash.PerformClick();
            //wait(2000);
            ////Store the Data in flash
            //byte[] intBytes = BitConverter.GetBytes(DataLength);
            //String NumOfBytesstr = ConvertByteArraytToString(intBytes);
            //textBox_StoreDatainFlash.Text = SYNTHESIZER_L1_ADDRESS /* + NumOfBytesstr */+ TotalframeDataToSend;
            //temp = StringToByteArray(Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", ""));
            //button_StoreDatainFlash.PerformClick();
        }

        String SYNTHESIZER_L2_ADDRESS = "00400000";
        private void button101_Click(object sender, EventArgs e)
        {
            String DataToSend = "";
            int DataLength = 0;
            byte CheckSumCalc = 0;

            var lines = richTextBox_SyntisazerL2.Lines;
            for (var i = 0; i < lines.Length; i++)
            {
                String line = lines[i];
                // Process line


                line = Regex.Replace(line, @"\s+", "");

                byte[] LineBytes = StringToByteArray(line);
                LineBytes = LineBytes.Reverse().ToArray();
                DataToSend = ByteArrayToString(LineBytes) + DataToSend;// Gil: We need to make it in reverse order, Icompare it exactly to the Matlab code.

                DataLength += LineBytes.Length;
                foreach (byte by in LineBytes)
                {
                    CheckSumCalc += by;
                }
            }



            byte[] FlashHeader = CreateMiniAdaFlashHeader(1, 0, DateTime.Now, DataLength, CheckSumCalc);


            DataLength += 12;
            string TotalframeDataToSend = ConvertByteArraytToString(FlashHeader) + DataToSend;
            byte[] temp = StringToByteArray(Regex.Replace(TotalframeDataToSend, @"\s+", ""));
            // Erase the Sector
            //      textBox_EraseDataFromFlash.Text = SYNTHESIZER_L2_ADDRESS;
            //      button_EraseFlash.PerformClick();
            wait(2000);
            //Store the Data in flash
            byte[] intBytes = BitConverter.GetBytes(DataLength);
            String NumOfBytesstr = ConvertByteArraytToString(intBytes);
            //    textBox_StoreDatainFlash.Text = SYNTHESIZER_L2_ADDRESS /* + NumOfBytesstr */+ TotalframeDataToSend;
            //       temp = StringToByteArray(Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", ""));
            //button_StoreDatainFlash.PerformClick();
        }

        private void button100_Click_2(object sender, EventArgs e)
        {
            button_WriteAllToFlash.BackColor = Color.Yellow;
            progressBar_WriteToFlash.Value = 0;
            SystemLogger.LogMessage(Color.Orange, Color.White, String.Format("Writing System Type to [{0}]", SYSTEM_TYPE_ADDRESS), true, true);
            button_WriteSystemType.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 20;
            SystemLogger.LogMessage(Color.Orange, Color.White, String.Format("Synthesizer L1 [{0}]", SYNTHESIZER_L1_ADDRESS), true, true);
            button_SynthL1.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 40;
            SystemLogger.LogMessage(Color.Orange, Color.White, String.Format("Synthesizer L2 [{0}]", SYNTHESIZER_L2_ADDRESS), true, true);
            button_SynthL2.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 60;
            SystemLogger.LogMessage(Color.Orange, Color.White, String.Format("Catalina 1-4 [{0}] [{1}] [{2}] [{3}]", CATALINA_1_ADDRESS, CATALINA_2_ADDRESS, CATALINA_3_ADDRESS, CATALINA_4_ADDRESS), true, true);
            button_WriteCatalinas.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 100;
            button_WriteAllToFlash.BackColor = default;
        }

        private void richTextBox_RegisterCommands_TextChanged(object sender, EventArgs e)
        {
            //    Monitor.Properties.Settings.Default.RegisterCommands = richTextBox_RegisterCommands.Text;
            //    Monitor.Properties.Settings.Default.Save();
        }

        private void button72_Click_3(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "8A 00";
            //textBox_data.Text = textBox_RecordingTests.Text;

            //SendDataToSystem();
        }

        private void textBox_RecordingTests_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_RecordingTests.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length ==1)
            //{
            //    textBox_RecordingTests.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_RecordingTests.BackColor = Color.Red;
            //}
        }

        private void button72_MouseDown_1(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Select recording test
Command: 	0x8A
TX data: 	1 byte - Select test:
0x0 - Record the RX channel state RX/CAL (CAL_TX_CTRL signal) 
along with 1 of the Rx channel (1 from 1…8) at the same time
0x1 - Record the bit(Rx/CAL) that represent the end of command.
along with 1 of the Rx channel (1 from 1…8) at the same time
0x2 - Record the bit that represent the end of command change Syn. Freq.  
        and record the bit Syn Lock at the same time.

Note: “at the same time” – meaning when saving the samples there is time alignment between bot sampled signals

TX frame: 	0x004D 0x008A 0x00000001 + Tx Data + checksum
RX data: 	1 byte – Test result: 0x0 – Ok, 0x1 - Failed
RX frame: 	0x004D 0x008A 0x00000001 + RX Data + checksum



");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button73_Click_2(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "90 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void textBox_GetMonitoredData_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_GetMonitoredData.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 1)
            //{
            //    textBox_GetMonitoredData.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_GetMonitoredData.BackColor = Color.Red;
            //}
        }

        private void button94_Click_1(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "91 00";
            //textBox_data.Text = textBox_GetMonitoredData.Text;

            //SendDataToSystem();
        }

        private void button94_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"

Description:   Get a block of next monitored data from selected group
Command: 	0x91
TX data: 	1 byte - Monitored group enum: 	0x0 - Group Temperature
							0x1 - Group Voltage
							0x2 - Group Current
							0x3 - Group Flags
TX frame: 	0x004D 0x0091 0x00000001 + TX Data + checksum
RX data: 	64 byte
		2 byte - The ID of this object Discrete 
1 byte - Current value
1 byte - Discrete is Alarm. Boolean level (1/0) for generating an Alarm
4 byte - Minimum value allowed
4 byte - Maximum value allowed
4 byte - Analog Current value
40 byte - The Name of this object, String type.
4byte - Alarm type, eStatus enum
4byte - Alarm rules (Min-Only, Max-Only, Min-Max, No), eStatus enum
RX frame: 	0x004D 0x0091 0x00000040 + RX Data + checksum
Note: eStatus enum 
	0x0 - NO - Alarm is not generated/Current reading is in range. Ok!
0x1 - HIGH - Alarm when value to high / Current reading is too high.
0x2 - LOW - Alarm when value to low / Current reading is too low.
0x3 - MIN_MAX- Alarm when value to high or to low / not applicable for reading
 


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button95_Click_1(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "92 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button96_Click_3(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "93 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button96_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                String str = String.Format(@"
Description:   Get a block of next monitored data having alarm 
Command: 	0x93
TX data: 	N.A
TX frame: 	0x004D 0x0093 0x00000001 + TX Data + checksum
RX data: 	64 byte
		2 byte - The ID of this object Discrete 
1 byte - Current value
1 byte - Discrete is Alarm. Boolean level (1/0) for generating an Alarm
4 byte - Minimum value allowed
4 byte - Maximum value allowed
4 byte - Analog Current value
40 byte - The Name of this object, String type.
4byte - Alarm type, eStatus enum
4byte - Alarm rules (Min-Only, Max-Only, Min-Max, No), eStatus enum
RX frame: 	0x004D 0x0093 0x00000040 + RX Data + checksum
Note: eStatus enum 
	0x0 - NO - Alarm is not generated/Current reading is in range. Ok!
0x1 - HIGH - Alarm when value to high / Current reading is too high.
0x2 - LOW - Alarm when value to low / Current reading is too low.
0x3 - MIN_MAX- Alarm when value to high or to low / not applicable for reading


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void textBox_SetAlarmSimulatorBlock_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SetAlarmSimulatorBlock.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null )
            //{
            //    textBox_SetAlarmSimulatorBlock.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SetAlarmSimulatorBlock.BackColor = Color.Red;
            //}
        }

        private void button100_Click_3(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "94 00";
            //textBox_data.Text = textBox_SetAlarmSimulatorBlock.Text;

            //SendDataToSystem();
        }

        private void textBox_MonitorTask_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_MonitorTask.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 1)
            //{
            //    textBox_MonitorTask.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_MonitorTask.BackColor = Color.Red;
            //}
        }

        private void button101_Click_1(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "95 00";
            //textBox_data.Text = textBox_MonitorTask.Text;

            //SendDataToSystem();
        }

        private void textBox_SetLOFreq_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SetLOFreq.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 5)
            //{
            //    textBox_SetLOFreq.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SetLOFreq.BackColor = Color.Red;
            //}
        }

        private void button102_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "99 00";
            //textBox_data.Text = textBox_SetLOFreq.Text;

            //SendDataToSystem();

        }

        private void textBox_SetLOFreqStep_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SetLOFreqStep.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 9)
            //{
            //    textBox_SetLOFreqStep.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SetLOFreqStep.BackColor = Color.Red;
            //}
        }

        private void button103_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "9A 00";
            //textBox_data.Text = textBox_SetLOFreqStep.Text;

            //SendDataToSystem();

        }

        private void button104_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "9B 00";
            //textBox_data.Text = textBox_GetLOStateFreqMode.Text;

            //SendDataToSystem();

        }

        private void textBox_GetLOStateFreqMode_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_GetLOStateFreqMode.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 1)
            //{
            //    textBox_GetLOStateFreqMode.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_GetLOStateFreqMode.BackColor = Color.Red;
            //}
        }

        private void button105_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "9C 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void textBox_SelectLOSource_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SelectLOSource.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 1)
            //{
            //    textBox_SelectLOSource.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SelectLOSource.BackColor = Color.Red;
            //}
        }

        private void button107_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "9D 00";
            //textBox_data.Text = textBox_SelectLOSource.Text;

            //SendDataToSystem();
        }

        private void button106_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "9E 00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button48_Click_1(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button_SendProtocolSerialPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen == false)
                {
                    return;
                }
                ClearRxTextBox();
                textBox_Preamble_TextChanged(null, null);
                textBox_Opcode_TextChanged(null, null);
                textBox_data_TextChanged(null, null);

                if (!(textBox_Preamble.BackColor == Color.LightGreen && textBox_Opcode.BackColor == Color.LightGreen && textBox_data.BackColor == Color.LightGreen))
                {
                    button_SendProtocolSerialPort.BackColor = Color.Red;
                    return;
                }
                else
                {
                    button_SendProtocolSerialPort.BackColor = Color.LightGreen;
                }

                List<byte> ListBytes = new List<byte>();
                // Kratos_Protocol KratusP = new Kratos_Protocol();


                KratosProtocolFrame KratosFrame = new KratosProtocolFrame();
                KratosFrame.Preamble = Regex.Replace(textBox_Preamble.Text, @"\s+", "");
                KratosFrame.Opcode = Regex.Replace(textBox_Opcode.Text, @"\s+", "");
                KratosFrame.Data = Regex.Replace(textBox_data.Text, @"\s+", "");
                byte[] Result = Kratos_Protocol.EncodeKratusProtocol_Standard(KratosFrame);

                KratosProtocolFrame SentFrame = Kratos_Protocol.DecodeKratusProtocol_Standard(Result);
                //textBox_AllDataSent.Text = String.Format("Preamble: [{0}] Opcode: [{1}] Data : [{2}] Data length: [{3}] CheckSum: [{4}]",Ret.Preamble,Ret.Opcode,Ret.Data,Ret.DataLength,Ret.CheckSum);
                textBox_SentPreamble.Text = SentFrame.Preamble;
                textBox_SentOpcode.Text = SentFrame.Opcode;
                textBox_SentData.Text = SentFrame.Data;
                textBox_SentDataLength.Text = SentFrame.DataLength;
                textBox_SentChecksum.Text = SentFrame.CheckSum;

                textBox_SendSerialPort.Text = ConvertByteArraytToString(Result);

                Button2_Click_1(null, null);
                // button_SendSerialPort.PerformClick();
                //stm.Write(Result, 0, Result.Length);




            }
            catch
            {
                //MessageBox.Show (se.Message );
            }
        }

        private void button108_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "80";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "00";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "01";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "02";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button62_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "03";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "04";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button68_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "25";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button89_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "35";
            textBox_data.Text = textBox_SetSystemMode.Text;

            SendDataToSystem();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "36";
            textBox_data.Text = textBox_SetADCMode.Text;

            SendDataToSystem();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "38";
            textBox_data.Text = textBox17.Text;

            SendDataToSystem();
        }

        private void button118_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "39";
            textBox_data.Text = textBox_ControlCal.Text;

            SendDataToSystem();
        }

        private void button119_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "40";
            textBox_data.Text = textBox19.Text;

            SendDataToSystem();
        }

        private void button120_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "70";
            textBox_data.Text = textBox20.Text;

            SendDataToSystem();
        }

        private void button121_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "71";
            textBox_data.Text = textBox21.Text;

            SendDataToSystem();
        }

        private void button122_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "72";
            textBox_data.Text = textBox22.Text;

            SendDataToSystem();
        }

        private void button48_Click_2(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "85";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "90";
            textBox_data.Text = textBox_TxInhibit.Text;

            SendDataToSystem();
        }

        private void button49_Click_1(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "91";
            textBox_data.Text = textBox3.Text;

            SendDataToSystem();
        }

        private void button50_Click_1(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "92";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "93";
            textBox_data.Text = textBox4.Text;

            SendDataToSystem();
        }

        private void button53_Click_1(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "94";
            textBox_data.Text = textBox5.Text;

            SendDataToSystem();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "95";
            textBox_data.Text = textBox6.Text;

            SendDataToSystem();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "96";
            textBox_data.Text = textBox7.Text;

            SendDataToSystem();
        }

        private void button56_Click_1(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "97";
            textBox_data.Text = textBox8.Text;

            SendDataToSystem();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "98";
            textBox_data.Text = textBox_PulseGenParms.Text;

            SendDataToSystem();
        }

        private void button58_Click_1(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "99";
            textBox_data.Text = textBox10.Text;

            SendDataToSystem();
        }

        private void button110_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "9A";
            textBox_data.Text = textBox_RFGenParms.Text;

            SendDataToSystem();
        }

        private void button111_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "9B";
            textBox_data.Text = textBox12.Text;

            SendDataToSystem();
        }

        private void button112_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "9C";
            textBox_data.Text = textBox13.Text;

            SendDataToSystem();
        }

        private void button113_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "9D";
            textBox_data.Text = textBox14.Text;

            SendDataToSystem();
        }

        private void button114_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "9E";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button115_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "9F";
            textBox_data.Text = textBox15.Text;

            SendDataToSystem();
        }

        private void button116_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "A0";
            textBox_data.Text = "";

            SendDataToSystem();
        }

        private void button117_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "A1";
            textBox_data.Text = textBox16.Text;

            SendDataToSystem();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox_ControlCal_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void textBox56_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void textBox57_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox59_TextChanged(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {

        }

        String[] GetDataStringFromTextbox()
        {
            return richTextBox_SSPA.Text.Split(new string[] { "<<", ">>" }, StringSplitOptions.RemoveEmptyEntries);
        }
        private async void button70_Click_1(object sender, EventArgs e)
        {
            GlobalSystemResultReceived = "";


            button61_Click(null, null);
            await Task.Delay(500);
            button62_Click(null, null);
            await Task.Delay(500);




            String[] TextDataRecieved = GlobalSystemResultReceived.Split(new string[] { "<<", ">>" }, StringSplitOptions.None);


            if (TextDataRecieved.Length < 3)
            {
                return;
            }
            textBox1.Text = TextDataRecieved[1];
            textBox2.Text = TextDataRecieved[3];

        }







        private async void button31_Click_1(object sender, EventArgs e)
        {
            try
            {
                GlobalSystemResultReceived = "";



                button108_Click(null, null);
                await Task.Delay(500);
                button48_Click_2(null, null);
                await Task.Delay(500);
                button46_Click(null, null);
                await Task.Delay(500);
                button45_Click(null, null);
                await Task.Delay(500);


                String[] TextDataRecieved = GlobalSystemResultReceived.Split(new string[] { "<<", ">>" }, StringSplitOptions.None);



                textBox_SimulatorID.Text = TextDataRecieved[1];
                textBox_SimulatorSN.Text = TextDataRecieved[3];
                textBox_SimulatorHWVersion.Text = TextDataRecieved[5];
                textBox_SimulatorFWVersion.Text = TextDataRecieved[7];
            }
            catch(Exception ex)
            {
                textBox_SystemStatus.BackColor = Color.DarkOrange;
                textBox_SystemStatus.Text = ex.Message;
                return;
            }
        }

        void ClearVersions()
        {
            textBox_SimulatorHWVersion.Text = "";
            textBox_SimulatorFWVersion.Text = "";
            textBox_SimulatorSN.Text = "";
            textBox_SimulatorID.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button75_Click_1(object sender, EventArgs e)
        {
            ClearVersions();
        }

        private void button32_Click_1(object sender, EventArgs e)
        {
            int temp = 0;

            string hexValue = "";
            if (Int32.TryParse(textBox_RFWidth.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (Int32.TryParse(textBox_RFPeriod.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (Int32.TryParse(textBox_RFDelay.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            textBox_RFGenParms.Text = hexValue;

            button110_Click(null, null);

        }

        private void button42_Click_2(object sender, EventArgs e)
        {
            int temp = 0;

            string hexValue = "";
            if (Int32.TryParse(textBox_PulseWidth.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (Int32.TryParse(textBox_PulsePeriod.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (Int32.TryParse(textBox_PulseDelay.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            textBox_TxInhibit.Text = hexValue;

            button47_Click(null, null);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            int temp = 0;

            string hexValue = "";
            if (Int32.TryParse(textBox_PulseWidth2.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (Int32.TryParse(textBox_PulsePeriod2.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (Int32.TryParse(textBox_PulseDelay2.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            textBox_PulseGenParms.Text = hexValue;

            button57_Click(null, null);
        }

        private async void button72_Click_4(object sender, EventArgs e)
        {

            GlobalSystemResultReceived = "";
            button67_Click(null, null);
            await Task.Delay(500);
            button68_Click(null, null);
            await Task.Delay(500);
            button50_Click_1(null, null);
            await Task.Delay(500);
            String[] TextDataRecieved = GlobalSystemResultReceived.Split(new string[] { "<<", ">>" }, StringSplitOptions.RemoveEmptyEntries);

            if (TextDataRecieved.Length < 50)
            {
                return;
            }

            textBox_StatusUUT1.Text = TextDataRecieved[1];
            textBox_StatusUUT2.Text = TextDataRecieved[3];
            textBox_StatusUUT3.Text = TextDataRecieved[5];
            textBox_StatusUUT4.Text = TextDataRecieved[7];
            textBox_StatusUUT5.Text = TextDataRecieved[9];
            textBox_StatusUUT6.Text = TextDataRecieved[11];
            textBox_StatusUUT7.Text = TextDataRecieved[13];
            textBox_StatusUUT8.Text = TextDataRecieved[15];
            textBox_StatusUUT9.Text = TextDataRecieved[17];
            textBox_StatusUUT10.Text = TextDataRecieved[19];
            textBox_StatusUUT11.Text = TextDataRecieved[21];
            textBox_StatusUUT12.Text = TextDataRecieved[23];
            textBox_StatusUUT13.Text = TextDataRecieved[25];
            textBox_StatusUUT14.Text = TextDataRecieved[27];
            textBox_StatusUUT15.Text = TextDataRecieved[29];
            textBox_StatusUUT16.Text = TextDataRecieved[31];
            textBox_StatusUUT17.Text = TextDataRecieved[33];
            textBox_StatusUUT18.Text = TextDataRecieved[35];
            textBox_StatusUUT19.Text = TextDataRecieved[37];
            textBox_StatusUUT20.Text = TextDataRecieved[39];
            textBox_StatusUUT21.Text = TextDataRecieved[41];
            textBox_StatusUUT22.Text = TextDataRecieved[43];
            textBox_StatusUUT23.Text = TextDataRecieved[45];
            textBox_StatusUUT24.Text = TextDataRecieved[47];
            textBox_StatusUUT25.Text = TextDataRecieved[49];
            textBox_StatusUUT26.Text = TextDataRecieved[51];




        }


        void SetPSUValues()
        {
            int temp = 0;

            string hexValue = "";
            if (Int32.TryParse(textBox24.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (Int32.TryParse(textBox25.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (Int32.TryParse(textBox26.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (Int32.TryParse(textBox27.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            textBox_SetPSUOutput.Text = hexValue;
            button69_Click(null, null);
            //textBox24.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SetPSUValues();


            }
        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetPSUValues();
            }
        }

        private void textBox26_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetPSUValues();
            }
        }

        private void textBox27_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetPSUValues();
            }
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox31_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int temp = 0;

                string hexValue = "";
                if (Int32.TryParse(textBox31.Text, out temp))
                {
                    hexValue += temp.ToString("X2");
                }

                textBox_SetVVAAtt.Text = hexValue;
                button88_Click(null, null);
            }
        }

        void SetDCAValues()
        {
            int temp = 0;

            string hexValue = "";
            if (Int32.TryParse(textBox29.Text, out temp))
            {
                hexValue += temp.ToString("X2");
            }

            if (Int32.TryParse(textBox30.Text, out temp))
            {
                hexValue += temp.ToString("X2");
            }

            textBox_SetDCAWithBusMode.Text = hexValue;
            button87_Click(null, null);
        }
        private void textBox30_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetDCAValues();
            }
        }

        private void textBox29_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //textBox24.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                button69_Click(null, null);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Checkbx = (CheckBox)sender;
            if (Checkbx.Checked == true)
            {
                textBox12.Text = "01";

                Checkbx.BackColor = Color.LightGreen;
            }
            else
            {
                textBox12.Text = "00";
                Checkbx.BackColor = default;
            }

            button111_Click(null, null);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Checkbx = (CheckBox)sender;
            if (Checkbx.Checked == true)
            {
                textBox3.Text = "01";

                Checkbx.BackColor = Color.LightGreen;
            }
            else
            {
                textBox3.Text = "00";
                Checkbx.BackColor = default;
            }

            button49_Click_1(null, null);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Checkbx = (CheckBox)sender;
            if (Checkbx.Checked == true)
            {
                textBox10.Text = "01";

                Checkbx.BackColor = Color.LightGreen;
            }
            else
            {
                textBox10.Text = "00";
                Checkbx.BackColor = default;
            }

            button58_Click_1(null, null);
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckBox Checkbx = (CheckBox)sender;
            if (Checkbx.Checked == true)
            {
                textBox15.Text = "01";

                Checkbx.BackColor = Color.LightGreen;
            }
            else
            {
                textBox15.Text = "00";
                Checkbx.BackColor = default;
            }

            button115_Click(null, null);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Checkbx = (CheckBox)sender;
            if (Checkbx.Checked == true)
            {
                textBox13.Text = "01";

                Checkbx.BackColor = Color.LightGreen;
            }
            else
            {
                textBox13.Text = "00";
                Checkbx.BackColor = default;
            }

            button112_Click(null, null);
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckBox Checkbx = (CheckBox)sender;
            if (Checkbx.Checked == true)
            {
                textBox16.Text = "01";

                Checkbx.BackColor = Color.LightGreen;
            }
            else
            {
                textBox16.Text = "00";
                Checkbx.BackColor = default;
            }

            button117_Click(null, null);
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckBox Checkbx = (CheckBox)sender;
            if (Checkbx.Checked == true)
            {
                textBox4.Text = "01";

                Checkbx.BackColor = Color.LightGreen;
            }
            else
            {
                textBox4.Text = "00";
                Checkbx.BackColor = default;
            }

            button51_Click(null, null);
        }

        private void button73_Click_3(object sender, EventArgs e)
        {
            button53_Click_1(null, null);
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox84_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int temp = 0;

                string hexValue = "";
                if (Int32.TryParse(textBox84.Text, out temp))
                {
                    hexValue += temp.ToString("X2");
                }

                textBox7.Text = hexValue;
                button55_Click(null, null);
            }
        }

        private void textBox83_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int temp = 0;

                string hexValue = "";
                if (Int32.TryParse(textBox83.Text, out temp))
                {
                    hexValue += temp.ToString("X2");
                }

                textBox6.Text = hexValue;
                button54_Click(null, null);
            }
        }

        private void textBox82_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int temp = 0;

                string hexValue = "";
                if (Int32.TryParse(textBox82.Text, out temp))
                {
                    hexValue += temp.ToString("X2");
                }

                textBox8.Text = hexValue;
                button56_Click_1(null, null);
            }
        }

        private void textBox85_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int temp = 0;

                string hexValue = "";
                if (Int32.TryParse(textBox85.Text, out temp))
                {
                    hexValue += temp.ToString("X2");
                }

                textBox8.Text = hexValue;
                button116_Click(null, null);
            }
        }

        private void button57_Click_1(object sender, EventArgs e)
        {
            ClearVersions();
        }

        private void ComboBox_SerialPortHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_SerialPortHistory.SelectedItem != null )
            //{
            //    if (textBox_SendSerialPort.Text != comboBox_SerialPortHistory.SelectedItem.ToString())
            //    {
            //        textBox_SendSerialPort.Text = comboBox_SerialPortHistory.SelectedItem.ToString();
            //    }
            //}
        }

        private void ListBox_Charts_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < listBox_Charts.Items.Count; i++)
            {

                if (listBox_Charts.GetSelected(i) == true)
                {
                    chart1.Series[i].Enabled = true;

                    textBox_graph_XY.Invoke(new EventHandler(delegate
                    {
                        textBox_graph_XY.Text = chart1.Series[i].LegendToolTip;

                    }));
                }
                else
                {
                    chart1.Series[i].Enabled = false;
                }
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        void ResetTimer()
        {
            textBox_TimerTime.Text = TimerMemory.ToString();
            textBox_SetTimerTime.Text = "0";
            IsTimerRunning = false;
            button_StartStopTimer.BackColor = default;
        }

        private void Button_ResetTimer_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        //private void comboBox_SendThrough_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    switch (comboBox_SendThrough.SelectedIndex)
        //    {
        //        case (int)eComSource.GPRS:
        //            groupBox_ServerSettings.Visible = true;
        //            gbPortSettings.Visible = false;
        //            groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SerialPort:
        //            groupBox_ServerSettings.Visible = false;
        //            gbPortSettings.Visible = true;
        //            groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SMS:
        //            groupBox_ServerSettings.Visible = false;
        //            gbPortSettings.Visible = true;
        //            groupBox_PhoneNumber.Visible = true;
        //            break;
        //    }
        //}

        //private bool m_EchoResponse = false;
        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked == true)
        //    {
        //        m_EchoResponse = true;
        //    }
        //    else
        //    {
        //        m_EchoResponse = false;
        //    }
        //}


        /*Modem Registration Status = [1], RSSI = [31], Modem GPRS = [0],
         * Temperature Level = [0],Board Temperature = [31] , Sim Status = [1] ,
         * OperatorName = ["Cellcom"], Modem Voltage = [3.924000], Modem SIMIdentificationNumber = [899720201108447424] ,
         * ModemIMEI = [354869050098417], SimIMSI = [425020110844742], ModemVersion = [Cinterion,BGS2-W,REVISION 02.000,A-REVISION 01.000.08,OK,], 
         * ModemConnectionStatus = [], ModemServiceStatus = [], ModemServiceStatus2 = [], ModemErrorServiceStatus = [], ModemEUpdateCounter = [4],*/

        class ModemStatus
        {
            public bool Valid = false;
            public string ModemRegistrationStatus = "";
            public string RSSI = "";
            public string SIMStatus = "";
            public string Operator = "";
            public string ModemVoltage = "";
            public string SIMIdentificationNumber = "";
            public string ModemIMEI = "";
            public string SimIMSI = "";
            public string ModemVersion = "";
            public string ModemEUpdateCounter = "";

            public ModemStatus(ref string i_ModemStatus)
            {
                if (i_ModemStatus.Contains("Modem Registration Status") &&
                    i_ModemStatus.Contains("RSSI") &&
                    i_ModemStatus.Contains("SIMIdentificationNumber") &&
                    i_ModemStatus.Contains("SMS_ONLY") &&
                    i_ModemStatus.Contains("SIMIdentificationNumber"))
                {
                    i_ModemStatus = i_ModemStatus.Substring(i_ModemStatus.LastIndexOf("SMS_ONLY"));
                    string[] values = i_ModemStatus.Split('[', ']');
                    if (values.Length >= 33)
                    {
                        this.ModemRegistrationStatus = values[1];
                        this.RSSI = values[3];
                        this.SIMStatus = values[11];
                        this.Operator = values[13];
                        this.ModemVoltage = values[15];
                        this.SIMIdentificationNumber = values[17];
                        this.ModemIMEI = values[19];
                        this.SimIMSI = values[21];
                        this.ModemVersion = values[23];
                        this.ModemEUpdateCounter = values[33];

                        Valid = true;
                    }
                    else
                    {
                        Valid = false;
                    }

                }
                else
                {
                    Valid = false;
                }
            }
        }



    }
}
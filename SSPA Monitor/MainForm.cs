using DSPLib;
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

namespace Monitor
{


    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class MainForm : System.Windows.Forms.Form
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

        private bool New_Line = false;
        private bool Show_Time;
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
        private Button button_GetSystemID;
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
        private Button button_SetSystemMode;
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
        private Button button_SimulatorDiscreteCALSARcontrol;
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
        private TabPage tabPage3038WBPAA;
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
        private Button button_GetStatus;
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
        private TextBox textBox94;
        private Label label73;
        private TextBox textBox93;
        private Label label68;
        private Label label71;
        private TextBox textBox90;
        private TextBox textBox91;
        private Label label72;
        private TextBox textBox92;
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
        private TextBox textBox_CALSAR;
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
        private TextBox textBox_PulsePeriod2;
        private TextBox textBox_PulseWidth2;
        private GroupBox groupBox34;
        private Button button42;
        private TextBox textBox_PulseDelay;
        private TextBox textBox_PulsePeriod;
        private TextBox textBox_PulseWidth;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private Button button75;
        private GroupBox groupBox39;
        private Label label120;
        private TextBox textBox_StatusUUT23;
        private TextBox textBox_SystemFWVersion;
        private TextBox textBox_SystemHWVersion;
        private ToolTip toolTip1;
        private CheckBox checkBox6;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private Label label115;
        private TextBox textBox95;
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
        private Label label84;
        private Label label85;
        private Label label101;
        private Label label79;
        private Label label80;
        private Label label83;
        private Button button74;
        private Label label102;
        private CheckBox checkBox_ParseRxTCPBuffer;
        private CheckBox checkBox_SendEveryOneSecond;
        private TextBox textBox_SendSerialPortPeriod;
        private TextBox textBox_SimulatorDiscreteCALSARcontrol;
        private Label label103;
        private TextBox textBox_StatusUUT32;
        private Label label104;
        private Label label105;
        private TextBox textBox_StatusUUT31;
        private Label label106;
        private TextBox textBox_StatusUUT30;
        private Label label118;
        private TextBox textBox_StatusUUT29;
        private Label label119;
        private TextBox textBox_StatusUUT27;
        private TextBox textBox_StatusUUT28;
        private Label label121;
        private TextBox textBox_SystemSN;
        private Label label122;
        private TextBox textBox_SystemID;
        private GroupBox groupBox49;
        private TextBox textBox_SystemMode;
        private Button button_SystemMode;
        private Label label123;
        private static readonly string PREAMBLE = "23";


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


                base.Dispose(disposing);



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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox_ServerSettings = new System.Windows.Forms.GroupBox();
            textBox_ServerOpen = new System.Windows.Forms.TextBox();
            textBox_ServerActive = new System.Windows.Forms.TextBox();
            txtPortNo = new System.Windows.Forms.TextBox();
            textBox_NumberOfOpenConnections = new System.Windows.Forms.TextBox();
            ListenBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            comboBox_ConnectionNumber = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            txtDataTx = new System.Windows.Forms.TextBox();
            tabControl_Main = new System.Windows.Forms.TabControl();
            tabPage_charts = new System.Windows.Forms.TabPage();
            button99 = new System.Windows.Forms.Button();
            label37 = new System.Windows.Forms.Label();
            textBox_MaxXAxis = new System.Windows.Forms.TextBox();
            textBox_MinXAxis = new System.Windows.Forms.TextBox();
            comboBox_ChartUpdateTime = new System.Windows.Forms.ComboBox();
            button28 = new System.Windows.Forms.Button();
            listBox_Charts = new System.Windows.Forms.ListBox();
            button_OpenFolder2 = new System.Windows.Forms.Button();
            button_GraphPause = new System.Windows.Forms.Button();
            Button_Export_excel = new System.Windows.Forms.Button();
            button_ResetGraphs = new System.Windows.Forms.Button();
            textBox_graph_XY = new System.Windows.Forms.TextBox();
            button_ScreenShot = new System.Windows.Forms.Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tabPage_ServerTCP = new System.Windows.Forms.TabPage();
            checkBox_ParseMessages = new System.Windows.Forms.CheckBox();
            textBox_IDKey = new System.Windows.Forms.RichTextBox();
            groupBox_FOTA = new System.Windows.Forms.GroupBox();
            button_StartFOTAProcess = new System.Windows.Forms.Button();
            textBox_TotalFileLength = new System.Windows.Forms.TextBox();
            textBox_MaximumNumberReceivedRequest = new System.Windows.Forms.RichTextBox();
            button35 = new System.Windows.Forms.Button();
            button_StartFOTA = new System.Windows.Forms.Button();
            textBox_TotalFrames1280Bytes = new System.Windows.Forms.TextBox();
            textBox_FOTA = new System.Windows.Forms.TextBox();
            button5 = new System.Windows.Forms.Button();
            checkBox_EchoResponse = new System.Windows.Forms.CheckBox();
            groupBox_ConnectionTimedOut = new System.Windows.Forms.GroupBox();
            textBox_CurrentTimeOut = new System.Windows.Forms.TextBox();
            button_SetTimedOut = new System.Windows.Forms.Button();
            textBox_ConnectionTimedOut = new System.Windows.Forms.TextBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            checkBox_ServerRecord = new System.Windows.Forms.CheckBox();
            checkBox_ServerPause = new System.Windows.Forms.CheckBox();
            button_ClearServer = new System.Windows.Forms.Button();
            checkBox_StopLogging = new System.Windows.Forms.CheckBox();
            TextBox_Server = new System.Windows.Forms.RichTextBox();
            checkBox_RecordGeneral = new System.Windows.Forms.CheckBox();
            PauseCheck = new System.Windows.Forms.CheckBox();
            Clear_btn = new System.Windows.Forms.Button();
            tabPage_ClientTCP = new System.Windows.Forms.TabPage();
            checkBox_ParseRxTCPBuffer = new System.Windows.Forms.CheckBox();
            button_Ping = new System.Windows.Forms.Button();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            button_ClearRx = new System.Windows.Forms.Button();
            richTextBox_ClientRx = new System.Windows.Forms.RichTextBox();
            button43 = new System.Windows.Forms.Button();
            button_ClientClose = new System.Windows.Forms.Button();
            button_ClientConnect = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            richTextBox_ClientTx = new System.Windows.Forms.RichTextBox();
            textBox_ClientPort = new System.Windows.Forms.TextBox();
            textBox_ClientIP = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            tabPage_SerialPort = new System.Windows.Forms.TabPage();
            groupBox_SendSerialOrMonitorCommands = new System.Windows.Forms.GroupBox();
            textBox_SendSerialPortPeriod = new System.Windows.Forms.TextBox();
            checkBox_SendEveryOneSecond = new System.Windows.Forms.CheckBox();
            checkBox_SendHexdata = new System.Windows.Forms.CheckBox();
            textBox_SendSerialPort = new System.Windows.Forms.TextBox();
            checkBox_DeleteCommand = new System.Windows.Forms.CheckBox();
            button_SendSerialPort = new System.Windows.Forms.Button();
            gbPortSettings = new System.Windows.Forms.GroupBox();
            button_OpenPort = new System.Windows.Forms.Button();
            button_ReScanComPort = new System.Windows.Forms.Button();
            cmb_PortName = new System.Windows.Forms.ComboBox();
            cmbBaudRate = new System.Windows.Forms.ComboBox();
            cmb_StopBits = new System.Windows.Forms.ComboBox();
            cmbParity = new System.Windows.Forms.ComboBox();
            cmbDataBits = new System.Windows.Forms.ComboBox();
            lblComPort = new System.Windows.Forms.Label();
            lblStopBits = new System.Windows.Forms.Label();
            lblBaudRate = new System.Windows.Forms.Label();
            lblDataBits = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox5 = new System.Windows.Forms.GroupBox();
            groupBox_Timer = new System.Windows.Forms.GroupBox();
            textBox_TimerTime = new System.Windows.Forms.TextBox();
            button_StartStopTimer = new System.Windows.Forms.Button();
            button_ResetTimer = new System.Windows.Forms.Button();
            textBox_SetTimerTime = new System.Windows.Forms.TextBox();
            groupBox_Stopwatch = new System.Windows.Forms.GroupBox();
            button_TimerLog = new System.Windows.Forms.Button();
            button_Stopwatch_Start_Stop = new System.Windows.Forms.Button();
            button_StopwatchReset = new System.Windows.Forms.Button();
            textBox_StopWatch = new System.Windows.Forms.TextBox();
            checkBox_RxHex = new System.Windows.Forms.CheckBox();
            textBox_SerialPortRecognizePattern3 = new System.Windows.Forms.TextBox();
            textBox_SerialPortRecognizePattern2 = new System.Windows.Forms.TextBox();
            textBox_SerialPortRecognizePattern = new System.Windows.Forms.TextBox();
            checkBox_S1RecordLog = new System.Windows.Forms.CheckBox();
            checkBox_S1Pause = new System.Windows.Forms.CheckBox();
            txtS1_Clear = new System.Windows.Forms.Button();
            SerialPortLogger_TextBox = new System.Windows.Forms.RichTextBox();
            tabPage_GenericFrame = new System.Windows.Forms.TabPage();
            button52 = new System.Windows.Forms.Button();
            groupBox31 = new System.Windows.Forms.GroupBox();
            textBox_RxClientCheckSum = new System.Windows.Forms.TextBox();
            label24 = new System.Windows.Forms.Label();
            label41 = new System.Windows.Forms.Label();
            textBox_RxClientDataLength = new System.Windows.Forms.TextBox();
            label23 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            textBox_RxClientPreamble = new System.Windows.Forms.TextBox();
            textBox_RxClientOpcode = new System.Windows.Forms.TextBox();
            textBox_RxClientData = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            groupBox_clientTX = new System.Windows.Forms.GroupBox();
            button_SendProtocolSerialPort = new System.Windows.Forms.Button();
            groupBox41 = new System.Windows.Forms.GroupBox();
            textBox_SentChecksum = new System.Windows.Forms.TextBox();
            label48 = new System.Windows.Forms.Label();
            label42 = new System.Windows.Forms.Label();
            textBox_SentDataLength = new System.Windows.Forms.TextBox();
            label43 = new System.Windows.Forms.Label();
            label44 = new System.Windows.Forms.Label();
            label45 = new System.Windows.Forms.Label();
            textBox_SentPreamble = new System.Windows.Forms.TextBox();
            textBox_SentOpcode = new System.Windows.Forms.TextBox();
            textBox_SentData = new System.Windows.Forms.TextBox();
            label46 = new System.Windows.Forms.Label();
            label47 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            textBox_Preamble = new System.Windows.Forms.TextBox();
            button_SendProtocolTCPIP = new System.Windows.Forms.Button();
            textBox_Opcode = new System.Windows.Forms.TextBox();
            textBox_data = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            tabPage_Commands = new System.Windows.Forms.TabPage();
            groupBox40 = new System.Windows.Forms.GroupBox();
            tabControl_System = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            textBox_SimulatorDiscreteCALSARcontrol = new System.Windows.Forms.TextBox();
            textBox16 = new System.Windows.Forms.TextBox();
            button117 = new System.Windows.Forms.Button();
            button_SimulatorDiscreteCALSARcontrol = new System.Windows.Forms.Button();
            textBox15 = new System.Windows.Forms.TextBox();
            button115 = new System.Windows.Forms.Button();
            button114 = new System.Windows.Forms.Button();
            textBox14 = new System.Windows.Forms.TextBox();
            button113 = new System.Windows.Forms.Button();
            textBox13 = new System.Windows.Forms.TextBox();
            button112 = new System.Windows.Forms.Button();
            textBox12 = new System.Windows.Forms.TextBox();
            button111 = new System.Windows.Forms.Button();
            textBox_RFGenParms = new System.Windows.Forms.TextBox();
            button_SetRFGen = new System.Windows.Forms.Button();
            textBox10 = new System.Windows.Forms.TextBox();
            button58 = new System.Windows.Forms.Button();
            textBox_PulseGenParms = new System.Windows.Forms.TextBox();
            button_GPparms = new System.Windows.Forms.Button();
            textBox8 = new System.Windows.Forms.TextBox();
            button56 = new System.Windows.Forms.Button();
            textBox7 = new System.Windows.Forms.TextBox();
            button55 = new System.Windows.Forms.Button();
            textBox6 = new System.Windows.Forms.TextBox();
            button54 = new System.Windows.Forms.Button();
            textBox5 = new System.Windows.Forms.TextBox();
            button53 = new System.Windows.Forms.Button();
            textBox4 = new System.Windows.Forms.TextBox();
            button51 = new System.Windows.Forms.Button();
            button50 = new System.Windows.Forms.Button();
            textBox3 = new System.Windows.Forms.TextBox();
            button49 = new System.Windows.Forms.Button();
            textBox_TxInhibit = new System.Windows.Forms.TextBox();
            button47 = new System.Windows.Forms.Button();
            button48 = new System.Windows.Forms.Button();
            button108 = new System.Windows.Forms.Button();
            button109 = new System.Windows.Forms.Button();
            button45 = new System.Windows.Forms.Button();
            button46 = new System.Windows.Forms.Button();
            tabPage2 = new System.Windows.Forms.TabPage();
            textBox22 = new System.Windows.Forms.TextBox();
            button122 = new System.Windows.Forms.Button();
            textBox21 = new System.Windows.Forms.TextBox();
            button121 = new System.Windows.Forms.Button();
            textBox20 = new System.Windows.Forms.TextBox();
            button120 = new System.Windows.Forms.Button();
            textBox19 = new System.Windows.Forms.TextBox();
            button119 = new System.Windows.Forms.Button();
            textBox_ControlCal = new System.Windows.Forms.TextBox();
            button118 = new System.Windows.Forms.Button();
            textBox17 = new System.Windows.Forms.TextBox();
            textBox_SetSystemMode = new System.Windows.Forms.TextBox();
            button_SetSystemMode = new System.Windows.Forms.Button();
            textBox_SetDCAWithBusMode = new System.Windows.Forms.TextBox();
            button87 = new System.Windows.Forms.Button();
            textBox_SetVVAAtt = new System.Windows.Forms.TextBox();
            button88 = new System.Windows.Forms.Button();
            textBox_SetPSUOutput = new System.Windows.Forms.TextBox();
            button69 = new System.Windows.Forms.Button();
            button68 = new System.Windows.Forms.Button();
            button67 = new System.Windows.Forms.Button();
            button66 = new System.Windows.Forms.Button();
            button65 = new System.Windows.Forms.Button();
            textBox_SetADCMode = new System.Windows.Forms.TextBox();
            button64 = new System.Windows.Forms.Button();
            button63 = new System.Windows.Forms.Button();
            button62 = new System.Windows.Forms.Button();
            button61 = new System.Windows.Forms.Button();
            button60 = new System.Windows.Forms.Button();
            button_GetSystemID = new System.Windows.Forms.Button();
            groupBox32 = new System.Windows.Forms.GroupBox();
            richTextBox_SSPA = new System.Windows.Forms.RichTextBox();
            checkBox_RecordMiniAda = new System.Windows.Forms.CheckBox();
            checkBox_PauseMiniAda = new System.Windows.Forms.CheckBox();
            button_ClearMiniAda = new System.Windows.Forms.Button();
            tabPage3038WBPAA = new System.Windows.Forms.TabPage();
            groupBox43 = new System.Windows.Forms.GroupBox();
            groupBox48 = new System.Windows.Forms.GroupBox();
            button6 = new System.Windows.Forms.Button();
            button29 = new System.Windows.Forms.Button();
            groupBox38 = new System.Windows.Forms.GroupBox();
            button2 = new System.Windows.Forms.Button();
            button30 = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage6 = new System.Windows.Forms.TabPage();
            groupBox49 = new System.Windows.Forms.GroupBox();
            button_SystemMode = new System.Windows.Forms.Button();
            textBox_SystemMode = new System.Windows.Forms.TextBox();
            groupBox37 = new System.Windows.Forms.GroupBox();
            checkBox4 = new System.Windows.Forms.CheckBox();
            checkBox3 = new System.Windows.Forms.CheckBox();
            checkBox9 = new System.Windows.Forms.CheckBox();
            checkBox2 = new System.Windows.Forms.CheckBox();
            button73 = new System.Windows.Forms.Button();
            label114 = new System.Windows.Forms.Label();
            label113 = new System.Windows.Forms.Label();
            label112 = new System.Windows.Forms.Label();
            textBox_CALSAR = new System.Windows.Forms.TextBox();
            label111 = new System.Windows.Forms.Label();
            label110 = new System.Windows.Forms.Label();
            textBox82 = new System.Windows.Forms.TextBox();
            label107 = new System.Windows.Forms.Label();
            textBox83 = new System.Windows.Forms.TextBox();
            label108 = new System.Windows.Forms.Label();
            textBox84 = new System.Windows.Forms.TextBox();
            label109 = new System.Windows.Forms.Label();
            button71 = new System.Windows.Forms.Button();
            groupBox47 = new System.Windows.Forms.GroupBox();
            label103 = new System.Windows.Forms.Label();
            button74 = new System.Windows.Forms.Button();
            textBox_StatusUUT32 = new System.Windows.Forms.TextBox();
            button_GetStatus = new System.Windows.Forms.Button();
            label104 = new System.Windows.Forms.Label();
            label105 = new System.Windows.Forms.Label();
            textBox_StatusUUT25 = new System.Windows.Forms.TextBox();
            textBox_StatusUUT31 = new System.Windows.Forms.TextBox();
            label69 = new System.Windows.Forms.Label();
            label106 = new System.Windows.Forms.Label();
            label120 = new System.Windows.Forms.Label();
            textBox_StatusUUT30 = new System.Windows.Forms.TextBox();
            textBox_StatusUUT26 = new System.Windows.Forms.TextBox();
            label118 = new System.Windows.Forms.Label();
            textBox_StatusUUT23 = new System.Windows.Forms.TextBox();
            textBox_StatusUUT29 = new System.Windows.Forms.TextBox();
            label56 = new System.Windows.Forms.Label();
            label119 = new System.Windows.Forms.Label();
            textBox_StatusUUT24 = new System.Windows.Forms.TextBox();
            textBox_StatusUUT27 = new System.Windows.Forms.TextBox();
            textBox_StatusUUT12 = new System.Windows.Forms.TextBox();
            textBox_StatusUUT28 = new System.Windows.Forms.TextBox();
            label57 = new System.Windows.Forms.Label();
            label67 = new System.Windows.Forms.Label();
            textBox_StatusUUT22 = new System.Windows.Forms.TextBox();
            label58 = new System.Windows.Forms.Label();
            label70 = new System.Windows.Forms.Label();
            textBox_StatusUUT21 = new System.Windows.Forms.TextBox();
            label59 = new System.Windows.Forms.Label();
            textBox_StatusUUT20 = new System.Windows.Forms.TextBox();
            label60 = new System.Windows.Forms.Label();
            textBox_StatusUUT19 = new System.Windows.Forms.TextBox();
            label61 = new System.Windows.Forms.Label();
            textBox_StatusUUT18 = new System.Windows.Forms.TextBox();
            label62 = new System.Windows.Forms.Label();
            textBox_StatusUUT17 = new System.Windows.Forms.TextBox();
            label63 = new System.Windows.Forms.Label();
            textBox_StatusUUT16 = new System.Windows.Forms.TextBox();
            label64 = new System.Windows.Forms.Label();
            textBox_StatusUUT15 = new System.Windows.Forms.TextBox();
            label65 = new System.Windows.Forms.Label();
            textBox_StatusUUT14 = new System.Windows.Forms.TextBox();
            label66 = new System.Windows.Forms.Label();
            textBox_StatusUUT13 = new System.Windows.Forms.TextBox();
            label55 = new System.Windows.Forms.Label();
            textBox_StatusUUT1 = new System.Windows.Forms.TextBox();
            label54 = new System.Windows.Forms.Label();
            textBox_StatusUUT11 = new System.Windows.Forms.TextBox();
            label53 = new System.Windows.Forms.Label();
            textBox_StatusUUT10 = new System.Windows.Forms.TextBox();
            label52 = new System.Windows.Forms.Label();
            textBox_StatusUUT9 = new System.Windows.Forms.TextBox();
            label51 = new System.Windows.Forms.Label();
            textBox_StatusUUT8 = new System.Windows.Forms.TextBox();
            label50 = new System.Windows.Forms.Label();
            textBox_StatusUUT7 = new System.Windows.Forms.TextBox();
            label49 = new System.Windows.Forms.Label();
            textBox_StatusUUT6 = new System.Windows.Forms.TextBox();
            label40 = new System.Windows.Forms.Label();
            textBox_StatusUUT5 = new System.Windows.Forms.TextBox();
            label39 = new System.Windows.Forms.Label();
            textBox_StatusUUT4 = new System.Windows.Forms.TextBox();
            label33 = new System.Windows.Forms.Label();
            textBox_StatusUUT3 = new System.Windows.Forms.TextBox();
            label32 = new System.Windows.Forms.Label();
            textBox_StatusUUT2 = new System.Windows.Forms.TextBox();
            groupBox39 = new System.Windows.Forms.GroupBox();
            label115 = new System.Windows.Forms.Label();
            textBox95 = new System.Windows.Forms.TextBox();
            label71 = new System.Windows.Forms.Label();
            label74 = new System.Windows.Forms.Label();
            textBox94 = new System.Windows.Forms.TextBox();
            label73 = new System.Windows.Forms.Label();
            textBox93 = new System.Windows.Forms.TextBox();
            label68 = new System.Windows.Forms.Label();
            textBox92 = new System.Windows.Forms.TextBox();
            label72 = new System.Windows.Forms.Label();
            textBox90 = new System.Windows.Forms.TextBox();
            textBox91 = new System.Windows.Forms.TextBox();
            groupBox35 = new System.Windows.Forms.GroupBox();
            label84 = new System.Windows.Forms.Label();
            checkBox8 = new System.Windows.Forms.CheckBox();
            label85 = new System.Windows.Forms.Label();
            button44 = new System.Windows.Forms.Button();
            label101 = new System.Windows.Forms.Label();
            textBox_PulseDelay2 = new System.Windows.Forms.TextBox();
            textBox_PulsePeriod2 = new System.Windows.Forms.TextBox();
            textBox_PulseWidth2 = new System.Windows.Forms.TextBox();
            groupBox46 = new System.Windows.Forms.GroupBox();
            label38 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            label35 = new System.Windows.Forms.Label();
            textBox29 = new System.Windows.Forms.TextBox();
            textBox30 = new System.Windows.Forms.TextBox();
            textBox31 = new System.Windows.Forms.TextBox();
            label36 = new System.Windows.Forms.Label();
            groupBox45 = new System.Windows.Forms.GroupBox();
            label102 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            textBox27 = new System.Windows.Forms.TextBox();
            textBox26 = new System.Windows.Forms.TextBox();
            textBox25 = new System.Windows.Forms.TextBox();
            textBox24 = new System.Windows.Forms.TextBox();
            label25 = new System.Windows.Forms.Label();
            groupBox34 = new System.Windows.Forms.GroupBox();
            label79 = new System.Windows.Forms.Label();
            checkBox7 = new System.Windows.Forms.CheckBox();
            label80 = new System.Windows.Forms.Label();
            button42 = new System.Windows.Forms.Button();
            label83 = new System.Windows.Forms.Label();
            textBox_PulseDelay = new System.Windows.Forms.TextBox();
            textBox_PulsePeriod = new System.Windows.Forms.TextBox();
            textBox_PulseWidth = new System.Windows.Forms.TextBox();
            groupBox44 = new System.Windows.Forms.GroupBox();
            label121 = new System.Windows.Forms.Label();
            button57 = new System.Windows.Forms.Button();
            textBox_SystemSN = new System.Windows.Forms.TextBox();
            textBox_SystemFWVersion = new System.Windows.Forms.TextBox();
            label122 = new System.Windows.Forms.Label();
            textBox_SystemHWVersion = new System.Windows.Forms.TextBox();
            textBox_SystemID = new System.Windows.Forms.TextBox();
            button70 = new System.Windows.Forms.Button();
            label27 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            button75 = new System.Windows.Forms.Button();
            label97 = new System.Windows.Forms.Label();
            textBox_SimulatorSN = new System.Windows.Forms.TextBox();
            label96 = new System.Windows.Forms.Label();
            textBox_SimulatorID = new System.Windows.Forms.TextBox();
            button31 = new System.Windows.Forms.Button();
            label93 = new System.Windows.Forms.Label();
            label94 = new System.Windows.Forms.Label();
            textBox_SimulatorFWVersion = new System.Windows.Forms.TextBox();
            textBox_SimulatorHWVersion = new System.Windows.Forms.TextBox();
            label95 = new System.Windows.Forms.Label();
            groupBox33 = new System.Windows.Forms.GroupBox();
            checkBox6 = new System.Windows.Forms.CheckBox();
            button32 = new System.Windows.Forms.Button();
            textBox_RFDelay = new System.Windows.Forms.TextBox();
            label100 = new System.Windows.Forms.Label();
            textBox_RFPeriod = new System.Windows.Forms.TextBox();
            label99 = new System.Windows.Forms.Label();
            textBox_RFWidth = new System.Windows.Forms.TextBox();
            label98 = new System.Windows.Forms.Label();
            tabPage13 = new System.Windows.Forms.TabPage();
            dataGridView_ValPage0 = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label81 = new System.Windows.Forms.Label();
            dataGridView_OverUnder = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label82 = new System.Windows.Forms.Label();
            textBox66 = new System.Windows.Forms.TextBox();
            label78 = new System.Windows.Forms.Label();
            textBox62 = new System.Windows.Forms.TextBox();
            label77 = new System.Windows.Forms.Label();
            textBox61 = new System.Windows.Forms.TextBox();
            tabPage7 = new System.Windows.Forms.TabPage();
            label117 = new System.Windows.Forms.Label();
            label116 = new System.Windows.Forms.Label();
            dataGridView_Page1_4 = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabPage8 = new System.Windows.Forms.TabPage();
            label89 = new System.Windows.Forms.Label();
            dataGridView_VVAOffset1 = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label88 = new System.Windows.Forms.Label();
            dataGridView_VVAOffset2 = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label87 = new System.Windows.Forms.Label();
            label86 = new System.Windows.Forms.Label();
            dataGridView_PAVVA = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label76 = new System.Windows.Forms.Label();
            label75 = new System.Windows.Forms.Label();
            dataGridView_DC4 = new System.Windows.Forms.DataGridView();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabPage9 = new System.Windows.Forms.TabPage();
            label92 = new System.Windows.Forms.Label();
            dataGridView10 = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label91 = new System.Windows.Forms.Label();
            dataGridView9 = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label90 = new System.Windows.Forms.Label();
            dataGridView8 = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            groupBox42 = new System.Windows.Forms.GroupBox();
            radioButton_TCPIP = new System.Windows.Forms.RadioButton();
            radioButton_SerialPort = new System.Windows.Forms.RadioButton();
            button_OpenFolder = new System.Windows.Forms.Button();
            tabPage4 = new System.Windows.Forms.TabPage();
            S1_Configuration = new System.Windows.Forms.GroupBox();
            groupBox12 = new System.Windows.Forms.GroupBox();
            button13 = new System.Windows.Forms.Button();
            groupBox22 = new System.Windows.Forms.GroupBox();
            TextBox_Odometer = new System.Windows.Forms.TextBox();
            button19 = new System.Windows.Forms.Button();
            groupBox28 = new System.Windows.Forms.GroupBox();
            textBox_ModemSocket = new System.Windows.Forms.TextBox();
            textBox_ModemRetries = new System.Windows.Forms.TextBox();
            textBox_ModemTimeOut = new System.Windows.Forms.TextBox();
            button25 = new System.Windows.Forms.Button();
            textBox_ModemPrimeryPort = new System.Windows.Forms.TextBox();
            textBox_ModemPrimeryHost = new System.Windows.Forms.TextBox();
            groupBox30 = new System.Windows.Forms.GroupBox();
            textBox_ForginPassword = new System.Windows.Forms.TextBox();
            button27 = new System.Windows.Forms.Button();
            textBox_ForginAcessPoint = new System.Windows.Forms.TextBox();
            textBox_ForginSecondaryDNS = new System.Windows.Forms.TextBox();
            textBox_ForginUserName = new System.Windows.Forms.TextBox();
            textBox_ForginPrimeryDNS = new System.Windows.Forms.TextBox();
            groupBox29 = new System.Windows.Forms.GroupBox();
            textBox_HomePassword = new System.Windows.Forms.TextBox();
            button26 = new System.Windows.Forms.Button();
            textBox_HomeAcessPoint = new System.Windows.Forms.TextBox();
            textBox_HomeSecondaryDNS = new System.Windows.Forms.TextBox();
            textBox_HomeUserName = new System.Windows.Forms.TextBox();
            textBox_HomePrimeryDNS = new System.Windows.Forms.TextBox();
            groupBox27 = new System.Windows.Forms.GroupBox();
            maskedTextBox1 = new System.Windows.Forms.TextBox();
            button24 = new System.Windows.Forms.Button();
            groupBox26 = new System.Windows.Forms.GroupBox();
            TextBox_NormalStatusDuration = new System.Windows.Forms.TextBox();
            button23 = new System.Windows.Forms.Button();
            groupBox25 = new System.Windows.Forms.GroupBox();
            maskedTextBox_SpeedLimit2 = new System.Windows.Forms.TextBox();
            maskedTextBox_SpeedLimit3 = new System.Windows.Forms.TextBox();
            maskedTextBox_SpeedLimit1 = new System.Windows.Forms.TextBox();
            button22 = new System.Windows.Forms.Button();
            groupBox24 = new System.Windows.Forms.GroupBox();
            comboBox_DispatchSpeed = new System.Windows.Forms.ComboBox();
            button21 = new System.Windows.Forms.Button();
            groupBox23 = new System.Windows.Forms.GroupBox();
            comboBox_KillEngine = new System.Windows.Forms.ComboBox();
            button20 = new System.Windows.Forms.Button();
            groupBox21 = new System.Windows.Forms.GroupBox();
            maskedTextBox_TiltTowSens = new System.Windows.Forms.TextBox();
            comboBox_TiltTowSensState = new System.Windows.Forms.ComboBox();
            button18 = new System.Windows.Forms.Button();
            groupBox20 = new System.Windows.Forms.GroupBox();
            maskedTextBox_HitSensitivity = new System.Windows.Forms.TextBox();
            comboBox_HitState = new System.Windows.Forms.ComboBox();
            button17 = new System.Windows.Forms.Button();
            groupBox19 = new System.Windows.Forms.GroupBox();
            maskedTextBox_ShockDetectNum = new System.Windows.Forms.TextBox();
            maskedTextBox_ShockWindow = new System.Windows.Forms.TextBox();
            comboBox_ShockState = new System.Windows.Forms.ComboBox();
            button16 = new System.Windows.Forms.Button();
            groupBox18 = new System.Windows.Forms.GroupBox();
            maskedTextBox_TiltDetectNum = new System.Windows.Forms.TextBox();
            maskedTextBox_TiltWindow = new System.Windows.Forms.TextBox();
            maskedTextBox_TiltAngle = new System.Windows.Forms.TextBox();
            comboBox1_TiltState = new System.Windows.Forms.ComboBox();
            button15 = new System.Windows.Forms.Button();
            groupBox17 = new System.Windows.Forms.GroupBox();
            maskedTextBox_TowDetectNum = new System.Windows.Forms.TextBox();
            maskedTextBox_TowWindow = new System.Windows.Forms.TextBox();
            maskedTextBox_TowAngle = new System.Windows.Forms.TextBox();
            button14 = new System.Windows.Forms.Button();
            groupBox11 = new System.Windows.Forms.GroupBox();
            comboBox_SleepPolicy = new System.Windows.Forms.ComboBox();
            button12 = new System.Windows.Forms.Button();
            groupBox10 = new System.Windows.Forms.GroupBox();
            comboBox_AlarmPilicy = new System.Windows.Forms.ComboBox();
            button11 = new System.Windows.Forms.Button();
            groupBox9 = new System.Windows.Forms.GroupBox();
            dateTimePicker_SetTimeDate = new System.Windows.Forms.DateTimePicker();
            button10 = new System.Windows.Forms.Button();
            groupBox8 = new System.Windows.Forms.GroupBox();
            comboBox_BatThreshold = new System.Windows.Forms.ComboBox();
            button9 = new System.Windows.Forms.Button();
            groupBox7 = new System.Windows.Forms.GroupBox();
            maskedTextBox_OutputDuration = new System.Windows.Forms.TextBox();
            comboBox_OutputNum = new System.Windows.Forms.ComboBox();
            comboBox_OutputControl = new System.Windows.Forms.ComboBox();
            button8 = new System.Windows.Forms.Button();
            comboBox_OutputPulseLevel = new System.Windows.Forms.ComboBox();
            groupBox6 = new System.Windows.Forms.GroupBox();
            maskedTextBox_InputDuration = new System.Windows.Forms.TextBox();
            comboBox_InputNum1 = new System.Windows.Forms.ComboBox();
            comboBox_Interupt = new System.Windows.Forms.ComboBox();
            button7 = new System.Windows.Forms.Button();
            groupBox13 = new System.Windows.Forms.GroupBox();
            btn_ChangePassword = new System.Windows.Forms.Button();
            textBox_NewPassword = new System.Windows.Forms.TextBox();
            groupBox14 = new System.Windows.Forms.GroupBox();
            comboBox_SMSControl = new System.Windows.Forms.ComboBox();
            button_SMSControl = new System.Windows.Forms.Button();
            groupBox15 = new System.Windows.Forms.GroupBox();
            textBox_FreeText = new System.Windows.Forms.TextBox();
            comboBox_InputIndex = new System.Windows.Forms.ComboBox();
            button_SetFreeText = new System.Windows.Forms.Button();
            groupBox16 = new System.Windows.Forms.GroupBox();
            maskedTextBox3_Subscriber3 = new System.Windows.Forms.TextBox();
            maskedTextBox2_Subscriber2 = new System.Windows.Forms.TextBox();
            maskedTextBox1_Subscriber1 = new System.Windows.Forms.TextBox();
            button4 = new System.Windows.Forms.Button();
            tabPage5 = new System.Windows.Forms.TabPage();
            textBox_SMSPhoneNumber = new System.Windows.Forms.TextBox();
            button_SendAllCheckedSMS = new System.Windows.Forms.Button();
            button_SendSelectedSMS = new System.Windows.Forms.Button();
            button_Ring = new System.Windows.Forms.Button();
            comboBox_SystemType = new System.Windows.Forms.ComboBox();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            timer_General_100ms = new System.Windows.Forms.Timer(components);
            timer_General_1Second = new System.Windows.Forms.Timer(components);
            serialPort = new System.IO.Ports.SerialPort(components);
            groupBox36 = new System.Windows.Forms.GroupBox();
            groupBox_PhoneNumber = new System.Windows.Forms.GroupBox();
            Label_SerialPortRx = new System.Windows.Forms.Label();
            label_SerialPortConnected = new System.Windows.Forms.Label();
            Label_SerialPortTx = new System.Windows.Forms.Label();
            groupBox_SerialPort = new System.Windows.Forms.GroupBox();
            label_SerialPortStatus = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            button97 = new System.Windows.Forms.Button();
            textBox_SystemStatus = new System.Windows.Forms.TextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            groupBox_ClentTCPStatus = new System.Windows.Forms.GroupBox();
            label_TCPClient = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label_ClientTCPConnected = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            checkedListBox_PhoneBook = new System.Windows.Forms.CheckedListBox();
            button_AddContact = new System.Windows.Forms.Button();
            button_RemoveContact = new System.Windows.Forms.Button();
            button_ExportToXML = new System.Windows.Forms.Button();
            button_ImportToXML = new System.Windows.Forms.Button();
            button33 = new System.Windows.Forms.Button();
            richTextBox_ContactDetails = new System.Windows.Forms.RichTextBox();
            button34 = new System.Windows.Forms.Button();
            richTextBox_TextSendSMS = new System.Windows.Forms.RichTextBox();
            label_SMSSendCharacters = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            checkBox_SendSMSAsIs = new System.Windows.Forms.CheckBox();
            checkBox_SMSencrypted = new System.Windows.Forms.CheckBox();
            GrooupBox_Encryption = new System.Windows.Forms.GroupBox();
            textBox_UnitIDForSMS = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            textBox_CodeArrayForSMS = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            richTextBox_ModemStatus = new System.Windows.Forms.RichTextBox();
            comboBox_ComportSMS = new System.Windows.Forms.ComboBox();
            button36 = new System.Windows.Forms.Button();
            checkBox_OpenPortSMS = new System.Windows.Forms.CheckBox();
            checkBox_DebugSMS = new System.Windows.Forms.CheckBox();
            button_ClearSMSConsole = new System.Windows.Forms.Button();
            checkBox_PauseSMSConsole = new System.Windows.Forms.CheckBox();
            checkBox_RecordSMSConsole = new System.Windows.Forms.CheckBox();
            richTextBox_SMSConsole = new System.Windows.Forms.RichTextBox();
            button41 = new System.Windows.Forms.Button();
            button40 = new System.Windows.Forms.Button();
            button39 = new System.Windows.Forms.Button();
            button38 = new System.Windows.Forms.Button();
            button37 = new System.Windows.Forms.Button();
            listBox_SMSCommands = new System.Windows.Forms.ListBox();
            button_WriteCatalinas = new System.Windows.Forms.Button();
            textBox_FilesToWriteForTheCatalinas = new System.Windows.Forms.RichTextBox();
            richTextBox_SyntisazerL1 = new System.Windows.Forms.RichTextBox();
            richTextBox_SyntisazerL2 = new System.Windows.Forms.RichTextBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            button_WriteSystemType = new System.Windows.Forms.Button();
            button_SynthL1 = new System.Windows.Forms.Button();
            button_WriteAllToFlash = new System.Windows.Forms.Button();
            button_SynthL2 = new System.Windows.Forms.Button();
            progressBar_WriteToFlash = new System.Windows.Forms.ProgressBar();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            label123 = new System.Windows.Forms.Label();
            groupBox_ServerSettings.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl_Main.SuspendLayout();
            tabPage_charts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(chart1)).BeginInit();
            tabPage_ServerTCP.SuspendLayout();
            groupBox_FOTA.SuspendLayout();
            groupBox_ConnectionTimedOut.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPage_ClientTCP.SuspendLayout();
            tabPage_SerialPort.SuspendLayout();
            groupBox_SendSerialOrMonitorCommands.SuspendLayout();
            gbPortSettings.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox_Timer.SuspendLayout();
            groupBox_Stopwatch.SuspendLayout();
            tabPage_GenericFrame.SuspendLayout();
            groupBox31.SuspendLayout();
            groupBox_clientTX.SuspendLayout();
            groupBox41.SuspendLayout();
            tabPage_Commands.SuspendLayout();
            groupBox40.SuspendLayout();
            tabControl_System.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox32.SuspendLayout();
            tabPage3038WBPAA.SuspendLayout();
            groupBox43.SuspendLayout();
            groupBox48.SuspendLayout();
            groupBox38.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage6.SuspendLayout();
            groupBox49.SuspendLayout();
            groupBox37.SuspendLayout();
            groupBox47.SuspendLayout();
            groupBox39.SuspendLayout();
            groupBox35.SuspendLayout();
            groupBox46.SuspendLayout();
            groupBox45.SuspendLayout();
            groupBox34.SuspendLayout();
            groupBox44.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox33.SuspendLayout();
            tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_ValPage0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_OverUnder)).BeginInit();
            tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_Page1_4)).BeginInit();
            tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_VVAOffset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_VVAOffset2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_PAVVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_DC4)).BeginInit();
            tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView8)).BeginInit();
            groupBox42.SuspendLayout();
            tabPage4.SuspendLayout();
            S1_Configuration.SuspendLayout();
            groupBox12.SuspendLayout();
            groupBox22.SuspendLayout();
            groupBox28.SuspendLayout();
            groupBox30.SuspendLayout();
            groupBox29.SuspendLayout();
            groupBox27.SuspendLayout();
            groupBox26.SuspendLayout();
            groupBox25.SuspendLayout();
            groupBox24.SuspendLayout();
            groupBox23.SuspendLayout();
            groupBox21.SuspendLayout();
            groupBox20.SuspendLayout();
            groupBox19.SuspendLayout();
            groupBox18.SuspendLayout();
            groupBox17.SuspendLayout();
            groupBox11.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox13.SuspendLayout();
            groupBox14.SuspendLayout();
            groupBox15.SuspendLayout();
            groupBox16.SuspendLayout();
            groupBox_PhoneNumber.SuspendLayout();
            groupBox_SerialPort.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            groupBox_ClentTCPStatus.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox_ServerSettings
            // 
            groupBox_ServerSettings.Controls.Add(textBox_ServerOpen);
            groupBox_ServerSettings.Controls.Add(textBox_ServerActive);
            groupBox_ServerSettings.Controls.Add(txtPortNo);
            groupBox_ServerSettings.Controls.Add(textBox_NumberOfOpenConnections);
            groupBox_ServerSettings.Controls.Add(ListenBox);
            groupBox_ServerSettings.Controls.Add(label1);
            groupBox_ServerSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox_ServerSettings.Location = new System.Drawing.Point(6, 3);
            groupBox_ServerSettings.Margin = new System.Windows.Forms.Padding(2);
            groupBox_ServerSettings.Name = "groupBox_ServerSettings";
            groupBox_ServerSettings.Padding = new System.Windows.Forms.Padding(2);
            groupBox_ServerSettings.Size = new System.Drawing.Size(378, 56);
            groupBox_ServerSettings.TabIndex = 0;
            groupBox_ServerSettings.TabStop = false;
            groupBox_ServerSettings.Text = "Server Settings";
            // 
            // textBox_ServerOpen
            // 
            textBox_ServerOpen.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_ServerOpen.ForeColor = System.Drawing.Color.White;
            textBox_ServerOpen.Location = new System.Drawing.Point(252, 17);
            textBox_ServerOpen.Margin = new System.Windows.Forms.Padding(2);
            textBox_ServerOpen.Multiline = true;
            textBox_ServerOpen.Name = "textBox_ServerOpen";
            textBox_ServerOpen.ReadOnly = true;
            textBox_ServerOpen.Size = new System.Drawing.Size(82, 25);
            textBox_ServerOpen.TabIndex = 7;
            textBox_ServerOpen.Text = "Connected";
            // 
            // textBox_ServerActive
            // 
            textBox_ServerActive.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_ServerActive.ForeColor = System.Drawing.Color.White;
            textBox_ServerActive.Location = new System.Drawing.Point(192, 17);
            textBox_ServerActive.Margin = new System.Windows.Forms.Padding(2);
            textBox_ServerActive.Multiline = true;
            textBox_ServerActive.Name = "textBox_ServerActive";
            textBox_ServerActive.ReadOnly = true;
            textBox_ServerActive.Size = new System.Drawing.Size(56, 25);
            textBox_ServerActive.TabIndex = 6;
            textBox_ServerActive.Text = "Active";
            // 
            // txtPortNo
            // 
            txtPortNo.Location = new System.Drawing.Point(78, 15);
            txtPortNo.Margin = new System.Windows.Forms.Padding(2);
            txtPortNo.Name = "txtPortNo";
            txtPortNo.Size = new System.Drawing.Size(38, 23);
            txtPortNo.TabIndex = 1;
            txtPortNo.Text = "7000";
            txtPortNo.TextChanged += new System.EventHandler(TxtPortNo_TextChanged);
            // 
            // textBox_NumberOfOpenConnections
            // 
            textBox_NumberOfOpenConnections.ForeColor = System.Drawing.Color.White;
            textBox_NumberOfOpenConnections.Location = new System.Drawing.Point(339, 17);
            textBox_NumberOfOpenConnections.Margin = new System.Windows.Forms.Padding(2);
            textBox_NumberOfOpenConnections.Name = "textBox_NumberOfOpenConnections";
            textBox_NumberOfOpenConnections.ReadOnly = true;
            textBox_NumberOfOpenConnections.Size = new System.Drawing.Size(24, 23);
            textBox_NumberOfOpenConnections.TabIndex = 5;
            textBox_NumberOfOpenConnections.TextChanged += new System.EventHandler(TextBox_NumberOfOpenConnections_TextChanged);
            // 
            // ListenBox
            // 
            ListenBox.Appearance = System.Windows.Forms.Appearance.Button;
            ListenBox.AutoSize = true;
            ListenBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ListenBox.Location = new System.Drawing.Point(121, 14);
            ListenBox.Margin = new System.Windows.Forms.Padding(2);
            ListenBox.Name = "ListenBox";
            ListenBox.Size = new System.Drawing.Size(74, 28);
            ListenBox.TabIndex = 4;
            ListenBox.Text = "Listening";
            ListenBox.UseVisualStyleBackColor = true;
            ListenBox.CheckedChanged += new System.EventHandler(ListenBox_CheckedChanged);
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(6, 18);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Port Number:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox_ConnectionNumber);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(txtDataTx);
            groupBox2.Location = new System.Drawing.Point(2, 63);
            groupBox2.Margin = new System.Windows.Forms.Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(2);
            groupBox2.Size = new System.Drawing.Size(250, 210);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Send Data";
            // 
            // comboBox_ConnectionNumber
            // 
            comboBox_ConnectionNumber.FormattingEnabled = true;
            comboBox_ConnectionNumber.Location = new System.Drawing.Point(77, 182);
            comboBox_ConnectionNumber.Margin = new System.Windows.Forms.Padding(2);
            comboBox_ConnectionNumber.Name = "comboBox_ConnectionNumber";
            comboBox_ConnectionNumber.Size = new System.Drawing.Size(156, 26);
            comboBox_ConnectionNumber.TabIndex = 2;
            comboBox_ConnectionNumber.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button1.Location = new System.Drawing.Point(13, 181);
            button1.Margin = new System.Windows.Forms.Padding(2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(58, 23);
            button1.TabIndex = 1;
            button1.Text = "Send";
            button1.Click += new System.EventHandler(Button1_Click);
            // 
            // txtDataTx
            // 
            txtDataTx.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtDataTx.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtDataTx.Location = new System.Drawing.Point(13, 18);
            txtDataTx.Margin = new System.Windows.Forms.Padding(2);
            txtDataTx.Multiline = true;
            txtDataTx.Name = "txtDataTx";
            txtDataTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtDataTx.Size = new System.Drawing.Size(236, 158);
            txtDataTx.TabIndex = 0;
            txtDataTx.TextChanged += new System.EventHandler(TxtDataTx_TextChanged);
            // 
            // tabControl_Main
            // 
            tabControl_Main.Controls.Add(tabPage_charts);
            tabControl_Main.Controls.Add(tabPage_ServerTCP);
            tabControl_Main.Controls.Add(tabPage_ClientTCP);
            tabControl_Main.Controls.Add(tabPage_SerialPort);
            tabControl_Main.Controls.Add(tabPage_GenericFrame);
            tabControl_Main.Controls.Add(tabPage_Commands);
            tabControl_Main.Controls.Add(tabPage3038WBPAA);
            tabControl_Main.Location = new System.Drawing.Point(4, 5);
            tabControl_Main.Margin = new System.Windows.Forms.Padding(2);
            tabControl_Main.Name = "tabControl_Main";
            tabControl_Main.SelectedIndex = 0;
            tabControl_Main.Size = new System.Drawing.Size(1422, 690);
            tabControl_Main.TabIndex = 8;
            tabControl_Main.TabStop = false;
            // 
            // tabPage_charts
            // 
            tabPage_charts.Controls.Add(button99);
            tabPage_charts.Controls.Add(label37);
            tabPage_charts.Controls.Add(textBox_MaxXAxis);
            tabPage_charts.Controls.Add(textBox_MinXAxis);
            tabPage_charts.Controls.Add(comboBox_ChartUpdateTime);
            tabPage_charts.Controls.Add(button28);
            tabPage_charts.Controls.Add(listBox_Charts);
            tabPage_charts.Controls.Add(button_OpenFolder2);
            tabPage_charts.Controls.Add(button_GraphPause);
            tabPage_charts.Controls.Add(Button_Export_excel);
            tabPage_charts.Controls.Add(button_ResetGraphs);
            tabPage_charts.Controls.Add(textBox_graph_XY);
            tabPage_charts.Controls.Add(button_ScreenShot);
            tabPage_charts.Controls.Add(chart1);
            tabPage_charts.Location = new System.Drawing.Point(4, 27);
            tabPage_charts.Margin = new System.Windows.Forms.Padding(2);
            tabPage_charts.Name = "tabPage_charts";
            tabPage_charts.Size = new System.Drawing.Size(1414, 659);
            tabPage_charts.TabIndex = 7;
            tabPage_charts.Text = "Charts";
            tabPage_charts.UseVisualStyleBackColor = true;
            // 
            // button99
            // 
            button99.Location = new System.Drawing.Point(121, 367);
            button99.Margin = new System.Windows.Forms.Padding(2);
            button99.Name = "button99";
            button99.Size = new System.Drawing.Size(53, 22);
            button99.TabIndex = 84;
            button99.Text = "auto";
            button99.UseVisualStyleBackColor = true;
            button99.Click += new System.EventHandler(button99_Click);
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new System.Drawing.Point(2, 343);
            label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(102, 18);
            label37.TabIndex = 83;
            label37.Text = "Min/Max X axis";
            // 
            // textBox_MaxXAxis
            // 
            textBox_MaxXAxis.Location = new System.Drawing.Point(56, 366);
            textBox_MaxXAxis.Margin = new System.Windows.Forms.Padding(2);
            textBox_MaxXAxis.Name = "textBox_MaxXAxis";
            textBox_MaxXAxis.Size = new System.Drawing.Size(59, 26);
            textBox_MaxXAxis.TabIndex = 82;
            textBox_MaxXAxis.TextChanged += new System.EventHandler(textBox_MaxXAxis_TextChanged);
            // 
            // textBox_MinXAxis
            // 
            textBox_MinXAxis.Location = new System.Drawing.Point(2, 366);
            textBox_MinXAxis.Margin = new System.Windows.Forms.Padding(2);
            textBox_MinXAxis.Name = "textBox_MinXAxis";
            textBox_MinXAxis.Size = new System.Drawing.Size(44, 26);
            textBox_MinXAxis.TabIndex = 81;
            textBox_MinXAxis.TextChanged += new System.EventHandler(textBox_MinXAxis_TextChanged);
            // 
            // comboBox_ChartUpdateTime
            // 
            comboBox_ChartUpdateTime.FormattingEnabled = true;
            comboBox_ChartUpdateTime.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000",
            "10000"});
            comboBox_ChartUpdateTime.Location = new System.Drawing.Point(5, 593);
            comboBox_ChartUpdateTime.Margin = new System.Windows.Forms.Padding(2);
            comboBox_ChartUpdateTime.Name = "comboBox_ChartUpdateTime";
            comboBox_ChartUpdateTime.Size = new System.Drawing.Size(169, 26);
            comboBox_ChartUpdateTime.TabIndex = 80;
            comboBox_ChartUpdateTime.Text = "Update time ms";
            comboBox_ChartUpdateTime.SelectedIndexChanged += new System.EventHandler(ComboBox_ChartUpdateTime_SelectedIndexChanged);
            // 
            // button28
            // 
            button28.Location = new System.Drawing.Point(2, 538);
            button28.Margin = new System.Windows.Forms.Padding(2);
            button28.Name = "button28";
            button28.Size = new System.Drawing.Size(170, 22);
            button28.TabIndex = 79;
            button28.Text = "Reset X point";
            button28.UseVisualStyleBackColor = true;
            button28.Click += new System.EventHandler(Button28_Click_2);
            // 
            // listBox_Charts
            // 
            listBox_Charts.FormattingEnabled = true;
            listBox_Charts.ItemHeight = 18;
            listBox_Charts.Location = new System.Drawing.Point(2, 162);
            listBox_Charts.Margin = new System.Windows.Forms.Padding(2);
            listBox_Charts.Name = "listBox_Charts";
            listBox_Charts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            listBox_Charts.Size = new System.Drawing.Size(170, 148);
            listBox_Charts.TabIndex = 78;
            listBox_Charts.SelectedIndexChanged += new System.EventHandler(ListBox_Charts_SelectedIndexChanged);
            listBox_Charts.KeyDown += new System.Windows.Forms.KeyEventHandler(listBox_Charts_KeyDown);
            listBox_Charts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(listBox_Charts_KeyPress);
            // 
            // button_OpenFolder2
            // 
            button_OpenFolder2.Location = new System.Drawing.Point(4, 420);
            button_OpenFolder2.Margin = new System.Windows.Forms.Padding(2);
            button_OpenFolder2.Name = "button_OpenFolder2";
            button_OpenFolder2.Size = new System.Drawing.Size(169, 26);
            button_OpenFolder2.TabIndex = 77;
            button_OpenFolder2.Text = "Open Local Folder";
            button_OpenFolder2.UseVisualStyleBackColor = true;
            button_OpenFolder2.Click += new System.EventHandler(Button_OpenFolder2_Click);
            // 
            // button_GraphPause
            // 
            button_GraphPause.Location = new System.Drawing.Point(2, 565);
            button_GraphPause.Margin = new System.Windows.Forms.Padding(2);
            button_GraphPause.Name = "button_GraphPause";
            button_GraphPause.Size = new System.Drawing.Size(170, 22);
            button_GraphPause.TabIndex = 8;
            button_GraphPause.Text = "Pause";
            button_GraphPause.UseVisualStyleBackColor = true;
            button_GraphPause.Click += new System.EventHandler(Button_GraphPause_Click);
            // 
            // Button_Export_excel
            // 
            Button_Export_excel.Location = new System.Drawing.Point(2, 451);
            Button_Export_excel.Margin = new System.Windows.Forms.Padding(2);
            Button_Export_excel.Name = "Button_Export_excel";
            Button_Export_excel.Size = new System.Drawing.Size(170, 22);
            Button_Export_excel.TabIndex = 7;
            Button_Export_excel.Text = "Export to excel";
            Button_Export_excel.UseVisualStyleBackColor = true;
            Button_Export_excel.Click += new System.EventHandler(Button_Export_excel_Click);
            // 
            // button_ResetGraphs
            // 
            button_ResetGraphs.Location = new System.Drawing.Point(2, 509);
            button_ResetGraphs.Margin = new System.Windows.Forms.Padding(2);
            button_ResetGraphs.Name = "button_ResetGraphs";
            button_ResetGraphs.Size = new System.Drawing.Size(170, 22);
            button_ResetGraphs.TabIndex = 6;
            button_ResetGraphs.Text = "Reset chart data";
            button_ResetGraphs.UseVisualStyleBackColor = true;
            button_ResetGraphs.Click += new System.EventHandler(Button_ResetGraphs_Click);
            // 
            // textBox_graph_XY
            // 
            textBox_graph_XY.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_graph_XY.Location = new System.Drawing.Point(4, 8);
            textBox_graph_XY.Margin = new System.Windows.Forms.Padding(2);
            textBox_graph_XY.Multiline = true;
            textBox_graph_XY.Name = "textBox_graph_XY";
            textBox_graph_XY.ReadOnly = true;
            textBox_graph_XY.Size = new System.Drawing.Size(170, 149);
            textBox_graph_XY.TabIndex = 4;
            textBox_graph_XY.Text = "Message box ";
            textBox_graph_XY.TextChanged += new System.EventHandler(TextBox_graph_XY_TextChanged);
            // 
            // button_ScreenShot
            // 
            button_ScreenShot.Location = new System.Drawing.Point(2, 478);
            button_ScreenShot.Margin = new System.Windows.Forms.Padding(2);
            button_ScreenShot.Name = "button_ScreenShot";
            button_ScreenShot.Size = new System.Drawing.Size(170, 22);
            button_ScreenShot.TabIndex = 1;
            button_ScreenShot.Text = "Take screen shot";
            button_ScreenShot.UseVisualStyleBackColor = true;
            button_ScreenShot.Click += new System.EventHandler(Button_ScreenShot_Click);
            // 
            // chart1
            // 
            chartArea2.AxisX.Title = "Freq";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chartArea2.AxisY.Title = "Power [dBm]";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            chart1.Legends.Add(legend2);
            chart1.Location = new System.Drawing.Point(178, 2);
            chart1.Margin = new System.Windows.Forms.Padding(2);
            chart1.Name = "chart1";
            chart1.Size = new System.Drawing.Size(1234, 644);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            chart1.Click += new System.EventHandler(chart1_Click);
            chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(Chart1_MouseClick);
            chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(Chart1_MouseMove);
            // 
            // tabPage_ServerTCP
            // 
            tabPage_ServerTCP.Controls.Add(checkBox_ParseMessages);
            tabPage_ServerTCP.Controls.Add(textBox_IDKey);
            tabPage_ServerTCP.Controls.Add(groupBox_FOTA);
            tabPage_ServerTCP.Controls.Add(checkBox_EchoResponse);
            tabPage_ServerTCP.Controls.Add(groupBox_ServerSettings);
            tabPage_ServerTCP.Controls.Add(groupBox_ConnectionTimedOut);
            tabPage_ServerTCP.Controls.Add(groupBox2);
            tabPage_ServerTCP.Controls.Add(groupBox3);
            tabPage_ServerTCP.Location = new System.Drawing.Point(4, 27);
            tabPage_ServerTCP.Margin = new System.Windows.Forms.Padding(2);
            tabPage_ServerTCP.Name = "tabPage_ServerTCP";
            tabPage_ServerTCP.Padding = new System.Windows.Forms.Padding(2);
            tabPage_ServerTCP.Size = new System.Drawing.Size(1414, 659);
            tabPage_ServerTCP.TabIndex = 0;
            tabPage_ServerTCP.Text = "Server TCP";
            tabPage_ServerTCP.UseVisualStyleBackColor = true;
            // 
            // checkBox_ParseMessages
            // 
            checkBox_ParseMessages.AutoSize = true;
            checkBox_ParseMessages.Location = new System.Drawing.Point(106, 332);
            checkBox_ParseMessages.Margin = new System.Windows.Forms.Padding(2);
            checkBox_ParseMessages.Name = "checkBox_ParseMessages";
            checkBox_ParseMessages.Size = new System.Drawing.Size(124, 22);
            checkBox_ParseMessages.TabIndex = 103;
            checkBox_ParseMessages.Text = "Parse messages";
            checkBox_ParseMessages.UseVisualStyleBackColor = true;
            checkBox_ParseMessages.CheckedChanged += new System.EventHandler(CheckBox_ParseMessages_CheckedChanged);
            // 
            // textBox_IDKey
            // 
            textBox_IDKey.Location = new System.Drawing.Point(1119, 75);
            textBox_IDKey.Margin = new System.Windows.Forms.Padding(2);
            textBox_IDKey.Name = "textBox_IDKey";
            textBox_IDKey.Size = new System.Drawing.Size(290, 148);
            textBox_IDKey.TabIndex = 102;
            textBox_IDKey.Text = "";
            textBox_IDKey.Visible = false;
            // 
            // groupBox_FOTA
            // 
            groupBox_FOTA.Controls.Add(button_StartFOTAProcess);
            groupBox_FOTA.Controls.Add(textBox_TotalFileLength);
            groupBox_FOTA.Controls.Add(textBox_MaximumNumberReceivedRequest);
            groupBox_FOTA.Controls.Add(button35);
            groupBox_FOTA.Controls.Add(button_StartFOTA);
            groupBox_FOTA.Controls.Add(textBox_TotalFrames1280Bytes);
            groupBox_FOTA.Controls.Add(textBox_FOTA);
            groupBox_FOTA.Controls.Add(button5);
            groupBox_FOTA.Location = new System.Drawing.Point(2, 353);
            groupBox_FOTA.Margin = new System.Windows.Forms.Padding(2);
            groupBox_FOTA.Name = "groupBox_FOTA";
            groupBox_FOTA.Padding = new System.Windows.Forms.Padding(2);
            groupBox_FOTA.Size = new System.Drawing.Size(246, 206);
            groupBox_FOTA.TabIndex = 12;
            groupBox_FOTA.TabStop = false;
            groupBox_FOTA.Text = "FOTA";
            groupBox_FOTA.Visible = false;
            // 
            // button_StartFOTAProcess
            // 
            button_StartFOTAProcess.Enabled = false;
            button_StartFOTAProcess.Location = new System.Drawing.Point(188, 104);
            button_StartFOTAProcess.Margin = new System.Windows.Forms.Padding(2);
            button_StartFOTAProcess.Name = "button_StartFOTAProcess";
            button_StartFOTAProcess.Size = new System.Drawing.Size(53, 42);
            button_StartFOTAProcess.TabIndex = 21;
            button_StartFOTAProcess.Text = "Start FOTA";
            button_StartFOTAProcess.UseVisualStyleBackColor = true;
            button_StartFOTAProcess.Click += new System.EventHandler(Button34_Click_1);
            // 
            // textBox_TotalFileLength
            // 
            textBox_TotalFileLength.Location = new System.Drawing.Point(188, 75);
            textBox_TotalFileLength.Margin = new System.Windows.Forms.Padding(2);
            textBox_TotalFileLength.Name = "textBox_TotalFileLength";
            textBox_TotalFileLength.ReadOnly = true;
            textBox_TotalFileLength.Size = new System.Drawing.Size(54, 26);
            textBox_TotalFileLength.TabIndex = 20;
            // 
            // textBox_MaximumNumberReceivedRequest
            // 
            textBox_MaximumNumberReceivedRequest.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_MaximumNumberReceivedRequest.Location = new System.Drawing.Point(4, 102);
            textBox_MaximumNumberReceivedRequest.Margin = new System.Windows.Forms.Padding(2);
            textBox_MaximumNumberReceivedRequest.Name = "textBox_MaximumNumberReceivedRequest";
            textBox_MaximumNumberReceivedRequest.Size = new System.Drawing.Size(180, 87);
            textBox_MaximumNumberReceivedRequest.TabIndex = 19;
            textBox_MaximumNumberReceivedRequest.Text = "";
            // 
            // button35
            // 
            button35.Location = new System.Drawing.Point(188, 290);
            button35.Margin = new System.Windows.Forms.Padding(2);
            button35.Name = "button35";
            button35.Size = new System.Drawing.Size(53, 22);
            button35.TabIndex = 18;
            button35.Text = "Clear";
            button35.UseVisualStyleBackColor = true;
            button35.Click += new System.EventHandler(Button35_Click);
            // 
            // button_StartFOTA
            // 
            button_StartFOTA.Enabled = false;
            button_StartFOTA.Location = new System.Drawing.Point(188, 264);
            button_StartFOTA.Margin = new System.Windows.Forms.Padding(2);
            button_StartFOTA.Name = "button_StartFOTA";
            button_StartFOTA.Size = new System.Drawing.Size(53, 22);
            button_StartFOTA.TabIndex = 16;
            button_StartFOTA.Text = "--->";
            button_StartFOTA.UseVisualStyleBackColor = true;
            button_StartFOTA.Click += new System.EventHandler(Button33_Click);
            // 
            // textBox_TotalFrames1280Bytes
            // 
            textBox_TotalFrames1280Bytes.Location = new System.Drawing.Point(188, 47);
            textBox_TotalFrames1280Bytes.Margin = new System.Windows.Forms.Padding(2);
            textBox_TotalFrames1280Bytes.Name = "textBox_TotalFrames1280Bytes";
            textBox_TotalFrames1280Bytes.ReadOnly = true;
            textBox_TotalFrames1280Bytes.Size = new System.Drawing.Size(54, 26);
            textBox_TotalFrames1280Bytes.TabIndex = 14;
            textBox_TotalFrames1280Bytes.TextChanged += new System.EventHandler(TextBox_TotalFrames256Bytes_TextChanged);
            // 
            // textBox_FOTA
            // 
            textBox_FOTA.Location = new System.Drawing.Point(6, 47);
            textBox_FOTA.Margin = new System.Windows.Forms.Padding(2);
            textBox_FOTA.Multiline = true;
            textBox_FOTA.Name = "textBox_FOTA";
            textBox_FOTA.Size = new System.Drawing.Size(178, 51);
            textBox_FOTA.TabIndex = 13;
            textBox_FOTA.TextChanged += new System.EventHandler(TextBox_FOTA_TextChanged);
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(6, 19);
            button5.Margin = new System.Windows.Forms.Padding(2);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(90, 22);
            button5.TabIndex = 0;
            button5.Text = "Choose File";
            button5.UseVisualStyleBackColor = true;
            button5.Click += new System.EventHandler(Button5_Click);
            // 
            // checkBox_EchoResponse
            // 
            checkBox_EchoResponse.AutoSize = true;
            checkBox_EchoResponse.Location = new System.Drawing.Point(5, 332);
            checkBox_EchoResponse.Margin = new System.Windows.Forms.Padding(2);
            checkBox_EchoResponse.Name = "checkBox_EchoResponse";
            checkBox_EchoResponse.Size = new System.Drawing.Size(117, 22);
            checkBox_EchoResponse.TabIndex = 10;
            checkBox_EchoResponse.Text = "Send ACK Back";
            checkBox_EchoResponse.UseVisualStyleBackColor = true;
            checkBox_EchoResponse.CheckedChanged += new System.EventHandler(CheckBox_EchoResponse_CheckedChanged);
            // 
            // groupBox_ConnectionTimedOut
            // 
            groupBox_ConnectionTimedOut.Controls.Add(textBox_CurrentTimeOut);
            groupBox_ConnectionTimedOut.Controls.Add(button_SetTimedOut);
            groupBox_ConnectionTimedOut.Controls.Add(textBox_ConnectionTimedOut);
            groupBox_ConnectionTimedOut.Location = new System.Drawing.Point(2, 279);
            groupBox_ConnectionTimedOut.Margin = new System.Windows.Forms.Padding(2);
            groupBox_ConnectionTimedOut.Name = "groupBox_ConnectionTimedOut";
            groupBox_ConnectionTimedOut.Padding = new System.Windows.Forms.Padding(2);
            groupBox_ConnectionTimedOut.Size = new System.Drawing.Size(250, 51);
            groupBox_ConnectionTimedOut.TabIndex = 9;
            groupBox_ConnectionTimedOut.TabStop = false;
            groupBox_ConnectionTimedOut.Text = "Server Connection Timed Out (seconds)";
            groupBox_ConnectionTimedOut.Visible = false;
            // 
            // textBox_CurrentTimeOut
            // 
            textBox_CurrentTimeOut.Location = new System.Drawing.Point(134, 20);
            textBox_CurrentTimeOut.Margin = new System.Windows.Forms.Padding(2);
            textBox_CurrentTimeOut.Name = "textBox_CurrentTimeOut";
            textBox_CurrentTimeOut.ReadOnly = true;
            textBox_CurrentTimeOut.Size = new System.Drawing.Size(58, 26);
            textBox_CurrentTimeOut.TabIndex = 10;
            // 
            // button_SetTimedOut
            // 
            button_SetTimedOut.Location = new System.Drawing.Point(59, 20);
            button_SetTimedOut.Margin = new System.Windows.Forms.Padding(2);
            button_SetTimedOut.Name = "button_SetTimedOut";
            button_SetTimedOut.Size = new System.Drawing.Size(69, 22);
            button_SetTimedOut.TabIndex = 9;
            button_SetTimedOut.Text = "Set";
            button_SetTimedOut.UseVisualStyleBackColor = true;
            button_SetTimedOut.Click += new System.EventHandler(Button_SetTimedOut_Click);
            // 
            // textBox_ConnectionTimedOut
            // 
            textBox_ConnectionTimedOut.Location = new System.Drawing.Point(6, 22);
            textBox_ConnectionTimedOut.Margin = new System.Windows.Forms.Padding(2);
            textBox_ConnectionTimedOut.Name = "textBox_ConnectionTimedOut";
            textBox_ConnectionTimedOut.Size = new System.Drawing.Size(49, 26);
            textBox_ConnectionTimedOut.TabIndex = 8;
            textBox_ConnectionTimedOut.Text = "300";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox_ServerRecord);
            groupBox3.Controls.Add(checkBox_ServerPause);
            groupBox3.Controls.Add(button_ClearServer);
            groupBox3.Controls.Add(checkBox_StopLogging);
            groupBox3.Controls.Add(TextBox_Server);
            groupBox3.Controls.Add(checkBox_RecordGeneral);
            groupBox3.Controls.Add(PauseCheck);
            groupBox3.Controls.Add(Clear_btn);
            groupBox3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox3.Location = new System.Drawing.Point(258, 63);
            groupBox3.Margin = new System.Windows.Forms.Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(2);
            groupBox3.Size = new System.Drawing.Size(856, 591);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Server Console";
            // 
            // checkBox_ServerRecord
            // 
            checkBox_ServerRecord.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_ServerRecord.AutoSize = true;
            checkBox_ServerRecord.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_ServerRecord.Location = new System.Drawing.Point(139, 560);
            checkBox_ServerRecord.Margin = new System.Windows.Forms.Padding(2);
            checkBox_ServerRecord.Name = "checkBox_ServerRecord";
            checkBox_ServerRecord.Size = new System.Drawing.Size(64, 29);
            checkBox_ServerRecord.TabIndex = 108;
            checkBox_ServerRecord.Text = "Record";
            checkBox_ServerRecord.UseVisualStyleBackColor = true;
            // 
            // checkBox_ServerPause
            // 
            checkBox_ServerPause.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_ServerPause.AutoSize = true;
            checkBox_ServerPause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_ServerPause.Location = new System.Drawing.Point(81, 560);
            checkBox_ServerPause.Margin = new System.Windows.Forms.Padding(2);
            checkBox_ServerPause.Name = "checkBox_ServerPause";
            checkBox_ServerPause.Size = new System.Drawing.Size(58, 29);
            checkBox_ServerPause.TabIndex = 107;
            checkBox_ServerPause.Text = "Pause";
            checkBox_ServerPause.UseVisualStyleBackColor = true;
            // 
            // button_ClearServer
            // 
            button_ClearServer.Location = new System.Drawing.Point(6, 560);
            button_ClearServer.Margin = new System.Windows.Forms.Padding(2);
            button_ClearServer.Name = "button_ClearServer";
            button_ClearServer.Size = new System.Drawing.Size(69, 22);
            button_ClearServer.TabIndex = 104;
            button_ClearServer.Text = "Clear";
            button_ClearServer.UseVisualStyleBackColor = true;
            // 
            // checkBox_StopLogging
            // 
            checkBox_StopLogging.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_StopLogging.AutoSize = true;
            checkBox_StopLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_StopLogging.Location = new System.Drawing.Point(279, 609);
            checkBox_StopLogging.Margin = new System.Windows.Forms.Padding(2);
            checkBox_StopLogging.Name = "checkBox_StopLogging";
            checkBox_StopLogging.Size = new System.Drawing.Size(106, 26);
            checkBox_StopLogging.TabIndex = 8;
            checkBox_StopLogging.Text = "Stop Printing";
            checkBox_StopLogging.UseVisualStyleBackColor = true;
            // 
            // TextBox_Server
            // 
            TextBox_Server.BackColor = System.Drawing.Color.LightGray;
            TextBox_Server.EnableAutoDragDrop = true;
            TextBox_Server.Location = new System.Drawing.Point(6, 19);
            TextBox_Server.Margin = new System.Windows.Forms.Padding(2);
            TextBox_Server.Name = "TextBox_Server";
            TextBox_Server.Size = new System.Drawing.Size(845, 535);
            TextBox_Server.TabIndex = 0;
            TextBox_Server.Text = "";
            TextBox_Server.TextChanged += new System.EventHandler(RichTextBox1_TextChanged);
            // 
            // checkBox_RecordGeneral
            // 
            checkBox_RecordGeneral.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_RecordGeneral.AutoSize = true;
            checkBox_RecordGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_RecordGeneral.Location = new System.Drawing.Point(382, 609);
            checkBox_RecordGeneral.Margin = new System.Windows.Forms.Padding(2);
            checkBox_RecordGeneral.Name = "checkBox_RecordGeneral";
            checkBox_RecordGeneral.Size = new System.Drawing.Size(99, 26);
            checkBox_RecordGeneral.TabIndex = 7;
            checkBox_RecordGeneral.Text = "Record Log";
            checkBox_RecordGeneral.UseVisualStyleBackColor = true;
            checkBox_RecordGeneral.CheckedChanged += new System.EventHandler(CheckBox_RecordGeneral_CheckedChanged);
            // 
            // PauseCheck
            // 
            PauseCheck.Appearance = System.Windows.Forms.Appearance.Button;
            PauseCheck.AutoSize = true;
            PauseCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            PauseCheck.Location = new System.Drawing.Point(478, 609);
            PauseCheck.Margin = new System.Windows.Forms.Padding(2);
            PauseCheck.Name = "PauseCheck";
            PauseCheck.Size = new System.Drawing.Size(62, 26);
            PauseCheck.TabIndex = 5;
            PauseCheck.Text = "Pause";
            PauseCheck.UseVisualStyleBackColor = true;
            // 
            // Clear_btn
            // 
            Clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Clear_btn.Location = new System.Drawing.Point(539, 609);
            Clear_btn.Margin = new System.Windows.Forms.Padding(2);
            Clear_btn.Name = "Clear_btn";
            Clear_btn.Size = new System.Drawing.Size(57, 26);
            Clear_btn.TabIndex = 6;
            Clear_btn.Text = "Clear";
            Clear_btn.UseVisualStyleBackColor = true;
            // 
            // tabPage_ClientTCP
            // 
            tabPage_ClientTCP.Controls.Add(checkBox_ParseRxTCPBuffer);
            tabPage_ClientTCP.Controls.Add(button_Ping);
            tabPage_ClientTCP.Controls.Add(label10);
            tabPage_ClientTCP.Controls.Add(label9);
            tabPage_ClientTCP.Controls.Add(button_ClearRx);
            tabPage_ClientTCP.Controls.Add(richTextBox_ClientRx);
            tabPage_ClientTCP.Controls.Add(button43);
            tabPage_ClientTCP.Controls.Add(button_ClientClose);
            tabPage_ClientTCP.Controls.Add(button_ClientConnect);
            tabPage_ClientTCP.Controls.Add(button3);
            tabPage_ClientTCP.Controls.Add(richTextBox_ClientTx);
            tabPage_ClientTCP.Controls.Add(textBox_ClientPort);
            tabPage_ClientTCP.Controls.Add(textBox_ClientIP);
            tabPage_ClientTCP.Controls.Add(label8);
            tabPage_ClientTCP.Controls.Add(label7);
            tabPage_ClientTCP.Location = new System.Drawing.Point(4, 27);
            tabPage_ClientTCP.Margin = new System.Windows.Forms.Padding(2);
            tabPage_ClientTCP.Name = "tabPage_ClientTCP";
            tabPage_ClientTCP.Size = new System.Drawing.Size(1414, 659);
            tabPage_ClientTCP.TabIndex = 9;
            tabPage_ClientTCP.Text = "Client TCP";
            tabPage_ClientTCP.UseVisualStyleBackColor = true;
            // 
            // checkBox_ParseRxTCPBuffer
            // 
            checkBox_ParseRxTCPBuffer.AutoSize = true;
            checkBox_ParseRxTCPBuffer.Location = new System.Drawing.Point(1084, 349);
            checkBox_ParseRxTCPBuffer.Name = "checkBox_ParseRxTCPBuffer";
            checkBox_ParseRxTCPBuffer.Size = new System.Drawing.Size(146, 22);
            checkBox_ParseRxTCPBuffer.TabIndex = 15;
            checkBox_ParseRxTCPBuffer.Text = "Parse Rx TCP Buffer";
            checkBox_ParseRxTCPBuffer.UseVisualStyleBackColor = true;
            // 
            // button_Ping
            // 
            button_Ping.Location = new System.Drawing.Point(178, 75);
            button_Ping.Margin = new System.Windows.Forms.Padding(2);
            button_Ping.Name = "button_Ping";
            button_Ping.Size = new System.Drawing.Size(91, 22);
            button_Ping.TabIndex = 14;
            button_Ping.Text = "Ping";
            button_Ping.UseVisualStyleBackColor = true;
            button_Ping.Click += new System.EventHandler(button72_Click);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label10.Location = new System.Drawing.Point(548, 294);
            label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(150, 23);
            label10.TabIndex = 13;
            label10.Text = "Rx - Data Received";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(548, 86);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(118, 23);
            label9.TabIndex = 12;
            label9.Text = "Tx - Data Send";
            // 
            // button_ClearRx
            // 
            button_ClearRx.Location = new System.Drawing.Point(1084, 322);
            button_ClearRx.Margin = new System.Windows.Forms.Padding(2);
            button_ClearRx.Name = "button_ClearRx";
            button_ClearRx.Size = new System.Drawing.Size(69, 22);
            button_ClearRx.TabIndex = 11;
            button_ClearRx.Text = "Clear Rx";
            button_ClearRx.UseVisualStyleBackColor = true;
            button_ClearRx.Click += new System.EventHandler(Button_ClearRx_Click);
            // 
            // richTextBox_ClientRx
            // 
            richTextBox_ClientRx.Location = new System.Drawing.Point(31, 323);
            richTextBox_ClientRx.Margin = new System.Windows.Forms.Padding(2);
            richTextBox_ClientRx.Name = "richTextBox_ClientRx";
            richTextBox_ClientRx.ReadOnly = true;
            richTextBox_ClientRx.Size = new System.Drawing.Size(1049, 162);
            richTextBox_ClientRx.TabIndex = 9;
            richTextBox_ClientRx.Text = "";
            // 
            // button43
            // 
            button43.Location = new System.Drawing.Point(1086, 141);
            button43.Margin = new System.Windows.Forms.Padding(2);
            button43.Name = "button43";
            button43.Size = new System.Drawing.Size(68, 23);
            button43.TabIndex = 8;
            button43.Text = "Clear Tx";
            button43.UseVisualStyleBackColor = true;
            button43.Click += new System.EventHandler(Button43_Click_1);
            // 
            // button_ClientClose
            // 
            button_ClientClose.Location = new System.Drawing.Point(105, 77);
            button_ClientClose.Margin = new System.Windows.Forms.Padding(2);
            button_ClientClose.Name = "button_ClientClose";
            button_ClientClose.Size = new System.Drawing.Size(69, 22);
            button_ClientClose.TabIndex = 7;
            button_ClientClose.Text = "Close";
            button_ClientClose.UseVisualStyleBackColor = true;
            button_ClientClose.Click += new System.EventHandler(Button42_Click_1);
            // 
            // button_ClientConnect
            // 
            button_ClientConnect.Location = new System.Drawing.Point(31, 78);
            button_ClientConnect.Margin = new System.Windows.Forms.Padding(2);
            button_ClientConnect.Name = "button_ClientConnect";
            button_ClientConnect.Size = new System.Drawing.Size(69, 22);
            button_ClientConnect.TabIndex = 6;
            button_ClientConnect.Text = "Connect";
            button_ClientConnect.UseVisualStyleBackColor = true;
            button_ClientConnect.Click += new System.EventHandler(Button_ClientConnect_Click);
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(1086, 112);
            button3.Margin = new System.Windows.Forms.Padding(2);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(68, 22);
            button3.TabIndex = 5;
            button3.Text = "Send";
            button3.UseVisualStyleBackColor = true;
            button3.Click += new System.EventHandler(Button3_Click_4);
            // 
            // richTextBox_ClientTx
            // 
            richTextBox_ClientTx.Location = new System.Drawing.Point(31, 114);
            richTextBox_ClientTx.Margin = new System.Windows.Forms.Padding(2);
            richTextBox_ClientTx.Name = "richTextBox_ClientTx";
            richTextBox_ClientTx.Size = new System.Drawing.Size(1050, 162);
            richTextBox_ClientTx.TabIndex = 4;
            richTextBox_ClientTx.Text = "Send Data to Server";
            // 
            // textBox_ClientPort
            // 
            textBox_ClientPort.Location = new System.Drawing.Point(114, 46);
            textBox_ClientPort.Margin = new System.Windows.Forms.Padding(2);
            textBox_ClientPort.Name = "textBox_ClientPort";
            textBox_ClientPort.Size = new System.Drawing.Size(92, 26);
            textBox_ClientPort.TabIndex = 3;
            textBox_ClientPort.Text = "7";
            // 
            // textBox_ClientIP
            // 
            textBox_ClientIP.Location = new System.Drawing.Point(114, 17);
            textBox_ClientIP.Margin = new System.Windows.Forms.Padding(2);
            textBox_ClientIP.Name = "textBox_ClientIP";
            textBox_ClientIP.Size = new System.Drawing.Size(92, 26);
            textBox_ClientIP.TabIndex = 2;
            textBox_ClientIP.Text = "192.168.1.10";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label8.Location = new System.Drawing.Point(27, 46);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(43, 23);
            label8.TabIndex = 1;
            label8.Text = "Port";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(27, 14);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(87, 23);
            label7.TabIndex = 0;
            label7.Text = "Host or IP";
            // 
            // tabPage_SerialPort
            // 
            tabPage_SerialPort.Controls.Add(groupBox_SendSerialOrMonitorCommands);
            tabPage_SerialPort.Controls.Add(gbPortSettings);
            tabPage_SerialPort.Controls.Add(groupBox5);
            tabPage_SerialPort.Location = new System.Drawing.Point(4, 27);
            tabPage_SerialPort.Margin = new System.Windows.Forms.Padding(2);
            tabPage_SerialPort.Name = "tabPage_SerialPort";
            tabPage_SerialPort.Padding = new System.Windows.Forms.Padding(2);
            tabPage_SerialPort.Size = new System.Drawing.Size(1414, 659);
            tabPage_SerialPort.TabIndex = 1;
            tabPage_SerialPort.Text = "Serial Port";
            tabPage_SerialPort.UseVisualStyleBackColor = true;
            // 
            // groupBox_SendSerialOrMonitorCommands
            // 
            groupBox_SendSerialOrMonitorCommands.Controls.Add(textBox_SendSerialPortPeriod);
            groupBox_SendSerialOrMonitorCommands.Controls.Add(checkBox_SendEveryOneSecond);
            groupBox_SendSerialOrMonitorCommands.Controls.Add(checkBox_SendHexdata);
            groupBox_SendSerialOrMonitorCommands.Controls.Add(textBox_SendSerialPort);
            groupBox_SendSerialOrMonitorCommands.Controls.Add(checkBox_DeleteCommand);
            groupBox_SendSerialOrMonitorCommands.Controls.Add(button_SendSerialPort);
            groupBox_SendSerialOrMonitorCommands.Location = new System.Drawing.Point(4, 6);
            groupBox_SendSerialOrMonitorCommands.Margin = new System.Windows.Forms.Padding(2);
            groupBox_SendSerialOrMonitorCommands.Name = "groupBox_SendSerialOrMonitorCommands";
            groupBox_SendSerialOrMonitorCommands.Padding = new System.Windows.Forms.Padding(2);
            groupBox_SendSerialOrMonitorCommands.Size = new System.Drawing.Size(841, 90);
            groupBox_SendSerialOrMonitorCommands.TabIndex = 69;
            groupBox_SendSerialOrMonitorCommands.TabStop = false;
            groupBox_SendSerialOrMonitorCommands.Text = "Send Data to Serial Port";
            // 
            // textBox_SendSerialPortPeriod
            // 
            textBox_SendSerialPortPeriod.Location = new System.Drawing.Point(378, 55);
            textBox_SendSerialPortPeriod.Margin = new System.Windows.Forms.Padding(2);
            textBox_SendSerialPortPeriod.Name = "textBox_SendSerialPortPeriod";
            textBox_SendSerialPortPeriod.Size = new System.Drawing.Size(46, 26);
            textBox_SendSerialPortPeriod.TabIndex = 108;
            textBox_SendSerialPortPeriod.Text = "10";
            textBox_SendSerialPortPeriod.TextChanged += new System.EventHandler(textBox_SendSerialPortPeriod_TextChanged);
            // 
            // checkBox_SendEveryOneSecond
            // 
            checkBox_SendEveryOneSecond.AutoSize = true;
            checkBox_SendEveryOneSecond.Location = new System.Drawing.Point(439, 57);
            checkBox_SendEveryOneSecond.Margin = new System.Windows.Forms.Padding(2);
            checkBox_SendEveryOneSecond.Name = "checkBox_SendEveryOneSecond";
            checkBox_SendEveryOneSecond.Size = new System.Drawing.Size(189, 22);
            checkBox_SendEveryOneSecond.TabIndex = 6;
            checkBox_SendEveryOneSecond.Text = "Send Periodically (100 ms)";
            checkBox_SendEveryOneSecond.UseVisualStyleBackColor = true;
            checkBox_SendEveryOneSecond.CheckedChanged += new System.EventHandler(checkBox_SendEveryOneSecond_CheckedChanged);
            // 
            // checkBox_SendHexdata
            // 
            checkBox_SendHexdata.AutoSize = true;
            checkBox_SendHexdata.Checked = true;
            checkBox_SendHexdata.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_SendHexdata.Location = new System.Drawing.Point(252, 58);
            checkBox_SendHexdata.Margin = new System.Windows.Forms.Padding(2);
            checkBox_SendHexdata.Name = "checkBox_SendHexdata";
            checkBox_SendHexdata.Size = new System.Drawing.Size(115, 22);
            checkBox_SendHexdata.TabIndex = 5;
            checkBox_SendHexdata.Text = "Send Hex data";
            checkBox_SendHexdata.UseVisualStyleBackColor = true;
            checkBox_SendHexdata.CheckedChanged += new System.EventHandler(CheckBox_SendHexdata_CheckedChanged);
            // 
            // textBox_SendSerialPort
            // 
            textBox_SendSerialPort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            textBox_SendSerialPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            textBox_SendSerialPort.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_SendSerialPort.Location = new System.Drawing.Point(8, 20);
            textBox_SendSerialPort.Margin = new System.Windows.Forms.Padding(2);
            textBox_SendSerialPort.Name = "textBox_SendSerialPort";
            textBox_SendSerialPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox_SendSerialPort.Size = new System.Drawing.Size(630, 31);
            textBox_SendSerialPort.TabIndex = 0;
            textBox_SendSerialPort.TextChanged += new System.EventHandler(TextBox_SendSerialPort_TextChanged_1);
            textBox_SendSerialPort.KeyDown += new System.Windows.Forms.KeyEventHandler(TextBox_SendSerialPort_KeyDown);
            textBox_SendSerialPort.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(TextBox_SendSerialPort_PreviewKeyDown);
            // 
            // checkBox_DeleteCommand
            // 
            checkBox_DeleteCommand.AutoSize = true;
            checkBox_DeleteCommand.Location = new System.Drawing.Point(115, 59);
            checkBox_DeleteCommand.Margin = new System.Windows.Forms.Padding(2);
            checkBox_DeleteCommand.Name = "checkBox_DeleteCommand";
            checkBox_DeleteCommand.Size = new System.Drawing.Size(135, 22);
            checkBox_DeleteCommand.TabIndex = 4;
            checkBox_DeleteCommand.Text = "Delete after Send";
            checkBox_DeleteCommand.UseVisualStyleBackColor = true;
            // 
            // button_SendSerialPort
            // 
            button_SendSerialPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button_SendSerialPort.Location = new System.Drawing.Point(8, 56);
            button_SendSerialPort.Margin = new System.Windows.Forms.Padding(2);
            button_SendSerialPort.Name = "button_SendSerialPort";
            button_SendSerialPort.Size = new System.Drawing.Size(96, 23);
            button_SendSerialPort.TabIndex = 1;
            button_SendSerialPort.Text = "Send";
            button_SendSerialPort.Click += new System.EventHandler(Button2_Click_1);
            // 
            // gbPortSettings
            // 
            gbPortSettings.Controls.Add(button_OpenPort);
            gbPortSettings.Controls.Add(button_ReScanComPort);
            gbPortSettings.Controls.Add(cmb_PortName);
            gbPortSettings.Controls.Add(cmbBaudRate);
            gbPortSettings.Controls.Add(cmb_StopBits);
            gbPortSettings.Controls.Add(cmbParity);
            gbPortSettings.Controls.Add(cmbDataBits);
            gbPortSettings.Controls.Add(lblComPort);
            gbPortSettings.Controls.Add(lblStopBits);
            gbPortSettings.Controls.Add(lblBaudRate);
            gbPortSettings.Controls.Add(lblDataBits);
            gbPortSettings.Controls.Add(label3);
            gbPortSettings.Location = new System.Drawing.Point(852, 13);
            gbPortSettings.Margin = new System.Windows.Forms.Padding(2);
            gbPortSettings.Name = "gbPortSettings";
            gbPortSettings.Padding = new System.Windows.Forms.Padding(2);
            gbPortSettings.Size = new System.Drawing.Size(557, 83);
            gbPortSettings.TabIndex = 10;
            gbPortSettings.TabStop = false;
            gbPortSettings.Text = "COM Serial Port Settings";
            // 
            // button_OpenPort
            // 
            button_OpenPort.Location = new System.Drawing.Point(463, 33);
            button_OpenPort.Margin = new System.Windows.Forms.Padding(2);
            button_OpenPort.Name = "button_OpenPort";
            button_OpenPort.Size = new System.Drawing.Size(83, 32);
            button_OpenPort.TabIndex = 11;
            button_OpenPort.Text = "Open ";
            button_OpenPort.UseVisualStyleBackColor = true;
            button_OpenPort.Click += new System.EventHandler(Button_OpenPort_Click);
            // 
            // button_ReScanComPort
            // 
            button_ReScanComPort.AutoSize = true;
            button_ReScanComPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button_ReScanComPort.Location = new System.Drawing.Point(378, 33);
            button_ReScanComPort.Margin = new System.Windows.Forms.Padding(2);
            button_ReScanComPort.Name = "button_ReScanComPort";
            button_ReScanComPort.Size = new System.Drawing.Size(80, 33);
            button_ReScanComPort.TabIndex = 10;
            button_ReScanComPort.Text = "ReScan";
            button_ReScanComPort.UseVisualStyleBackColor = true;
            button_ReScanComPort.Click += new System.EventHandler(Button_ReScanComPort_Click);
            // 
            // cmb_PortName
            // 
            cmb_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_PortName.FormattingEnabled = true;
            cmb_PortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            cmb_PortName.Location = new System.Drawing.Point(7, 37);
            cmb_PortName.Margin = new System.Windows.Forms.Padding(2);
            cmb_PortName.Name = "cmb_PortName";
            cmb_PortName.Size = new System.Drawing.Size(62, 26);
            cmb_PortName.TabIndex = 1;
            cmb_PortName.Tag = "1";
            cmb_PortName.SelectedIndexChanged += new System.EventHandler(CmbPortName_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            cmbBaudRate.FormattingEnabled = true;
            cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            cmbBaudRate.Location = new System.Drawing.Point(74, 37);
            cmbBaudRate.Margin = new System.Windows.Forms.Padding(2);
            cmbBaudRate.Name = "cmbBaudRate";
            cmbBaudRate.Size = new System.Drawing.Size(82, 26);
            cmbBaudRate.TabIndex = 3;
            cmbBaudRate.Text = "38400";
            cmbBaudRate.SelectedIndexChanged += new System.EventHandler(CmbBaudRate_SelectedIndexChanged);
            // 
            // cmb_StopBits
            // 
            cmb_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_StopBits.FormattingEnabled = true;
            cmb_StopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            cmb_StopBits.Location = new System.Drawing.Point(282, 36);
            cmb_StopBits.Margin = new System.Windows.Forms.Padding(2);
            cmb_StopBits.Name = "cmb_StopBits";
            cmb_StopBits.Size = new System.Drawing.Size(82, 26);
            cmb_StopBits.TabIndex = 9;
            // 
            // cmbParity
            // 
            cmbParity.DisplayMember = "1";
            cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbParity.FormattingEnabled = true;
            cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            cmbParity.Location = new System.Drawing.Point(161, 36);
            cmbParity.Margin = new System.Windows.Forms.Padding(2);
            cmbParity.Name = "cmbParity";
            cmbParity.Size = new System.Drawing.Size(56, 26);
            cmbParity.TabIndex = 5;
            cmbParity.Tag = "1";
            // 
            // cmbDataBits
            // 
            cmbDataBits.FormattingEnabled = true;
            cmbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            cmbDataBits.Location = new System.Drawing.Point(220, 36);
            cmbDataBits.Margin = new System.Windows.Forms.Padding(2);
            cmbDataBits.Name = "cmbDataBits";
            cmbDataBits.Size = new System.Drawing.Size(56, 26);
            cmbDataBits.TabIndex = 7;
            cmbDataBits.Text = "8";
            // 
            // lblComPort
            // 
            lblComPort.AutoSize = true;
            lblComPort.Location = new System.Drawing.Point(6, 22);
            lblComPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblComPort.Name = "lblComPort";
            lblComPort.Size = new System.Drawing.Size(71, 18);
            lblComPort.TabIndex = 0;
            lblComPort.Text = "COM Port:";
            // 
            // lblStopBits
            // 
            lblStopBits.AutoSize = true;
            lblStopBits.Location = new System.Drawing.Point(283, 20);
            lblStopBits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblStopBits.Name = "lblStopBits";
            lblStopBits.Size = new System.Drawing.Size(66, 18);
            lblStopBits.TabIndex = 8;
            lblStopBits.Text = "Stop Bits:";
            // 
            // lblBaudRate
            // 
            lblBaudRate.AutoSize = true;
            lblBaudRate.Location = new System.Drawing.Point(73, 22);
            lblBaudRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblBaudRate.Name = "lblBaudRate";
            lblBaudRate.Size = new System.Drawing.Size(74, 18);
            lblBaudRate.TabIndex = 2;
            lblBaudRate.Text = "Baud Rate:";
            // 
            // lblDataBits
            // 
            lblDataBits.AutoSize = true;
            lblDataBits.Location = new System.Drawing.Point(223, 20);
            lblDataBits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblDataBits.Name = "lblDataBits";
            lblDataBits.Size = new System.Drawing.Size(66, 18);
            lblDataBits.TabIndex = 6;
            lblDataBits.Text = "Data Bits:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(162, 20);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(48, 18);
            label3.TabIndex = 4;
            label3.Text = "Parity:";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(groupBox_Timer);
            groupBox5.Controls.Add(groupBox_Stopwatch);
            groupBox5.Controls.Add(checkBox_RxHex);
            groupBox5.Controls.Add(textBox_SerialPortRecognizePattern3);
            groupBox5.Controls.Add(textBox_SerialPortRecognizePattern2);
            groupBox5.Controls.Add(textBox_SerialPortRecognizePattern);
            groupBox5.Controls.Add(checkBox_S1RecordLog);
            groupBox5.Controls.Add(checkBox_S1Pause);
            groupBox5.Controls.Add(txtS1_Clear);
            groupBox5.Controls.Add(SerialPortLogger_TextBox);
            groupBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox5.Location = new System.Drawing.Point(4, 102);
            groupBox5.Margin = new System.Windows.Forms.Padding(2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(2);
            groupBox5.Size = new System.Drawing.Size(1405, 553);
            groupBox5.TabIndex = 68;
            groupBox5.TabStop = false;
            groupBox5.Text = "Serial Port Console";
            groupBox5.Enter += new System.EventHandler(GroupBox5_Enter);
            // 
            // groupBox_Timer
            // 
            groupBox_Timer.Controls.Add(textBox_TimerTime);
            groupBox_Timer.Controls.Add(button_StartStopTimer);
            groupBox_Timer.Controls.Add(button_ResetTimer);
            groupBox_Timer.Controls.Add(textBox_SetTimerTime);
            groupBox_Timer.Location = new System.Drawing.Point(38, 704);
            groupBox_Timer.Margin = new System.Windows.Forms.Padding(2);
            groupBox_Timer.Name = "groupBox_Timer";
            groupBox_Timer.Padding = new System.Windows.Forms.Padding(2);
            groupBox_Timer.Size = new System.Drawing.Size(246, 107);
            groupBox_Timer.TabIndex = 107;
            groupBox_Timer.TabStop = false;
            groupBox_Timer.Text = "Timer";
            groupBox_Timer.Visible = false;
            // 
            // textBox_TimerTime
            // 
            textBox_TimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_TimerTime.Location = new System.Drawing.Point(109, 64);
            textBox_TimerTime.Margin = new System.Windows.Forms.Padding(2);
            textBox_TimerTime.Name = "textBox_TimerTime";
            textBox_TimerTime.ReadOnly = true;
            textBox_TimerTime.Size = new System.Drawing.Size(65, 31);
            textBox_TimerTime.TabIndex = 106;
            textBox_TimerTime.Text = "0";
            // 
            // button_StartStopTimer
            // 
            button_StartStopTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button_StartStopTimer.Location = new System.Drawing.Point(8, 22);
            button_StartStopTimer.Margin = new System.Windows.Forms.Padding(2);
            button_StartStopTimer.Name = "button_StartStopTimer";
            button_StartStopTimer.Size = new System.Drawing.Size(101, 36);
            button_StartStopTimer.TabIndex = 104;
            button_StartStopTimer.Text = "Start/Stop";
            button_StartStopTimer.UseVisualStyleBackColor = true;
            button_StartStopTimer.Click += new System.EventHandler(Button_StartStopTimer_Click);
            // 
            // button_ResetTimer
            // 
            button_ResetTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button_ResetTimer.Location = new System.Drawing.Point(109, 22);
            button_ResetTimer.Margin = new System.Windows.Forms.Padding(2);
            button_ResetTimer.Name = "button_ResetTimer";
            button_ResetTimer.Size = new System.Drawing.Size(101, 36);
            button_ResetTimer.TabIndex = 105;
            button_ResetTimer.Text = "Reset (0)";
            button_ResetTimer.UseVisualStyleBackColor = true;
            button_ResetTimer.Click += new System.EventHandler(Button_ResetTimer_Click);
            // 
            // textBox_SetTimerTime
            // 
            textBox_SetTimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_SetTimerTime.Location = new System.Drawing.Point(8, 64);
            textBox_SetTimerTime.Margin = new System.Windows.Forms.Padding(2);
            textBox_SetTimerTime.Name = "textBox_SetTimerTime";
            textBox_SetTimerTime.Size = new System.Drawing.Size(96, 31);
            textBox_SetTimerTime.TabIndex = 103;
            textBox_SetTimerTime.Text = "0";
            // 
            // groupBox_Stopwatch
            // 
            groupBox_Stopwatch.Controls.Add(button_TimerLog);
            groupBox_Stopwatch.Controls.Add(button_Stopwatch_Start_Stop);
            groupBox_Stopwatch.Controls.Add(button_StopwatchReset);
            groupBox_Stopwatch.Controls.Add(textBox_StopWatch);
            groupBox_Stopwatch.Location = new System.Drawing.Point(38, 590);
            groupBox_Stopwatch.Margin = new System.Windows.Forms.Padding(2);
            groupBox_Stopwatch.Name = "groupBox_Stopwatch";
            groupBox_Stopwatch.Padding = new System.Windows.Forms.Padding(2);
            groupBox_Stopwatch.Size = new System.Drawing.Size(246, 108);
            groupBox_Stopwatch.TabIndex = 106;
            groupBox_Stopwatch.TabStop = false;
            groupBox_Stopwatch.Text = "Stopwatch";
            groupBox_Stopwatch.Visible = false;
            // 
            // button_TimerLog
            // 
            button_TimerLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button_TimerLog.Location = new System.Drawing.Point(173, 22);
            button_TimerLog.Margin = new System.Windows.Forms.Padding(2);
            button_TimerLog.Name = "button_TimerLog";
            button_TimerLog.Size = new System.Drawing.Size(69, 36);
            button_TimerLog.TabIndex = 106;
            button_TimerLog.Text = "Log ->";
            button_TimerLog.UseVisualStyleBackColor = true;
            button_TimerLog.Click += new System.EventHandler(Button_TimerLog_Click);
            // 
            // button_Stopwatch_Start_Stop
            // 
            button_Stopwatch_Start_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button_Stopwatch_Start_Stop.Location = new System.Drawing.Point(8, 22);
            button_Stopwatch_Start_Stop.Margin = new System.Windows.Forms.Padding(2);
            button_Stopwatch_Start_Stop.Name = "button_Stopwatch_Start_Stop";
            button_Stopwatch_Start_Stop.Size = new System.Drawing.Size(101, 36);
            button_Stopwatch_Start_Stop.TabIndex = 104;
            button_Stopwatch_Start_Stop.Text = "Start/Stop";
            button_Stopwatch_Start_Stop.UseVisualStyleBackColor = true;
            button_Stopwatch_Start_Stop.Click += new System.EventHandler(Button_Stopwatch_Start_Stop_Click);
            // 
            // button_StopwatchReset
            // 
            button_StopwatchReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button_StopwatchReset.Location = new System.Drawing.Point(109, 22);
            button_StopwatchReset.Margin = new System.Windows.Forms.Padding(2);
            button_StopwatchReset.Name = "button_StopwatchReset";
            button_StopwatchReset.Size = new System.Drawing.Size(64, 36);
            button_StopwatchReset.TabIndex = 105;
            button_StopwatchReset.Text = "Reset";
            button_StopwatchReset.UseVisualStyleBackColor = true;
            button_StopwatchReset.Click += new System.EventHandler(Button_StopwatchReset_Click);
            // 
            // textBox_StopWatch
            // 
            textBox_StopWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_StopWatch.Location = new System.Drawing.Point(8, 64);
            textBox_StopWatch.Margin = new System.Windows.Forms.Padding(2);
            textBox_StopWatch.Name = "textBox_StopWatch";
            textBox_StopWatch.ReadOnly = true;
            textBox_StopWatch.Size = new System.Drawing.Size(184, 31);
            textBox_StopWatch.TabIndex = 103;
            textBox_StopWatch.Text = "0";
            textBox_StopWatch.TextChanged += new System.EventHandler(TextBox_StopWatch_TextChanged);
            // 
            // checkBox_RxHex
            // 
            checkBox_RxHex.AutoSize = true;
            checkBox_RxHex.Checked = true;
            checkBox_RxHex.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_RxHex.Location = new System.Drawing.Point(595, 19);
            checkBox_RxHex.Margin = new System.Windows.Forms.Padding(2);
            checkBox_RxHex.Name = "checkBox_RxHex";
            checkBox_RxHex.Size = new System.Drawing.Size(111, 23);
            checkBox_RxHex.TabIndex = 6;
            checkBox_RxHex.Text = "Show Rx Hex";
            checkBox_RxHex.UseVisualStyleBackColor = true;
            // 
            // textBox_SerialPortRecognizePattern3
            // 
            textBox_SerialPortRecognizePattern3.Location = new System.Drawing.Point(232, 15);
            textBox_SerialPortRecognizePattern3.Margin = new System.Windows.Forms.Padding(2);
            textBox_SerialPortRecognizePattern3.Name = "textBox_SerialPortRecognizePattern3";
            textBox_SerialPortRecognizePattern3.Size = new System.Drawing.Size(108, 27);
            textBox_SerialPortRecognizePattern3.TabIndex = 75;
            // 
            // textBox_SerialPortRecognizePattern2
            // 
            textBox_SerialPortRecognizePattern2.Location = new System.Drawing.Point(120, 16);
            textBox_SerialPortRecognizePattern2.Margin = new System.Windows.Forms.Padding(2);
            textBox_SerialPortRecognizePattern2.Name = "textBox_SerialPortRecognizePattern2";
            textBox_SerialPortRecognizePattern2.Size = new System.Drawing.Size(108, 27);
            textBox_SerialPortRecognizePattern2.TabIndex = 74;
            // 
            // textBox_SerialPortRecognizePattern
            // 
            textBox_SerialPortRecognizePattern.Location = new System.Drawing.Point(8, 16);
            textBox_SerialPortRecognizePattern.Margin = new System.Windows.Forms.Padding(2);
            textBox_SerialPortRecognizePattern.Name = "textBox_SerialPortRecognizePattern";
            textBox_SerialPortRecognizePattern.Size = new System.Drawing.Size(108, 27);
            textBox_SerialPortRecognizePattern.TabIndex = 73;
            // 
            // checkBox_S1RecordLog
            // 
            checkBox_S1RecordLog.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_S1RecordLog.AutoSize = true;
            checkBox_S1RecordLog.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_S1RecordLog.Location = new System.Drawing.Point(345, 14);
            checkBox_S1RecordLog.Margin = new System.Windows.Forms.Padding(2);
            checkBox_S1RecordLog.Name = "checkBox_S1RecordLog";
            checkBox_S1RecordLog.Size = new System.Drawing.Size(83, 29);
            checkBox_S1RecordLog.TabIndex = 69;
            checkBox_S1RecordLog.Text = "Log to file";
            checkBox_S1RecordLog.UseVisualStyleBackColor = true;
            checkBox_S1RecordLog.CheckedChanged += new System.EventHandler(CheckBox_S1RecordLog_CheckedChanged);
            // 
            // checkBox_S1Pause
            // 
            checkBox_S1Pause.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_S1Pause.AutoSize = true;
            checkBox_S1Pause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_S1Pause.Location = new System.Drawing.Point(443, 13);
            checkBox_S1Pause.Margin = new System.Windows.Forms.Padding(2);
            checkBox_S1Pause.Name = "checkBox_S1Pause";
            checkBox_S1Pause.Size = new System.Drawing.Size(58, 29);
            checkBox_S1Pause.TabIndex = 70;
            checkBox_S1Pause.Text = "Pause";
            checkBox_S1Pause.UseVisualStyleBackColor = true;
            checkBox_S1Pause.CheckedChanged += new System.EventHandler(CheckBox_S1Pause_CheckedChanged);
            // 
            // txtS1_Clear
            // 
            txtS1_Clear.Font = new System.Drawing.Font("Calibri", 12F);
            txtS1_Clear.Location = new System.Drawing.Point(514, 13);
            txtS1_Clear.Margin = new System.Windows.Forms.Padding(2);
            txtS1_Clear.Name = "txtS1_Clear";
            txtS1_Clear.Size = new System.Drawing.Size(62, 29);
            txtS1_Clear.TabIndex = 69;
            txtS1_Clear.Text = "Clear";
            txtS1_Clear.UseVisualStyleBackColor = true;
            txtS1_Clear.Click += new System.EventHandler(txtS1_Clear_Click);
            // 
            // SerialPortLogger_TextBox
            // 
            SerialPortLogger_TextBox.BackColor = System.Drawing.Color.LightGray;
            SerialPortLogger_TextBox.EnableAutoDragDrop = true;
            SerialPortLogger_TextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            SerialPortLogger_TextBox.Location = new System.Drawing.Point(4, 47);
            SerialPortLogger_TextBox.Margin = new System.Windows.Forms.Padding(2);
            SerialPortLogger_TextBox.Name = "SerialPortLogger_TextBox";
            SerialPortLogger_TextBox.Size = new System.Drawing.Size(1397, 502);
            SerialPortLogger_TextBox.TabIndex = 0;
            SerialPortLogger_TextBox.Text = "";
            SerialPortLogger_TextBox.TextChanged += new System.EventHandler(SerialPortLogger_TextBox_TextChanged);
            // 
            // tabPage_GenericFrame
            // 
            tabPage_GenericFrame.Controls.Add(button52);
            tabPage_GenericFrame.Controls.Add(groupBox31);
            tabPage_GenericFrame.Controls.Add(groupBox_clientTX);
            tabPage_GenericFrame.Location = new System.Drawing.Point(4, 27);
            tabPage_GenericFrame.Margin = new System.Windows.Forms.Padding(2);
            tabPage_GenericFrame.Name = "tabPage_GenericFrame";
            tabPage_GenericFrame.Size = new System.Drawing.Size(1414, 659);
            tabPage_GenericFrame.TabIndex = 10;
            tabPage_GenericFrame.Text = "Generic Kratos frame";
            tabPage_GenericFrame.UseVisualStyleBackColor = true;
            tabPage_GenericFrame.Enter += new System.EventHandler(tabPage_GenericFrame_Enter);
            tabPage_GenericFrame.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(tabPage_GenericFrame_PreviewKeyDown);
            // 
            // button52
            // 
            button52.Location = new System.Drawing.Point(13, 506);
            button52.Margin = new System.Windows.Forms.Padding(2);
            button52.Name = "button52";
            button52.Size = new System.Drawing.Size(69, 22);
            button52.TabIndex = 15;
            button52.Text = "Clear";
            button52.UseVisualStyleBackColor = true;
            button52.Click += new System.EventHandler(button52_Click);
            // 
            // groupBox31
            // 
            groupBox31.Controls.Add(textBox_RxClientCheckSum);
            groupBox31.Controls.Add(label24);
            groupBox31.Controls.Add(label41);
            groupBox31.Controls.Add(textBox_RxClientDataLength);
            groupBox31.Controls.Add(label23);
            groupBox31.Controls.Add(label18);
            groupBox31.Controls.Add(label13);
            groupBox31.Controls.Add(textBox_RxClientPreamble);
            groupBox31.Controls.Add(textBox_RxClientOpcode);
            groupBox31.Controls.Add(textBox_RxClientData);
            groupBox31.Controls.Add(label15);
            groupBox31.Controls.Add(label16);
            groupBox31.Location = new System.Drawing.Point(577, 15);
            groupBox31.Margin = new System.Windows.Forms.Padding(2);
            groupBox31.Name = "groupBox31";
            groupBox31.Padding = new System.Windows.Forms.Padding(2);
            groupBox31.Size = new System.Drawing.Size(829, 197);
            groupBox31.TabIndex = 14;
            groupBox31.TabStop = false;
            groupBox31.Text = "Data received";
            // 
            // textBox_RxClientCheckSum
            // 
            textBox_RxClientCheckSum.Location = new System.Drawing.Point(89, 155);
            textBox_RxClientCheckSum.Margin = new System.Windows.Forms.Padding(2);
            textBox_RxClientCheckSum.MaxLength = 4;
            textBox_RxClientCheckSum.Name = "textBox_RxClientCheckSum";
            textBox_RxClientCheckSum.ReadOnly = true;
            textBox_RxClientCheckSum.Size = new System.Drawing.Size(92, 26);
            textBox_RxClientCheckSum.TabIndex = 15;
            textBox_RxClientCheckSum.TabStop = false;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label24.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label24.ForeColor = System.Drawing.Color.Maroon;
            label24.Location = new System.Drawing.Point(186, 122);
            label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(65, 21);
            label24.TabIndex = 11;
            label24.Text = "Decimal";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new System.Drawing.Point(9, 159);
            label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label41.Name = "label41";
            label41.Size = new System.Drawing.Size(75, 18);
            label41.TabIndex = 14;
            label41.Text = "Check Sum";
            // 
            // textBox_RxClientDataLength
            // 
            textBox_RxClientDataLength.Location = new System.Drawing.Point(89, 121);
            textBox_RxClientDataLength.Margin = new System.Windows.Forms.Padding(2);
            textBox_RxClientDataLength.MaxLength = 4;
            textBox_RxClientDataLength.Name = "textBox_RxClientDataLength";
            textBox_RxClientDataLength.ReadOnly = true;
            textBox_RxClientDataLength.Size = new System.Drawing.Size(92, 26);
            textBox_RxClientDataLength.TabIndex = 10;
            textBox_RxClientDataLength.TabStop = false;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(9, 125);
            label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(81, 18);
            label23.TabIndex = 9;
            label23.Text = "Data Length";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label18.ForeColor = System.Drawing.Color.Maroon;
            label18.Location = new System.Drawing.Point(186, 17);
            label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(97, 21);
            label18.TabIndex = 8;
            label18.Text = "Hexadecimal";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(9, 20);
            label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(68, 18);
            label13.TabIndex = 4;
            label13.Text = "Preamble";
            // 
            // textBox_RxClientPreamble
            // 
            textBox_RxClientPreamble.Location = new System.Drawing.Point(89, 18);
            textBox_RxClientPreamble.Margin = new System.Windows.Forms.Padding(2);
            textBox_RxClientPreamble.MaxLength = 4;
            textBox_RxClientPreamble.Name = "textBox_RxClientPreamble";
            textBox_RxClientPreamble.ReadOnly = true;
            textBox_RxClientPreamble.Size = new System.Drawing.Size(92, 26);
            textBox_RxClientPreamble.TabIndex = 0;
            textBox_RxClientPreamble.TabStop = false;
            textBox_RxClientPreamble.TextChanged += new System.EventHandler(textBox_RxClientPreamble_TextChanged);
            // 
            // textBox_RxClientOpcode
            // 
            textBox_RxClientOpcode.Location = new System.Drawing.Point(89, 52);
            textBox_RxClientOpcode.Margin = new System.Windows.Forms.Padding(2);
            textBox_RxClientOpcode.MaxLength = 4;
            textBox_RxClientOpcode.Name = "textBox_RxClientOpcode";
            textBox_RxClientOpcode.ReadOnly = true;
            textBox_RxClientOpcode.Size = new System.Drawing.Size(92, 26);
            textBox_RxClientOpcode.TabIndex = 1;
            textBox_RxClientOpcode.TabStop = false;
            // 
            // textBox_RxClientData
            // 
            textBox_RxClientData.Location = new System.Drawing.Point(89, 86);
            textBox_RxClientData.Margin = new System.Windows.Forms.Padding(2);
            textBox_RxClientData.Name = "textBox_RxClientData";
            textBox_RxClientData.ReadOnly = true;
            textBox_RxClientData.Size = new System.Drawing.Size(608, 26);
            textBox_RxClientData.TabIndex = 2;
            textBox_RxClientData.TabStop = false;
            textBox_RxClientData.TextChanged += new System.EventHandler(textBox_RxClientData_TextChanged);
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(9, 58);
            label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(56, 18);
            label15.TabIndex = 5;
            label15.Text = "Opcode";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(9, 88);
            label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(36, 18);
            label16.TabIndex = 6;
            label16.Text = "Data";
            label16.Click += new System.EventHandler(label16_Click);
            // 
            // groupBox_clientTX
            // 
            groupBox_clientTX.Controls.Add(button_SendProtocolSerialPort);
            groupBox_clientTX.Controls.Add(groupBox41);
            groupBox_clientTX.Controls.Add(label17);
            groupBox_clientTX.Controls.Add(label4);
            groupBox_clientTX.Controls.Add(textBox_Preamble);
            groupBox_clientTX.Controls.Add(button_SendProtocolTCPIP);
            groupBox_clientTX.Controls.Add(textBox_Opcode);
            groupBox_clientTX.Controls.Add(textBox_data);
            groupBox_clientTX.Controls.Add(label6);
            groupBox_clientTX.Controls.Add(label11);
            groupBox_clientTX.Location = new System.Drawing.Point(13, 12);
            groupBox_clientTX.Margin = new System.Windows.Forms.Padding(2);
            groupBox_clientTX.Name = "groupBox_clientTX";
            groupBox_clientTX.Padding = new System.Windows.Forms.Padding(2);
            groupBox_clientTX.Size = new System.Drawing.Size(560, 490);
            groupBox_clientTX.TabIndex = 13;
            groupBox_clientTX.TabStop = false;
            groupBox_clientTX.Text = "Send Data";
            groupBox_clientTX.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(groupBox_clientTX_PreviewKeyDown);
            // 
            // button_SendProtocolSerialPort
            // 
            button_SendProtocolSerialPort.Location = new System.Drawing.Point(120, 122);
            button_SendProtocolSerialPort.Margin = new System.Windows.Forms.Padding(2);
            button_SendProtocolSerialPort.Name = "button_SendProtocolSerialPort";
            button_SendProtocolSerialPort.Size = new System.Drawing.Size(110, 22);
            button_SendProtocolSerialPort.TabIndex = 16;
            button_SendProtocolSerialPort.TabStop = false;
            button_SendProtocolSerialPort.Text = "Send SerialPort";
            button_SendProtocolSerialPort.UseVisualStyleBackColor = true;
            button_SendProtocolSerialPort.Click += new System.EventHandler(button_SendProtocolSerialPort_Click);
            // 
            // groupBox41
            // 
            groupBox41.Controls.Add(textBox_SentChecksum);
            groupBox41.Controls.Add(label48);
            groupBox41.Controls.Add(label42);
            groupBox41.Controls.Add(textBox_SentDataLength);
            groupBox41.Controls.Add(label43);
            groupBox41.Controls.Add(label44);
            groupBox41.Controls.Add(label45);
            groupBox41.Controls.Add(textBox_SentPreamble);
            groupBox41.Controls.Add(textBox_SentOpcode);
            groupBox41.Controls.Add(textBox_SentData);
            groupBox41.Controls.Add(label46);
            groupBox41.Controls.Add(label47);
            groupBox41.Location = new System.Drawing.Point(6, 174);
            groupBox41.Margin = new System.Windows.Forms.Padding(2);
            groupBox41.Name = "groupBox41";
            groupBox41.Padding = new System.Windows.Forms.Padding(2);
            groupBox41.Size = new System.Drawing.Size(544, 312);
            groupBox41.TabIndex = 15;
            groupBox41.TabStop = false;
            groupBox41.Text = "Data Sent";
            // 
            // textBox_SentChecksum
            // 
            textBox_SentChecksum.Location = new System.Drawing.Point(89, 157);
            textBox_SentChecksum.Margin = new System.Windows.Forms.Padding(2);
            textBox_SentChecksum.MaxLength = 4;
            textBox_SentChecksum.Name = "textBox_SentChecksum";
            textBox_SentChecksum.ReadOnly = true;
            textBox_SentChecksum.Size = new System.Drawing.Size(92, 26);
            textBox_SentChecksum.TabIndex = 13;
            textBox_SentChecksum.TabStop = false;
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new System.Drawing.Point(9, 161);
            label48.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label48.Name = "label48";
            label48.Size = new System.Drawing.Size(75, 18);
            label48.TabIndex = 12;
            label48.Text = "Check Sum";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label42.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label42.ForeColor = System.Drawing.Color.Maroon;
            label42.Location = new System.Drawing.Point(186, 122);
            label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(65, 21);
            label42.TabIndex = 11;
            label42.Text = "Decimal";
            // 
            // textBox_SentDataLength
            // 
            textBox_SentDataLength.Location = new System.Drawing.Point(89, 121);
            textBox_SentDataLength.Margin = new System.Windows.Forms.Padding(2);
            textBox_SentDataLength.MaxLength = 4;
            textBox_SentDataLength.Name = "textBox_SentDataLength";
            textBox_SentDataLength.ReadOnly = true;
            textBox_SentDataLength.Size = new System.Drawing.Size(92, 26);
            textBox_SentDataLength.TabIndex = 10;
            textBox_SentDataLength.TabStop = false;
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new System.Drawing.Point(9, 125);
            label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(81, 18);
            label43.TabIndex = 9;
            label43.Text = "Data Length";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label44.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label44.ForeColor = System.Drawing.Color.Maroon;
            label44.Location = new System.Drawing.Point(192, 22);
            label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(97, 21);
            label44.TabIndex = 8;
            label44.Text = "Hexadecimal";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new System.Drawing.Point(9, 20);
            label45.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(68, 18);
            label45.TabIndex = 4;
            label45.Text = "Preamble";
            // 
            // textBox_SentPreamble
            // 
            textBox_SentPreamble.Location = new System.Drawing.Point(89, 18);
            textBox_SentPreamble.Margin = new System.Windows.Forms.Padding(2);
            textBox_SentPreamble.MaxLength = 4;
            textBox_SentPreamble.Name = "textBox_SentPreamble";
            textBox_SentPreamble.ReadOnly = true;
            textBox_SentPreamble.Size = new System.Drawing.Size(92, 26);
            textBox_SentPreamble.TabIndex = 0;
            textBox_SentPreamble.TabStop = false;
            // 
            // textBox_SentOpcode
            // 
            textBox_SentOpcode.Location = new System.Drawing.Point(89, 52);
            textBox_SentOpcode.Margin = new System.Windows.Forms.Padding(2);
            textBox_SentOpcode.MaxLength = 4;
            textBox_SentOpcode.Name = "textBox_SentOpcode";
            textBox_SentOpcode.ReadOnly = true;
            textBox_SentOpcode.Size = new System.Drawing.Size(92, 26);
            textBox_SentOpcode.TabIndex = 1;
            textBox_SentOpcode.TabStop = false;
            // 
            // textBox_SentData
            // 
            textBox_SentData.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox_SentData.Location = new System.Drawing.Point(89, 86);
            textBox_SentData.Margin = new System.Windows.Forms.Padding(2);
            textBox_SentData.Name = "textBox_SentData";
            textBox_SentData.ReadOnly = true;
            textBox_SentData.Size = new System.Drawing.Size(449, 26);
            textBox_SentData.TabIndex = 2;
            textBox_SentData.TabStop = false;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new System.Drawing.Point(9, 58);
            label46.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label46.Name = "label46";
            label46.Size = new System.Drawing.Size(56, 18);
            label46.TabIndex = 5;
            label46.Text = "Opcode";
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new System.Drawing.Point(9, 88);
            label47.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label47.Name = "label47";
            label47.Size = new System.Drawing.Size(36, 18);
            label47.TabIndex = 6;
            label47.Text = "Data";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label17.ForeColor = System.Drawing.Color.Maroon;
            label17.Location = new System.Drawing.Point(192, 22);
            label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(97, 21);
            label17.TabIndex = 7;
            label17.Text = "Hexadecimal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(17, 20);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(68, 18);
            label4.TabIndex = 4;
            label4.Text = "Preamble";
            // 
            // textBox_Preamble
            // 
            textBox_Preamble.Location = new System.Drawing.Point(89, 18);
            textBox_Preamble.Margin = new System.Windows.Forms.Padding(2);
            textBox_Preamble.MaxLength = 5;
            textBox_Preamble.Name = "textBox_Preamble";
            textBox_Preamble.Size = new System.Drawing.Size(92, 26);
            textBox_Preamble.TabIndex = 0;
            textBox_Preamble.Text = "23";
            textBox_Preamble.TextChanged += new System.EventHandler(textBox_Preamble_TextChanged);
            textBox_Preamble.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_Preamble_KeyDown);
            // 
            // button_SendProtocolTCPIP
            // 
            button_SendProtocolTCPIP.Location = new System.Drawing.Point(6, 122);
            button_SendProtocolTCPIP.Margin = new System.Windows.Forms.Padding(2);
            button_SendProtocolTCPIP.Name = "button_SendProtocolTCPIP";
            button_SendProtocolTCPIP.Size = new System.Drawing.Size(109, 22);
            button_SendProtocolTCPIP.TabIndex = 3;
            button_SendProtocolTCPIP.TabStop = false;
            button_SendProtocolTCPIP.Text = "Send TCP/IP";
            button_SendProtocolTCPIP.UseVisualStyleBackColor = true;
            button_SendProtocolTCPIP.Click += new System.EventHandler(button_Send_Click);
            // 
            // textBox_Opcode
            // 
            textBox_Opcode.Location = new System.Drawing.Point(89, 52);
            textBox_Opcode.Margin = new System.Windows.Forms.Padding(2);
            textBox_Opcode.MaxLength = 5;
            textBox_Opcode.Name = "textBox_Opcode";
            textBox_Opcode.Size = new System.Drawing.Size(92, 26);
            textBox_Opcode.TabIndex = 1;
            textBox_Opcode.Text = "70 00";
            textBox_Opcode.TextChanged += new System.EventHandler(textBox_Opcode_TextChanged);
            textBox_Opcode.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_Opcode_KeyDown);
            // 
            // textBox_data
            // 
            textBox_data.Location = new System.Drawing.Point(89, 86);
            textBox_data.Margin = new System.Windows.Forms.Padding(2);
            textBox_data.Name = "textBox_data";
            textBox_data.Size = new System.Drawing.Size(206, 26);
            textBox_data.TabIndex = 2;
            textBox_data.Text = "04 00 00 00";
            textBox_data.TextChanged += new System.EventHandler(textBox_data_TextChanged);
            textBox_data.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_data_KeyDown);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(17, 55);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(56, 18);
            label6.TabIndex = 5;
            label6.Text = "Opcode";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(14, 88);
            label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(36, 18);
            label11.TabIndex = 6;
            label11.Text = "Data";
            // 
            // tabPage_Commands
            // 
            tabPage_Commands.Controls.Add(groupBox40);
            tabPage_Commands.Controls.Add(groupBox32);
            tabPage_Commands.Location = new System.Drawing.Point(4, 27);
            tabPage_Commands.Margin = new System.Windows.Forms.Padding(2);
            tabPage_Commands.Name = "tabPage_Commands";
            tabPage_Commands.Size = new System.Drawing.Size(1414, 659);
            tabPage_Commands.TabIndex = 11;
            tabPage_Commands.Text = "SSPA Commands";
            tabPage_Commands.UseVisualStyleBackColor = true;
            // 
            // groupBox40
            // 
            groupBox40.Controls.Add(tabControl_System);
            groupBox40.Location = new System.Drawing.Point(9, 8);
            groupBox40.Margin = new System.Windows.Forms.Padding(2);
            groupBox40.Name = "groupBox40";
            groupBox40.Padding = new System.Windows.Forms.Padding(2);
            groupBox40.Size = new System.Drawing.Size(886, 642);
            groupBox40.TabIndex = 11;
            groupBox40.TabStop = false;
            groupBox40.Text = "Commands for SSPA (press right click on mouse for help)";
            // 
            // tabControl_System
            // 
            tabControl_System.Controls.Add(tabPage1);
            tabControl_System.Controls.Add(tabPage2);
            tabControl_System.Location = new System.Drawing.Point(6, 22);
            tabControl_System.Margin = new System.Windows.Forms.Padding(2);
            tabControl_System.Name = "tabControl_System";
            tabControl_System.SelectedIndex = 0;
            tabControl_System.Size = new System.Drawing.Size(875, 615);
            tabControl_System.TabIndex = 21;
            tabControl_System.SelectedIndexChanged += new System.EventHandler(tabControl_MiniAda_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBox_SimulatorDiscreteCALSARcontrol);
            tabPage1.Controls.Add(textBox16);
            tabPage1.Controls.Add(button117);
            tabPage1.Controls.Add(button_SimulatorDiscreteCALSARcontrol);
            tabPage1.Controls.Add(textBox15);
            tabPage1.Controls.Add(button115);
            tabPage1.Controls.Add(button114);
            tabPage1.Controls.Add(textBox14);
            tabPage1.Controls.Add(button113);
            tabPage1.Controls.Add(textBox13);
            tabPage1.Controls.Add(button112);
            tabPage1.Controls.Add(textBox12);
            tabPage1.Controls.Add(button111);
            tabPage1.Controls.Add(textBox_RFGenParms);
            tabPage1.Controls.Add(button_SetRFGen);
            tabPage1.Controls.Add(textBox10);
            tabPage1.Controls.Add(button58);
            tabPage1.Controls.Add(textBox_PulseGenParms);
            tabPage1.Controls.Add(button_GPparms);
            tabPage1.Controls.Add(textBox8);
            tabPage1.Controls.Add(button56);
            tabPage1.Controls.Add(textBox7);
            tabPage1.Controls.Add(button55);
            tabPage1.Controls.Add(textBox6);
            tabPage1.Controls.Add(button54);
            tabPage1.Controls.Add(textBox5);
            tabPage1.Controls.Add(button53);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(button51);
            tabPage1.Controls.Add(button50);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(button49);
            tabPage1.Controls.Add(textBox_TxInhibit);
            tabPage1.Controls.Add(button47);
            tabPage1.Controls.Add(button48);
            tabPage1.Controls.Add(button108);
            tabPage1.Controls.Add(button109);
            tabPage1.Controls.Add(button45);
            tabPage1.Controls.Add(button46);
            tabPage1.Location = new System.Drawing.Point(4, 27);
            tabPage1.Margin = new System.Windows.Forms.Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(2);
            tabPage1.Size = new System.Drawing.Size(867, 584);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Simulator";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox_SimulatorDiscreteCALSARcontrol
            // 
            textBox_SimulatorDiscreteCALSARcontrol.Location = new System.Drawing.Point(599, 282);
            textBox_SimulatorDiscreteCALSARcontrol.Margin = new System.Windows.Forms.Padding(2);
            textBox_SimulatorDiscreteCALSARcontrol.MaxLength = 30;
            textBox_SimulatorDiscreteCALSARcontrol.Name = "textBox_SimulatorDiscreteCALSARcontrol";
            textBox_SimulatorDiscreteCALSARcontrol.Size = new System.Drawing.Size(118, 26);
            textBox_SimulatorDiscreteCALSARcontrol.TabIndex = 87;
            textBox_SimulatorDiscreteCALSARcontrol.Text = "00";
            textBox_SimulatorDiscreteCALSARcontrol.TextChanged += new System.EventHandler(textBox1_TextChanged_4);
            // 
            // textBox16
            // 
            textBox16.Location = new System.Drawing.Point(599, 309);
            textBox16.Margin = new System.Windows.Forms.Padding(2);
            textBox16.MaxLength = 30;
            textBox16.Name = "textBox16";
            textBox16.Size = new System.Drawing.Size(118, 26);
            textBox16.TabIndex = 86;
            textBox16.Text = "00";
            textBox16.TextChanged += new System.EventHandler(textBox16_TextChanged);
            // 
            // button117
            // 
            button117.Location = new System.Drawing.Point(367, 310);
            button117.Margin = new System.Windows.Forms.Padding(2);
            button117.Name = "button117";
            button117.Size = new System.Drawing.Size(223, 22);
            button117.TabIndex = 85;
            button117.Text = "Simulator discrete Tx_OVT_Check control";
            button117.UseVisualStyleBackColor = true;
            button117.Click += new System.EventHandler(button117_Click);
            // 
            // button_SimulatorDiscreteCALSARcontrol
            // 
            button_SimulatorDiscreteCALSARcontrol.Location = new System.Drawing.Point(367, 281);
            button_SimulatorDiscreteCALSARcontrol.Margin = new System.Windows.Forms.Padding(2);
            button_SimulatorDiscreteCALSARcontrol.Name = "button_SimulatorDiscreteCALSARcontrol";
            button_SimulatorDiscreteCALSARcontrol.Size = new System.Drawing.Size(223, 22);
            button_SimulatorDiscreteCALSARcontrol.TabIndex = 84;
            button_SimulatorDiscreteCALSARcontrol.Text = "Simulator Discrete CAL SAR";
            button_SimulatorDiscreteCALSARcontrol.UseVisualStyleBackColor = true;
            button_SimulatorDiscreteCALSARcontrol.Click += new System.EventHandler(button_SimulatorDiscreteCALSARcontrol_Click);
            // 
            // textBox15
            // 
            textBox15.Location = new System.Drawing.Point(599, 253);
            textBox15.Margin = new System.Windows.Forms.Padding(2);
            textBox15.MaxLength = 30;
            textBox15.Name = "textBox15";
            textBox15.Size = new System.Drawing.Size(118, 26);
            textBox15.TabIndex = 83;
            textBox15.Text = "00";
            textBox15.TextChanged += new System.EventHandler(textBox15_TextChanged);
            // 
            // button115
            // 
            button115.Location = new System.Drawing.Point(367, 254);
            button115.Margin = new System.Windows.Forms.Padding(2);
            button115.Name = "button115";
            button115.Size = new System.Drawing.Size(223, 22);
            button115.TabIndex = 82;
            button115.Text = "Set Simulator discrete DC4 ";
            button115.UseVisualStyleBackColor = true;
            button115.Click += new System.EventHandler(button115_Click);
            // 
            // button114
            // 
            button114.Location = new System.Drawing.Point(367, 226);
            button114.Margin = new System.Windows.Forms.Padding(2);
            button114.Name = "button114";
            button114.Size = new System.Drawing.Size(223, 22);
            button114.TabIndex = 81;
            button114.Text = "Get Thermal Supervisor ";
            button114.UseVisualStyleBackColor = true;
            button114.Click += new System.EventHandler(button114_Click);
            // 
            // textBox14
            // 
            textBox14.Location = new System.Drawing.Point(599, 194);
            textBox14.Margin = new System.Windows.Forms.Padding(2);
            textBox14.MaxLength = 30;
            textBox14.Name = "textBox14";
            textBox14.Size = new System.Drawing.Size(118, 26);
            textBox14.TabIndex = 80;
            textBox14.Text = "00";
            textBox14.TextChanged += new System.EventHandler(textBox14_TextChanged);
            // 
            // button113
            // 
            button113.Location = new System.Drawing.Point(367, 196);
            button113.Margin = new System.Windows.Forms.Padding(2);
            button113.Name = "button113";
            button113.Size = new System.Drawing.Size(223, 22);
            button113.TabIndex = 79;
            button113.Text = "Set Synchronized Tx-Strobe ";
            button113.UseVisualStyleBackColor = true;
            button113.Click += new System.EventHandler(button113_Click);
            // 
            // textBox13
            // 
            textBox13.Location = new System.Drawing.Point(231, 549);
            textBox13.Margin = new System.Windows.Forms.Padding(2);
            textBox13.MaxLength = 30;
            textBox13.Name = "textBox13";
            textBox13.Size = new System.Drawing.Size(119, 26);
            textBox13.TabIndex = 78;
            textBox13.Text = "00";
            textBox13.TextChanged += new System.EventHandler(textBox13_TextChanged);
            // 
            // button112
            // 
            button112.Location = new System.Drawing.Point(0, 551);
            button112.Margin = new System.Windows.Forms.Padding(2);
            button112.Name = "button112";
            button112.Size = new System.Drawing.Size(223, 22);
            button112.TabIndex = 77;
            button112.Text = "Set SEU Recover ";
            button112.UseVisualStyleBackColor = true;
            button112.Click += new System.EventHandler(button112_Click);
            // 
            // textBox12
            // 
            textBox12.Location = new System.Drawing.Point(231, 519);
            textBox12.Margin = new System.Windows.Forms.Padding(2);
            textBox12.MaxLength = 30;
            textBox12.Name = "textBox12";
            textBox12.Size = new System.Drawing.Size(119, 26);
            textBox12.TabIndex = 76;
            textBox12.Text = "00";
            textBox12.TextChanged += new System.EventHandler(textBox12_TextChanged);
            // 
            // button111
            // 
            button111.Location = new System.Drawing.Point(0, 521);
            button111.Margin = new System.Windows.Forms.Padding(2);
            button111.Name = "button111";
            button111.Size = new System.Drawing.Size(223, 22);
            button111.TabIndex = 75;
            button111.Text = "Set RF Gen. Enable ";
            button111.UseVisualStyleBackColor = true;
            button111.Click += new System.EventHandler(button111_Click);
            // 
            // textBox_RFGenParms
            // 
            textBox_RFGenParms.Location = new System.Drawing.Point(231, 486);
            textBox_RFGenParms.Margin = new System.Windows.Forms.Padding(2);
            textBox_RFGenParms.MaxLength = 30;
            textBox_RFGenParms.Name = "textBox_RFGenParms";
            textBox_RFGenParms.Size = new System.Drawing.Size(119, 26);
            textBox_RFGenParms.TabIndex = 74;
            textBox_RFGenParms.Text = "0000 0000 0000";
            textBox_RFGenParms.TextChanged += new System.EventHandler(textBox11_TextChanged);
            // 
            // button_SetRFGen
            // 
            button_SetRFGen.Location = new System.Drawing.Point(0, 488);
            button_SetRFGen.Margin = new System.Windows.Forms.Padding(2);
            button_SetRFGen.Name = "button_SetRFGen";
            button_SetRFGen.Size = new System.Drawing.Size(223, 22);
            button_SetRFGen.TabIndex = 73;
            button_SetRFGen.Text = "Set RF Gen. Parameters ";
            button_SetRFGen.UseVisualStyleBackColor = true;
            button_SetRFGen.Click += new System.EventHandler(button110_Click);
            // 
            // textBox10
            // 
            textBox10.Location = new System.Drawing.Point(231, 454);
            textBox10.Margin = new System.Windows.Forms.Padding(2);
            textBox10.MaxLength = 30;
            textBox10.Name = "textBox10";
            textBox10.Size = new System.Drawing.Size(119, 26);
            textBox10.TabIndex = 72;
            textBox10.Text = "00";
            textBox10.TextChanged += new System.EventHandler(textBox10_TextChanged);
            // 
            // button58
            // 
            button58.Location = new System.Drawing.Point(0, 456);
            button58.Margin = new System.Windows.Forms.Padding(2);
            button58.Name = "button58";
            button58.Size = new System.Drawing.Size(223, 22);
            button58.TabIndex = 71;
            button58.Text = "Set GP Enable ";
            button58.UseVisualStyleBackColor = true;
            button58.Click += new System.EventHandler(button58_Click_1);
            // 
            // textBox_PulseGenParms
            // 
            textBox_PulseGenParms.Location = new System.Drawing.Point(231, 424);
            textBox_PulseGenParms.Margin = new System.Windows.Forms.Padding(2);
            textBox_PulseGenParms.MaxLength = 30;
            textBox_PulseGenParms.Name = "textBox_PulseGenParms";
            textBox_PulseGenParms.Size = new System.Drawing.Size(119, 26);
            textBox_PulseGenParms.TabIndex = 70;
            textBox_PulseGenParms.Text = "0000 0000 0000";
            textBox_PulseGenParms.TextChanged += new System.EventHandler(textBox9_TextChanged);
            // 
            // button_GPparms
            // 
            button_GPparms.Location = new System.Drawing.Point(0, 426);
            button_GPparms.Margin = new System.Windows.Forms.Padding(2);
            button_GPparms.Name = "button_GPparms";
            button_GPparms.Size = new System.Drawing.Size(223, 22);
            button_GPparms.TabIndex = 69;
            button_GPparms.Text = "Set GP Parameters ";
            button_GPparms.UseVisualStyleBackColor = true;
            button_GPparms.Click += new System.EventHandler(button57_Click);
            // 
            // textBox8
            // 
            textBox8.Location = new System.Drawing.Point(231, 394);
            textBox8.Margin = new System.Windows.Forms.Padding(2);
            textBox8.MaxLength = 30;
            textBox8.Name = "textBox8";
            textBox8.Size = new System.Drawing.Size(119, 26);
            textBox8.TabIndex = 68;
            textBox8.Text = "00";
            textBox8.TextChanged += new System.EventHandler(textBox8_TextChanged);
            // 
            // button56
            // 
            button56.Location = new System.Drawing.Point(0, 396);
            button56.Margin = new System.Windows.Forms.Padding(2);
            button56.Name = "button56";
            button56.Size = new System.Drawing.Size(223, 22);
            button56.TabIndex = 67;
            button56.Text = "Set DCA Discretes ";
            button56.UseVisualStyleBackColor = true;
            button56.Click += new System.EventHandler(button56_Click_1);
            // 
            // textBox7
            // 
            textBox7.Location = new System.Drawing.Point(231, 366);
            textBox7.Margin = new System.Windows.Forms.Padding(2);
            textBox7.MaxLength = 30;
            textBox7.Name = "textBox7";
            textBox7.Size = new System.Drawing.Size(119, 26);
            textBox7.TabIndex = 66;
            textBox7.Text = "00";
            textBox7.TextChanged += new System.EventHandler(textBox7_TextChanged);
            // 
            // button55
            // 
            button55.Location = new System.Drawing.Point(0, 368);
            button55.Margin = new System.Windows.Forms.Padding(2);
            button55.Name = "button55";
            button55.Size = new System.Drawing.Size(223, 22);
            button55.TabIndex = 65;
            button55.Text = "Set Freq. Band ";
            button55.UseVisualStyleBackColor = true;
            button55.Click += new System.EventHandler(button55_Click);
            // 
            // textBox6
            // 
            textBox6.Location = new System.Drawing.Point(231, 338);
            textBox6.Margin = new System.Windows.Forms.Padding(2);
            textBox6.MaxLength = 30;
            textBox6.Name = "textBox6";
            textBox6.Size = new System.Drawing.Size(119, 26);
            textBox6.TabIndex = 64;
            textBox6.Text = "00";
            textBox6.TextChanged += new System.EventHandler(textBox6_TextChanged);
            // 
            // button54
            // 
            button54.Location = new System.Drawing.Point(0, 340);
            button54.Margin = new System.Windows.Forms.Padding(2);
            button54.Name = "button54";
            button54.Size = new System.Drawing.Size(223, 22);
            button54.TabIndex = 63;
            button54.Text = "Set OUT-TUNE ";
            button54.UseVisualStyleBackColor = true;
            button54.Click += new System.EventHandler(button54_Click);
            // 
            // textBox5
            // 
            textBox5.Location = new System.Drawing.Point(231, 310);
            textBox5.Margin = new System.Windows.Forms.Padding(2);
            textBox5.MaxLength = 30;
            textBox5.Name = "textBox5";
            textBox5.Size = new System.Drawing.Size(119, 26);
            textBox5.TabIndex = 62;
            textBox5.Text = "01";
            textBox5.TextChanged += new System.EventHandler(textBox5_TextChanged);
            // 
            // button53
            // 
            button53.Location = new System.Drawing.Point(0, 312);
            button53.Margin = new System.Windows.Forms.Padding(2);
            button53.Name = "button53";
            button53.Size = new System.Drawing.Size(223, 22);
            button53.TabIndex = 61;
            button53.Text = "Set TX-STROBE ";
            button53.UseVisualStyleBackColor = true;
            button53.Click += new System.EventHandler(button53_Click_1);
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(231, 282);
            textBox4.Margin = new System.Windows.Forms.Padding(2);
            textBox4.MaxLength = 30;
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(119, 26);
            textBox4.TabIndex = 60;
            textBox4.Text = "00";
            textBox4.TextChanged += new System.EventHandler(textBox4_TextChanged);
            // 
            // button51
            // 
            button51.Location = new System.Drawing.Point(0, 284);
            button51.Margin = new System.Windows.Forms.Padding(2);
            button51.Name = "button51";
            button51.Size = new System.Drawing.Size(223, 22);
            button51.TabIndex = 59;
            button51.Text = "Set Int_Set_Preserve ";
            button51.UseVisualStyleBackColor = true;
            button51.Click += new System.EventHandler(button51_Click);
            // 
            // button50
            // 
            button50.Location = new System.Drawing.Point(0, 257);
            button50.Margin = new System.Windows.Forms.Padding(2);
            button50.Name = "button50";
            button50.Size = new System.Drawing.Size(223, 22);
            button50.TabIndex = 58;
            button50.Text = "Get Simulator Status";
            button50.UseVisualStyleBackColor = true;
            button50.Click += new System.EventHandler(button50_Click_1);
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(231, 226);
            textBox3.Margin = new System.Windows.Forms.Padding(2);
            textBox3.MaxLength = 30;
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(119, 26);
            textBox3.TabIndex = 57;
            textBox3.Text = "00";
            textBox3.TextChanged += new System.EventHandler(textBox3_TextChanged);
            // 
            // button49
            // 
            button49.Location = new System.Drawing.Point(0, 227);
            button49.Margin = new System.Windows.Forms.Padding(2);
            button49.Name = "button49";
            button49.Size = new System.Drawing.Size(223, 22);
            button49.TabIndex = 56;
            button49.Text = "Set TX-INHIBIT Enable ";
            button49.UseVisualStyleBackColor = true;
            button49.Click += new System.EventHandler(button49_Click_1);
            // 
            // textBox_TxInhibit
            // 
            textBox_TxInhibit.Location = new System.Drawing.Point(231, 196);
            textBox_TxInhibit.Margin = new System.Windows.Forms.Padding(2);
            textBox_TxInhibit.MaxLength = 30;
            textBox_TxInhibit.Name = "textBox_TxInhibit";
            textBox_TxInhibit.Size = new System.Drawing.Size(119, 26);
            textBox_TxInhibit.TabIndex = 55;
            textBox_TxInhibit.Text = "0000 0000 0000";
            textBox_TxInhibit.TextChanged += new System.EventHandler(textBox2_TextChanged_1);
            // 
            // button47
            // 
            button47.Location = new System.Drawing.Point(0, 198);
            button47.Margin = new System.Windows.Forms.Padding(2);
            button47.Name = "button47";
            button47.Size = new System.Drawing.Size(223, 22);
            button47.TabIndex = 37;
            button47.Text = "Set TX-INHIBIT Params ";
            button47.UseVisualStyleBackColor = true;
            button47.Click += new System.EventHandler(button47_Click);
            // 
            // button48
            // 
            button48.Location = new System.Drawing.Point(-2, 122);
            button48.Margin = new System.Windows.Forms.Padding(2);
            button48.Name = "button48";
            button48.Size = new System.Drawing.Size(223, 22);
            button48.TabIndex = 36;
            button48.Text = "Get Simulator serial number";
            button48.UseVisualStyleBackColor = true;
            button48.Click += new System.EventHandler(button48_Click_2);
            // 
            // button108
            // 
            button108.Location = new System.Drawing.Point(0, 6);
            button108.Margin = new System.Windows.Forms.Padding(2);
            button108.Name = "button108";
            button108.Size = new System.Drawing.Size(223, 22);
            button108.TabIndex = 35;
            button108.Text = "Get Simulator ID";
            button108.UseVisualStyleBackColor = true;
            button108.Click += new System.EventHandler(button108_Click);
            // 
            // button109
            // 
            button109.Location = new System.Drawing.Point(0, 35);
            button109.Margin = new System.Windows.Forms.Padding(2);
            button109.Name = "button109";
            button109.Size = new System.Drawing.Size(223, 22);
            button109.TabIndex = 10;
            button109.Text = "Get Simulator Software version";
            button109.UseVisualStyleBackColor = true;
            button109.Click += new System.EventHandler(button_GetSoftwareVersion_Click);
            // 
            // button45
            // 
            button45.Location = new System.Drawing.Point(2, 63);
            button45.Margin = new System.Windows.Forms.Padding(2);
            button45.Name = "button45";
            button45.Size = new System.Drawing.Size(223, 22);
            button45.TabIndex = 11;
            button45.Text = "Get Simulator Firmware version";
            button45.UseVisualStyleBackColor = true;
            button45.Click += new System.EventHandler(button45_Click);
            // 
            // button46
            // 
            button46.Location = new System.Drawing.Point(0, 95);
            button46.Margin = new System.Windows.Forms.Padding(2);
            button46.Name = "button46";
            button46.Size = new System.Drawing.Size(223, 22);
            button46.TabIndex = 12;
            button46.Text = "Get Simulator Hardware version";
            button46.UseVisualStyleBackColor = true;
            button46.Click += new System.EventHandler(button46_Click);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox22);
            tabPage2.Controls.Add(button122);
            tabPage2.Controls.Add(textBox21);
            tabPage2.Controls.Add(button121);
            tabPage2.Controls.Add(textBox20);
            tabPage2.Controls.Add(button120);
            tabPage2.Controls.Add(textBox19);
            tabPage2.Controls.Add(button119);
            tabPage2.Controls.Add(textBox_ControlCal);
            tabPage2.Controls.Add(button118);
            tabPage2.Controls.Add(textBox17);
            tabPage2.Controls.Add(textBox_SetSystemMode);
            tabPage2.Controls.Add(button_SetSystemMode);
            tabPage2.Controls.Add(textBox_SetDCAWithBusMode);
            tabPage2.Controls.Add(button87);
            tabPage2.Controls.Add(textBox_SetVVAAtt);
            tabPage2.Controls.Add(button88);
            tabPage2.Controls.Add(textBox_SetPSUOutput);
            tabPage2.Controls.Add(button69);
            tabPage2.Controls.Add(button68);
            tabPage2.Controls.Add(button67);
            tabPage2.Controls.Add(button66);
            tabPage2.Controls.Add(button65);
            tabPage2.Controls.Add(textBox_SetADCMode);
            tabPage2.Controls.Add(button64);
            tabPage2.Controls.Add(button63);
            tabPage2.Controls.Add(button62);
            tabPage2.Controls.Add(button61);
            tabPage2.Controls.Add(button60);
            tabPage2.Controls.Add(button_GetSystemID);
            tabPage2.Location = new System.Drawing.Point(4, 27);
            tabPage2.Margin = new System.Windows.Forms.Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new System.Drawing.Size(867, 584);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "WB UUT";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox22
            // 
            textBox22.Location = new System.Drawing.Point(230, 566);
            textBox22.Margin = new System.Windows.Forms.Padding(2);
            textBox22.MaxLength = 30;
            textBox22.Name = "textBox22";
            textBox22.Size = new System.Drawing.Size(119, 26);
            textBox22.TabIndex = 77;
            textBox22.Text = "00";
            textBox22.TextChanged += new System.EventHandler(textBox22_TextChanged);
            // 
            // button122
            // 
            button122.Location = new System.Drawing.Point(4, 566);
            button122.Margin = new System.Windows.Forms.Padding(2);
            button122.Name = "button122";
            button122.Size = new System.Drawing.Size(222, 22);
            button122.TabIndex = 76;
            button122.Text = "Erase flash";
            button122.UseVisualStyleBackColor = true;
            button122.Click += new System.EventHandler(button122_Click);
            // 
            // textBox21
            // 
            textBox21.Location = new System.Drawing.Point(231, 537);
            textBox21.Margin = new System.Windows.Forms.Padding(2);
            textBox21.MaxLength = 30;
            textBox21.Name = "textBox21";
            textBox21.Size = new System.Drawing.Size(634, 26);
            textBox21.TabIndex = 75;
            textBox21.Text = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0" +
    "000 0000 0000 0000 0000 0000 ";
            textBox21.TextChanged += new System.EventHandler(textBox21_TextChanged);
            // 
            // button121
            // 
            button121.Location = new System.Drawing.Point(4, 539);
            button121.Margin = new System.Windows.Forms.Padding(2);
            button121.Name = "button121";
            button121.Size = new System.Drawing.Size(222, 22);
            button121.TabIndex = 74;
            button121.Text = "Write Flash";
            button121.UseVisualStyleBackColor = true;
            button121.Click += new System.EventHandler(button121_Click);
            // 
            // textBox20
            // 
            textBox20.Location = new System.Drawing.Point(232, 509);
            textBox20.Margin = new System.Windows.Forms.Padding(2);
            textBox20.MaxLength = 30;
            textBox20.Name = "textBox20";
            textBox20.Size = new System.Drawing.Size(120, 26);
            textBox20.TabIndex = 73;
            textBox20.Text = "0000";
            textBox20.TextChanged += new System.EventHandler(textBox20_TextChanged);
            // 
            // button120
            // 
            button120.Location = new System.Drawing.Point(4, 510);
            button120.Margin = new System.Windows.Forms.Padding(2);
            button120.Name = "button120";
            button120.Size = new System.Drawing.Size(222, 22);
            button120.TabIndex = 72;
            button120.Text = "Read Flash ";
            button120.UseVisualStyleBackColor = true;
            button120.Click += new System.EventHandler(button120_Click);
            // 
            // textBox19
            // 
            textBox19.Location = new System.Drawing.Point(231, 478);
            textBox19.Margin = new System.Windows.Forms.Padding(2);
            textBox19.MaxLength = 30;
            textBox19.Name = "textBox19";
            textBox19.Size = new System.Drawing.Size(634, 26);
            textBox19.TabIndex = 71;
            textBox19.Text = "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0" +
    "000 0000 0000 0000 0000 0000 ";
            textBox19.TextChanged += new System.EventHandler(textBox19_TextChanged);
            // 
            // button119
            // 
            button119.Location = new System.Drawing.Point(4, 482);
            button119.Margin = new System.Windows.Forms.Padding(2);
            button119.Name = "button119";
            button119.Size = new System.Drawing.Size(222, 22);
            button119.TabIndex = 70;
            button119.Text = "Set ADC value in debug mode";
            button119.UseVisualStyleBackColor = true;
            button119.Click += new System.EventHandler(button119_Click);
            // 
            // textBox_ControlCal
            // 
            textBox_ControlCal.Location = new System.Drawing.Point(230, 450);
            textBox_ControlCal.Margin = new System.Windows.Forms.Padding(2);
            textBox_ControlCal.MaxLength = 30;
            textBox_ControlCal.Name = "textBox_ControlCal";
            textBox_ControlCal.Size = new System.Drawing.Size(119, 26);
            textBox_ControlCal.TabIndex = 69;
            textBox_ControlCal.Text = "00";
            textBox_ControlCal.TextChanged += new System.EventHandler(textBox_ControlCal_TextChanged);
            // 
            // button118
            // 
            button118.Location = new System.Drawing.Point(4, 451);
            button118.Margin = new System.Windows.Forms.Padding(2);
            button118.Name = "button118";
            button118.Size = new System.Drawing.Size(222, 22);
            button118.TabIndex = 68;
            button118.Text = "Control CAL_SAR switches ";
            button118.UseVisualStyleBackColor = true;
            button118.Click += new System.EventHandler(button118_Click);
            // 
            // textBox17
            // 
            textBox17.Location = new System.Drawing.Point(230, 422);
            textBox17.Margin = new System.Windows.Forms.Padding(2);
            textBox17.MaxLength = 30;
            textBox17.Name = "textBox17";
            textBox17.Size = new System.Drawing.Size(119, 26);
            textBox17.TabIndex = 67;
            textBox17.Text = "00";
            textBox17.TextChanged += new System.EventHandler(textBox17_TextChanged);
            // 
            // textBox_SetSystemMode
            // 
            textBox_SetSystemMode.Location = new System.Drawing.Point(230, 325);
            textBox_SetSystemMode.Margin = new System.Windows.Forms.Padding(2);
            textBox_SetSystemMode.MaxLength = 30;
            textBox_SetSystemMode.Name = "textBox_SetSystemMode";
            textBox_SetSystemMode.Size = new System.Drawing.Size(143, 26);
            textBox_SetSystemMode.TabIndex = 66;
            textBox_SetSystemMode.Text = "00";
            textBox_SetSystemMode.TextChanged += new System.EventHandler(textBox_Erase4KsectorQSPI_TextChanged);
            // 
            // button_SetSystemMode
            // 
            button_SetSystemMode.Location = new System.Drawing.Point(2, 327);
            button_SetSystemMode.Margin = new System.Windows.Forms.Padding(2);
            button_SetSystemMode.Name = "button_SetSystemMode";
            button_SetSystemMode.Size = new System.Drawing.Size(223, 22);
            button_SetSystemMode.TabIndex = 65;
            button_SetSystemMode.Text = "Set System Mode";
            button_SetSystemMode.UseVisualStyleBackColor = true;
            button_SetSystemMode.Click += new System.EventHandler(button_SetSystemMode_Click);
            button_SetSystemMode.MouseDown += new System.Windows.Forms.MouseEventHandler(button89_MouseDown);
            // 
            // textBox_SetDCAWithBusMode
            // 
            textBox_SetDCAWithBusMode.Location = new System.Drawing.Point(230, 286);
            textBox_SetDCAWithBusMode.Margin = new System.Windows.Forms.Padding(2);
            textBox_SetDCAWithBusMode.MaxLength = 30;
            textBox_SetDCAWithBusMode.Name = "textBox_SetDCAWithBusMode";
            textBox_SetDCAWithBusMode.Size = new System.Drawing.Size(143, 26);
            textBox_SetDCAWithBusMode.TabIndex = 64;
            textBox_SetDCAWithBusMode.Text = "0000";
            textBox_SetDCAWithBusMode.TextChanged += new System.EventHandler(textBox_ReadQSPIFlashData_TextChanged);
            // 
            // button87
            // 
            button87.Location = new System.Drawing.Point(2, 289);
            button87.Margin = new System.Windows.Forms.Padding(2);
            button87.Name = "button87";
            button87.Size = new System.Drawing.Size(223, 22);
            button87.TabIndex = 63;
            button87.Text = "Set DCA with Bus Mode";
            button87.UseVisualStyleBackColor = true;
            button87.Click += new System.EventHandler(button87_Click);
            button87.MouseDown += new System.Windows.Forms.MouseEventHandler(button87_MouseDown);
            // 
            // textBox_SetVVAAtt
            // 
            textBox_SetVVAAtt.Location = new System.Drawing.Point(230, 254);
            textBox_SetVVAAtt.Margin = new System.Windows.Forms.Padding(2);
            textBox_SetVVAAtt.MaxLength = 30;
            textBox_SetVVAAtt.Name = "textBox_SetVVAAtt";
            textBox_SetVVAAtt.Size = new System.Drawing.Size(143, 26);
            textBox_SetVVAAtt.TabIndex = 62;
            textBox_SetVVAAtt.Text = "0000";
            textBox_SetVVAAtt.TextChanged += new System.EventHandler(textBox_WriteQSPIFlashData_TextChanged);
            // 
            // button88
            // 
            button88.Location = new System.Drawing.Point(2, 257);
            button88.Margin = new System.Windows.Forms.Padding(2);
            button88.Name = "button88";
            button88.Size = new System.Drawing.Size(223, 22);
            button88.TabIndex = 61;
            button88.Text = "Set VVA Attenuation";
            button88.UseVisualStyleBackColor = true;
            button88.Click += new System.EventHandler(button88_Click);
            button88.MouseDown += new System.Windows.Forms.MouseEventHandler(button88_MouseDown);
            // 
            // textBox_SetPSUOutput
            // 
            textBox_SetPSUOutput.Location = new System.Drawing.Point(230, 224);
            textBox_SetPSUOutput.Margin = new System.Windows.Forms.Padding(2);
            textBox_SetPSUOutput.MaxLength = 30;
            textBox_SetPSUOutput.Name = "textBox_SetPSUOutput";
            textBox_SetPSUOutput.Size = new System.Drawing.Size(143, 26);
            textBox_SetPSUOutput.TabIndex = 54;
            textBox_SetPSUOutput.Text = "0000 0000 0000 0000";
            textBox_SetPSUOutput.TextChanged += new System.EventHandler(textBox_SetTCXOTrim_TextChanged);
            // 
            // button69
            // 
            button69.Location = new System.Drawing.Point(2, 226);
            button69.Margin = new System.Windows.Forms.Padding(2);
            button69.Name = "button69";
            button69.Size = new System.Drawing.Size(223, 22);
            button69.TabIndex = 53;
            button69.Text = "Set PSU Output Voltage";
            button69.UseVisualStyleBackColor = true;
            button69.Click += new System.EventHandler(button69_Click);
            button69.MouseDown += new System.Windows.Forms.MouseEventHandler(button69_MouseDown);
            // 
            // button68
            // 
            button68.Location = new System.Drawing.Point(2, 194);
            button68.Margin = new System.Windows.Forms.Padding(2);
            button68.Name = "button68";
            button68.Size = new System.Drawing.Size(223, 22);
            button68.TabIndex = 50;
            button68.Text = "Get Discrete Status – Bus mode";
            button68.UseVisualStyleBackColor = true;
            button68.Click += new System.EventHandler(button68_Click);
            button68.MouseDown += new System.Windows.Forms.MouseEventHandler(button68_MouseDown);
            // 
            // button67
            // 
            button67.Location = new System.Drawing.Point(2, 161);
            button67.Margin = new System.Windows.Forms.Padding(2);
            button67.Name = "button67";
            button67.Size = new System.Drawing.Size(223, 22);
            button67.TabIndex = 49;
            button67.Text = "Get Status";
            button67.UseVisualStyleBackColor = true;
            button67.Click += new System.EventHandler(button67_Click);
            button67.MouseDown += new System.Windows.Forms.MouseEventHandler(button67_MouseDown);
            // 
            // button66
            // 
            button66.Location = new System.Drawing.Point(2, 130);
            button66.Margin = new System.Windows.Forms.Padding(2);
            button66.Name = "button66";
            button66.Size = new System.Drawing.Size(223, 22);
            button66.TabIndex = 46;
            button66.Text = "Get Serial Number";
            button66.UseVisualStyleBackColor = true;
            button66.Click += new System.EventHandler(button66_Click);
            button66.MouseDown += new System.Windows.Forms.MouseEventHandler(button66_MouseDown);
            // 
            // button65
            // 
            button65.Location = new System.Drawing.Point(4, 423);
            button65.Margin = new System.Windows.Forms.Padding(2);
            button65.Name = "button65";
            button65.Size = new System.Drawing.Size(222, 22);
            button65.TabIndex = 45;
            button65.Text = "Set DC4 mode ON and OFF";
            button65.UseVisualStyleBackColor = true;
            button65.Click += new System.EventHandler(button65_Click);
            button65.MouseDown += new System.Windows.Forms.MouseEventHandler(button65_MouseDown);
            // 
            // textBox_SetADCMode
            // 
            textBox_SetADCMode.Location = new System.Drawing.Point(232, 365);
            textBox_SetADCMode.Margin = new System.Windows.Forms.Padding(2);
            textBox_SetADCMode.MaxLength = 30;
            textBox_SetADCMode.Name = "textBox_SetADCMode";
            textBox_SetADCMode.Size = new System.Drawing.Size(141, 26);
            textBox_SetADCMode.TabIndex = 43;
            textBox_SetADCMode.Text = "0000";
            textBox_SetADCMode.TextChanged += new System.EventHandler(textBox_SetSyestemState_TextChanged);
            // 
            // button64
            // 
            button64.Location = new System.Drawing.Point(4, 366);
            button64.Margin = new System.Windows.Forms.Padding(2);
            button64.Name = "button64";
            button64.Size = new System.Drawing.Size(222, 22);
            button64.TabIndex = 42;
            button64.Text = "Set ADC System Mode";
            button64.UseVisualStyleBackColor = true;
            button64.Click += new System.EventHandler(button64_Click);
            button64.MouseDown += new System.Windows.Forms.MouseEventHandler(button64_MouseDown);
            // 
            // button63
            // 
            button63.Location = new System.Drawing.Point(4, 395);
            button63.Margin = new System.Windows.Forms.Padding(2);
            button63.Name = "button63";
            button63.Size = new System.Drawing.Size(222, 22);
            button63.TabIndex = 41;
            button63.Text = "Get System Table Indexes";
            button63.UseVisualStyleBackColor = true;
            button63.Click += new System.EventHandler(button63_Click);
            button63.MouseDown += new System.Windows.Forms.MouseEventHandler(button63_MouseDown);
            // 
            // button62
            // 
            button62.Location = new System.Drawing.Point(2, 100);
            button62.Margin = new System.Windows.Forms.Padding(2);
            button62.Name = "button62";
            button62.Size = new System.Drawing.Size(223, 22);
            button62.TabIndex = 38;
            button62.Text = "Get Hardware Version";
            button62.UseVisualStyleBackColor = true;
            button62.Click += new System.EventHandler(button62_Click);
            button62.MouseDown += new System.Windows.Forms.MouseEventHandler(button62_MouseDown);
            // 
            // button61
            // 
            button61.Location = new System.Drawing.Point(2, 70);
            button61.Margin = new System.Windows.Forms.Padding(2);
            button61.Name = "button61";
            button61.Size = new System.Drawing.Size(223, 22);
            button61.TabIndex = 35;
            button61.Text = "Get Firmware Version";
            button61.UseVisualStyleBackColor = true;
            button61.Click += new System.EventHandler(button61_Click);
            button61.MouseDown += new System.Windows.Forms.MouseEventHandler(button61_MouseDown);
            // 
            // button60
            // 
            button60.Location = new System.Drawing.Point(2, 41);
            button60.Margin = new System.Windows.Forms.Padding(2);
            button60.Name = "button60";
            button60.Size = new System.Drawing.Size(223, 22);
            button60.TabIndex = 32;
            button60.Text = "Get Software Version";
            button60.UseVisualStyleBackColor = true;
            button60.Click += new System.EventHandler(button60_Click);
            button60.MouseDown += new System.Windows.Forms.MouseEventHandler(button60_MouseDown);
            // 
            // button_GetSystemID
            // 
            button_GetSystemID.Location = new System.Drawing.Point(2, 10);
            button_GetSystemID.Margin = new System.Windows.Forms.Padding(2);
            button_GetSystemID.Name = "button_GetSystemID";
            button_GetSystemID.Size = new System.Drawing.Size(223, 22);
            button_GetSystemID.TabIndex = 29;
            button_GetSystemID.Text = "Get ID";
            button_GetSystemID.UseVisualStyleBackColor = true;
            button_GetSystemID.Click += new System.EventHandler(button59_Click);
            button_GetSystemID.MouseClick += new System.Windows.Forms.MouseEventHandler(button59_MouseClick);
            button_GetSystemID.MouseDown += new System.Windows.Forms.MouseEventHandler(button59_MouseDown);
            // 
            // groupBox32
            // 
            groupBox32.Controls.Add(richTextBox_SSPA);
            groupBox32.Controls.Add(checkBox_RecordMiniAda);
            groupBox32.Controls.Add(checkBox_PauseMiniAda);
            groupBox32.Controls.Add(button_ClearMiniAda);
            groupBox32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox32.Location = new System.Drawing.Point(901, 3);
            groupBox32.Margin = new System.Windows.Forms.Padding(2);
            groupBox32.Name = "groupBox32";
            groupBox32.Padding = new System.Windows.Forms.Padding(2);
            groupBox32.Size = new System.Drawing.Size(510, 646);
            groupBox32.TabIndex = 9;
            groupBox32.TabStop = false;
            groupBox32.Text = "SSPA Monitor";
            // 
            // richTextBox_SSPA
            // 
            richTextBox_SSPA.BackColor = System.Drawing.Color.LightGray;
            richTextBox_SSPA.EnableAutoDragDrop = true;
            richTextBox_SSPA.Location = new System.Drawing.Point(6, 17);
            richTextBox_SSPA.Margin = new System.Windows.Forms.Padding(2);
            richTextBox_SSPA.Name = "richTextBox_SSPA";
            richTextBox_SSPA.Size = new System.Drawing.Size(506, 588);
            richTextBox_SSPA.TabIndex = 0;
            richTextBox_SSPA.Text = "";
            // 
            // checkBox_RecordMiniAda
            // 
            checkBox_RecordMiniAda.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_RecordMiniAda.AutoSize = true;
            checkBox_RecordMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_RecordMiniAda.Location = new System.Drawing.Point(6, 610);
            checkBox_RecordMiniAda.Margin = new System.Windows.Forms.Padding(2);
            checkBox_RecordMiniAda.Name = "checkBox_RecordMiniAda";
            checkBox_RecordMiniAda.Size = new System.Drawing.Size(99, 26);
            checkBox_RecordMiniAda.TabIndex = 7;
            checkBox_RecordMiniAda.Text = "Record Log";
            checkBox_RecordMiniAda.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseMiniAda
            // 
            checkBox_PauseMiniAda.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_PauseMiniAda.AutoSize = true;
            checkBox_PauseMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_PauseMiniAda.Location = new System.Drawing.Point(102, 610);
            checkBox_PauseMiniAda.Margin = new System.Windows.Forms.Padding(2);
            checkBox_PauseMiniAda.Name = "checkBox_PauseMiniAda";
            checkBox_PauseMiniAda.Size = new System.Drawing.Size(62, 26);
            checkBox_PauseMiniAda.TabIndex = 5;
            checkBox_PauseMiniAda.Text = "Pause";
            checkBox_PauseMiniAda.UseVisualStyleBackColor = true;
            // 
            // button_ClearMiniAda
            // 
            button_ClearMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button_ClearMiniAda.Location = new System.Drawing.Point(165, 610);
            button_ClearMiniAda.Margin = new System.Windows.Forms.Padding(2);
            button_ClearMiniAda.Name = "button_ClearMiniAda";
            button_ClearMiniAda.Size = new System.Drawing.Size(57, 25);
            button_ClearMiniAda.TabIndex = 6;
            button_ClearMiniAda.Text = "Clear";
            button_ClearMiniAda.UseVisualStyleBackColor = true;
            // 
            // tabPage3038WBPAA
            // 
            tabPage3038WBPAA.Controls.Add(groupBox43);
            tabPage3038WBPAA.Location = new System.Drawing.Point(4, 27);
            tabPage3038WBPAA.Margin = new System.Windows.Forms.Padding(2);
            tabPage3038WBPAA.Name = "tabPage3038WBPAA";
            tabPage3038WBPAA.Size = new System.Drawing.Size(1414, 659);
            tabPage3038WBPAA.TabIndex = 12;
            tabPage3038WBPAA.Text = "3038 - WB PAA";
            tabPage3038WBPAA.UseVisualStyleBackColor = true;
            // 
            // groupBox43
            // 
            groupBox43.Controls.Add(groupBox48);
            groupBox43.Controls.Add(groupBox38);
            groupBox43.Controls.Add(tabControl1);
            groupBox43.Location = new System.Drawing.Point(2, 8);
            groupBox43.Margin = new System.Windows.Forms.Padding(2);
            groupBox43.Name = "groupBox43";
            groupBox43.Padding = new System.Windows.Forms.Padding(2);
            groupBox43.Size = new System.Drawing.Size(1410, 646);
            groupBox43.TabIndex = 0;
            groupBox43.TabStop = false;
            groupBox43.Text = "3038 - WB PAA";
            // 
            // groupBox48
            // 
            groupBox48.Controls.Add(button6);
            groupBox48.Controls.Add(button29);
            groupBox48.Location = new System.Drawing.Point(1248, 184);
            groupBox48.Margin = new System.Windows.Forms.Padding(2);
            groupBox48.Name = "groupBox48";
            groupBox48.Padding = new System.Windows.Forms.Padding(2);
            groupBox48.Size = new System.Drawing.Size(141, 130);
            groupBox48.TabIndex = 23;
            groupBox48.TabStop = false;
            groupBox48.Text = "CSV file";
            // 
            // button6
            // 
            button6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button6.Location = new System.Drawing.Point(6, 22);
            button6.Margin = new System.Windows.Forms.Padding(2);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(127, 43);
            button6.TabIndex = 18;
            button6.Text = "Read CSV file";
            button6.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            button29.BackColor = System.Drawing.Color.Transparent;
            button29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button29.Location = new System.Drawing.Point(6, 77);
            button29.Margin = new System.Windows.Forms.Padding(2);
            button29.Name = "button29";
            button29.Size = new System.Drawing.Size(127, 43);
            button29.TabIndex = 21;
            button29.Text = "Write CSV file";
            button29.UseVisualStyleBackColor = false;
            // 
            // groupBox38
            // 
            groupBox38.Controls.Add(button2);
            groupBox38.Controls.Add(button30);
            groupBox38.Location = new System.Drawing.Point(1248, 42);
            groupBox38.Margin = new System.Windows.Forms.Padding(2);
            groupBox38.Name = "groupBox38";
            groupBox38.Padding = new System.Windows.Forms.Padding(2);
            groupBox38.Size = new System.Drawing.Size(141, 130);
            groupBox38.TabIndex = 22;
            groupBox38.TabStop = false;
            groupBox38.Text = "Flash";
            // 
            // button2
            // 
            button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button2.Location = new System.Drawing.Point(6, 22);
            button2.Margin = new System.Windows.Forms.Padding(2);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(127, 43);
            button2.TabIndex = 18;
            button2.Text = "Read all from flash ";
            button2.UseVisualStyleBackColor = true;
            // 
            // button30
            // 
            button30.BackColor = System.Drawing.Color.Transparent;
            button30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button30.Location = new System.Drawing.Point(6, 77);
            button30.Margin = new System.Windows.Forms.Padding(2);
            button30.Name = "button30";
            button30.Size = new System.Drawing.Size(127, 43);
            button30.TabIndex = 21;
            button30.Text = "Write all to flash";
            button30.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Controls.Add(tabPage13);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Controls.Add(tabPage8);
            tabControl1.Controls.Add(tabPage9);
            tabControl1.Location = new System.Drawing.Point(5, 17);
            tabControl1.Margin = new System.Windows.Forms.Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1242, 623);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += new System.EventHandler(tabControl1_SelectedIndexChanged);
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(groupBox49);
            tabPage6.Controls.Add(groupBox37);
            tabPage6.Controls.Add(button71);
            tabPage6.Controls.Add(groupBox47);
            tabPage6.Controls.Add(groupBox35);
            tabPage6.Controls.Add(groupBox46);
            tabPage6.Controls.Add(groupBox45);
            tabPage6.Controls.Add(groupBox34);
            tabPage6.Controls.Add(groupBox44);
            tabPage6.Controls.Add(groupBox1);
            tabPage6.Controls.Add(groupBox33);
            tabPage6.Location = new System.Drawing.Point(4, 27);
            tabPage6.Margin = new System.Windows.Forms.Padding(2);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new System.Windows.Forms.Padding(2);
            tabPage6.Size = new System.Drawing.Size(1234, 592);
            tabPage6.TabIndex = 0;
            tabPage6.Text = "Main";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox49
            // 
            groupBox49.Controls.Add(label123);
            groupBox49.Controls.Add(button_SystemMode);
            groupBox49.Controls.Add(textBox_SystemMode);
            groupBox49.Location = new System.Drawing.Point(663, 120);
            groupBox49.Name = "groupBox49";
            groupBox49.Size = new System.Drawing.Size(200, 90);
            groupBox49.TabIndex = 31;
            groupBox49.TabStop = false;
            groupBox49.Text = "System mode";
            // 
            // button_SystemMode
            // 
            button_SystemMode.Location = new System.Drawing.Point(6, 58);
            button_SystemMode.Name = "button_SystemMode";
            button_SystemMode.Size = new System.Drawing.Size(124, 23);
            button_SystemMode.TabIndex = 32;
            button_SystemMode.Text = "Set System mode";
            button_SystemMode.UseVisualStyleBackColor = true;
            button_SystemMode.Click += new System.EventHandler(button_SystemMode_Click);
            // 
            // textBox_SystemMode
            // 
            textBox_SystemMode.Location = new System.Drawing.Point(136, 57);
            textBox_SystemMode.MaxLength = 2;
            textBox_SystemMode.Name = "textBox_SystemMode";
            textBox_SystemMode.Size = new System.Drawing.Size(56, 26);
            textBox_SystemMode.TabIndex = 31;
            textBox_SystemMode.Text = "00";
            textBox_SystemMode.TextChanged += new System.EventHandler(textBox_SystemMode_TextChanged);
            // 
            // groupBox37
            // 
            groupBox37.Controls.Add(checkBox4);
            groupBox37.Controls.Add(checkBox3);
            groupBox37.Controls.Add(checkBox9);
            groupBox37.Controls.Add(checkBox2);
            groupBox37.Controls.Add(button73);
            groupBox37.Controls.Add(label114);
            groupBox37.Controls.Add(label113);
            groupBox37.Controls.Add(label112);
            groupBox37.Controls.Add(textBox_CALSAR);
            groupBox37.Controls.Add(label111);
            groupBox37.Controls.Add(label110);
            groupBox37.Controls.Add(textBox82);
            groupBox37.Controls.Add(label107);
            groupBox37.Controls.Add(textBox83);
            groupBox37.Controls.Add(label108);
            groupBox37.Controls.Add(textBox84);
            groupBox37.Controls.Add(label109);
            groupBox37.Location = new System.Drawing.Point(876, 330);
            groupBox37.Margin = new System.Windows.Forms.Padding(2);
            groupBox37.Name = "groupBox37";
            groupBox37.Padding = new System.Windows.Forms.Padding(2);
            groupBox37.Size = new System.Drawing.Size(354, 192);
            groupBox37.TabIndex = 17;
            groupBox37.TabStop = false;
            // 
            // checkBox4
            // 
            checkBox4.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox4.AutoSize = true;
            checkBox4.Location = new System.Drawing.Point(174, 113);
            checkBox4.Margin = new System.Windows.Forms.Padding(2);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new System.Drawing.Size(36, 28);
            checkBox4.TabIndex = 28;
            checkBox4.Text = "On";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += new System.EventHandler(checkBox4_CheckedChanged_1);
            // 
            // checkBox3
            // 
            checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(96, 112);
            checkBox3.Margin = new System.Windows.Forms.Padding(2);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(36, 28);
            checkBox3.TabIndex = 27;
            checkBox3.Text = "On";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += new System.EventHandler(checkBox3_CheckedChanged_1);
            // 
            // checkBox9
            // 
            checkBox9.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox9.AutoSize = true;
            checkBox9.Location = new System.Drawing.Point(18, 112);
            checkBox9.Margin = new System.Windows.Forms.Padding(2);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new System.Drawing.Size(36, 28);
            checkBox9.TabIndex = 26;
            checkBox9.Text = "On";
            checkBox9.UseVisualStyleBackColor = true;
            checkBox9.CheckedChanged += new System.EventHandler(checkBox9_CheckedChanged);
            // 
            // checkBox2
            // 
            checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox2.AutoSize = true;
            checkBox2.Location = new System.Drawing.Point(232, 54);
            checkBox2.Margin = new System.Windows.Forms.Padding(2);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(36, 28);
            checkBox2.TabIndex = 20;
            checkBox2.Text = "On";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged_1);
            // 
            // button73
            // 
            button73.BackColor = System.Drawing.SystemColors.Highlight;
            button73.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button73.Location = new System.Drawing.Point(233, 98);
            button73.Margin = new System.Windows.Forms.Padding(2);
            button73.Name = "button73";
            button73.Size = new System.Drawing.Size(107, 39);
            button73.TabIndex = 17;
            button73.Text = "Strobe";
            button73.UseVisualStyleBackColor = false;
            button73.Click += new System.EventHandler(button73_Click_3);
            // 
            // label114
            // 
            label114.AutoSize = true;
            label114.Location = new System.Drawing.Point(158, 90);
            label114.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label114.Name = "label114";
            label114.Size = new System.Drawing.Size(63, 18);
            label114.TabIndex = 24;
            label114.Text = "Preserve";
            // 
            // label113
            // 
            label113.AutoSize = true;
            label113.Location = new System.Drawing.Point(82, 90);
            label113.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label113.Name = "label113";
            label113.Size = new System.Drawing.Size(72, 18);
            label113.TabIndex = 22;
            label113.Text = "OVT check";
            // 
            // label112
            // 
            label112.AutoSize = true;
            label112.Location = new System.Drawing.Point(4, 90);
            label112.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label112.Name = "label112";
            label112.Size = new System.Drawing.Size(81, 18);
            label112.TabIndex = 20;
            label112.Text = "SEU recover";
            // 
            // textBox_CALSAR
            // 
            textBox_CALSAR.Location = new System.Drawing.Point(286, 55);
            textBox_CALSAR.Margin = new System.Windows.Forms.Padding(2);
            textBox_CALSAR.Name = "textBox_CALSAR";
            textBox_CALSAR.Size = new System.Drawing.Size(53, 26);
            textBox_CALSAR.TabIndex = 19;
            textBox_CALSAR.Text = "0";
            textBox_CALSAR.TextChanged += new System.EventHandler(textBox_CALSAR_TextChanged);
            textBox_CALSAR.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_CALSAR_KeyDown);
            // 
            // label111
            // 
            label111.AutoSize = true;
            label111.Location = new System.Drawing.Point(282, 30);
            label111.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label111.Name = "label111";
            label111.Size = new System.Drawing.Size(58, 18);
            label111.TabIndex = 18;
            label111.Text = "CAL SAR";
            // 
            // label110
            // 
            label110.AutoSize = true;
            label110.Location = new System.Drawing.Point(233, 30);
            label110.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label110.Name = "label110";
            label110.Size = new System.Drawing.Size(32, 18);
            label110.TabIndex = 16;
            label110.Text = "DC4";
            // 
            // textBox82
            // 
            textBox82.Location = new System.Drawing.Point(165, 55);
            textBox82.Margin = new System.Windows.Forms.Padding(2);
            textBox82.Name = "textBox82";
            textBox82.Size = new System.Drawing.Size(53, 26);
            textBox82.TabIndex = 15;
            textBox82.Text = "0";
            textBox82.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox82_KeyDown);
            // 
            // label107
            // 
            label107.AutoSize = true;
            label107.Location = new System.Drawing.Point(162, 30);
            label107.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label107.Name = "label107";
            label107.Size = new System.Drawing.Size(50, 18);
            label107.TabIndex = 14;
            label107.Text = "ATT bit";
            // 
            // textBox83
            // 
            textBox83.Location = new System.Drawing.Point(87, 55);
            textBox83.Margin = new System.Windows.Forms.Padding(2);
            textBox83.Name = "textBox83";
            textBox83.Size = new System.Drawing.Size(53, 26);
            textBox83.TabIndex = 13;
            textBox83.Text = "0";
            textBox83.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox83_KeyDown);
            // 
            // label108
            // 
            label108.AutoSize = true;
            label108.Location = new System.Drawing.Point(89, 29);
            label108.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label108.Name = "label108";
            label108.Size = new System.Drawing.Size(42, 18);
            label108.TabIndex = 12;
            label108.Text = "FT bit";
            // 
            // textBox84
            // 
            textBox84.Location = new System.Drawing.Point(18, 55);
            textBox84.Margin = new System.Windows.Forms.Padding(2);
            textBox84.Name = "textBox84";
            textBox84.Size = new System.Drawing.Size(53, 26);
            textBox84.TabIndex = 11;
            textBox84.Text = "0";
            textBox84.TextChanged += new System.EventHandler(textBox84_TextChanged);
            textBox84.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox84_KeyDown);
            // 
            // label109
            // 
            label109.AutoSize = true;
            label109.Location = new System.Drawing.Point(12, 30);
            label109.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label109.Name = "label109";
            label109.Size = new System.Drawing.Size(56, 18);
            label109.TabIndex = 1;
            label109.Text = "Freq bit";
            // 
            // button71
            // 
            button71.Location = new System.Drawing.Point(552, 184);
            button71.Margin = new System.Windows.Forms.Padding(2);
            button71.Name = "button71";
            button71.Size = new System.Drawing.Size(97, 22);
            button71.TabIndex = 16;
            button71.Text = "Save CSV";
            button71.UseVisualStyleBackColor = true;
            button71.Click += new System.EventHandler(button71_Click);
            // 
            // groupBox47
            // 
            groupBox47.Controls.Add(label103);
            groupBox47.Controls.Add(button74);
            groupBox47.Controls.Add(textBox_StatusUUT32);
            groupBox47.Controls.Add(button_GetStatus);
            groupBox47.Controls.Add(label104);
            groupBox47.Controls.Add(label105);
            groupBox47.Controls.Add(textBox_StatusUUT25);
            groupBox47.Controls.Add(textBox_StatusUUT31);
            groupBox47.Controls.Add(label69);
            groupBox47.Controls.Add(label106);
            groupBox47.Controls.Add(label120);
            groupBox47.Controls.Add(textBox_StatusUUT30);
            groupBox47.Controls.Add(textBox_StatusUUT26);
            groupBox47.Controls.Add(label118);
            groupBox47.Controls.Add(textBox_StatusUUT23);
            groupBox47.Controls.Add(textBox_StatusUUT29);
            groupBox47.Controls.Add(label56);
            groupBox47.Controls.Add(label119);
            groupBox47.Controls.Add(textBox_StatusUUT24);
            groupBox47.Controls.Add(textBox_StatusUUT27);
            groupBox47.Controls.Add(textBox_StatusUUT12);
            groupBox47.Controls.Add(textBox_StatusUUT28);
            groupBox47.Controls.Add(label57);
            groupBox47.Controls.Add(label67);
            groupBox47.Controls.Add(textBox_StatusUUT22);
            groupBox47.Controls.Add(label58);
            groupBox47.Controls.Add(label70);
            groupBox47.Controls.Add(textBox_StatusUUT21);
            groupBox47.Controls.Add(label59);
            groupBox47.Controls.Add(textBox_StatusUUT20);
            groupBox47.Controls.Add(label60);
            groupBox47.Controls.Add(textBox_StatusUUT19);
            groupBox47.Controls.Add(label61);
            groupBox47.Controls.Add(textBox_StatusUUT18);
            groupBox47.Controls.Add(label62);
            groupBox47.Controls.Add(textBox_StatusUUT17);
            groupBox47.Controls.Add(label63);
            groupBox47.Controls.Add(textBox_StatusUUT16);
            groupBox47.Controls.Add(label64);
            groupBox47.Controls.Add(textBox_StatusUUT15);
            groupBox47.Controls.Add(label65);
            groupBox47.Controls.Add(textBox_StatusUUT14);
            groupBox47.Controls.Add(label66);
            groupBox47.Controls.Add(textBox_StatusUUT13);
            groupBox47.Controls.Add(label55);
            groupBox47.Controls.Add(textBox_StatusUUT1);
            groupBox47.Controls.Add(label54);
            groupBox47.Controls.Add(textBox_StatusUUT11);
            groupBox47.Controls.Add(label53);
            groupBox47.Controls.Add(textBox_StatusUUT10);
            groupBox47.Controls.Add(label52);
            groupBox47.Controls.Add(textBox_StatusUUT9);
            groupBox47.Controls.Add(label51);
            groupBox47.Controls.Add(textBox_StatusUUT8);
            groupBox47.Controls.Add(label50);
            groupBox47.Controls.Add(textBox_StatusUUT7);
            groupBox47.Controls.Add(label49);
            groupBox47.Controls.Add(textBox_StatusUUT6);
            groupBox47.Controls.Add(label40);
            groupBox47.Controls.Add(textBox_StatusUUT5);
            groupBox47.Controls.Add(label39);
            groupBox47.Controls.Add(textBox_StatusUUT4);
            groupBox47.Controls.Add(label33);
            groupBox47.Controls.Add(textBox_StatusUUT3);
            groupBox47.Controls.Add(label32);
            groupBox47.Controls.Add(textBox_StatusUUT2);
            groupBox47.Controls.Add(groupBox39);
            groupBox47.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox47.Location = new System.Drawing.Point(6, 209);
            groupBox47.Margin = new System.Windows.Forms.Padding(2);
            groupBox47.Name = "groupBox47";
            groupBox47.Padding = new System.Windows.Forms.Padding(2);
            groupBox47.Size = new System.Drawing.Size(857, 379);
            groupBox47.TabIndex = 15;
            groupBox47.TabStop = false;
            groupBox47.Text = " Status UUT";
            // 
            // label103
            // 
            label103.AutoSize = true;
            label103.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label103.ForeColor = System.Drawing.Color.Black;
            label103.Location = new System.Drawing.Point(425, 172);
            label103.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label103.Name = "label103";
            label103.Size = new System.Drawing.Size(105, 19);
            label103.TabIndex = 87;
            label103.Text = "Tx OVT hazard";
            // 
            // button74
            // 
            button74.Location = new System.Drawing.Point(757, 330);
            button74.Margin = new System.Windows.Forms.Padding(2);
            button74.Name = "button74";
            button74.Size = new System.Drawing.Size(97, 43);
            button74.TabIndex = 77;
            button74.Text = "Clear";
            button74.UseVisualStyleBackColor = true;
            button74.Click += new System.EventHandler(button74_Click_1);
            // 
            // textBox_StatusUUT32
            // 
            textBox_StatusUUT32.Location = new System.Drawing.Point(538, 169);
            textBox_StatusUUT32.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT32.Name = "textBox_StatusUUT32";
            textBox_StatusUUT32.ReadOnly = true;
            textBox_StatusUUT32.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT32.TabIndex = 86;
            textBox_StatusUUT32.TextChanged += new System.EventHandler(textBox_StatusUUT32_TextChanged);
            // 
            // button_GetStatus
            // 
            button_GetStatus.Location = new System.Drawing.Point(652, 330);
            button_GetStatus.Margin = new System.Windows.Forms.Padding(2);
            button_GetStatus.Name = "button_GetStatus";
            button_GetStatus.Size = new System.Drawing.Size(97, 43);
            button_GetStatus.TabIndex = 17;
            button_GetStatus.Text = "Get Status";
            button_GetStatus.UseVisualStyleBackColor = true;
            button_GetStatus.Click += new System.EventHandler(button_GetStatus_Click);
            // 
            // label104
            // 
            label104.AutoSize = true;
            label104.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label104.ForeColor = System.Drawing.Color.Black;
            label104.Location = new System.Drawing.Point(441, 18);
            label104.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label104.Name = "label104";
            label104.Size = new System.Drawing.Size(51, 19);
            label104.TabIndex = 80;
            label104.Text = "Ready";
            // 
            // label105
            // 
            label105.AutoSize = true;
            label105.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label105.ForeColor = System.Drawing.Color.Black;
            label105.Location = new System.Drawing.Point(441, 142);
            label105.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label105.Name = "label105";
            label105.Size = new System.Drawing.Size(35, 19);
            label105.TabIndex = 85;
            label105.Text = "SEU";
            // 
            // textBox_StatusUUT25
            // 
            textBox_StatusUUT25.Location = new System.Drawing.Point(538, 262);
            textBox_StatusUUT25.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT25.Name = "textBox_StatusUUT25";
            textBox_StatusUUT25.ReadOnly = true;
            textBox_StatusUUT25.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT25.TabIndex = 57;
            textBox_StatusUUT25.TextChanged += new System.EventHandler(textBox_StatusUUT25_TextChanged);
            // 
            // textBox_StatusUUT31
            // 
            textBox_StatusUUT31.Location = new System.Drawing.Point(538, 139);
            textBox_StatusUUT31.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT31.Name = "textBox_StatusUUT31";
            textBox_StatusUUT31.ReadOnly = true;
            textBox_StatusUUT31.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT31.TabIndex = 84;
            textBox_StatusUUT31.TextChanged += new System.EventHandler(textBox_StatusUUT31_TextChanged);
            // 
            // label69
            // 
            label69.AutoSize = true;
            label69.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label69.ForeColor = System.Drawing.Color.Black;
            label69.Location = new System.Drawing.Point(446, 268);
            label69.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label69.Name = "label69";
            label69.Size = new System.Drawing.Size(76, 19);
            label69.TabIndex = 58;
            label69.Text = "DC1 value";
            // 
            // label106
            // 
            label106.AutoSize = true;
            label106.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label106.ForeColor = System.Drawing.Color.Black;
            label106.Location = new System.Drawing.Point(441, 113);
            label106.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label106.Name = "label106";
            label106.Size = new System.Drawing.Size(81, 19);
            label106.TabIndex = 83;
            label106.Text = "Protection";
            // 
            // label120
            // 
            label120.AutoSize = true;
            label120.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label120.ForeColor = System.Drawing.Color.Black;
            label120.Location = new System.Drawing.Point(241, 351);
            label120.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label120.Name = "label120";
            label120.Size = new System.Drawing.Size(90, 19);
            label120.TabIndex = 75;
            label120.Text = "CAL SAR BIT";
            // 
            // textBox_StatusUUT30
            // 
            textBox_StatusUUT30.Location = new System.Drawing.Point(538, 106);
            textBox_StatusUUT30.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT30.Name = "textBox_StatusUUT30";
            textBox_StatusUUT30.ReadOnly = true;
            textBox_StatusUUT30.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT30.TabIndex = 82;
            textBox_StatusUUT30.TextChanged += new System.EventHandler(textBox_StatusUUT30_TextChanged);
            // 
            // textBox_StatusUUT26
            // 
            textBox_StatusUUT26.Location = new System.Drawing.Point(538, 295);
            textBox_StatusUUT26.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT26.Name = "textBox_StatusUUT26";
            textBox_StatusUUT26.ReadOnly = true;
            textBox_StatusUUT26.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT26.TabIndex = 59;
            textBox_StatusUUT26.TextChanged += new System.EventHandler(textBox_StatusUUT26_TextChanged);
            // 
            // label118
            // 
            label118.AutoSize = true;
            label118.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label118.ForeColor = System.Drawing.Color.Black;
            label118.Location = new System.Drawing.Point(431, 79);
            label118.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label118.Name = "label118";
            label118.Size = new System.Drawing.Size(97, 19);
            label118.TabIndex = 81;
            label118.Text = "Over voltage";
            // 
            // textBox_StatusUUT23
            // 
            textBox_StatusUUT23.Location = new System.Drawing.Point(332, 351);
            textBox_StatusUUT23.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT23.Name = "textBox_StatusUUT23";
            textBox_StatusUUT23.ReadOnly = true;
            textBox_StatusUUT23.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT23.TabIndex = 74;
            textBox_StatusUUT23.TextChanged += new System.EventHandler(textBox_StatusUUT23_TextChanged);
            // 
            // textBox_StatusUUT29
            // 
            textBox_StatusUUT29.Location = new System.Drawing.Point(538, 75);
            textBox_StatusUUT29.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT29.Name = "textBox_StatusUUT29";
            textBox_StatusUUT29.ReadOnly = true;
            textBox_StatusUUT29.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT29.TabIndex = 76;
            textBox_StatusUUT29.TextChanged += new System.EventHandler(textBox_StatusUUT29_TextChanged);
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label56.ForeColor = System.Drawing.Color.Black;
            label56.Location = new System.Drawing.Point(239, 14);
            label56.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label56.Name = "label56";
            label56.Size = new System.Drawing.Size(85, 19);
            label56.TabIndex = 56;
            label56.Text = "PRM_temp";
            // 
            // label119
            // 
            label119.AutoSize = true;
            label119.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label119.ForeColor = System.Drawing.Color.Black;
            label119.Location = new System.Drawing.Point(429, 46);
            label119.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label119.Name = "label119";
            label119.Size = new System.Drawing.Size(106, 19);
            label119.TabIndex = 77;
            label119.Text = "Under voltage";
            // 
            // textBox_StatusUUT24
            // 
            textBox_StatusUUT24.Location = new System.Drawing.Point(538, 233);
            textBox_StatusUUT24.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT24.Name = "textBox_StatusUUT24";
            textBox_StatusUUT24.ReadOnly = true;
            textBox_StatusUUT24.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT24.TabIndex = 61;
            textBox_StatusUUT24.TextChanged += new System.EventHandler(textBox_StatusUUT24_TextChanged);
            // 
            // textBox_StatusUUT27
            // 
            textBox_StatusUUT27.Location = new System.Drawing.Point(538, 14);
            textBox_StatusUUT27.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT27.Name = "textBox_StatusUUT27";
            textBox_StatusUUT27.ReadOnly = true;
            textBox_StatusUUT27.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT27.TabIndex = 79;
            textBox_StatusUUT27.TextChanged += new System.EventHandler(textBox_StatusUUT27_TextChanged);
            // 
            // textBox_StatusUUT12
            // 
            textBox_StatusUUT12.Location = new System.Drawing.Point(332, 9);
            textBox_StatusUUT12.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT12.Name = "textBox_StatusUUT12";
            textBox_StatusUUT12.ReadOnly = true;
            textBox_StatusUUT12.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT12.TabIndex = 55;
            textBox_StatusUUT12.TextChanged += new System.EventHandler(textBox_StatusUUT12_TextChanged);
            // 
            // textBox_StatusUUT28
            // 
            textBox_StatusUUT28.Location = new System.Drawing.Point(538, 45);
            textBox_StatusUUT28.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT28.Name = "textBox_StatusUUT28";
            textBox_StatusUUT28.ReadOnly = true;
            textBox_StatusUUT28.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT28.TabIndex = 78;
            textBox_StatusUUT28.TextChanged += new System.EventHandler(textBox_StatusUUT28_TextChanged);
            // 
            // label57
            // 
            label57.AutoSize = true;
            label57.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label57.ForeColor = System.Drawing.Color.Black;
            label57.Location = new System.Drawing.Point(241, 327);
            label57.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label57.Name = "label57";
            label57.Size = new System.Drawing.Size(60, 19);
            label57.TabIndex = 54;
            label57.Text = "DCA bit";
            // 
            // label67
            // 
            label67.AutoSize = true;
            label67.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label67.ForeColor = System.Drawing.Color.Black;
            label67.Location = new System.Drawing.Point(446, 239);
            label67.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label67.Name = "label67";
            label67.Size = new System.Drawing.Size(77, 19);
            label67.TabIndex = 62;
            label67.Text = "VVA value";
            // 
            // textBox_StatusUUT22
            // 
            textBox_StatusUUT22.Location = new System.Drawing.Point(332, 322);
            textBox_StatusUUT22.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT22.Name = "textBox_StatusUUT22";
            textBox_StatusUUT22.ReadOnly = true;
            textBox_StatusUUT22.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT22.TabIndex = 53;
            textBox_StatusUUT22.TextChanged += new System.EventHandler(textBox_StatusUUT22_TextChanged);
            // 
            // label58
            // 
            label58.AutoSize = true;
            label58.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label58.ForeColor = System.Drawing.Color.Black;
            label58.Location = new System.Drawing.Point(241, 296);
            label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label58.Name = "label58";
            label58.Size = new System.Drawing.Size(47, 19);
            label58.TabIndex = 52;
            label58.Text = "FT bit";
            // 
            // label70
            // 
            label70.AutoSize = true;
            label70.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label70.ForeColor = System.Drawing.Color.Black;
            label70.Location = new System.Drawing.Point(446, 300);
            label70.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label70.Name = "label70";
            label70.Size = new System.Drawing.Size(76, 19);
            label70.TabIndex = 63;
            label70.Text = "DC2 value";
            // 
            // textBox_StatusUUT21
            // 
            textBox_StatusUUT21.Location = new System.Drawing.Point(332, 291);
            textBox_StatusUUT21.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT21.Name = "textBox_StatusUUT21";
            textBox_StatusUUT21.ReadOnly = true;
            textBox_StatusUUT21.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT21.TabIndex = 51;
            textBox_StatusUUT21.TextChanged += new System.EventHandler(textBox_StatusUUT21_TextChanged);
            // 
            // label59
            // 
            label59.AutoSize = true;
            label59.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label59.ForeColor = System.Drawing.Color.Black;
            label59.Location = new System.Drawing.Point(241, 264);
            label59.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label59.Name = "label59";
            label59.Size = new System.Drawing.Size(60, 19);
            label59.TabIndex = 50;
            label59.Text = "freq bit";
            // 
            // textBox_StatusUUT20
            // 
            textBox_StatusUUT20.Location = new System.Drawing.Point(332, 259);
            textBox_StatusUUT20.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT20.Name = "textBox_StatusUUT20";
            textBox_StatusUUT20.ReadOnly = true;
            textBox_StatusUUT20.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT20.TabIndex = 49;
            textBox_StatusUUT20.TextChanged += new System.EventHandler(textBox_StatusUUT20_TextChanged);
            // 
            // label60
            // 
            label60.AutoSize = true;
            label60.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label60.ForeColor = System.Drawing.Color.Black;
            label60.Location = new System.Drawing.Point(241, 234);
            label60.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label60.Name = "label60";
            label60.Size = new System.Drawing.Size(94, 19);
            label60.TabIndex = 48;
            label60.Text = "Pulse period";
            // 
            // textBox_StatusUUT19
            // 
            textBox_StatusUUT19.Location = new System.Drawing.Point(332, 229);
            textBox_StatusUUT19.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT19.Name = "textBox_StatusUUT19";
            textBox_StatusUUT19.ReadOnly = true;
            textBox_StatusUUT19.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT19.TabIndex = 47;
            textBox_StatusUUT19.TextChanged += new System.EventHandler(textBox_StatusUUT19_TextChanged);
            // 
            // label61
            // 
            label61.AutoSize = true;
            label61.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label61.ForeColor = System.Drawing.Color.Black;
            label61.Location = new System.Drawing.Point(239, 202);
            label61.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label61.Name = "label61";
            label61.Size = new System.Drawing.Size(89, 19);
            label61.TabIndex = 46;
            label61.Text = "Pulse width";
            // 
            // textBox_StatusUUT18
            // 
            textBox_StatusUUT18.Location = new System.Drawing.Point(332, 198);
            textBox_StatusUUT18.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT18.Name = "textBox_StatusUUT18";
            textBox_StatusUUT18.ReadOnly = true;
            textBox_StatusUUT18.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT18.TabIndex = 45;
            textBox_StatusUUT18.TextChanged += new System.EventHandler(textBox_StatusUUT18_TextChanged);
            // 
            // label62
            // 
            label62.AutoSize = true;
            label62.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label62.ForeColor = System.Drawing.Color.Black;
            label62.Location = new System.Drawing.Point(239, 171);
            label62.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label62.Name = "label62";
            label62.Size = new System.Drawing.Size(76, 19);
            label62.TabIndex = 44;
            label62.Text = "PSU temp";
            // 
            // textBox_StatusUUT17
            // 
            textBox_StatusUUT17.Location = new System.Drawing.Point(332, 166);
            textBox_StatusUUT17.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT17.Name = "textBox_StatusUUT17";
            textBox_StatusUUT17.ReadOnly = true;
            textBox_StatusUUT17.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT17.TabIndex = 43;
            textBox_StatusUUT17.TextChanged += new System.EventHandler(textBox_StatusUUT17_TextChanged);
            // 
            // label63
            // 
            label63.AutoSize = true;
            label63.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label63.ForeColor = System.Drawing.Color.Black;
            label63.Location = new System.Drawing.Point(239, 138);
            label63.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label63.Name = "label63";
            label63.Size = new System.Drawing.Size(80, 19);
            label63.TabIndex = 42;
            label63.Text = "VTM temp";
            // 
            // textBox_StatusUUT16
            // 
            textBox_StatusUUT16.Location = new System.Drawing.Point(332, 133);
            textBox_StatusUUT16.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT16.Name = "textBox_StatusUUT16";
            textBox_StatusUUT16.ReadOnly = true;
            textBox_StatusUUT16.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT16.TabIndex = 41;
            textBox_StatusUUT16.TextChanged += new System.EventHandler(textBox_StatusUUT16_TextChanged);
            // 
            // label64
            // 
            label64.AutoSize = true;
            label64.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label64.ForeColor = System.Drawing.Color.Black;
            label64.Location = new System.Drawing.Point(239, 106);
            label64.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label64.Name = "label64";
            label64.Size = new System.Drawing.Size(85, 19);
            label64.TabIndex = 40;
            label64.Text = "48V in rush";
            // 
            // textBox_StatusUUT15
            // 
            textBox_StatusUUT15.Location = new System.Drawing.Point(332, 102);
            textBox_StatusUUT15.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT15.Name = "textBox_StatusUUT15";
            textBox_StatusUUT15.ReadOnly = true;
            textBox_StatusUUT15.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT15.TabIndex = 39;
            textBox_StatusUUT15.TextChanged += new System.EventHandler(textBox_StatusUUT15_TextChanged);
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label65.ForeColor = System.Drawing.Color.Black;
            label65.Location = new System.Drawing.Point(239, 75);
            label65.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label65.Name = "label65";
            label65.Size = new System.Drawing.Size(71, 19);
            label65.TabIndex = 38;
            label65.Text = "48V filter";
            // 
            // textBox_StatusUUT14
            // 
            textBox_StatusUUT14.Location = new System.Drawing.Point(332, 70);
            textBox_StatusUUT14.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT14.Name = "textBox_StatusUUT14";
            textBox_StatusUUT14.ReadOnly = true;
            textBox_StatusUUT14.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT14.TabIndex = 37;
            textBox_StatusUUT14.TextChanged += new System.EventHandler(textBox_StatusUUT14_TextChanged);
            // 
            // label66
            // 
            label66.AutoSize = true;
            label66.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label66.ForeColor = System.Drawing.Color.Black;
            label66.Location = new System.Drawing.Point(239, 42);
            label66.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label66.Name = "label66";
            label66.Size = new System.Drawing.Size(89, 19);
            label66.TabIndex = 36;
            label66.Text = "48V current";
            // 
            // textBox_StatusUUT13
            // 
            textBox_StatusUUT13.Location = new System.Drawing.Point(332, 38);
            textBox_StatusUUT13.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT13.Name = "textBox_StatusUUT13";
            textBox_StatusUUT13.ReadOnly = true;
            textBox_StatusUUT13.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT13.TabIndex = 35;
            textBox_StatusUUT13.TextChanged += new System.EventHandler(textBox_StatusUUT13_TextChanged);
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label55.ForeColor = System.Drawing.Color.Black;
            label55.Location = new System.Drawing.Point(6, 15);
            label55.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label55.Name = "label55";
            label55.Size = new System.Drawing.Size(136, 19);
            label55.TabIndex = 34;
            label55.Text = "Main Temperature";
            // 
            // textBox_StatusUUT1
            // 
            textBox_StatusUUT1.Location = new System.Drawing.Point(147, 10);
            textBox_StatusUUT1.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT1.Name = "textBox_StatusUUT1";
            textBox_StatusUUT1.ReadOnly = true;
            textBox_StatusUUT1.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT1.TabIndex = 33;
            textBox_StatusUUT1.TextChanged += new System.EventHandler(textBox_StatusUUT1_TextChanged);
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label54.ForeColor = System.Drawing.Color.Black;
            label54.Location = new System.Drawing.Point(6, 330);
            label54.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label54.Name = "label54";
            label54.Size = new System.Drawing.Size(54, 19);
            label54.TabIndex = 32;
            label54.Text = "Detect";
            // 
            // textBox_StatusUUT11
            // 
            textBox_StatusUUT11.Location = new System.Drawing.Point(148, 324);
            textBox_StatusUUT11.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT11.Name = "textBox_StatusUUT11";
            textBox_StatusUUT11.ReadOnly = true;
            textBox_StatusUUT11.Size = new System.Drawing.Size(93, 26);
            textBox_StatusUUT11.TabIndex = 31;
            textBox_StatusUUT11.TextChanged += new System.EventHandler(textBox_StatusUUT11_TextChanged);
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label53.ForeColor = System.Drawing.Color.Black;
            label53.Location = new System.Drawing.Point(6, 298);
            label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label53.Name = "label53";
            label53.Size = new System.Drawing.Size(65, 19);
            label53.TabIndex = 30;
            label53.Text = "Vgg N5V";
            // 
            // textBox_StatusUUT10
            // 
            textBox_StatusUUT10.Location = new System.Drawing.Point(148, 292);
            textBox_StatusUUT10.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT10.Name = "textBox_StatusUUT10";
            textBox_StatusUUT10.ReadOnly = true;
            textBox_StatusUUT10.Size = new System.Drawing.Size(93, 26);
            textBox_StatusUUT10.TabIndex = 29;
            textBox_StatusUUT10.TextChanged += new System.EventHandler(textBox_StatusUUT10_TextChanged);
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label52.ForeColor = System.Drawing.Color.Black;
            label52.Location = new System.Drawing.Point(6, 266);
            label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label52.Name = "label52";
            label52.Size = new System.Drawing.Size(60, 19);
            label52.TabIndex = 28;
            label52.Text = "Vdd_4V";
            // 
            // textBox_StatusUUT9
            // 
            textBox_StatusUUT9.Location = new System.Drawing.Point(148, 260);
            textBox_StatusUUT9.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT9.Name = "textBox_StatusUUT9";
            textBox_StatusUUT9.ReadOnly = true;
            textBox_StatusUUT9.Size = new System.Drawing.Size(93, 26);
            textBox_StatusUUT9.TabIndex = 27;
            textBox_StatusUUT9.TextChanged += new System.EventHandler(textBox_StatusUUT9_TextChanged);
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label51.ForeColor = System.Drawing.Color.Black;
            label51.Location = new System.Drawing.Point(6, 235);
            label51.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label51.Name = "label51";
            label51.Size = new System.Drawing.Size(60, 19);
            label51.TabIndex = 26;
            label51.Text = "Vdd_5V";
            // 
            // textBox_StatusUUT8
            // 
            textBox_StatusUUT8.Location = new System.Drawing.Point(148, 229);
            textBox_StatusUUT8.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT8.Name = "textBox_StatusUUT8";
            textBox_StatusUUT8.ReadOnly = true;
            textBox_StatusUUT8.Size = new System.Drawing.Size(93, 26);
            textBox_StatusUUT8.TabIndex = 25;
            textBox_StatusUUT8.TextChanged += new System.EventHandler(textBox_StatusUUT8_TextChanged);
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label50.ForeColor = System.Drawing.Color.Black;
            label50.Location = new System.Drawing.Point(6, 204);
            label50.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label50.Name = "label50";
            label50.Size = new System.Drawing.Size(60, 19);
            label50.TabIndex = 24;
            label50.Text = "Vdd_9V";
            // 
            // textBox_StatusUUT7
            // 
            textBox_StatusUUT7.Location = new System.Drawing.Point(147, 199);
            textBox_StatusUUT7.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT7.Name = "textBox_StatusUUT7";
            textBox_StatusUUT7.ReadOnly = true;
            textBox_StatusUUT7.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT7.TabIndex = 23;
            textBox_StatusUUT7.TextChanged += new System.EventHandler(textBox_StatusUUT7_TextChanged);
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label49.ForeColor = System.Drawing.Color.Black;
            label49.Location = new System.Drawing.Point(6, 174);
            label49.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label49.Name = "label49";
            label49.Size = new System.Drawing.Size(68, 19);
            label49.TabIndex = 22;
            label49.Text = "Vdd_28V";
            // 
            // textBox_StatusUUT6
            // 
            textBox_StatusUUT6.Location = new System.Drawing.Point(147, 168);
            textBox_StatusUUT6.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT6.Name = "textBox_StatusUUT6";
            textBox_StatusUUT6.ReadOnly = true;
            textBox_StatusUUT6.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT6.TabIndex = 21;
            textBox_StatusUUT6.TextChanged += new System.EventHandler(textBox_StatusUUT6_TextChanged);
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label40.ForeColor = System.Drawing.Color.Black;
            label40.Location = new System.Drawing.Point(6, 139);
            label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(81, 19);
            label40.TabIndex = 20;
            label40.Text = "9V current";
            // 
            // textBox_StatusUUT5
            // 
            textBox_StatusUUT5.Location = new System.Drawing.Point(147, 133);
            textBox_StatusUUT5.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT5.Name = "textBox_StatusUUT5";
            textBox_StatusUUT5.ReadOnly = true;
            textBox_StatusUUT5.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT5.TabIndex = 19;
            textBox_StatusUUT5.TextChanged += new System.EventHandler(textBox_StatusUUT5_TextChanged);
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label39.ForeColor = System.Drawing.Color.Black;
            label39.Location = new System.Drawing.Point(6, 109);
            label39.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(89, 19);
            label39.TabIndex = 18;
            label39.Text = "28V current";
            // 
            // textBox_StatusUUT4
            // 
            textBox_StatusUUT4.Location = new System.Drawing.Point(147, 103);
            textBox_StatusUUT4.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT4.Name = "textBox_StatusUUT4";
            textBox_StatusUUT4.ReadOnly = true;
            textBox_StatusUUT4.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT4.TabIndex = 17;
            textBox_StatusUUT4.TextChanged += new System.EventHandler(textBox_StatusUUT4_TextChanged);
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label33.ForeColor = System.Drawing.Color.Black;
            label33.Location = new System.Drawing.Point(6, 78);
            label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(81, 19);
            label33.TabIndex = 16;
            label33.Text = "5V current";
            // 
            // textBox_StatusUUT3
            // 
            textBox_StatusUUT3.Location = new System.Drawing.Point(147, 72);
            textBox_StatusUUT3.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT3.Name = "textBox_StatusUUT3";
            textBox_StatusUUT3.ReadOnly = true;
            textBox_StatusUUT3.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT3.TabIndex = 15;
            textBox_StatusUUT3.TextChanged += new System.EventHandler(textBox_StatusUUT3_TextChanged);
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label32.ForeColor = System.Drawing.Color.Black;
            label32.Location = new System.Drawing.Point(6, 45);
            label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(85, 19);
            label32.TabIndex = 14;
            label32.Text = "Main Index";
            // 
            // textBox_StatusUUT2
            // 
            textBox_StatusUUT2.Location = new System.Drawing.Point(147, 39);
            textBox_StatusUUT2.Margin = new System.Windows.Forms.Padding(2);
            textBox_StatusUUT2.Name = "textBox_StatusUUT2";
            textBox_StatusUUT2.ReadOnly = true;
            textBox_StatusUUT2.Size = new System.Drawing.Size(92, 26);
            textBox_StatusUUT2.TabIndex = 0;
            textBox_StatusUUT2.TextChanged += new System.EventHandler(textBox_StatusUUT2_TextChanged);
            // 
            // groupBox39
            // 
            groupBox39.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            groupBox39.Controls.Add(label115);
            groupBox39.Controls.Add(textBox95);
            groupBox39.Controls.Add(label71);
            groupBox39.Controls.Add(label74);
            groupBox39.Controls.Add(textBox94);
            groupBox39.Controls.Add(label73);
            groupBox39.Controls.Add(textBox93);
            groupBox39.Controls.Add(label68);
            groupBox39.Controls.Add(textBox92);
            groupBox39.Controls.Add(label72);
            groupBox39.Controls.Add(textBox90);
            groupBox39.Controls.Add(textBox91);
            groupBox39.FlatStyle = System.Windows.Forms.FlatStyle.System;
            groupBox39.Location = new System.Drawing.Point(642, 14);
            groupBox39.Margin = new System.Windows.Forms.Padding(2);
            groupBox39.Name = "groupBox39";
            groupBox39.Padding = new System.Windows.Forms.Padding(2);
            groupBox39.Size = new System.Drawing.Size(211, 215);
            groupBox39.TabIndex = 76;
            groupBox39.TabStop = false;
            groupBox39.Text = "Status Simulator";
            // 
            // label115
            // 
            label115.AutoSize = true;
            label115.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label115.ForeColor = System.Drawing.Color.Black;
            label115.Location = new System.Drawing.Point(2, 189);
            label115.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label115.Name = "label115";
            label115.Size = new System.Drawing.Size(105, 19);
            label115.TabIndex = 75;
            label115.Text = "Tx OVT hazard";
            // 
            // textBox95
            // 
            textBox95.Location = new System.Drawing.Point(115, 186);
            textBox95.Margin = new System.Windows.Forms.Padding(2);
            textBox95.Name = "textBox95";
            textBox95.ReadOnly = true;
            textBox95.Size = new System.Drawing.Size(92, 26);
            textBox95.TabIndex = 74;
            textBox95.TextChanged += new System.EventHandler(textBox95_TextChanged);
            // 
            // label71
            // 
            label71.AutoSize = true;
            label71.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label71.ForeColor = System.Drawing.Color.Black;
            label71.Location = new System.Drawing.Point(18, 35);
            label71.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label71.Name = "label71";
            label71.Size = new System.Drawing.Size(51, 19);
            label71.TabIndex = 68;
            label71.Text = "Ready";
            label71.Click += new System.EventHandler(label71_Click);
            // 
            // label74
            // 
            label74.AutoSize = true;
            label74.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label74.ForeColor = System.Drawing.Color.Black;
            label74.Location = new System.Drawing.Point(18, 159);
            label74.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label74.Name = "label74";
            label74.Size = new System.Drawing.Size(35, 19);
            label74.TabIndex = 73;
            label74.Text = "SEU";
            label74.Click += new System.EventHandler(label74_Click);
            // 
            // textBox94
            // 
            textBox94.Location = new System.Drawing.Point(115, 156);
            textBox94.Margin = new System.Windows.Forms.Padding(2);
            textBox94.Name = "textBox94";
            textBox94.ReadOnly = true;
            textBox94.Size = new System.Drawing.Size(92, 26);
            textBox94.TabIndex = 72;
            textBox94.TextChanged += new System.EventHandler(textBox60_TextChanged);
            // 
            // label73
            // 
            label73.AutoSize = true;
            label73.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label73.ForeColor = System.Drawing.Color.Black;
            label73.Location = new System.Drawing.Point(18, 130);
            label73.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label73.Name = "label73";
            label73.Size = new System.Drawing.Size(81, 19);
            label73.TabIndex = 71;
            label73.Text = "Protection";
            label73.Click += new System.EventHandler(label73_Click);
            // 
            // textBox93
            // 
            textBox93.Location = new System.Drawing.Point(115, 123);
            textBox93.Margin = new System.Windows.Forms.Padding(2);
            textBox93.Name = "textBox93";
            textBox93.ReadOnly = true;
            textBox93.Size = new System.Drawing.Size(92, 26);
            textBox93.TabIndex = 70;
            textBox93.TextChanged += new System.EventHandler(textBox59_TextChanged);
            // 
            // label68
            // 
            label68.AutoSize = true;
            label68.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label68.ForeColor = System.Drawing.Color.Black;
            label68.Location = new System.Drawing.Point(8, 96);
            label68.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label68.Name = "label68";
            label68.Size = new System.Drawing.Size(97, 19);
            label68.TabIndex = 69;
            label68.Text = "Over voltage";
            label68.Click += new System.EventHandler(label68_Click);
            // 
            // textBox92
            // 
            textBox92.Location = new System.Drawing.Point(115, 92);
            textBox92.Margin = new System.Windows.Forms.Padding(2);
            textBox92.Name = "textBox92";
            textBox92.ReadOnly = true;
            textBox92.Size = new System.Drawing.Size(92, 26);
            textBox92.TabIndex = 64;
            textBox92.TextChanged += new System.EventHandler(textBox58_TextChanged);
            // 
            // label72
            // 
            label72.AutoSize = true;
            label72.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label72.ForeColor = System.Drawing.Color.Black;
            label72.Location = new System.Drawing.Point(6, 63);
            label72.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label72.Name = "label72";
            label72.Size = new System.Drawing.Size(106, 19);
            label72.TabIndex = 65;
            label72.Text = "Under voltage";
            label72.Click += new System.EventHandler(label72_Click);
            // 
            // textBox90
            // 
            textBox90.Location = new System.Drawing.Point(115, 31);
            textBox90.Margin = new System.Windows.Forms.Padding(2);
            textBox90.Name = "textBox90";
            textBox90.ReadOnly = true;
            textBox90.Size = new System.Drawing.Size(92, 26);
            textBox90.TabIndex = 67;
            textBox90.TextChanged += new System.EventHandler(textBox56_TextChanged);
            // 
            // textBox91
            // 
            textBox91.Location = new System.Drawing.Point(115, 62);
            textBox91.Margin = new System.Windows.Forms.Padding(2);
            textBox91.Name = "textBox91";
            textBox91.ReadOnly = true;
            textBox91.Size = new System.Drawing.Size(92, 26);
            textBox91.TabIndex = 66;
            textBox91.TextChanged += new System.EventHandler(textBox57_TextChanged);
            // 
            // groupBox35
            // 
            groupBox35.Controls.Add(label84);
            groupBox35.Controls.Add(checkBox8);
            groupBox35.Controls.Add(label85);
            groupBox35.Controls.Add(button44);
            groupBox35.Controls.Add(label101);
            groupBox35.Controls.Add(textBox_PulseDelay2);
            groupBox35.Controls.Add(textBox_PulsePeriod2);
            groupBox35.Controls.Add(textBox_PulseWidth2);
            groupBox35.Location = new System.Drawing.Point(876, 233);
            groupBox35.Margin = new System.Windows.Forms.Padding(2);
            groupBox35.Name = "groupBox35";
            groupBox35.Padding = new System.Windows.Forms.Padding(2);
            groupBox35.Size = new System.Drawing.Size(354, 97);
            groupBox35.TabIndex = 18;
            groupBox35.TabStop = false;
            groupBox35.Text = "GP pulse gen";
            // 
            // label84
            // 
            label84.AutoSize = true;
            label84.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label84.Location = new System.Drawing.Point(171, 34);
            label84.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label84.Name = "label84";
            label84.Size = new System.Drawing.Size(69, 15);
            label84.TabIndex = 23;
            label84.Text = "Delay (1us)";
            // 
            // checkBox8
            // 
            checkBox8.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox8.AutoSize = true;
            checkBox8.Location = new System.Drawing.Point(268, 20);
            checkBox8.Margin = new System.Windows.Forms.Padding(2);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new System.Drawing.Size(64, 28);
            checkBox8.TabIndex = 19;
            checkBox8.Text = "Control";
            checkBox8.UseVisualStyleBackColor = true;
            checkBox8.CheckedChanged += new System.EventHandler(checkBox8_CheckedChanged);
            // 
            // label85
            // 
            label85.AutoSize = true;
            label85.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label85.Location = new System.Drawing.Point(93, 34);
            label85.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label85.Name = "label85";
            label85.Size = new System.Drawing.Size(74, 15);
            label85.TabIndex = 22;
            label85.Text = "Period (1us)";
            // 
            // button44
            // 
            button44.Location = new System.Drawing.Point(222, 58);
            button44.Margin = new System.Windows.Forms.Padding(2);
            button44.Name = "button44";
            button44.Size = new System.Drawing.Size(112, 22);
            button44.TabIndex = 16;
            button44.Text = "Set GP parms";
            button44.UseVisualStyleBackColor = true;
            button44.Click += new System.EventHandler(button44_Click);
            // 
            // label101
            // 
            label101.AutoSize = true;
            label101.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label101.Location = new System.Drawing.Point(15, 34);
            label101.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label101.Name = "label101";
            label101.Size = new System.Drawing.Size(72, 15);
            label101.TabIndex = 21;
            label101.Text = "Width (1us)";
            // 
            // textBox_PulseDelay2
            // 
            textBox_PulseDelay2.Location = new System.Drawing.Point(165, 55);
            textBox_PulseDelay2.Margin = new System.Windows.Forms.Padding(2);
            textBox_PulseDelay2.Name = "textBox_PulseDelay2";
            textBox_PulseDelay2.Size = new System.Drawing.Size(53, 26);
            textBox_PulseDelay2.TabIndex = 15;
            textBox_PulseDelay2.Text = "0";
            // 
            // textBox_PulsePeriod2
            // 
            textBox_PulsePeriod2.Location = new System.Drawing.Point(87, 55);
            textBox_PulsePeriod2.Margin = new System.Windows.Forms.Padding(2);
            textBox_PulsePeriod2.Name = "textBox_PulsePeriod2";
            textBox_PulsePeriod2.Size = new System.Drawing.Size(53, 26);
            textBox_PulsePeriod2.TabIndex = 13;
            textBox_PulsePeriod2.Text = "16";
            textBox_PulsePeriod2.TextChanged += new System.EventHandler(textBox_PulsePeriod2_TextChanged);
            // 
            // textBox_PulseWidth2
            // 
            textBox_PulseWidth2.Location = new System.Drawing.Point(18, 55);
            textBox_PulseWidth2.Margin = new System.Windows.Forms.Padding(2);
            textBox_PulseWidth2.Name = "textBox_PulseWidth2";
            textBox_PulseWidth2.Size = new System.Drawing.Size(53, 26);
            textBox_PulseWidth2.TabIndex = 11;
            textBox_PulseWidth2.Text = "2";
            textBox_PulseWidth2.TextChanged += new System.EventHandler(textBox_PulseWidth2_TextChanged);
            // 
            // groupBox46
            // 
            groupBox46.Controls.Add(label38);
            groupBox46.Controls.Add(label34);
            groupBox46.Controls.Add(label35);
            groupBox46.Controls.Add(textBox29);
            groupBox46.Controls.Add(textBox30);
            groupBox46.Controls.Add(textBox31);
            groupBox46.Controls.Add(label36);
            groupBox46.Location = new System.Drawing.Point(310, 106);
            groupBox46.Margin = new System.Windows.Forms.Padding(2);
            groupBox46.Name = "groupBox46";
            groupBox46.Padding = new System.Windows.Forms.Padding(2);
            groupBox46.Size = new System.Drawing.Size(232, 104);
            groupBox46.TabIndex = 14;
            groupBox46.TabStop = false;
            groupBox46.Enter += new System.EventHandler(groupBox46_Enter);
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label38.ForeColor = System.Drawing.Color.Black;
            label38.Location = new System.Drawing.Point(121, 43);
            label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(45, 19);
            label38.TabIndex = 14;
            label38.Text = "DCA2";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label34.ForeColor = System.Drawing.Color.Black;
            label34.Location = new System.Drawing.Point(62, 43);
            label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(45, 19);
            label34.TabIndex = 11;
            label34.Text = "DCA1";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label35.ForeColor = System.Drawing.Color.Black;
            label35.Location = new System.Drawing.Point(7, 43);
            label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(36, 19);
            label35.TabIndex = 7;
            label35.Text = "VVA";
            // 
            // textBox29
            // 
            textBox29.Location = new System.Drawing.Point(65, 69);
            textBox29.Margin = new System.Windows.Forms.Padding(2);
            textBox29.Name = "textBox29";
            textBox29.Size = new System.Drawing.Size(50, 26);
            textBox29.TabIndex = 6;
            textBox29.Text = "0";
            toolTip1.SetToolTip(textBox29, "Press Enter to update");
            textBox29.TextChanged += new System.EventHandler(textBox29_TextChanged);
            textBox29.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox29_KeyDown);
            // 
            // textBox30
            // 
            textBox30.Location = new System.Drawing.Point(123, 68);
            textBox30.Margin = new System.Windows.Forms.Padding(2);
            textBox30.Name = "textBox30";
            textBox30.Size = new System.Drawing.Size(50, 26);
            textBox30.TabIndex = 7;
            textBox30.Text = "0";
            toolTip1.SetToolTip(textBox30, "Press Enter to update");
            textBox30.TextChanged += new System.EventHandler(textBox30_TextChanged);
            textBox30.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox30_KeyDown);
            // 
            // textBox31
            // 
            textBox31.Location = new System.Drawing.Point(7, 69);
            textBox31.Margin = new System.Windows.Forms.Padding(2);
            textBox31.Name = "textBox31";
            textBox31.Size = new System.Drawing.Size(50, 26);
            textBox31.TabIndex = 5;
            textBox31.Text = "0";
            toolTip1.SetToolTip(textBox31, "Press Enter to update");
            textBox31.TextChanged += new System.EventHandler(textBox31_TextChanged);
            textBox31.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox31_KeyDown);
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label36.ForeColor = System.Drawing.Color.Blue;
            label36.Location = new System.Drawing.Point(51, 14);
            label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(133, 23);
            label36.TabIndex = 7;
            label36.Text = "Set Attenuation";
            // 
            // groupBox45
            // 
            groupBox45.Controls.Add(label102);
            groupBox45.Controls.Add(label31);
            groupBox45.Controls.Add(label30);
            groupBox45.Controls.Add(label29);
            groupBox45.Controls.Add(label28);
            groupBox45.Controls.Add(textBox27);
            groupBox45.Controls.Add(textBox26);
            groupBox45.Controls.Add(textBox25);
            groupBox45.Controls.Add(textBox24);
            groupBox45.Controls.Add(label25);
            groupBox45.Location = new System.Drawing.Point(6, 102);
            groupBox45.Margin = new System.Windows.Forms.Padding(2);
            groupBox45.Name = "groupBox45";
            groupBox45.Padding = new System.Windows.Forms.Padding(2);
            groupBox45.Size = new System.Drawing.Size(295, 105);
            groupBox45.TabIndex = 1;
            groupBox45.TabStop = false;
            // 
            // label102
            // 
            label102.AutoSize = true;
            label102.Location = new System.Drawing.Point(198, 13);
            label102.Name = "label102";
            label102.Size = new System.Drawing.Size(90, 18);
            label102.TabIndex = 14;
            label102.Text = "Enter to send";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label31.ForeColor = System.Drawing.Color.Black;
            label31.Location = new System.Drawing.Point(180, 41);
            label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(26, 19);
            label31.TabIndex = 13;
            label31.Text = "4V";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label30.ForeColor = System.Drawing.Color.Black;
            label30.Location = new System.Drawing.Point(124, 42);
            label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(26, 19);
            label30.TabIndex = 12;
            label30.Text = "5V";
            label30.Click += new System.EventHandler(label30_Click);
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label29.ForeColor = System.Drawing.Color.Black;
            label29.Location = new System.Drawing.Point(63, 42);
            label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(26, 19);
            label29.TabIndex = 11;
            label29.Text = "9V";
            label29.Click += new System.EventHandler(label29_Click);
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label28.ForeColor = System.Drawing.Color.Black;
            label28.Location = new System.Drawing.Point(13, 41);
            label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(34, 19);
            label28.TabIndex = 7;
            label28.Text = "28V";
            // 
            // textBox27
            // 
            textBox27.Location = new System.Drawing.Point(171, 69);
            textBox27.Margin = new System.Windows.Forms.Padding(2);
            textBox27.Name = "textBox27";
            textBox27.Size = new System.Drawing.Size(50, 26);
            textBox27.TabIndex = 4;
            textBox27.Text = "0";
            toolTip1.SetToolTip(textBox27, "Press Enter to update");
            textBox27.TextChanged += new System.EventHandler(textBox27_TextChanged);
            textBox27.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox27_KeyDown);
            // 
            // textBox26
            // 
            textBox26.Location = new System.Drawing.Point(116, 69);
            textBox26.Margin = new System.Windows.Forms.Padding(2);
            textBox26.Name = "textBox26";
            textBox26.Size = new System.Drawing.Size(50, 26);
            textBox26.TabIndex = 3;
            textBox26.Text = "0";
            toolTip1.SetToolTip(textBox26, "Press Enter to update");
            textBox26.TextChanged += new System.EventHandler(textBox26_TextChanged);
            textBox26.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox26_KeyDown);
            // 
            // textBox25
            // 
            textBox25.Location = new System.Drawing.Point(62, 69);
            textBox25.Margin = new System.Windows.Forms.Padding(2);
            textBox25.Name = "textBox25";
            textBox25.Size = new System.Drawing.Size(50, 26);
            textBox25.TabIndex = 2;
            textBox25.Text = "0";
            toolTip1.SetToolTip(textBox25, "Press Enter to update");
            textBox25.TextChanged += new System.EventHandler(textBox25_TextChanged);
            textBox25.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox25_KeyDown);
            // 
            // textBox24
            // 
            textBox24.Location = new System.Drawing.Point(6, 69);
            textBox24.Margin = new System.Windows.Forms.Padding(2);
            textBox24.Name = "textBox24";
            textBox24.Size = new System.Drawing.Size(50, 26);
            textBox24.TabIndex = 1;
            textBox24.Text = "0";
            toolTip1.SetToolTip(textBox24, "Press Enter to update");
            textBox24.TextChanged += new System.EventHandler(textBox24_TextChanged);
            textBox24.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox24_KeyDown);
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label25.ForeColor = System.Drawing.Color.Blue;
            label25.Location = new System.Drawing.Point(51, 14);
            label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(134, 23);
            label25.TabIndex = 7;
            label25.Text = "Set PSU voltage";
            // 
            // groupBox34
            // 
            groupBox34.Controls.Add(label79);
            groupBox34.Controls.Add(checkBox7);
            groupBox34.Controls.Add(label80);
            groupBox34.Controls.Add(button42);
            groupBox34.Controls.Add(label83);
            groupBox34.Controls.Add(textBox_PulseDelay);
            groupBox34.Controls.Add(textBox_PulsePeriod);
            groupBox34.Controls.Add(textBox_PulseWidth);
            groupBox34.Location = new System.Drawing.Point(876, 128);
            groupBox34.Margin = new System.Windows.Forms.Padding(2);
            groupBox34.Name = "groupBox34";
            groupBox34.Padding = new System.Windows.Forms.Padding(2);
            groupBox34.Size = new System.Drawing.Size(354, 97);
            groupBox34.TabIndex = 17;
            groupBox34.TabStop = false;
            groupBox34.Text = "Pulse gen";
            // 
            // label79
            // 
            label79.AutoSize = true;
            label79.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label79.Location = new System.Drawing.Point(171, 33);
            label79.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label79.Name = "label79";
            label79.Size = new System.Drawing.Size(69, 15);
            label79.TabIndex = 20;
            label79.Text = "Delay (1us)";
            // 
            // checkBox7
            // 
            checkBox7.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox7.AutoSize = true;
            checkBox7.Location = new System.Drawing.Point(268, 19);
            checkBox7.Margin = new System.Windows.Forms.Padding(2);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new System.Drawing.Size(64, 28);
            checkBox7.TabIndex = 18;
            checkBox7.Text = "Control";
            checkBox7.UseVisualStyleBackColor = true;
            checkBox7.CheckedChanged += new System.EventHandler(checkBox7_CheckedChanged);
            // 
            // label80
            // 
            label80.AutoSize = true;
            label80.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label80.Location = new System.Drawing.Point(93, 33);
            label80.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label80.Name = "label80";
            label80.Size = new System.Drawing.Size(74, 15);
            label80.TabIndex = 19;
            label80.Text = "Period (1us)";
            // 
            // button42
            // 
            button42.Location = new System.Drawing.Point(222, 58);
            button42.Margin = new System.Windows.Forms.Padding(2);
            button42.Name = "button42";
            button42.Size = new System.Drawing.Size(112, 22);
            button42.TabIndex = 16;
            button42.Text = "Set Tx Inhabit";
            button42.UseVisualStyleBackColor = true;
            button42.Click += new System.EventHandler(button42_Click_2);
            // 
            // label83
            // 
            label83.AutoSize = true;
            label83.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label83.Location = new System.Drawing.Point(15, 33);
            label83.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label83.Name = "label83";
            label83.Size = new System.Drawing.Size(72, 15);
            label83.TabIndex = 18;
            label83.Text = "Width (1us)";
            // 
            // textBox_PulseDelay
            // 
            textBox_PulseDelay.Location = new System.Drawing.Point(165, 55);
            textBox_PulseDelay.Margin = new System.Windows.Forms.Padding(2);
            textBox_PulseDelay.Name = "textBox_PulseDelay";
            textBox_PulseDelay.Size = new System.Drawing.Size(53, 26);
            textBox_PulseDelay.TabIndex = 15;
            textBox_PulseDelay.Text = "0";
            // 
            // textBox_PulsePeriod
            // 
            textBox_PulsePeriod.Location = new System.Drawing.Point(87, 55);
            textBox_PulsePeriod.Margin = new System.Windows.Forms.Padding(2);
            textBox_PulsePeriod.Name = "textBox_PulsePeriod";
            textBox_PulsePeriod.Size = new System.Drawing.Size(53, 26);
            textBox_PulsePeriod.TabIndex = 13;
            textBox_PulsePeriod.Text = "16";
            textBox_PulsePeriod.TextChanged += new System.EventHandler(textBox_PulsePeriod_TextChanged);
            // 
            // textBox_PulseWidth
            // 
            textBox_PulseWidth.Location = new System.Drawing.Point(18, 55);
            textBox_PulseWidth.Margin = new System.Windows.Forms.Padding(2);
            textBox_PulseWidth.Name = "textBox_PulseWidth";
            textBox_PulseWidth.Size = new System.Drawing.Size(53, 26);
            textBox_PulseWidth.TabIndex = 11;
            textBox_PulseWidth.Text = "2";
            textBox_PulseWidth.TextChanged += new System.EventHandler(textBox_PulseWidth_TextChanged);
            // 
            // groupBox44
            // 
            groupBox44.Controls.Add(label121);
            groupBox44.Controls.Add(button57);
            groupBox44.Controls.Add(textBox_SystemSN);
            groupBox44.Controls.Add(textBox_SystemFWVersion);
            groupBox44.Controls.Add(label122);
            groupBox44.Controls.Add(textBox_SystemHWVersion);
            groupBox44.Controls.Add(textBox_SystemID);
            groupBox44.Controls.Add(button70);
            groupBox44.Controls.Add(label27);
            groupBox44.Controls.Add(label26);
            groupBox44.Controls.Add(label19);
            groupBox44.Location = new System.Drawing.Point(6, 4);
            groupBox44.Margin = new System.Windows.Forms.Padding(2);
            groupBox44.Name = "groupBox44";
            groupBox44.Padding = new System.Windows.Forms.Padding(2);
            groupBox44.Size = new System.Drawing.Size(399, 97);
            groupBox44.TabIndex = 0;
            groupBox44.TabStop = false;
            // 
            // label121
            // 
            label121.AutoSize = true;
            label121.Location = new System.Drawing.Point(310, 70);
            label121.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label121.Name = "label121";
            label121.Size = new System.Drawing.Size(29, 18);
            label121.TabIndex = 15;
            label121.Text = "SN:";
            // 
            // button57
            // 
            button57.Location = new System.Drawing.Point(6, 68);
            button57.Margin = new System.Windows.Forms.Padding(2);
            button57.Name = "button57";
            button57.Size = new System.Drawing.Size(69, 22);
            button57.TabIndex = 12;
            button57.Text = "Clear";
            button57.UseVisualStyleBackColor = true;
            button57.Click += new System.EventHandler(button57_Click_1);
            // 
            // textBox_SystemSN
            // 
            textBox_SystemSN.Location = new System.Drawing.Point(339, 62);
            textBox_SystemSN.Margin = new System.Windows.Forms.Padding(2);
            textBox_SystemSN.Name = "textBox_SystemSN";
            textBox_SystemSN.ReadOnly = true;
            textBox_SystemSN.Size = new System.Drawing.Size(46, 26);
            textBox_SystemSN.TabIndex = 14;
            // 
            // textBox_SystemFWVersion
            // 
            textBox_SystemFWVersion.Location = new System.Drawing.Point(162, 63);
            textBox_SystemFWVersion.Margin = new System.Windows.Forms.Padding(2);
            textBox_SystemFWVersion.Name = "textBox_SystemFWVersion";
            textBox_SystemFWVersion.ReadOnly = true;
            textBox_SystemFWVersion.Size = new System.Drawing.Size(126, 26);
            textBox_SystemFWVersion.TabIndex = 13;
            // 
            // label122
            // 
            label122.AutoSize = true;
            label122.Location = new System.Drawing.Point(310, 38);
            label122.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label122.Name = "label122";
            label122.Size = new System.Drawing.Size(25, 18);
            label122.TabIndex = 13;
            label122.Text = "ID:";
            // 
            // textBox_SystemHWVersion
            // 
            textBox_SystemHWVersion.Location = new System.Drawing.Point(162, 31);
            textBox_SystemHWVersion.Margin = new System.Windows.Forms.Padding(2);
            textBox_SystemHWVersion.Name = "textBox_SystemHWVersion";
            textBox_SystemHWVersion.ReadOnly = true;
            textBox_SystemHWVersion.Size = new System.Drawing.Size(126, 26);
            textBox_SystemHWVersion.TabIndex = 12;
            // 
            // textBox_SystemID
            // 
            textBox_SystemID.Location = new System.Drawing.Point(339, 31);
            textBox_SystemID.Margin = new System.Windows.Forms.Padding(2);
            textBox_SystemID.Name = "textBox_SystemID";
            textBox_SystemID.ReadOnly = true;
            textBox_SystemID.Size = new System.Drawing.Size(46, 26);
            textBox_SystemID.TabIndex = 12;
            // 
            // button70
            // 
            button70.Location = new System.Drawing.Point(6, 42);
            button70.Margin = new System.Windows.Forms.Padding(2);
            button70.Name = "button70";
            button70.Size = new System.Drawing.Size(69, 22);
            button70.TabIndex = 6;
            button70.Text = "Get";
            button70.UseVisualStyleBackColor = true;
            button70.Click += new System.EventHandler(button70_Click_1);
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(82, 70);
            label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(81, 18);
            label27.TabIndex = 5;
            label27.Text = "FW version:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(79, 40);
            label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(83, 18);
            label26.TabIndex = 4;
            label26.Text = "HW version:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label19.Location = new System.Drawing.Point(5, 14);
            label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(68, 23);
            label19.TabIndex = 0;
            label19.Text = "System";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button75);
            groupBox1.Controls.Add(label97);
            groupBox1.Controls.Add(textBox_SimulatorSN);
            groupBox1.Controls.Add(label96);
            groupBox1.Controls.Add(textBox_SimulatorID);
            groupBox1.Controls.Add(button31);
            groupBox1.Controls.Add(label93);
            groupBox1.Controls.Add(label94);
            groupBox1.Controls.Add(textBox_SimulatorFWVersion);
            groupBox1.Controls.Add(textBox_SimulatorHWVersion);
            groupBox1.Controls.Add(label95);
            groupBox1.Location = new System.Drawing.Point(411, 4);
            groupBox1.Margin = new System.Windows.Forms.Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(2);
            groupBox1.Size = new System.Drawing.Size(354, 97);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // button75
            // 
            button75.Location = new System.Drawing.Point(6, 65);
            button75.Margin = new System.Windows.Forms.Padding(2);
            button75.Name = "button75";
            button75.Size = new System.Drawing.Size(69, 22);
            button75.TabIndex = 11;
            button75.Text = "Clear";
            button75.UseVisualStyleBackColor = true;
            button75.Click += new System.EventHandler(button75_Click_1);
            // 
            // label97
            // 
            label97.AutoSize = true;
            label97.Location = new System.Drawing.Point(274, 71);
            label97.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label97.Name = "label97";
            label97.Size = new System.Drawing.Size(29, 18);
            label97.TabIndex = 10;
            label97.Text = "SN:";
            // 
            // textBox_SimulatorSN
            // 
            textBox_SimulatorSN.Location = new System.Drawing.Point(303, 63);
            textBox_SimulatorSN.Margin = new System.Windows.Forms.Padding(2);
            textBox_SimulatorSN.Name = "textBox_SimulatorSN";
            textBox_SimulatorSN.ReadOnly = true;
            textBox_SimulatorSN.Size = new System.Drawing.Size(46, 26);
            textBox_SimulatorSN.TabIndex = 9;
            // 
            // label96
            // 
            label96.AutoSize = true;
            label96.Location = new System.Drawing.Point(274, 39);
            label96.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label96.Name = "label96";
            label96.Size = new System.Drawing.Size(25, 18);
            label96.TabIndex = 8;
            label96.Text = "ID:";
            // 
            // textBox_SimulatorID
            // 
            textBox_SimulatorID.Location = new System.Drawing.Point(303, 32);
            textBox_SimulatorID.Margin = new System.Windows.Forms.Padding(2);
            textBox_SimulatorID.Name = "textBox_SimulatorID";
            textBox_SimulatorID.ReadOnly = true;
            textBox_SimulatorID.Size = new System.Drawing.Size(46, 26);
            textBox_SimulatorID.TabIndex = 7;
            // 
            // button31
            // 
            button31.Location = new System.Drawing.Point(6, 38);
            button31.Margin = new System.Windows.Forms.Padding(2);
            button31.Name = "button31";
            button31.Size = new System.Drawing.Size(69, 22);
            button31.TabIndex = 6;
            button31.Text = "Get";
            button31.UseVisualStyleBackColor = true;
            button31.Click += new System.EventHandler(button31_Click_1);
            // 
            // label93
            // 
            label93.AutoSize = true;
            label93.Location = new System.Drawing.Point(95, 67);
            label93.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label93.Name = "label93";
            label93.Size = new System.Drawing.Size(81, 18);
            label93.TabIndex = 5;
            label93.Text = "FW version:";
            // 
            // label94
            // 
            label94.AutoSize = true;
            label94.Location = new System.Drawing.Point(90, 35);
            label94.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label94.Name = "label94";
            label94.Size = new System.Drawing.Size(83, 18);
            label94.TabIndex = 4;
            label94.Text = "HW version:";
            // 
            // textBox_SimulatorFWVersion
            // 
            textBox_SimulatorFWVersion.Location = new System.Drawing.Point(177, 63);
            textBox_SimulatorFWVersion.Margin = new System.Windows.Forms.Padding(2);
            textBox_SimulatorFWVersion.Name = "textBox_SimulatorFWVersion";
            textBox_SimulatorFWVersion.ReadOnly = true;
            textBox_SimulatorFWVersion.Size = new System.Drawing.Size(92, 26);
            textBox_SimulatorFWVersion.TabIndex = 3;
            // 
            // textBox_SimulatorHWVersion
            // 
            textBox_SimulatorHWVersion.Location = new System.Drawing.Point(177, 34);
            textBox_SimulatorHWVersion.Margin = new System.Windows.Forms.Padding(2);
            textBox_SimulatorHWVersion.Name = "textBox_SimulatorHWVersion";
            textBox_SimulatorHWVersion.ReadOnly = true;
            textBox_SimulatorHWVersion.Size = new System.Drawing.Size(92, 26);
            textBox_SimulatorHWVersion.TabIndex = 1;
            // 
            // label95
            // 
            label95.AutoSize = true;
            label95.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label95.Location = new System.Drawing.Point(4, 14);
            label95.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label95.Name = "label95";
            label95.Size = new System.Drawing.Size(87, 23);
            label95.TabIndex = 0;
            label95.Text = "Simulator";
            // 
            // groupBox33
            // 
            groupBox33.Controls.Add(checkBox6);
            groupBox33.Controls.Add(button32);
            groupBox33.Controls.Add(textBox_RFDelay);
            groupBox33.Controls.Add(label100);
            groupBox33.Controls.Add(textBox_RFPeriod);
            groupBox33.Controls.Add(label99);
            groupBox33.Controls.Add(textBox_RFWidth);
            groupBox33.Controls.Add(label98);
            groupBox33.Location = new System.Drawing.Point(876, 23);
            groupBox33.Margin = new System.Windows.Forms.Padding(2);
            groupBox33.Name = "groupBox33";
            groupBox33.Padding = new System.Windows.Forms.Padding(2);
            groupBox33.Size = new System.Drawing.Size(354, 97);
            groupBox33.TabIndex = 2;
            groupBox33.TabStop = false;
            groupBox33.Text = "RF gen";
            // 
            // checkBox6
            // 
            checkBox6.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox6.AutoSize = true;
            checkBox6.Location = new System.Drawing.Point(268, 18);
            checkBox6.Margin = new System.Windows.Forms.Padding(2);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new System.Drawing.Size(64, 28);
            checkBox6.TabIndex = 17;
            checkBox6.Text = "Control";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.CheckedChanged += new System.EventHandler(checkBox6_CheckedChanged);
            // 
            // button32
            // 
            button32.Location = new System.Drawing.Point(222, 58);
            button32.Margin = new System.Windows.Forms.Padding(2);
            button32.Name = "button32";
            button32.Size = new System.Drawing.Size(112, 22);
            button32.TabIndex = 16;
            button32.Text = "Set RF gen parms";
            button32.UseVisualStyleBackColor = true;
            button32.Click += new System.EventHandler(button32_Click_1);
            // 
            // textBox_RFDelay
            // 
            textBox_RFDelay.Location = new System.Drawing.Point(165, 55);
            textBox_RFDelay.Margin = new System.Windows.Forms.Padding(2);
            textBox_RFDelay.Name = "textBox_RFDelay";
            textBox_RFDelay.Size = new System.Drawing.Size(53, 26);
            textBox_RFDelay.TabIndex = 15;
            textBox_RFDelay.Text = "0";
            // 
            // label100
            // 
            label100.AutoSize = true;
            label100.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label100.Location = new System.Drawing.Point(162, 36);
            label100.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label100.Name = "label100";
            label100.Size = new System.Drawing.Size(69, 15);
            label100.TabIndex = 14;
            label100.Text = "Delay (1us)";
            // 
            // textBox_RFPeriod
            // 
            textBox_RFPeriod.Location = new System.Drawing.Point(87, 55);
            textBox_RFPeriod.Margin = new System.Windows.Forms.Padding(2);
            textBox_RFPeriod.Name = "textBox_RFPeriod";
            textBox_RFPeriod.Size = new System.Drawing.Size(53, 26);
            textBox_RFPeriod.TabIndex = 13;
            textBox_RFPeriod.Text = "16";
            textBox_RFPeriod.TextChanged += new System.EventHandler(textBox_RFPeriod_TextChanged);
            // 
            // label99
            // 
            label99.AutoSize = true;
            label99.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label99.Location = new System.Drawing.Point(84, 36);
            label99.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label99.Name = "label99";
            label99.Size = new System.Drawing.Size(74, 15);
            label99.TabIndex = 12;
            label99.Text = "Period (1us)";
            // 
            // textBox_RFWidth
            // 
            textBox_RFWidth.Location = new System.Drawing.Point(18, 55);
            textBox_RFWidth.Margin = new System.Windows.Forms.Padding(2);
            textBox_RFWidth.Name = "textBox_RFWidth";
            textBox_RFWidth.Size = new System.Drawing.Size(53, 26);
            textBox_RFWidth.TabIndex = 11;
            textBox_RFWidth.Text = "2";
            textBox_RFWidth.TextChanged += new System.EventHandler(textBox_RFWidth_TextChanged);
            // 
            // label98
            // 
            label98.AutoSize = true;
            label98.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label98.Location = new System.Drawing.Point(6, 36);
            label98.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label98.Name = "label98";
            label98.Size = new System.Drawing.Size(72, 15);
            label98.TabIndex = 1;
            label98.Text = "Width (1us)";
            // 
            // tabPage13
            // 
            tabPage13.Controls.Add(dataGridView_ValPage0);
            tabPage13.Controls.Add(label81);
            tabPage13.Controls.Add(dataGridView_OverUnder);
            tabPage13.Controls.Add(label82);
            tabPage13.Controls.Add(textBox66);
            tabPage13.Controls.Add(label78);
            tabPage13.Controls.Add(textBox62);
            tabPage13.Controls.Add(label77);
            tabPage13.Controls.Add(textBox61);
            tabPage13.Location = new System.Drawing.Point(4, 27);
            tabPage13.Margin = new System.Windows.Forms.Padding(2);
            tabPage13.Name = "tabPage13";
            tabPage13.Size = new System.Drawing.Size(1234, 592);
            tabPage13.TabIndex = 4;
            tabPage13.Text = "Page 0";
            tabPage13.UseVisualStyleBackColor = true;
            // 
            // dataGridView_ValPage0
            // 
            dataGridView_ValPage0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_ValPage0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn29});
            dataGridView_ValPage0.Location = new System.Drawing.Point(435, 234);
            dataGridView_ValPage0.Margin = new System.Windows.Forms.Padding(2);
            dataGridView_ValPage0.Name = "dataGridView_ValPage0";
            dataGridView_ValPage0.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView_ValPage0.Size = new System.Drawing.Size(307, 350);
            dataGridView_ValPage0.TabIndex = 27;
            // 
            // dataGridViewTextBoxColumn29
            // 
            dataGridViewTextBoxColumn29.HeaderText = "Value";
            dataGridViewTextBoxColumn29.MinimumWidth = 6;
            dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            dataGridViewTextBoxColumn29.Width = 125;
            // 
            // label81
            // 
            label81.AutoSize = true;
            label81.Location = new System.Drawing.Point(484, 682);
            label81.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label81.Name = "label81";
            label81.Size = new System.Drawing.Size(115, 18);
            label81.TabIndex = 26;
            label81.Text = "TGA2700 DC4 Vdd";
            // 
            // dataGridView_OverUnder
            // 
            dataGridView_OverUnder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_OverUnder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn3,
            dataGridViewTextBoxColumn4,
            Column3});
            dataGridView_OverUnder.Location = new System.Drawing.Point(6, 234);
            dataGridView_OverUnder.Margin = new System.Windows.Forms.Padding(2);
            dataGridView_OverUnder.Name = "dataGridView_OverUnder";
            dataGridView_OverUnder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView_OverUnder.Size = new System.Drawing.Size(423, 350);
            dataGridView_OverUnder.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Over";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Under";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Hystersis";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // label82
            // 
            label82.AutoSize = true;
            label82.Location = new System.Drawing.Point(18, 184);
            label82.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label82.Name = "label82";
            label82.Size = new System.Drawing.Size(106, 18);
            label82.TabIndex = 16;
            label82.Text = "Calibration date";
            // 
            // textBox66
            // 
            textBox66.Location = new System.Drawing.Point(124, 178);
            textBox66.Margin = new System.Windows.Forms.Padding(2);
            textBox66.Name = "textBox66";
            textBox66.Size = new System.Drawing.Size(93, 26);
            textBox66.TabIndex = 15;
            // 
            // label78
            // 
            label78.AutoSize = true;
            label78.Location = new System.Drawing.Point(278, 42);
            label78.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label78.Name = "label78";
            label78.Size = new System.Drawing.Size(83, 18);
            label78.TabIndex = 8;
            label78.Text = "HW version:";
            // 
            // textBox62
            // 
            textBox62.Location = new System.Drawing.Point(402, 42);
            textBox62.Margin = new System.Windows.Forms.Padding(2);
            textBox62.Name = "textBox62";
            textBox62.Size = new System.Drawing.Size(92, 26);
            textBox62.TabIndex = 7;
            // 
            // label77
            // 
            label77.AutoSize = true;
            label77.Location = new System.Drawing.Point(18, 43);
            label77.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label77.Name = "label77";
            label77.Size = new System.Drawing.Size(99, 18);
            label77.TabIndex = 6;
            label77.Text = "Serial number:";
            label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox61
            // 
            textBox61.Location = new System.Drawing.Point(124, 41);
            textBox61.Margin = new System.Windows.Forms.Padding(2);
            textBox61.Name = "textBox61";
            textBox61.Size = new System.Drawing.Size(93, 26);
            textBox61.TabIndex = 5;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(label117);
            tabPage7.Controls.Add(label116);
            tabPage7.Controls.Add(dataGridView_Page1_4);
            tabPage7.Location = new System.Drawing.Point(4, 27);
            tabPage7.Margin = new System.Windows.Forms.Padding(2);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new System.Windows.Forms.Padding(2);
            tabPage7.Size = new System.Drawing.Size(1234, 592);
            tabPage7.TabIndex = 1;
            tabPage7.Text = "Page 1-4";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // label117
            // 
            label117.AutoSize = true;
            label117.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label117.Location = new System.Drawing.Point(474, 4);
            label117.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label117.Name = "label117";
            label117.Size = new System.Drawing.Size(108, 23);
            label117.TabIndex = 31;
            label117.Text = "DC4-40 dBm";
            // 
            // label116
            // 
            label116.AutoSize = true;
            label116.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label116.Location = new System.Drawing.Point(173, 3);
            label116.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label116.Name = "label116";
            label116.Size = new System.Drawing.Size(70, 23);
            label116.TabIndex = 30;
            label116.Text = "46 dBm";
            // 
            // dataGridView_Page1_4
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridView_Page1_4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView_Page1_4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView_Page1_4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            dataGridView_Page1_4.ColumnHeadersHeight = 29;
            dataGridView_Page1_4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn1,
            dataGridViewTextBoxColumn2,
            dataGridViewTextBoxColumn23,
            dataGridViewTextBoxColumn24,
            dataGridViewTextBoxColumn25,
            dataGridViewTextBoxColumn26,
            dataGridViewTextBoxColumn27,
            dataGridViewTextBoxColumn28,
            Column14,
            Column15,
            Column16,
            Column17,
            Column18,
            Column19,
            Column20,
            Column21});
            dataGridView_Page1_4.Location = new System.Drawing.Point(9, 36);
            dataGridView_Page1_4.Margin = new System.Windows.Forms.Padding(2);
            dataGridView_Page1_4.Name = "dataGridView_Page1_4";
            dataGridView_Page1_4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridView_Page1_4.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView_Page1_4.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridView_Page1_4.Size = new System.Drawing.Size(938, 552);
            dataGridView_Page1_4.TabIndex = 28;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "F0";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 47;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "F1";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 47;
            // 
            // dataGridViewTextBoxColumn23
            // 
            dataGridViewTextBoxColumn23.HeaderText = "F2";
            dataGridViewTextBoxColumn23.MinimumWidth = 6;
            dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            dataGridViewTextBoxColumn23.Width = 47;
            // 
            // dataGridViewTextBoxColumn24
            // 
            dataGridViewTextBoxColumn24.HeaderText = "F3";
            dataGridViewTextBoxColumn24.MinimumWidth = 6;
            dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            dataGridViewTextBoxColumn24.Width = 47;
            // 
            // dataGridViewTextBoxColumn25
            // 
            dataGridViewTextBoxColumn25.HeaderText = "F4";
            dataGridViewTextBoxColumn25.MinimumWidth = 6;
            dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            dataGridViewTextBoxColumn25.Width = 47;
            // 
            // dataGridViewTextBoxColumn26
            // 
            dataGridViewTextBoxColumn26.HeaderText = "F5";
            dataGridViewTextBoxColumn26.MinimumWidth = 6;
            dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            dataGridViewTextBoxColumn26.Width = 47;
            // 
            // dataGridViewTextBoxColumn27
            // 
            dataGridViewTextBoxColumn27.HeaderText = "F6";
            dataGridViewTextBoxColumn27.MinimumWidth = 6;
            dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            dataGridViewTextBoxColumn27.Width = 47;
            // 
            // dataGridViewTextBoxColumn28
            // 
            dataGridViewTextBoxColumn28.HeaderText = "F7";
            dataGridViewTextBoxColumn28.MinimumWidth = 6;
            dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            dataGridViewTextBoxColumn28.Width = 47;
            // 
            // Column14
            // 
            Column14.HeaderText = "F0";
            Column14.MinimumWidth = 6;
            Column14.Name = "Column14";
            Column14.Width = 47;
            // 
            // Column15
            // 
            Column15.HeaderText = "F1";
            Column15.MinimumWidth = 6;
            Column15.Name = "Column15";
            Column15.Width = 47;
            // 
            // Column16
            // 
            Column16.HeaderText = "F2";
            Column16.MinimumWidth = 6;
            Column16.Name = "Column16";
            Column16.Width = 47;
            // 
            // Column17
            // 
            Column17.HeaderText = "F3";
            Column17.MinimumWidth = 6;
            Column17.Name = "Column17";
            Column17.Width = 47;
            // 
            // Column18
            // 
            Column18.HeaderText = "F4";
            Column18.MinimumWidth = 6;
            Column18.Name = "Column18";
            Column18.Width = 47;
            // 
            // Column19
            // 
            Column19.HeaderText = "F5";
            Column19.MinimumWidth = 6;
            Column19.Name = "Column19";
            Column19.Width = 47;
            // 
            // Column20
            // 
            Column20.HeaderText = "F6";
            Column20.MinimumWidth = 6;
            Column20.Name = "Column20";
            Column20.Width = 47;
            // 
            // Column21
            // 
            Column21.HeaderText = "F7";
            Column21.MinimumWidth = 6;
            Column21.Name = "Column21";
            Column21.Width = 47;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(label89);
            tabPage8.Controls.Add(dataGridView_VVAOffset1);
            tabPage8.Controls.Add(label88);
            tabPage8.Controls.Add(dataGridView_VVAOffset2);
            tabPage8.Controls.Add(label87);
            tabPage8.Controls.Add(label86);
            tabPage8.Controls.Add(dataGridView_PAVVA);
            tabPage8.Controls.Add(label76);
            tabPage8.Controls.Add(label75);
            tabPage8.Controls.Add(dataGridView_DC4);
            tabPage8.Location = new System.Drawing.Point(4, 27);
            tabPage8.Margin = new System.Windows.Forms.Padding(2);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new System.Drawing.Size(1234, 592);
            tabPage8.TabIndex = 2;
            tabPage8.Text = "Page 5-7";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // label89
            // 
            label89.AutoSize = true;
            label89.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label89.Location = new System.Drawing.Point(755, 304);
            label89.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label89.Name = "label89";
            label89.Size = new System.Drawing.Size(100, 23);
            label89.TabIndex = 12;
            label89.Text = "Vdd offset1";
            // 
            // dataGridView_VVAOffset1
            // 
            dataGridView_VVAOffset1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView_VVAOffset1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_VVAOffset1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn10,
            dataGridViewTextBoxColumn11,
            dataGridViewTextBoxColumn12,
            dataGridViewTextBoxColumn13,
            dataGridViewTextBoxColumn14,
            dataGridViewTextBoxColumn15,
            dataGridViewTextBoxColumn16,
            dataGridViewTextBoxColumn17});
            dataGridView_VVAOffset1.Location = new System.Drawing.Point(712, 330);
            dataGridView_VVAOffset1.Margin = new System.Windows.Forms.Padding(2);
            dataGridView_VVAOffset1.Name = "dataGridView_VVAOffset1";
            dataGridView_VVAOffset1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView_VVAOffset1.Size = new System.Drawing.Size(508, 256);
            dataGridView_VVAOffset1.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.HeaderText = "F0";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.Width = 47;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "F1";
            dataGridViewTextBoxColumn11.MinimumWidth = 6;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.Width = 47;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.HeaderText = "F2";
            dataGridViewTextBoxColumn12.MinimumWidth = 6;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.Width = 47;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.HeaderText = "F3";
            dataGridViewTextBoxColumn13.MinimumWidth = 6;
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.Width = 47;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.HeaderText = "F4";
            dataGridViewTextBoxColumn14.MinimumWidth = 6;
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.Width = 47;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.HeaderText = "F5";
            dataGridViewTextBoxColumn15.MinimumWidth = 6;
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.Width = 47;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.HeaderText = "F6";
            dataGridViewTextBoxColumn16.MinimumWidth = 6;
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.Width = 47;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.HeaderText = "F7";
            dataGridViewTextBoxColumn17.MinimumWidth = 6;
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.Width = 47;
            // 
            // label88
            // 
            label88.AutoSize = true;
            label88.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label88.Location = new System.Drawing.Point(755, 10);
            label88.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label88.Name = "label88";
            label88.Size = new System.Drawing.Size(103, 23);
            label88.TabIndex = 10;
            label88.Text = "VVA offset2";
            // 
            // dataGridView_VVAOffset2
            // 
            dataGridView_VVAOffset2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView_VVAOffset2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView_VVAOffset2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_VVAOffset2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn8,
            dataGridViewTextBoxColumn9,
            Column4,
            Column5,
            Column6,
            Column7,
            Column8,
            Column9});
            dataGridView_VVAOffset2.Location = new System.Drawing.Point(712, 41);
            dataGridView_VVAOffset2.Margin = new System.Windows.Forms.Padding(2);
            dataGridView_VVAOffset2.Name = "dataGridView_VVAOffset2";
            dataGridView_VVAOffset2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView_VVAOffset2.Size = new System.Drawing.Size(510, 262);
            dataGridView_VVAOffset2.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "F0";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Width = 47;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "F1";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Width = 47;
            // 
            // Column4
            // 
            Column4.HeaderText = "F2";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 47;
            // 
            // Column5
            // 
            Column5.HeaderText = "F3";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 47;
            // 
            // Column6
            // 
            Column6.HeaderText = "F4";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 47;
            // 
            // Column7
            // 
            Column7.HeaderText = "F5";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 47;
            // 
            // Column8
            // 
            Column8.HeaderText = "F6";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.Width = 47;
            // 
            // Column9
            // 
            Column9.HeaderText = "F7";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.Width = 47;
            // 
            // label87
            // 
            label87.AutoSize = true;
            label87.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label87.Location = new System.Drawing.Point(441, 8);
            label87.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label87.Name = "label87";
            label87.Size = new System.Drawing.Size(105, 23);
            label87.TabIndex = 8;
            label87.Text = "DCA control";
            // 
            // label86
            // 
            label86.AutoSize = true;
            label86.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label86.Location = new System.Drawing.Point(331, 8);
            label86.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label86.Name = "label86";
            label86.Size = new System.Drawing.Size(118, 23);
            label86.TabIndex = 6;
            label86.Text = "PA VVA offset";
            // 
            // dataGridView_PAVVA
            // 
            dataGridView_PAVVA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView_PAVVA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_PAVVA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn5,
            Column12,
            Column13});
            dataGridView_PAVVA.Location = new System.Drawing.Point(346, 41);
            dataGridView_PAVVA.Margin = new System.Windows.Forms.Padding(2);
            dataGridView_PAVVA.Name = "dataGridView_PAVVA";
            dataGridView_PAVVA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView_PAVVA.Size = new System.Drawing.Size(361, 545);
            dataGridView_PAVVA.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "VVA";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 59;
            // 
            // Column12
            // 
            Column12.HeaderText = "DCA1";
            Column12.MinimumWidth = 6;
            Column12.Name = "Column12";
            Column12.Width = 66;
            // 
            // Column13
            // 
            Column13.HeaderText = "DCA2";
            Column13.MinimumWidth = 6;
            Column13.Name = "Column13";
            Column13.Width = 66;
            // 
            // label76
            // 
            label76.AutoSize = true;
            label76.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label76.Location = new System.Drawing.Point(258, 12);
            label76.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label76.Name = "label76";
            label76.Size = new System.Drawing.Size(66, 23);
            label76.TabIndex = 4;
            label76.Text = "DC4 on";
            // 
            // label75
            // 
            label75.AutoSize = true;
            label75.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label75.Location = new System.Drawing.Point(162, 10);
            label75.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label75.Name = "label75";
            label75.Size = new System.Drawing.Size(67, 23);
            label75.TabIndex = 2;
            label75.Text = "DC4 off";
            // 
            // dataGridView_DC4
            // 
            dataGridView_DC4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView_DC4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_DC4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            Column1,
            Column2,
            Column10,
            Column11});
            dataGridView_DC4.Location = new System.Drawing.Point(2, 43);
            dataGridView_DC4.Margin = new System.Windows.Forms.Padding(2);
            dataGridView_DC4.Name = "dataGridView_DC4";
            dataGridView_DC4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridView_DC4.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView_DC4.Size = new System.Drawing.Size(338, 546);
            dataGridView_DC4.TabIndex = 1;
            dataGridView_DC4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            Column1.HeaderText = "28V";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 56;
            // 
            // Column2
            // 
            Column2.HeaderText = "Vgg";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 55;
            // 
            // Column10
            // 
            Column10.HeaderText = "28V";
            Column10.MinimumWidth = 6;
            Column10.Name = "Column10";
            Column10.Width = 56;
            // 
            // Column11
            // 
            Column11.HeaderText = "Vgg";
            Column11.MinimumWidth = 6;
            Column11.Name = "Column11";
            Column11.Width = 55;
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(label92);
            tabPage9.Controls.Add(dataGridView10);
            tabPage9.Controls.Add(label91);
            tabPage9.Controls.Add(dataGridView9);
            tabPage9.Controls.Add(label90);
            tabPage9.Controls.Add(dataGridView8);
            tabPage9.Location = new System.Drawing.Point(4, 27);
            tabPage9.Margin = new System.Windows.Forms.Padding(2);
            tabPage9.Name = "tabPage9";
            tabPage9.Size = new System.Drawing.Size(1234, 592);
            tabPage9.TabIndex = 3;
            tabPage9.Text = "Page 8";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // label92
            // 
            label92.AutoSize = true;
            label92.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label92.Location = new System.Drawing.Point(489, 13);
            label92.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label92.Name = "label92";
            label92.Size = new System.Drawing.Size(169, 23);
            label92.TabIndex = 12;
            label92.Text = "Pulse fall time delay";
            // 
            // dataGridView10
            // 
            dataGridView10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn21,
            dataGridViewTextBoxColumn22});
            dataGridView10.Location = new System.Drawing.Point(486, 42);
            dataGridView10.Margin = new System.Windows.Forms.Padding(2);
            dataGridView10.Name = "dataGridView10";
            dataGridView10.RowHeadersWidth = 51;
            dataGridView10.Size = new System.Drawing.Size(151, 546);
            dataGridView10.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn21
            // 
            dataGridViewTextBoxColumn21.HeaderText = "MPA";
            dataGridViewTextBoxColumn21.MinimumWidth = 6;
            dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            dataGridViewTextBoxColumn21.Width = 61;
            // 
            // dataGridViewTextBoxColumn22
            // 
            dataGridViewTextBoxColumn22.HeaderText = "SPA";
            dataGridViewTextBoxColumn22.MinimumWidth = 6;
            dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            dataGridViewTextBoxColumn22.Width = 56;
            // 
            // label91
            // 
            label91.AutoSize = true;
            label91.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label91.Location = new System.Drawing.Point(262, 13);
            label91.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label91.Name = "label91";
            label91.Size = new System.Drawing.Size(181, 23);
            label91.TabIndex = 10;
            label91.Text = "Pulse Rise Time delay";
            // 
            // dataGridView9
            // 
            dataGridView9.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView9.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn19,
            dataGridViewTextBoxColumn20});
            dataGridView9.Location = new System.Drawing.Point(258, 42);
            dataGridView9.Margin = new System.Windows.Forms.Padding(2);
            dataGridView9.Name = "dataGridView9";
            dataGridView9.RowHeadersWidth = 51;
            dataGridView9.Size = new System.Drawing.Size(151, 546);
            dataGridView9.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn19
            // 
            dataGridViewTextBoxColumn19.HeaderText = "MPA";
            dataGridViewTextBoxColumn19.MinimumWidth = 6;
            dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            dataGridViewTextBoxColumn19.Width = 61;
            // 
            // dataGridViewTextBoxColumn20
            // 
            dataGridViewTextBoxColumn20.HeaderText = "SPA";
            dataGridViewTextBoxColumn20.MinimumWidth = 6;
            dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            dataGridViewTextBoxColumn20.Width = 56;
            // 
            // label90
            // 
            label90.AutoSize = true;
            label90.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label90.Location = new System.Drawing.Point(11, 13);
            label90.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label90.Name = "label90";
            label90.Size = new System.Drawing.Size(77, 23);
            label90.TabIndex = 8;
            label90.Text = "SAR-SAT";
            // 
            // dataGridView8
            // 
            dataGridView8.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView8.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn18});
            dataGridView8.Location = new System.Drawing.Point(12, 46);
            dataGridView8.Margin = new System.Windows.Forms.Padding(2);
            dataGridView8.Name = "dataGridView8";
            dataGridView8.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView8.Size = new System.Drawing.Size(220, 545);
            dataGridView8.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn18
            // 
            dataGridViewTextBoxColumn18.HeaderText = "Value";
            dataGridViewTextBoxColumn18.MinimumWidth = 6;
            dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            dataGridViewTextBoxColumn18.Width = 68;
            // 
            // groupBox42
            // 
            groupBox42.Controls.Add(radioButton_TCPIP);
            groupBox42.Controls.Add(radioButton_SerialPort);
            groupBox42.Location = new System.Drawing.Point(1427, 332);
            groupBox42.Margin = new System.Windows.Forms.Padding(2);
            groupBox42.Name = "groupBox42";
            groupBox42.Padding = new System.Windows.Forms.Padding(2);
            groupBox42.Size = new System.Drawing.Size(183, 97);
            groupBox42.TabIndex = 33;
            groupBox42.TabStop = false;
            groupBox42.Text = "Communication gatway";
            // 
            // radioButton_TCPIP
            // 
            radioButton_TCPIP.AutoSize = true;
            radioButton_TCPIP.Location = new System.Drawing.Point(18, 54);
            radioButton_TCPIP.Margin = new System.Windows.Forms.Padding(2);
            radioButton_TCPIP.Name = "radioButton_TCPIP";
            radioButton_TCPIP.Size = new System.Drawing.Size(66, 22);
            radioButton_TCPIP.TabIndex = 1;
            radioButton_TCPIP.TabStop = true;
            radioButton_TCPIP.Text = "TCP/IP";
            radioButton_TCPIP.UseVisualStyleBackColor = true;
            // 
            // radioButton_SerialPort
            // 
            radioButton_SerialPort.AutoSize = true;
            radioButton_SerialPort.Checked = true;
            radioButton_SerialPort.Location = new System.Drawing.Point(18, 25);
            radioButton_SerialPort.Margin = new System.Windows.Forms.Padding(2);
            radioButton_SerialPort.Name = "radioButton_SerialPort";
            radioButton_SerialPort.Size = new System.Drawing.Size(90, 22);
            radioButton_SerialPort.TabIndex = 0;
            radioButton_SerialPort.TabStop = true;
            radioButton_SerialPort.Text = "Serial Port";
            radioButton_SerialPort.UseVisualStyleBackColor = true;
            // 
            // button_OpenFolder
            // 
            button_OpenFolder.Location = new System.Drawing.Point(1427, 294);
            button_OpenFolder.Margin = new System.Windows.Forms.Padding(2);
            button_OpenFolder.Name = "button_OpenFolder";
            button_OpenFolder.Size = new System.Drawing.Size(174, 25);
            button_OpenFolder.TabIndex = 76;
            button_OpenFolder.Text = "Open Folder";
            button_OpenFolder.UseVisualStyleBackColor = true;
            button_OpenFolder.Click += new System.EventHandler(Button43_Click);
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(S1_Configuration);
            tabPage4.Location = new System.Drawing.Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new System.Drawing.Size(1406, 776);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "S1 Configuration";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // S1_Configuration
            // 
            S1_Configuration.Controls.Add(groupBox12);
            S1_Configuration.Controls.Add(groupBox22);
            S1_Configuration.Controls.Add(groupBox28);
            S1_Configuration.Controls.Add(groupBox30);
            S1_Configuration.Controls.Add(groupBox29);
            S1_Configuration.Controls.Add(groupBox27);
            S1_Configuration.Controls.Add(groupBox26);
            S1_Configuration.Controls.Add(groupBox25);
            S1_Configuration.Controls.Add(groupBox24);
            S1_Configuration.Controls.Add(groupBox23);
            S1_Configuration.Controls.Add(groupBox21);
            S1_Configuration.Controls.Add(groupBox20);
            S1_Configuration.Controls.Add(groupBox19);
            S1_Configuration.Controls.Add(groupBox18);
            S1_Configuration.Controls.Add(groupBox17);
            S1_Configuration.Controls.Add(groupBox11);
            S1_Configuration.Controls.Add(groupBox10);
            S1_Configuration.Controls.Add(groupBox9);
            S1_Configuration.Controls.Add(groupBox8);
            S1_Configuration.Controls.Add(groupBox7);
            S1_Configuration.Controls.Add(groupBox6);
            S1_Configuration.Controls.Add(groupBox13);
            S1_Configuration.Controls.Add(groupBox14);
            S1_Configuration.Controls.Add(groupBox15);
            S1_Configuration.Controls.Add(groupBox16);
            S1_Configuration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            S1_Configuration.Location = new System.Drawing.Point(3, 3);
            S1_Configuration.Name = "S1_Configuration";
            S1_Configuration.Size = new System.Drawing.Size(924, 741);
            S1_Configuration.TabIndex = 12;
            S1_Configuration.TabStop = false;
            S1_Configuration.Text = "S1 Configuration";
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(button13);
            groupBox12.Location = new System.Drawing.Point(716, 24);
            groupBox12.Name = "groupBox12";
            groupBox12.Size = new System.Drawing.Size(164, 58);
            groupBox12.TabIndex = 67;
            groupBox12.TabStop = false;
            groupBox12.Text = "RF pairing";
            // 
            // button13
            // 
            button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button13.Location = new System.Drawing.Point(10, 20);
            button13.Name = "button13";
            button13.Size = new System.Drawing.Size(152, 26);
            button13.TabIndex = 49;
            button13.Text = "RF Pairing";
            button13.UseVisualStyleBackColor = true;
            button13.Click += new System.EventHandler(Button13_Click);
            // 
            // groupBox22
            // 
            groupBox22.Controls.Add(TextBox_Odometer);
            groupBox22.Controls.Add(button19);
            groupBox22.Location = new System.Drawing.Point(718, 88);
            groupBox22.Name = "groupBox22";
            groupBox22.Size = new System.Drawing.Size(200, 78);
            groupBox22.TabIndex = 68;
            groupBox22.TabStop = false;
            groupBox22.Text = "Odometer";
            // 
            // TextBox_Odometer
            // 
            TextBox_Odometer.Location = new System.Drawing.Point(6, 23);
            TextBox_Odometer.Name = "TextBox_Odometer";
            TextBox_Odometer.Size = new System.Drawing.Size(100, 22);
            TextBox_Odometer.TabIndex = 64;
            // 
            // button19
            // 
            button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button19.Location = new System.Drawing.Point(6, 50);
            button19.Name = "button19";
            button19.Size = new System.Drawing.Size(74, 26);
            button19.TabIndex = 63;
            button19.Text = "Odometer Config";
            button19.UseVisualStyleBackColor = true;
            button19.Click += new System.EventHandler(Button19_Click);
            // 
            // groupBox28
            // 
            groupBox28.Controls.Add(textBox_ModemSocket);
            groupBox28.Controls.Add(textBox_ModemRetries);
            groupBox28.Controls.Add(textBox_ModemTimeOut);
            groupBox28.Controls.Add(button25);
            groupBox28.Controls.Add(textBox_ModemPrimeryPort);
            groupBox28.Controls.Add(textBox_ModemPrimeryHost);
            groupBox28.Location = new System.Drawing.Point(188, 499);
            groupBox28.Name = "groupBox28";
            groupBox28.Size = new System.Drawing.Size(146, 195);
            groupBox28.TabIndex = 45;
            groupBox28.TabStop = false;
            groupBox28.Text = "Modem Config";
            // 
            // textBox_ModemSocket
            // 
            textBox_ModemSocket.Location = new System.Drawing.Point(8, 77);
            textBox_ModemSocket.Name = "textBox_ModemSocket";
            textBox_ModemSocket.Size = new System.Drawing.Size(132, 22);
            textBox_ModemSocket.TabIndex = 80;
            // 
            // textBox_ModemRetries
            // 
            textBox_ModemRetries.Location = new System.Drawing.Point(8, 50);
            textBox_ModemRetries.Name = "textBox_ModemRetries";
            textBox_ModemRetries.Size = new System.Drawing.Size(132, 22);
            textBox_ModemRetries.TabIndex = 79;
            // 
            // textBox_ModemTimeOut
            // 
            textBox_ModemTimeOut.Location = new System.Drawing.Point(8, 23);
            textBox_ModemTimeOut.Name = "textBox_ModemTimeOut";
            textBox_ModemTimeOut.Size = new System.Drawing.Size(132, 22);
            textBox_ModemTimeOut.TabIndex = 78;
            // 
            // button25
            // 
            button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button25.Location = new System.Drawing.Point(8, 157);
            button25.Name = "button25";
            button25.Size = new System.Drawing.Size(132, 26);
            button25.TabIndex = 44;
            button25.Text = "Config Modem";
            button25.UseVisualStyleBackColor = true;
            button25.Click += new System.EventHandler(Button25_Click);
            // 
            // textBox_ModemPrimeryPort
            // 
            textBox_ModemPrimeryPort.Location = new System.Drawing.Point(8, 129);
            textBox_ModemPrimeryPort.Name = "textBox_ModemPrimeryPort";
            textBox_ModemPrimeryPort.Size = new System.Drawing.Size(132, 22);
            textBox_ModemPrimeryPort.TabIndex = 37;
            // 
            // textBox_ModemPrimeryHost
            // 
            textBox_ModemPrimeryHost.Location = new System.Drawing.Point(8, 101);
            textBox_ModemPrimeryHost.Name = "textBox_ModemPrimeryHost";
            textBox_ModemPrimeryHost.Size = new System.Drawing.Size(132, 22);
            textBox_ModemPrimeryHost.TabIndex = 36;
            // 
            // groupBox30
            // 
            groupBox30.Controls.Add(textBox_ForginPassword);
            groupBox30.Controls.Add(button27);
            groupBox30.Controls.Add(textBox_ForginAcessPoint);
            groupBox30.Controls.Add(textBox_ForginSecondaryDNS);
            groupBox30.Controls.Add(textBox_ForginUserName);
            groupBox30.Controls.Add(textBox_ForginPrimeryDNS);
            groupBox30.Location = new System.Drawing.Point(344, 499);
            groupBox30.Name = "groupBox30";
            groupBox30.Size = new System.Drawing.Size(160, 195);
            groupBox30.TabIndex = 47;
            groupBox30.TabStop = false;
            groupBox30.Text = "Config Forgin Network";
            // 
            // textBox_ForginPassword
            // 
            textBox_ForginPassword.Location = new System.Drawing.Point(8, 77);
            textBox_ForginPassword.Name = "textBox_ForginPassword";
            textBox_ForginPassword.Size = new System.Drawing.Size(146, 22);
            textBox_ForginPassword.TabIndex = 35;
            // 
            // button27
            // 
            button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button27.Location = new System.Drawing.Point(8, 157);
            button27.Name = "button27";
            button27.Size = new System.Drawing.Size(146, 26);
            button27.TabIndex = 44;
            button27.Text = "Config Forgin Net";
            button27.UseVisualStyleBackColor = true;
            button27.Click += new System.EventHandler(Button27_Click);
            // 
            // textBox_ForginAcessPoint
            // 
            textBox_ForginAcessPoint.Location = new System.Drawing.Point(7, 23);
            textBox_ForginAcessPoint.Name = "textBox_ForginAcessPoint";
            textBox_ForginAcessPoint.Size = new System.Drawing.Size(147, 22);
            textBox_ForginAcessPoint.TabIndex = 33;
            // 
            // textBox_ForginSecondaryDNS
            // 
            textBox_ForginSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            textBox_ForginSecondaryDNS.Name = "textBox_ForginSecondaryDNS";
            textBox_ForginSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            textBox_ForginSecondaryDNS.TabIndex = 37;
            // 
            // textBox_ForginUserName
            // 
            textBox_ForginUserName.Location = new System.Drawing.Point(8, 51);
            textBox_ForginUserName.Name = "textBox_ForginUserName";
            textBox_ForginUserName.Size = new System.Drawing.Size(146, 22);
            textBox_ForginUserName.TabIndex = 34;
            // 
            // textBox_ForginPrimeryDNS
            // 
            textBox_ForginPrimeryDNS.Location = new System.Drawing.Point(8, 101);
            textBox_ForginPrimeryDNS.Name = "textBox_ForginPrimeryDNS";
            textBox_ForginPrimeryDNS.Size = new System.Drawing.Size(146, 22);
            textBox_ForginPrimeryDNS.TabIndex = 36;
            // 
            // groupBox29
            // 
            groupBox29.Controls.Add(textBox_HomePassword);
            groupBox29.Controls.Add(button26);
            groupBox29.Controls.Add(textBox_HomeAcessPoint);
            groupBox29.Controls.Add(textBox_HomeSecondaryDNS);
            groupBox29.Controls.Add(textBox_HomeUserName);
            groupBox29.Controls.Add(textBox_HomePrimeryDNS);
            groupBox29.Location = new System.Drawing.Point(345, 298);
            groupBox29.Name = "groupBox29";
            groupBox29.Size = new System.Drawing.Size(160, 195);
            groupBox29.TabIndex = 46;
            groupBox29.TabStop = false;
            groupBox29.Text = "Config Home Net";
            // 
            // textBox_HomePassword
            // 
            textBox_HomePassword.Location = new System.Drawing.Point(8, 77);
            textBox_HomePassword.Name = "textBox_HomePassword";
            textBox_HomePassword.Size = new System.Drawing.Size(146, 22);
            textBox_HomePassword.TabIndex = 35;
            textBox_HomePassword.Text = "Password";
            // 
            // button26
            // 
            button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button26.Location = new System.Drawing.Point(8, 157);
            button26.Name = "button26";
            button26.Size = new System.Drawing.Size(146, 26);
            button26.TabIndex = 44;
            button26.Text = "Config Home Net";
            button26.UseVisualStyleBackColor = true;
            button26.Click += new System.EventHandler(Button26_Click);
            // 
            // textBox_HomeAcessPoint
            // 
            textBox_HomeAcessPoint.Location = new System.Drawing.Point(7, 23);
            textBox_HomeAcessPoint.Name = "textBox_HomeAcessPoint";
            textBox_HomeAcessPoint.Size = new System.Drawing.Size(147, 22);
            textBox_HomeAcessPoint.TabIndex = 33;
            textBox_HomeAcessPoint.Text = "Aceess point";
            // 
            // textBox_HomeSecondaryDNS
            // 
            textBox_HomeSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            textBox_HomeSecondaryDNS.Name = "textBox_HomeSecondaryDNS";
            textBox_HomeSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            textBox_HomeSecondaryDNS.TabIndex = 37;
            textBox_HomeSecondaryDNS.Text = "Secondary DNS";
            // 
            // textBox_HomeUserName
            // 
            textBox_HomeUserName.Location = new System.Drawing.Point(8, 51);
            textBox_HomeUserName.Name = "textBox_HomeUserName";
            textBox_HomeUserName.Size = new System.Drawing.Size(146, 22);
            textBox_HomeUserName.TabIndex = 34;
            textBox_HomeUserName.Text = "User Name";
            // 
            // textBox_HomePrimeryDNS
            // 
            textBox_HomePrimeryDNS.Location = new System.Drawing.Point(8, 101);
            textBox_HomePrimeryDNS.Name = "textBox_HomePrimeryDNS";
            textBox_HomePrimeryDNS.Size = new System.Drawing.Size(146, 22);
            textBox_HomePrimeryDNS.TabIndex = 36;
            textBox_HomePrimeryDNS.Text = "Primery DNS";
            // 
            // groupBox27
            // 
            groupBox27.Controls.Add(maskedTextBox1);
            groupBox27.Controls.Add(button24);
            groupBox27.Location = new System.Drawing.Point(315, 107);
            groupBox27.Name = "groupBox27";
            groupBox27.Size = new System.Drawing.Size(145, 78);
            groupBox27.TabIndex = 72;
            groupBox27.TabStop = false;
            groupBox27.Text = "Sleep Status Duration";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new System.Drawing.Point(6, 18);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            maskedTextBox1.TabIndex = 71;
            // 
            // button24
            // 
            button24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button24.Location = new System.Drawing.Point(6, 45);
            button24.Name = "button24";
            button24.Size = new System.Drawing.Size(131, 26);
            button24.TabIndex = 70;
            button24.Text = "Duration sleep";
            button24.UseVisualStyleBackColor = true;
            button24.Click += new System.EventHandler(Button24_Click);
            // 
            // groupBox26
            // 
            groupBox26.Controls.Add(TextBox_NormalStatusDuration);
            groupBox26.Controls.Add(button23);
            groupBox26.Location = new System.Drawing.Point(334, 24);
            groupBox26.Name = "groupBox26";
            groupBox26.Size = new System.Drawing.Size(171, 77);
            groupBox26.TabIndex = 71;
            groupBox26.TabStop = false;
            groupBox26.Text = "Normal Status Duration";
            // 
            // TextBox_NormalStatusDuration
            // 
            TextBox_NormalStatusDuration.Location = new System.Drawing.Point(6, 17);
            TextBox_NormalStatusDuration.Name = "TextBox_NormalStatusDuration";
            TextBox_NormalStatusDuration.Size = new System.Drawing.Size(100, 22);
            TextBox_NormalStatusDuration.TabIndex = 71;
            // 
            // button23
            // 
            button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button23.Location = new System.Drawing.Point(6, 45);
            button23.Name = "button23";
            button23.Size = new System.Drawing.Size(111, 26);
            button23.TabIndex = 70;
            button23.Text = "Set Duration";
            button23.UseVisualStyleBackColor = true;
            button23.Click += new System.EventHandler(Button23_Click);
            // 
            // groupBox25
            // 
            groupBox25.Controls.Add(maskedTextBox_SpeedLimit2);
            groupBox25.Controls.Add(maskedTextBox_SpeedLimit3);
            groupBox25.Controls.Add(maskedTextBox_SpeedLimit1);
            groupBox25.Controls.Add(button22);
            groupBox25.Location = new System.Drawing.Point(510, 557);
            groupBox25.Name = "groupBox25";
            groupBox25.Size = new System.Drawing.Size(200, 89);
            groupBox25.TabIndex = 70;
            groupBox25.TabStop = false;
            groupBox25.Text = "Speed Limit Config";
            // 
            // maskedTextBox_SpeedLimit2
            // 
            maskedTextBox_SpeedLimit2.Location = new System.Drawing.Point(53, 20);
            maskedTextBox_SpeedLimit2.Name = "maskedTextBox_SpeedLimit2";
            maskedTextBox_SpeedLimit2.Size = new System.Drawing.Size(41, 22);
            maskedTextBox_SpeedLimit2.TabIndex = 80;
            // 
            // maskedTextBox_SpeedLimit3
            // 
            maskedTextBox_SpeedLimit3.Location = new System.Drawing.Point(101, 19);
            maskedTextBox_SpeedLimit3.Name = "maskedTextBox_SpeedLimit3";
            maskedTextBox_SpeedLimit3.Size = new System.Drawing.Size(41, 22);
            maskedTextBox_SpeedLimit3.TabIndex = 79;
            // 
            // maskedTextBox_SpeedLimit1
            // 
            maskedTextBox_SpeedLimit1.Location = new System.Drawing.Point(6, 20);
            maskedTextBox_SpeedLimit1.Name = "maskedTextBox_SpeedLimit1";
            maskedTextBox_SpeedLimit1.Size = new System.Drawing.Size(41, 22);
            maskedTextBox_SpeedLimit1.TabIndex = 78;
            // 
            // button22
            // 
            button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button22.Location = new System.Drawing.Point(6, 47);
            button22.Name = "button22";
            button22.Size = new System.Drawing.Size(140, 26);
            button22.TabIndex = 65;
            button22.Text = "Speed Limit Alert";
            button22.UseVisualStyleBackColor = true;
            button22.Click += new System.EventHandler(Button22_Click);
            // 
            // groupBox24
            // 
            groupBox24.Controls.Add(comboBox_DispatchSpeed);
            groupBox24.Controls.Add(button21);
            groupBox24.Location = new System.Drawing.Point(228, 377);
            groupBox24.Name = "groupBox24";
            groupBox24.Size = new System.Drawing.Size(106, 103);
            groupBox24.TabIndex = 68;
            groupBox24.TabStop = false;
            groupBox24.Text = "Dispatch Speed Limit";
            // 
            // comboBox_DispatchSpeed
            // 
            comboBox_DispatchSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_DispatchSpeed.FormattingEnabled = true;
            comboBox_DispatchSpeed.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_DispatchSpeed.Location = new System.Drawing.Point(8, 44);
            comboBox_DispatchSpeed.Name = "comboBox_DispatchSpeed";
            comboBox_DispatchSpeed.Size = new System.Drawing.Size(94, 21);
            comboBox_DispatchSpeed.TabIndex = 63;
            comboBox_DispatchSpeed.Text = "Speed";
            // 
            // button21
            // 
            button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button21.Location = new System.Drawing.Point(8, 71);
            button21.Name = "button21";
            button21.Size = new System.Drawing.Size(94, 26);
            button21.TabIndex = 64;
            button21.Text = "Dispatch Speed";
            button21.UseVisualStyleBackColor = true;
            button21.Click += new System.EventHandler(Button21_Click);
            // 
            // groupBox23
            // 
            groupBox23.Controls.Add(comboBox_KillEngine);
            groupBox23.Controls.Add(button20);
            groupBox23.Location = new System.Drawing.Point(230, 287);
            groupBox23.Name = "groupBox23";
            groupBox23.Size = new System.Drawing.Size(109, 91);
            groupBox23.TabIndex = 67;
            groupBox23.TabStop = false;
            groupBox23.Text = "Kill Engine";
            // 
            // comboBox_KillEngine
            // 
            comboBox_KillEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_KillEngine.FormattingEnabled = true;
            comboBox_KillEngine.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_KillEngine.Location = new System.Drawing.Point(6, 20);
            comboBox_KillEngine.Name = "comboBox_KillEngine";
            comboBox_KillEngine.Size = new System.Drawing.Size(58, 21);
            comboBox_KillEngine.TabIndex = 63;
            comboBox_KillEngine.Text = "Engine";
            // 
            // button20
            // 
            button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button20.Location = new System.Drawing.Point(6, 43);
            button20.Name = "button20";
            button20.Size = new System.Drawing.Size(98, 26);
            button20.TabIndex = 64;
            button20.Text = "Kill Engine";
            button20.UseVisualStyleBackColor = true;
            button20.Click += new System.EventHandler(Button20_Click);
            // 
            // groupBox21
            // 
            groupBox21.Controls.Add(maskedTextBox_TiltTowSens);
            groupBox21.Controls.Add(comboBox_TiltTowSensState);
            groupBox21.Controls.Add(button18);
            groupBox21.Location = new System.Drawing.Point(510, 451);
            groupBox21.Name = "groupBox21";
            groupBox21.Size = new System.Drawing.Size(200, 100);
            groupBox21.TabIndex = 65;
            groupBox21.TabStop = false;
            groupBox21.Text = "Tilt Tow Sensitivity";
            // 
            // maskedTextBox_TiltTowSens
            // 
            maskedTextBox_TiltTowSens.Location = new System.Drawing.Point(81, 32);
            maskedTextBox_TiltTowSens.Name = "maskedTextBox_TiltTowSens";
            maskedTextBox_TiltTowSens.Size = new System.Drawing.Size(100, 22);
            maskedTextBox_TiltTowSens.TabIndex = 83;
            // 
            // comboBox_TiltTowSensState
            // 
            comboBox_TiltTowSensState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_TiltTowSensState.FormattingEnabled = true;
            comboBox_TiltTowSensState.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_TiltTowSensState.Location = new System.Drawing.Point(17, 32);
            comboBox_TiltTowSensState.Name = "comboBox_TiltTowSensState";
            comboBox_TiltTowSensState.Size = new System.Drawing.Size(58, 21);
            comboBox_TiltTowSensState.TabIndex = 82;
            comboBox_TiltTowSensState.Text = "State";
            // 
            // button18
            // 
            button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button18.Location = new System.Drawing.Point(17, 59);
            button18.Name = "button18";
            button18.Size = new System.Drawing.Size(140, 26);
            button18.TabIndex = 61;
            button18.Text = "Tilt/Tow Sensitivity";
            button18.UseVisualStyleBackColor = true;
            button18.Click += new System.EventHandler(Button18_Click);
            // 
            // groupBox20
            // 
            groupBox20.Controls.Add(maskedTextBox_HitSensitivity);
            groupBox20.Controls.Add(comboBox_HitState);
            groupBox20.Controls.Add(button17);
            groupBox20.Location = new System.Drawing.Point(510, 345);
            groupBox20.Name = "groupBox20";
            groupBox20.Size = new System.Drawing.Size(200, 100);
            groupBox20.TabIndex = 64;
            groupBox20.TabStop = false;
            groupBox20.Text = "Hit Sensitivity";
            // 
            // maskedTextBox_HitSensitivity
            // 
            maskedTextBox_HitSensitivity.Location = new System.Drawing.Point(81, 32);
            maskedTextBox_HitSensitivity.Name = "maskedTextBox_HitSensitivity";
            maskedTextBox_HitSensitivity.Size = new System.Drawing.Size(100, 22);
            maskedTextBox_HitSensitivity.TabIndex = 82;
            // 
            // comboBox_HitState
            // 
            comboBox_HitState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_HitState.FormattingEnabled = true;
            comboBox_HitState.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_HitState.Location = new System.Drawing.Point(17, 32);
            comboBox_HitState.Name = "comboBox_HitState";
            comboBox_HitState.Size = new System.Drawing.Size(58, 21);
            comboBox_HitState.TabIndex = 62;
            comboBox_HitState.Text = "State";
            // 
            // button17
            // 
            button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button17.Location = new System.Drawing.Point(17, 59);
            button17.Name = "button17";
            button17.Size = new System.Drawing.Size(140, 26);
            button17.TabIndex = 61;
            button17.Text = "Hit Sensitivity";
            button17.UseVisualStyleBackColor = true;
            button17.Click += new System.EventHandler(Button17_Click);
            // 
            // groupBox19
            // 
            groupBox19.Controls.Add(maskedTextBox_ShockDetectNum);
            groupBox19.Controls.Add(maskedTextBox_ShockWindow);
            groupBox19.Controls.Add(comboBox_ShockState);
            groupBox19.Controls.Add(button16);
            groupBox19.Location = new System.Drawing.Point(718, 276);
            groupBox19.Name = "groupBox19";
            groupBox19.Size = new System.Drawing.Size(200, 100);
            groupBox19.TabIndex = 63;
            groupBox19.TabStop = false;
            groupBox19.Text = "Config Shock";
            // 
            // maskedTextBox_ShockDetectNum
            // 
            maskedTextBox_ShockDetectNum.Location = new System.Drawing.Point(111, 24);
            maskedTextBox_ShockDetectNum.Name = "maskedTextBox_ShockDetectNum";
            maskedTextBox_ShockDetectNum.Size = new System.Drawing.Size(46, 22);
            maskedTextBox_ShockDetectNum.TabIndex = 82;
            // 
            // maskedTextBox_ShockWindow
            // 
            maskedTextBox_ShockWindow.Location = new System.Drawing.Point(59, 24);
            maskedTextBox_ShockWindow.Name = "maskedTextBox_ShockWindow";
            maskedTextBox_ShockWindow.Size = new System.Drawing.Size(41, 22);
            maskedTextBox_ShockWindow.TabIndex = 81;
            // 
            // comboBox_ShockState
            // 
            comboBox_ShockState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_ShockState.FormattingEnabled = true;
            comboBox_ShockState.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_ShockState.Location = new System.Drawing.Point(1, 24);
            comboBox_ShockState.Name = "comboBox_ShockState";
            comboBox_ShockState.Size = new System.Drawing.Size(48, 21);
            comboBox_ShockState.TabIndex = 61;
            comboBox_ShockState.Text = "State";
            // 
            // button16
            // 
            button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button16.Location = new System.Drawing.Point(6, 54);
            button16.Name = "button16";
            button16.Size = new System.Drawing.Size(140, 26);
            button16.TabIndex = 42;
            button16.Text = "Config Shock";
            button16.UseVisualStyleBackColor = true;
            button16.Click += new System.EventHandler(Button16_Click);
            // 
            // groupBox18
            // 
            groupBox18.Controls.Add(maskedTextBox_TiltDetectNum);
            groupBox18.Controls.Add(maskedTextBox_TiltWindow);
            groupBox18.Controls.Add(maskedTextBox_TiltAngle);
            groupBox18.Controls.Add(comboBox1_TiltState);
            groupBox18.Controls.Add(button15);
            groupBox18.Location = new System.Drawing.Point(718, 170);
            groupBox18.Name = "groupBox18";
            groupBox18.Size = new System.Drawing.Size(200, 100);
            groupBox18.TabIndex = 62;
            groupBox18.TabStop = false;
            groupBox18.Text = "Config Tow";
            // 
            // maskedTextBox_TiltDetectNum
            // 
            maskedTextBox_TiltDetectNum.Location = new System.Drawing.Point(100, 29);
            maskedTextBox_TiltDetectNum.Name = "maskedTextBox_TiltDetectNum";
            maskedTextBox_TiltDetectNum.Size = new System.Drawing.Size(42, 22);
            maskedTextBox_TiltDetectNum.TabIndex = 83;
            // 
            // maskedTextBox_TiltWindow
            // 
            maskedTextBox_TiltWindow.Location = new System.Drawing.Point(53, 29);
            maskedTextBox_TiltWindow.Name = "maskedTextBox_TiltWindow";
            maskedTextBox_TiltWindow.Size = new System.Drawing.Size(41, 22);
            maskedTextBox_TiltWindow.TabIndex = 82;
            // 
            // maskedTextBox_TiltAngle
            // 
            maskedTextBox_TiltAngle.Location = new System.Drawing.Point(10, 29);
            maskedTextBox_TiltAngle.Name = "maskedTextBox_TiltAngle";
            maskedTextBox_TiltAngle.Size = new System.Drawing.Size(37, 22);
            maskedTextBox_TiltAngle.TabIndex = 81;
            // 
            // comboBox1_TiltState
            // 
            comboBox1_TiltState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox1_TiltState.FormattingEnabled = true;
            comboBox1_TiltState.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox1_TiltState.Location = new System.Drawing.Point(152, 29);
            comboBox1_TiltState.Name = "comboBox1_TiltState";
            comboBox1_TiltState.Size = new System.Drawing.Size(42, 21);
            comboBox1_TiltState.TabIndex = 38;
            comboBox1_TiltState.Text = "State";
            // 
            // button15
            // 
            button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button15.Location = new System.Drawing.Point(6, 56);
            button15.Name = "button15";
            button15.Size = new System.Drawing.Size(140, 26);
            button15.TabIndex = 42;
            button15.Text = "Config Tilt";
            button15.UseVisualStyleBackColor = true;
            button15.Click += new System.EventHandler(Button15_Click);
            // 
            // groupBox17
            // 
            groupBox17.Controls.Add(maskedTextBox_TowDetectNum);
            groupBox17.Controls.Add(maskedTextBox_TowWindow);
            groupBox17.Controls.Add(maskedTextBox_TowAngle);
            groupBox17.Controls.Add(button14);
            groupBox17.Location = new System.Drawing.Point(516, 17);
            groupBox17.Name = "groupBox17";
            groupBox17.Size = new System.Drawing.Size(157, 100);
            groupBox17.TabIndex = 61;
            groupBox17.TabStop = false;
            groupBox17.Text = "Tow Configuration";
            // 
            // maskedTextBox_TowDetectNum
            // 
            maskedTextBox_TowDetectNum.Location = new System.Drawing.Point(100, 24);
            maskedTextBox_TowDetectNum.Name = "maskedTextBox_TowDetectNum";
            maskedTextBox_TowDetectNum.Size = new System.Drawing.Size(42, 22);
            maskedTextBox_TowDetectNum.TabIndex = 80;
            // 
            // maskedTextBox_TowWindow
            // 
            maskedTextBox_TowWindow.Location = new System.Drawing.Point(53, 24);
            maskedTextBox_TowWindow.Name = "maskedTextBox_TowWindow";
            maskedTextBox_TowWindow.Size = new System.Drawing.Size(41, 22);
            maskedTextBox_TowWindow.TabIndex = 79;
            // 
            // maskedTextBox_TowAngle
            // 
            maskedTextBox_TowAngle.Location = new System.Drawing.Point(10, 24);
            maskedTextBox_TowAngle.Name = "maskedTextBox_TowAngle";
            maskedTextBox_TowAngle.Size = new System.Drawing.Size(37, 22);
            maskedTextBox_TowAngle.TabIndex = 78;
            // 
            // button14
            // 
            button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button14.Location = new System.Drawing.Point(6, 54);
            button14.Name = "button14";
            button14.Size = new System.Drawing.Size(140, 26);
            button14.TabIndex = 42;
            button14.Text = "Config Tow";
            button14.UseVisualStyleBackColor = true;
            button14.Click += new System.EventHandler(Button14_Click);
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(comboBox_SleepPolicy);
            groupBox11.Controls.Add(button12);
            groupBox11.Location = new System.Drawing.Point(15, 598);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new System.Drawing.Size(167, 84);
            groupBox11.TabIndex = 57;
            groupBox11.TabStop = false;
            groupBox11.Text = "Sleep Policy";
            // 
            // comboBox_SleepPolicy
            // 
            comboBox_SleepPolicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_SleepPolicy.FormattingEnabled = true;
            comboBox_SleepPolicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            comboBox_SleepPolicy.Location = new System.Drawing.Point(6, 27);
            comboBox_SleepPolicy.Name = "comboBox_SleepPolicy";
            comboBox_SleepPolicy.Size = new System.Drawing.Size(80, 21);
            comboBox_SleepPolicy.TabIndex = 47;
            comboBox_SleepPolicy.Text = "Sleep Policy";
            // 
            // button12
            // 
            button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button12.Location = new System.Drawing.Point(6, 51);
            button12.Name = "button12";
            button12.Size = new System.Drawing.Size(152, 26);
            button12.TabIndex = 48;
            button12.Text = "Set Sleep Policy";
            button12.UseVisualStyleBackColor = true;
            button12.Click += new System.EventHandler(Button12_Click);
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(comboBox_AlarmPilicy);
            groupBox10.Controls.Add(button11);
            groupBox10.Location = new System.Drawing.Point(15, 492);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new System.Drawing.Size(166, 100);
            groupBox10.TabIndex = 56;
            groupBox10.TabStop = false;
            groupBox10.Text = "Set Alarm Configuration";
            // 
            // comboBox_AlarmPilicy
            // 
            comboBox_AlarmPilicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_AlarmPilicy.FormattingEnabled = true;
            comboBox_AlarmPilicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            comboBox_AlarmPilicy.Location = new System.Drawing.Point(8, 28);
            comboBox_AlarmPilicy.Name = "comboBox_AlarmPilicy";
            comboBox_AlarmPilicy.Size = new System.Drawing.Size(80, 21);
            comboBox_AlarmPilicy.TabIndex = 42;
            comboBox_AlarmPilicy.Text = "Alarm Policy";
            // 
            // button11
            // 
            button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button11.Location = new System.Drawing.Point(8, 52);
            button11.Name = "button11";
            button11.Size = new System.Drawing.Size(152, 26);
            button11.TabIndex = 43;
            button11.Text = "Set Alarm Policy";
            button11.UseVisualStyleBackColor = true;
            button11.Click += new System.EventHandler(Button11_Click);
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(dateTimePicker_SetTimeDate);
            groupBox9.Controls.Add(button10);
            groupBox9.Location = new System.Drawing.Point(353, 193);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new System.Drawing.Size(204, 81);
            groupBox9.TabIndex = 55;
            groupBox9.TabStop = false;
            groupBox9.Text = "Set Time and Date";
            // 
            // dateTimePicker_SetTimeDate
            // 
            dateTimePicker_SetTimeDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePicker_SetTimeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dateTimePicker_SetTimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker_SetTimeDate.Location = new System.Drawing.Point(6, 20);
            dateTimePicker_SetTimeDate.Name = "dateTimePicker_SetTimeDate";
            dateTimePicker_SetTimeDate.Size = new System.Drawing.Size(179, 21);
            dateTimePicker_SetTimeDate.TabIndex = 41;
            // 
            // button10
            // 
            button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button10.Location = new System.Drawing.Point(6, 47);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(87, 26);
            button10.TabIndex = 40;
            button10.Text = "Time Date Config";
            button10.UseVisualStyleBackColor = true;
            button10.Click += new System.EventHandler(Button10_Click);
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(comboBox_BatThreshold);
            groupBox8.Controls.Add(button9);
            groupBox8.Location = new System.Drawing.Point(187, 183);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new System.Drawing.Size(160, 91);
            groupBox8.TabIndex = 54;
            groupBox8.TabStop = false;
            groupBox8.Text = "Vehicle Battery threshold ";
            // 
            // comboBox_BatThreshold
            // 
            comboBox_BatThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_BatThreshold.FormattingEnabled = true;
            comboBox_BatThreshold.Items.AddRange(new object[] {
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
            comboBox_BatThreshold.Location = new System.Drawing.Point(6, 20);
            comboBox_BatThreshold.Name = "comboBox_BatThreshold";
            comboBox_BatThreshold.Size = new System.Drawing.Size(49, 21);
            comboBox_BatThreshold.TabIndex = 39;
            // 
            // button9
            // 
            button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button9.Location = new System.Drawing.Point(6, 47);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(135, 26);
            button9.TabIndex = 38;
            button9.Text = "Vehicle Battery";
            button9.UseVisualStyleBackColor = true;
            button9.Click += new System.EventHandler(Button9_Click);
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(maskedTextBox_OutputDuration);
            groupBox7.Controls.Add(comboBox_OutputNum);
            groupBox7.Controls.Add(comboBox_OutputControl);
            groupBox7.Controls.Add(button8);
            groupBox7.Controls.Add(comboBox_OutputPulseLevel);
            groupBox7.Location = new System.Drawing.Point(9, 386);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(215, 94);
            groupBox7.TabIndex = 12;
            groupBox7.TabStop = false;
            groupBox7.Text = "Set Input Config";
            // 
            // maskedTextBox_OutputDuration
            // 
            maskedTextBox_OutputDuration.Location = new System.Drawing.Point(164, 48);
            maskedTextBox_OutputDuration.Name = "maskedTextBox_OutputDuration";
            maskedTextBox_OutputDuration.Size = new System.Drawing.Size(39, 22);
            maskedTextBox_OutputDuration.TabIndex = 38;
            // 
            // comboBox_OutputNum
            // 
            comboBox_OutputNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_OutputNum.FormattingEnabled = true;
            comboBox_OutputNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            comboBox_OutputNum.Location = new System.Drawing.Point(6, 20);
            comboBox_OutputNum.Name = "comboBox_OutputNum";
            comboBox_OutputNum.Size = new System.Drawing.Size(71, 21);
            comboBox_OutputNum.TabIndex = 33;
            comboBox_OutputNum.Text = "Output Num";
            // 
            // comboBox_OutputControl
            // 
            comboBox_OutputControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_OutputControl.FormattingEnabled = true;
            comboBox_OutputControl.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_OutputControl.Location = new System.Drawing.Point(83, 20);
            comboBox_OutputControl.Name = "comboBox_OutputControl";
            comboBox_OutputControl.Size = new System.Drawing.Size(71, 21);
            comboBox_OutputControl.TabIndex = 34;
            comboBox_OutputControl.Text = "Cntl";
            // 
            // button8
            // 
            button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button8.Location = new System.Drawing.Point(5, 47);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(152, 26);
            button8.TabIndex = 36;
            button8.Text = "Set Output Config";
            button8.UseVisualStyleBackColor = true;
            button8.Click += new System.EventHandler(Button8_Click);
            // 
            // comboBox_OutputPulseLevel
            // 
            comboBox_OutputPulseLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_OutputPulseLevel.FormattingEnabled = true;
            comboBox_OutputPulseLevel.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_OutputPulseLevel.Location = new System.Drawing.Point(160, 20);
            comboBox_OutputPulseLevel.Name = "comboBox_OutputPulseLevel";
            comboBox_OutputPulseLevel.Size = new System.Drawing.Size(43, 21);
            comboBox_OutputPulseLevel.TabIndex = 37;
            comboBox_OutputPulseLevel.Text = "Pulse\\Level";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(maskedTextBox_InputDuration);
            groupBox6.Controls.Add(comboBox_InputNum1);
            groupBox6.Controls.Add(comboBox_Interupt);
            groupBox6.Controls.Add(button7);
            groupBox6.Location = new System.Drawing.Point(9, 280);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(215, 100);
            groupBox6.TabIndex = 53;
            groupBox6.TabStop = false;
            groupBox6.Text = "Input Configuration";
            // 
            // maskedTextBox_InputDuration
            // 
            maskedTextBox_InputDuration.Location = new System.Drawing.Point(157, 31);
            maskedTextBox_InputDuration.Name = "maskedTextBox_InputDuration";
            maskedTextBox_InputDuration.Size = new System.Drawing.Size(46, 22);
            maskedTextBox_InputDuration.TabIndex = 33;
            // 
            // comboBox_InputNum1
            // 
            comboBox_InputNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_InputNum1.FormattingEnabled = true;
            comboBox_InputNum1.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_InputNum1.Location = new System.Drawing.Point(6, 31);
            comboBox_InputNum1.Name = "comboBox_InputNum1";
            comboBox_InputNum1.Size = new System.Drawing.Size(71, 21);
            comboBox_InputNum1.TabIndex = 29;
            comboBox_InputNum1.Text = "Input Num";
            // 
            // comboBox_Interupt
            // 
            comboBox_Interupt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_Interupt.FormattingEnabled = true;
            comboBox_Interupt.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_Interupt.Location = new System.Drawing.Point(83, 31);
            comboBox_Interupt.Name = "comboBox_Interupt";
            comboBox_Interupt.Size = new System.Drawing.Size(71, 21);
            comboBox_Interupt.TabIndex = 30;
            comboBox_Interupt.Text = "Interrupt";
            // 
            // button7
            // 
            button7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button7.Location = new System.Drawing.Point(5, 58);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(152, 26);
            button7.TabIndex = 32;
            button7.Text = "Set Input Config";
            button7.UseVisualStyleBackColor = true;
            button7.Click += new System.EventHandler(Button7_Click);
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(btn_ChangePassword);
            groupBox13.Controls.Add(textBox_NewPassword);
            groupBox13.Location = new System.Drawing.Point(9, 174);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new System.Drawing.Size(172, 100);
            groupBox13.TabIndex = 52;
            groupBox13.TabStop = false;
            groupBox13.Text = "Change Password";
            // 
            // btn_ChangePassword
            // 
            btn_ChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn_ChangePassword.Location = new System.Drawing.Point(8, 48);
            btn_ChangePassword.Name = "btn_ChangePassword";
            btn_ChangePassword.Size = new System.Drawing.Size(152, 26);
            btn_ChangePassword.TabIndex = 28;
            btn_ChangePassword.Text = "Change Password";
            btn_ChangePassword.UseVisualStyleBackColor = true;
            // 
            // textBox_NewPassword
            // 
            textBox_NewPassword.Location = new System.Drawing.Point(6, 19);
            textBox_NewPassword.Name = "textBox_NewPassword";
            textBox_NewPassword.Size = new System.Drawing.Size(120, 22);
            textBox_NewPassword.TabIndex = 27;
            // 
            // groupBox14
            // 
            groupBox14.Controls.Add(comboBox_SMSControl);
            groupBox14.Controls.Add(button_SMSControl);
            groupBox14.Location = new System.Drawing.Point(187, 105);
            groupBox14.Name = "groupBox14";
            groupBox14.Size = new System.Drawing.Size(122, 80);
            groupBox14.TabIndex = 51;
            groupBox14.TabStop = false;
            groupBox14.Text = "SMS Control";
            // 
            // comboBox_SMSControl
            // 
            comboBox_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_SMSControl.FormattingEnabled = true;
            comboBox_SMSControl.Items.AddRange(new object[] {
            "0",
            "1"});
            comboBox_SMSControl.Location = new System.Drawing.Point(6, 20);
            comboBox_SMSControl.Name = "comboBox_SMSControl";
            comboBox_SMSControl.Size = new System.Drawing.Size(101, 21);
            comboBox_SMSControl.TabIndex = 25;
            // 
            // button_SMSControl
            // 
            button_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button_SMSControl.Location = new System.Drawing.Point(6, 47);
            button_SMSControl.Name = "button_SMSControl";
            button_SMSControl.Size = new System.Drawing.Size(113, 26);
            button_SMSControl.TabIndex = 26;
            button_SMSControl.Text = "SMS Control";
            button_SMSControl.UseVisualStyleBackColor = true;
            button_SMSControl.Click += new System.EventHandler(Button_SMSControl_Click);
            // 
            // groupBox15
            // 
            groupBox15.Controls.Add(textBox_FreeText);
            groupBox15.Controls.Add(comboBox_InputIndex);
            groupBox15.Controls.Add(button_SetFreeText);
            groupBox15.Location = new System.Drawing.Point(187, 24);
            groupBox15.Name = "groupBox15";
            groupBox15.Size = new System.Drawing.Size(141, 75);
            groupBox15.TabIndex = 50;
            groupBox15.TabStop = false;
            groupBox15.Text = "Set Input Free Text";
            // 
            // textBox_FreeText
            // 
            textBox_FreeText.Location = new System.Drawing.Point(52, 16);
            textBox_FreeText.Name = "textBox_FreeText";
            textBox_FreeText.Size = new System.Drawing.Size(67, 22);
            textBox_FreeText.TabIndex = 25;
            // 
            // comboBox_InputIndex
            // 
            comboBox_InputIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            comboBox_InputIndex.FormattingEnabled = true;
            comboBox_InputIndex.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            comboBox_InputIndex.Location = new System.Drawing.Point(8, 17);
            comboBox_InputIndex.Name = "comboBox_InputIndex";
            comboBox_InputIndex.Size = new System.Drawing.Size(37, 21);
            comboBox_InputIndex.TabIndex = 20;
            // 
            // button_SetFreeText
            // 
            button_SetFreeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button_SetFreeText.Location = new System.Drawing.Point(8, 40);
            button_SetFreeText.Name = "button_SetFreeText";
            button_SetFreeText.Size = new System.Drawing.Size(111, 26);
            button_SetFreeText.TabIndex = 24;
            button_SetFreeText.Text = "Set Free Text";
            button_SetFreeText.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            groupBox16.Controls.Add(maskedTextBox3_Subscriber3);
            groupBox16.Controls.Add(maskedTextBox2_Subscriber2);
            groupBox16.Controls.Add(maskedTextBox1_Subscriber1);
            groupBox16.Controls.Add(button4);
            groupBox16.Location = new System.Drawing.Point(9, 20);
            groupBox16.Name = "groupBox16";
            groupBox16.Size = new System.Drawing.Size(172, 149);
            groupBox16.TabIndex = 20;
            groupBox16.TabStop = false;
            groupBox16.Text = "Subscribers";
            // 
            // maskedTextBox3_Subscriber3
            // 
            maskedTextBox3_Subscriber3.Location = new System.Drawing.Point(8, 76);
            maskedTextBox3_Subscriber3.Name = "maskedTextBox3_Subscriber3";
            maskedTextBox3_Subscriber3.Size = new System.Drawing.Size(153, 22);
            maskedTextBox3_Subscriber3.TabIndex = 28;
            // 
            // maskedTextBox2_Subscriber2
            // 
            maskedTextBox2_Subscriber2.Location = new System.Drawing.Point(8, 49);
            maskedTextBox2_Subscriber2.Name = "maskedTextBox2_Subscriber2";
            maskedTextBox2_Subscriber2.Size = new System.Drawing.Size(153, 22);
            maskedTextBox2_Subscriber2.TabIndex = 27;
            // 
            // maskedTextBox1_Subscriber1
            // 
            maskedTextBox1_Subscriber1.Location = new System.Drawing.Point(8, 24);
            maskedTextBox1_Subscriber1.Name = "maskedTextBox1_Subscriber1";
            maskedTextBox1_Subscriber1.Size = new System.Drawing.Size(153, 22);
            maskedTextBox1_Subscriber1.TabIndex = 26;
            // 
            // button4
            // 
            button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button4.Location = new System.Drawing.Point(6, 107);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(154, 26);
            button4.TabIndex = 20;
            button4.Text = "Set Subscribers";
            button4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new System.Drawing.Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new System.Drawing.Size(1406, 776);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "S1 Requests and Qureies";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox_SMSPhoneNumber
            // 
            textBox_SMSPhoneNumber.Location = new System.Drawing.Point(6, 22);
            textBox_SMSPhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            textBox_SMSPhoneNumber.Name = "textBox_SMSPhoneNumber";
            textBox_SMSPhoneNumber.Size = new System.Drawing.Size(143, 26);
            textBox_SMSPhoneNumber.TabIndex = 10;
            // 
            // button_SendAllCheckedSMS
            // 
            button_SendAllCheckedSMS.Location = new System.Drawing.Point(353, 115);
            button_SendAllCheckedSMS.Name = "button_SendAllCheckedSMS";
            button_SendAllCheckedSMS.Size = new System.Drawing.Size(123, 23);
            button_SendAllCheckedSMS.TabIndex = 7;
            button_SendAllCheckedSMS.Text = "Send SMS Multi";
            button_SendAllCheckedSMS.UseVisualStyleBackColor = true;
            button_SendAllCheckedSMS.Click += new System.EventHandler(Button39_Click);
            // 
            // button_SendSelectedSMS
            // 
            button_SendSelectedSMS.Location = new System.Drawing.Point(482, 115);
            button_SendSelectedSMS.Name = "button_SendSelectedSMS";
            button_SendSelectedSMS.Size = new System.Drawing.Size(107, 23);
            button_SendSelectedSMS.TabIndex = 8;
            button_SendSelectedSMS.Text = "Send SMS One";
            button_SendSelectedSMS.UseVisualStyleBackColor = true;
            button_SendSelectedSMS.Click += new System.EventHandler(Button_SendSelectedSMS_Click);
            // 
            // button_Ring
            // 
            button_Ring.Location = new System.Drawing.Point(88, 112);
            button_Ring.Name = "button_Ring";
            button_Ring.Size = new System.Drawing.Size(141, 23);
            button_Ring.TabIndex = 14;
            button_Ring.Text = "Ring";
            button_Ring.UseVisualStyleBackColor = true;
            // 
            // comboBox_SystemType
            // 
            comboBox_SystemType.FormattingEnabled = true;
            comboBox_SystemType.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            comboBox_SystemType.Location = new System.Drawing.Point(5, 45);
            comboBox_SystemType.Name = "comboBox_SystemType";
            comboBox_SystemType.Size = new System.Drawing.Size(78, 21);
            comboBox_SystemType.TabIndex = 77;
            comboBox_SystemType.MouseDown += new System.Windows.Forms.MouseEventHandler(comboBox2_MouseDown);
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer_General_100ms
            // 
            timer_General_100ms.Enabled = true;
            timer_General_100ms.Tick += new System.EventHandler(Timer_ConectionKeepAlive_Tick);
            // 
            // timer_General_1Second
            // 
            timer_General_1Second.Enabled = true;
            timer_General_1Second.Interval = 1000;
            timer_General_1Second.Tick += new System.EventHandler(Timer_General_Tick);
            // 
            // serialPort
            // 
            serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(SerialPort_DataReceived);
            // 
            // groupBox36
            // 
            groupBox36.Location = new System.Drawing.Point(0, -58);
            groupBox36.Margin = new System.Windows.Forms.Padding(2);
            groupBox36.Name = "groupBox36";
            groupBox36.Padding = new System.Windows.Forms.Padding(2);
            groupBox36.Size = new System.Drawing.Size(126, 55);
            groupBox36.TabIndex = 11;
            groupBox36.TabStop = false;
            groupBox36.Text = "Comm Interface";
            // 
            // groupBox_PhoneNumber
            // 
            groupBox_PhoneNumber.Controls.Add(textBox_SMSPhoneNumber);
            groupBox_PhoneNumber.Location = new System.Drawing.Point(890, 5);
            groupBox_PhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            groupBox_PhoneNumber.Name = "groupBox_PhoneNumber";
            groupBox_PhoneNumber.Padding = new System.Windows.Forms.Padding(2);
            groupBox_PhoneNumber.Size = new System.Drawing.Size(158, 54);
            groupBox_PhoneNumber.TabIndex = 12;
            groupBox_PhoneNumber.TabStop = false;
            groupBox_PhoneNumber.Text = "Phone Number";
            groupBox_PhoneNumber.Visible = false;
            // 
            // Label_SerialPortRx
            // 
            Label_SerialPortRx.AutoSize = true;
            Label_SerialPortRx.Location = new System.Drawing.Point(19, 52);
            Label_SerialPortRx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Label_SerialPortRx.Name = "Label_SerialPortRx";
            Label_SerialPortRx.Size = new System.Drawing.Size(23, 18);
            Label_SerialPortRx.TabIndex = 108;
            Label_SerialPortRx.Text = "Rx";
            // 
            // label_SerialPortConnected
            // 
            label_SerialPortConnected.AutoSize = true;
            label_SerialPortConnected.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label_SerialPortConnected.Location = new System.Drawing.Point(15, 28);
            label_SerialPortConnected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label_SerialPortConnected.Name = "label_SerialPortConnected";
            label_SerialPortConnected.Size = new System.Drawing.Size(69, 18);
            label_SerialPortConnected.TabIndex = 109;
            label_SerialPortConnected.Text = "Conneted";
            // 
            // Label_SerialPortTx
            // 
            Label_SerialPortTx.AutoSize = true;
            Label_SerialPortTx.Location = new System.Drawing.Point(59, 52);
            Label_SerialPortTx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Label_SerialPortTx.Name = "Label_SerialPortTx";
            Label_SerialPortTx.Size = new System.Drawing.Size(21, 18);
            Label_SerialPortTx.TabIndex = 110;
            Label_SerialPortTx.Text = "Tx";
            // 
            // groupBox_SerialPort
            // 
            groupBox_SerialPort.Controls.Add(label_SerialPortStatus);
            groupBox_SerialPort.Controls.Add(Label_SerialPortTx);
            groupBox_SerialPort.Controls.Add(label_SerialPortConnected);
            groupBox_SerialPort.Controls.Add(Label_SerialPortRx);
            groupBox_SerialPort.Location = new System.Drawing.Point(1427, 74);
            groupBox_SerialPort.Margin = new System.Windows.Forms.Padding(2);
            groupBox_SerialPort.Name = "groupBox_SerialPort";
            groupBox_SerialPort.Padding = new System.Windows.Forms.Padding(2);
            groupBox_SerialPort.Size = new System.Drawing.Size(174, 103);
            groupBox_SerialPort.TabIndex = 111;
            groupBox_SerialPort.TabStop = false;
            groupBox_SerialPort.Text = "Serial port";
            groupBox_SerialPort.Enter += new System.EventHandler(groupBox_SerialPort_Enter);
            // 
            // label_SerialPortStatus
            // 
            label_SerialPortStatus.AutoSize = true;
            label_SerialPortStatus.Location = new System.Drawing.Point(87, 28);
            label_SerialPortStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label_SerialPortStatus.Name = "label_SerialPortStatus";
            label_SerialPortStatus.Size = new System.Drawing.Size(42, 18);
            label_SerialPortStatus.TabIndex = 111;
            label_SerialPortStatus.Text = "None";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button97);
            groupBox4.Controls.Add(textBox_SystemStatus);
            groupBox4.Location = new System.Drawing.Point(1427, 443);
            groupBox4.Margin = new System.Windows.Forms.Padding(2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(2);
            groupBox4.Size = new System.Drawing.Size(174, 210);
            groupBox4.TabIndex = 114;
            groupBox4.TabStop = false;
            groupBox4.Text = "User information";
            // 
            // button97
            // 
            button97.Location = new System.Drawing.Point(5, 182);
            button97.Margin = new System.Windows.Forms.Padding(2);
            button97.Name = "button97";
            button97.Size = new System.Drawing.Size(53, 22);
            button97.TabIndex = 114;
            button97.Text = "Clear";
            button97.UseVisualStyleBackColor = true;
            button97.Click += new System.EventHandler(button97_Click);
            // 
            // textBox_SystemStatus
            // 
            textBox_SystemStatus.Location = new System.Drawing.Point(6, 17);
            textBox_SystemStatus.Margin = new System.Windows.Forms.Padding(2);
            textBox_SystemStatus.Multiline = true;
            textBox_SystemStatus.Name = "textBox_SystemStatus";
            textBox_SystemStatus.ReadOnly = true;
            textBox_SystemStatus.Size = new System.Drawing.Size(166, 163);
            textBox_SystemStatus.TabIndex = 113;
            textBox_SystemStatus.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            pictureBox1.Location = new System.Drawing.Point(1427, 31);
            pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(174, 37);
            pictureBox1.TabIndex = 115;
            pictureBox1.TabStop = false;
            // 
            // groupBox_ClentTCPStatus
            // 
            groupBox_ClentTCPStatus.Controls.Add(label_TCPClient);
            groupBox_ClentTCPStatus.Controls.Add(label12);
            groupBox_ClentTCPStatus.Controls.Add(label_ClientTCPConnected);
            groupBox_ClentTCPStatus.Controls.Add(label14);
            groupBox_ClentTCPStatus.Location = new System.Drawing.Point(1427, 186);
            groupBox_ClentTCPStatus.Margin = new System.Windows.Forms.Padding(2);
            groupBox_ClentTCPStatus.Name = "groupBox_ClentTCPStatus";
            groupBox_ClentTCPStatus.Padding = new System.Windows.Forms.Padding(2);
            groupBox_ClentTCPStatus.Size = new System.Drawing.Size(174, 103);
            groupBox_ClentTCPStatus.TabIndex = 112;
            groupBox_ClentTCPStatus.TabStop = false;
            groupBox_ClentTCPStatus.Text = "Client TCP";
            // 
            // label_TCPClient
            // 
            label_TCPClient.AutoSize = true;
            label_TCPClient.Location = new System.Drawing.Point(84, 28);
            label_TCPClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label_TCPClient.Name = "label_TCPClient";
            label_TCPClient.Size = new System.Drawing.Size(45, 18);
            label_TCPClient.TabIndex = 111;
            label_TCPClient.Text = " None";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(59, 52);
            label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(21, 18);
            label12.TabIndex = 110;
            label12.Text = "Tx";
            // 
            // label_ClientTCPConnected
            // 
            label_ClientTCPConnected.AutoSize = true;
            label_ClientTCPConnected.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label_ClientTCPConnected.Location = new System.Drawing.Point(15, 28);
            label_ClientTCPConnected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label_ClientTCPConnected.Name = "label_ClientTCPConnected";
            label_ClientTCPConnected.Size = new System.Drawing.Size(69, 18);
            label_ClientTCPConnected.TabIndex = 109;
            label_ClientTCPConnected.Text = "Conneted";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(19, 52);
            label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(23, 18);
            label14.TabIndex = 108;
            label14.Text = "Rx";
            // 
            // checkedListBox_PhoneBook
            // 
            checkedListBox_PhoneBook.FormattingEnabled = true;
            checkedListBox_PhoneBook.Location = new System.Drawing.Point(5, 19);
            checkedListBox_PhoneBook.Name = "checkedListBox_PhoneBook";
            checkedListBox_PhoneBook.Size = new System.Drawing.Size(279, 289);
            checkedListBox_PhoneBook.TabIndex = 0;
            checkedListBox_PhoneBook.SelectedIndexChanged += new System.EventHandler(CheckedListBox_PhoneBook_SelectedIndexChanged);
            checkedListBox_PhoneBook.KeyDown += new System.Windows.Forms.KeyEventHandler(CheckedListBox_PhoneBook_KeyDown);
            checkedListBox_PhoneBook.MouseDown += new System.Windows.Forms.MouseEventHandler(CheckedListBox_PhoneBook_MouseDown);
            // 
            // button_AddContact
            // 
            button_AddContact.Location = new System.Drawing.Point(7, 371);
            button_AddContact.Name = "button_AddContact";
            button_AddContact.Size = new System.Drawing.Size(75, 23);
            button_AddContact.TabIndex = 1;
            button_AddContact.Text = "Add";
            button_AddContact.UseVisualStyleBackColor = true;
            // this.button_AddContact.Click += new System.EventHandler(this.Button33_Click_1);
            // 
            // button_RemoveContact
            // 
            button_RemoveContact.Location = new System.Drawing.Point(88, 371);
            button_RemoveContact.Name = "button_RemoveContact";
            button_RemoveContact.Size = new System.Drawing.Size(75, 23);
            button_RemoveContact.TabIndex = 2;
            button_RemoveContact.Text = "Remove";
            button_RemoveContact.UseVisualStyleBackColor = true;
            button_RemoveContact.Click += new System.EventHandler(Button_RemoveContact_Click);
            // 
            // button_ExportToXML
            // 
            button_ExportToXML.Location = new System.Drawing.Point(7, 400);
            button_ExportToXML.Name = "button_ExportToXML";
            button_ExportToXML.Size = new System.Drawing.Size(75, 23);
            button_ExportToXML.TabIndex = 3;
            button_ExportToXML.Text = "Export";
            button_ExportToXML.UseVisualStyleBackColor = true;
            button_ExportToXML.Click += new System.EventHandler(Button_ExportToXML_Click);
            // 
            // button_ImportToXML
            // 
            button_ImportToXML.Location = new System.Drawing.Point(88, 400);
            button_ImportToXML.Name = "button_ImportToXML";
            button_ImportToXML.Size = new System.Drawing.Size(75, 23);
            button_ImportToXML.TabIndex = 4;
            button_ImportToXML.Text = "Import";
            button_ImportToXML.UseVisualStyleBackColor = true;
            button_ImportToXML.Click += new System.EventHandler(Button_ImportToXML_Click);
            // 
            // button33
            // 
            button33.Location = new System.Drawing.Point(169, 371);
            button33.Name = "button33";
            button33.Size = new System.Drawing.Size(75, 23);
            button33.TabIndex = 5;
            button33.Text = "Edit";
            button33.UseVisualStyleBackColor = true;
            button33.Click += new System.EventHandler(Button33_Click_2);
            // 
            // richTextBox_ContactDetails
            // 
            richTextBox_ContactDetails.BackColor = System.Drawing.SystemColors.Control;
            richTextBox_ContactDetails.Location = new System.Drawing.Point(290, 19);
            richTextBox_ContactDetails.Name = "richTextBox_ContactDetails";
            richTextBox_ContactDetails.Size = new System.Drawing.Size(166, 328);
            richTextBox_ContactDetails.TabIndex = 6;
            richTextBox_ContactDetails.Text = "";
            richTextBox_ContactDetails.TextChanged += new System.EventHandler(RichTextBox_ContactDetails_TextChanged);
            // 
            // button34
            // 
            button34.Location = new System.Drawing.Point(169, 400);
            button34.Name = "button34";
            button34.Size = new System.Drawing.Size(75, 23);
            button34.TabIndex = 7;
            button34.Text = "Backup";
            button34.UseVisualStyleBackColor = true;
            button34.Click += new System.EventHandler(Button34_Click_2);
            // 
            // richTextBox_TextSendSMS
            // 
            richTextBox_TextSendSMS.AutoWordSelection = true;
            richTextBox_TextSendSMS.EnableAutoDragDrop = true;
            richTextBox_TextSendSMS.Location = new System.Drawing.Point(10, 18);
            richTextBox_TextSendSMS.Name = "richTextBox_TextSendSMS";
            richTextBox_TextSendSMS.Size = new System.Drawing.Size(579, 91);
            richTextBox_TextSendSMS.TabIndex = 2;
            richTextBox_TextSendSMS.Text = "";
            richTextBox_TextSendSMS.TextChanged += new System.EventHandler(RichTextBox_TextSendSMS_TextChanged);
            // 
            // label_SMSSendCharacters
            // 
            label_SMSSendCharacters.AutoSize = true;
            label_SMSSendCharacters.Location = new System.Drawing.Point(12, 119);
            label_SMSSendCharacters.Name = "label_SMSSendCharacters";
            label_SMSSendCharacters.Size = new System.Drawing.Size(36, 13);
            label_SMSSendCharacters.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(145, 145);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(92, 22);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox_SendSMSAsIs
            // 
            checkBox_SendSMSAsIs.AutoSize = true;
            checkBox_SendSMSAsIs.Location = new System.Drawing.Point(240, 115);
            checkBox_SendSMSAsIs.Name = "checkBox_SendSMSAsIs";
            checkBox_SendSMSAsIs.Size = new System.Drawing.Size(116, 22);
            checkBox_SendSMSAsIs.TabIndex = 11;
            checkBox_SendSMSAsIs.Text = "Send SMS as is";
            checkBox_SendSMSAsIs.UseVisualStyleBackColor = true;
            checkBox_SendSMSAsIs.CheckedChanged += new System.EventHandler(CheckBox_SendSMSAsIs_CheckedChanged);
            // 
            // checkBox_SMSencrypted
            // 
            checkBox_SMSencrypted.AutoSize = true;
            checkBox_SMSencrypted.Location = new System.Drawing.Point(595, 20);
            checkBox_SMSencrypted.Name = "checkBox_SMSencrypted";
            checkBox_SMSencrypted.Size = new System.Drawing.Size(89, 22);
            checkBox_SMSencrypted.TabIndex = 12;
            checkBox_SMSencrypted.Text = "Encrypted";
            checkBox_SMSencrypted.UseVisualStyleBackColor = true;
            checkBox_SMSencrypted.CheckedChanged += new System.EventHandler(CheckBox_SMSencrypted_CheckedChanged);
            // 
            // GrooupBox_Encryption
            // 
            GrooupBox_Encryption.Enabled = false;
            GrooupBox_Encryption.Location = new System.Drawing.Point(595, 38);
            GrooupBox_Encryption.Name = "GrooupBox_Encryption";
            GrooupBox_Encryption.Size = new System.Drawing.Size(184, 103);
            GrooupBox_Encryption.TabIndex = 13;
            GrooupBox_Encryption.TabStop = false;
            // 
            // textBox_UnitIDForSMS
            // 
            textBox_UnitIDForSMS.Location = new System.Drawing.Point(54, 17);
            textBox_UnitIDForSMS.MaxLength = 16;
            textBox_UnitIDForSMS.Name = "textBox_UnitIDForSMS";
            textBox_UnitIDForSMS.Size = new System.Drawing.Size(124, 20);
            textBox_UnitIDForSMS.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 13);
            label2.TabIndex = 1;
            // 
            // textBox_CodeArrayForSMS
            // 
            textBox_CodeArrayForSMS.Location = new System.Drawing.Point(54, 46);
            textBox_CodeArrayForSMS.MaxLength = 4;
            textBox_CodeArrayForSMS.Name = "textBox_CodeArrayForSMS";
            textBox_CodeArrayForSMS.Size = new System.Drawing.Size(124, 20);
            textBox_CodeArrayForSMS.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 46);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(32, 13);
            label5.TabIndex = 3;
            // 
            // richTextBox_ModemStatus
            // 
            richTextBox_ModemStatus.Location = new System.Drawing.Point(7, 19);
            richTextBox_ModemStatus.Name = "richTextBox_ModemStatus";
            richTextBox_ModemStatus.Size = new System.Drawing.Size(256, 115);
            richTextBox_ModemStatus.TabIndex = 0;
            richTextBox_ModemStatus.Text = "";
            // 
            // comboBox_ComportSMS
            // 
            comboBox_ComportSMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_ComportSMS.FormattingEnabled = true;
            comboBox_ComportSMS.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            comboBox_ComportSMS.Location = new System.Drawing.Point(290, 22);
            comboBox_ComportSMS.Name = "comboBox_ComportSMS";
            comboBox_ComportSMS.Size = new System.Drawing.Size(67, 21);
            comboBox_ComportSMS.TabIndex = 9;
            comboBox_ComportSMS.Tag = "1";
            comboBox_ComportSMS.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged_2);
            // 
            // button36
            // 
            button36.Location = new System.Drawing.Point(269, 109);
            button36.Name = "button36";
            button36.Size = new System.Drawing.Size(75, 23);
            button36.TabIndex = 6;
            button36.Text = "Clear";
            button36.UseVisualStyleBackColor = true;
            button36.Click += new System.EventHandler(Button36_Click);
            // 
            // checkBox_OpenPortSMS
            // 
            checkBox_OpenPortSMS.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_OpenPortSMS.AutoSize = true;
            checkBox_OpenPortSMS.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_OpenPortSMS.Location = new System.Drawing.Point(363, 20);
            checkBox_OpenPortSMS.Name = "checkBox_OpenPortSMS";
            checkBox_OpenPortSMS.Size = new System.Drawing.Size(84, 29);
            checkBox_OpenPortSMS.TabIndex = 10;
            checkBox_OpenPortSMS.Text = "Open Port";
            checkBox_OpenPortSMS.UseVisualStyleBackColor = true;
            checkBox_OpenPortSMS.CheckedChanged += new System.EventHandler(CheckBox_OpenPortSMS_CheckedChanged);
            // 
            // checkBox_DebugSMS
            // 
            checkBox_DebugSMS.AutoSize = true;
            checkBox_DebugSMS.Location = new System.Drawing.Point(390, 54);
            checkBox_DebugSMS.Name = "checkBox_DebugSMS";
            checkBox_DebugSMS.Size = new System.Drawing.Size(67, 22);
            checkBox_DebugSMS.TabIndex = 11;
            checkBox_DebugSMS.Text = "Debug";
            checkBox_DebugSMS.UseVisualStyleBackColor = true;
            // 
            // button_ClearSMSConsole
            // 
            button_ClearSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button_ClearSMSConsole.Location = new System.Drawing.Point(395, 630);
            button_ClearSMSConsole.Name = "button_ClearSMSConsole";
            button_ClearSMSConsole.Size = new System.Drawing.Size(62, 26);
            button_ClearSMSConsole.TabIndex = 6;
            button_ClearSMSConsole.Text = "Clear";
            button_ClearSMSConsole.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseSMSConsole
            // 
            checkBox_PauseSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_PauseSMSConsole.AutoSize = true;
            checkBox_PauseSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_PauseSMSConsole.Location = new System.Drawing.Point(327, 630);
            checkBox_PauseSMSConsole.Name = "checkBox_PauseSMSConsole";
            checkBox_PauseSMSConsole.Size = new System.Drawing.Size(62, 26);
            checkBox_PauseSMSConsole.TabIndex = 5;
            checkBox_PauseSMSConsole.Text = "Pause";
            checkBox_PauseSMSConsole.UseVisualStyleBackColor = true;
            // 
            // checkBox_RecordSMSConsole
            // 
            checkBox_RecordSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox_RecordSMSConsole.AutoSize = true;
            checkBox_RecordSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            checkBox_RecordSMSConsole.Location = new System.Drawing.Point(222, 630);
            checkBox_RecordSMSConsole.Name = "checkBox_RecordSMSConsole";
            checkBox_RecordSMSConsole.Size = new System.Drawing.Size(99, 26);
            checkBox_RecordSMSConsole.TabIndex = 7;
            checkBox_RecordSMSConsole.Text = "Record Log";
            checkBox_RecordSMSConsole.UseVisualStyleBackColor = true;
            // 
            // richTextBox_SMSConsole
            // 
            richTextBox_SMSConsole.EnableAutoDragDrop = true;
            richTextBox_SMSConsole.Location = new System.Drawing.Point(6, 17);
            richTextBox_SMSConsole.Name = "richTextBox_SMSConsole";
            richTextBox_SMSConsole.Size = new System.Drawing.Size(451, 607);
            richTextBox_SMSConsole.TabIndex = 0;
            richTextBox_SMSConsole.Text = "";
            // 
            // button41
            // 
            button41.Location = new System.Drawing.Point(7, 359);
            button41.Name = "button41";
            button41.Size = new System.Drawing.Size(75, 23);
            button41.TabIndex = 1;
            button41.Text = "Add";
            button41.UseVisualStyleBackColor = true;
            button41.Click += new System.EventHandler(Button41_Click);
            // 
            // button40
            // 
            button40.Location = new System.Drawing.Point(88, 359);
            button40.Name = "button40";
            button40.Size = new System.Drawing.Size(75, 23);
            button40.TabIndex = 2;
            button40.Text = "Remove";
            button40.UseVisualStyleBackColor = true;
            button40.Click += new System.EventHandler(Button40_Click);
            // 
            // button39
            // 
            button39.Location = new System.Drawing.Point(7, 395);
            button39.Name = "button39";
            button39.Size = new System.Drawing.Size(75, 23);
            button39.TabIndex = 3;
            button39.Text = "Export";
            button39.UseVisualStyleBackColor = true;
            button39.Click += new System.EventHandler(Button39_Click_1);
            // 
            // button38
            // 
            button38.Location = new System.Drawing.Point(88, 395);
            button38.Name = "button38";
            button38.Size = new System.Drawing.Size(75, 23);
            button38.TabIndex = 4;
            button38.Text = "Import";
            button38.UseVisualStyleBackColor = true;
            button38.Click += new System.EventHandler(Button38_Click);
            // 
            // button37
            // 
            button37.Location = new System.Drawing.Point(169, 359);
            button37.Name = "button37";
            button37.Size = new System.Drawing.Size(75, 23);
            button37.TabIndex = 5;
            button37.Text = "Edit";
            button37.UseVisualStyleBackColor = true;
            button37.Click += new System.EventHandler(Button37_Click);
            // 
            // listBox_SMSCommands
            // 
            listBox_SMSCommands.FormattingEnabled = true;
            listBox_SMSCommands.Location = new System.Drawing.Point(6, 17);
            listBox_SMSCommands.Name = "listBox_SMSCommands";
            listBox_SMSCommands.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            listBox_SMSCommands.Size = new System.Drawing.Size(303, 290);
            listBox_SMSCommands.TabIndex = 6;
            listBox_SMSCommands.SelectedIndexChanged += new System.EventHandler(ListBox_SMSCommands_SelectedIndexChanged_1);
            // 
            // button_WriteCatalinas
            // 
            button_WriteCatalinas.Location = new System.Drawing.Point(789, 449);
            button_WriteCatalinas.Name = "button_WriteCatalinas";
            button_WriteCatalinas.Size = new System.Drawing.Size(144, 23);
            button_WriteCatalinas.TabIndex = 69;
            button_WriteCatalinas.Text = "Write Files To Flash";
            button_WriteCatalinas.UseVisualStyleBackColor = true;
            button_WriteCatalinas.Click += new System.EventHandler(button72_Click_2);
            // 
            // textBox_FilesToWriteForTheCatalinas
            // 
            textBox_FilesToWriteForTheCatalinas.Location = new System.Drawing.Point(0, 311);
            textBox_FilesToWriteForTheCatalinas.Name = "textBox_FilesToWriteForTheCatalinas";
            textBox_FilesToWriteForTheCatalinas.Size = new System.Drawing.Size(933, 131);
            textBox_FilesToWriteForTheCatalinas.TabIndex = 70;
            textBox_FilesToWriteForTheCatalinas.Text = "";
            textBox_FilesToWriteForTheCatalinas.MouseDown += new System.Windows.Forms.MouseEventHandler(textBox_FilesToWriteForTheCatalinas2_MouseDown);
            // 
            // richTextBox_SyntisazerL1
            // 
            richTextBox_SyntisazerL1.Location = new System.Drawing.Point(5, 111);
            richTextBox_SyntisazerL1.Name = "richTextBox_SyntisazerL1";
            richTextBox_SyntisazerL1.Size = new System.Drawing.Size(161, 124);
            richTextBox_SyntisazerL1.TabIndex = 71;
            richTextBox_SyntisazerL1.Text = "";
            richTextBox_SyntisazerL1.TextChanged += new System.EventHandler(richTextBox_SyntisazerL1_TextChanged);
            richTextBox_SyntisazerL1.MouseDown += new System.Windows.Forms.MouseEventHandler(richTextBox_SyntisazerL1_MouseDown);
            // 
            // richTextBox_SyntisazerL2
            // 
            richTextBox_SyntisazerL2.Location = new System.Drawing.Point(243, 108);
            richTextBox_SyntisazerL2.Name = "richTextBox_SyntisazerL2";
            richTextBox_SyntisazerL2.Size = new System.Drawing.Size(161, 132);
            richTextBox_SyntisazerL2.TabIndex = 72;
            richTextBox_SyntisazerL2.Text = "";
            richTextBox_SyntisazerL2.TextChanged += new System.EventHandler(richTextBox_SyntisazerL2_TextChanged);
            richTextBox_SyntisazerL2.MouseDown += new System.Windows.Forms.MouseEventHandler(richTextBox_SyntisazerL2_MouseDown);
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] {
            "A",
            "B"});
            comboBox1.Location = new System.Drawing.Point(371, 76);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(37, 21);
            comboBox1.TabIndex = 73;
            comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged_3);
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(8, 87);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(103, 13);
            label20.TabIndex = 74;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(240, 83);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(103, 13);
            label21.TabIndex = 75;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(6, 22);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(64, 13);
            label22.TabIndex = 76;
            // 
            // button_WriteSystemType
            // 
            button_WriteSystemType.Location = new System.Drawing.Point(89, 45);
            button_WriteSystemType.Name = "button_WriteSystemType";
            button_WriteSystemType.Size = new System.Drawing.Size(188, 23);
            button_WriteSystemType.TabIndex = 78;
            button_WriteSystemType.Text = "Write System type to flash";
            button_WriteSystemType.UseVisualStyleBackColor = true;
            button_WriteSystemType.Click += new System.EventHandler(button73_Click_1);
            // 
            // button_SynthL1
            // 
            button_SynthL1.Location = new System.Drawing.Point(2, 244);
            button_SynthL1.Name = "button_SynthL1";
            button_SynthL1.Size = new System.Drawing.Size(227, 23);
            button_SynthL1.TabIndex = 79;
            button_SynthL1.Text = "Write Synthesizer L1";
            button_SynthL1.UseVisualStyleBackColor = true;
            button_SynthL1.Click += new System.EventHandler(button96_Click_2);
            // 
            // button_WriteAllToFlash
            // 
            button_WriteAllToFlash.BackColor = System.Drawing.Color.Transparent;
            button_WriteAllToFlash.Location = new System.Drawing.Point(789, 24);
            button_WriteAllToFlash.Name = "button_WriteAllToFlash";
            button_WriteAllToFlash.Size = new System.Drawing.Size(144, 34);
            button_WriteAllToFlash.TabIndex = 80;
            button_WriteAllToFlash.Text = "Write all to flash";
            button_WriteAllToFlash.UseVisualStyleBackColor = false;
            button_WriteAllToFlash.Click += new System.EventHandler(button100_Click_2);
            // 
            // button_SynthL2
            // 
            button_SynthL2.Location = new System.Drawing.Point(243, 244);
            button_SynthL2.Name = "button_SynthL2";
            button_SynthL2.Size = new System.Drawing.Size(227, 23);
            button_SynthL2.TabIndex = 81;
            button_SynthL2.Text = "Write Synthesizer L2";
            button_SynthL2.UseVisualStyleBackColor = true;
            button_SynthL2.Click += new System.EventHandler(button101_Click);
            // 
            // progressBar_WriteToFlash
            // 
            progressBar_WriteToFlash.Location = new System.Drawing.Point(789, 68);
            progressBar_WriteToFlash.Name = "progressBar_WriteToFlash";
            progressBar_WriteToFlash.Size = new System.Drawing.Size(144, 23);
            progressBar_WriteToFlash.TabIndex = 82;
            // 
            // label123
            // 
            label123.AutoSize = true;
            label123.Location = new System.Drawing.Point(124, 34);
            label123.Name = "label123";
            label123.Size = new System.Drawing.Size(68, 18);
            label123.TabIndex = 33;
            label123.Text = "hex value";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(1458, 626);
            Controls.Add(groupBox_ClentTCPStatus);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox4);
            Controls.Add(button_OpenFolder);
            Controls.Add(groupBox_SerialPort);
            Controls.Add(tabControl_Main);
            Controls.Add(groupBox36);
            Controls.Add(groupBox_PhoneNumber);
            Controls.Add(groupBox42);
            Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "MainForm";
            Text = "3038 - WB PAA";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosed += new System.Windows.Forms.FormClosedEventHandler(MainForm_FormClosed_1);
            Load += new System.EventHandler(MainForm_Load);
            groupBox_ServerSettings.ResumeLayout(false);
            groupBox_ServerSettings.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl_Main.ResumeLayout(false);
            tabPage_charts.ResumeLayout(false);
            tabPage_charts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(chart1)).EndInit();
            tabPage_ServerTCP.ResumeLayout(false);
            tabPage_ServerTCP.PerformLayout();
            groupBox_FOTA.ResumeLayout(false);
            groupBox_FOTA.PerformLayout();
            groupBox_ConnectionTimedOut.ResumeLayout(false);
            groupBox_ConnectionTimedOut.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabPage_ClientTCP.ResumeLayout(false);
            tabPage_ClientTCP.PerformLayout();
            tabPage_SerialPort.ResumeLayout(false);
            groupBox_SendSerialOrMonitorCommands.ResumeLayout(false);
            groupBox_SendSerialOrMonitorCommands.PerformLayout();
            gbPortSettings.ResumeLayout(false);
            gbPortSettings.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox_Timer.ResumeLayout(false);
            groupBox_Timer.PerformLayout();
            groupBox_Stopwatch.ResumeLayout(false);
            groupBox_Stopwatch.PerformLayout();
            tabPage_GenericFrame.ResumeLayout(false);
            groupBox31.ResumeLayout(false);
            groupBox31.PerformLayout();
            groupBox_clientTX.ResumeLayout(false);
            groupBox_clientTX.PerformLayout();
            groupBox41.ResumeLayout(false);
            groupBox41.PerformLayout();
            tabPage_Commands.ResumeLayout(false);
            groupBox40.ResumeLayout(false);
            tabControl_System.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox32.ResumeLayout(false);
            groupBox32.PerformLayout();
            tabPage3038WBPAA.ResumeLayout(false);
            groupBox43.ResumeLayout(false);
            groupBox48.ResumeLayout(false);
            groupBox38.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            groupBox49.ResumeLayout(false);
            groupBox49.PerformLayout();
            groupBox37.ResumeLayout(false);
            groupBox37.PerformLayout();
            groupBox47.ResumeLayout(false);
            groupBox47.PerformLayout();
            groupBox39.ResumeLayout(false);
            groupBox39.PerformLayout();
            groupBox35.ResumeLayout(false);
            groupBox35.PerformLayout();
            groupBox46.ResumeLayout(false);
            groupBox46.PerformLayout();
            groupBox45.ResumeLayout(false);
            groupBox45.PerformLayout();
            groupBox34.ResumeLayout(false);
            groupBox34.PerformLayout();
            groupBox44.ResumeLayout(false);
            groupBox44.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox33.ResumeLayout(false);
            groupBox33.PerformLayout();
            tabPage13.ResumeLayout(false);
            tabPage13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_ValPage0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_OverUnder)).EndInit();
            tabPage7.ResumeLayout(false);
            tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_Page1_4)).EndInit();
            tabPage8.ResumeLayout(false);
            tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_VVAOffset1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_VVAOffset2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_PAVVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView_DC4)).EndInit();
            tabPage9.ResumeLayout(false);
            tabPage9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dataGridView8)).EndInit();
            groupBox42.ResumeLayout(false);
            groupBox42.PerformLayout();
            tabPage4.ResumeLayout(false);
            S1_Configuration.ResumeLayout(false);
            groupBox12.ResumeLayout(false);
            groupBox22.ResumeLayout(false);
            groupBox22.PerformLayout();
            groupBox28.ResumeLayout(false);
            groupBox28.PerformLayout();
            groupBox30.ResumeLayout(false);
            groupBox30.PerformLayout();
            groupBox29.ResumeLayout(false);
            groupBox29.PerformLayout();
            groupBox27.ResumeLayout(false);
            groupBox27.PerformLayout();
            groupBox26.ResumeLayout(false);
            groupBox26.PerformLayout();
            groupBox25.ResumeLayout(false);
            groupBox25.PerformLayout();
            groupBox24.ResumeLayout(false);
            groupBox23.ResumeLayout(false);
            groupBox21.ResumeLayout(false);
            groupBox21.PerformLayout();
            groupBox20.ResumeLayout(false);
            groupBox20.PerformLayout();
            groupBox19.ResumeLayout(false);
            groupBox19.PerformLayout();
            groupBox18.ResumeLayout(false);
            groupBox18.PerformLayout();
            groupBox17.ResumeLayout(false);
            groupBox17.PerformLayout();
            groupBox11.ResumeLayout(false);
            groupBox10.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            groupBox14.ResumeLayout(false);
            groupBox15.ResumeLayout(false);
            groupBox15.PerformLayout();
            groupBox16.ResumeLayout(false);
            groupBox16.PerformLayout();
            groupBox_PhoneNumber.ResumeLayout(false);
            groupBox_PhoneNumber.PerformLayout();
            groupBox_SerialPort.ResumeLayout(false);
            groupBox_SerialPort.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            groupBox_ClentTCPStatus.ResumeLayout(false);
            groupBox_ClentTCPStatus.PerformLayout();
            ResumeLayout(false);

        }

        private readonly List<string> CommandsHistoy = new List<string>();
        private int HistoryIndex = -1;
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

        private void ListBox_SMSCommands_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedCommand();
            }
        }

        private void CheckedListBox_PhoneBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedContact();
            }
        }

        private static bool PhoneBookIsChecked = false;

        private void CheckedListBox_PhoneBook_MouseDown(object sender, MouseEventArgs e)
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

        private void TextBox_GeneralMessage_KeyPress(object sender, KeyPressEventArgs e)
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
        private static void Main()
        {

            Application.Run(new MainForm());


        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

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
                object objData = SendString;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                SendDataToServer(comboBox_ConnectionNumber.SelectedItem.ToString(), byData);
            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }
        }

        private bool SerialPortSendData(byte[] i_SendData)
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

        private void SendExceptionToTheMonitor(string i_Message)
        {
            SerialPortLogger.LogMessage(Color.Red, Color.LightGray, i_Message, New_Line = true, Show_Time = true);
        }

        //Color oldColor;
        private Gil_Server.Server m_Server;
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

        private void Server_InformationNotifyDelegate(object sender, EventArgs e)
        {
            Gil_Server.Server.stringEventArgs mye = (Gil_Server.Server.stringEventArgs)e;

            ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            ServerLogger.LogMessage(Color.Brown, Color.White, "[Internal Server] ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.Black, Color.White, mye.StrData, New_Line = true, Show_Time = false);
        }

        private static int LastIgn = 1;
        private static int TimerStatusRingWait = 0;

        //string[] UnitNumberToConnections = new string[30];
        private readonly Dictionary<string, string> ConnectionToIDdictionary = new Dictionary<string, string>();
        private readonly Dictionary<string, string> IDToFOTA_Status = new Dictionary<string, string>();

        private void GilServer_DataRecievedNotifyDelegate(object sender, EventArgs e)
        {

            Gil_Server.Server.DataEventArgs mye = (Gil_Server.Server.DataEventArgs)e;

            ASCIIEncoding encoder = new ASCIIEncoding();

            // string IncomingString = System.Text.Encoding.Default.GetString(mye.BytesData);
            string IncomingString = ByteArrayToString(mye.BytesData.ToArray());
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

        private void PrintFotaIDStatus()
        {

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

        private byte CalcCheckSumbufferSize(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < i_buffer.Length; i++)
            {
                ret += i_buffer[i];
            }
            return ret;
        }

        private byte CalcCheckSumbuffer(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < 1280; i++)
            {
                ret += i_buffer[i];
            }
            return ret;
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

        private void SendDataToServer(string i_Connection, byte[] i_Data)
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

        private void UpdatePhoneBook()
        {


        }

        //void ClacPhoneBookTimeForPeriodOfSystem()
        //{
        //    System.Windows.Forms.Application.Exit();
        //}
        private TextBox_Logger SystemLogger;
        private TextBox_Logger ServerLogger;
        private TextBox_Logger SerialPortLogger;

        //   Logger LogIWatcher;
        // TextBox_Logger LogSMS;
        //   PhoneBook MyPhoneBook;
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

        private Point? prevPosition = null;
        private readonly ToolTip tooltip = new ToolTip();

        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
            {
                return;
            }

            tooltip.RemoveAll();
            prevPosition = pos;
            HitTestResult[] results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (HitTestResult result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        double pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        double pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 3 &&
                            Math.Abs(pos.Y - pointYPixel) < 3)
                        {
                            //textBox_graph_XY.Text = "Chart=" + result.Series.Name + "\n, X=" + prop.XValue.ToString() + ", Y=" + prop.YValues[0].ToString();

                            tooltip.Show("X=" + prop.XValue.ToString("0.##E+0") + ", Y=" + prop.YValues[0], chart1,
                                            pos.X, pos.Y - 15, 9999999);
                        }
                    }
                }
            }
        }

        private void Chart1_MouseClick(object sender, MouseEventArgs e)
        {
            Point pos = e.Location;
            //if (prevPosition.HasValue && pos == prevPosition.Value)
            //    return;
            tooltip.RemoveAll();
            prevPosition = pos;
            HitTestResult[] results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (HitTestResult result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        double pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        double pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

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

            if (ReceiveThread != null)
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
        //public void System1_parser_sum_CB(OneSystemCommand i_cmd, String[] i_InputArgs)
        //{
        //    int sum = 0;
        //    if (i_InputArgs[0] == "?")
        //    {
        //        SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "Sum CB: " + i_cmd.Help, New_Line = true, Show_Time = true);
        //    }
        //    else
        //    {
        //        foreach (String str in i_InputArgs)
        //        {
        //            sum += Int32.Parse(str);

        //        }

        //        SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "Sum CB: sum = " + sum, New_Line = true, Show_Time = true);
        //    }
        //}



        //readonly System1_parser system1_Parser = new System1_parser();


        // List<S1_Protocol.S1_Messege_Builder.Command_Description> CommandsDescription;
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

                tabControl_Main.TabPages.RemoveAt(0);
                tabControl_Main.TabPages.RemoveAt(0);
                tabControl_Main.TabPages.RemoveAt(0);

                //system1_Parser.AddCommand("sum", " sum all the elements \n Format: sum 1 2 3");
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

                Text = Text + " [ " + ", Version: " + version + ", Compiled: " + RetrieveLinkerTimestamp().ToString() + " ]";







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

                foreach (Control allContrls in Controls)
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

        private void EditDataGridForSSPAWB()
        {
            int i = 0;

            dataGridView_DC4.TopLeftHeaderCell.Value = "Temperature (C)";
            dataGridView8.TopLeftHeaderCell.Value = "Temperature (C)";
            dataGridView_PAVVA.TopLeftHeaderCell.Value = "Power (dBm)";

            dataGridView_VVAOffset2.TopLeftHeaderCell.Value = "Power (dBm)";
            dataGridView_VVAOffset1.TopLeftHeaderCell.Value = "Power (dBm)";
            dataGridView_OverUnder.TopLeftHeaderCell.Value = "Volts (V)";
            dataGridView_Page1_4.TopLeftHeaderCell.Value = "VVA";





            int RowText = -31;
            int Temperature = -31;

            //this.dataGridView_Page1_4.RowTemplate.Height = 20;
            ////this.dataGridView_Page1_4.RowsDefaultCellStyle.Font = new Font("Calibri", 8);
            //this.dataGridView_DC4.RowTemplate.Height = 20;
            //this.dataGridView8.RowTemplate.Height = 20;

            for (i = 0; i < 32; i++)
            {

                dataGridView_Page1_4.Rows.Add();
                dataGridView_Page1_4.Rows[i].HeaderCell.Value = string.Format("{0}C", Temperature);


                dataGridView8.Rows.Add();
                dataGridView8.Rows[i].HeaderCell.Value = string.Format("{0}..{1}C", RowText, RowText + 3);

                dataGridView_DC4.Rows.Add();
                dataGridView_DC4.Rows[i].HeaderCell.Value = string.Format("{0}..{1}C", RowText, RowText + 3);
                RowText += 3;
                Temperature += 4;
            }

            RowText = -3;
            for (i = 0; i < 21; i++)
            {
                dataGridView_PAVVA.Rows.Add();
                dataGridView_PAVVA.Rows[i].HeaderCell.Value = string.Format("{0} dBm", RowText);
                RowText--;
            }

            dataGridView_PAVVA.Rows[0].HeaderCell.Value += " <";
            dataGridView_PAVVA.Rows[20].HeaderCell.Value += " >";


            double RowText2 = 46;
            for (i = 0; i < 9; i++)
            {

                dataGridView_VVAOffset1.Rows.Add();
                dataGridView_VVAOffset1.Rows[i].HeaderCell.Value = string.Format("{0} dBm", RowText);

                dataGridView_VVAOffset2.Rows.Add();
                dataGridView_VVAOffset2.Rows[i].HeaderCell.Value = string.Format("{0} dBm", RowText);

                RowText2 -= 0.2;
            }
            dataGridView_VVAOffset2.Rows[8].HeaderCell.Value += "<";
            dataGridView_VVAOffset2.Rows.Add();
            dataGridView_VVAOffset2.Rows[9].HeaderCell.Value = "40- DC4";

            dataGridView_VVAOffset1.Rows[8].HeaderCell.Value += "<";
            dataGridView_VVAOffset1.Rows.Add();
            dataGridView_VVAOffset1.Rows[9].HeaderCell.Value = "40- DC4";

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
                string temp = txt.Text;
                txt.Text = " ";
                txt.Text = temp;
            }

            if (ctl.GetType().FullName == "System.Windows.Forms.RichTextBox")
            {
                RichTextBox txt = (RichTextBox)ctl;

                txt.Invoke(new EventHandler(delegate
                {

                    string temp = txt.Text;
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

        private void SaveCommandsAndContacts()
        {
            string subPath = Directory.GetCurrentDirectory() + "\\SMS_Backup\\";
            string m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_Contacts" + ".xml";
            string filesName = m_log_file_name;

            bool isExists = System.IO.Directory.Exists(subPath);

            if (!isExists)
            {
                System.IO.Directory.CreateDirectory(subPath);
            }


            m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "____________Commands" + ".xml";
            filesName += "\n" + m_log_file_name;
            using (Stream myStream = File.Create(subPath + m_log_file_name))
            {
                List<string> templist = new List<string>();
                foreach (object item in listBox_SMSCommands.Items)
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
        private readonly List<TextBox> List_ConfigurationTextBoxes = new List<TextBox>();


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

        private string ConfigFileName;
        private void Button28_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                //TextBox_File_Name.Text = openFileDialog1.FileName;



            }


        }

        private int NumOfRemainCommands = 0;
        private void BackgroundWorker_ConfigSystem_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

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
            float ret = (NumOfRemainCommands / (float)CommandsToSend.Count) * 100;
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

        private readonly List<List<string>> CommandsToSend = new List<List<string>>();












        private void Button29_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox_GeneralMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private double ChartCntX = 0, ChartCntY = 0;
        private double ChartCntY2 = 0;
        private double ChartCntY3 = 0;
        private bool OppositeCount = false, SerialRxBlinklled = false, SerialTxBlinklled = false;

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
                answer = string.Format("{0}.{1:D2}s", t.Seconds, t.Milliseconds / 10);
            }
            else if (t.TotalHours < 1.0)
            {
                //answer = String.Format("{0}m:{1:D2}.{2:D2}s", t.Minutes, t.Seconds, t.Milliseconds % 100);
                answer = string.Format("{0}m:{1:D2}", t.Minutes, t.Seconds);
            }
            else // more than 1 hour
            {
                answer = string.Format("{0}h:{1:D2}m:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
            }

            return answer;
        }

        private static int GetDataIntervalCounter;
        private bool IsTimedOutTimerEnabled = false;

        /// <summary>
        /// 
        /// </summary>
        private int Timer_100ms = 0;

        private void ClientTCpipProcessing()
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

            if (checkBox_SendEveryOneSecond.CheckState == CheckState.Checked)
            {
                if (textBox_SendSerialPortPeriod.BackColor == Color.LightGreen)
                {
                    if (int.TryParse(textBox_SendSerialPortPeriod.Text, out int TimeSend))
                    {
                        if (Timer_100ms % TimeSend == 0)
                        {
                            Button2_Click_1(null, null);
                        }
                    }

                }
            }

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

            if (serialPort.IsOpen == true)
            {
                SerialTerminalRxTxLights();
            }







        }

        private void SerialTerminalRxTxLights()
        {
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

        private readonly List<double> ChartMem = new List<double>();
        private readonly List<double> ChartMem2 = new List<double>();
        private readonly Random rand = new Random();
        private int GreenCnt = 0, RedCnt = 0;
        private const int MOVING_AVARAGE_SIZE = 30;

        private void GraphPrint()
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

            string filePath = FileLocation;
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

        private int FindZeroPaddingSize(int i_SignalLength)
        {
            uint mLogN = 0;
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

        private int WaitforBufferFull = -1;

        //DSPLib.DSP.Window.Type windowToApply;
        //void CheckForMiniAdaDataFFT(SSPA_Parser i_MiniAdaParser)
        //{



        //    //  double samplingRate = Convert.ToDouble(TextBoxFsSamplingRate.Text); ;
        //    //UInt32 zeroPadding = 9000;
        //    double scale = 2 ^ 11 - 1;


        //    double[] IQ1Sigal = new double[i_MiniAdaParser.IQData.I1.Length];
        //    double[] IQ2Sigal = new double[i_MiniAdaParser.IQData.I2.Length];

        //    for (int i = 0; i < i_MiniAdaParser.IQData.I1.Length; i++)
        //    {
        //        IQ1Sigal[i] = (double)(i_MiniAdaParser.IQData.I1[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q1[i] / scale / 2);
        //    }


        //    for (int i = 0; i < i_MiniAdaParser.IQData.I2.Length; i++)
        //    {
        //        IQ2Sigal[i] = (double)(i_MiniAdaParser.IQData.I2[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q2[i] / scale / 2);
        //    }

        //    int zeroPadding = FindZeroPaddingSize(IQ1Sigal.Length);
        //    int zeroPadding2 = FindZeroPaddingSize(IQ2Sigal.Length);





        //    // Instantiate & Initialize a new DFT
        //    DSPLib.FFT fft = new DSPLib.FFT();
        //    DSPLib.FFT fft2 = new DSPLib.FFT();
        //    //DSPLib.DFT dft = new DSPLib.DFT();
        //    fft.Initialize((uint)IQ1Sigal.Length, (uint)zeroPadding); // NOTE: Zero Padding
        //    fft2.Initialize((uint)IQ2Sigal.Length, (uint)zeroPadding2);

        //    // Call the DFT and get the scaled spectrum back

        //    // Convert the complex spectrum to note: Magnitude Format


        //    //double[] lmSpectrum = DSP.ConvertMagnitude.ToMagnitudeDBV(temp);
        //    // double[] lmSpectrum2 = DSP.ConvertMagnitude.ToMagnitudeDBV(temp2);
        //    // Properly scale the spectrum for the added window




        //    // For plotting on an XY Scatter plot generate the X Axis frequency Span
        //    //   double[] freqSpan = fft.FrequencySpan(samplingRate);
        //    //  double[] freqSpan2 = fft2.FrequencySpan(samplingRate);
        //    // At this point a XY Scatter plot can be generated from,
        //    // X axis => freqSpan
        //    // Y axis => lmSpectrum
        //    //double Mean = DSP.Analyze.FindMean(IQ1Sigal);
        //    //double Mean2 = DSP.Analyze.FindMean(IQ2Sigal);

        //    //double RMS = DSP.Analyze.FindRms(IQ1Sigal);
        //    //double RMS2 = DSP.Analyze.FindRms(IQ2Sigal);

        //    //double MaxAmplitude = DSP.Analyze.FindMaxAmplitude(lmSpectrum);
        //    //double MaxPosition = DSP.Analyze.FindMaxPosition(lmSpectrum);
        //    //double MaxFrequency = DSP.Analyze.FindMaxFrequency(lmSpectrum, freqSpan);

        //    //textBox_graph_XY.BeginInvoke(new EventHandler(delegate
        //    //{
        //    //    textBox_graph_XY.Text = String.Format(" \n CH1 : Mean [{0}] RMS [{1}] \n", Mean.ToString("0.00"),RMS.ToString("0.00"));
        //    //    textBox_graph_XY.Text += String.Format(" \n CH2 : Mean [{0}] RMS [{1}]  \n ", Mean2.ToString("0.00"), RMS2.ToString("0.00"));
        //    //    textBox_graph_XY.Text += String.Format(" \n CH1 : MaxAmplitude [{0}] MaxPosition [{1}] MaxFrequency [{2}] \n ", MaxAmplitude.ToString("0.00"), MaxPosition.ToString("0.00"), MaxFrequency.ToString("0.00"));

        //    //}));

        //    listBox_Charts.BeginInvoke(new EventHandler(delegate
        //    {
        //        var series1 = new Series("CH1 " + ChartIndex.ToString());
        //        //var series2 = new Series("IQ1 Time " + ChartIndex.ToString());
        //        var series3 = new Series("CH2 " + ChartIndex.ToString());
        //        //  var series4 = new Series("IQ2 Time " + ChartIndex.ToString());

        //        series1.ChartType = SeriesChartType.Line;
        //        series3.ChartType = SeriesChartType.Line;

        //        ChartIndex++;

        //        //  listBox_Charts.Items.Add(series4.Name);
        //        // Frist parameter is X-Axis and Second is Collection of Y- Axis
        //        // double[] xData = DSP.Generate.LinSpace(-(freqSpan.Length) / 2 , (freqSpan.Length) / 2, (UInt32)(freqSpan.Length));
        //        //       series1.Points.DataBindXY(freqSpan, lmSpectrum);
        //        for (int i = 0; i < IQ1Sigal.Length; i++)
        //        {
        //            //         series2.Points.AddXY(i, IQ1Sigal[i]);
        //        }
        //        //     series2.ChartType = SeriesChartType.Line;
        //        chart1.Series.Add(series1);
        //        //     chart1.Series.Add(series2);

        //        //  series3.Points.DataBindXY(freqSpan, lmSpectrum2);

        //        for (int i = 0; i < IQ1Sigal.Length; i++)
        //        {
        //            //         series4.Points.AddXY(i, IQ1Sigal[i]);
        //        }
        //        //      series4.ChartType = SeriesChartType.Line;
        //        chart1.Series.Add(series3);
        //        //   chart1.Series.Add(series4);

        //        PlotGraphTimer = -1;
        //        textBox_SystemStatus.Text = "Graphs is ready;\n";
        //        textBox_SystemStatus.BackColor = Color.LightGreen;

        //        //Gil: Find the maximum and minimum points
        //        //      MarkTheBiggestFreq(series1, lmSpectrum, freqSpan);
        //        //      MarkTheBiggestFreq(series3, lmSpectrum2, freqSpan2);


        //    }));


        //}

        private void MarkTheBiggestFreq(Series i_serias, double[] i_lmSpectrum, double[] i_freqSpan)
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
            maxYpt.Label = string.Format("X= {0} Y= {1} dBm", maxYpt.XValue.ToString("0.##E+0"), maxYpt.YValues[0].ToString("0.00"));
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
            i_serias.LegendToolTip = string.Format(" \n{0} \n Mean [{1}] \n RMS [{2}] \n MaxAmplitude [{3}] \n MaxPosition [{4}] \n MaxFrequency [{5}] \n \n", i_serias.Name, Mean.ToString("0.00"), RMS.ToString("0.00"), MaxAmplitude.ToString("0.00"), MaxPosition.ToString("0.00"), MaxFrequency.ToString("0.##E+0"));
        }

        //void CheckForMiniAdaDataDFT(SSPA_Parser i_MiniAdaParser)
        //{
        //    //// Same Input Signal as Example 1 - Except a fractional cycle for frequency.
        //    //double amplitude = 1.0; double frequency = 20000.5;
        //    //UInt32 length = 1000; UInt32 zeroPadding = 9000; // NOTE: Zero Padding
        //    //double samplingRate = 100000;
        //    //double[] inputSignal = DSPLib.DSP.Generate.ToneSampling(amplitude, frequency, samplingRate, length);
        //    //// Apply window to the Input Data & calculate Scale Factor
        //    //double[] wCoefs = DSP.Window.Coefficients(DSP.Window.Type.FTNI, length);
        //    //double[] wInputData = DSP.Math.Multiply(inputSignal, wCoefs);
        //    //double wScaleFactor = DSP.Window.ScaleFactor.Signal(wCoefs);
        //    //// Instantiate & Initialize a new DFT
        //    //DSPLib.DFT dft = new DSPLib.DFT();
        //    //dft.Initialize(length, zeroPadding); // NOTE: Zero Padding
        //    //                                     // Call the DFT and get the scaled spectrum back
        //    //Complex[] cSpectrum = dft.Execute(wInputData);
        //    //// Convert the complex spectrum to note: Magnitude Format
        //    //double[] lmSpectrum = DSPLib.DSP.ConvertComplex.ToMagnitude(cSpectrum);
        //    //// Properly scale the spectrum for the added window
        //    //lmSpectrum = DSP.Math.Multiply(lmSpectrum, wScaleFactor);
        //    //// For plotting on an XY Scatter plot generate the X Axis frequency Span
        //    //double[] freqSpan = dft.FrequencySpan(samplingRate);
        //    //// At this point a XY Scatter plot can be generated from,
        //    //// X axis => freqSpan
        //    //// Y axis => lmSpectrum

        //    //var series = new Series("Freq 2");
        //    //var series2 = new Series("Time 2");
        //    //listBox_Charts.Items.Add(series.Name);
        //    //listBox_Charts.Items.Add(series2.Name);
        //    //// Frist parameter is X-Axis and Second is Collection of Y- Axis
        //    //series.Points.DataBindXY(freqSpan, lmSpectrum);

        //    //for (int i = 0; i < inputSignal.Length / 10; i++)
        //    //{
        //    //    series2.Points.AddXY(i, inputSignal[i]);
        //    //}
        //    //series2.ChartType = SeriesChartType.Line;
        //    //chart1.Series.Add(series);
        //    //chart1.Series.Add(series2);

        //    //  double samplingRate = Convert.ToDouble(TextBoxFsSamplingRate.Text); ;
        //    //UInt32 zeroPadding = 9000;
        //    double scale = 2 ^ 11 - 1;


        //    double[] IQ1Sigal = new double[i_MiniAdaParser.IQData.I1.Length];
        //    double[] IQ2Sigal = new double[i_MiniAdaParser.IQData.I2.Length];

        //    for (int i = 0; i < i_MiniAdaParser.IQData.I1.Length; i++)
        //    {
        //        IQ1Sigal[i] = (double)(i_MiniAdaParser.IQData.I1[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q1[i] / scale / 2);
        //    }


        //    for (int i = 0; i < i_MiniAdaParser.IQData.I2.Length; i++)
        //    {
        //        IQ2Sigal[i] = (double)(i_MiniAdaParser.IQData.I2[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q2[i] / scale / 2);
        //    }

        //    int zeroPadding = 0;
        //    //   Int32.TryParse(TextBox_Zeropadding.Text, out zeroPadding);



        //    // Instantiate & Initialize a new DFT
        //    DSPLib.DFT dft = new DSPLib.DFT();
        //    DSPLib.DFT dft2 = new DSPLib.DFT();
        //    //DSPLib.DFT dft = new DSPLib.DFT();
        //    dft.Initialize((uint)IQ1Sigal.Length, (uint)zeroPadding); // NOTE: Zero Padding
        //    dft2.Initialize((uint)IQ2Sigal.Length, (uint)zeroPadding);

        //    // Call the DFT and get the scaled spectrum back

        //    // Convert the complex spectrum to note: Magnitude Format

        //    // Properly scale the spectrum for the added window

        //    // For plotting on an XY Scatter plot generate the X Axis frequency Span
        //    //double[] freqSpan = dft.FrequencySpan(samplingRate);
        //    //double[] freqSpan2 = dft2.FrequencySpan(samplingRate);
        //    // At this point a XY Scatter plot can be generated from,
        //    // X axis => freqSpan
        //    // Y axis => lmSpectrum

        //    listBox_Charts.BeginInvoke(new EventHandler(delegate
        //    {
        //        var series1 = new Series("IQ1 Freq " + ChartIndex.ToString());
        //        var series2 = new Series("IQ1 Time " + ChartIndex.ToString());
        //        var series3 = new Series("IQ2 Freq " + ChartIndex.ToString());
        //        var series4 = new Series("IQ2 Time " + ChartIndex.ToString());

        //        ChartIndex++;
        //        listBox_Charts.Items.Add(series1.Name);
        //        listBox_Charts.Items.Add(series2.Name);
        //        listBox_Charts.Items.Add(series3.Name);
        //        listBox_Charts.Items.Add(series4.Name);
        //        // Frist parameter is X-Axis and Second is Collection of Y- Axis
        //        //       series1.Points.DataBindXY(freqSpan, lmSpectrum);

        //        for (int i = 0; i < IQ1Sigal.Length; i++)
        //        {
        //            series2.Points.AddXY(i, IQ1Sigal[i]);
        //        }
        //        series2.ChartType = SeriesChartType.Line;
        //        chart1.Series.Add(series1);
        //        chart1.Series.Add(series2);

        //        //    series3.Points.DataBindXY(freqSpan, lmSpectrum);

        //        for (int i = 0; i < IQ1Sigal.Length; i++)
        //        {
        //            series4.Points.AddXY(i, IQ1Sigal[i]);
        //        }
        //        series4.ChartType = SeriesChartType.Line;
        //        chart1.Series.Add(series3);
        //        chart1.Series.Add(series4);

        //        PlotGraphTimer = -1;
        //        textBox_SystemStatus.Text = "Graphs is ready;";
        //        textBox_SystemStatus.BackColor = Color.LightGreen;
        //    }));


        //}

        public string ConvertHex(string hexString)
        {
            try
            {
                string ascii = string.Empty;
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    string hs = string.Empty;
                    hs = hexString.Substring(i, 2);
                    if (hs != "00")
                    {
                        uint decval = System.Convert.ToUInt32(hs, 16);
                        char character = System.Convert.ToChar(decval);
                        ascii += character;
                    }

                }
                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return string.Empty;
        }


        public float ConvertFloat(string hexString)
        {
            try
            {
                //string hexString = "43480170";
                uint num = uint.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);
                byte[] floatVals = BitConverter.GetBytes(num).Reverse().ToArray();

                float f = BitConverter.ToSingle(floatVals, 0);
                return f;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return 0;
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
            catch
            {
                return null;
            }


        }

        // object ReturnValue =null;
        public class GetRecodIQDataClass
        {
            public short[] I1;
            public short[] Q1;
            public short[] I2;
            public short[] Q2;
        }
        public GetRecodIQDataClass IQData = new GetRecodIQDataClass();

        //public object GetDataFromParser()
        //{
        //    object ret = ReturnValue;
        //    ReturnValue = null;
        //    return ret;
        //}


        private string UnHandaledPreample(KratosProtocolFrame i_Parsedframe)
        {
            string ret = string.Format("\n Unkown Preample Unhandled: [{0}] \n", i_Parsedframe.Preamble);
            textBox_SystemStatus.Text = ret;

            return ret;
        }

        private string UnHandledOpcode(KratosProtocolFrame i_Parsedframe)
        {

            string ret = string.Format("\n Opcode Unhandled: [{0}] \n", i_Parsedframe.Opcode);
            textBox_SystemStatus.Text = ret;

            return ret;

        }

        //string RetriveIQData(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n IQ data retrive: [{0}] \n", i_Parsedframe.Data);
        //}
        //string PlayIQData(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n IQ Data sent to play \n");
        //}
        //string GetUbloxData(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Ublox data: [{0}] \n", ConvertHex(i_Parsedframe.Data));
        //}

        //string SetRxChannelStateCal(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n RX channel state RX/CAL have been set \n");
        //}
        //string RecordIQDaraSelectSource(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n Record IQ data source selected \n");
        //}
        //string RecordIQData(KratosProtocolFrame i_Parsedframe)
        //{
        //    byte[] DataBytes = StringToByteArray(i_Parsedframe.Data);



        //    int NumberOfSamples = DataBytes.Length;
        //    NumberOfSamples /= 8;

        //    IQData = new GetRecodIQDataClass();
        //    IQData.I1 = new Int16[NumberOfSamples - 1];
        //    IQData.Q1 = new Int16[NumberOfSamples - 1];
        //    IQData.I2 = new Int16[NumberOfSamples - 1];
        //    IQData.Q2 = new Int16[NumberOfSamples - 1];

        //    for (int i = 1; i < (DataBytes.Length / 8) - 1; i++)// Gil: i=1 beacuse we throw the first sample
        //    {
        //        int Index = i * 8;
        //        IQData.I1[i] = (Int16)(DataBytes[Index] | DataBytes[Index + 1] << 8);
        //        IQData.Q1[i] = (Int16)(DataBytes[Index + 2] | DataBytes[Index + 3] << 8);
        //        IQData.I2[i] = (Int16)(DataBytes[Index + 4] | DataBytes[Index + 5] << 8);
        //        IQData.Q2[i] = (Int16)(DataBytes[Index + 6] | DataBytes[Index + 7] << 8);
        //    }




        //    return String.Format("\n IQ samples Data: [{0}]  Data Length: [{1}] Bytes\n", i_Parsedframe.Data, DataBytes.Length);
        //}
        //string SetGPIOValue(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n GPIO value have been set \n");
        //}

        //string GetGPIOValue(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n GPIO Value  [{0}]  \n", i_Parsedframe.Data);
        //}
        //string SetGPIODirection(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n GPIO direction have been set \n");
        //}

        //string GetGPIODirection(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n GPIO direction  [{0}]  \n", i_Parsedframe.Data);
        //}
        //string TxGetRFPLLlockDetect(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n Tx Get RF PLL lock Detect [{0}]  \n", i_Parsedframe.Data);
        //}
        //string RxGetRFPLLlockDetect(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n Rx Get RF PLL lock Detect [{0}]  \n", i_Parsedframe.Data);
        //}
        //string GetDCA(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n DCA [{0}] dBm \n", ConvertFloat(i_Parsedframe.Data));
        //}

        //string SetDCA(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n DCA has been set \n");
        //}
        //string GetRXChannelGain(KratosProtocolFrame i_Parsedframe)
        //{
        //    int intValue = int.Parse(i_Parsedframe.Data, System.Globalization.NumberStyles.HexNumber);
        //    return String.Format("\n Rx channel Gain [{0}] \n", intValue);
        //}
        //string SetRXChannelGain(KratosProtocolFrame i_Parsedframe)
        //{
        //    byte[] DataBytes = StringToByteArray(i_Parsedframe.Data);
        //    return String.Format("\n RX Channel Gain has been set\n");
        //}
        //string LoadDataInFlash(KratosProtocolFrame i_Parsedframe)
        //{
        //    byte[] DataBytes = StringToByteArray(i_Parsedframe.Data);
        //    return String.Format("\n Loaded Data: [{0}]  Data Length: [{1}] Bytes\n", i_Parsedframe.Data, DataBytes.Length);
        //}



        //string EraseSectorintFlash(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Sector has been erased \n");
        //}
        //string StoreDataInFlash(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Data stored in the flash \n");
        //}
        //string Write_FPGA_Data(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n FPGA value have been set \n");
        //}

        //string Read_FPGA_Data(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n FPGA value [{0}] \n", i_Parsedframe.Data);
        //}
        //string SetTXCO_ON_OFF(KratosProtocolFrame i_Parsedframe)
        //{


        //    return String.Format("\n TCXO have been set \n");
        //}
        //string GetOutputPower(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Output Power [{0}] dBm \n", ConvertFloat(i_Parsedframe.Data));
        //}
        //string SetOutputPower(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n System Output power havs been set \n");
        //}
        //string GetSytemState(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n System State [{0}] \n", ConvertHex(i_Parsedframe.Data));
        //}
        //string SetSytemState(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n System state have been changed \n");
        //}
        //string DoSync(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Sync received \n");
        //}
        //string GetTxAD936X(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n Tx AD936X  [{0}] \n", i_Parsedframe.Data);

        //}
        //string SetTxAD936X(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Tx AD936X data Has been Set [OK] \n");
        //}
        //string SetSynthesizerL2(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Synthesizer L2 Has been Set [OK] \n");
        //}
        //string SetSynthesizerL1(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Synthesizer L1 Has been Set [OK] \n");

        //}
        //string GetPSUCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n PSU card Information [{0}] \n", ConvertHex(i_Parsedframe.Data));
        //}

        //string SetPSUCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n PSU card Information Has been Set [OK] \n");
        //}

        //string GetRFCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n RF card Information [{0}] \n", ConvertHex(i_Parsedframe.Data));
        //}

        //string SetRFCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Core RF Information Has been Set [OK] \n");
        //}

        //string SetCoreCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Core card Information Has been Set [OK] \n");
        //}


        //void GetCoreCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    SendMessageToSystemLogger(String.Format("\n Core card Information [{0}] \n", ConvertHex(i_Parsedframe.Data)));
        //}
        //void SetIdentityInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    SendMessageToSystemLogger(String.Format("\n Identity Information Has been Set [OK] \n"));
        //}
        //void GetIdentityInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    SendMessageToSystemLogger(String.Format("\n Identity Information [{0}] \n", ConvertHex(i_Parsedframe.Data)));
        //}
        //void GetSystemType(KratosProtocolFrame i_Parsedframe)
        //{

        //    int SystemType = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

        //    SendMessageToSystemLogger(String.Format("\n System type [{0}] \n", SystemType));
        //}

        //void IsSystemBusy(KratosProtocolFrame i_Parsedframe)
        //{
        //    //2 bytes Serial number:
        //    //2 bytes - Serial number, range: 0 – 65535
        //    int BusyStatus = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        //    //int SerialNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2) + i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        //    if (BusyStatus == 0)
        //    {
        //        SendMessageToSystemLogger( String.Format("\n Ready [OK] [{0}] \n", BusyStatus));
        //    }
        //    else
        //    {
        //        SendMessageToSystemLogger(String.Format("\n Busy  [{0}] \n", BusyStatus));
        //    }
        //}
        //void SetLogLevel(KratosProtocolFrame i_Parsedframe)
        //{
        //    //2 bytes Serial number:
        //    //2 bytes - Serial number, range: 0 – 65535

        //    //int SerialNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2) + i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

        //    SendMessageToSystemLogger( String.Format("\n Log Level has been set. \n"));
        //}
        private void GetSerialNumber(KratosProtocolFrame i_Parsedframe)
        {
            //2 bytes Serial number:
            //2 bytes - Serial number, range: 0 – 65535

            int SerialNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2) + i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

            textBox_SimulatorSN.Text = SerialNumber.ToString();
            // SendMessageToSystemLogger( String.Format("\n Serial Number : <<{0}>>\n", SerialNumber));
        }

        private string GetBytesFromData(string i_data, int i_ByteStartIndex, int i_NumOfBytes)
        {
            int StartIndex = i_ByteStartIndex * 2;
            int MaxIndex = (StartIndex + i_NumOfBytes * 2);
            if (i_data.Length < MaxIndex)
            {

                return string.Format("Out of range [{0}] - [{1}]", i_data.Length, MaxIndex);
            }
            else
            {
                return ReverseHexStringLittleBigEndian(i_data.Substring(StartIndex, i_NumOfBytes * 2));

            }

        }
        private void GetSystemStatus(KratosProtocolFrame i_Parsedframe)
        {
            if (int.TryParse(i_Parsedframe.DataLength, out int DataLength) == true)
            {

                textBox_StatusUUT1.Text = GetBytesFromData(i_Parsedframe.Data, 0, 2);
                textBox_StatusUUT2.Text = GetBytesFromData(i_Parsedframe.Data, 2, 2);
                textBox_StatusUUT3.Text = GetBytesFromData(i_Parsedframe.Data, 4, 2);
                textBox_StatusUUT4.Text = GetBytesFromData(i_Parsedframe.Data, 6, 2);
                textBox_StatusUUT5.Text = GetBytesFromData(i_Parsedframe.Data, 8, 2);
                textBox_StatusUUT6.Text = GetBytesFromData(i_Parsedframe.Data, 10, 2);
                textBox_StatusUUT7.Text = GetBytesFromData(i_Parsedframe.Data, 12, 2);
                textBox_StatusUUT8.Text = GetBytesFromData(i_Parsedframe.Data, 14, 2);
                textBox_StatusUUT9.Text = GetBytesFromData(i_Parsedframe.Data, 16, 2);
                textBox_StatusUUT10.Text = GetBytesFromData(i_Parsedframe.Data, 18, 2);
                textBox_StatusUUT11.Text = GetBytesFromData(i_Parsedframe.Data, 20, 2);
                textBox_StatusUUT12.Text = GetBytesFromData(i_Parsedframe.Data, 22, 2);
                textBox_StatusUUT13.Text = GetBytesFromData(i_Parsedframe.Data, 24, 2);
                textBox_StatusUUT14.Text = GetBytesFromData(i_Parsedframe.Data, 26, 2);
                textBox_StatusUUT15.Text = GetBytesFromData(i_Parsedframe.Data, 28, 2);
                textBox_StatusUUT16.Text = GetBytesFromData(i_Parsedframe.Data, 30, 2);
                textBox_StatusUUT17.Text = GetBytesFromData(i_Parsedframe.Data, 32, 2);
                textBox_StatusUUT18.Text = GetBytesFromData(i_Parsedframe.Data, 34, 2);
                textBox_StatusUUT19.Text = GetBytesFromData(i_Parsedframe.Data, 36, 2);
                textBox_StatusUUT20.Text = GetBytesFromData(i_Parsedframe.Data, 38, 2);
                textBox_StatusUUT21.Text = GetBytesFromData(i_Parsedframe.Data, 40, 2);
                textBox_StatusUUT22.Text = GetBytesFromData(i_Parsedframe.Data, 42, 2);
                textBox_StatusUUT23.Text = GetBytesFromData(i_Parsedframe.Data, 44, 2);
            }

            //  SendMessageToSystemLogger(ret);
        }

        private string GetBit(byte b, int bitNumber)
        {
            return (b & (1 << bitNumber)).ToString();
        }

        private void GetDiscreteStatusBusmode(KratosProtocolFrame i_Parsedframe)
        {
            if (int.TryParse(i_Parsedframe.DataLength, out int DataLength) == true)
            {
                // byte Data = byte.Parse(GetBytesFromData(i_Parsedframe.Data, 0, 2), System.Globalization.NumberStyles.HexNumber);

                textBox_StatusUUT27.Text = GetBytesFromData(i_Parsedframe.Data, 0, 1);
                textBox_StatusUUT28.Text = GetBytesFromData(i_Parsedframe.Data, 1, 1);
                textBox_StatusUUT29.Text = GetBytesFromData(i_Parsedframe.Data, 2, 1);
                textBox_StatusUUT30.Text = GetBytesFromData(i_Parsedframe.Data, 3, 1);
                textBox_StatusUUT31.Text = GetBytesFromData(i_Parsedframe.Data, 4, 1);
                textBox_StatusUUT32.Text = GetBytesFromData(i_Parsedframe.Data, 5, 1);
            }

            //   SendMessageToSystemLogger(ret);
        }

        private void GetSystemTableIndexes(KratosProtocolFrame i_Parsedframe)
        {
            if (int.TryParse(i_Parsedframe.DataLength, out int DataLength) == true)
            {
                // byte Data = byte.Parse(GetBytesFromData(i_Parsedframe.Data, 0, 2), System.Globalization.NumberStyles.HexNumber);

                textBox_StatusUUT24.Text = GetBytesFromData(i_Parsedframe.Data, 12, 2);
                textBox_StatusUUT25.Text = GetBytesFromData(i_Parsedframe.Data, 21, 1);
                textBox_StatusUUT26.Text = GetBytesFromData(i_Parsedframe.Data, 22, 1);

            }
        }

        private void ReadFromFlash(KratosProtocolFrame i_Parsedframe)
        {
            string ret = "";
            int.TryParse(i_Parsedframe.DataLength, out int DataLength);

            for (int i = 0; i < DataLength - 2; i = i + 2)
            {
                ret += "<<" + i_Parsedframe.Data.Substring(i, i + 2) + ">>";
            }

            //    SendMessageToSystemLogger(ret);
        }

        private void ACK_Received(KratosProtocolFrame i_Parsedframe)
        {
            string ret = string.Format("\n recieved OK, Opcode :[{0}] \n", i_Parsedframe.Opcode);
            //       SendMessageToSystemLogger(ret);
        }

        private void GetThermalSuperVisor(KratosProtocolFrame i_Parsedframe)
        {


            string ret = string.Format("\n recieved OK, Opcode :[{0}], Thermal <<{1}>> \n", i_Parsedframe.Opcode, i_Parsedframe.Data);
            //         SendMessageToSystemLogger(ret);
        }

        private void GetHardwareVertion(KratosProtocolFrame i_Parsedframe)
        {
            //    Unit major version – 	1 byte
            //Unit minor version – 	1 byte
            //Version day –		1 bytes
            //Version month –	1 bytes
            //Version year –		2 bytes

            int UnitMajorVersion = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            //    int UnitMinorVersion = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionDay = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionYear = int.Parse(i_Parsedframe.Data.Substring(8, 2) + i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            textBox_SimulatorHWVersion.Text = string.Format("\n {0},{1}/{2}/{3}\n  ",
                UnitMajorVersion, VersionDay, VersionMonth, VersionYear);
        }

        private void GetFirmwareVertion(KratosProtocolFrame i_Parsedframe)
        {
            //    Unit major version – 	1 byte
            //Unit minor version – 	1 byte
            //Version day –		1 bytes
            //Version month –	1 bytes
            //Version year –		2 bytes

            int UnitMajorVersion = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            //    int UnitMinorVersion = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionDay = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionYear = int.Parse(i_Parsedframe.Data.Substring(8, 2) + i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            textBox_SimulatorFWVersion.Text = (string.Format("\n {0},{1}/{2}/{3}\n  ",
               UnitMajorVersion, VersionDay, VersionMonth, VersionYear));
        }

        private void GetSimulatorStatus(KratosProtocolFrame i_Parsedframe)
        {
            textBox90.Text = i_Parsedframe.Data.Substring(0, 2);
            textBox91.Text = i_Parsedframe.Data.Substring(2, 2);
            textBox92.Text = i_Parsedframe.Data.Substring(4, 2);
            textBox93.Text = i_Parsedframe.Data.Substring(6, 2);
            textBox94.Text = i_Parsedframe.Data.Substring(8, 2);
            textBox95.Text = i_Parsedframe.Data.Substring(10, 2);
            //int Ready_count = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            //int Int_under_voltage_count = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            //int Int_over_voltage_count = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            //int Protection_count = int.Parse(i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            //int Protection_count = int.Parse(i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            //int Protection_count = int.Parse(i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            //       SendMessageToSystemLogger(String.Format("\n Simulator ID <<0x{0}>>\n ", i_Parsedframe.Data));

        }

        private void GetSimulatorID(KratosProtocolFrame i_Parsedframe)
        {
            textBox_SimulatorID.Text = i_Parsedframe.Data;
            //    SendMessageToSystemLogger(String.Format("\n Simulator ID <<0x{0}>>\n ", i_Parsedframe.Data));

        }

        private void GetSystemHardwareVersion(KratosProtocolFrame i_Parsedframe)
        {
            int UnitMajorVersion = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            //    int UnitMinorVersion = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionDay = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionYear = int.Parse(i_Parsedframe.Data.Substring(8, 2) + i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            textBox_SystemHWVersion.Text = (string.Format("\n {0},{1}/{2}/{3}\n  ",
               UnitMajorVersion, VersionDay, VersionMonth, VersionYear));
        }

        private void GetSystemFirmwareVersion(KratosProtocolFrame i_Parsedframe)
        {
            int UnitMajorVersion = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            //    int UnitMinorVersion = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionDay = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int VersionYear = int.Parse(i_Parsedframe.Data.Substring(8, 2) + i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            textBox_SystemFWVersion.Text = (string.Format("\n {0},{1}/{2}/{3}\n  ",
               UnitMajorVersion, VersionDay, VersionMonth, VersionYear));
        }



        private void GetSystemID(KratosProtocolFrame i_Parsedframe)
        {
            textBox_SystemID.Text = i_Parsedframe.Data;


        }

        private void GetSystemSN(KratosProtocolFrame i_Parsedframe)
        {
            textBox_SystemSN.Text = i_Parsedframe.Data;


        }

        private void GetSoftwareVertion(KratosProtocolFrame i_Parsedframe)
        {
            //    ICD major version – 	1 byte
            //ICD minor version – 	1 byte
            //Unit major version – 	1 byte
            //Unit minor version – 	1 byte
            //Version day –		1 bytes
            //Version month –	1 bytes
            //Version year –		2 bytes


            int ICDMajor = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int ICDMinor = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int UnitMajorNumber = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int UnitMinorNumber = int.Parse(i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            string VersionDateTime = ConvertHex(i_Parsedframe.Data.Substring(8));


            //        SendMessageToSystemLogger(String.Format("\n ICD major version [{0}]\n ICD minor version [{1}]\n Unit major version [{2}]\n Unit minor version [{3}]" +
            //"\n Version date time  [{4}]\n ",
            //ICDMajor, ICDMinor, UnitMajorNumber, UnitMinorNumber, VersionDateTime));
            //        //int VersionDay = int.Parse(i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            //        //int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(10, 2), System.Globalization.NumberStyles.HexNumber);
            //        //int VersionYear = int.Parse(i_Parsedframe.Data.Substring(14, 2) + i_Parsedframe.Data.Substring(12, 2), System.Globalization.NumberStyles.HexNumber);  //Gil: because it is little endian so I need to reverse the bytes
            //        //return String.Format("\n ICD major version [{0}]\n ICD minor version [{1}]\n Unit major version [{2}]\n Unit minor version [{3}]" +
            //        //    "\n Version day  [{4}]\n Version month [{5}]\n Version year [{6}]\n",
            //        //    ICDMajor, ICDMinor ,UnitMajorNumber, UnitMinorNumber, VersionDay, VersionMonth, VersionYear);
        }

        private void ParseSystemFrame(KratosProtocolFrame i_Parsedframe)
        {
            if (i_Parsedframe == null)
            {
                textBox_SystemStatus.Text = "frame received as null";
            }
            int intValue = int.Parse(i_Parsedframe.Preamble, System.Globalization.NumberStyles.HexNumber);
            if (intValue != 0x23)
            {
                UnHandaledPreample(i_Parsedframe);
            }
            else
            {
                //ret = "[ACK]  ";
                switch (i_Parsedframe.Opcode)
                {

                    case "00":
                        GetSystemID(i_Parsedframe);

                        break;

                    case "02":
                        GetSystemFirmwareVersion(i_Parsedframe);

                        break;

                    case "03":
                        GetSystemHardwareVersion(i_Parsedframe);

                        break;

                    case "04":
                        GetSystemSN(i_Parsedframe);

                        break;

                    case "11":
                        GetSystemStatus(i_Parsedframe);

                        break;

                    case "25":
                        GetDiscreteStatusBusmode(i_Parsedframe);

                        break;

                    case "26":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "27":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "33":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "35":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "36":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "37":
                        GetSystemTableIndexes(i_Parsedframe);

                        break;

                    case "70":
                        ReadFromFlash(i_Parsedframe);

                        break;

                    case "38":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "39":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "80":
                        GetSimulatorID(i_Parsedframe);

                        break;

                    case "81":
                        GetSoftwareVertion(i_Parsedframe);

                        break;

                    case "82":
                        GetFirmwareVertion(i_Parsedframe);

                        break;

                    case "83":
                        GetHardwareVertion(i_Parsedframe);

                        break;

                    case "85":
                        GetSerialNumber(i_Parsedframe);

                        break;


                    case "90":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "91":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "92":
                        GetSimulatorStatus(i_Parsedframe);

                        break;

                    case "93":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "94":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "95":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "96":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "97":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "98":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "99":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9A":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9B":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9C":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9D":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9E":
                        GetThermalSuperVisor(i_Parsedframe);

                        break;

                    case "9F":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "A0":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "A1":
                        ACK_Received(i_Parsedframe);

                        break;


                    default:
                        UnHandledOpcode(i_Parsedframe);
                        break;
                }

            }
        }

        private void SendMessageToSystemLogger(string i_msg)
        {

            SystemLogger.LogMessage(Color.Blue, Color.Azure, "", New_Line = false, Show_Time = true);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, "Rx:>", false, false);

            //if (i_msg.Contains("ACK") == true)
            //{
            //    SystemLogger.LogMessage(Color.DarkGreen, Color.White, i_msg, true, false);
            //}
            //else
            //{
            SystemLogger.LogMessage(Color.Blue, Color.LightGray, i_msg, true, false);
            //}

            GlobalSystemResultReceived += i_msg;
        }

        private void ParseKratosIncomeFrame(byte[] i_IncomeBuffer)
        {
            try
            {
                if (i_IncomeBuffer.Length == 0)
                {
                    return;
                }
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
                        textBox_RxClientData.Text = Regex.Replace(Result.Data, ".{2}", "$0 ");

                        textBox_RxClientDataLength.BackColor = Color.LightGreen;
                        textBox_RxClientDataLength.Text = Result.DataLength + " Bytes";

                        textBox_RxClientCheckSum.BackColor = Color.LightGreen;
                        textBox_RxClientCheckSum.Text = Result.CheckSum;


                        ParseSystemFrame(Result);

                        SendMessageToSystemLogger(Result.ToString());








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
                SystemLogger.LogMessage(Color.Red, Color.White, ex.ToString(), true, false);
            }
        }

        private string GlobalSystemResultReceived;

        // int ChartIndex = 0;
        //SSPA_Parser MiniAdaParser = new SSPA_Parser();
        private void ParseIncomeBuffer_TCPIP()
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

        private void TCPClientConnection()
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
                if (checkBox_ParseRxTCPBuffer.Checked == true)
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
                else
                {
                    try
                    {
                        TcpClient PClientSocket = ClientSocket;
                        if (TCPClientBuffer.Length > 0)
                        {

                            string str = System.Text.Encoding.Default.GetString(TCPClientBuffer);
                            richTextBox_ClientRxPrintText("[" + DateTime.Now.TimeOfDay.ToString().Substring(0, 11) + "] " + str + "\n \n");
                            TCPClientBuffer = new byte[0];
                            PClientSocket = ClientSocket;
                        }
                    }
                    catch (Exception ex)
                    {
                        SystemLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = false, Show_Time = true);
                    }



                }



            }

        }

        private void CheckIfSerialPortOpen()
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
        private int TimerClearModemStatus = 0;
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
                        List<string> dataSource = new List<string>
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

        private void PrintDictineryIDKeys()
        {
            textBox_IDKey.Invoke(new EventHandler(delegate
            {
                textBox_IDKey.Text = "Connection       |      Unit ID \n";
                textBox_IDKey.AppendText("------------------------------------- \n");
            }));

            foreach (KeyValuePair<string, string> pair in ConnectionToIDdictionary)
            {
                textBox_IDKey.Invoke(new EventHandler(delegate
                {
                    textBox_IDKey.AppendText(pair.Key + " | " + pair.Value.Replace(';', ' ') + " \n");
                }));
            }

        }

        private static int LastConNum = 0;
        private static int CloseSerialPortConter = 0;
        private bool CloseSerialPortTimer = false;
        private bool ComPortClosing = false;

        //List<byte> temp_serialBuff = new List<byte>();
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            // If the com port has been closed, do nothing
            if (!serialPort.IsOpen)
            {
                return;
            }

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

            if (!serialPort.IsOpen)
            {
                return;
            }

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

        private string ConvertByteArraytToString(byte[] i_Buffer)
        {
            string IncomingHexMessage = "";
            foreach (byte by in i_Buffer)
            {
                IncomingHexMessage += by.ToString("X2") + " ";

            }

            return IncomingHexMessage;
        }

        private enum SourceMessage
        {
            SMS,
            SerialPort,
            Server
        };

        private void ParseStatuPos(string IncomingString)
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

            bool IwatcherPrint = false;


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

        private void ParseSerialPortSMSString(string IncomingString)
        {

        }

        private void ParseSerialPortString(string IncomingString)
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

        private bool ParseSMSCommand(string IncomingString)
        {
            bool ret = false;
            bool IsCommandFound = true;
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

                    //ModemStatus mdmStat = new ModemStatus(ref CommandString);



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

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private void ParseSMSText(string i_Subscriber, string i_SMSText, Color i_ColorDisplay)
        {




        }

        private string UnitVersion;

        private void ParseUnitVersion(string IncomingString)
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

        private void ParseConfigCommand(string IncomingString)
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

        private BinaryReader m_BinaryReader;
        private readonly Dictionary<int, string> FOTAData = new Dictionary<int, string>();
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
            foreach (KeyValuePair<string, string> pair in IDToFOTA_Status)
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

        private void UpdateSerialPortHistory(string i_SendString)
        {
            bool Found = false;

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
                string LastCommand = CommandsHistoy[CommandsHistoy.Count - 1];

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

        private void UpdateSerialPortComboBox()
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
                string tempStr = textBox_SendSerialPort.Text.Replace(" ", "");

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


                string tempStr = textBox_SendSerialPort.Text.Replace("\\n", "\n");
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
                        byte CheckSum = CalcCheckSumbufferSize(buf);


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

        private bool ParseConfigString(string i_Config)
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

        private enum ConfigDataType
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

        private bool CheckSubscriberValid(string i_String, ConfigDataType i_DataType)
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

        private bool CheckAllTextboxConfig()
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

        private void CheckConfigTextboxValidData(TextBox i_TextBox, ConfigDataType i_ConfigDataType)
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

        private void Password_form_Load(object sender, EventArgs e)
        {

        }

        private string GenerateConfigCommand()
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
                byte CheckSum = CalcCheckSumbufferSize(buf);


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



        private void TextBox_GenerateConfigFile_Clear()
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

        private void UpdateAlarmCheckBoxes()
        {

        }

        private void CheckBox_config_Bit0_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void UpdateTextBox13()
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







        private void Button39_Click(object sender, EventArgs e)
        {
            //groupBox34.Enabled = false;
            foreach (object item in checkedListBox_PhoneBook.CheckedItems)
            {
                if (item != null)
                {
                    //    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)item);
                    //SendSMSToContact((PhoneBookContact)item, SMSText);
                }
            }
            //     AddCommandToCommands(richTextBox_TextSendSMS.Text);
            //    groupBox34.Enabled = true;
        }

        private void RemoveSelectedContact()
        {

        }

        private void Button_RemoveContact_Click(object sender, EventArgs e)
        {
            RemoveSelectedContact();
        }

        private void Button_ExportToXML_Click(object sender, EventArgs e)
        {






        }

        private void Button_ImportToXML_Click(object sender, EventArgs e)
        {


        }

        private void AddCommandToCommands(string i_SMSText)
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


        private string ReturnSMSEncryiepted(string i_SMSText)
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

        }

        private void Button33_Click_2(object sender, EventArgs e)
        {

        }

        private void Form_Load(object sender, EventArgs e)
        {

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

        private void SortSMSCommands()
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

        private void SMSCommandForm_Load(object sender, EventArgs e)
        {

        }

        ///
        private void RemoveSelectedCommand()
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
                    foreach (object item in listBox_SMSCommands.Items)
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

        private void SetSpeedThreeSpeedLimit()
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

        private string OpcodeToCompare = "";
        private int SendOneTimeFlag = 0;

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

        private void ScanComports()
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

        private readonly Stopwatch stopwatch = new Stopwatch();

        private void TextBox_StopWatch_TextChanged(object sender, EventArgs e)
        {

        }

        private int TimerLogNumber = 0;
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

        private bool IsTimerRunning = false;
        private int TimerMemory = 0;
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
            foreach (Series ser in chart1.Series)
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


            Invoke((MethodInvoker)delegate ()
            {
                textBox_graph_XY.Text = "";
            });

            Series[] Serias_Graphs = new Series[chart1.Series.Count];
            chart1.Series.CopyTo(Serias_Graphs, 0);
            foreach (Series ser in Serias_Graphs)
            {
                string fileName = ser.Name;
                string Location = AppDomain.CurrentDomain.BaseDirectory + fileName + DateTime.Now.ToString("MM_DD_HH_mm_ss") + ".csv";
                using (StreamWriter writetext = new StreamWriter(@Location))
                {

                    foreach (DataPoint point_ in ser.Points)
                    {
                        writetext.WriteLine(point_.XValue + "," + point_.YValues[0]);
                    }

                    Invoke((MethodInvoker)delegate ()
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

        private bool IsPauseGraphs = false;
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

        private void CloseClentConnection()
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
            {
                hex.AppendFormat("{0:x2} ", b);
            }

            return hex.ToString();
        }

        private byte[] TCPClientBuffer = new byte[0];

        private void ReceiveData()
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

        private bool m_Exit = false;
        private TcpClient ClientSocket;
        private Thread ReceiveThread;
        private void Button_ClientConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //create a new client socket ...
                m_Exit = false;
                //m_socWorker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                string szIPSelected = textBox_ClientIP.Text;
                string szPort = textBox_ClientPort.Text;
                int alPort = System.Convert.ToInt16(szPort, 10);

                ClientSocket = new TcpClient();
                IAsyncResult result = ClientSocket.BeginConnect(textBox_ClientIP.Text, alPort, null, null);

                bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                if (!success)
                {
                    richTextBox_ClientRxPrintText(string.Format("Failed to connect to [{0}] [{1}]\n", szIPSelected, szPort));
                    return;
                }
                // we have connected
                ClientSocket.EndConnect(result);


                //System.Net.IPAddress	remoteIPAddress	 = System.Net.IPAddress.Parse(szIPSelected);
                //System.Net.IPEndPoint	remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);
                //m_socWorker.Connect(remoteEndPoint);

                if (ClientSocket.Connected)
                {
                    ReceiveThread = new Thread(new ThreadStart(ReceiveData));
                    ReceiveThread.Start();
                }
            }
            catch (System.Net.Sockets.SocketException se)
            {
                richTextBox_ClientRx.AppendText(se.Message + "\n");
            }
        }

        private int ClentSendData = 0;
        private void Button3_Click_4(object sender, EventArgs e)
        {
            try
            {
                string str = richTextBox_ClientTx.Text;
                Stream stm = ClientSocket.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);

                //byte[] sspData = SSP_Protocol.SSP_Protocol.SSPPacket_Encoder(SSP_Protocol.eMessegeType.TRACE, ba);

                // Console.WriteLine("Sending...");

                stm.Write(ba, 0, ba.Length);

                //WaitforBufferFull = 1;

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

        private void SerialTerminalPrintHelp()
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
                        List<string> Strlist = new List<string>();
                        foreach (string str in CommandsHistoy)
                        {
                            if (str.StartsWith(textBox_SendSerialPort.Text))
                            {
                                Strlist.Add(str);
                            }
                        }

                        if (Strlist.Count > 1)
                        {
                            SerialPortLogger.LogMessage(Color.Black, Color.Yellow, "Total sub commands: " + Strlist.Count.ToString() + " ", New_Line = true, Show_Time = true);
                            foreach (string str in Strlist)
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

        private int ChartUpdateTime = 100;
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

        private void ClearRxTextBox()
        {
            textBox_RxClientPreamble.BackColor = default;
            textBox_RxClientPreamble.Text = "";

            textBox_RxClientOpcode.BackColor = default;
            textBox_RxClientOpcode.Text = "";

            textBox_RxClientData.BackColor = default;
            textBox_RxClientData.Text = "";

        }

        private void ClearallTextBoxsTCPClient()
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
                    KratosProtocolFrame KratosFrame = new KratosProtocolFrame
                    {
                        Preamble = Regex.Replace(textBox_Preamble.Text, @"\s+", ""),
                        Opcode = Regex.Replace(textBox_Opcode.Text, @"\s+", ""),
                        Data = Regex.Replace(textBox_data.Text, @"\s+", "")
                    };
                    byte[] Result = Kratos_Protocol.EncodeKratusProtocol_Standard(KratosFrame);

                    KratosProtocolFrame SentFrame = Kratos_Protocol.DecodeKratusProtocol_Standard(Result);
                    //textBox_AllDataSent.Text = String.Format("Preamble: [{0}] Opcode: [{1}] Data : [{2}] Data length: [{3}] CheckSum: [{4}]",Ret.Preamble,Ret.Opcode,Ret.Data,Ret.DataLength,Ret.CheckSum);
                    textBox_SentPreamble.Text = SentFrame.Preamble;
                    textBox_SentOpcode.Text = SentFrame.Opcode;
                    textBox_SentData.Text = Regex.Replace(SentFrame.Data, ".{2}", "$0 ");
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

        private void SendThrouthSerialPort()
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
                    SystemLogger.LogMessage(Color.Purple, Color.LightGray, SentFrameGlobal.ToString(), true, false);
                }
                else
                {
                    SystemLogger.LogMessage(Color.Red, Color.White, "Connection Problem or bad data", true, true);

                }
            }
        }

        private void SendThrouthTCPIP()
        {
            button_Send_Click(null, null);

            if (button_SendProtocolTCPIP.BackColor == Color.LightGreen)
            {
                SystemLogger.LogMessage(Color.Purple, Color.LightYellow, "", New_Line = false, Show_Time = true);
                SystemLogger.LogMessage(Color.Purple, Color.LightYellow, "Tx:>", false, false);
                string str = string.Format("Preamble [{0}],Opcode [{1}],Data [{2}] ", textBox_Preamble.Text, textBox_Opcode.Text, textBox_data.Text);
                SystemLogger.LogMessage(Color.Purple, Color.LightYellow, str, true, false);
            }
            else
            {
                SystemLogger.LogMessage(Color.Orange, Color.White, "Connection Problem or bad data", true, true);

            }
        }

        private void SendDataToSystem()
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"Help:
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"Description:   Set the system state: 
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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



        private void button71_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "70 00";
            //textBox_data.Text = textBox_ReadFPGARegister.Text;

            //SendDataToSystem();
        }

        private void richTextBox_ClientRxPrintText(string i_string)
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
                string szIPSelected = textBox_ClientIP.Text;

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


        private void button72_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"4.2.2.12	Store data in Flash 
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



        private void button73_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"4.2.2.13	Load data from Flash by address 
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



        private void button78_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"Help:
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            uint length = 1000;
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
            Series series = new Series("Freq");
            Series series2 = new Series("Time");
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
            uint length = 1000; uint zeroPadding = 9000; // NOTE: Zero Padding
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

            Series series = new Series("Freq 2");
            Series series2 = new Series("Time 2");
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
            if (long.TryParse(textBox_MinXAxis.Text, out long x))
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
            if (long.TryParse(textBox_MaxXAxis.Text, out long x))
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

        private int PlotGraphTimer = 0;
        //private void button96_Click(object sender, EventArgs e)
        //{
        //    PlotGraphTimer = 60;
        //    new Thread(() =>
        //    {
        //        CheckForMiniAdaDataFFT(MiniAdaParser);

        //    }).Start();

        //}

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

        //private void button98_Click(object sender, EventArgs e)
        //{
        //    PlotGraphTimer = 120;
        //    new Thread(() =>
        //    {


        //        CheckForMiniAdaDataDFT(MiniAdaParser);

        //    }).Start();
        //}

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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button65_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button68_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button87_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button88_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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

        private void WriteFileToFlash(string i_FilePathName, string i_AD936X_ADDR)
        {
            string DataToSend = "";
            int DataLength = 0;
            byte CheckSumCalc = 0;
            //Gil: Catalina 1
            string[] lines = File.ReadAllLines(i_FilePathName);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
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
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0)
            {
                return;
            }
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
        private string ReverseHexStringLittleBigEndian(string i_HexString)
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

        private readonly string CATALINA_1_ADDRESS = "00500000";
        private readonly string CATALINA_2_ADDRESS = "00600000";
        private readonly string CATALINA_3_ADDRESS = "00700000";
        private readonly string CATALINA_4_ADDRESS = "00800000";
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
                SystemLogger.LogMessage(Color.Red, Color.White, ex.ToString(), true, false);
            }
        }

        private void textBox_FilesToWriteForTheCatalinas2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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

            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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

        private byte[] CreateMiniAdaFlashHeader(byte i_ver_major, byte i_ver_minor, DateTime i_ver_date, int i_block_size, byte i_checksum)
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
            FlashHeader[10] = i_checksum; // Check Sum is the same as the system type
            FlashHeader[11] = 0;

            return FlashHeader;
        }

        private readonly string SYSTEM_TYPE_ADDRESS = "00000000";
        private void button73_Click_1(object sender, EventArgs e)
        {
            string DataToSend = "";
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

            byte[] FlashHeader = CreateMiniAdaFlashHeader(0, 0, DateTime.Now, DataLength, SystemType);

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

        private readonly string SYNTHESIZER_L1_ADDRESS = "00300000";
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

        private readonly string SYNTHESIZER_L2_ADDRESS = "00400000";
        private void button101_Click(object sender, EventArgs e)
        {
            string DataToSend = "";
            int DataLength = 0;
            byte CheckSumCalc = 0;

            string[] lines = richTextBox_SyntisazerL2.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
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
            string NumOfBytesstr = ConvertByteArraytToString(intBytes);
            //    textBox_StoreDatainFlash.Text = SYNTHESIZER_L2_ADDRESS /* + NumOfBytesstr */+ TotalframeDataToSend;
            //       temp = StringToByteArray(Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", ""));
            //button_StoreDatainFlash.PerformClick();
        }

        private void button100_Click_2(object sender, EventArgs e)
        {
            button_WriteAllToFlash.BackColor = Color.Yellow;
            progressBar_WriteToFlash.Value = 0;
            SystemLogger.LogMessage(Color.Orange, Color.White, string.Format("Writing System Type to [{0}]", SYSTEM_TYPE_ADDRESS), true, true);
            button_WriteSystemType.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 20;
            SystemLogger.LogMessage(Color.Orange, Color.White, string.Format("Synthesizer L1 [{0}]", SYNTHESIZER_L1_ADDRESS), true, true);
            button_SynthL1.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 40;
            SystemLogger.LogMessage(Color.Orange, Color.White, string.Format("Synthesizer L2 [{0}]", SYNTHESIZER_L2_ADDRESS), true, true);
            button_SynthL2.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 60;
            SystemLogger.LogMessage(Color.Orange, Color.White, string.Format("Catalina 1-4 [{0}] [{1}] [{2}] [{3}]", CATALINA_1_ADDRESS, CATALINA_2_ADDRESS, CATALINA_3_ADDRESS, CATALINA_4_ADDRESS), true, true);
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"

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
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
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

        private KratosProtocolFrame SentFrameGlobal = null;
        private void button_SendProtocolSerialPort_Click(object sender, EventArgs e)
        {
            SentFrameGlobal = null;
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


                KratosProtocolFrame KratosFrame = new KratosProtocolFrame
                {
                    Preamble = Regex.Replace(textBox_Preamble.Text, @"\s+", ""),
                    Opcode = Regex.Replace(textBox_Opcode.Text, @"\s+", ""),
                    Data = Regex.Replace(textBox_data.Text, @"\s+", "")
                };
                byte[] Result = Kratos_Protocol.EncodeKratusProtocol_Standard(KratosFrame);

                KratosProtocolFrame SentFrame = Kratos_Protocol.DecodeKratusProtocol_Standard(Result);

                SentFrameGlobal = SentFrame;
                //textBox_AllDataSent.Text = String.Format("Preamble: [{0}] Opcode: [{1}] Data : [{2}] Data length: [{3}] CheckSum: [{4}]",Ret.Preamble,Ret.Opcode,Ret.Data,Ret.DataLength,Ret.CheckSum);
                textBox_SentPreamble.Text = SentFrame.Preamble;
                textBox_SentOpcode.Text = SentFrame.Opcode;
                textBox_SentData.Text = textBox_SentData.Text = Regex.Replace(SentFrame.Data, ".{2}", "$0 ");
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
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void textBox57_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox59_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private string[] GetDataStringFromTextbox()
        {
            return richTextBox_SSPA.Text.Split(new string[] { "<<", ">>" }, StringSplitOptions.RemoveEmptyEntries);
        }
        private async void button70_Click_1(object sender, EventArgs e)
        {
            GlobalSystemResultReceived = "";

            button62_Click(null, null);
            await Task.Delay(500);
            button61_Click(null, null);
            await Task.Delay(500);
            button59_Click(null, null);
            await Task.Delay(500);
            button66_Click(null, null);
            await Task.Delay(500);





        }







        private async void button31_Click_1(object sender, EventArgs e)
        {
            try
            {
                // GlobalSystemResultReceived = "";



                button108_Click(null, null);
                await Task.Delay(500);
                button48_Click_2(null, null);
                await Task.Delay(500);
                button46_Click(null, null);
                await Task.Delay(500);
                button45_Click(null, null);
                await Task.Delay(500);


                //String[] TextDataRecieved = GlobalSystemResultReceived.Split(new string[] { "<<", ">>" }, StringSplitOptions.None);



                //textBox_SimulatorID.Text = TextDataRecieved[1];
                //textBox_SimulatorSN.Text = TextDataRecieved[3];
                //textBox_SimulatorHWVersion.Text = TextDataRecieved[5];
                //textBox_SimulatorFWVersion.Text = TextDataRecieved[7];
            }
            catch (Exception ex)
            {
                textBox_SystemStatus.BackColor = Color.DarkOrange;
                textBox_SystemStatus.Text = ex.Message;
                return;
            }
        }

        private void ClearVersions()
        {
            textBox_SimulatorHWVersion.Text = "";
            textBox_SimulatorFWVersion.Text = "";
            textBox_SimulatorSN.Text = "";
            textBox_SimulatorID.Text = "";
            textBox_SystemHWVersion.Text = "";
            textBox_SystemFWVersion.Text = "";
        }

        private void button75_Click_1(object sender, EventArgs e)
        {
            foreach (Control ctr in groupBox1.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }



        }

        private void button32_Click_1(object sender, EventArgs e)
        {

            string hexValue = "";
            if (int.TryParse(textBox_RFWidth.Text, out int temp))
            {
                temp *= 10;
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            if (int.TryParse(textBox_RFPeriod.Text, out temp))
            {
                temp *= 10;
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            if (int.TryParse(textBox_RFDelay.Text, out temp))
            {
                temp *= 10;
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            textBox_RFGenParms.Text = hexValue;

            button110_Click(null, null);

        }

        private void button42_Click_2(object sender, EventArgs e)
        {

            string hexValue = "";
            if (int.TryParse(textBox_PulseWidth.Text, out int temp))
            {
                temp *= 10;
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            if (int.TryParse(textBox_PulsePeriod.Text, out temp))
            {
                temp *= 10;
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            if (int.TryParse(textBox_PulseDelay.Text, out temp))
            {
                temp *= 10;
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            textBox_TxInhibit.Text = hexValue;

            button47_Click(null, null);
        }

        private string LittleBigEndian_Change(string i_HexNumber)
        {
            byte[] bytes = StringToByteArray(i_HexNumber);
            bytes = bytes.Reverse().ToArray();
            string retval = ConvertByteArraytToString(bytes);

            return retval;
        }

        private void button44_Click(object sender, EventArgs e)
        {

            string hexValue = "";
            if (int.TryParse(textBox_PulseWidth2.Text, out int temp))
            {
                temp *= 10;
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            if (int.TryParse(textBox_PulsePeriod2.Text, out temp))
            {
                temp *= 10;
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            if (int.TryParse(textBox_PulseDelay2.Text, out temp))
            {
                temp *= 10;
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
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
            button63_Click(null, null);
            await Task.Delay(500);
            string[] TextDataRecieved = GlobalSystemResultReceived.Split(new string[] { "<<", ">>" }, StringSplitOptions.RemoveEmptyEntries);

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

        private async void SetPSUValues()
        {

            string hexValue = "";
            if (int.TryParse(textBox24.Text, out int temp))
            {
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            if (int.TryParse(textBox25.Text, out temp))
            {
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            if (int.TryParse(textBox26.Text, out temp))
            {
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            if (int.TryParse(textBox27.Text, out temp))
            {
                hexValue += LittleBigEndian_Change(temp.ToString("X4"));
            }

            textBox_SetPSUOutput.Text = hexValue;
            button69_Click(null, null);
            //textBox24.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            await Task.Delay(500);
            button_GetStatus_Click(null, null);
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
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");

            if (IsDigitsOnly(WithoutSpaces) == true)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private async void textBox31_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string hexValue = "";
                if (int.TryParse(textBox31.Text, out int temp))
                {
                    hexValue += temp.ToString("X4");
                }

                textBox_SetVVAAtt.Text = hexValue;
                button88_Click(null, null);

                await Task.Delay(500);
                button_GetStatus_Click(null, null);
            }
        }

        private async void SetDCAValues()
        {

            string hexValue = "";
            if (int.TryParse(textBox29.Text, out int temp))
            {
                hexValue += temp.ToString("X4");
            }

            if (int.TryParse(textBox30.Text, out temp))
            {
                hexValue += temp.ToString("X4");
            }

            textBox_SetDCAWithBusMode.Text = hexValue;
            button87_Click(null, null);

            await Task.Delay(500);
            button_GetStatus_Click(null, null);
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
                SetDCAValues();
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
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");


            if (IsDigitsOnly(WithoutSpaces) == true)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox84_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string hexValue = "";
                if (int.TryParse(textBox84.Text, out int temp))
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

                string hexValue = "";
                if (int.TryParse(textBox83.Text, out int temp))
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

                string hexValue = "";
                if (int.TryParse(textBox82.Text, out int temp))
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

                string hexValue = "";
                if (int.TryParse(textBox_CALSAR.Text, out int temp))
                {
                    hexValue += temp.ToString("X2");
                }

                textBox_SimulatorDiscreteCALSARcontrol.Text = hexValue;
                button_SimulatorDiscreteCALSARcontrol_Click(null, null);
            }
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");

            if (IsDigitsOnly(WithoutSpaces) == true)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void groupBox46_Enter(object sender, EventArgs e)
        {

        }

        private bool CheckPeriodAndWidth(int i_Period, int i_Width)
        {
            if (i_Period >= i_Width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void textBox_RFPeriod_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_RFPeriod.Text, out int Period) && int.TryParse(textBox_RFWidth.Text, out int Width))
            {
                if (CheckPeriodAndWidth(Period, Width) == true)
                {
                    textBox_RFPeriod.BackColor = Color.LightGreen;
                    textBox_RFWidth.BackColor = Color.LightGreen;
                }
                else
                {
                    textBox_RFPeriod.BackColor = Color.Red;
                    textBox_RFWidth.BackColor = Color.Red;
                }
            }
            else
            {
                textBox_RFPeriod.BackColor = Color.Red;
                textBox_RFWidth.BackColor = Color.Red;
            }
        }

        private void textBox_RFWidth_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_RFPeriod.Text, out int Period) && int.TryParse(textBox_RFWidth.Text, out int Width))
            {
                if (CheckPeriodAndWidth(Period, Width) == true)
                {
                    textBox_RFPeriod.BackColor = Color.LightGreen;
                    textBox_RFWidth.BackColor = Color.LightGreen;
                }
                else
                {
                    textBox_RFPeriod.BackColor = Color.Red;
                    textBox_RFWidth.BackColor = Color.Red;
                }
            }
            else
            {
                textBox_RFPeriod.BackColor = Color.Red;
                textBox_RFWidth.BackColor = Color.Red;
            }
        }

        private void textBox_PulseWidth_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_PulsePeriod.Text, out int Period) && int.TryParse(textBox_PulseWidth.Text, out int Width))
            {
                if (CheckPeriodAndWidth(Period, Width) == true)
                {
                    textBox_PulsePeriod.BackColor = Color.LightGreen;
                    textBox_PulseWidth.BackColor = Color.LightGreen;
                }
                else
                {
                    textBox_PulsePeriod.BackColor = Color.Red;
                    textBox_PulseWidth.BackColor = Color.Red;
                }
            }
            else
            {
                textBox_PulsePeriod.BackColor = Color.Red;
                textBox_PulseWidth.BackColor = Color.Red;
            }
        }

        private void textBox_PulsePeriod_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_PulsePeriod.Text, out int Period) && int.TryParse(textBox_PulseWidth.Text, out int Width))
            {
                if (CheckPeriodAndWidth(Period, Width) == true)
                {
                    textBox_PulsePeriod.BackColor = Color.LightGreen;
                    textBox_PulseWidth.BackColor = Color.LightGreen;
                }
                else
                {
                    textBox_PulsePeriod.BackColor = Color.Red;
                    textBox_PulseWidth.BackColor = Color.Red;
                }
            }
            else
            {
                textBox_PulsePeriod.BackColor = Color.Red;
                textBox_PulseWidth.BackColor = Color.Red;
            }
        }

        private void textBox_PulseWidth2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_PulsePeriod2.Text, out int Period) && int.TryParse(textBox_PulseWidth2.Text, out int Width))
            {
                if (CheckPeriodAndWidth(Period, Width) == true)
                {
                    textBox_PulsePeriod2.BackColor = Color.LightGreen;
                    textBox_PulseWidth2.BackColor = Color.LightGreen;
                }
                else
                {
                    textBox_PulsePeriod2.BackColor = Color.Red;
                    textBox_PulseWidth2.BackColor = Color.Red;
                }
            }
            else
            {
                textBox_PulsePeriod2.BackColor = Color.Red;
                textBox_PulseWidth2.BackColor = Color.Red;
            }
        }

        private void textBox_PulsePeriod2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_PulsePeriod2.Text, out int Period) && int.TryParse(textBox_PulseWidth2.Text, out int Width))
            {
                if (CheckPeriodAndWidth(Period, Width) == true)
                {
                    textBox_PulsePeriod2.BackColor = Color.LightGreen;
                    textBox_PulseWidth2.BackColor = Color.LightGreen;
                }
                else
                {
                    textBox_PulsePeriod2.BackColor = Color.Red;
                    textBox_PulseWidth2.BackColor = Color.Red;
                }
            }
            else
            {
                textBox_PulsePeriod2.BackColor = Color.Red;
                textBox_PulseWidth2.BackColor = Color.Red;
            }
        }

        private void button74_Click_1(object sender, EventArgs e)
        {
            foreach (Control ctr in groupBox47.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                    ctr.BackColor = default;
                }
            }

            foreach (Control ctr in groupBox39.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                    ctr.BackColor = default;
                }
            }


        }

        private void Ctr_TextChanged(object sender, EventArgs e)
        {
            textBox_StatusUUT1_TextChanged(sender, e);
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");

            if (IsDigitsOnly(WithoutSpaces) == true)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");

            if (IsDigitsOnly(WithoutSpaces) == true)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");

            if (IsDigitsOnly(WithoutSpaces) == true)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");

            if (IsDigitsOnly(WithoutSpaces) == true)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void checkBox_SendEveryOneSecond_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_SendSerialPortPeriod_TextChanged(object sender, EventArgs e)
        {
            if (IsDigitsOnly(textBox_SendSerialPortPeriod.Text) == true)
            {
                textBox_SendSerialPortPeriod.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SendSerialPortPeriod.BackColor = Color.Red;
            }
        }

        private void textBox1_TextChanged_4(object sender, EventArgs e)
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

        private void button_SimulatorDiscreteCALSARcontrol_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "A0";
            textBox_data.Text = textBox_SimulatorDiscreteCALSARcontrol.Text;

            SendDataToSystem();
        }

        private void textBox_CALSAR_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (textBox_CALSAR.BackColor == Color.LightGreen)
                {
                    string hexValue = "";
                    if (int.TryParse(textBox_CALSAR.Text, out int temp))
                    {
                        hexValue += temp.ToString("X2");
                    }

                    textBox_SimulatorDiscreteCALSARcontrol.Text = hexValue;
                    button_SimulatorDiscreteCALSARcontrol_Click(null, null);
                }


            }
        }

        private void textBox_CALSAR_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_CALSAR.Text, out int temp))
            {
                if (temp >= 0 && temp <= 3)
                {
                    textBox_CALSAR.BackColor = Color.LightGreen;

                }
                else
                {
                    textBox_CALSAR.BackColor = Color.Red;

                }
            }
            else
            {
                textBox_CALSAR.BackColor = Color.Red;
            }
        }

        private void checkBox_DebugMode_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Checkbx = (CheckBox)sender;
            if (Checkbx.Checked == true)
            {
                textBox_SetSystemMode.Text = "01";

                Checkbx.BackColor = Color.LightGreen;
            }
            else
            {
                textBox_SetSystemMode.Text = "00";
                Checkbx.BackColor = default;
            }

            button_SetSystemMode_Click(null, null);
        }

        private void textBox84_TextChanged(object sender, EventArgs e)
        {

        }

        private void SetTextBoxTextChangedColor(TextBox i_textbox)
        {

            if (i_textbox.BackColor == Color.White)
            {

                i_textbox.BackColor = default;

            }
            else
            {

                i_textbox.BackColor = Color.White;
            }
        }

        private void textBox_StatusUUT1_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);




        }

        private void textBox_StatusUUT2_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT3_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT4_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT5_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT6_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT7_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT18_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT19_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT29_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT17_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT8_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT9_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT10_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT11_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT23_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT22_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT21_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT20_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT16_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT15_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT14_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT13_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT12_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT26_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT25_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT24_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT32_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT31_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT30_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT28_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT27_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private async void button_GetStatus_Click(object sender, EventArgs e)
        {
            GlobalSystemResultReceived = "";
            button67_Click(null, null);
            await Task.Delay(500);
            button68_Click(null, null);
            await Task.Delay(500);
            button50_Click_1(null, null);
            await Task.Delay(500);
            button63_Click(null, null);
            await Task.Delay(500);
            string[] TextDataRecieved = GlobalSystemResultReceived.Split(new string[] { "<<", ">>" }, StringSplitOptions.RemoveEmptyEntries);

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

        private void textBox95_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void button_SetSystemMode_Click(object sender, EventArgs e)
        {
            textBox_Preamble.Text = PREAMBLE;
            textBox_Opcode.Text = "35";
            textBox_data.Text = textBox_SetSystemMode.Text;

            SendDataToSystem();
        }

        private void textBox_SystemMode_TextChanged(object sender, EventArgs e)
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

        private void button_SystemMode_Click(object sender, EventArgs e)
        {
            if (textBox_SystemMode.BackColor == Color.LightGreen)
            {
                textBox_SetSystemMode.Text = textBox_SystemMode.Text;

                button_SetSystemMode_Click(null, null);
            }
        }

        private void button57_Click_1(object sender, EventArgs e)
        {
            foreach (Control ctr in groupBox44.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
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

        private void ResetTimer()
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



        //private void button57_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void button71_Click(object sender, EventArgs e)
        //{

        //}
    }
}
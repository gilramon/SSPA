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

namespace Monitor
{
    public partial class MainForm 
    {







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



                    //UpdateDefaultsContacts();

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

                        //UpdateDefaultsContacts();

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
            catch (Exception ex)
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

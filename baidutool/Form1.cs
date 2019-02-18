
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Threading;

namespace baidutool
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        ArrayList arrText = new ArrayList();
        List<String> keyList = new List<String>();
        int Total = 0;
        int i, k = 0;
        string currKey = null;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtKey;
        private const string TitleInfo = "程序制作：iCC";
        private System.Windows.Forms.ListBox listBox1;
        private string strUrl = "https://www.baidu.com/s?";
        public Form1()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        //定义结构体代理信息
        public struct Struct_INTERNET_PROXY_INFO
        {
            public int dwAccessType;
            public IntPtr proxy;
            public IntPtr proxyBypass;
        };

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        private bool RefreshIESettings(string strProxy)
        {
            const int INTERNET_OPTION_PROXY = 38;
            const int INTERNET_OPEN_TYPE_PROXY = 3;

            Struct_INTERNET_PROXY_INFO struct_IPI;

            // Filling in structure 
            struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
            struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy);
            struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local");

            // Allocating memory 
            IntPtr intptrStruct = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI));

            // Converting structure to IntPtr 
            Marshal.StructureToPtr(struct_IPI, intptrStruct, true);

            bool iReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, Marshal.SizeOf(struct_IPI));
            return iReturn;
        }
        private void StartShua1(string item)
        {
            toolStripStatusLabel1.Text = "关键字：" + item + "，正在使用代理IP：" + arrText[k].ToString() + "访问网站";
            string url = strUrl + "wd=" + System.Web.HttpUtility.HtmlEncode(item);
            System.Object nullObject = 0;
            string strTemp = String.Empty;
            System.Object nullObjStr = strTemp;
            axWebBrowser1.Navigate(url, ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr);
        }

        private void StartShua(List<string> list)
        {
            int keyB = 0, keyE = 0;
            string keyBStr = this.txtKeyB.Text;
            string keyEStr = this.txtKeyE.Text;
            int.TryParse(keyBStr, out keyB);
            int.TryParse(keyEStr, out keyE);
            int keyI = new Random().Next(keyB, keyE);
            keyI = keyI * 1000;
            if (arrText.Count > 0 && list.Count > 0)
            {
                this.listBox1.SetSelected(k, true);
                if (RefreshIESettings(arrText[k].ToString()))
                {
                    foreach (var item in list)
                    {
                        currKey = item;
                        TaskTimer taskTime = new TaskTimer();
                        taskTime.Interval = keyI * 1000;
                        taskTime.Param = item;
                        taskTime.Enabled = true;
                        taskTime.Start();
                    }
                    k += 1;
                    if (k >= i) k = 0;
                }
            }
            else
            {
                MessageBox.Show("请获取代理地址或导入代理地址后操作！");
            }
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            arrText.Clear();
            listBox1.Items.Clear();
            i = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strPath, strLine = "";
                strPath = openFileDialog1.FileName.ToString();
                StreamReader sr = new StreamReader(strPath);
                while (strLine != null)
                {
                    strLine = sr.ReadLine();
                    if (strLine != null)
                    {
                        i += 1;
                        arrText.Add(strLine);
                        listBox1.Items.Add(strLine);
                    }
                }
                sr.Close();
            }
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            Total = listBox1.Items.Count;
            if (button2.Text == "开始刷")
            {
                if (i == 0 && Total == 0)
                {
                    MessageBox.Show("请获取代理地址或导入代理地址后操作！");
                    return;
                }
                if (keyList.Count < 1)
                    getKeyList();
                StartShua(keyList);
                button2.Text = "停止刷";

                string roundBStr = this.txtRoundB.Text;
                string roundEStr = this.txtRoundE.Text;
                int roundB = 0, roundE = 0;
                int.TryParse(roundBStr, out roundB);
                int.TryParse(roundEStr, out roundE);
                int roundI = new Random().Next(roundB, roundE);
                timer1.Interval = roundI * 1000;
                timer1.Enabled = true;
                timer1.Start();
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                keyList.Clear();
                button2.Text = "开始刷";
                button1.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            arrText.Clear();
            i = 0;
            listBox1.Items.Clear();
            #region q

            for (int k = 1; k <= 8; k++)
            {
                string Url = "https://www.xicidaili.com/nn/" + k;
                try
                {
                    string strHtml = Utils.GetHtml(Url);
                    NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(strHtml);
                    NSoup.Select.Elements tableEle = doc.GetElementsByTag("table");
                    foreach (var tableItem in tableEle)
                    {
                        if (tableItem.Id == "ip_list")
                        {
                            NSoup.Select.Elements trEle = tableItem.GetElementsByTag("tr");
                            foreach (var trItem in trEle)
                            {
                                NSoup.Select.Elements tdEle = trItem.GetElementsByTag("td");
                                if (tdEle.Count > 3)
                                {
                                    string ip = tdEle[1].Text();
                                    int port = 0;
                                    string portStr = tdEle[2].Text();
                                    int.TryParse(portStr, out port);
                                    if (Utils.VerIP(ip, port))
                                    {
                                        arrText.Add(ip + ":" + port);
                                        i += 1;
                                        listBox1.Items.Add(ip + ":" + port);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, TitleInfo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            #endregion
        }

        private void keyImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strPath, strLine = "";
                strPath = openFileDialog1.FileName.ToString();
                StreamReader sr = new StreamReader(strPath);
                while (strLine != null)
                {
                    strLine = sr.ReadLine();
                    if (strLine != null)
                    {
                        txtKey.AppendText(strLine);
                    }
                }
                sr.Close();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.txtKey.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(arrText.Count < 1)
            {
                MessageBox.Show("请获取代理地址或导入代理地址后操作！");
                return;
            }
            i = 0;
            ArrayList arrayList = new ArrayList();
            foreach (var item in arrText)
            {
                string[] data = item.ToString().Split(':');
                string ip = data[0];
                string portStr = data[1];
                int port = 0;
                int.TryParse(portStr, out port);
                if (Utils.VerIP(ip, port))
                {
                    i++;
                    arrayList.Add(item);
                }
            }

            listBox1.Items.Clear();
            foreach (var item in arrayList)
            {
                listBox1.Items.Add(item);
            }
            arrText = arrayList;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (keyList.Count < 1)
                getKeyList();
            StartShua(keyList);
        }

        private void timer2_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            TaskTimer tt = (TaskTimer)sender;
            StartShua1(tt.Param);
        }

        private List<String> getKeyList()
        {
            keyList.Clear();
            string listStr = txtKey.Text;
            string[] data = listStr.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string item in data)
            {
                keyList.Add(item);
            }
            return keyList;
        }
    }
}
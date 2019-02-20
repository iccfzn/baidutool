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
using System.Linq;

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
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        List<String> arrText = new List<String>();
        List<String> keyList = new List<String>();
        int Total = 0;
        Thread thread = null;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtKey;
        private const string TitleInfo = "程序制作：iCC";
        private System.Windows.Forms.ListBox listBox1;
        private volatile bool canStop = false;
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

        /// <summary>
        /// 代理刷
        /// </summary>
        private void StartShuaUA(List<string> list,int roundI,int keyI,int max)
        {
            // 等待“停止”信号，如果没有收到信号则执行 
            roundI = roundI * 1000;
            keyI = keyI * 1000;
            if (arrText.Count > 0 && list.Count > 0 && max > 0)
            {
                for (int q = 1; q <= max; q++)
                {
                    if (canStop)
                        break;
                    for (int j = 0; j < arrText.Count; j++)
                    {
                        //this.listBox1.Invoke(new Action(()=> listBox1.SetSelected(j, true)));
                        if (Utils.RefreshIESettings(arrText[j].ToString()))
                        {
                            foreach (var item in list)
                            {
                                // 等待“停止”信号，如果没有收到信号则执行 
                                if (canStop)
                                    break;
                                toolStripStatusLabel1.Text = "第" + q + "次，关键字：" + item + "，正在使用代理IP：" + arrText[j].ToString() + "访问";
                                string url = strUrl + "wd=" + System.Web.HttpUtility.HtmlEncode(item);
                                System.Object nullObject = 0;
                                string strTemp = String.Empty;
                                System.Object nullObjStr = strTemp;
                                axWebBrowser1.Invoke(new Action(() => axWebBrowser1.Navigate(url, ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr)));
                                Thread.Sleep(keyI);
                            }
                        }
                    }
                    Thread.Sleep(roundI);
                }
                button2.Invoke(new EventHandler(delegate
                {
                    button2.Text = "开始刷";
                }));
                toolStripStatusLabel1.Text = "";
                button1.Invoke(new EventHandler(delegate
                {
                    button1.Enabled = true;
                }));
                button3.Invoke(new EventHandler(delegate
                {
                    button3.Enabled = true;
                }));
                button5.Invoke(new EventHandler(delegate
                {
                    button5.Enabled = true;
                }));
            }
            else
            {
                MessageBox.Show("请输入词条并设置最大次数！"); canStop = true;
                button2.Invoke(new EventHandler(delegate
                {
                    button2.Text = "开始刷";
                }));
                toolStripStatusLabel1.Text = "";
                button1.Invoke(new EventHandler(delegate
                {
                    button1.Enabled = true;
                }));
                button3.Invoke(new EventHandler(delegate
                {
                    button3.Enabled = true;
                }));
                button5.Invoke(new EventHandler(delegate
                {
                    button5.Enabled = true;
                }));
                
            }
            // 此时已经收到停止信号，可以在此释放资源并 
            // 初始化变量 
            canStop = false;
        }

        /// <summary>
        /// 不换ip刷
        /// </summary>
        private void StartShua(List<string> list, int roundI, int keyI, int max)
        {
            roundI = roundI * 1000;
            keyI = keyI * 1000;
            if (list.Count > 0 && max > 0)
            {
                for (int q = 1; q <= max; q++)
                {
                    if (canStop)
                        break;
                    foreach (var item in list)
                    {
                        // 等待“停止”信号，如果没有收到信号则执行 
                        if (canStop)
                            break;
                        toolStripStatusLabel1.Text = "第" + q + "次，关键字：" + item + "，正在使用本地IP访问";
                        string url = strUrl + "wd=" + System.Web.HttpUtility.HtmlEncode(item);
                        System.Object nullObject = 0;
                        string strTemp = String.Empty;
                        System.Object nullObjStr = strTemp;
                        axWebBrowser1.Invoke(new Action(() => axWebBrowser1.Navigate(url, ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr)));
                        Thread.Sleep(keyI);
                    }
                    Thread.Sleep(roundI);
                }
                button2.Invoke(new EventHandler(delegate
                {
                    button2.Text = "开始刷";
                }));
                toolStripStatusLabel1.Text = "";
                button1.Invoke(new EventHandler(delegate
                {
                    button1.Enabled = true;
                }));
                button3.Invoke(new EventHandler(delegate
                {
                    button3.Enabled = true;
                }));
                button5.Invoke(new EventHandler(delegate
                {
                    button5.Enabled = true;
                }));
            }
            else
            {
                MessageBox.Show("请输入词条并设置最大次数！");
                canStop = true;
                button2.Invoke(new EventHandler(delegate
                {
                    button2.Text = "开始刷";
                }));
                toolStripStatusLabel1.Text = "";
                button1.Invoke(new EventHandler(delegate
                {
                    button1.Enabled = true;
                }));
                button3.Invoke(new EventHandler(delegate
                {
                    button3.Enabled = true;
                }));
                button5.Invoke(new EventHandler(delegate
                {
                    button5.Enabled = true;
                }));
            }
            // 此时已经收到停止信号，可以在此释放资源并 
            // 初始化变量 
            canStop = false;
        }
        
        /// <summary>
        /// 路由器刷
        /// </summary>
        private void StartShuaLYQ(List<string> list, int roundI, int keyI, int max,string account,string pwd,string ip)
        {
            // 等待“停止”信号，如果没有收到信号则执行 
            roundI = roundI * 1000;
            keyI = keyI * 1000;
            if (list.Count > 0 && max > 0)
            {
                for (int q = 1; q <= max; q++)
                {
                    if (canStop)
                        break;
                    foreach (var item in list)
                    {
                        // 等待“停止”信号，如果没有收到信号则执行 
                        if (canStop)
                            break;
                        toolStripStatusLabel1.Text = "第" + q + "次，关键字：" + item + "，正在使用路由器换ip访问";
                        string url = strUrl + "wd=" + System.Web.HttpUtility.HtmlEncode(item);
                        System.Object nullObject = 0;
                        string strTemp = String.Empty;
                        System.Object nullObjStr = strTemp;
                        axWebBrowser1.Invoke(new Action(() => axWebBrowser1.Navigate(url, ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr)));
                        Thread.Sleep(keyI);
                    }
                    string result = Utils.Disconnect(ip, account, pwd);
                    if (!result.Contains("success"))
                    {
                        MessageBox.Show(result);
                        canStop = true;
                        button2.Invoke(new EventHandler(delegate
                        {
                            button2.Text = "开始刷";
                        }));
                        toolStripStatusLabel1.Text = "";
                        button1.Invoke(new EventHandler(delegate
                        {
                            button1.Enabled = true;
                        }));
                        button3.Invoke(new EventHandler(delegate
                        {
                            button3.Enabled = true;
                        }));
                        button5.Invoke(new EventHandler(delegate
                        {
                            button5.Enabled = true;
                        }));
                        return;
                    }
                    Thread.Sleep(roundI);
                }
                button2.Invoke(new EventHandler(delegate
                {
                    button2.Text = "开始刷";
                }));
                toolStripStatusLabel1.Text = "";
                button1.Invoke(new EventHandler(delegate
                {
                    button1.Enabled = true;
                }));
                button3.Invoke(new EventHandler(delegate
                {
                    button3.Enabled = true;
                }));
                button5.Invoke(new EventHandler(delegate
                {
                    button5.Enabled = true;
                }));
            }
            else
            {
                MessageBox.Show("请输入词条并设置最大次数！");
                canStop = true;
                button2.Text = "开始刷";
                toolStripStatusLabel1.Text = "";
                button1.Invoke(new EventHandler(delegate
                {
                    button1.Enabled = true;
                }));
                button3.Invoke(new EventHandler(delegate
                {
                    button3.Enabled = true;
                }));
                button5.Invoke(new EventHandler(delegate
                {
                    button5.Enabled = true;
                }));
            }
            // 此时已经收到停止信号，可以在此释放资源并 
            // 初始化变量 
            canStop = false;
        }
        
        /// <summary>
        /// 宽带刷
        /// </summary>
        private void StartShuaKD(List<string> list, int roundI, int keyI, int max)
        {
           
        }

        /// <summary>
        /// 导入
        /// </summary>
        private void button1_Click_1(object sender, System.EventArgs e)
        {
            arrText.Clear();
            listBox1.Items.Clear();
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
                        arrText.Add(strLine);
                        listBox1.Items.Add(strLine);
                    }
                }
                sr.Close();
            }
        }

        /// <summary>
        /// 刷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, System.EventArgs e)
        {
            //刷的类型
            int type = 0;
            if (radioButton1.Checked)
                type = 1;
            if (radioButton2.Checked)
                type = 2;
            if (radioButton3.Checked)
                type = 3;

            Total = listBox1.Items.Count;
            if (button2.Text == "开始刷")
            {
                if (Total == 0 && type == 3)
                {
                    MessageBox.Show("请获取代理地址或导入代理地址后操作！");
                    return;
                }
                if ((string.IsNullOrEmpty(lyqaccount.Text) || string.IsNullOrEmpty(lyqpwd.Text) || string.IsNullOrEmpty(lyqip.Text)) && type == 2)
                {
                    MessageBox.Show("请填写路由器ip，账号和密码！");
                    return;
                }
                int roundB = 0, roundE = 0;
                string roundBStr = this.txtRoundB.Text;
                string roundEStr = this.txtRoundE.Text;
                int.TryParse(roundBStr, out roundB);
                int.TryParse(roundEStr, out roundE);
                int roundI = new Random().Next(roundB, roundE);
                if (roundB <= 0 || roundE <= 0 || (roundE - roundB) <= 0)
                {
                    MessageBox.Show("间隔时间不可为0或开始间隔秒数要大于结束间隔秒数！");
                    return;
                }

                if ((roundB < 10 || roundE < 10 || (roundE - roundB) <= 0) && type == 2)
                {
                    MessageBox.Show("路由器换ip：每轮间隔时间需要大于10秒或开始间隔秒数要大于结束间隔秒数！");
                    return;
                }
                int keyB = 0, keyE = 0;
                string keyBStr = this.txtKeyB.Text;
                string keyEStr = this.txtKeyE.Text;
                int.TryParse(keyBStr, out keyB);
                int.TryParse(keyEStr, out keyE);
                int keyI = new Random().Next(keyB, keyE);
                if (keyB <= 0 || keyE <= 0 || (keyE - keyB) <= 0)
                {
                    MessageBox.Show("间隔时间不可为0或开始间隔秒数要大于结束间隔秒数！");
                    return;
                }
                int count = 0;
                string countStr = this.count.Text;
                int.TryParse(countStr, out count);
                if (count <= 0)
                {
                    MessageBox.Show("最大次数不可为0！");
                    return;
                }

                if (keyList.Count < 1)
                    getKeyList();

                button2.Text = "停止刷";
                canStop = false;
                switch (type)
                {
                    case 1:
                        thread = new Thread(() => StartShuaKD(keyList, roundI, keyI, count));
                        thread.Start();
                        break;
                    case 2:
                        thread = new Thread(() => StartShuaLYQ(keyList, roundI, keyI, count, lyqaccount.Text, lyqpwd.Text, lyqip.Text));
                        thread.Start();
                        break;
                    case 3:
                        thread = new Thread(() => StartShuaUA(keyList, roundI, keyI, count));
                        thread.Start();
                        break;
                    default:
                        thread = new Thread(() => StartShua(keyList, roundI, keyI, count));
                        thread.Start();
                        break;
                }
                button1.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
            }
            else
            {
                canStop = true;
                thread.Abort();
                button2.Text = "开始刷";
                toolStripStatusLabel1.Text = "";
                button1.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
        }

        /// <summary>
        /// 获取免费代理
        /// </summary>
        private void button3_Click(object sender, System.EventArgs e)
        {
            arrText.Clear();
            listBox1.Items.Clear();
            #region q

            for (int k = 1; k <= 1; k++)
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
                                    arrText.Add(ip + ":" + port);
                                    listBox1.Items.Add(ip + ":" + port);
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
            keyList.Clear();
        }

        /// <summary>
        /// 验证ip
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "验证IP")
            {
                if (arrText.Count < 1)
                {
                    MessageBox.Show("请获取代理地址或导入代理地址后操作！");
                    return;
                }
                LoadingHelper.ShowLoadingScreen();
                List<String> arrayList = new List<String>();
                arrayList = new List<string>(arrText);
                int threadCount = arrayList.Count > 20 ? 20 : arrText.Count;
                int single = arrayList.Count / threadCount;
                if (arrayList.Count % threadCount > 0)
                    single++;
                arrText.Clear();
                listBox1.Items.Clear();
                for (int i = 0; i < threadCount; i++)
                {
                    List<string> newText = arrayList.Skip(((i+1) - 1) * single).Take(single).ToList();

                    new Thread(() =>
                    {
                        toolStripStatusLabel1.Text = "后台正在验证ip...";
                        foreach (var item in newText)
                        {
                            string[] data = item.ToString().Split(':');
                            string ip = data[0];
                            string portStr = data[1];
                            int port = 0;
                            int.TryParse(portStr, out port);
                            if (Utils.VerIP(ip, port))
                            {
                                listBox1.Invoke(new Action(() => listBox1.Items.Add(item)));
                                arrText.Add(item);
                            }
                        }
                        toolStripStatusLabel1.Text = "";
                    }
                    ).Start();  
                }
                LoadingHelper.CloseForm();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("关闭窗体后，程序会退出！！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
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
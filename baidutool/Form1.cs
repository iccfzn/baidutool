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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.IContainer components;
        List<String> keyList = new List<String>();
        int Total = 0, logCount = 1;
        Thread thread = null;
        private System.Windows.Forms.GroupBox groupBox5;
        private const string TitleInfo = "程序制作：iCC";
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
            logCount = this.dataGridView1.RowCount;
            // 等待“停止”信号，如果没有收到信号则执行 
            roundI = roundI * 1000;
            keyI = keyI * 1000;
            if (PublicValue.arrText.Count > 0 && list.Count > 0 && max > 0)
            {
                for (int q = 1; q <= max; q++)
                {
                    if (canStop)
                        break;
                    for (int j = 0; j < PublicValue.arrText.Count; j++)
                    {
                        //将IE浏览器代理改为当前代理IP
                        if (Utils.RefreshIESettings(PublicValue.arrText[j].ToString()))
                        {
                            for (int k = 0; k < list.Count; k++)
                            {
                                string item = list[k];
                                // 等待“停止”信号，如果没有收到信号则执行 
                                if (canStop)
                                    break;
                                int index = 0;
                                this.dataGridView1.Invoke(new Action(() =>  index = this.dataGridView1.Rows.Add(logCount, item, "进行中", q, PublicValue.arrText[j].ToString(), DateTime.Now.ToString())));
                                string url = strUrl + "wd=" + System.Web.HttpUtility.HtmlEncode(item);
                                System.Object nullObject = 0;
                                string strTemp = String.Empty;
                                System.Object nullObjStr = strTemp;
                                //操作浏览器访问页面
                                axWebBrowser1.Invoke(new Action(() => axWebBrowser1.Navigate(url, ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr)));
                                //写入日志
                                Utils.WriteLog("第" + q + "次，关键字：" + item + "，正在使用代理IP"+ PublicValue.arrText[j].ToString() + "访问");
                                logCount++;
                                Thread.Sleep(keyI);
                                //写入表格
                                this.dataGridView1.Invoke(new Action(() => this.dataGridView1.Rows[index].Cells[2].Value = "完成"));
                            }
                        }
                    }
                    Thread.Sleep(roundI);
                }
                keyList.Clear();
                listBox2.Items.Clear();
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
            logCount = this.dataGridView1.RowCount;
            roundI = roundI * 1000;
            keyI = keyI * 1000;
            if (list.Count > 0 && max > 0)
            {
                for (int q = 1; q <= max; q++)
                {
                    if (canStop)
                        break;
                    for (int j = 0; j < list.Count; j++)
                    {
                        string item = list[j];
                        // 等待“停止”信号，如果没有收到信号则执行 
                        if (canStop)
                            break;
                        int index = 0;
                        this.dataGridView1.Invoke(new Action(()=> index = dataGridView1.Rows.Add(logCount, item, "进行中", q, "本地IP",DateTime.Now.ToString())));
                        //toolStripStatusLabel1.Text = "第" + q + "次，关键字：" + item + "，正在使用本地IP访问";
                        string url = strUrl + "wd=" + System.Web.HttpUtility.HtmlEncode(item);
                        System.Object nullObject = 0;
                        string strTemp = String.Empty;
                        System.Object nullObjStr = strTemp;
                        axWebBrowser1.Invoke(new Action(() => axWebBrowser1.Navigate(url, ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr)));
                        
                        Utils.WriteLog("第" + q + "次，关键字：" + item + "，正在使用本地IP访问");
                        logCount++;
                        Thread.Sleep(keyI);
                        this.dataGridView1.Invoke(new Action(() => this.dataGridView1.Rows[index].Cells[2].Value = "完成"));
                    }
                    Thread.Sleep(roundI);
                }

                keyList.Clear();
                listBox2.Items.Clear();
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
            int count = 1;
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
                        string url = strUrl + "wd=" + System.Web.HttpUtility.HtmlEncode(item);
                        System.Object nullObject = 0;
                        string strTemp = String.Empty;
                        System.Object nullObjStr = strTemp;
                        axWebBrowser1.Invoke(new Action(() => axWebBrowser1.Navigate(url, ref nullObject, ref nullObjStr, ref nullObjStr, ref nullObjStr)));
                        this.dataGridView1.Rows.Add(count, item, "成功", q, "路由换IP");
                        Utils.WriteLog("第" + q + "次，关键字：" + item + "，正在使用路由换IP访问");
                        count++;
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
            }
            // 此时已经收到停止信号，可以在此释放资源并 
            // 初始化变量 
            canStop = false;
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
            if (radioButton3.Checked)
                type = 3;

            Total = PublicValue.arrText.Count;
            if (button2.Text == "开始刷")
            {
                if (Total == 0 && type == 3)
                {
                    MessageBox.Show("请从IP中获取代理地址或导入代理地址后操作！");
                    return;
                }
                int roundI = new Random().Next(PublicValue.roundB, PublicValue.roundE);
                if (PublicValue.roundB <= 0 || PublicValue.roundE <= 0 || (PublicValue.roundE - PublicValue.roundB) <= 0)
                {
                    MessageBox.Show("每轮间隔时间不可为0或开始间隔秒数要大于结束间隔秒数！");
                    return;
                }
                int keyI = new Random().Next(PublicValue.keyB, PublicValue.keyE);
                if (PublicValue.keyB <= 0 || PublicValue.keyE <= 0 || (PublicValue.keyE - PublicValue.keyB) <= 0)
                {
                    MessageBox.Show("关键字间隔时间不可为0或开始间隔秒数要大于结束间隔秒数！");
                    return;
                }
                if (PublicValue.count <= 0)
                {
                    MessageBox.Show("最大次数不可为0！");
                    return;
                }
                if(keyList.Count < 1)
                {
                    MessageBox.Show("请在列表中加入关键字！");
                    return;
                }

                button2.Text = "停止刷";
                canStop = false;
                switch (type)
                {
                    case 3:
                        thread = new Thread(() => StartShuaUA(keyList, roundI, keyI, PublicValue.count));
                        thread.Start();
                        break;
                    default:
                        thread = new Thread(() => StartShua(keyList, roundI, keyI, PublicValue.count));
                        thread.Start();
                        break;
                }
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                canStop = true;
                thread.Abort();
                button2.Text = "开始刷";
                toolStripStatusLabel1.Text = "";
                button1.Enabled = true;
                button3.Enabled = true;
            }
        }

        /// <summary>
        /// 导入关键字
        /// </summary>
        private void keyImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strPath, strLine = "";
                strPath = openFileDialog1.FileName.ToString();
                StreamReader sr = new StreamReader(strPath, Encoding.Default);
                while (strLine != null)
                {
                    strLine = sr.ReadLine();
                    if (strLine != null)
                    {
                        txtKey.AppendText(strLine+"\r\n");
                    }
                }
                sr.Close();
            }
        }

        /// <summary>
        /// 清除关键字
        /// </summary>
        private void clear_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.txtKey.Clear();
            keyList.Clear();
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("关闭窗体后，程序会退出！！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
                base.Dispose();
                //System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 获取关键字列表
        /// </summary>
        /// <returns></returns>
        private List<String> getKeyList()
        {
            keyList.Clear();
            listBox2.Items.Clear();
            string mainKey = textBox1.Text;
            if (!string.IsNullOrEmpty(mainKey))
            {
                listBox2.Items.Add(mainKey);
                keyList.Add(mainKey);
            }
            string listStr = txtKey.Text;
            string[] data = listStr.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string item in data)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    listBox2.Items.Add(mainKey);
                    keyList.Add(item);
                }
            }
            return keyList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //跨线程访问控件
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 浏览器的显示与隐藏
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "合上")
            {
                button4.Text = "打开";
                axWebBrowser1.Visible = false;
            }
            else
            {
                button4.Text = "合上";
                axWebBrowser1.Visible = true;
            }
        }

        /// <summary>
        /// 关键字加入任务
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            //主关键字
            string mainKey = textBox1.Text;
            if (!string.IsNullOrEmpty(mainKey))
            {
                listBox2.Items.Add(mainKey);
                keyList.Add(mainKey);
            }
            //副关键字
            string listStr = txtKey.Text;
            string[] data = listStr.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string item in data)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    listBox2.Items.Add(item);
                    keyList.Add(item);
                }
            }
        }
        
        /// <summary>
        /// 打开设置
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Setting f = new Setting();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        /// <summary>
        /// 打开IP
        /// </summary>
        private void button3_Click_1(object sender, EventArgs e)
        {
            ip f = new ip();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.DrawBackground();
            //Brush myBrush = Brushes.Black; //初始化字体颜色=黑色    
            //e.Graphics.DrawString(listBox2.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, null);

            Brush myBrush = Brushes.Black;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                myBrush = new SolidBrush(Color.FromArgb(0, 0, 255));//选中时背景颜色
            }
            else//没有选中时的背景颜色
            {
                myBrush = new SolidBrush(Color.White);
            }
            e.Graphics.FillRectangle(myBrush, e.Bounds);//填满矩形背景颜色
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(e.ForeColor)), e.Bounds);
            e.DrawFocusRectangle();//焦点框
            StringFormat stringformat = StringFormat.GenericDefault;
            stringformat.LineAlignment = StringAlignment.Center;
            if(e.Index > -1)
                e.Graphics.DrawString(listBox2.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, stringformat);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            keyList.Clear();
            listBox2.Items.Clear();
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                dt.Rows.Clear();
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
            logCount = 1;
        }
    }
}
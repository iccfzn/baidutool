using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace baidutool
{
    public partial class ip : Form
    {
        private const string TitleInfo = "程序制作：iCC";
        public ip()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "验证IP")
            {
                if (PublicValue.arrText.Count < 1)
                {
                    MessageBox.Show("请获取代理地址或导入代理地址后操作！");
                    return;
                }
                LoadingHelper.ShowLoadingScreen();
                List<String> arrayList = new List<String>();
                arrayList = new List<string>(PublicValue.arrText);
                int threadCount = arrayList.Count > 20 ? 20 : PublicValue.arrText.Count;
                int single = arrayList.Count / threadCount;
                if (arrayList.Count % threadCount > 0)
                    single++;
                PublicValue.arrText.Clear();
                listBox1.Items.Clear();
                for (int i = 0; i < threadCount; i++)
                {
                    List<string> newText = arrayList.Skip(((i + 1) - 1) * single).Take(single).ToList();

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
                                 listBox1.Items.Add(item);
                                PublicValue.arrText.Add(item);
                            }
                        }
                        toolStripStatusLabel1.Text = "";
                    }
                    ).Start();
                }
                LoadingHelper.CloseForm();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PublicValue.arrText.Clear();
            listBox1.Items.Clear();
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
                        PublicValue.arrText.Add(strLine);
                        listBox1.Items.Add(strLine);
                    }
                }
                sr.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PublicValue.arrText.Clear();
            #region q
            new Thread(() =>
            {
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
                                        PublicValue.arrText.Add(ip + ":" + port);
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
            }).Start();
            #endregion
        }

        private void ip_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach(var data in PublicValue.arrText)
            {
                listBox1.Items.Add(data);
            }
        }
    }
}

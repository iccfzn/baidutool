using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace baidutool
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.keyE.Value = 1;
            this.keyB.Value = 1;
            this.roundB.Value = 1;
            this.roundE.Value = 1;
            this.count.Value = 1;
            PublicValue.count = 1;
            PublicValue.keyB = 1;
            PublicValue.keyE = 1;
            PublicValue.roundB = 1;
            PublicValue.roundE = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PublicValue.count = int.Parse(this.count.Value.ToString());
            PublicValue.keyB = int.Parse(this.keyB.Value.ToString());
            PublicValue.keyE = int.Parse(this.keyE.Value.ToString());
            PublicValue.roundB = int.Parse(this.roundB.Value.ToString());
            PublicValue.roundE = int.Parse(this.roundE.Value.ToString());
            this.Close();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            this.keyE.Value = PublicValue.keyE;
            this.keyB.Value = PublicValue.keyB;
            this.roundB.Value = PublicValue.roundB;
            this.roundE.Value = PublicValue.roundE;
            this.count.Value = PublicValue.count;
        }
    }
}

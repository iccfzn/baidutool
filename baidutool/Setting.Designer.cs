namespace baidutool
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.count = new System.Windows.Forms.NumericUpDown();
            this.roundB = new System.Windows.Forms.NumericUpDown();
            this.roundE = new System.Windows.Forms.NumericUpDown();
            this.keyE = new System.Windows.Forms.NumericUpDown();
            this.keyB = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyB)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "秒";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "关键词间隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "每轮间隔";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "秒";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "（随机停留时间）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 44;
            this.label5.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(182, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 52;
            this.label10.Text = "次";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 51;
            this.label8.Text = "要刷的次数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 47;
            this.label6.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 49;
            this.label9.Text = "（随机停留时间）";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 53;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 54;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(79, 124);
            this.count.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(93, 21);
            this.count.TabIndex = 55;
            this.count.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // roundB
            // 
            this.roundB.Location = new System.Drawing.Point(79, 75);
            this.roundB.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.roundB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roundB.Name = "roundB";
            this.roundB.Size = new System.Drawing.Size(54, 21);
            this.roundB.TabIndex = 59;
            this.roundB.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // roundE
            // 
            this.roundE.Location = new System.Drawing.Point(156, 75);
            this.roundE.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.roundE.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roundE.Name = "roundE";
            this.roundE.Size = new System.Drawing.Size(52, 21);
            this.roundE.TabIndex = 60;
            this.roundE.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // keyE
            // 
            this.keyE.Location = new System.Drawing.Point(156, 30);
            this.keyE.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.keyE.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.keyE.Name = "keyE";
            this.keyE.Size = new System.Drawing.Size(52, 21);
            this.keyE.TabIndex = 61;
            this.keyE.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // keyB
            // 
            this.keyB.Location = new System.Drawing.Point(79, 30);
            this.keyB.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.keyB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.keyB.Name = "keyB";
            this.keyB.Size = new System.Drawing.Size(54, 21);
            this.keyB.TabIndex = 62;
            this.keyB.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 231);
            this.Controls.Add(this.keyB);
            this.Controls.Add(this.keyE);
            this.Controls.Add(this.roundE);
            this.Controls.Add(this.roundB);
            this.Controls.Add(this.count);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Name = "Setting";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.Setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown count;
        private System.Windows.Forms.NumericUpDown roundB;
        private System.Windows.Forms.NumericUpDown roundE;
        private System.Windows.Forms.NumericUpDown keyE;
        private System.Windows.Forms.NumericUpDown keyB;
    }
}
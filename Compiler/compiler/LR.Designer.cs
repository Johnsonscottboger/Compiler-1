namespace compiler
{
    partial class LR
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
            this.btnAn = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tbSen = new System.Windows.Forms.TextBox();
            this.btnAnaly = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewAnalysis = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoad = new System.Windows.Forms.Button();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAn
            // 
            this.btnAn.Location = new System.Drawing.Point(730, 201);
            this.btnAn.Name = "btnAn";
            this.btnAn.Size = new System.Drawing.Size(75, 23);
            this.btnAn.TabIndex = 32;
            this.btnAn.Text = "分析";
            this.btnAn.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(475, 228);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(430, 320);
            this.listView.TabIndex = 31;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "步骤";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "分析栈";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "剩余输入串";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "推导所用产生式或匹配";
            this.columnHeader7.Width = 135;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "输入待分析的表达式:";
            // 
            // tbSen
            // 
            this.tbSen.Location = new System.Drawing.Point(599, 201);
            this.tbSen.Name = "tbSen";
            this.tbSen.Size = new System.Drawing.Size(100, 21);
            this.tbSen.TabIndex = 29;
            // 
            // btnAnaly
            // 
            this.btnAnaly.Location = new System.Drawing.Point(673, 14);
            this.btnAnaly.Name = "btnAnaly";
            this.btnAnaly.Size = new System.Drawing.Size(75, 23);
            this.btnAnaly.TabIndex = 27;
            this.btnAnaly.Text = "生成预测表";
            this.btnAnaly.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(834, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "全部清空";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(475, 14);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(87, 23);
            this.btnStep.TabIndex = 26;
            this.btnStep.Text = "单步求预测表";
            this.btnStep.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(369, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 25;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(198, 14);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 24;
            this.btnConfirm.Text = "确认文法";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewAnalysis);
            this.groupBox1.Location = new System.Drawing.Point(475, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 150);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LR(0)分析表";
            // 
            // listViewAnalysis
            // 
            this.listViewAnalysis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAnalysis.FullRowSelect = true;
            this.listViewAnalysis.GridLines = true;
            this.listViewAnalysis.Location = new System.Drawing.Point(3, 17);
            this.listViewAnalysis.Name = "listViewAnalysis";
            this.listViewAnalysis.Size = new System.Drawing.Size(431, 130);
            this.listViewAnalysis.TabIndex = 2;
            this.listViewAnalysis.UseCompatibleStateImageBehavior = false;
            this.listViewAnalysis.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "预测表";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(24, 14);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 20;
            this.btnLoad.Text = "读入文法";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // rtbText
            // 
            this.rtbText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbText.Location = new System.Drawing.Point(24, 45);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(420, 142);
            this.rtbText.TabIndex = 19;
            this.rtbText.Text = "";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(431, 324);
            this.listView1.TabIndex = 33;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "状态";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目集";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "后继符号";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "后继状态";
            this.columnHeader9.Width = 135;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(24, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 344);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LR(0)项目集规范簇";
            // 
            // LR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAn);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSen);
            this.Controls.Add(this.btnAnaly);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.rtbText);
            this.Name = "LR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LR";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAn;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSen;
        private System.Windows.Forms.Button btnAnaly;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewAnalysis;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
namespace compiler
{
    partial class LL_1_
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
            this.listViewFirst = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewFollow = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnFollow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewAnalysis = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnAnaly = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbSen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFirst
            // 
            this.listViewFirst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewFirst.FullRowSelect = true;
            this.listViewFirst.GridLines = true;
            this.listViewFirst.Location = new System.Drawing.Point(29, 179);
            this.listViewFirst.Name = "listViewFirst";
            this.listViewFirst.Size = new System.Drawing.Size(420, 150);
            this.listViewFirst.TabIndex = 1;
            this.listViewFirst.UseCompatibleStateImageBehavior = false;
            this.listViewFirst.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "First";
            this.columnHeader1.Width = 50;
            // 
            // listViewFollow
            // 
            this.listViewFollow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewFollow.FullRowSelect = true;
            this.listViewFollow.GridLines = true;
            this.listViewFollow.Location = new System.Drawing.Point(29, 386);
            this.listViewFollow.Name = "listViewFollow";
            this.listViewFollow.Size = new System.Drawing.Size(420, 150);
            this.listViewFollow.TabIndex = 2;
            this.listViewFollow.UseCompatibleStateImageBehavior = false;
            this.listViewFollow.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Follow";
            // 
            // rtbText
            // 
            this.rtbText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbText.Location = new System.Drawing.Point(29, 40);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(420, 120);
            this.rtbText.TabIndex = 3;
            this.rtbText.Text = "";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(29, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "读入文法";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(102, 343);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "First集";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnFollow
            // 
            this.btnFollow.Location = new System.Drawing.Point(320, 343);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(75, 23);
            this.btnFollow.TabIndex = 6;
            this.btnFollow.Text = "Follow集";
            this.btnFollow.UseVisualStyleBackColor = true;
            this.btnFollow.Click += new System.EventHandler(this.btnFollow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewAnalysis);
            this.groupBox1.Location = new System.Drawing.Point(480, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 150);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预测分析表";
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
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(203, 9);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "确认文法";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(374, 9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(480, 9);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(87, 23);
            this.btnStep.TabIndex = 10;
            this.btnStep.Text = "单步求预测表";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnAnaly
            // 
            this.btnAnaly.Location = new System.Drawing.Point(678, 9);
            this.btnAnaly.Name = "btnAnaly";
            this.btnAnaly.Size = new System.Drawing.Size(75, 23);
            this.btnAnaly.TabIndex = 11;
            this.btnAnaly.Text = "生成预测表";
            this.btnAnaly.UseVisualStyleBackColor = true;
            this.btnAnaly.Click += new System.EventHandler(this.btnAnaly_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(839, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "全部清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbSen
            // 
            this.tbSen.Location = new System.Drawing.Point(558, 196);
            this.tbSen.Name = "tbSen";
            this.tbSen.Size = new System.Drawing.Size(100, 21);
            this.tbSen.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(482, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "输入表达式:";
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
            this.listView.Location = new System.Drawing.Point(480, 223);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(430, 320);
            this.listView.TabIndex = 15;
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
            // btnAn
            // 
            this.btnAn.Location = new System.Drawing.Point(678, 196);
            this.btnAn.Name = "btnAn";
            this.btnAn.Size = new System.Drawing.Size(75, 23);
            this.btnAn.TabIndex = 16;
            this.btnAn.Text = "分析表";
            this.btnAn.UseVisualStyleBackColor = true;
            this.btnAn.Click += new System.EventHandler(this.btnAn_Click);
            // 
            // LL_1_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 562);
            this.Controls.Add(this.btnAn);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSen);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAnaly);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFollow);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.listViewFollow);
            this.Controls.Add(this.listViewFirst);
            this.MaximizeBox = false;
            this.Name = "LL_1_";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LL_1_";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LL_1__FormClosed);
            this.Load += new System.EventHandler(this.LL_1__Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewFirst;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listViewFollow;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnFollow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewAnalysis;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnAnaly;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbSen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnAn;




    }
}
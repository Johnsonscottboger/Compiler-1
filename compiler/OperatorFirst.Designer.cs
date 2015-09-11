namespace compiler
{
    partial class OperatorFirst
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnLastVT = new System.Windows.Forms.Button();
            this.btnFirstVT = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.listViewLast = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewFirst = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewTable = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSen = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAnaly = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(376, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(205, 11);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 16;
            this.btnConfirm.Text = "确认文法";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnLastVT
            // 
            this.btnLastVT.Location = new System.Drawing.Point(322, 345);
            this.btnLastVT.Name = "btnLastVT";
            this.btnLastVT.Size = new System.Drawing.Size(75, 23);
            this.btnLastVT.TabIndex = 15;
            this.btnLastVT.Text = "LastVT";
            this.btnLastVT.UseVisualStyleBackColor = true;
            this.btnLastVT.Click += new System.EventHandler(this.btnLastVT_Click);
            // 
            // btnFirstVT
            // 
            this.btnFirstVT.Location = new System.Drawing.Point(104, 345);
            this.btnFirstVT.Name = "btnFirstVT";
            this.btnFirstVT.Size = new System.Drawing.Size(75, 23);
            this.btnFirstVT.TabIndex = 14;
            this.btnFirstVT.Text = "FirstVT";
            this.btnFirstVT.UseVisualStyleBackColor = true;
            this.btnFirstVT.Click += new System.EventHandler(this.btnFirstVT_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(31, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "读入文法";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // rtbText
            // 
            this.rtbText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbText.Location = new System.Drawing.Point(31, 42);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(420, 120);
            this.rtbText.TabIndex = 12;
            this.rtbText.Text = "";
            // 
            // listViewLast
            // 
            this.listViewLast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewLast.FullRowSelect = true;
            this.listViewLast.GridLines = true;
            this.listViewLast.Location = new System.Drawing.Point(31, 388);
            this.listViewLast.Name = "listViewLast";
            this.listViewLast.Size = new System.Drawing.Size(420, 150);
            this.listViewLast.TabIndex = 11;
            this.listViewLast.UseCompatibleStateImageBehavior = false;
            this.listViewLast.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "LastVT";
            // 
            // listViewFirst
            // 
            this.listViewFirst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewFirst.FullRowSelect = true;
            this.listViewFirst.GridLines = true;
            this.listViewFirst.Location = new System.Drawing.Point(31, 181);
            this.listViewFirst.Name = "listViewFirst";
            this.listViewFirst.Size = new System.Drawing.Size(420, 150);
            this.listViewFirst.TabIndex = 10;
            this.listViewFirst.UseCompatibleStateImageBehavior = false;
            this.listViewFirst.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "FirstVT";
            // 
            // listViewTable
            // 
            this.listViewTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewTable.FullRowSelect = true;
            this.listViewTable.GridLines = true;
            this.listViewTable.Location = new System.Drawing.Point(486, 42);
            this.listViewTable.Name = "listViewTable";
            this.listViewTable.Size = new System.Drawing.Size(430, 150);
            this.listViewTable.TabIndex = 18;
            this.listViewTable.UseCompatibleStateImageBehavior = false;
            this.listViewTable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "优先表";
            // 
            // btnAn
            // 
            this.btnAn.Location = new System.Drawing.Point(680, 204);
            this.btnAn.Name = "btnAn";
            this.btnAn.Size = new System.Drawing.Size(75, 23);
            this.btnAn.TabIndex = 22;
            this.btnAn.Text = "分析";
            this.btnAn.UseVisualStyleBackColor = true;
            this.btnAn.Click += new System.EventHandler(this.btnAn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "输入表达式:";
            // 
            // tbSen
            // 
            this.tbSen.Location = new System.Drawing.Point(560, 204);
            this.tbSen.Name = "tbSen";
            this.tbSen.Size = new System.Drawing.Size(100, 21);
            this.tbSen.TabIndex = 20;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(486, 233);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(430, 305);
            this.listView.TabIndex = 23;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "步骤";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "分析栈";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "剩余输入串";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "推导所用产生式或匹配";
            this.columnHeader8.Width = 135;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(841, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "全部清空";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnAnaly
            // 
            this.btnAnaly.Location = new System.Drawing.Point(680, 13);
            this.btnAnaly.Name = "btnAnaly";
            this.btnAnaly.Size = new System.Drawing.Size(75, 23);
            this.btnAnaly.TabIndex = 25;
            this.btnAnaly.Text = "生成优先表";
            this.btnAnaly.UseVisualStyleBackColor = true;
            this.btnAnaly.Click += new System.EventHandler(this.btnAnaly_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(486, 13);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(87, 23);
            this.btnStep.TabIndex = 24;
            this.btnStep.Text = "单步求优先表";
            this.btnStep.UseVisualStyleBackColor = true;
            // 
            // OperatorFirst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 562);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAnaly);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnAn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSen);
            this.Controls.Add(this.listViewTable);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnLastVT);
            this.Controls.Add(this.btnFirstVT);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.listViewLast);
            this.Controls.Add(this.listViewFirst);
            this.Name = "OperatorFirst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OperatorFirst";
            this.Load += new System.EventHandler(this.OperatorFirst_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnLastVT;
        private System.Windows.Forms.Button btnFirstVT;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.ListView listViewLast;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listViewFirst;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listViewTable;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnAn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSen;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAnaly;
        private System.Windows.Forms.Button btnStep;
    }
}
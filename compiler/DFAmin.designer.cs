namespace compiler
{
    partial class DFAmin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEnds = new System.Windows.Forms.Label();
            this.lblStarts = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReadDFAD = new System.Windows.Forms.Button();
            this.lvDFAD = new System.Windows.Forms.ListView();
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Varch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.To = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDFADtoDFAM = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEndNode = new System.Windows.Forms.Label();
            this.lblStartNode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvDFAN = new System.Windows.Forms.ListView();
            this.mFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mVarch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEnds);
            this.groupBox1.Controls.Add(this.lblStarts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnReadDFAD);
            this.groupBox1.Controls.Add(this.lvDFAD);
            this.groupBox1.Location = new System.Drawing.Point(13, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 430);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DFA";
            // 
            // lblEnds
            // 
            this.lblEnds.AutoSize = true;
            this.lblEnds.Location = new System.Drawing.Point(78, 405);
            this.lblEnds.Name = "lblEnds";
            this.lblEnds.Size = new System.Drawing.Size(0, 12);
            this.lblEnds.TabIndex = 5;
            // 
            // lblStarts
            // 
            this.lblStarts.AutoSize = true;
            this.lblStarts.Location = new System.Drawing.Point(78, 374);
            this.lblStarts.Name = "lblStarts";
            this.lblStarts.Size = new System.Drawing.Size(0, 12);
            this.lblStarts.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束状态：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "开始状态：";
            // 
            // btnReadDFAD
            // 
            this.btnReadDFAD.Location = new System.Drawing.Point(233, 396);
            this.btnReadDFAD.Name = "btnReadDFAD";
            this.btnReadDFAD.Size = new System.Drawing.Size(119, 23);
            this.btnReadDFAD.TabIndex = 1;
            this.btnReadDFAD.Text = "读取DFA文件";
            this.btnReadDFAD.UseVisualStyleBackColor = true;
            this.btnReadDFAD.Click += new System.EventHandler(this.btnReadDFAD_Click);
            // 
            // lvDFAD
            // 
            this.lvDFAD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.From,
            this.Varch,
            this.To});
            this.lvDFAD.FullRowSelect = true;
            this.lvDFAD.GridLines = true;
            this.lvDFAD.Location = new System.Drawing.Point(7, 21);
            this.lvDFAD.Name = "lvDFAD";
            this.lvDFAD.Size = new System.Drawing.Size(345, 346);
            this.lvDFAD.TabIndex = 0;
            this.lvDFAD.UseCompatibleStateImageBehavior = false;
            this.lvDFAD.View = System.Windows.Forms.View.Details;
            // 
            // From
            // 
            this.From.Text = "From";
            // 
            // Varch
            // 
            this.Varch.Text = "Vrach";
            // 
            // To
            // 
            this.To.Text = "To";
            // 
            // btnDFADtoDFAM
            // 
            this.btnDFADtoDFAM.Location = new System.Drawing.Point(264, 396);
            this.btnDFADtoDFAM.Name = "btnDFADtoDFAM";
            this.btnDFADtoDFAM.Size = new System.Drawing.Size(87, 23);
            this.btnDFADtoDFAM.TabIndex = 1;
            this.btnDFADtoDFAM.Text = "DFA->MFA";
            this.btnDFADtoDFAM.UseVisualStyleBackColor = true;
            this.btnDFADtoDFAM.Click += new System.EventHandler(this.btnDFADtoDFAM_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEndNode);
            this.groupBox2.Controls.Add(this.lblStartNode);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnDFADtoDFAM);
            this.groupBox2.Controls.Add(this.lvDFAN);
            this.groupBox2.Location = new System.Drawing.Point(395, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 430);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MFA";
            // 
            // lblEndNode
            // 
            this.lblEndNode.AutoSize = true;
            this.lblEndNode.Location = new System.Drawing.Point(78, 406);
            this.lblEndNode.Name = "lblEndNode";
            this.lblEndNode.Size = new System.Drawing.Size(0, 12);
            this.lblEndNode.TabIndex = 5;
            // 
            // lblStartNode
            // 
            this.lblStartNode.AutoSize = true;
            this.lblStartNode.Location = new System.Drawing.Point(78, 374);
            this.lblStartNode.Name = "lblStartNode";
            this.lblStartNode.Size = new System.Drawing.Size(0, 12);
            this.lblStartNode.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "结束状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "开始状态：";
            // 
            // lvDFAN
            // 
            this.lvDFAN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mFrom,
            this.mVarch,
            this.mTo});
            this.lvDFAN.FullRowSelect = true;
            this.lvDFAN.GridLines = true;
            this.lvDFAN.Location = new System.Drawing.Point(6, 21);
            this.lvDFAN.Name = "lvDFAN";
            this.lvDFAN.Size = new System.Drawing.Size(345, 346);
            this.lvDFAN.TabIndex = 1;
            this.lvDFAN.UseCompatibleStateImageBehavior = false;
            this.lvDFAN.View = System.Windows.Forms.View.Details;
            // 
            // mFrom
            // 
            this.mFrom.Text = "From";
            // 
            // mVarch
            // 
            this.mVarch.Text = "Varch";
            // 
            // mTo
            // 
            this.mTo.Text = "To";
            // 
            // DFAmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 465);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DFAmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DFA最小化";
            this.Load += new System.EventHandler(this.DFAmin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvDFAD;
        private System.Windows.Forms.Button btnDFADtoDFAM;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvDFAN;
        private System.Windows.Forms.Button btnReadDFAD;
        private System.Windows.Forms.ColumnHeader From;
        private System.Windows.Forms.ColumnHeader Varch;
        private System.Windows.Forms.ColumnHeader To;
        private System.Windows.Forms.ColumnHeader mFrom;
        private System.Windows.Forms.ColumnHeader mVarch;
        private System.Windows.Forms.ColumnHeader mTo;
        private System.Windows.Forms.Label lblEnds;
        private System.Windows.Forms.Label lblStarts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEndNode;
        private System.Windows.Forms.Label lblStartNode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
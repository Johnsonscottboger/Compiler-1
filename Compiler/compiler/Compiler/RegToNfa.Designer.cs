namespace Compiler
{
    partial class RegToNfa
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
            this.gpbRegrxtonfa = new System.Windows.Forms.GroupBox();
            this.btnReadTXT = new System.Windows.Forms.Button();
            this.tbxRegex = new System.Windows.Forms.TextBox();
            this.lblRegex = new System.Windows.Forms.Label();
            this.gpbＮfa = new System.Windows.Forms.GroupBox();
            this.lblEndNode = new System.Windows.Forms.Label();
            this.lblStartNode = new System.Windows.Forms.Label();
            this.btnReadnfafile = new System.Windows.Forms.Button();
            this.listResult = new System.Windows.Forms.ListView();
            this.from = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.varch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.to = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTonfa = new System.Windows.Forms.Button();
            this.lblEndstate = new System.Windows.Forms.Label();
            this.lblStartstate = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn = new System.Windows.Forms.Button();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lstDfa = new System.Windows.Forms.ListView();
            this.froms = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.varchs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblStarts = new System.Windows.Forms.Label();
            this.lblEnds = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbRegrxtonfa.SuspendLayout();
            this.gpbＮfa.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbRegrxtonfa
            // 
            this.gpbRegrxtonfa.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gpbRegrxtonfa.Controls.Add(this.label1);
            this.gpbRegrxtonfa.Controls.Add(this.btnReadTXT);
            this.gpbRegrxtonfa.Controls.Add(this.btnReadnfafile);
            this.gpbRegrxtonfa.Controls.Add(this.tbxRegex);
            this.gpbRegrxtonfa.Controls.Add(this.lblRegex);
            this.gpbRegrxtonfa.Location = new System.Drawing.Point(13, 13);
            this.gpbRegrxtonfa.Name = "gpbRegrxtonfa";
            this.gpbRegrxtonfa.Size = new System.Drawing.Size(708, 92);
            this.gpbRegrxtonfa.TabIndex = 0;
            this.gpbRegrxtonfa.TabStop = false;
            this.gpbRegrxtonfa.Text = "正规式->NFA";
            // 
            // btnReadTXT
            // 
            this.btnReadTXT.Location = new System.Drawing.Point(588, 20);
            this.btnReadTXT.Name = "btnReadTXT";
            this.btnReadTXT.Size = new System.Drawing.Size(114, 23);
            this.btnReadTXT.TabIndex = 2;
            this.btnReadTXT.Text = "从文件读取正规式";
            this.btnReadTXT.UseVisualStyleBackColor = true;
            this.btnReadTXT.Click += new System.EventHandler(this.btnReadTXT_Click);
            // 
            // tbxRegex
            // 
            this.tbxRegex.Location = new System.Drawing.Point(144, 20);
            this.tbxRegex.Name = "tbxRegex";
            this.tbxRegex.Size = new System.Drawing.Size(438, 21);
            this.tbxRegex.TabIndex = 1;
            // 
            // lblRegex
            // 
            this.lblRegex.AutoSize = true;
            this.lblRegex.Location = new System.Drawing.Point(15, 23);
            this.lblRegex.Name = "lblRegex";
            this.lblRegex.Size = new System.Drawing.Size(131, 12);
            this.lblRegex.TabIndex = 0;
            this.lblRegex.Text = "请输入要转换的正规式:";
            // 
            // gpbＮfa
            // 
            this.gpbＮfa.Controls.Add(this.lblEndNode);
            this.gpbＮfa.Controls.Add(this.lblStartNode);
            this.gpbＮfa.Controls.Add(this.listResult);
            this.gpbＮfa.Controls.Add(this.btnTonfa);
            this.gpbＮfa.Controls.Add(this.lblEndstate);
            this.gpbＮfa.Controls.Add(this.lblStartstate);
            this.gpbＮfa.Location = new System.Drawing.Point(12, 114);
            this.gpbＮfa.Name = "gpbＮfa";
            this.gpbＮfa.Size = new System.Drawing.Size(330, 381);
            this.gpbＮfa.TabIndex = 1;
            this.gpbＮfa.TabStop = false;
            this.gpbＮfa.Text = "正规式->NFA";
            // 
            // lblEndNode
            // 
            this.lblEndNode.AutoSize = true;
            this.lblEndNode.Location = new System.Drawing.Point(99, 329);
            this.lblEndNode.Name = "lblEndNode";
            this.lblEndNode.Size = new System.Drawing.Size(0, 12);
            this.lblEndNode.TabIndex = 7;
            // 
            // lblStartNode
            // 
            this.lblStartNode.AutoSize = true;
            this.lblStartNode.Location = new System.Drawing.Point(97, 303);
            this.lblStartNode.Name = "lblStartNode";
            this.lblStartNode.Size = new System.Drawing.Size(0, 12);
            this.lblStartNode.TabIndex = 6;
            // 
            // btnReadnfafile
            // 
            this.btnReadnfafile.Location = new System.Drawing.Point(144, 62);
            this.btnReadnfafile.Name = "btnReadnfafile";
            this.btnReadnfafile.Size = new System.Drawing.Size(114, 23);
            this.btnReadnfafile.TabIndex = 3;
            this.btnReadnfafile.Text = "读入NFA文件";
            this.btnReadnfafile.UseVisualStyleBackColor = true;
            this.btnReadnfafile.Click += new System.EventHandler(this.btnReadnfafile_Click);
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.from,
            this.varch,
            this.to});
            this.listResult.FullRowSelect = true;
            this.listResult.GridLines = true;
            this.listResult.Location = new System.Drawing.Point(11, 21);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(313, 276);
            this.listResult.TabIndex = 5;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            // 
            // from
            // 
            this.from.Text = "起始状态";
            // 
            // varch
            // 
            this.varch.Text = "字符";
            // 
            // to
            // 
            this.to.Text = "结束状态";
            // 
            // btnTonfa
            // 
            this.btnTonfa.Location = new System.Drawing.Point(181, 349);
            this.btnTonfa.Name = "btnTonfa";
            this.btnTonfa.Size = new System.Drawing.Size(112, 23);
            this.btnTonfa.TabIndex = 4;
            this.btnTonfa.Text = "正规式->NFA";
            this.btnTonfa.UseVisualStyleBackColor = true;
            this.btnTonfa.Click += new System.EventHandler(this.btnTonfa_Click);
            // 
            // lblEndstate
            // 
            this.lblEndstate.AutoSize = true;
            this.lblEndstate.Location = new System.Drawing.Point(9, 330);
            this.lblEndstate.Name = "lblEndstate";
            this.lblEndstate.Size = new System.Drawing.Size(83, 12);
            this.lblEndstate.TabIndex = 2;
            this.lblEndstate.Text = "终结状态集合:";
            // 
            // lblStartstate
            // 
            this.lblStartstate.AutoSize = true;
            this.lblStartstate.Location = new System.Drawing.Point(7, 304);
            this.lblStartstate.Name = "lblStartstate";
            this.lblStartstate.Size = new System.Drawing.Size(83, 12);
            this.lblStartstate.TabIndex = 1;
            this.lblStartstate.Text = "开始状态集合:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEnds);
            this.groupBox2.Controls.Add(this.lblStarts);
            this.groupBox2.Controls.Add(this.btn);
            this.groupBox2.Controls.Add(this.lblEnd);
            this.groupBox2.Controls.Add(this.lblStart);
            this.groupBox2.Controls.Add(this.lstDfa);
            this.groupBox2.Location = new System.Drawing.Point(390, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 381);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "NFA->DFA";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(210, 348);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(114, 23);
            this.btn.TabIndex = 4;
            this.btn.Text = "NFA->DFA";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(7, 329);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(59, 12);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "结束状态:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(7, 304);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(59, 12);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "开始状态:";
            // 
            // lstDfa
            // 
            this.lstDfa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.froms,
            this.varchs,
            this.tos});
            this.lstDfa.FullRowSelect = true;
            this.lstDfa.GridLines = true;
            this.lstDfa.Location = new System.Drawing.Point(7, 21);
            this.lstDfa.Name = "lstDfa";
            this.lstDfa.Size = new System.Drawing.Size(317, 276);
            this.lstDfa.TabIndex = 0;
            this.lstDfa.UseCompatibleStateImageBehavior = false;
            this.lstDfa.View = System.Windows.Forms.View.Details;
            // 
            // froms
            // 
            this.froms.Text = "起始状态";
            // 
            // varchs
            // 
            this.varchs.Text = "字符";
            // 
            // tos
            // 
            this.tos.Text = "结束状态";
            // 
            // lblStarts
            // 
            this.lblStarts.AutoSize = true;
            this.lblStarts.Location = new System.Drawing.Point(73, 303);
            this.lblStarts.Name = "lblStarts";
            this.lblStarts.Size = new System.Drawing.Size(0, 12);
            this.lblStarts.TabIndex = 5;
            // 
            // lblEnds
            // 
            this.lblEnds.AutoSize = true;
            this.lblEnds.Location = new System.Drawing.Point(73, 329);
            this.lblEnds.Name = "lblEnds";
            this.lblEnds.Size = new System.Drawing.Size(0, 12);
            this.lblEnds.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "NFAM->DFAD:";
            // 
            // RegToNfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 507);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpbＮfa);
            this.Controls.Add(this.gpbRegrxtonfa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "RegToNfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正规式转NFA";
            this.Load += new System.EventHandler(this.RegToNfa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegToNfa_KeyDown);
            this.gpbRegrxtonfa.ResumeLayout(false);
            this.gpbRegrxtonfa.PerformLayout();
            this.gpbＮfa.ResumeLayout(false);
            this.gpbＮfa.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbRegrxtonfa;
        private System.Windows.Forms.TextBox tbxRegex;
        private System.Windows.Forms.Label lblRegex;
        private System.Windows.Forms.GroupBox gpbＮfa;
        private System.Windows.Forms.Button btnTonfa;
        private System.Windows.Forms.Button btnReadnfafile;
        private System.Windows.Forms.Label lblEndstate;
        private System.Windows.Forms.Label lblStartstate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ListView lstDfa;
        private System.Windows.Forms.ListView listResult;
        private System.Windows.Forms.ColumnHeader from;
        private System.Windows.Forms.ColumnHeader varch;
        private System.Windows.Forms.ColumnHeader to;
        private System.Windows.Forms.Label lblEndNode;
        private System.Windows.Forms.Label lblStartNode;
        private System.Windows.Forms.Button btnReadTXT;
        private System.Windows.Forms.ColumnHeader froms;
        private System.Windows.Forms.ColumnHeader varchs;
        private System.Windows.Forms.ColumnHeader tos;
        private System.Windows.Forms.Label lblEnds;
        private System.Windows.Forms.Label lblStarts;
        private System.Windows.Forms.Label label1;
    }
}
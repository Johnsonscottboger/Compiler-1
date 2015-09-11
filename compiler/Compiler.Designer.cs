namespace compiler
{
    partial class Compiler
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compiler));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.词法分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.词法分析器AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.正规式NFAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nFADFAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFA最小化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.语法分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.语法分析器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lL1预测分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运算符优先ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中间代码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.目标代码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具栏ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.状态栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示符号表信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于CompilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAnalyse = new System.Windows.Forms.ToolStripButton();
            this.tsbShowHide = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.of = new System.Windows.Forms.OpenFileDialog();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtToken = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.词法分析ToolStripMenuItem,
            this.语法分析ToolStripMenuItem,
            this.中间代码ToolStripMenuItem,
            this.目标代码ToolStripMenuItem,
            this.帮助HToolStripMenuItem,
            this.帮助HToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem,
            this.保存SToolStripMenuItem,
            this.另存为AToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.打开OToolStripMenuItem_Click);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // 另存为AToolStripMenuItem
            // 
            this.另存为AToolStripMenuItem.Name = "另存为AToolStripMenuItem";
            this.另存为AToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.另存为AToolStripMenuItem.Text = "另存为(&A)";
            this.另存为AToolStripMenuItem.Click += new System.EventHandler(this.另存为AToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.编辑ToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 词法分析ToolStripMenuItem
            // 
            this.词法分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.词法分析器AToolStripMenuItem,
            this.正规式NFAToolStripMenuItem,
            this.nFADFAToolStripMenuItem,
            this.dFA最小化ToolStripMenuItem});
            this.词法分析ToolStripMenuItem.Name = "词法分析ToolStripMenuItem";
            this.词法分析ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.词法分析ToolStripMenuItem.Text = "词法分析(&W)";
            // 
            // 词法分析器AToolStripMenuItem
            // 
            this.词法分析器AToolStripMenuItem.Name = "词法分析器AToolStripMenuItem";
            this.词法分析器AToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.词法分析器AToolStripMenuItem.Text = "词法分析器(&S)";
            this.词法分析器AToolStripMenuItem.Click += new System.EventHandler(this.词法分析器AToolStripMenuItem_Click);
            // 
            // 正规式NFAToolStripMenuItem
            // 
            this.正规式NFAToolStripMenuItem.Name = "正规式NFAToolStripMenuItem";
            this.正规式NFAToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.正规式NFAToolStripMenuItem.Text = "正规式=>NFA(&R)";
            this.正规式NFAToolStripMenuItem.Click += new System.EventHandler(this.正规式NFAToolStripMenuItem_Click);
            // 
            // nFADFAToolStripMenuItem
            // 
            this.nFADFAToolStripMenuItem.Name = "nFADFAToolStripMenuItem";
            this.nFADFAToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.nFADFAToolStripMenuItem.Text = "NFA=>DFA(&N)";
            this.nFADFAToolStripMenuItem.Click += new System.EventHandler(this.nFADFAToolStripMenuItem_Click);
            // 
            // dFA最小化ToolStripMenuItem
            // 
            this.dFA最小化ToolStripMenuItem.Name = "dFA最小化ToolStripMenuItem";
            this.dFA最小化ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.dFA最小化ToolStripMenuItem.Text = "DFA最小化(&D)";
            this.dFA最小化ToolStripMenuItem.Click += new System.EventHandler(this.dFA最小化ToolStripMenuItem_Click);
            // 
            // 语法分析ToolStripMenuItem
            // 
            this.语法分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.语法分析器ToolStripMenuItem,
            this.lL1预测分析ToolStripMenuItem,
            this.运算符优先ToolStripMenuItem,
            this.lRToolStripMenuItem});
            this.语法分析ToolStripMenuItem.Name = "语法分析ToolStripMenuItem";
            this.语法分析ToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.语法分析ToolStripMenuItem.Text = "语法分析(&P)";
            // 
            // 语法分析器ToolStripMenuItem
            // 
            this.语法分析器ToolStripMenuItem.Enabled = false;
            this.语法分析器ToolStripMenuItem.Name = "语法分析器ToolStripMenuItem";
            this.语法分析器ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.语法分析器ToolStripMenuItem.Text = "语法分析器";
            this.语法分析器ToolStripMenuItem.Click += new System.EventHandler(this.语法分析器ToolStripMenuItem_Click);
            // 
            // lL1预测分析ToolStripMenuItem
            // 
            this.lL1预测分析ToolStripMenuItem.Name = "lL1预测分析ToolStripMenuItem";
            this.lL1预测分析ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.lL1预测分析ToolStripMenuItem.Text = "LL(1)预测分析";
            this.lL1预测分析ToolStripMenuItem.Click += new System.EventHandler(this.lL1预测分析ToolStripMenuItem_Click);
            // 
            // 运算符优先ToolStripMenuItem
            // 
            this.运算符优先ToolStripMenuItem.Name = "运算符优先ToolStripMenuItem";
            this.运算符优先ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.运算符优先ToolStripMenuItem.Text = "运算符优先";
            this.运算符优先ToolStripMenuItem.Click += new System.EventHandler(this.运算符优先ToolStripMenuItem_Click);
            // 
            // lRToolStripMenuItem
            // 
            this.lRToolStripMenuItem.Name = "lRToolStripMenuItem";
            this.lRToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.lRToolStripMenuItem.Text = "LR分析";
            this.lRToolStripMenuItem.Click += new System.EventHandler(this.lRToolStripMenuItem_Click);
            // 
            // 中间代码ToolStripMenuItem
            // 
            this.中间代码ToolStripMenuItem.Name = "中间代码ToolStripMenuItem";
            this.中间代码ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.中间代码ToolStripMenuItem.Text = "中间代码";
            this.中间代码ToolStripMenuItem.Click += new System.EventHandler(this.中间代码ToolStripMenuItem_Click);
            // 
            // 目标代码ToolStripMenuItem
            // 
            this.目标代码ToolStripMenuItem.Name = "目标代码ToolStripMenuItem";
            this.目标代码ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.目标代码ToolStripMenuItem.Text = "目标代码";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具栏ToolStripMenuItem1,
            this.状态栏ToolStripMenuItem,
            this.显示符号表信息ToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.帮助HToolStripMenuItem.Text = "查看(&V)";
            // 
            // 工具栏ToolStripMenuItem1
            // 
            this.工具栏ToolStripMenuItem1.Checked = true;
            this.工具栏ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.工具栏ToolStripMenuItem1.Name = "工具栏ToolStripMenuItem1";
            this.工具栏ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.工具栏ToolStripMenuItem1.Text = "工具栏";
            this.工具栏ToolStripMenuItem1.Click += new System.EventHandler(this.工具栏ToolStripMenuItem1_Click);
            // 
            // 状态栏ToolStripMenuItem
            // 
            this.状态栏ToolStripMenuItem.Checked = true;
            this.状态栏ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.状态栏ToolStripMenuItem.Name = "状态栏ToolStripMenuItem";
            this.状态栏ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.状态栏ToolStripMenuItem.Text = "状态栏";
            this.状态栏ToolStripMenuItem.Click += new System.EventHandler(this.状态栏ToolStripMenuItem_Click);
            // 
            // 显示符号表信息ToolStripMenuItem
            // 
            this.显示符号表信息ToolStripMenuItem.Name = "显示符号表信息ToolStripMenuItem";
            this.显示符号表信息ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.显示符号表信息ToolStripMenuItem.Text = "显示符号表信息";
            this.显示符号表信息ToolStripMenuItem.Click += new System.EventHandler(this.show_sym);
            // 
            // 帮助HToolStripMenuItem1
            // 
            this.帮助HToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于CompilerToolStripMenuItem});
            this.帮助HToolStripMenuItem1.Name = "帮助HToolStripMenuItem1";
            this.帮助HToolStripMenuItem1.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem1.Text = "帮助(&H)";
            // 
            // 关于CompilerToolStripMenuItem
            // 
            this.关于CompilerToolStripMenuItem.Name = "关于CompilerToolStripMenuItem";
            this.关于CompilerToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.关于CompilerToolStripMenuItem.Text = "关于Compiler...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator2,
            this.tsbAnalyse,
            this.tsbShowHide,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(934, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "打开";
            this.tsbOpen.Click += new System.EventHandler(this.打开OToolStripMenuItem_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAnalyse
            // 
            this.tsbAnalyse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnalyse.Image = ((System.Drawing.Image)(resources.GetObject("tsbAnalyse.Image")));
            this.tsbAnalyse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnalyse.Name = "tsbAnalyse";
            this.tsbAnalyse.Size = new System.Drawing.Size(23, 22);
            this.tsbAnalyse.Text = "词法分析";
            this.tsbAnalyse.Click += new System.EventHandler(this.词法分析器AToolStripMenuItem_Click);
            // 
            // tsbShowHide
            // 
            this.tsbShowHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowHide.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowHide.Image")));
            this.tsbShowHide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowHide.Name = "tsbShowHide";
            this.tsbShowHide.Size = new System.Drawing.Size(23, 22);
            this.tsbShowHide.Text = "显示隐藏符号表";
            this.tsbShowHide.Click += new System.EventHandler(this.show_sym);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "语法分析";
            this.toolStripButton1.Click += new System.EventHandler(this.语法分析器ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "行数";
            // 
            // of
            // 
            this.of.FileName = "openFileDialog1";
            // 
            // txtRow
            // 
            this.txtRow.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtRow.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRow.ForeColor = System.Drawing.Color.Red;
            this.txtRow.Location = new System.Drawing.Point(0, 50);
            this.txtRow.Multiline = true;
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(32, 490);
            this.txtRow.TabIndex = 5;
            this.txtRow.TabStop = false;
            this.txtRow.Text = "1";
            this.txtRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Location = new System.Drawing.Point(454, 276);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(445, 211);
            this.txtMsg.TabIndex = 2;
            this.txtMsg.TabStop = false;
            this.txtMsg.Text = "";
            this.txtMsg.WordWrap = false;
            // 
            // txtContent
            // 
            this.txtContent.AcceptsTab = true;
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Location = new System.Drawing.Point(3, 3);
            this.txtContent.Name = "txtContent";
            this.tableLayoutPanel1.SetRowSpan(this.txtContent, 2);
            this.txtContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtContent.Size = new System.Drawing.Size(445, 484);
            this.txtContent.TabIndex = 0;
            this.txtContent.Text = "";
            this.txtContent.WordWrap = false;
            this.txtContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtContent_MouseClick);
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtToken, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtContent, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMsg, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(32, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.89743F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.10257F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(902, 490);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // txtToken
            // 
            this.txtToken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtToken.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToken.Location = new System.Drawing.Point(454, 3);
            this.txtToken.Name = "txtToken";
            this.txtToken.ReadOnly = true;
            this.txtToken.Size = new System.Drawing.Size(445, 267);
            this.txtToken.TabIndex = 1;
            this.txtToken.TabStop = false;
            this.txtToken.Text = "";
            this.txtToken.WordWrap = false;
            // 
            // Compiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Compiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 编译原理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Compiler_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Compiler_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 词法分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中间代码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 目标代码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具栏ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 状态栏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示符号表信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripMenuItem 词法分析器AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbAnalyse;
        private System.Windows.Forms.OpenFileDialog of;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.RichTextBox txtMsg;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox txtToken;
        private System.Windows.Forms.ToolStripButton tsbShowHide;
        private System.Windows.Forms.ToolStripMenuItem 语法分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 正规式NFAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nFADFAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dFA最小化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 语法分析器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lL1预测分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运算符优先ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于CompilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}


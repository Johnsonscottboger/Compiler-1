namespace Compiler
{
    partial class Complier
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Complier));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.spilt = new System.Windows.Forms.ToolStripSeparator();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileAs = new System.Windows.Forms.ToolStripMenuItem();
            this.spilt1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.WordAny = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Wordany = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_RegularToNfa = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_NfaToDfa = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_MinDfa = new System.Windows.Forms.ToolStripMenuItem();
            this.GrammarAny = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Grammer = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Ll1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Opa = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Lr = new System.Windows.Forms.ToolStripMenuItem();
            this.MiddleCode = new System.Windows.Forms.ToolStripMenuItem();
            this.TargetCode = new System.Windows.Forms.ToolStripMenuItem();
            this.View = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Tool = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Status = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Char = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool = new System.Windows.Forms.ToolStrip();
            this.Tool_Open = new System.Windows.Forms.ToolStripButton();
            this.Tool_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.Tool_Cut = new System.Windows.Forms.ToolStripButton();
            this.Tool_Copy = new System.Windows.Forms.ToolStripButton();
            this.Tool_Paste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Tool_Help = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.MyPictureBox = new System.Windows.Forms.PictureBox();
            this.tbx_sourcecode = new System.Windows.Forms.RichTextBox();
            this.textMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fontMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undo = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_sourcecode = new System.Windows.Forms.Label();
            this.lst_error = new System.Windows.Forms.ListView();
            this.lines = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.word = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorinfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_up = new System.Windows.Forms.Label();
            this.lbl_Errorinfo = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lst_output = new System.Windows.Forms.ListView();
            this.words = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.linescol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_output = new System.Windows.Forms.Label();
            this.lst_table = new System.Windows.Forms.ListView();
            this.into = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wordss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.types = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sorts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.md = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_Chartable = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.StatusStrip();
            this.status_space = new System.Windows.Forms.ToolStripStatusLabel();
            this.linescols = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_lines = new System.Windows.Forms.Timer(this.components);
            this.menu.SuspendLayout();
            this.Tool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyPictureBox)).BeginInit();
            this.textMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.WordAny,
            this.GrammarAny,
            this.MiddleCode,
            this.TargetCode,
            this.View,
            this.Help});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(859, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.spilt,
            this.SaveFile,
            this.SaveFileAs,
            this.spilt1,
            this.Exit});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(59, 20);
            this.File.Text = "文件(&F)";
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFile.Size = new System.Drawing.Size(177, 22);
            this.OpenFile.Text = "打开文件(&O)";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // spilt
            // 
            this.spilt.Name = "spilt";
            this.spilt.Size = new System.Drawing.Size(174, 6);
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFile.Size = new System.Drawing.Size(177, 22);
            this.SaveFile.Text = "保存文件(&S)";
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // SaveFileAs
            // 
            this.SaveFileAs.Name = "SaveFileAs";
            this.SaveFileAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SaveFileAs.Size = new System.Drawing.Size(177, 22);
            this.SaveFileAs.Text = "另存为(&A)";
            this.SaveFileAs.Click += new System.EventHandler(this.SaveFileAs_Click);
            // 
            // spilt1
            // 
            this.spilt1.Name = "spilt1";
            this.spilt1.Size = new System.Drawing.Size(174, 6);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.Exit.Size = new System.Drawing.Size(177, 22);
            this.Exit.Text = "退出(&X)";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // WordAny
            // 
            this.WordAny.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Wordany,
            this.Menu_RegularToNfa,
            this.Menu_NfaToDfa,
            this.Menu_MinDfa});
            this.WordAny.Name = "WordAny";
            this.WordAny.Size = new System.Drawing.Size(83, 20);
            this.WordAny.Text = "词法分析(&W)";
            this.WordAny.Click += new System.EventHandler(this.WordAny_Click);
            // 
            // Menu_Wordany
            // 
            this.Menu_Wordany.Name = "Menu_Wordany";
            this.Menu_Wordany.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.Menu_Wordany.Size = new System.Drawing.Size(195, 22);
            this.Menu_Wordany.Text = "词法分析器";
            this.Menu_Wordany.Click += new System.EventHandler(this.Menu_Wordany_Click);
            // 
            // Menu_RegularToNfa
            // 
            this.Menu_RegularToNfa.Name = "Menu_RegularToNfa";
            this.Menu_RegularToNfa.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.Menu_RegularToNfa.Size = new System.Drawing.Size(195, 22);
            this.Menu_RegularToNfa.Text = "正规式->NFA(&R)";
            this.Menu_RegularToNfa.Click += new System.EventHandler(this.Menu_RegularToNfa_Click);
            // 
            // Menu_NfaToDfa
            // 
            this.Menu_NfaToDfa.Name = "Menu_NfaToDfa";
            this.Menu_NfaToDfa.Size = new System.Drawing.Size(195, 22);
            this.Menu_NfaToDfa.Text = "NFA->DFA(&N)";
            this.Menu_NfaToDfa.Click += new System.EventHandler(this.Menu_NfaToDfa_Click);
            // 
            // Menu_MinDfa
            // 
            this.Menu_MinDfa.Name = "Menu_MinDfa";
            this.Menu_MinDfa.Size = new System.Drawing.Size(195, 22);
            this.Menu_MinDfa.Text = "DFA最小化(&D)";
            this.Menu_MinDfa.Click += new System.EventHandler(this.Menu_MinDfa_Click);
            // 
            // GrammarAny
            // 
            this.GrammarAny.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Grammer,
            this.Menu_Ll1,
            this.Menu_Opa,
            this.Menu_Lr});
            this.GrammarAny.Name = "GrammarAny";
            this.GrammarAny.Size = new System.Drawing.Size(83, 20);
            this.GrammarAny.Text = "语法分析(&G)";
            // 
            // Menu_Grammer
            // 
            this.Menu_Grammer.Name = "Menu_Grammer";
            this.Menu_Grammer.Size = new System.Drawing.Size(148, 22);
            this.Menu_Grammer.Text = "语法分析器(&P)";
            // 
            // Menu_Ll1
            // 
            this.Menu_Ll1.Name = "Menu_Ll1";
            this.Menu_Ll1.Size = new System.Drawing.Size(148, 22);
            this.Menu_Ll1.Text = "LL(1)预测分析";
            // 
            // Menu_Opa
            // 
            this.Menu_Opa.Name = "Menu_Opa";
            this.Menu_Opa.Size = new System.Drawing.Size(148, 22);
            this.Menu_Opa.Text = "运算符优先(&C)";
            // 
            // Menu_Lr
            // 
            this.Menu_Lr.Name = "Menu_Lr";
            this.Menu_Lr.Size = new System.Drawing.Size(148, 22);
            this.Menu_Lr.Text = "LR分析(&L)";
            // 
            // MiddleCode
            // 
            this.MiddleCode.Name = "MiddleCode";
            this.MiddleCode.Size = new System.Drawing.Size(107, 20);
            this.MiddleCode.Text = "中间代码生成(&M)";
            // 
            // TargetCode
            // 
            this.TargetCode.Name = "TargetCode";
            this.TargetCode.Size = new System.Drawing.Size(107, 20);
            this.TargetCode.Text = "目标代码生成(&T)";
            // 
            // View
            // 
            this.View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Tool,
            this.Menu_Status,
            this.Menu_Char});
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(59, 20);
            this.View.Text = "查看(&V)";
            // 
            // Menu_Tool
            // 
            this.Menu_Tool.Checked = true;
            this.Menu_Tool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_Tool.Name = "Menu_Tool";
            this.Menu_Tool.Size = new System.Drawing.Size(124, 22);
            this.Menu_Tool.Text = "工具栏(&T)";
            // 
            // Menu_Status
            // 
            this.Menu_Status.Checked = true;
            this.Menu_Status.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_Status.Name = "Menu_Status";
            this.Menu_Status.Size = new System.Drawing.Size(124, 22);
            this.Menu_Status.Text = "状态栏(&B)";
            // 
            // Menu_Char
            // 
            this.Menu_Char.Checked = true;
            this.Menu_Char.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_Char.Name = "Menu_Char";
            this.Menu_Char.Size = new System.Drawing.Size(124, 22);
            this.Menu_Char.Text = "符号表";
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(59, 20);
            this.Help.Text = "帮助(&H)";
            // 
            // Tool
            // 
            this.Tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tool_Open,
            this.Tool_Save,
            this.toolStripSeparator,
            this.Tool_Cut,
            this.Tool_Copy,
            this.Tool_Paste,
            this.toolStripSeparator1,
            this.Tool_Help});
            this.Tool.Location = new System.Drawing.Point(0, 24);
            this.Tool.Name = "Tool";
            this.Tool.Size = new System.Drawing.Size(859, 25);
            this.Tool.TabIndex = 1;
            this.Tool.Text = "tool";
            // 
            // Tool_Open
            // 
            this.Tool_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tool_Open.Image = ((System.Drawing.Image)(resources.GetObject("Tool_Open.Image")));
            this.Tool_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool_Open.Name = "Tool_Open";
            this.Tool_Open.Size = new System.Drawing.Size(23, 22);
            this.Tool_Open.Text = "打开(&O)";
            this.Tool_Open.Click += new System.EventHandler(this.Tool_Open_Click);
            // 
            // Tool_Save
            // 
            this.Tool_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tool_Save.Image = ((System.Drawing.Image)(resources.GetObject("Tool_Save.Image")));
            this.Tool_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool_Save.Name = "Tool_Save";
            this.Tool_Save.Size = new System.Drawing.Size(23, 22);
            this.Tool_Save.Text = "保存(&S)";
            this.Tool_Save.Click += new System.EventHandler(this.Tool_Save_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // Tool_Cut
            // 
            this.Tool_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tool_Cut.Image = ((System.Drawing.Image)(resources.GetObject("Tool_Cut.Image")));
            this.Tool_Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool_Cut.Name = "Tool_Cut";
            this.Tool_Cut.Size = new System.Drawing.Size(23, 22);
            this.Tool_Cut.Text = "剪切(&U)";
            this.Tool_Cut.Click += new System.EventHandler(this.Tool_Cut_Click);
            // 
            // Tool_Copy
            // 
            this.Tool_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tool_Copy.Image = ((System.Drawing.Image)(resources.GetObject("Tool_Copy.Image")));
            this.Tool_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool_Copy.Name = "Tool_Copy";
            this.Tool_Copy.Size = new System.Drawing.Size(23, 22);
            this.Tool_Copy.Text = "复制(&C)";
            this.Tool_Copy.Click += new System.EventHandler(this.Tool_Copy_Click);
            // 
            // Tool_Paste
            // 
            this.Tool_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tool_Paste.Image = ((System.Drawing.Image)(resources.GetObject("Tool_Paste.Image")));
            this.Tool_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool_Paste.Name = "Tool_Paste";
            this.Tool_Paste.Size = new System.Drawing.Size(23, 22);
            this.Tool_Paste.Text = "粘贴(&P)";
            this.Tool_Paste.Click += new System.EventHandler(this.Tool_Paste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Tool_Help
            // 
            this.Tool_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tool_Help.Image = ((System.Drawing.Image)(resources.GetObject("Tool_Help.Image")));
            this.Tool_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool_Help.Name = "Tool_Help";
            this.Tool_Help.Size = new System.Drawing.Size(23, 22);
            this.Tool_Help.Text = "帮助(&L)";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(859, 394);
            this.splitContainer1.SplitterDistance = 609;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.MyPictureBox);
            this.splitContainer2.Panel1.Controls.Add(this.tbx_sourcecode);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_sourcecode);
            this.splitContainer2.Panel1MinSize = 1;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.lst_error);
            this.splitContainer2.Panel2.Controls.Add(this.btn_up);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_Errorinfo);
            this.splitContainer2.Panel2MinSize = 1;
            this.splitContainer2.Size = new System.Drawing.Size(607, 392);
            this.splitContainer2.SplitterDistance = 240;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // MyPictureBox
            // 
            this.MyPictureBox.Location = new System.Drawing.Point(5, 22);
            this.MyPictureBox.Name = "MyPictureBox";
            this.MyPictureBox.Size = new System.Drawing.Size(30, 50);
            this.MyPictureBox.TabIndex = 5;
            this.MyPictureBox.TabStop = false;
            this.MyPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MyPictureBox_Paint);
            // 
            // tbx_sourcecode
            // 
            this.tbx_sourcecode.AcceptsTab = true;
            this.tbx_sourcecode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_sourcecode.ContextMenuStrip = this.textMenu;
            this.tbx_sourcecode.DetectUrls = false;
            this.tbx_sourcecode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_sourcecode.HideSelection = false;
            this.tbx_sourcecode.Location = new System.Drawing.Point(5, 22);
            this.tbx_sourcecode.Name = "tbx_sourcecode";
            this.tbx_sourcecode.Size = new System.Drawing.Size(599, 210);
            this.tbx_sourcecode.TabIndex = 4;
            this.tbx_sourcecode.Text = "";
            this.tbx_sourcecode.VScroll += new System.EventHandler(this.tbx_sourcecode_VScroll);
            this.tbx_sourcecode.TextChanged += new System.EventHandler(this.tbx_sourcecode_TextChanged);
            this.tbx_sourcecode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_sourcecode_KeyPress);
            this.tbx_sourcecode.Resize += new System.EventHandler(this.tbx_sourcecode_Resize);
            // 
            // textMenu
            // 
            this.textMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontMenu,
            this.copyMenu,
            this.cutMenu,
            this.pasteMenu,
            this.undo});
            this.textMenu.Name = "textMenu";
            this.textMenu.Size = new System.Drawing.Size(153, 136);
            this.textMenu.Opening += new System.ComponentModel.CancelEventHandler(this.textMenu_Opening);
            // 
            // fontMenu
            // 
            this.fontMenu.Name = "fontMenu";
            this.fontMenu.Size = new System.Drawing.Size(152, 22);
            this.fontMenu.Text = "字体设置";
            this.fontMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fontMenu.Click += new System.EventHandler(this.fontMenu_Click);
            // 
            // copyMenu
            // 
            this.copyMenu.Name = "copyMenu";
            this.copyMenu.Size = new System.Drawing.Size(152, 22);
            this.copyMenu.Text = "复制";
            this.copyMenu.Click += new System.EventHandler(this.copyMenu_Click);
            // 
            // cutMenu
            // 
            this.cutMenu.Name = "cutMenu";
            this.cutMenu.Size = new System.Drawing.Size(152, 22);
            this.cutMenu.Text = "剪切";
            this.cutMenu.Click += new System.EventHandler(this.cutMenu_Click);
            // 
            // pasteMenu
            // 
            this.pasteMenu.Name = "pasteMenu";
            this.pasteMenu.Size = new System.Drawing.Size(152, 22);
            this.pasteMenu.Text = "粘贴";
            this.pasteMenu.Click += new System.EventHandler(this.pasteMenu_Click);
            // 
            // undo
            // 
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(152, 22);
            this.undo.Text = "撤销";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // lbl_sourcecode
            // 
            this.lbl_sourcecode.AutoSize = true;
            this.lbl_sourcecode.Location = new System.Drawing.Point(3, 4);
            this.lbl_sourcecode.Name = "lbl_sourcecode";
            this.lbl_sourcecode.Size = new System.Drawing.Size(41, 12);
            this.lbl_sourcecode.TabIndex = 1;
            this.lbl_sourcecode.Text = "源代码";
            // 
            // lst_error
            // 
            this.lst_error.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_error.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lines,
            this.col,
            this.code,
            this.word,
            this.errorinfo});
            this.lst_error.FullRowSelect = true;
            this.lst_error.GridLines = true;
            this.lst_error.Location = new System.Drawing.Point(5, 22);
            this.lst_error.MultiSelect = false;
            this.lst_error.Name = "lst_error";
            this.lst_error.Size = new System.Drawing.Size(599, 144);
            this.lst_error.TabIndex = 3;
            this.lst_error.UseCompatibleStateImageBehavior = false;
            this.lst_error.View = System.Windows.Forms.View.Details;
            this.lst_error.DoubleClick += new System.EventHandler(this.lst_error_DoubleClick);
            // 
            // lines
            // 
            this.lines.Text = "行";
            // 
            // col
            // 
            this.col.Text = "列";
            // 
            // code
            // 
            this.code.Text = "错误代码";
            // 
            // word
            // 
            this.word.Text = "错误单词";
            // 
            // errorinfo
            // 
            this.errorinfo.Text = "错误信息";
            this.errorinfo.Width = 150;
            // 
            // btn_up
            // 
            this.btn_up.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_up.AutoSize = true;
            this.btn_up.Location = new System.Drawing.Point(257, 2);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(17, 12);
            this.btn_up.TabIndex = 2;
            this.btn_up.Text = "△";
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // lbl_Errorinfo
            // 
            this.lbl_Errorinfo.AutoSize = true;
            this.lbl_Errorinfo.Location = new System.Drawing.Point(3, 2);
            this.lbl_Errorinfo.Name = "lbl_Errorinfo";
            this.lbl_Errorinfo.Size = new System.Drawing.Size(53, 12);
            this.lbl_Errorinfo.TabIndex = 1;
            this.lbl_Errorinfo.Text = "错误信息";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.lst_output);
            this.splitContainer3.Panel1.Controls.Add(this.lbl_output);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.lst_table);
            this.splitContainer3.Panel2.Controls.Add(this.lbl_Chartable);
            this.splitContainer3.Size = new System.Drawing.Size(246, 392);
            this.splitContainer3.SplitterDistance = 186;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // lst_output
            // 
            this.lst_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_output.AutoArrange = false;
            this.lst_output.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.words,
            this.sort,
            this.linescol});
            this.lst_output.FullRowSelect = true;
            this.lst_output.GridLines = true;
            this.lst_output.Location = new System.Drawing.Point(5, 22);
            this.lst_output.MultiSelect = false;
            this.lst_output.Name = "lst_output";
            this.lst_output.Size = new System.Drawing.Size(238, 156);
            this.lst_output.TabIndex = 2;
            this.lst_output.UseCompatibleStateImageBehavior = false;
            this.lst_output.View = System.Windows.Forms.View.Details;
            // 
            // words
            // 
            this.words.Text = "单词";
            this.words.Width = 100;
            // 
            // sort
            // 
            this.sort.Text = "种别码";
            this.sort.Width = 100;
            // 
            // linescol
            // 
            this.linescol.Text = "行号,列号";
            this.linescol.Width = 100;
            // 
            // lbl_output
            // 
            this.lbl_output.AutoSize = true;
            this.lbl_output.Location = new System.Drawing.Point(3, 4);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(29, 12);
            this.lbl_output.TabIndex = 1;
            this.lbl_output.Text = "输出";
            // 
            // lst_table
            // 
            this.lst_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_table.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.into,
            this.wordss,
            this.length,
            this.types,
            this.sorts,
            this.key,
            this.md});
            this.lst_table.FullRowSelect = true;
            this.lst_table.GridLines = true;
            this.lst_table.Location = new System.Drawing.Point(4, 22);
            this.lst_table.MultiSelect = false;
            this.lst_table.Name = "lst_table";
            this.lst_table.Size = new System.Drawing.Size(239, 198);
            this.lst_table.TabIndex = 2;
            this.lst_table.UseCompatibleStateImageBehavior = false;
            this.lst_table.View = System.Windows.Forms.View.Details;
            // 
            // into
            // 
            this.into.Text = "入口";
            // 
            // wordss
            // 
            this.wordss.Text = "单词";
            // 
            // length
            // 
            this.length.Text = "长度";
            // 
            // types
            // 
            this.types.Text = "类型";
            // 
            // sorts
            // 
            this.sorts.Text = "种属";
            // 
            // key
            // 
            this.key.Text = "值";
            // 
            // md
            // 
            this.md.Text = "内存地址";
            // 
            // lbl_Chartable
            // 
            this.lbl_Chartable.AutoSize = true;
            this.lbl_Chartable.Location = new System.Drawing.Point(3, 2);
            this.lbl_Chartable.Name = "lbl_Chartable";
            this.lbl_Chartable.Size = new System.Drawing.Size(65, 12);
            this.lbl_Chartable.TabIndex = 1;
            this.lbl_Chartable.Text = "符号表信息";
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_space,
            this.linescols});
            this.status.Location = new System.Drawing.Point(0, 449);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(859, 22);
            this.status.TabIndex = 3;
            this.status.Text = "a";
            // 
            // status_space
            // 
            this.status_space.Name = "status_space";
            this.status_space.Size = new System.Drawing.Size(797, 17);
            this.status_space.Spring = true;
            // 
            // linescols
            // 
            this.linescols.Name = "linescols";
            this.linescols.Size = new System.Drawing.Size(47, 17);
            this.linescols.Text = "行0 列0";
            // 
            // timer_lines
            // 
            this.timer_lines.Enabled = true;
            this.timer_lines.Tick += new System.EventHandler(this.timer_lines_Tick);
            // 
            // Complier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 471);
            this.Controls.Add(this.status);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Tool);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Complier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compiler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Complier_FormClosing);
            this.Load += new System.EventHandler(this.Complier_Load);
            this.Resize += new System.EventHandler(this.Complier_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.Tool.ResumeLayout(false);
            this.Tool.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyPictureBox)).EndInit();
            this.textMenu.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripSeparator spilt;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.ToolStripMenuItem SaveFileAs;
        private System.Windows.Forms.ToolStripSeparator spilt1;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem WordAny;
        private System.Windows.Forms.ToolStripMenuItem GrammarAny;
        private System.Windows.Forms.ToolStripMenuItem MiddleCode;
        private System.Windows.Forms.ToolStripMenuItem TargetCode;
        private System.Windows.Forms.ToolStripMenuItem View;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ToolStrip Tool;
        private System.Windows.Forms.ToolStripButton Tool_Open;
        private System.Windows.Forms.ToolStripButton Tool_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton Tool_Cut;
        private System.Windows.Forms.ToolStripButton Tool_Copy;
        private System.Windows.Forms.ToolStripButton Tool_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Tool_Help;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lbl_sourcecode;
        private System.Windows.Forms.Label lbl_Errorinfo;
        private System.Windows.Forms.Label lbl_output;
        private System.Windows.Forms.Label lbl_Chartable;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel linescols;
        private System.Windows.Forms.ToolStripStatusLabel status_space;
        private System.Windows.Forms.Timer timer_lines;
        private System.Windows.Forms.ToolStripMenuItem Menu_Wordany;
        private System.Windows.Forms.ToolStripMenuItem Menu_RegularToNfa;
        private System.Windows.Forms.ToolStripMenuItem Menu_NfaToDfa;
        private System.Windows.Forms.ToolStripMenuItem Menu_MinDfa;
        private System.Windows.Forms.ToolStripMenuItem Menu_Grammer;
        private System.Windows.Forms.ToolStripMenuItem Menu_Ll1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Opa;
        private System.Windows.Forms.ToolStripMenuItem Menu_Lr;
        private System.Windows.Forms.ToolStripMenuItem Menu_Tool;
        private System.Windows.Forms.ToolStripMenuItem Menu_Status;
        private System.Windows.Forms.ToolStripMenuItem Menu_Char;
        private System.Windows.Forms.Label btn_up;
        private System.Windows.Forms.ListView lst_output;
        private System.Windows.Forms.ColumnHeader words;
        private System.Windows.Forms.ColumnHeader sort;
        private System.Windows.Forms.ColumnHeader linescol;
        private System.Windows.Forms.ListView lst_error;
        private System.Windows.Forms.ColumnHeader lines;
        private System.Windows.Forms.ColumnHeader col;
        private System.Windows.Forms.ColumnHeader code;
        private System.Windows.Forms.ColumnHeader word;
        private System.Windows.Forms.ColumnHeader errorinfo;
        private System.Windows.Forms.ListView lst_table;
        private System.Windows.Forms.ColumnHeader wordss;
        private System.Windows.Forms.ColumnHeader length;
        private System.Windows.Forms.ColumnHeader types;
        private System.Windows.Forms.ColumnHeader sorts;
        private System.Windows.Forms.ColumnHeader key;
        private System.Windows.Forms.ColumnHeader md;
        private System.Windows.Forms.ColumnHeader into;
        private System.Windows.Forms.RichTextBox tbx_sourcecode;
        private System.Windows.Forms.ContextMenuStrip textMenu;
        private System.Windows.Forms.ToolStripMenuItem fontMenu;
        private System.Windows.Forms.ToolStripMenuItem copyMenu;
        private System.Windows.Forms.ToolStripMenuItem cutMenu;
        private System.Windows.Forms.ToolStripMenuItem pasteMenu;
        private System.Windows.Forms.PictureBox MyPictureBox;
        private System.Windows.Forms.ToolStripMenuItem undo;
    }
}


namespace csc
{
	partial class JSForm
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
			components = new System.ComponentModel.Container();
			tbCode = new TextBox();
			btnClose = new Button();
			btnOutput = new Button();
			tbResult = new TextBox();
			label1 = new Label();
			btnExec = new Button();
			menuStrip1 = new MenuStrip();
			FileMenu = new ToolStripMenuItem();
			CloseAndOutputMenu = new ToolStripMenuItem();
			CloseMenu = new ToolStripMenuItem();
			EditMenu = new ToolStripMenuItem();
			ExecuteMenu = new ToolStripMenuItem();
			MathMenu = new ToolStripMenuItem();
			contextMenuStrip1 = new ContextMenuStrip(components);
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// tbCode
			// 
			tbCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tbCode.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbCode.Location = new Point(12, 104);
			tbCode.Multiline = true;
			tbCode.Name = "tbCode";
			tbCode.ScrollBars = ScrollBars.Both;
			tbCode.Size = new Size(755, 247);
			tbCode.TabIndex = 0;
			tbCode.Text = "var a=\"A\";\r\nvar b = \"B\";\r\nvar v0 = 12;\r\nvar v1 = 24;\r\n\r\nvar c = a + b + \"\\r\\n\" + v0 +\"/\" +v1;\r\nc;";
			// 
			// btnClose
			// 
			btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnClose.DialogResult = DialogResult.Cancel;
			btnClose.FlatStyle = FlatStyle.Flat;
			btnClose.Location = new Point(534, 435);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(88, 35);
			btnClose.TabIndex = 1;
			btnClose.Text = "Close";
			btnClose.UseVisualStyleBackColor = true;
			// 
			// btnOutput
			// 
			btnOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnOutput.DialogResult = DialogResult.OK;
			btnOutput.FlatStyle = FlatStyle.Flat;
			btnOutput.Location = new Point(628, 435);
			btnOutput.Name = "btnOutput";
			btnOutput.Size = new Size(139, 35);
			btnOutput.TabIndex = 2;
			btnOutput.Text = "Close and Output";
			btnOutput.UseVisualStyleBackColor = true;
			// 
			// tbResult
			// 
			tbResult.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tbResult.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tbResult.Location = new Point(12, 357);
			tbResult.Multiline = true;
			tbResult.Name = "tbResult";
			tbResult.ReadOnly = true;
			tbResult.ScrollBars = ScrollBars.Both;
			tbResult.Size = new Size(755, 72);
			tbResult.TabIndex = 3;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 73);
			label1.Name = "label1";
			label1.Size = new Size(302, 15);
			label1.TabIndex = 4;
			label1.Text = "JavaScriptっぽい計算ができます。Executeでコードを評価します";
			// 
			// btnExec
			// 
			btnExec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnExec.FlatStyle = FlatStyle.Flat;
			btnExec.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnExec.Location = new Point(534, 58);
			btnExec.Name = "btnExec";
			btnExec.Size = new Size(233, 40);
			btnExec.TabIndex = 5;
			btnExec.Text = "Execute";
			btnExec.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			menuStrip1.Anchor = AnchorStyles.None;
			menuStrip1.AutoSize = false;
			menuStrip1.Dock = DockStyle.None;
			menuStrip1.Items.AddRange(new ToolStripItem[] { FileMenu, EditMenu, MathMenu });
			menuStrip1.Location = new Point(0, 22);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(789, 24);
			menuStrip1.TabIndex = 6;
			menuStrip1.Text = "menuStrip1";
			// 
			// FileMenu
			// 
			FileMenu.DropDownItems.AddRange(new ToolStripItem[] { CloseAndOutputMenu, CloseMenu });
			FileMenu.Name = "FileMenu";
			FileMenu.Size = new Size(37, 20);
			FileMenu.Text = "File";
			// 
			// CloseAndOutputMenu
			// 
			CloseAndOutputMenu.Name = "CloseAndOutputMenu";
			CloseAndOutputMenu.Size = new Size(162, 22);
			CloseAndOutputMenu.Text = "CloseAndOutput";
			// 
			// CloseMenu
			// 
			CloseMenu.Name = "CloseMenu";
			CloseMenu.Size = new Size(162, 22);
			CloseMenu.Text = "Close";
			// 
			// EditMenu
			// 
			EditMenu.DropDownItems.AddRange(new ToolStripItem[] { ExecuteMenu });
			EditMenu.Name = "EditMenu";
			EditMenu.Size = new Size(39, 20);
			EditMenu.Text = "Edit";
			// 
			// ExecuteMenu
			// 
			ExecuteMenu.Name = "ExecuteMenu";
			ExecuteMenu.Size = new Size(115, 22);
			ExecuteMenu.Text = "Execute";
			// 
			// MathMenu
			// 
			MathMenu.Name = "MathMenu";
			MathMenu.Size = new Size(47, 20);
			MathMenu.Text = "Input";
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// JSForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(789, 482);
			CloseAction = CloseAction.DRCancel;
			Controls.Add(btnExec);
			Controls.Add(label1);
			Controls.Add(tbResult);
			Controls.Add(btnOutput);
			Controls.Add(btnClose);
			Controls.Add(tbCode);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "JSForm";
			Text = "Javascript";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbCode;
		private Button btnClose;
		private Button btnOutput;
		private TextBox tbResult;
		private Label label1;
		private Button btnExec;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem EditMenu;
		private ToolStripMenuItem MathMenu;
		private ToolStripMenuItem FileMenu;
		private ToolStripMenuItem CloseAndOutputMenu;
		private ToolStripMenuItem CloseMenu;
		private ToolStripMenuItem ExecuteMenu;
		private ContextMenuStrip contextMenuStrip1;
	}
}
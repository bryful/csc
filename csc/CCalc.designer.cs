
namespace csc
{
	partial class CCalc
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCalc));
			textBox1 = new TextBox();
			contextMenuStrip1 = new ContextMenuStrip(components);
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			outputCloseToolStripMenuItem = new ToolStripMenuItem();
			closeToolStripMenuItem = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			MenuUndo = new ToolStripMenuItem();
			mathMenu = new ToolStripMenuItem();
			btnOutputAndClose = new Button();
			btnClose = new Button();
			lbError = new Label();
			key10Pad1 = new Key10Pad();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.BackColor = Color.FromArgb(230, 230, 230);
			textBox1.ContextMenuStrip = contextMenuStrip1;
			textBox1.Font = new Font("MS UI Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
			textBox1.ForeColor = Color.FromArgb(64, 64, 64);
			textBox1.Location = new Point(14, 50);
			textBox1.Margin = new Padding(4);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(325, 39);
			textBox1.TabIndex = 0;
			textBox1.TextChanged += textBox1_TextChanged;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// menuStrip1
			// 
			menuStrip1.Anchor = AnchorStyles.None;
			menuStrip1.AutoSize = false;
			menuStrip1.Dock = DockStyle.None;
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, mathMenu });
			menuStrip1.Location = new Point(0, 22);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(7, 2, 0, 2);
			menuStrip1.Size = new Size(350, 24);
			menuStrip1.TabIndex = 35;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { outputCloseToolStripMenuItem, closeToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// outputCloseToolStripMenuItem
			// 
			outputCloseToolStripMenuItem.Name = "outputCloseToolStripMenuItem";
			outputCloseToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
			outputCloseToolStripMenuItem.Size = new Size(192, 22);
			outputCloseToolStripMenuItem.Text = "Output&&Close";
			outputCloseToolStripMenuItem.Click += btnOutputAndClose_Click;
			// 
			// closeToolStripMenuItem
			// 
			closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			closeToolStripMenuItem.Size = new Size(192, 22);
			closeToolStripMenuItem.Text = "Close";
			closeToolStripMenuItem.Click += btnClose_Click;
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MenuUndo });
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// MenuUndo
			// 
			MenuUndo.Name = "MenuUndo";
			MenuUndo.ShortcutKeys = Keys.Control | Keys.Z;
			MenuUndo.Size = new Size(143, 22);
			MenuUndo.Text = "Undo";
			MenuUndo.Click += MenuUndo_Click;
			// 
			// mathMenu
			// 
			mathMenu.Name = "mathMenu";
			mathMenu.Size = new Size(47, 20);
			mathMenu.Text = "Math";
			// 
			// btnOutputAndClose
			// 
			btnOutputAndClose.FlatStyle = FlatStyle.Flat;
			btnOutputAndClose.ForeColor = Color.White;
			btnOutputAndClose.Location = new Point(238, 339);
			btnOutputAndClose.Margin = new Padding(4);
			btnOutputAndClose.Name = "btnOutputAndClose";
			btnOutputAndClose.Size = new Size(101, 37);
			btnOutputAndClose.TabIndex = 37;
			btnOutputAndClose.Text = "Output&&Close";
			btnOutputAndClose.UseVisualStyleBackColor = true;
			btnOutputAndClose.Click += btnOutputAndClose_Click;
			// 
			// btnClose
			// 
			btnClose.FlatStyle = FlatStyle.Flat;
			btnClose.ForeColor = Color.White;
			btnClose.Location = new Point(142, 339);
			btnClose.Margin = new Padding(4);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(88, 37);
			btnClose.TabIndex = 36;
			btnClose.Text = "Close";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// lbError
			// 
			lbError.AutoSize = true;
			lbError.Font = new Font("ＭＳ ゴシック", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			lbError.ForeColor = Color.White;
			lbError.Location = new Point(14, 339);
			lbError.Margin = new Padding(4, 0, 4, 0);
			lbError.Name = "lbError";
			lbError.Size = new Size(94, 21);
			lbError.TabIndex = 43;
			lbError.Text = "       ";
			// 
			// key10Pad1
			// 
			key10Pad1.BtnInter = 5;
			key10Pad1.BtnSize = new Size(50, 35);
			key10Pad1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			key10Pad1.ForcusItem = textBox1;
			key10Pad1.Location = new Point(14, 97);
			key10Pad1.MaximumSize = new Size(325, 235);
			key10Pad1.MinimumSize = new Size(325, 235);
			key10Pad1.Name = "key10Pad1";
			key10Pad1.Size = new Size(325, 235);
			key10Pad1.TabIndex = 44;
			key10Pad1.Text = "key10Pad1";
			// 
			// CCalc
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(64, 64, 64);
			CanResize = false;
			ClientSize = new Size(350, 385);
			Controls.Add(key10Pad1);
			Controls.Add(lbError);
			Controls.Add(btnOutputAndClose);
			Controls.Add(btnClose);
			Controls.Add(menuStrip1);
			Controls.Add(textBox1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			MainMenuStrip = menuStrip1;
			Margin = new Padding(4);
			Name = "CCalc";
			Text = "Calc";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private ContextMenuStrip contextMenuStrip1;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem mathMenu;
		private ToolStripMenuItem outputCloseToolStripMenuItem;
		private ToolStripMenuItem closeToolStripMenuItem;
		private ToolStripMenuItem editToolStripMenuItem;
		private Button btnOutputAndClose;
		private ToolStripMenuItem MenuUndo;
		private Button btnClose;
		private Label lbError;
		private Key10Pad key10Pad1;
	}
}


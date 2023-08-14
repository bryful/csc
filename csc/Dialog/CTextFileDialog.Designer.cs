
namespace csc
{
	partial class CTextFileDialog
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
			textBox1 = new TextBox();
			btnCancel = new Button();
			btnOutput = new Button();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			openToolStripMenuItem = new ToolStripMenuItem();
			saveToolStripMenuItem = new ToolStripMenuItem();
			saveAsToolStripMenuItem = new ToolStripMenuItem();
			outputToolStripMenuItem = new ToolStripMenuItem();
			closeToolStripMenuItem = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBox1.BackColor = Color.FromArgb(230, 230, 230);
			textBox1.BorderStyle = BorderStyle.FixedSingle;
			textBox1.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			textBox1.ForeColor = Color.FromArgb(32, 32, 32);
			textBox1.Location = new Point(12, 58);
			textBox1.MaxLength = int.MaxValue;
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(802, 378);
			textBox1.TabIndex = 0;
			// 
			// btnCancel
			// 
			btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCancel.FlatStyle = FlatStyle.Flat;
			btnCancel.Font = new Font("MS UI Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			btnCancel.ForeColor = Color.FromArgb(230, 230, 230);
			btnCancel.Location = new Point(618, 442);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Close";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// btnOutput
			// 
			btnOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnOutput.FlatStyle = FlatStyle.Flat;
			btnOutput.Font = new Font("MS UI Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			btnOutput.ForeColor = Color.FromArgb(230, 230, 230);
			btnOutput.Location = new Point(699, 442);
			btnOutput.Name = "btnOutput";
			btnOutput.Size = new Size(115, 23);
			btnOutput.TabIndex = 3;
			btnOutput.Text = "Output&&Close";
			btnOutput.UseVisualStyleBackColor = true;
			btnOutput.Click += btnSave_Click;
			// 
			// menuStrip1
			// 
			menuStrip1.Anchor = AnchorStyles.None;
			menuStrip1.AutoSize = false;
			menuStrip1.Dock = DockStyle.None;
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new Point(0, 22);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(826, 24);
			menuStrip1.TabIndex = 5;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, outputToolStripMenuItem, closeToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
			openToolStripMenuItem.Size = new Size(189, 22);
			openToolStripMenuItem.Text = "Open";
			openToolStripMenuItem.Click += openToolStripMenuItem_Click;
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
			saveToolStripMenuItem.Size = new Size(189, 22);
			saveToolStripMenuItem.Text = "Save";
			saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
			// 
			// saveAsToolStripMenuItem
			// 
			saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
			saveAsToolStripMenuItem.Size = new Size(189, 22);
			saveAsToolStripMenuItem.Text = "SaveAs";
			saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
			// 
			// outputToolStripMenuItem
			// 
			outputToolStripMenuItem.Name = "outputToolStripMenuItem";
			outputToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
			outputToolStripMenuItem.Size = new Size(189, 22);
			outputToolStripMenuItem.Text = "Output&&Close";
			outputToolStripMenuItem.Click += outputToolStripMenuItem_Click;
			// 
			// closeToolStripMenuItem
			// 
			closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			closeToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
			closeToolStripMenuItem.Size = new Size(189, 22);
			closeToolStripMenuItem.Text = "Close";
			closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
			// 
			// CTextFileDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = Color.FromArgb(32, 32, 32);
			ClientSize = new Size(826, 477);
			Controls.Add(btnCancel);
			Controls.Add(btnOutput);
			Controls.Add(textBox1);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			MinimizeBox = false;
			Name = "CTextFileDialog";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "TextFileDialog";
			TopMost = true;
			FormClosed += CTextFileDialog_FormClosed;
			Load += CTextFileDialog_Load;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private Button btnCancel;
		private Button btnOutput;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripMenuItem saveToolStripMenuItem;
		private ToolStripMenuItem saveAsToolStripMenuItem;
		private ToolStripMenuItem closeToolStripMenuItem;
		private ToolStripMenuItem outputToolStripMenuItem;
	}
}
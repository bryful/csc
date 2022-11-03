namespace csc
{
	partial class CSelectFolder
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSelectFolder));
			this.tnTargetDir = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.dirFileListBox1 = new csc.DirFileListBox();
			this.directoryListBox1 = new csc.DirectoryListBox();
			this.tbDir = new System.Windows.Forms.TextBox();
			this.driveListBox1 = new csc.DriveListBox();
			this.btnParent = new System.Windows.Forms.Button();
			this.btnRoot = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.btnDeskTop = new System.Windows.Forms.Button();
			this.btnDoc = new System.Windows.Forms.Button();
			this.btnDownload = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tnTargetDir
			// 
			this.tnTargetDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tnTargetDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tnTargetDir.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tnTargetDir.Location = new System.Drawing.Point(12, 442);
			this.tnTargetDir.Name = "tnTargetDir";
			this.tnTargetDir.ReadOnly = true;
			this.tnTargetDir.Size = new System.Drawing.Size(756, 16);
			this.tnTargetDir.TabIndex = 2;
			this.tnTargetDir.Text = "C:\\Bin";
			this.tnTargetDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(632, 476);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(155, 42);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "Select Directory";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(473, 476);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(155, 42);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cansel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// dirFileListBox1
			// 
			this.dirFileListBox1.Current = ((System.IO.DirectoryInfo)(resources.GetObject("dirFileListBox1.Current")));
			this.dirFileListBox1.CurrentPath = "C:\\Bin";
			this.dirFileListBox1.DirectoryListBox = this.directoryListBox1;
			this.dirFileListBox1.DirTextBox = this.tnTargetDir;
			this.dirFileListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dirFileListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.dirFileListBox1.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.dirFileListBox1.FormattingEnabled = true;
			this.dirFileListBox1.ItemHeight = 20;
			this.dirFileListBox1.Location = new System.Drawing.Point(0, 0);
			this.dirFileListBox1.Name = "dirFileListBox1";
			this.dirFileListBox1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.dirFileListBox1.Size = new System.Drawing.Size(325, 392);
			this.dirFileListBox1.TabIndex = 15;
			// 
			// directoryListBox1
			// 
			this.directoryListBox1.Current = ((System.IO.DirectoryInfo)(resources.GetObject("directoryListBox1.Current")));
			this.directoryListBox1.CurrentPath = "C:\\";
			this.directoryListBox1.DesktopBtn = this.btnDeskTop;
			this.directoryListBox1.DirectryTextBox = this.tbDir;
			this.directoryListBox1.DirFileListBox = this.dirFileListBox1;
			this.directoryListBox1.DocBtn = this.btnDoc;
			this.directoryListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.directoryListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.directoryListBox1.DriveListBox = this.driveListBox1;
			this.directoryListBox1.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.directoryListBox1.FormattingEnabled = true;
			this.directoryListBox1.ItemHeight = 20;
			this.directoryListBox1.Items.AddRange(new object[] {
            "AITEMP",
            "Bin",
            "eSupport",
            "lbr",
            "MediaServer",
            "OpenToonz stuff",
            "PerfLogs",
            "Program Files",
            "Program Files (x86)",
            "Qt",
            "Themes",
            "Users",
            "VNTApp",
            "Windows"});
			this.directoryListBox1.Location = new System.Drawing.Point(0, 0);
			this.directoryListBox1.Name = "directoryListBox1";
			this.directoryListBox1.ParentBtn = this.btnParent;
			this.directoryListBox1.RootBtn = this.btnRoot;
			this.directoryListBox1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.directoryListBox1.Size = new System.Drawing.Size(280, 392);
			this.directoryListBox1.TabIndex = 16;
			this.directoryListBox1.UserBtn = this.btnDownload;
			// 
			// tbDir
			// 
			this.tbDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbDir.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tbDir.Location = new System.Drawing.Point(12, 12);
			this.tbDir.Name = "tbDir";
			this.tbDir.ReadOnly = true;
			this.tbDir.Size = new System.Drawing.Size(440, 16);
			this.tbDir.TabIndex = 20;
			this.tbDir.Text = "C:\\";
			this.tbDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// driveListBox1
			// 
			this.driveListBox1.DirectoryListBox = this.directoryListBox1;
			this.driveListBox1.DirectoryName = "C:\\";
			this.driveListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.driveListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.driveListBox1.Drives = new string[] {
        "C:\\",
        "D:\\",
        "E:\\",
        "F:\\",
        "G:\\",
        "H:\\",
        "Y:\\",
        "Z:\\"};
			this.driveListBox1.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.driveListBox1.FormattingEnabled = true;
			this.driveListBox1.ItemHeight = 18;
			this.driveListBox1.Items.AddRange(new object[] {
            "C (OS)",
            "D (SSD-D)",
            "E (HDD4T01)",
            "F (HDD4T-02)",
            "G (500G)",
            "H (HDD6T)",
            "Y (sv02)",
            "Z (sv01)"});
			this.driveListBox1.Location = new System.Drawing.Point(0, 0);
			this.driveListBox1.Name = "driveListBox1";
			this.driveListBox1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.driveListBox1.Size = new System.Drawing.Size(150, 392);
			this.driveListBox1.TabIndex = 11;
			// 
			// btnParent
			// 
			this.btnParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnParent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnParent.Location = new System.Drawing.Point(633, 9);
			this.btnParent.Name = "btnParent";
			this.btnParent.Size = new System.Drawing.Size(154, 28);
			this.btnParent.TabIndex = 18;
			this.btnParent.Text = "To Parent";
			this.btnParent.UseVisualStyleBackColor = true;
			// 
			// btnRoot
			// 
			this.btnRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRoot.Location = new System.Drawing.Point(473, 9);
			this.btnRoot.Name = "btnRoot";
			this.btnRoot.Size = new System.Drawing.Size(154, 28);
			this.btnRoot.TabIndex = 19;
			this.btnRoot.Text = "To Root";
			this.btnRoot.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 44);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.driveListBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(775, 392);
			this.splitContainer1.SplitterDistance = 150;
			this.splitContainer1.SplitterWidth = 10;
			this.splitContainer1.TabIndex = 17;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.directoryListBox1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.dirFileListBox1);
			this.splitContainer2.Size = new System.Drawing.Size(615, 392);
			this.splitContainer2.SplitterDistance = 280;
			this.splitContainer2.SplitterWidth = 10;
			this.splitContainer2.TabIndex = 0;
			// 
			// btnDeskTop
			// 
			this.btnDeskTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDeskTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDeskTop.Location = new System.Drawing.Point(8, 483);
			this.btnDeskTop.Name = "btnDeskTop";
			this.btnDeskTop.Size = new System.Drawing.Size(96, 28);
			this.btnDeskTop.TabIndex = 21;
			this.btnDeskTop.Text = "To Desktop";
			this.btnDeskTop.UseVisualStyleBackColor = true;
			// 
			// btnDoc
			// 
			this.btnDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDoc.Location = new System.Drawing.Point(110, 483);
			this.btnDoc.Name = "btnDoc";
			this.btnDoc.Size = new System.Drawing.Size(94, 28);
			this.btnDoc.TabIndex = 22;
			this.btnDoc.Text = "To Document";
			this.btnDoc.UseVisualStyleBackColor = true;
			// 
			// btnDownload
			// 
			this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDownload.Location = new System.Drawing.Point(210, 483);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(94, 28);
			this.btnDownload.TabIndex = 23;
			this.btnDownload.Text = "To User";
			this.btnDownload.UseVisualStyleBackColor = true;
			// 
			// CSelectFolder
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(799, 541);
			this.Controls.Add(this.btnDownload);
			this.Controls.Add(this.btnDoc);
			this.Controls.Add(this.btnDeskTop);
			this.Controls.Add(this.tbDir);
			this.Controls.Add(this.btnRoot);
			this.Controls.Add(this.btnParent);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tnTargetDir);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 500);
			this.Name = "CSelectFolder";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Folder Dialog";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox tnTargetDir;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private DriveListBox driveListBox1;
		private DirFileListBox dirFileListBox1;
		private DirectoryListBox directoryListBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button btnParent;
		private System.Windows.Forms.Button btnRoot;
		private System.Windows.Forms.TextBox tbDir;
		private System.Windows.Forms.Button btnDeskTop;
		private System.Windows.Forms.Button btnDoc;
		private System.Windows.Forms.Button btnDownload;
	}
}
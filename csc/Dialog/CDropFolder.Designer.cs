
namespace csc
{
	partial class CDropFolder
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDropFolder));
			label1 = new Label();
			btnClose = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label1.Font = new Font("MS UI Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(12, 36);
			label1.Name = "label1";
			label1.Size = new Size(575, 244);
			label1.TabIndex = 0;
			label1.Text = "ここにフォルダをドラッグ";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnClose
			// 
			btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnClose.FlatStyle = FlatStyle.Flat;
			btnClose.Location = new Point(495, 283);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(75, 23);
			btnClose.TabIndex = 1;
			btnClose.Text = "close";
			btnClose.UseVisualStyleBackColor = true;
			// 
			// CDropFolder
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(599, 318);
			Controls.Add(btnClose);
			Controls.Add(label1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "CDropFolder";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "DropFolder";
			TopMost = true;
			FormClosed += CDropFolder_FormClosed;
			Load += CDropFolder_Load;
			DragDrop += CDropFolder_DragDrop;
			DragEnter += CDropFolder_DragEnter;
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private Button btnClose;
	}
}
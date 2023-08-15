
namespace csc
{
	partial class CLineEditDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLineEditDialog));
			textBox1 = new TextBox();
			btnOK = new Button();
			btnCancel = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox1.Font = new Font("ＭＳ ゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			textBox1.Location = new Point(33, 62);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(392, 26);
			textBox1.TabIndex = 0;
			// 
			// btnOK
			// 
			btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnOK.DialogResult = DialogResult.OK;
			btnOK.FlatStyle = FlatStyle.Flat;
			btnOK.Location = new Point(350, 105);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.FlatStyle = FlatStyle.Flat;
			btnCancel.Location = new Point(269, 105);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(33, 43);
			label1.Name = "label1";
			label1.Size = new Size(45, 16);
			label1.TabIndex = 3;
			label1.Text = "label1";
			// 
			// CLineEditDialog
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(9F, 16F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(467, 150);
			Controls.Add(label1);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			Controls.Add(textBox1);
			Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4);
			MaximizeBox = false;
			MaximumSize = new Size(5000, 150);
			MinimizeBox = false;
			MinimumSize = new Size(150, 150);
			Name = "CLineEditDialog";
			ShowIcon = false;
			Text = "EditDialog";
			TopMost = true;
			FormClosed += CLineEditDialog_FormClosed;
			Load += CLineEditDialog_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private Button btnOK;
		private Button btnCancel;
		private Label label1;
	}
}
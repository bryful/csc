
namespace csc
{
	partial class CAlert
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAlert));
			btnOK = new Button();
			webBrowser1 = new WebBrowser();
			SuspendLayout();
			// 
			// btnOK
			// 
			btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnOK.FlatStyle = FlatStyle.Flat;
			btnOK.ForeColor = Color.White;
			btnOK.Location = new Point(294, 165);
			btnOK.Margin = new Padding(4);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(113, 32);
			btnOK.TabIndex = 1;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// webBrowser1
			// 
			webBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			webBrowser1.Location = new Point(13, 39);
			webBrowser1.Margin = new Padding(4);
			webBrowser1.MinimumSize = new Size(30, 27);
			webBrowser1.Name = "webBrowser1";
			webBrowser1.Size = new Size(394, 119);
			webBrowser1.TabIndex = 2;
			// 
			// CAlert
			// 
			AutoScaleDimensions = new SizeF(9F, 16F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(100, 100, 100);
			ClientSize = new Size(431, 210);
			Controls.Add(webBrowser1);
			Controls.Add(btnOK);
			Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "CAlert";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Alert";
			TopMost = true;
			ResumeLayout(false);
		}

		#endregion
		private Button btnOK;
		private WebBrowser webBrowser1;
	}
}


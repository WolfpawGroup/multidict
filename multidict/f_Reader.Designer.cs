namespace multidict
{
	partial class f_Reader
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
			this.lbl_Word = new System.Windows.Forms.Label();
			this.lbl_Dict = new System.Windows.Forms.Label();
			this.lbl_Translation = new System.Windows.Forms.WebBrowser();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_Close = new System.Windows.Forms.Button();
			this.btn_Copy = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.cb_CopyAs = new System.Windows.Forms.ComboBox();
			this.cb_AppendData = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// lbl_Word
			// 
			this.lbl_Word.AutoSize = true;
			this.lbl_Word.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_Word.Location = new System.Drawing.Point(81, 7);
			this.lbl_Word.Name = "lbl_Word";
			this.lbl_Word.Size = new System.Drawing.Size(0, 27);
			this.lbl_Word.TabIndex = 0;
			// 
			// lbl_Dict
			// 
			this.lbl_Dict.AutoSize = true;
			this.lbl_Dict.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_Dict.Location = new System.Drawing.Point(83, 61);
			this.lbl_Dict.Name = "lbl_Dict";
			this.lbl_Dict.Size = new System.Drawing.Size(0, 18);
			this.lbl_Dict.TabIndex = 1;
			// 
			// lbl_Translation
			// 
			this.lbl_Translation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_Translation.Location = new System.Drawing.Point(83, 112);
			this.lbl_Translation.Name = "lbl_Translation";
			this.lbl_Translation.ScriptErrorsSuppressed = true;
			this.lbl_Translation.Size = new System.Drawing.Size(750, 434);
			this.lbl_Translation.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Word: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "From: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Translation: ";
			// 
			// btn_Close
			// 
			this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Close.Location = new System.Drawing.Point(733, 559);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(100, 23);
			this.btn_Close.TabIndex = 6;
			this.btn_Close.Text = "Close Window";
			this.btn_Close.UseVisualStyleBackColor = true;
			// 
			// btn_Copy
			// 
			this.btn_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Copy.Location = new System.Drawing.Point(15, 559);
			this.btn_Copy.Name = "btn_Copy";
			this.btn_Copy.Size = new System.Drawing.Size(90, 23);
			this.btn_Copy.TabIndex = 7;
			this.btn_Copy.Text = "Copy Data";
			this.btn_Copy.UseVisualStyleBackColor = true;
			this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(111, 564);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(18, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "as";
			// 
			// cb_CopyAs
			// 
			this.cb_CopyAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_CopyAs.FormattingEnabled = true;
			this.cb_CopyAs.Items.AddRange(new object[] {
            "clear text ( \\r\\n )",
            "CSW ( ; )",
            "XML",
            "JSON",
            "YAML",
            "MessagePack (Base64)",
            "MessagePack (HEX values)"});
			this.cb_CopyAs.Location = new System.Drawing.Point(135, 561);
			this.cb_CopyAs.Name = "cb_CopyAs";
			this.cb_CopyAs.Size = new System.Drawing.Size(121, 21);
			this.cb_CopyAs.TabIndex = 9;
			// 
			// cb_AppendData
			// 
			this.cb_AppendData.AutoSize = true;
			this.cb_AppendData.Location = new System.Drawing.Point(262, 564);
			this.cb_AppendData.Name = "cb_AppendData";
			this.cb_AppendData.Size = new System.Drawing.Size(63, 17);
			this.cb_AppendData.TabIndex = 10;
			this.cb_AppendData.Text = "Append";
			this.cb_AppendData.UseVisualStyleBackColor = true;
			// 
			// f_Reader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(845, 594);
			this.Controls.Add(this.cb_AppendData);
			this.Controls.Add(this.cb_CopyAs);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btn_Copy);
			this.Controls.Add(this.btn_Close);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbl_Translation);
			this.Controls.Add(this.lbl_Dict);
			this.Controls.Add(this.lbl_Word);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "f_Reader";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_Word;
		private System.Windows.Forms.Label lbl_Dict;
		private System.Windows.Forms.WebBrowser lbl_Translation;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_Close;
		private System.Windows.Forms.Button btn_Copy;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cb_CopyAs;
		private System.Windows.Forms.CheckBox cb_AppendData;
	}
}
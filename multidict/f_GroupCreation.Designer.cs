namespace multidict
{
	partial class f_GroupCreation
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
			this.lv_Dictionaries = new System.Windows.Forms.ListView();
			this.ch_Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_DictionaryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.tb_Name = new System.Windows.Forms.TextBox();
			this.btn_Add = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lv_Dictionaries
			// 
			this.lv_Dictionaries.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lv_Dictionaries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lv_Dictionaries.CheckBoxes = true;
			this.lv_Dictionaries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Index,
            this.ch_DictionaryName});
			this.lv_Dictionaries.FullRowSelect = true;
			this.lv_Dictionaries.GridLines = true;
			this.lv_Dictionaries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lv_Dictionaries.HideSelection = false;
			this.lv_Dictionaries.Location = new System.Drawing.Point(12, 12);
			this.lv_Dictionaries.Name = "lv_Dictionaries";
			this.lv_Dictionaries.Size = new System.Drawing.Size(369, 185);
			this.lv_Dictionaries.TabIndex = 4;
			this.lv_Dictionaries.UseCompatibleStateImageBehavior = false;
			this.lv_Dictionaries.View = System.Windows.Forms.View.Details;
			// 
			// ch_Index
			// 
			this.ch_Index.Text = "#";
			this.ch_Index.Width = 42;
			// 
			// ch_DictionaryName
			// 
			this.ch_DictionaryName.Text = "Dictionary";
			this.ch_DictionaryName.Width = 300;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 214);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "List Name: ";
			// 
			// tb_Name
			// 
			this.tb_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tb_Name.Location = new System.Drawing.Point(78, 211);
			this.tb_Name.Name = "tb_Name";
			this.tb_Name.Size = new System.Drawing.Size(303, 20);
			this.tb_Name.TabIndex = 6;
			this.tb_Name.Text = "New List";
			this.tb_Name.Click += new System.EventHandler(this.tb_Name_Click);
			// 
			// btn_Add
			// 
			this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Add.Location = new System.Drawing.Point(12, 250);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(75, 23);
			this.btn_Add.TabIndex = 7;
			this.btn_Add.Text = "Add";
			this.btn_Add.UseVisualStyleBackColor = true;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Cancel.Location = new System.Drawing.Point(306, 250);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 8;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// f_GroupCreation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(393, 282);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Add);
			this.Controls.Add(this.tb_Name);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lv_Dictionaries);
			this.Name = "f_GroupCreation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Group";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lv_Dictionaries;
		private System.Windows.Forms.ColumnHeader ch_Index;
		private System.Windows.Forms.ColumnHeader ch_DictionaryName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_Name;
		private System.Windows.Forms.Button btn_Add;
		private System.Windows.Forms.Button btn_Cancel;
	}
}
using System.Windows.Forms;
using System;

namespace multidict
{
	partial class Form1
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
			this.label1 = new System.Windows.Forms.Label();
			this.cb_Search = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lv_Dictionaries = new System.Windows.Forms.ListView();
			this.ch_Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_DictionaryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_Search = new System.Windows.Forms.Button();
			this.lv_Results = new System.Windows.Forms.ListView();
			this.ch_Result_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_Result_From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_Result_Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Search: ";
			// 
			// cb_Search
			// 
			this.cb_Search.FormattingEnabled = true;
			this.cb_Search.Location = new System.Drawing.Point(87, 6);
			this.cb_Search.Name = "cb_Search";
			this.cb_Search.Size = new System.Drawing.Size(327, 21);
			this.cb_Search.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Dictionaries: ";
			// 
			// lv_Dictionaries
			// 
			this.lv_Dictionaries.CheckBoxes = true;
			this.lv_Dictionaries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Index,
            this.ch_DictionaryName});
			this.lv_Dictionaries.FullRowSelect = true;
			this.lv_Dictionaries.GridLines = true;
			this.lv_Dictionaries.Location = new System.Drawing.Point(86, 33);
			this.lv_Dictionaries.Name = "lv_Dictionaries";
			this.lv_Dictionaries.Size = new System.Drawing.Size(328, 133);
			this.lv_Dictionaries.TabIndex = 3;
			this.lv_Dictionaries.UseCompatibleStateImageBehavior = false;
			this.lv_Dictionaries.View = System.Windows.Forms.View.Details;
			// 
			// ch_Index
			// 
			this.ch_Index.Text = "#";
			this.ch_Index.Width = 30;
			// 
			// ch_DictionaryName
			// 
			this.ch_DictionaryName.Text = "Dictionary";
			this.ch_DictionaryName.Width = 293;
			// 
			// btn_Search
			// 
			this.btn_Search.Location = new System.Drawing.Point(15, 143);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(65, 23);
			this.btn_Search.TabIndex = 4;
			this.btn_Search.Text = "Search (TEST)";
			this.btn_Search.UseVisualStyleBackColor = true;
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// lv_Results
			// 
			this.lv_Results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Result_id,
            this.ch_Result_From,
            this.ch_Result_Data});
			this.lv_Results.FullRowSelect = true;
			this.lv_Results.GridLines = true;
			this.lv_Results.Location = new System.Drawing.Point(15, 172);
			this.lv_Results.Name = "lv_Results";
			this.lv_Results.Size = new System.Drawing.Size(773, 266);
			this.lv_Results.TabIndex = 5;
			this.lv_Results.UseCompatibleStateImageBehavior = false;
			this.lv_Results.View = System.Windows.Forms.View.Details;
			this.lv_Results.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_Results_MouseDoubleClick);
			// 
			// ch_Result_id
			// 
			this.ch_Result_id.Text = "#";
			this.ch_Result_id.Width = 30;
			// 
			// ch_Result_From
			// 
			this.ch_Result_From.Text = "Dictionary";
			this.ch_Result_From.Width = 331;
			// 
			// ch_Result_Data
			// 
			this.ch_Result_Data.Text = "Result";
			this.ch_Result_Data.Width = 406;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lv_Results);
			this.Controls.Add(this.btn_Search);
			this.Controls.Add(this.lv_Dictionaries);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cb_Search);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cb_Search;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lv_Dictionaries;
		private System.Windows.Forms.ColumnHeader ch_Index;
		private System.Windows.Forms.ColumnHeader ch_DictionaryName;
		private System.Windows.Forms.Button btn_Search;
		private System.Windows.Forms.ListView lv_Results;
		private System.Windows.Forms.ColumnHeader ch_Result_id;
		private System.Windows.Forms.ColumnHeader ch_Result_From;
		private System.Windows.Forms.ColumnHeader ch_Result_Data;
	}
}


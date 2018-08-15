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
			this.components = new System.ComponentModel.Container();
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
			this.btn_Exit = new System.Windows.Forms.Button();
			this.cb_Clear = new System.Windows.Forms.CheckBox();
			this.cms_Dicts = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.btn_Dicts_UncheckAll = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_Dicts_CheckAll = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_Dicts_Sep1 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_Dicts_Groups = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_Dicts_CheckDefaultGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_Dicts_Sep2 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_Dicts_CheckFromEnglish = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_Dicts_CheckToEnglish = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_Dicts_Sep3 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_Dicts_CheckInvert = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_Dicts_CheckUtil = new System.Windows.Forms.ToolStripMenuItem();
			this.cms_Dicts.SuspendLayout();
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
			this.cb_Search.Size = new System.Drawing.Size(360, 21);
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
			this.lv_Dictionaries.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lv_Dictionaries.CheckBoxes = true;
			this.lv_Dictionaries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Index,
            this.ch_DictionaryName});
			this.lv_Dictionaries.ContextMenuStrip = this.cms_Dicts;
			this.lv_Dictionaries.FullRowSelect = true;
			this.lv_Dictionaries.GridLines = true;
			this.lv_Dictionaries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lv_Dictionaries.HideSelection = false;
			this.lv_Dictionaries.Location = new System.Drawing.Point(86, 33);
			this.lv_Dictionaries.Name = "lv_Dictionaries";
			this.lv_Dictionaries.Size = new System.Drawing.Size(361, 133);
			this.lv_Dictionaries.TabIndex = 3;
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
			this.ch_DictionaryName.Width = 311;
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
			this.lv_Results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lv_Results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Result_id,
            this.ch_Result_From,
            this.ch_Result_Data});
			this.lv_Results.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lv_Results.FullRowSelect = true;
			this.lv_Results.GridLines = true;
			this.lv_Results.Location = new System.Drawing.Point(15, 172);
			this.lv_Results.Name = "lv_Results";
			this.lv_Results.Size = new System.Drawing.Size(773, 249);
			this.lv_Results.TabIndex = 5;
			this.lv_Results.UseCompatibleStateImageBehavior = false;
			this.lv_Results.View = System.Windows.Forms.View.Details;
			this.lv_Results.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_Results_MouseDoubleClick);
			// 
			// ch_Result_id
			// 
			this.ch_Result_id.Text = "#";
			this.ch_Result_id.Width = 39;
			// 
			// ch_Result_From
			// 
			this.ch_Result_From.Text = "Dictionary";
			this.ch_Result_From.Width = 323;
			// 
			// ch_Result_Data
			// 
			this.ch_Result_Data.Text = "Result";
			this.ch_Result_Data.Width = 406;
			// 
			// btn_Exit
			// 
			this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Exit.Location = new System.Drawing.Point(667, 425);
			this.btn_Exit.Name = "btn_Exit";
			this.btn_Exit.Size = new System.Drawing.Size(121, 23);
			this.btn_Exit.TabIndex = 6;
			this.btn_Exit.Text = "Exit";
			this.btn_Exit.UseVisualStyleBackColor = true;
			// 
			// cb_Clear
			// 
			this.cb_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cb_Clear.AutoSize = true;
			this.cb_Clear.Checked = true;
			this.cb_Clear.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cb_Clear.Location = new System.Drawing.Point(15, 425);
			this.cb_Clear.Name = "cb_Clear";
			this.cb_Clear.Size = new System.Drawing.Size(174, 17);
			this.cb_Clear.TabIndex = 7;
			this.cb_Clear.Text = "Clear results before new search";
			this.cb_Clear.UseVisualStyleBackColor = true;
			// 
			// cms_Dicts
			// 
			this.cms_Dicts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Dicts_CheckAll,
            this.btn_Dicts_UncheckAll,
            this.btn_Dicts_Sep1,
            this.btn_Dicts_Groups,
            this.btn_Dicts_CheckDefaultGroup,
            this.btn_Dicts_Sep2,
            this.btn_Dicts_CheckUtil,
            this.btn_Dicts_CheckFromEnglish,
            this.btn_Dicts_CheckToEnglish,
            this.btn_Dicts_Sep3,
            this.btn_Dicts_CheckInvert});
			this.cms_Dicts.Name = "cms_Dicts";
			this.cms_Dicts.Size = new System.Drawing.Size(207, 220);
			// 
			// btn_Dicts_UncheckAll
			// 
			this.btn_Dicts_UncheckAll.Name = "btn_Dicts_UncheckAll";
			this.btn_Dicts_UncheckAll.Size = new System.Drawing.Size(206, 22);
			this.btn_Dicts_UncheckAll.Text = "Uncheck All";
			this.btn_Dicts_UncheckAll.Click += new System.EventHandler(this.btn_Dicts_UncheckAll_Click);
			// 
			// btn_Dicts_CheckAll
			// 
			this.btn_Dicts_CheckAll.Name = "btn_Dicts_CheckAll";
			this.btn_Dicts_CheckAll.Size = new System.Drawing.Size(206, 22);
			this.btn_Dicts_CheckAll.Text = "Check All";
			this.btn_Dicts_CheckAll.Click += new System.EventHandler(this.btn_Dicts_CheckAll_Click);
			// 
			// btn_Dicts_Sep1
			// 
			this.btn_Dicts_Sep1.Name = "btn_Dicts_Sep1";
			this.btn_Dicts_Sep1.Size = new System.Drawing.Size(203, 6);
			// 
			// btn_Dicts_Groups
			// 
			this.btn_Dicts_Groups.Name = "btn_Dicts_Groups";
			this.btn_Dicts_Groups.Size = new System.Drawing.Size(206, 22);
			this.btn_Dicts_Groups.Text = "Groups";
			// 
			// btn_Dicts_CheckDefaultGroup
			// 
			this.btn_Dicts_CheckDefaultGroup.Name = "btn_Dicts_CheckDefaultGroup";
			this.btn_Dicts_CheckDefaultGroup.Size = new System.Drawing.Size(206, 22);
			this.btn_Dicts_CheckDefaultGroup.Text = "Check Default";
			// 
			// btn_Dicts_Sep2
			// 
			this.btn_Dicts_Sep2.Name = "btn_Dicts_Sep2";
			this.btn_Dicts_Sep2.Size = new System.Drawing.Size(203, 6);
			// 
			// btn_Dicts_CheckFromEnglish
			// 
			this.btn_Dicts_CheckFromEnglish.Name = "btn_Dicts_CheckFromEnglish";
			this.btn_Dicts_CheckFromEnglish.Size = new System.Drawing.Size(206, 22);
			this.btn_Dicts_CheckFromEnglish.Text = "Check all \'From English\'";
			this.btn_Dicts_CheckFromEnglish.Click += new System.EventHandler(this.btn_Dicts_CheckFromEnglish_Click);
			// 
			// btn_Dicts_CheckToEnglish
			// 
			this.btn_Dicts_CheckToEnglish.Name = "btn_Dicts_CheckToEnglish";
			this.btn_Dicts_CheckToEnglish.Size = new System.Drawing.Size(206, 22);
			this.btn_Dicts_CheckToEnglish.Text = "Check all \'To English\'";
			this.btn_Dicts_CheckToEnglish.Click += new System.EventHandler(this.btn_Dicts_CheckToEnglish_Click);
			// 
			// btn_Dicts_Sep3
			// 
			this.btn_Dicts_Sep3.Name = "btn_Dicts_Sep3";
			this.btn_Dicts_Sep3.Size = new System.Drawing.Size(203, 6);
			// 
			// btn_Dicts_CheckInvert
			// 
			this.btn_Dicts_CheckInvert.Name = "btn_Dicts_CheckInvert";
			this.btn_Dicts_CheckInvert.Size = new System.Drawing.Size(206, 22);
			this.btn_Dicts_CheckInvert.Text = "Invert Selection";
			this.btn_Dicts_CheckInvert.Click += new System.EventHandler(this.btn_Dicts_CheckInvert_Click);
			// 
			// btn_Dicts_CheckUtil
			// 
			this.btn_Dicts_CheckUtil.Name = "btn_Dicts_CheckUtil";
			this.btn_Dicts_CheckUtil.Size = new System.Drawing.Size(206, 22);
			this.btn_Dicts_CheckUtil.Text = "Check Utility Dictionaries";
			this.btn_Dicts_CheckUtil.Click += new System.EventHandler(this.btn_Dicts_CheckUtil_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cb_Clear);
			this.Controls.Add(this.lv_Dictionaries);
			this.Controls.Add(this.btn_Exit);
			this.Controls.Add(this.lv_Results);
			this.Controls.Add(this.btn_Search);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cb_Search);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.cms_Dicts.ResumeLayout(false);
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
		private Button btn_Exit;
		private CheckBox cb_Clear;
		private ContextMenuStrip cms_Dicts;
		private ToolStripMenuItem btn_Dicts_CheckAll;
		private ToolStripMenuItem btn_Dicts_UncheckAll;
		private ToolStripSeparator btn_Dicts_Sep1;
		private ToolStripMenuItem btn_Dicts_Groups;
		private ToolStripMenuItem btn_Dicts_CheckDefaultGroup;
		private ToolStripSeparator btn_Dicts_Sep2;
		private ToolStripMenuItem btn_Dicts_CheckFromEnglish;
		private ToolStripMenuItem btn_Dicts_CheckToEnglish;
		private ToolStripSeparator btn_Dicts_Sep3;
		private ToolStripMenuItem btn_Dicts_CheckInvert;
		private ToolStripMenuItem btn_Dicts_CheckUtil;
	}
}


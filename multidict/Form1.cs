﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multidict
{
	public partial class Form1 : Form
	{
		c_Api api = new c_Api();
		Dictionary<string, string> lvis = new Dictionary<string, string>();

		public Form1()
		{
			InitializeComponent();
			Load += Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.s_UseOnlineDatabases)
			{
				ListViewItem[] lvia = api.getItems().ToArray();
				foreach(ListViewItem l in lvia) { try { lvis.Add(l.SubItems[0].Text, l.SubItems[2].Text); } catch { } }
				lv_Dictionaries.Items.AddRange(lvia);
			}

			loadLastSearches();
		}

		public void loadLastSearches()
		{
			cb_Search.Items.Clear();
			string[] lsts = new string[Properties.Settings.Default.s_LastSearches.Count];
			Properties.Settings.Default.s_LastSearches.CopyTo(lsts, 0);
			lsts = lsts.Reverse().ToArray();
			cb_Search.Items.AddRange(lsts);
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			if (cb_Search.Text != "")
			{
				string[] lsts = new string[Properties.Settings.Default.s_LastSearches.Count];
				Properties.Settings.Default.s_LastSearches.CopyTo(lsts, 0);

				if (lsts.Select(x => x.ToLower()).Contains(cb_Search.Text.ToLower()))
				{
					Properties.Settings.Default.s_LastSearches.RemoveAt(lsts.Select(x => x.ToLower()).ToList().IndexOf(cb_Search.Text.ToLower()));
				}
				Properties.Settings.Default.s_LastSearches.Add(cb_Search.Text);
				Properties.Settings.Default.Save();
				loadLastSearches();

				if (lv_Dictionaries.CheckedItems.Count > 0 || lv_Dictionaries.FocusedItem != null)
				{
					if (cb_Clear.Checked) { lv_Results.Items.Clear(); }

					List<string> dicts = new List<string>();
					List<string> words = new List<string>();

					ListViewItem[] lvis = new ListViewItem[lv_Dictionaries.CheckedItems.Count];
					lv_Dictionaries.CheckedItems.CopyTo(lvis, 0);
					List<ListViewItem> checkedItems = lvis.ToList();

					if (lv_Dictionaries.CheckedItems.Count > 0)
					{
						foreach (string s in checkedItems.Select(x => x.Tag))
						{
							dicts.Add(s);
						}
					}
					else
					{
						dicts.Add(lv_Dictionaries.FocusedItem.Tag.ToString());
					}

					words = cb_Search.Text.Split(' ').ToList();

					foreach (String word in words)
					{
						ListViewItem lvi0 = new ListViewItem(new string[] { "", word, "" });
						lvi0.BackColor = Color.LightSkyBlue;
						lvi0.Tag = new string[] { word, "NO DATA", "NO DATA" };
						lv_Results.Items.Add(lvi0);
						foreach (List<string[]> ret in api.getTranslations(dicts, word))
						{
							foreach (string[] rret in ret)
							{
								ListViewItem lvi = new ListViewItem();
								lvi.BackColor = lv_Results.Items.Count % 2 == 0 ? Color.LightYellow : Color.WhiteSmoke;
								lvi.Text = ((lv_Results.Items.Count + 1) + "");
								lvi.SubItems.Add(rret[0]);
								lvi.SubItems.Add(rret[1]);
								lvi.Tag = new string[] { word, rret[0], rret[1] };
								lv_Results.Items.Add(lvi);
							}
						}

					}
				}
			}
		}

		private void lv_Results_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && lv_Results.FocusedItem != null)
			{
				foreach(ListViewItem lvi in lv_Results.Items)
				{
					if (lvi.SubItems[0].Text.StartsWith("-► ")) { lvi.SubItems[0].Text = lvi.SubItems[0].Text.Replace("-► ", ""); }
				}

				ListViewItem l = lv_Results.FocusedItem;

				string[] str = (string[])l.Tag;

				int i = 0;
				f_Reader frm = null;
				foreach(Form f in Application.OpenForms)
				{
					if (f is f_Reader)
					{
						i++;
						frm = (f_Reader)f;
					}
				}

				if(i == 0)
				{
					frm = new f_Reader();
					frm.Show();
				}
				else
				{
					frm.Show();
				}

				lv_Results.FocusedItem.SubItems[0].Text = lv_Results.FocusedItem.SubItems[0].Text.Insert(0, "-► ");
				ch_Result_id.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				frm.setdata(str[0], str[2], str[1]);
			}
		}

		private void btn_Dicts_CheckAll_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lv_Dictionaries.Items)
			{
				item.Checked = true;
			}
		}

		private void btn_Dicts_UncheckAll_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lv_Dictionaries.Items)
			{
				item.Checked = false;
			}
		}

		private void btn_Dicts_CheckInvert_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lv_Dictionaries.Items)
			{
				item.Checked = !item.Checked;
			}
		}

		private void btn_Dicts_CheckUtil_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lv_Dictionaries.Items)
			{
				if (lvis.Where(x=>x.Key == item.SubItems[0].Text).Select(x=>x.Value == "U").Count(x=>x.Equals(true)) > 0)
				{
					item.Checked = !item.Checked;
				}
			}
		}

		private void btn_Dicts_CheckFromEnglish_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lv_Dictionaries.Items)
			{
				if (lvis.Where(x => x.Key == item.SubItems[0].Text).Select(x => x.Value == "E").Count(x => x.Equals(true)) > 0)
				{
					item.Checked = !item.Checked;
				}
			}
		}

		private void btn_Dicts_CheckToEnglish_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lv_Dictionaries.Items)
			{
				if (lvis.Where(x => x.Key == item.SubItems[0].Text).Select(x => x.Value == "O").Count(x => x.Equals(true)) > 0)
				{
					item.Checked = !item.Checked;
				}
			}
		}

		private void cb_Search_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				btn_Search_Click(null, null);
				e.SuppressKeyPress = true;
			}
		}

		private void btn_Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btn_Dicts_SetSelectionAsDefault_Click(object sender, EventArgs e)
		{
			if (lv_Dictionaries.CheckedItems.Count > 0 && MessageBox.Show("You are about to change your default group.\r\n\r\nAre you sure you wish to continue?","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string tmp = "";
				foreach (ListViewItem lvi in lv_Dictionaries.CheckedItems)
				{
					tmp += lvi.Tag.ToString().ToLower() + ";";
				}
				tmp = tmp.Trim(';');
				Properties.Settings.Default.s_DefaultGroup = tmp;
				Properties.Settings.Default.Save();
			}
		}

		private void btn_Dicts_CheckDefaultGroup_Click(object sender, EventArgs e)
		{
			string[] ss = Properties.Settings.Default.s_DefaultGroup.Split(';');
			foreach (ListViewItem lvi in lv_Dictionaries.Items)
			{
				if (ss.Contains(lvi.Tag.ToString().ToLower())) { lvi.Checked = true; }
				else { lvi.Checked = false; }
			}
		}

		private void btn_Dicts_CreateGroupOfSelection_Click(object sender, EventArgs e)
		{
			List<ListViewItem> tmp = new List<ListViewItem>();
			ListViewItem[] lvis = new ListViewItem[lv_Dictionaries.CheckedItems.Count];
			int i = 0;
			foreach (ListViewItem lvi in lv_Dictionaries.CheckedItems)
			{
				lvis[i] = new ListViewItem(new string[]{ lvi.SubItems[0].Text, lvi.SubItems[1].Text, lvi.SubItems[2].Text }) { Checked = true, Tag = lvi.Tag };
				i++;
			}
			
			f_GroupCreation fg = new f_GroupCreation();
			fg.Items = lvis.ToList();
			fg.ShowDialog();
		}

		private void cms_Dicts_Opening(object sender, CancelEventArgs e)
		{
			ToolStripItemCollection ti = null;
			ti = btn_Dicts_Groups.DropDown.Items;
			if (ti.Find("tss", true).Count() >0) { ti.Remove(ti.Find("tss", true)[0]); }
			if (ti.Find("Manage_Groups", true).Count() >0) { ti.Remove(ti.Find("Manage_Groups", true)[0]); }

			foreach (string s in Properties.Settings.Default.s_Groups)
			{
				ToolStripItem t = new ToolStripMenuItem();
				t.Text = s.Substring(0, s.IndexOf(";"));
				t.Name = t.Text;

				if (ti == null || ti.Find(t.Text,true).Count() == 0)
				{
					btn_Dicts_Groups.DropDown.Items.Add(t);
					t.Click += T_Click;
				}
			}

			if (ti != null && ti.Count > 0)
			{
				ToolStripSeparator tss = new ToolStripSeparator();
				tss.Name = "tss";
				ToolStripItem tbtn = new ToolStripMenuItem();
				tbtn.Text = "Manage Groups";
				tbtn.Name = "Manage_Groups";
				btn_Dicts_Groups.DropDown.Items.AddRange(new ToolStripItem[] { tss, tbtn });
				tbtn.Click += Tbtn_Click;
			}
		}

		private void Tbtn_Click(object sender, EventArgs e)
		{
			//TODO:: MANAGE GROUPS
		}

		private void T_Click(object sender, EventArgs e)
		{
			if(sender as ToolStripMenuItem != null)
			{
				string name = (sender as ToolStripMenuItem).Text;

				foreach(string s in Properties.Settings.Default.s_Groups)
				{
					if (s.ToLower().StartsWith(name.ToLower()))
					{
						string[] ss = s.ToLower().Split(';');
						foreach (ListViewItem lvi in lv_Dictionaries.Items)
						{
							if (lvi.Tag.ToString().ToLower() != ss.First())
							{
								if (ss.Contains(lvi.Tag.ToString().ToLower())) { lvi.Checked = true; }
								else { lvi.Checked = false; }
							}
						}

					}
				}
			}
		}

		private void lv_Dictionaries_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			
		}

		private void lv_Dictionaries_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (lv_Dictionaries.CheckedItems.Count == 0)
			{
				btn_Dicts_CreateGroupOfSelection.Enabled = false;
				btn_Dicts_SetSelectionAsDefault.Enabled = false;
				btn_Dicts_UncheckAll.Enabled = false;
				btn_Dicts_CheckAll.Enabled = true;
			}
			else
			{
				btn_Dicts_CreateGroupOfSelection.Enabled = true;
				btn_Dicts_SetSelectionAsDefault.Enabled = true;
				btn_Dicts_UncheckAll.Enabled = true;
				btn_Dicts_CheckAll.Enabled = false;
			}
		}
	}

	public static class string_extension
	{
		/// <summary>
		/// Runs a replace on string with the values in replacenemnts
		/// </summary>
		public static string ArrayReplace(this string str, arrayReplacement[] replacements)
		{
			string s = str;

			foreach (arrayReplacement ar in replacements)
			{
				s = s.Replace(ar.replace_this, ar.with_this);
			}

			return s;
		}

		/// <summary>
		/// Replaces each string in inputArrayA with it's counterpart in inputArrayB
		/// </summary>
		public static string ArrayReplace(this string str, string[] inputArrayA, string[] inputArrayB)
		{
			if (inputArrayA.Length != inputArrayB.Length) { throw new ArgumentException("Exception!\r\nInput array lengths must match!", new Exception()); }
			arrayReplacement[] ara = new arrayReplacement[inputArrayA.Length];

			for (int i = 0; i < inputArrayA.Length; i++)
			{
				ara[i] = new arrayReplacement() { replace_this = inputArrayA[i], with_this = inputArrayB[i] };
			}

			return ArrayReplace(str, ara);
		}

		/// <summary>
		/// Replaces all strings in inputArrayA with inputB
		/// </summary>
		public static string ArrayReplace(this string str, string[] inputArrayA, string inputB)
		{
			string s = str;

			for (int i = 0; i < inputArrayA.Length; i++)
			{
				s = s.Replace(inputArrayA[i], inputB);
			}

			return s;
		}

		/// <summary>
		/// Replaces all strings in inputA (split by |) with inputB
		/// </summary>
		public static string ArrayReplace(this string str, string inputA, string inputB)
		{
			string s = str;

			foreach (string ss in inputA.Split('|'))
			{
				s = s.Replace(ss, inputB);
			}

			return s;
		}

		/// <summary>
		/// Regex Replace where inputA is the regex searched for
		/// </summary>
		public static string RegReplace(this string str, string inputA, string inputB, bool ignoreCase = false, bool multiLine = false, bool singleLine = false, bool ecmaScript = false)
		{
			RegexOptions ro = new RegexOptions();
			if (multiLine) { ro |= RegexOptions.Multiline; }
			if (ignoreCase) { ro |= RegexOptions.IgnoreCase; }
			if (singleLine) { ro |= RegexOptions.Singleline; }
			if (ecmaScript) { ro |= RegexOptions.ECMAScript; }

			Regex r = new Regex(inputA, ro);

			if (r.IsMatch(str))
			{
				str = r.Replace(str, inputB);
			}

			return str;
		}
	}

	public struct arrayReplacement
	{
		public string replace_this { get; set; }
		public string with_this { get; set; }
	}
}

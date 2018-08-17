using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multidict
{
	public partial class f_GroupCreation : Form
	{
		private List<ListViewItem> items = new List<ListViewItem>();
		public List<ListViewItem> Items { get { return items; } set { items = value; loadValues(); } }

		public f_GroupCreation()
		{
			InitializeComponent();
		}

		private void loadValues()
		{
			if(items.Count > 0)
			{
				lv_Dictionaries.Items.AddRange(items.ToArray());
			}
		}

		private void btn_Add_Click(object sender, EventArgs e)
		{
			string name = tb_Name.Text;

			foreach (string s in Properties.Settings.Default.s_Groups) { if (s.ToLower().StartsWith(name.ToLower() + ";")) { MessageBox.Show("A group with the name [" + name + "] already exists.\r\n\r\nPlease select a new name!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } }

			string tmp = "";
			foreach (ListViewItem lvi in lv_Dictionaries.CheckedItems)
			{
				tmp += lvi.Tag.ToString().ToLower() + ";";
			}
			tmp = name + ";" + tmp.Trim(';');
			Properties.Settings.Default.s_Groups.Add(tmp);
			Properties.Settings.Default.Save();
			this.Close();
		}

		private void tb_Name_Click(object sender, EventArgs e)
		{
			if (tb_Name.SelectionLength == 0)
			{
				tb_Name.SelectAll();
			}
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

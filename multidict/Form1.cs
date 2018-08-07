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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			List<string> dicts = new List<string>() {"*", "fd-eng-hun"};
			List<string> words = new List<string>() { "apple"};

			c_Api ap = new c_Api();
			

			foreach(String word in words)
			{
				ListViewItem lvi0 = new ListViewItem(new string[] { "", word, "" });
				lvi0.BackColor = Color.LightSkyBlue;
				lvi0.Tag = new string[] { word, "NO DATA", "NO DATA" };
				lv_Results.Items.Add(lvi0);
				foreach (List<string[]> ret in ap.getTranslations(dicts, word))
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

		private void lv_Results_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && lv_Results.FocusedItem != null)
			{
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

				frm.setdata(str[0], str[2], str[1]);
			}
		}
	}
}

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
			List<string> dicts = new List<string>() { "*", "fd-eng-hun", "moby-thesaurus", "fd-eng-nld", "fd-eng-deu" };
			List<string> words = new List<string>() { "apple", "beer", "poop", "hair", "table" };

			c_Api ap = new c_Api();
			

			foreach(String word in words)
			{
				ListViewItem lvi0 = new ListViewItem(new string[] { "", word, "" });
				lvi0.BackColor = Color.LightSkyBlue;
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
						lv_Results.Items.Add(lvi);

					}
				}
				Console.WriteLine("==============================================================");
			}
		}
	}
}

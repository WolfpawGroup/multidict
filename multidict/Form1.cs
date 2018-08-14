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

			foreach(string ss in inputA.Split('|'))
			{
				s = s.Replace(ss, inputB);
			}

			return s;
		}
	}

	public struct arrayReplacement
	{
		public string replace_this { get; set; }
		public string with_this { get; set; }
	}
}

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
	public partial class f_Reader : Form
	{
		public f_Reader()
		{
			InitializeComponent();
			Load += F_Reader_Load;
		}

		private void F_Reader_Load(object sender, EventArgs e)
		{
			setdata("", "", "");
		}

		public void setdata(string word, string translation, string from)
		{
			lbl_Word.Text = word;
			lbl_Translation.Text = translation;
			lbl_Dict.Text = from;

			Text = word + " - " + from;
		}
	}
}

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

			lbl_Translation.Navigate("about:blank");
			HtmlDocument doc = lbl_Translation.Document;
			doc.Write(String.Empty);

			//doc.Write("<html><head></head><body style='white-space:pre'>" + translation + "</body></html>");

			string style = @"
<style>
	body{ background:lightblue; }
	.tab{ width: 50px; display: inline-block; }
</style>";

			translation = translation.Replace("\n","<br />").Replace("    ", "\t").Replace("   ", "\t").Replace("  ", "\t").Replace("\t", "<span class='tab'> </span>");

			lbl_Translation.DocumentText = "<html><head><title>" + word + " - From: " + from + "</title><meta charset='UTF-8' />" + style + "</head><body>" + translation + "</body></html>";

			lbl_Dict.Text = from;

			Text = word + " - " + from;
		}
	}
}

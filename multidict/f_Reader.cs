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
		c_DataSerializer ds = new c_DataSerializer();
		List<c_DataObject> pastData = new List<c_DataObject>();

		private string _word = "";
		private string _translation = "";
		private string _from = "";


		string clearTranslation = "";

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
			_word = word;
			_translation = translation;
			_from = from;

			lbl_Word.Text = word;

			clearTranslation = translation;

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

		private void btn_Copy_Click(object sender, EventArgs e)
		{
			lbl_Translation.Document.ExecCommand("SelectAll", false, null);
			lbl_Translation.Document.ExecCommand("Copy", false, null);

			string tr = _translation;
			tr = tr.ArrayReplace("<br />|<br>|<br/>","\r\n").ArrayReplace("<span class='tab'> </span>", "\t");

			c_DataObject d1 = new c_DataObject()
			{
				word = lbl_Word.Text,
				translation = clearTranslation.Replace("\r","").Replace("\n","\r\n"),
				dictionary = lbl_Dict.Text
			};

			if (!cb_AppendData.Checked)
			{
				pastData.Clear();
			}

			d1.index = pastData.Count + 1;

			pastData.Add(d1);

			lbl_Translation.Document.ExecCommand("Unselect", false, Type.Missing);

			Clipboard.SetText(ds.getJSON(pastData, true));
		}
	}
}

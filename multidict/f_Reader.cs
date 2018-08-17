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
			Top = Screen.FromControl(this).WorkingArea.Height - Height;
			Left = Screen.FromControl(this).WorkingArea.Width - Width;
			setdata("", "", "");
			cb_CopyAs.SelectedIndex = Properties.Settings.Default.s_LastCopyMode;
			cb_AppendData.Checked = Properties.Settings.Default.s_CopyAppend;
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
			/*
			lbl_Translation.Document.ExecCommand("SelectAll", false, null);
			lbl_Translation.Document.ExecCommand("Copy", false, null);
			*/
			string tr = _translation;
			tr = tr.ArrayReplace("<br />|<br>|<br/>", "\r\n").ArrayReplace("<span class='tab'> </span>", "\t").RegReplace("<.*?</.*?>|<.*?>|</.*?>", "");
			_translation = tr;

			c_DataObject d1 = new c_DataObject()
			{
				word = _word,
				translation = _translation,
				//translation = clearTranslation.Replace("\r","").Replace("\n","\r\n"),
				dictionary = _from
			};

			if (!cb_AppendData.Checked)
			{
				pastData.Clear();
			}

			d1.index = pastData.Count + 1;

			pastData.Add(d1);

			//lbl_Translation.Document.ExecCommand("Unselect", false, Type.Missing);

			switch (cb_CopyAs.SelectedIndex)
			{
				case 0:
					Clipboard.SetText(ds.getText(pastData));
					break;

				case 1:
					Clipboard.SetText(ds.getCSV(pastData));
					break;

				case 2:
					Clipboard.SetText(ds.getHTML(pastData));
					break;

				case 3:
					Clipboard.SetText(ds.getXML(pastData));
					break;

				case 4:
					Clipboard.SetText(ds.getJSON(pastData, false));
					break;

				case 5:
					Clipboard.SetText(ds.getJSON(pastData, true));
					break;

				case 6:
					Clipboard.SetText(ds.getYAML(pastData));
					break;

				case 7:
					Clipboard.SetText(ds.getMP(pastData, returnType.base64_string));
					break;

				case 8:
					Clipboard.SetText(ds.getMP(pastData, returnType.hexadecimal_string));
					break;
			}
		}

		private void cb_AppendData_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.s_CopyAppend = cb_AppendData.Checked;
			Properties.Settings.Default.Save();
		}

		private void cb_CopyAs_SelectedIndexChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.s_LastCopyMode = cb_CopyAs.SelectedIndex;
			Properties.Settings.Default.Save();
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

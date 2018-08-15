using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace multidict
{
	public class c_Api
	{
		private List<ListViewItem> items = new List<ListViewItem>();

		public c_Api()
		{
			items.Add(new ListViewItem(new string[] { "01 ", "Any", "U" }) { Tag = "*" });
			items.Add(new ListViewItem(new string[] { "02 ", "First match", "U" }) { Tag = "!" });
			items.Add(new ListViewItem(new string[] { "03 ", "The Collaborative International Dictionary of English v.0.48", "U" }) { Tag = "gcide" });
			items.Add(new ListViewItem(new string[] { "04 ", "WordNet (r) 3.0 (2006)", "U" }) { Tag = "wn" });
			items.Add(new ListViewItem(new string[] { "05 ", "Moby Thesaurus II by Grady Ward, 1.0", "U" }) { Tag = "moby-thesaurus" });
			items.Add(new ListViewItem(new string[] { "06 ", "The Elements (07Nov00)", "U" }) { Tag = "elements" });
			items.Add(new ListViewItem(new string[] { "07 ", "V.E.R.A. -- Virtual Entity of Relevant Acronyms (September 2014)", "U" }) { Tag = "vera" });
			items.Add(new ListViewItem(new string[] { "08 ", "The Jargon File (version 4.4.7, 29 Dec 2003)", "U" }) { Tag = "jargon" });
			items.Add(new ListViewItem(new string[] { "09 ", "The Free On-line Dictionary of Computing (18 March 2015)", "U" }) { Tag = "foldoc" });
			items.Add(new ListViewItem(new string[] { "10", "Easton's 1897 Bible Dictionary", "U" }) { Tag = "easton" });
			items.Add(new ListViewItem(new string[] { "11", "Hitchcock's Bible Names Dictionary (late 1800's)", "U" }) { Tag = "hitchcock" });
			items.Add(new ListViewItem(new string[] { "12", "Bouvier's Law Dictionary, Revised 6th Ed (1856)", "U" }) { Tag = "bouvier" });
			items.Add(new ListViewItem(new string[] { "13", "The Devil's Dictionary (1881-1906)", "U" }) { Tag = "devil" });
			items.Add(new ListViewItem(new string[] { "14", "CIA World Factbook 2002", "U" }) { Tag = "world02" });
			items.Add(new ListViewItem(new string[] { "15", "U.S. Gazetteer Counties (2000)", "U" }) { Tag = "gaz2k-counties" });
			items.Add(new ListViewItem(new string[] { "16", "U.S. Gazetteer Places (2000)", "U" }) { Tag = "gaz2k-places" });
			items.Add(new ListViewItem(new string[] { "17", "U.S. Gazetteer Zip Code Tabulation Areas (2000)", "U" }) { Tag = "gaz2k-zips" });
			items.Add(new ListViewItem(new string[] { "18", "Turkish-English FreeDict Dictionary ver. 0.2.1", "O" }) { Tag = "fd-tur-eng" });
			items.Add(new ListViewItem(new string[] { "19", "Portuguese-German FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-por-deu" });
			items.Add(new ListViewItem(new string[] { "20", "Dutch-English Freedict Dictionary ver. 0.1.3", "O" }) { Tag = "fd-nld-eng" });
			items.Add(new ListViewItem(new string[] { "21", "English-Arabic FreeDict Dictionary ver. 0.6.2", "E" }) { Tag = "fd-eng-ara" });
			items.Add(new ListViewItem(new string[] { "22", "Spanish-English FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-spa-eng" });
			items.Add(new ListViewItem(new string[] { "23", "English-Hungarian FreeDict Dictionary ver. 0.1", "E" }) { Tag = "fd-eng-hun" });
			items.Add(new ListViewItem(new string[] { "24", "Italian-English FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-ita-eng" });
			items.Add(new ListViewItem(new string[] { "25", "Welsh-English Freedict dictionary", "O" }) { Tag = "fd-wel-eng" });
			items.Add(new ListViewItem(new string[] { "26", "English-Dutch FreeDict Dictionary ver. 0.1.1", "E" }) { Tag = "fd-eng-nld" });
			items.Add(new ListViewItem(new string[] { "27", "French-English FreeDict Dictionary ver. 0.3.4", "O" }) { Tag = "fd-fra-eng" });
			items.Add(new ListViewItem(new string[] { "28", "Turkish-German FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-tur-deu" });
			items.Add(new ListViewItem(new string[] { "29", "Swedish-English FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-swe-eng" });
			items.Add(new ListViewItem(new string[] { "30", "Nederlands-French FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-nld-fra" });
			items.Add(new ListViewItem(new string[] { "31", "English-Swahili xFried/FreeDict Dictionary", "E" }) { Tag = "fd-eng-swa" });
			items.Add(new ListViewItem(new string[] { "32", "German-Dutch FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-deu-nld" });
			items.Add(new ListViewItem(new string[] { "33", "French-German FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-fra-deu" });
			items.Add(new ListViewItem(new string[] { "34", "English-Croatian Freedict Dictionary", "E" }) { Tag = "fd-eng-cro" });
			items.Add(new ListViewItem(new string[] { "35", "English-Italian FreeDict Dictionary ver. 0.1.1", "E" }) { Tag = "fd-eng-ita" });
			items.Add(new ListViewItem(new string[] { "36", "English-Latin FreeDict Dictionary ver. 0.1.1", "E" }) { Tag = "fd-eng-lat" });
			items.Add(new ListViewItem(new string[] { "37", "Latin-English FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-lat-eng" });
			items.Add(new ListViewItem(new string[] { "38", "French-Dutch FreeDict Dictionary ver. 0.1.2", "O" }) { Tag = "fd-fra-nld" });
			items.Add(new ListViewItem(new string[] { "39", "Italian-German FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-ita-deu" });
			items.Add(new ListViewItem(new string[] { "40", "English-Hindi FreeDict Dictionary ver. 1.5.1", "E" }) { Tag = "fd-eng-hin" });
			items.Add(new ListViewItem(new string[] { "41", "German-English FreeDict Dictionary ver. 0.3.4", "O" }) { Tag = "fd-deu-eng" });
			items.Add(new ListViewItem(new string[] { "42", "Portuguese-English FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-por-eng" });
			items.Add(new ListViewItem(new string[] { "43", "Latin - German FreeDict dictionary ver. 0.4", "O" }) { Tag = "fd-lat-deu" });
			items.Add(new ListViewItem(new string[] { "44", "Japanese-German FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-jpn-deu" });
			items.Add(new ListViewItem(new string[] { "45", "English-German FreeDict Dictionary ver. 0.3.6", "E" }) { Tag = "fd-eng-deu" });
			items.Add(new ListViewItem(new string[] { "46", "English-Serbo-Croat Freedict dictionary", "E" }) { Tag = "fd-eng-scr" });
			items.Add(new ListViewItem(new string[] { "47", "English-Romanian FreeDict Dictionary ver. 0.6.1", "E" }) { Tag = "fd-eng-rom" });
			items.Add(new ListViewItem(new string[] { "48", "Irish-English Freedict dictionary", "O" }) { Tag = "fd-iri-eng" });
			items.Add(new ListViewItem(new string[] { "49", "Czech-English Freedict dictionary", "O" }) { Tag = "fd-cze-eng" });
			items.Add(new ListViewItem(new string[] { "50", "Serbo-Croat-English Freedict dictionary", "O" }) { Tag = "fd-scr-eng" });
			items.Add(new ListViewItem(new string[] { "51", "English-Czech fdicts/FreeDict Dictionary", "E" }) { Tag = "fd-eng-cze" });
			items.Add(new ListViewItem(new string[] { "52", "English-Russian FreeDict Dictionary ver. 0.3", "E" }) { Tag = "fd-eng-rus" });
			items.Add(new ListViewItem(new string[] { "53", "Afrikaans-German FreeDict Dictionary ver. 0.3", "O" }) { Tag = "fd-afr-deu" });
			items.Add(new ListViewItem(new string[] { "54", "English-Portuguese FreeDict Dictionary ver. 0.2.2", "E" }) { Tag = "fd-eng-por" });
			items.Add(new ListViewItem(new string[] { "55", "Hungarian-English FreeDict Dictionary ver. 0.3.1", "O" }) { Tag = "fd-hun-eng" });
			items.Add(new ListViewItem(new string[] { "56", "English-Swedish FreeDict Dictionary ver. 0.1.1", "E" }) { Tag = "fd-eng-swe" });
			items.Add(new ListViewItem(new string[] { "57", "German-Italian FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-deu-ita" });
			items.Add(new ListViewItem(new string[] { "58", "Croatian-English Freedict Dictionary", "O" }) { Tag = "fd-cro-eng" });
			items.Add(new ListViewItem(new string[] { "59", "Danish-English FreeDict Dictionary ver. 0.2.1", "O" }) { Tag = "fd-dan-eng" });
			items.Add(new ListViewItem(new string[] { "60", "English-Turkish FreeDict Dictionary ver. 0.2.1", "E" }) { Tag = "fd-eng-tur" });
			items.Add(new ListViewItem(new string[] { "61", "English-Spanish FreeDict Dictionary ver. 0.2.1", "E" }) { Tag = "fd-eng-spa" });
			items.Add(new ListViewItem(new string[] { "62", "Dutch-German FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-nld-deu" });
			items.Add(new ListViewItem(new string[] { "63", "German-Portuguese FreeDict Dictionary ver. 0.2.1", "O" }) { Tag = "fd-deu-por" });
			items.Add(new ListViewItem(new string[] { "64", "Swahili-English xFried/FreeDict Dictionary", "O" }) { Tag = "fd-swa-eng" });
			items.Add(new ListViewItem(new string[] { "65", "English-Hindi Freedict Dictionary [reverse index]", "E" }) { Tag = "fd-hin-eng" });
			items.Add(new ListViewItem(new string[] { "66", "German-French FreeDict Dictionary ver. 0.3.1", "O" }) { Tag = "fd-deu-fra" });
			items.Add(new ListViewItem(new string[] { "67", "English-French FreeDict Dictionary ver. 0.1.4", "E" }) { Tag = "fd-eng-fra" });
			items.Add(new ListViewItem(new string[] { "68", "Slovak-English Freedict dictionary", "O" }) { Tag = "fd-slo-eng" });
			items.Add(new ListViewItem(new string[] { "69", "Scottish Gaelic-German FreeDict Dictionary ver. 0.1.1", "O" }) { Tag = "fd-gla-deu" });
			items.Add(new ListViewItem(new string[] { "70", "English-Welsh Freedict dictionary", "E" }) { Tag = "fd-eng-wel" });
			items.Add(new ListViewItem(new string[] { "71", "English-Irish Freedict dictionary", "E" }) { Tag = "fd-eng-iri" });
			items.Add(new ListViewItem(new string[] { "72", "English Monolingual Dictionaries", "U" }) { Tag = "english" });
			items.Add(new ListViewItem(new string[] { "73", "Translating Dictionaries", "U" }) { Tag = "trans" });
			items.Add(new ListViewItem(new string[] { "74", "All Dictionaries (English-Only and Translating)", "U" }) { Tag = "all" });
		}

		public List<ListViewItem> getItems()
		{
			return items;
		}

		public List<List<string[]>> getTranslations(List<string> dicts, string search)
		{
			List<List<string[]>> ret = new List<List<string[]>>();

			foreach(string dict in dicts)
			{
				ret.Add(parseXML(makeApiCall(dict, search)));
			}
			
			return ret;
		}

		public List<string[]> parseXML(string html)
		{
			var ret = new List<string[]>();

			XmlDocument xd = new XmlDocument();

			html = html.Substring(html.IndexOf("<hr>") + 4);
			html = html.Substring(0, html.LastIndexOf("<hr>"));
			html = @"<?xml version=""1.0"" encoding=""UTF - 8""?><data>" + html + "</data>";

			html = html.Replace("<pre>", "<val><![CDATA[");
			html = html.Replace("</pre>", "]]></val>");
			Regex r0 = new Regex("From <a href.*?>(.*?)</a>", RegexOptions.IgnoreCase);
			Regex r = new Regex("<a href.*?>(.*?)</a>", RegexOptions.IgnoreCase);
			//Regex r = new Regex("<a href.*?</a>", RegexOptions.IgnoreCase);

			while (r0.IsMatch(html))
			{
				html = html.Replace(r0.Match(html).Value, "<from>" + r0.Match(html).Groups[r0.Match(html).Groups.Count - 1].Value + "</from>");
			}
			
			while (r.IsMatch(html))
			{
				html = html.Replace(r.Match(html).Value, r.Match(html).Groups[r.Match(html).Groups.Count - 1].Value);
			}
			
			xd.LoadXml(html);

			List<XmlNode[]> lst = new List<XmlNode[]>();
			foreach(XmlNode x in xd.SelectNodes("/data/b/from"))
			{
				XmlNode[] xx = new XmlNode[2];
				xx[0] = x;
				xx[1] = x.ParentNode.NextSibling;
				lst.Add(xx);
			}

			foreach (XmlNode[] x in lst)
			{
				if (x[0].Name == "from" && x[1].Name == "val")
				{
					ret.Add(new string[] { x[0].InnerText.Trim(), x[1].InnerText.Trim() });
				}
			}

			
			return ret;
		}

		public string makeApiCall(string dict, string word)
		{
			HttpWebRequest wreq = WebRequest.CreateHttp("http://www.dict.org/bin/Dict");
			byte[] buffer = new byte[1024];
			string data = string.Format("Form=Dict1&Query={0}&Strategy=*&Database={1}&submit=Submit+query", word, dict);
			byte[] dataBytes = Encoding.ASCII.GetBytes(data);

			wreq.Method = "POST";
			wreq.ContentType = "application/x-www-form-urlencoded";
			wreq.ContentLength = dataBytes.Length;

			using (Stream str = wreq.GetRequestStream())
			{
				str.Write(dataBytes, 0, dataBytes.Length);
			}

			HttpWebResponse resp = (HttpWebResponse)wreq.GetResponse();
			string ret = "";

			using (var str = new StreamReader(resp.GetResponseStream()))
			{
				ret = str.ReadToEnd();
			}

			return ret;
		}
	}
}

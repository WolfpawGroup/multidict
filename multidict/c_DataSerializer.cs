using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Xml.Serialization;
using YamlDotNet.Serialization;
using MessagePack;
using System.Windows.Forms;

namespace multidict
{
	public class c_DataSerializer
	{
		public string getText(List<c_DataObject> strs)
		{
			string r = "";

			foreach (c_DataObject str in strs)
			{
				r += string.Format("{0}: {1}\r\n{2}\r\n{3}\r\n\r\n", str.index, str.word, str.translation, str.dictionary);
			}
			return r;
		}


		public string getCSV(List<c_DataObject> strs)
		{
			string r = "";
			foreach (c_DataObject str in strs)
			{
				r += string.Format("{0};{1};{2};{3}\r\n", str.index, str.word, str.translation, str.dictionary);
			}
			return r;
		}


		public string getJSON(List<c_DataObject> strs, bool asArray)
		{
			string r = "";

			if (asArray)
			{
				JsonSerializer jss = new JsonSerializer() { Formatting = Newtonsoft.Json.Formatting.Indented };
				using (StringWriter sw = new StringWriter())
				{
					jss.Serialize(sw, strs);
					r = "\"array:\"" + (sw.ToString());
				}

			}
			else
			{

				foreach (c_DataObject str in strs)
				{
					r += string.Format(@" ""{0}"" : {1}", str.index, JsonConvert.SerializeObject(str, Newtonsoft.Json.Formatting.Indented));
					if (!strs.Last().Equals(str)) { r += ", "; }
				}
			}
			
			string t = r;
			string[] st = t.Split('\n');
			r = "";
			for(int i = 0; i < t.Split('\n').Length; i++)
			{
				r += "\t" + st[i] + "\n";
			}
			
			r = "{\r\n" + r + "}";

			return r;
		}

		public string getXML(List<c_DataObject> strs)
		{
			XmlDocument xd = new XmlDocument();

			XmlNode xml_xml = xd.CreateNode(XmlNodeType.XmlDeclaration, "xml", "/");
			XmlNode trans_xml = xd.CreateElement("translations");

			xd.AppendChild(xml_xml);
			xd.AppendChild(trans_xml);

			foreach (c_DataObject str in strs)
			{
				XmlSerializer xs = new XmlSerializer(new c_DataObject().GetType());
				using (StringWriter swr = new StringWriter())
				{
					xs.Serialize(swr, str);

					swr.Flush();

					string tmp = swr.ToString();

					XmlNode xm = xd.CreateElement("translation_" + str.index);
					xm.InnerXml = new XmlDocument() { InnerXml = tmp }.ChildNodes[1].InnerXml;
					if (Properties.Settings.Default.s_XML_UseCData)
					{
						string tmpText = xm.SelectSingleNode("/translation").InnerText;
						xm.SelectSingleNode("/translation").InnerText = "";
						XmlNode xText = xd.CreateNode(XmlNodeType.CDATA, "", "");
						xText.InnerText = tmpText;
						xm.SelectSingleNode("/translation").AppendChild(xText);
					}
					xd.SelectSingleNode("translations").AppendChild(xm);

				}
			}

			return PrettyXml(xd.OuterXml);
		}

		static string PrettyXml(string xml)
		{
			try
			{
				var stringBuilder = new StringBuilder();

				var element = XElement.Parse(xml);

				var settings = new XmlWriterSettings();

				if (Properties.Settings.Default.s_XML_RemoveHeader)
				{
					settings.OmitXmlDeclaration = true;
				}

				settings.Indent = true;
				settings.NewLineOnAttributes = true;

				using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
				{
					element.Save(xmlWriter);
				}

				return stringBuilder.ToString();
			}
			catch
			{
				return xml;
			}
		}

		public string getYAML(List<c_DataObject> strs)
		{
			string r = "";

			using (MemoryStream s = new MemoryStream())
			{
				using (var tr = new StreamWriter(s, Encoding.UTF8))
				{
					using (var sr = new StreamReader(s, Encoding.UTF8, true))
					{
						Serializer xs = new Serializer();
						foreach (c_DataObject str in strs)
						{
							xs.Serialize(tr, str, new c_DataObject().GetType());

							tr.Flush();
							s.Position = 0;


							r += sr.ReadToEnd();
						}
					}
				}
			}

			return r;
		}

		/// <summary>
		/// Returns MessagePack encoded into base64
		/// </summary>
		public string getMP(List<c_DataObject> strs, returnType rettype)
		{
			List<byte> bb = new List<byte>();
			StringBuilder ret = new StringBuilder();

			byte[] b = new byte[] { 0 };

			if (strs.Count > 1)
			{
				b = MessagePackSerializer.Serialize(strs);
			}
			else if (strs.Count == 1)
			{
				b = MessagePackSerializer.Serialize(strs[0]);
			}

			bb.AddRange(b);

			switch (rettype)
			{

				case returnType.hexadecimal_string:
					foreach (byte b_ in bb) { ret.Append(b_.ToString("X2") + " "); }
					break;

				case returnType.decimal_string:
					foreach (byte b_ in bb) { ret.Append(((int)b_).ToString() + " "); }
					break;

				case returnType.octal_string:
					foreach (byte b_ in bb) { ret.Append((Convert.ToString(b_, 8)).ToString() + " "); }
					break;

				case returnType.bytes:
					foreach (byte b_ in bb) { ret.Append((char)b_); }
					break;

				default:
				case returnType.base64_string:
					ret.Append(Convert.ToBase64String((bb.ToArray())));
					break;
			}

			return ret.ToString().Trim();
		}

		public string getHTML(List<c_DataObject> strs)
		{
			string wrd = "";
			StringBuilder sb = new StringBuilder();
			string strLinks = "";
			string linkTemplate = "<a href='#translation_{0}' onclick='event.stopPropagation();' > ○ Translation{0} </a><br />";

			sb.AppendLine("<!DOCTYPE html>");
			sb.AppendLine("<html>");
			sb.AppendLine("	<head>");
			sb.AppendLine("		<meta charset='UTF-8' />");
			sb.AppendLine("		<title>");
			sb.AppendLine("			Copied from WolfPaw multiDict - " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
			sb.AppendLine("		</title>");
			sb.AppendLine("		<style>");
			sb.AppendLine("			body{ background:lightblue; padding: 30px; }");
			sb.AppendLine("			h1{ text-shadow:2px 2px 2px #333; font-size:3.3em; margin-bottom:60px;  }");
			sb.AppendLine("			h2{ font-weight:100; font-size: 0.9em; font-family:consolas; color: red; text-shadow:1px 1px 1px #F00;  }");
			sb.AppendLine("			p{ display:block; width:99%; position:relative; white-space:pre-wrap; font-size:1.2em; font-family:\"Courier New\"; text-shadow:1px 1px 1px #111;  }");
			sb.AppendLine("			div{ margin-top:20px; padding: 5px 0px 20px 10px; border-bottom: 1px solid white;  border-left: 10px solid rgba(255,255,255,0.3); border-top-left-radius:10px; border-bottom-left-radius:15px; }");
			sb.AppendLine("			#indexHolder { background:#FFF; display:inline; position:absolute; padding-left: 25px; margin-left:-5px; margin-top:-30px; z-index:1; border-top-left-radius:5px; right: 10px; top: 10px;}");
			sb.AppendLine("			#pages{ display:block; width: 160px; padding-right:20px; height:19px;  line-break: unset; transition-duration:1s; overflow:hidden;  }");
			sb.AppendLine("			#chk { display:inline; position:absolute; margin-left: -20px; }");
			sb.AppendLine("			#chk:checked + #pages{ transition-property:height; height: calc(30px + ([MAX]*23px)); transition-duration:1s; overflow:hidden; overflow-y:auto;}");
			sb.AppendLine("			#pages a{ font-weight:bold; font-family:Consolas; text-decoration:none; color:black; }");
			sb.AppendLine("			#pages a:hover{ font-weight:bold; font-family:Consolas; text-decoration:none; color:red; }");
			sb.AppendLine("			#s::before{ content:\"  Translations: \"; cursor:pointer; }");
			sb.AppendLine("		</style>");
			sb.AppendLine("	</head>");
			sb.AppendLine("	<body>");
			

			

			if (strs.Count == 1)
			{
				sb.AppendLine("		<h1>" + strs[0].word + "</h1>");
				sb.AppendLine("		<div id='translation_0'>");

				sb.AppendLine("			<h2 id='dict_0'>" + strs[0].dictionary + "</h2>");
				sb.AppendLine("			<p id='trans_0'>" + strs[0].translation + "</p>");


				sb.AppendLine("		</div>");
			}
			else
			{
				wrd = strs[0].word;
				sb.AppendLine("		<h1>" + strs[0].word + "</h1>");

				sb.AppendLine("		<span id='indexHolder' >");
				sb.AppendLine("			<input type='checkbox' id='chk' />");
				sb.AppendLine("			<span id='pages' onclick='document.getElementById(\"chk\").checked = !document.getElementById(\"chk\").checked;'>");
				sb.AppendLine("				<span id='s'></span><br /><br />");
				sb.AppendLine("				[TRANSLATIONS]");
				sb.AppendLine("			</span>");
				sb.AppendLine("		</span>");

				

				foreach (c_DataObject str in strs)
				{
					if (str.word != wrd)
					{
						wrd = str.word;
						sb.AppendLine("		<h1>" + str.word + "</h1>");
					}

					sb.AppendLine("		<div id='translation_" + str.index + "'>");

					sb.AppendLine("			<h2 title='Translation " + str.index + "' id='dict_" + str.index + "'>" + str.dictionary + "</h2>");
					sb.AppendLine("			<p title='Translation " + str.index + "' id='trans_" + str.index + "'>" + str.translation + "</p>");
					
					sb.AppendLine("		</div>");

					strLinks += string.Format(linkTemplate, str.index) + "\r\n";
				}
			}



			sb.AppendLine("	</body>");
			sb.AppendLine("</html>");

			return sb.ToString().Replace("[MAX]", strs.Count + "").Replace("[TRANSLATIONS]", strLinks);
		}

	}

	public enum returnType
	{
		base64_string,
		hexadecimal_string,
		decimal_string,
		octal_string,
		bytes
	}
}

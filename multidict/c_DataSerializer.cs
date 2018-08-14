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
				r += string.Format("{0};{1};{2};{3}", str.index, str.word, str.translation, str.dictionary);
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
					r = (sw.ToString());
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
			
			r = "{\r\n\"array\":" + r + "}";

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

			switch (rettype) {

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

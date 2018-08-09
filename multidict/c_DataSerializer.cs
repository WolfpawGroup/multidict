using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using System.Xml.Linq;

using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using MessagePack.LZ4;
using MessagePack.Resolvers;

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


		public string getJSON(List<c_DataObject> strs)
		{
			string r = "{";

			foreach (c_DataObject str in strs)
			{
				r += string.Format(@" ""{0}"" : {1}", str.index, JsonConvert.SerializeObject(str));
				if (!strs.Last().Equals(str)) { r += ", "; }
			}

			r += "}";

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

		public string getMP(List<c_DataObject> strs)
		{
			
			foreach (var str in strs)
			{
				/*
				var i = TypelessObjectResolver.Instance;
				var formattter = i.GetFormatter<c_DataObject>();
				byte[] bs = new byte[10240];
				formattter.Serialize(ref bs, 0, str, TypelessObjectResolver.Instance);
				//byte[] b = MessagePackSerializer.Serialize<c_DataObject>(str, TypelessObjectResolver.Instance);
				foreach (byte bb in bs)
				{
					if(bb == '\0') { break; }
					Console.Write(bb);
				}
				*/
			}

			return "a";

		}

	}
}

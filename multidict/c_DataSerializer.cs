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

			string r = "<translations>";

			using (MemoryStream s = new MemoryStream())
			{
				using (var tr = new StreamWriter(s, Encoding.UTF8))
				{
					XmlSerializer xs = new XmlSerializer(new c_DataObject().GetType());
					foreach (c_DataObject str in strs)
					{
						xs.Serialize(tr, str);

						tr.Flush();
						s.Position = 0;

						using (var sr = new StreamReader(s, Encoding.UTF8, true))
						{
							string xTmp = sr.ReadToEnd();
							XmlDocument xd = new XmlDocument();
							xd.LoadXml(xTmp);
							xd.DocumentElement.SetAttribute("index", str.index.ToString());
							r += sr.ReadToEnd();
						}
					}
				}
			}

			r += "</translations>";

			return r;
		}

		public string getYAML(List<c_DataObject> strs)
		{
			string r = "";

			using (MemoryStream s = new MemoryStream())
			{
				using (var tr = new StreamWriter(s, Encoding.UTF8))
				{
					Serializer xs = new Serializer();
					foreach (c_DataObject str in strs)
					{
						xs.Serialize(tr, str, new c_DataObject().GetType());
						
						tr.Flush();
						s.Position = 0;

						using (var sr = new StreamReader(s, Encoding.UTF8, true))
						{
							r += sr.ReadToEnd();
						}
					}
				}
			}
			
			return r;
		}



	}
}

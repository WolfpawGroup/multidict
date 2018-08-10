using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multidict
{
	[MessagePackObject]
	public class c_DataObject
	{
		[Key(0)]
		public int index { get; set; }
		[Key(1)]
		public string word { get; set; }
		[Key(2)]
		public string dictionary { get; set; }
		[Key(3)]
		public string translation { get; set; }
	}
}

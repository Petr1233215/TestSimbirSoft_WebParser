using System;
using System.Collections.Generic;
using System.Text;

namespace TestSimbirSoft_WebParser
{
	public static class StaticFileHelper
	{
		public static Dictionary<string, int> FillStatisticsDictionary(this FileHelper fileHelper, IEnumerable<string> texts)
		{
			var statisticDictionary = new Dictionary<string, int>();
			foreach (var text in texts)
			{
				if (statisticDictionary.ContainsKey(text))
					statisticDictionary[text] += 1;
				else
					statisticDictionary[text] = 1;
			}

			return statisticDictionary;
		}
	}
}

using System.Collections.Generic;
using System.Linq;

namespace TextSynthesizer
{
	public class TextSplitter
	{
		public bool IsLatinLetter(char c)
		{
			return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
		}

		public RowRuEng SplitString(string str)
		{
			if (string.IsNullOrWhiteSpace(str))
				return null;

			var rusPart = new string(str.TakeWhile(x => !IsLatinLetter(x)).ToArray())?.Trim();

			var engPart = "";
			if (!string.IsNullOrWhiteSpace(rusPart))
				engPart = str.Replace(rusPart, "")?.Trim();

			var result = new RowRuEng(rusPart, engPart, 1);
			return result;
		}


		public List<RowRuEng> SplitStringMany(params string[] strList)
		{
			var result = strList.Select(x => SplitString(x)).ToList();
			return result;
		}





	}
}

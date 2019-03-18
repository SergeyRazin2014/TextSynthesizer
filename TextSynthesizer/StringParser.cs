using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace TextSynthesizer
{
	public static class StringParser
	{
		public static string RemoveSpaces(string str)
		{
			if (string.IsNullOrWhiteSpace(str))
				return "";

			var rez = Regex.Replace(str, " +", " ");
			return rez.Trim();
		}

		//получить все подстроки котрые в фигурных скобках
		public static string GetOneCurlyBracket(string str)
		{
			string pattern = @"{.*}";
			RegexOptions regexOptions = RegexOptions.IgnoreCase | RegexOptions.Singleline;
			Regex regex = new Regex(pattern, regexOptions);

			foreach (Match match in regex.Matches(str))
			{
				if (match.Success)
				{
					return match.ToString();
				}
			}

			return null;
		}

		//получить список с подстроками в фигурках
		public static List<string> SplitByCyrlyBrackt(string str)
		{
			List<string> list = new List<string>();

			//разбить строку
			var split = str.Split('}');

			//получить из строки наши скобки
			foreach (var i in split)
			{
				var res = GetOneCurlyBracket(i + "}");
				if (!string.IsNullOrWhiteSpace(res))
					list.Add(res);
			}

			return list;
		}

		public static string ChangeElementsInCyrlyBracketOnSpecNumbers(string englishStr, List<string> curlyBracketList)
		{
			for (int i = 0; i < curlyBracketList.Count; i++)
			{
				englishStr = englishStr.Replace(curlyBracketList[i], "{" + "curlyB" + i + "}");
			}

			return englishStr;
		}

		public static string ReturnCurlyBracketBack(string result, List<string> curlyBracketList)
		{
			for (int i = 0; i < curlyBracketList.Count; i++)
			{
				result = result.Replace("{" + "curlyB" + i + "}", curlyBracketList[i]);
			}

			return result;
		}

		public static List<string> GetServiceSymbolsList(string englishStr, params string[] symbs)
		{
			var listSymbs = symbs.ToList();

			var reslist = new List<string>();

			for (int i = 0; i < symbs.Length; i++)
			{
				if (englishStr.Contains(symbs[i]))
				{
					reslist.Add(symbs[i]);
				}
			}

			return reslist;
		}

		public static string ChangeServiceSimbolsOnStub(string englishStr, params string[] symbs)
		{
			for (int i = 0; i < symbs.Length; i++)
			{
				englishStr = englishStr.Replace(symbs[i], "sssyyymmm" + i);
			}

			return englishStr;
		}

		public static string ReturnServiceSymbols(string result, List<string> serviceSymbolsList)
		{
			for (int i = 0; i < serviceSymbolsList.Count; i++)
			{
				result = result.Replace("sssyyymmm" + i, serviceSymbolsList[i]);
			}

			return result;
		}

		public static string RemoveEndDot(string str)
		{
			if (string.IsNullOrWhiteSpace(str))
				return "";



			var res = str.Substring(0, str.Length - 1);
			return res;
		}


		public static bool IsNumber(string str)
		{
			int temp;

			var res = int.TryParse(str, out temp);

			return res;
		}

		public static string WhitespaceToSpace(string str)
		{
			var res = Regex.Replace(str, @"\s+", " ");
			return res;
		}

		public static int GetWordCount(string str)
		{
			var res = StringParser.WhitespaceToSpace(str.Trim()).Split().Count();
			return res;
		}
	}
}
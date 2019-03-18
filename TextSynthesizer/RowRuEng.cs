using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSynthesizer
{
	public class RowRuEng
	{
		public RowRuEng(string ru, string en, int rowNumber)
		{
			RuStr = ru;
			EnStr = en;
			RowNumber = rowNumber;
		}

		public string RuStr { get; set; }
		public string EnStr { get; set; }

		/// <summary>
		/// номер строки в документе EXCEL (начинаемс 1)
		/// </summary>
		public int RowNumber { get; }
	}
}

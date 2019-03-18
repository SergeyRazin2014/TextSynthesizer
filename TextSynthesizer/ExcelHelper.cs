using ClosedXML.Excel;
using System;
using System.Collections.Generic;

namespace TextSynthesizer
{
	public class ExcelHelper :IDisposable
	{
		private XLWorkbook _workbook;

		public ExcelHelper(string excelPath)
		{
			_workbook = new XLWorkbook(excelPath);
		}

		public List<RowRuEng> GetRowsRuEng(int workSheetNumber)
		{
			IXLWorksheet worksheet = _workbook.Worksheet(workSheetNumber);

			var list = new List<RowRuEng>();

			if (worksheet.LastRowUsed() == null)
				return list;

			for (int i = 1; i <= worksheet.LastRowUsed().RowNumber(); i++)
			{
				var ruStr = worksheet.Row(i).Cell(1).GetValue<string>();
				var enStr = worksheet.Row(i).Cell(2).GetValue<string>();
				var testValue = new RowRuEng(ruStr, enStr, i);

				list.Add(testValue);
			}

			return list;
		}

		public int GetWorkSheetCount()
		{
			var res = _workbook.Worksheets.Count;
			return res;
		}

		public string GetWorkSheetName(int sheetNumber)
		{
			var res = _workbook.Worksheets.Worksheet(sheetNumber).Name;
			return res;
		}

		/// <summary>
		/// сохранить текст в эксель
		/// </summary>
		/// <remarks>
		/// пример для cellAddr = "A1"
		/// </remarks>
		public void WriteStr(int workSheetNumber, string cellAddr, string value)
		{
			var worksheet = _workbook.Worksheet(workSheetNumber);

			worksheet.Cell(cellAddr).Value = value;
			_workbook.Save();
		}

		private void WriteRow(RowRuEng row, int rowNumber, int workSheetNumber)
		{
			var cellAddrRu = "A" + rowNumber;
			var cellAddrEn = "B" + rowNumber;

			WriteStr(workSheetNumber, cellAddrRu, row.RuStr);
			WriteStr(workSheetNumber, cellAddrEn, row.EnStr);
		}

		public void WriteRowList(int workSheetNumber, params RowRuEng[] rowList)
		{
			for (int i = 0; i < rowList.Length; i++)
			{
				var row = rowList[i];

				WriteRow(row, i + 1, workSheetNumber);
			}
		}

		public void Dispose()
		{
			_workbook.Dispose();
		}
	}
}
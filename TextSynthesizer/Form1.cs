using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TextSynthesizer
{
	public partial class Form1 : Form
	{
		private ExcelHelper _excelHelper
		{
			get
			{
				var res = new ExcelHelper(_filePath);
				return res;
			}
		}

		private string _filePath;

		public Form1()
		{
			InitializeComponent();

			tbWaitAfterRu.Enabled = !checkBoxAutoCalc.Checked;
			tbWaitAfterEn.Enabled = !checkBoxAutoCalc.Checked;
			tbRepeatCount.Enabled = !checkBoxAutoCalc.Checked;
		}

		private void BtnSpeak_Click(object sender, EventArgs e)
		{
			TrySpeack();
		}

		private bool IsFilePathValid()
		{
			if (string.IsNullOrWhiteSpace(_filePath))
			{
				MessageBox.Show("выберите файл эксель");
				return false;
			}

			if (!File.Exists(_filePath))
			{
				MessageBox.Show("указанный файл не существует");
				return false;
			}

			return true;
		}

		private void TrySpeack()
		{
			try
			{
				if (!IsFilePathValid())
					return;

				int sheetCount = GetSheetCount();

				if (string.IsNullOrWhiteSpace(tbTakeRowCount.Text))
				{
					for (int i = 1; i <= sheetCount; i++)
						CreateAllRecord(i);
				}
				else
				{
					for (int i = 1; i <= sheetCount; i++)
						CreateRecordRowCount(i, int.Parse(tbTakeRowCount.Text));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// создать запись
		/// </summary>
		/// <param name="workSheetNumber">номер листа начиная с 1</param>
		private void CreateAllRecord(int workSheetNumber)
		{
			var textName = _excelHelper.GetWorkSheetName(workSheetNumber);

			if (textName.ToUpper().StartsWith("IGNORE"))
				return;

			List<RowRuEng> allRows = _excelHelper.GetRowsRuEng(workSheetNumber);
			if (IsContainsEndMark(allRows))
			{
				var subLists = SplitRowList(allRows);
				CreateRecordBySplitList(subLists, workSheetNumber);
			}
			else
			{
				CreaterRecord(allRows, workSheetNumber);
			}

		}

		private bool IsContainsEndMark(List<RowRuEng> rowList)
		{
			if (rowList.Any(x => x.RuStr.ToUpper().Contains("{END}")))
				return true;

			return false;
		}

		//☻
		//разбить список строк на указанные группы с разделителем в файле
		public List<List<RowRuEng>> SplitRowList(List<RowRuEng> allRows)
		{
			List<List<RowRuEng>> resList = new List<List<RowRuEng>>();

			var subList = new List<RowRuEng>();

			//|| row.RowNumber == allRows.Count

			//для каждой строки
			foreach (var row in allRows)
			{
				//если это не указатель на разрыв аудио файла
				if (row.RuStr.ToUpper() != "{END}")
				{
					subList.Add(row); //положить эту строку в subList

					//если это последняя строка в EXCEL
					if (row.RowNumber == allRows.Count)
					{
						resList.Add(subList);
						subList = new List<RowRuEng>();
					}

				}
				else //иначе если это указатель на разрыв аудио файла подлист добавляем в результирующий и очищаем ссылку на подлист чтобы начать собирать список для нового аудио файла
				{
					resList.Add(subList);
					subList = new List<RowRuEng>();
				}
			}

			return resList;
		}


		private void CreaterRecord(List<RowRuEng> rowList, int workSheetNumber, string suffix = null)
		{
			//var textName = _excelHelper.GetWorkSheetName(workSheetNumber) + suffix;

			//var speaker = new Speaker(tbWaitAfterRu.Value, tbWaitAfterEn.Value, tbRepeatCount.Value, tbSpeachSpeed.Value, checkBoxAutoCalc.Checked);
			//speaker.SayRowList(textName, rowList.ToArray());
			//speaker.Dispose();

			var textName = _excelHelper.GetWorkSheetName(workSheetNumber) + suffix;

			using (var speaker = new Speaker(tbWaitAfterRu.Value, tbWaitAfterEn.Value, tbRepeatCount.Value, tbSpeachSpeed.Value, checkBoxAutoCalc.Checked))
			{
				speaker.SayRowList(textName, rowList.ToArray());
			}

		}

		/// <summary>
		/// создать аудио файлы с настройкой не более строк в одном медиа файле
		/// </summary>
		private void CreateRecordRowCount(int workSheetNumber, int takeRowCount)
		{
			var worksheetName = _excelHelper.GetWorkSheetName(workSheetNumber);

			if (worksheetName.ToUpper().StartsWith("IGNORE"))
				return;

			//все строки
			List<RowRuEng> allRows = _excelHelper.GetRowsRuEng(workSheetNumber);

			List<List<RowRuEng>> splitRowList = new List<List<RowRuEng>>();

			splitRowList = allRows //сгруппировать строки по указанному количеству
					.Select((x, i) => new { Index = i, Value = x })
					.GroupBy(x => x.Index / takeRowCount)
					.Select(x => x.Select(v => v.Value).ToList())
					.ToList();

			//int count = 1;
			//foreach (var rowList in splitRowList) //для каждого списка строк создать аудио файл
			//{
			//	CreaterRecord(rowList, workSheetNumber, count.ToString());
			//	count++;
			//}

			CreateRecordBySplitList(splitRowList, workSheetNumber);
		}

		private void CreateRecordBySplitList(List<List<RowRuEng>> splitRowList, int workSheetNumber)
		{
			int count = 1;
			foreach (var rowList in splitRowList) //для каждого списка строк создать аудио файл
			{
				CreaterRecord(rowList, workSheetNumber, count.ToString());
				count++;
			}
		}

		private void btnSelectFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog diag = new OpenFileDialog();
			diag.Title = "выберите файл с расширением xlsx";

			if (diag.ShowDialog() == DialogResult.OK)
			{
				_filePath = diag.FileName;
			}
		}

		private void btnTranslate_Click(object sender, EventArgs e)
		{
			try
			{
				if (!IsFilePathValid())
					return;

				WriteTranslateToExcel();

				MessageBox.Show("Перевод окончен");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private int GetSheetCount()
		{
			//ExcelHelper excelHelper = new ExcelHelper(_filePath);

			if (checkBOnly1.Checked)
				return 1;
			else
				return _excelHelper.GetWorkSheetCount();
		}

		private void WriteTranslateToExcel()
		{
			//ExcelHelper excelHelper = new ExcelHelper(_filePath);

			var sheetCount = GetSheetCount();

			for (int i = 1; i <= sheetCount; i++)
			{
				var rowList = _excelHelper.GetRowsRuEng(i);

				Translater t = new Translater("trnsl.1.1.20150916T154114Z.3ccc4dfb24c67895.2cf775a7f8654fb0bc1b363763f2549ea0a874ae");
				var translatedRowList = t.TranslateRowList(rowList.ToArray());

				_excelHelper.WriteRowList(i, translatedRowList);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				var appDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

				var path = $"{appDir}\\Result";
				Process.Start(path);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void tbFilePath_Leave(object sender, EventArgs e)
		{
			_filePath = tbFilePath.Text.Trim('"');
		}

		private void checkBoxWaitByWords_CheckedChanged(object sender, EventArgs e)
		{
			tbWaitAfterRu.Enabled = !((CheckBox)sender).Checked;
			tbRepeatCount.Enabled = !((CheckBox)sender).Checked;
			tbWaitAfterEn.Enabled = !((CheckBox)sender).Checked;

		}

		
	}
}
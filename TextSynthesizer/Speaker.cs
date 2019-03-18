using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;

namespace TextSynthesizer
{
	public class Speaker : IDisposable
	{
		private SpeechSynthesizer _speaker;
		private readonly decimal? _waitAfterRu;
		private decimal? _repeatCount;
		private decimal? _waitAfterEn;
		private readonly bool _autoCalc;

		public Speaker(decimal? waitAfterRu, decimal? waitAfterEn, decimal? repeatCount, decimal? speachSpeed, bool autoCalc)
		{
			_speaker = new SpeechSynthesizer();

			//_speaker.Rate = -3;
			_speaker.Rate = 0;
			_waitAfterRu = waitAfterRu;
			_repeatCount = repeatCount;
			_waitAfterEn = waitAfterEn;
			_speaker.Rate = (int)speachSpeed;
			_autoCalc = autoCalc;
		}

		//private void SayRow(RowRuEng row)
		//{
		//	//ожидание времени после русской фразы
		//	if (_waitFirst != null && !_calculateWaitAfterRu)
		//		row.RuStr += "{" + _waitFirst + "}";

		//	if (_calculateWaitAfterRu)
		//		row.RuStr += "{" + CalculateWaitByWords(row.EnStr) + "}";

		//	if (_calculateRepeat)
		//	{
		//		_repeatCount = CalculateRepeatCount(row.EnStr);

		//		if (_repeatCount == 1)
		//			_waitOthers = 0;
		//		else
		//			_waitOthers = 3;
		//	}

		//	//ожидание вреиени после английской фразы
		//	if (_waitOthers != null)
		//		row.EnStr += "{" + _waitOthers + "}";
		//	else
		//		row.EnStr += "{" + 2 + "}";

		//	//увеличиваем количество
		//	if (_repeatCount != null)
		//	{
		//		for (int i = 1; i < _repeatCount; i++)
		//		{
		//			row.EnStr += row.EnStr;
		//		}
		//	}

		//	//после всей строки добавляю 2 секунды ожидания если фраза на EN длинная
		//	if (CalculateWaitByWords(row.EnStr) > 5)
		//		row.EnStr += "{" + 2 + "}";

		//	if (!String.IsNullOrWhiteSpace(row.RuStr))
		//		SayStr(row.RuStr, Constants.Ru);

		//	if (!String.IsNullOrWhiteSpace(row.EnStr))
		//		SayStr(row.EnStr, Constants.En);
		//}

		private void SayRow(RowRuEng row)
		{
			if (_autoCalc)
				row = PrepareRow_If_Autocalc(row);
			else
				row = PrepareRow_If_No_Autocalc(row);

			if (!String.IsNullOrWhiteSpace(row.RuStr))
				SayStr(row.RuStr, Constants.Ru);

			if (!String.IsNullOrWhiteSpace(row.EnStr))
				SayStr(row.EnStr, Constants.En);
		}

		private RowRuEng PrepareRow_If_Autocalc(RowRuEng row)
		{
			row.RuStr += "{" + CalculateWaitAfterRu(row.EnStr) + "}";

			_repeatCount = CalculateRepeatCount(row.EnStr);

			if (_repeatCount == 1)
				_waitAfterEn = 0;
			else
				_waitAfterEn = 3;

			//увеличиваем количество
			for (int i = 1; i < _repeatCount; i++)
				row.EnStr += "{3}" + row.EnStr;

			//вконце en строки добавляю 2 секунды
			row.EnStr += "{" + 2 + "}";

			return row;
		}

		/// <summary>
		/// ЕСЛИ НЕ ЗАДАНА НАСТРОЙКА - "РАССЧИТАТЬ АВТОМАТИЧЕСКИ"
		/// </summary>
		private RowRuEng PrepareRow_If_No_Autocalc(RowRuEng row)
		{
			if (string.IsNullOrWhiteSpace(row.EnStr))
				return row;

			//ожидание времени после русской фразы
			if (_waitAfterRu != null)
				row.RuStr += "{" + _waitAfterRu + "}";

			//ожидание времени после английской фразы
			if (_waitAfterEn != null && _waitAfterEn != 0)
				row.EnStr += "{" + _waitAfterEn + "}";

			//увеличиваем количество повторов
			if (_repeatCount != null && _repeatCount != 0)
			{
				var str = "";

				for (int i = 0; i < _repeatCount; i++)
				{
					str += row.EnStr;
				}

				row.EnStr = str;
			}

			return row;
		}

		private int CalculateRepeatCount(string str)
		{
			//рассчитываю количество слов
			var res = StringParser.GetWordCount(str);

			if (res <= 4)
				res = 1;
			else if (res > 4 && res <= 6)
				res = 2;
			else
				res = 3;

			return res;
		}

		private int CalculateWaitAfterRu(string str)
		{
			//рассчитываю количество слов
			var wordCount = StringParser.GetWordCount(str);

			if (string.IsNullOrWhiteSpace(str))
				return 0;

			if (wordCount <= 4)
				return 2;

			if (wordCount > 4)
				return 5;

			return 4;
		}

		public void FillPromptBuilder(string str, PromptBuilder promptBuilder)
		{
			if (string.IsNullOrWhiteSpace(str))
				return;

			new FillPromptBuilder(promptBuilder).Execute(str);
		}

		public void SayStr(string str, string locale)
		{
			var prompt = new PromptBuilder();
			prompt.Culture = CultureInfo.GetCultureInfoByIetfLanguageTag(locale);

			FillPromptBuilder(str, prompt);

			if (locale == Constants.Ru)
				_speaker.SelectVoice(Constants.RuVoice);
			else if (locale == Constants.En)
				_speaker.SelectVoice(Constants.EnVoice);
			else
				throw new Exception("неизвестный идентификатор языка");

			_speaker.Speak(prompt);
		}

		private FileStream _fs;

		private void SetModeSaveToFile(string fileName)
		{
			var directoryName = "RESULT";
			var fileStr = fileName + ".wav";

			if (!Directory.Exists(directoryName))
				Directory.CreateDirectory(directoryName);

			var path = Path.Combine(directoryName, fileStr);

			_fs = new FileStream(path, FileMode.Create, FileAccess.Write);
			_speaker.SetOutputToWaveStream(_fs);
		}

		public void SayRowList(string textName, params RowRuEng[] rowList)
		{
			if (!rowList.Any())
				return;

			SetModeSaveToFile(textName); //говорим , что будем сохранять в файл

			SayStr("Текст: " + textName, Constants.Ru);

			foreach (var row in rowList)
				SayRow(row);

			SayStr("А-А-А-А Ы-Ы-Ы-ЫЫ-Ы-Ы-Ы Ю-Ю-Ю-Ю, Конец текста", Constants.Ru);
		}

		public List<string> GetAllVoices()
		{
			var englishVoice = _speaker.GetInstalledVoices(new CultureInfo("en-Us")).Select(x => x.VoiceInfo.Name).ToList();
			var ruVoices = _speaker.GetInstalledVoices(CultureInfo.CurrentCulture).Select(x => x.VoiceInfo.Name).ToList();
			List<string> allVoices = englishVoice.Union(ruVoices).ToList();
			return allVoices;
		}

		public void Dispose()
		{
			_speaker.Dispose();

			if (_fs != null)
				_fs.Dispose();
		}
	}
}
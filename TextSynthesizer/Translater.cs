
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace TextSynthesizer
{
    public class Translater
    {
        public delegate void ProgressDelegate(int current, int count);

        private string _yandexToken;

        public Translater(string yandexToken)
        {
            this._yandexToken = yandexToken;
        }

        public Dictionary<string, string> GetAllStringsTranslate(Dictionary<string, string> englishStringDict, ProgressDelegate progressDellegate)
        {
            Dictionary<string, string> translateDict = new Dictionary<string, string>();

            for (int i = 0; i < englishStringDict.Count; i++)
            {
                var item = englishStringDict.ElementAt(i);
                var itemKey = item.Key;
                var itemValue = item.Value;

                try
                {
                    translateDict.Add( itemKey, TranslateOneStringWithYandex(itemValue));
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при обработке запроса Яндексом, возможо вы ввели неверный токен в опциях! " + ex);
                }

                if (progressDellegate != null)
                    progressDellegate(i, englishStringDict.Count);
            }

            return translateDict;
        }

        public string TranslateOneStringWithYandex(string englishStr)
        {
            if (string.IsNullOrWhiteSpace(englishStr))
                return "";

            string queryString = CreateQueryString(englishStr, _yandexToken);// -- токен яндекса

            var result = SendYandex(queryString); // -- ПЕРЕВОД

            return result;
        }

        private string SendYandex(string queryString)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(queryString);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            StreamReader myStreamReader = new StreamReader(myHttpWebResponse.GetResponseStream());

            var str = myStreamReader.ReadToEnd();

            var result = GetFromXML(str);

            
            
            return result;
        }

        private string CreateQueryString(string englishString, string yandexToken)
        {
            if (string.IsNullOrWhiteSpace(yandexToken))
                throw new Exception("Заполните токен для сервиса яндекса в опциях!");

            //queryString = string.Format(@"https://translate.yandex.net/api/v1.5/tr/translate?key=trnsl.1.1.20150916T154114Z.3ccc4dfb24c67895.2cf775a7f8654fb0bc1b363763f2549ea0a874ae&lang=en-ru&text={0}.", stringToQuery);

            //To+be,+or+not+to+be+That+is+the+question
            var stringToQuery = StringParser.RemoveSpaces(englishString).Replace(" ", "+");

            string queryString = "";


            if (!string.IsNullOrWhiteSpace(stringToQuery))
                queryString = string.Format(@"https://translate.yandex.net/api/v1.5/tr/translate?key={0}&lang=en-ru&text={1}.", yandexToken, stringToQuery);

            return queryString;


        }

        public string GetFromXML(string xmlString)
        {
            XDocument xmlDocument = XDocument.Parse(xmlString);
            var res = xmlDocument.Descendants("text").First().Value;

            return res;
        }

        public RowRuEng[] TranslateRowList(params RowRuEng[] rowList)
        {
            ////queryString = string.Format(@"https://translate.yandex.net/api/v1.5/tr/translate?key=trnsl.1.1.20150916T154114Z.3ccc4dfb24c67895.2cf775a7f8654fb0bc1b363763f2549ea0a874ae&lang=en-ru&text={0}.", stringToQuery);

            ////переводим строку на русский
            //Translater t = new Translater("trnsl.1.1.20150916T154114Z.3ccc4dfb24c67895.2cf775a7f8654fb0bc1b363763f2549ea0a874ae");
            //var test = t.TranslateOneStringWithYandex("hello");

            ////сохраняем строку в эксель
            //ExcelHelper excelHelper = new ExcelHelper(tbFilePath.Text);
            //excelHelper.WriteStr(1,"A1",test);


            //для каждой строки
            //  берем ее англ часть
            //  если есть русская часть
            //      тогда континуе
            //  если такая же англ есть на одну выше
            //      тогда континуе

            //  переводим эту англ часть
            //  записываем перевод в русскую часть

            //сохранить полученные строки в эксель

            Translater translater = new Translater("trnsl.1.1.20150916T154114Z.3ccc4dfb24c67895.2cf775a7f8654fb0bc1b363763f2549ea0a874ae");

            for (int i = 0; i < rowList.Length; i++)
            {
                var row = rowList[i];

                if (!string.IsNullOrWhiteSpace(row.RuStr))
                    continue;

                //если ткущая англ часть == предыдущей , тогда не переводим
                if (i != 0 && rowList[i - 1].EnStr.Trim().ToUpper() == row.EnStr)
                    continue;

                if (string.IsNullOrWhiteSpace(row.EnStr))
                    continue;

                row.RuStr =  translater.TranslateOneStringWithYandex(row.EnStr);
                

            }

            return rowList;
            
        }
    }
}
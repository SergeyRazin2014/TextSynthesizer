using System;
using System.Speech.Synthesis;
using System.Linq;
using System.Collections.Generic;

namespace TextSynthesizer
{
    public class FillPromptBuilder
    {
        private PromptBuilder promptBuilder;

        public FillPromptBuilder(PromptBuilder promptBuilder)
        {
            this.promptBuilder = promptBuilder;
        }

        private List<string> GetSplitWithEndBracket(List<string> strList)
        {
            var resList = new List<string>();

            foreach (var item in strList)
            {
                if (item.Contains("{"))
                    resList.Add(item + "}");
                else
                    resList.Add(item);
            }

            return resList;
        }

        private List<string> GetSplitByEndBracket(string str)
        {
            var split = str.Split('}').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            var res = GetSplitWithEndBracket(split);

            return res;
        }

        public void Execute(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return;

            //если есть фигурные скобки - разбить на временные интервалы
            if (str.Contains("{") && str.Contains("}"))
            {
                //получили разбитие типа {3} Привет {1} буфет {2} => в массив [{3}] [Привет{1}] [буфет{2}]
                var split = GetSplitByEndBracket(str);



                foreach (var substr in split)
                {
                    //если это чисто пауза
                    if (substr.StartsWith("{") && substr.EndsWith("}"))
                    {
                        //то получаем паузу
                        var breakVal = GetBreakVal(substr);
                        AddBreak(breakVal);
                    }
                    else if (substr.Contains("{"))  //если это текст с паузой
                    {
                        var breakStr = StringParser.GetOneCurlyBracket(substr);
                        var breakVal = GetBreakVal(breakStr);
                        var text = substr.Replace(breakStr, "");

                        promptBuilder.AppendText(text);
                        AddBreak(breakVal);
                    }
                    else //если это текст без паузы
                    {
                        promptBuilder.AppendText(substr);
                    }
                }
            }
            else
            {
                promptBuilder.AppendText(str);
            }
        }

        private void AddBreak(int breakVal)
        {
            promptBuilder.AppendBreak(TimeSpan.FromSeconds(breakVal));
        }

        private int GetBreakVal(string str)
        {
            var res = str.Replace("{", "").Replace("}", "");

            if (!StringParser.IsNumber(res))
                throw new Exception("Неверное значение - " + res + " в фигурных скобках должны быть только цифры");

            return int.Parse(res);
        }
    }
}
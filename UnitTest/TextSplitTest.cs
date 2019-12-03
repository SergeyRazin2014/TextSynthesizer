using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TextSynthesizer;

namespace UnitTest
{
	[TestFixture]
	public class TextSplitTest
	{
		[TestCase('a')]
		public void IsLatinLetterTest(char a)
		{
			var result = new TextSplitter().IsLatinLetter(a);

			Assert.True(result);
		}

		[TestCase("привет hello")]
		public void SplitStringTest(string str)
		{
			var result = new TextSplitter().SplitString(str);
			Assert.AreEqual("привет", result.RuStr);
			Assert.AreEqual("hello", result.EnStr);

		}

		[TestCase("привет (буфет) hello")]
		public void SplitStringTestWhenBrackets(string str)
		{
			var result = new TextSplitter().SplitString(str);
			Assert.AreEqual("привет (буфет)", result.RuStr);
			Assert.AreEqual("hello", result.EnStr);

		}

		[TestCase("")]
		[TestCase("  ")]
		[TestCase("  1")]
		[TestCase("1")]
		[TestCase(null)]
		[TestCase("hello world")]
		public void SplitStringTestWhenError(string str)
		{
			var result = new TextSplitter().SplitString(str);
			Assert.Null(result);

		}

	}
}

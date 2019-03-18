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
    public class StringParserTest
    {
        [Test]
        public void SayStrTest_When_Break_AfterText()
        {
            //var speaker = new Speaker();
            //speaker.SayStr("Привет {1}", Constants.Ru);
        }

        [Test]
        public void SayStrTest_When_Break_BeforText()
        {
            //var speaker = new Speaker();
            //speaker.SayStr("{1}Привет{1}буфет{1}", Constants.Ru);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using D11Bot.AzureWebApi.DataParsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D11Bot.Tests
{
    [TestClass]
    public class WikiQuoteParserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sut = new WikiQuoteParser();

            var lines = sut.ReadDataFile();

            Assert.IsNotNull(lines);
            Assert.IsTrue(lines.Length > 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sut = new WikiQuoteParser();
            var lines = sut.ReadDataFile();

            var result = sut.ParseLines(lines);

            Assert.IsNotNull(result);

            var first = result[0];
            Assert.AreEqual("Bandy Mona", first.Character);
            Assert.AreEqual("Lasse Rimmer", first.Actor);
            Assert.AreEqual("Meget overtroisk mand", first.Role);

            var firstQuote = first.Quotes[0];
            Assert.AreEqual("Umla dumla tjippertjep!", firstQuote.QuoteText);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var sut = new WikiQuoteParser();
            var lines = sut.ReadDataFile();
            var result = sut.ParseLines(lines);

            var flattened = sut.Flatten(result);

            Assert.IsTrue(flattened.Count > 0);
        }

    }
}

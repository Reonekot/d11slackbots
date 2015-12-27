using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using D11Bot.AzureWebApi.DataParsers;
using D11Bot.AzureWebApi.Models;
using D11Bot.AzureWebApi.Models.MandrilQuote;

namespace D11Bot.AzureWebApi.SlackCommandHandlers
{
    public class MandrilHandler
        : SlackBaseCommandHandler
    {
        private static List<MandrilFullQuote> _quotes = null;
        private static Random _rand = new Random();

        static MandrilHandler()
        {
            _quotes = InitWikiQuotes();
        }

        public override Task<string> ExecuteAsync(SlackMessage message)
        {
            var pick = _rand.Next(0, _quotes.Count);

            var q = _quotes[pick];

            var msg = $"[{q.Character}] : {q.QuoteText}";

            return Task.FromResult(msg);
        }

        private static List<MandrilFullQuote> InitWikiQuotes()
        {
            var parser = new WikiQuoteParser();
            var lines = parser.ReadDataFile();
            var quotesParsed = parser.ParseLines(lines);

            return parser.Flatten(quotesParsed);
        }
    }
}
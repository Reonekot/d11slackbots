using System.Collections.Generic;

namespace D11Bot.AzureWebApi.Models.MandrilQuote
{
    public class MandrilQuoteSection
    {
        public MandrilQuoteSection()
        {
            Quotes = new List<MandrilQuote>();
        }

        public string Actor { get; internal set; }
        public string Character { get; internal set; }
        public string Role { get; internal set; }
        public List<MandrilQuote> Quotes { get; }
    }
}
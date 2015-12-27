namespace D11Bot.AzureWebApi.Models.MandrilQuote
{
    public class MandrilQuote
    {
        public MandrilQuote(string quote)
        {
            QuoteText = quote;
        }

        public string QuoteText { get; set; }
    }
}
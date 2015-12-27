namespace D11Bot.AzureWebApi.Models.MandrilQuote
{
    public class MandrilFullQuote
    {
        public MandrilFullQuote(string character, string v2, string role, string quoteText)
        {
            Character = character;
            Role = role;
            QuoteText = quoteText;
        }

        public string Character { get; set; }
        public string Role { get; set; }
        public string QuoteText { get; set; }
    }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;
using D11Bot.AzureWebApi.Models;
using Newtonsoft.Json.Linq;

namespace D11Bot.AzureWebApi.SlackCommandHandlers
{
    public class DefaultHandler
        : SlackBaseCommandHandler
    {
        
        public override async Task<string> ExecuteAsync(SlackMessage message)
        {
            var pick = (new Random().Next(0, 2)) == 0 ? false : true;

            string msg = null;

            if (pick)
            {
                msg = $"Den er god med dig, {message.UserName}";
            }
            else
            {
                msg = await GetQuote();
            }

            return msg;
        }

        private async Task<string> GetQuote()
        {
            using (var client = new HttpClient())
            {
                // https://theysaidso.com/api/
                var json = await client.GetStringAsync("http://api.theysaidso.com/qod.json");

                dynamic obj = JObject.Parse(json);

                string tmp = "Error";
                if (obj.success.total > 0)
                {
                    tmp = obj.contents.quotes[0].quote;
                }

                return tmp;
            }
        }
    }
}
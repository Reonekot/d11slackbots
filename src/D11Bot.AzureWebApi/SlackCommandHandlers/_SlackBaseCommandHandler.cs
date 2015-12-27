using System.Threading.Tasks;
using D11Bot.AzureWebApi.Models;

namespace D11Bot.AzureWebApi.SlackCommandHandlers
{
    public abstract class SlackBaseCommandHandler
    {
        public abstract Task<string> ExecuteAsync(SlackMessage message);
    }
}
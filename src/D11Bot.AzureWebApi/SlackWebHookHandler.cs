using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using D11Bot.AzureWebApi.Models;
using D11Bot.AzureWebApi.SlackCommandHandlers;
using Microsoft.AspNet.WebHooks;

namespace D11Bot.AzureWebApi
{
    public class SlackWebHookHandler : WebHookHandler
    {
        public override async Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            NameValueCollection nvc;

            if (context.TryGetData<NameValueCollection>(out nvc))
            {
                var sm = SlackMessage.Create(nvc);

                var handler = GetHandler(sm.Handler);

                var handlerResponse = await handler.ExecuteAsync(sm);
                
                var reply = new SlackResponse(handlerResponse);
                context.Response = context.Request.CreateResponse(reply);
            }
        }

        private SlackBaseCommandHandler GetHandler(string handler)
        {
            SlackBaseCommandHandler commandHandler = null; ;

            if (handler == "mandril")
            {
                commandHandler = new MandrilHandler();
            }
            else
            {
                commandHandler = new DefaultHandler();
            }

            return commandHandler;
        }
    }
}
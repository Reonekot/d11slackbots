using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace D11Bot.AzureWebApi.Models
{
    //   token = Mb0W1ScAjTc4YbQMRmRV9Z68
    // & team_id = T0GGNC62Y
    // & team_domain = lummerkrogen
    // & service_id = 16664152050
    // & channel_id = C0GKJQBC7
    // & channel_name = test
    // & timestamp = 1450173474.000003
    // & user_id = U0GGUC745
    // & user_name = toke
    // & text = d11bot + test
    // & trigger_word = d11bot
    // & subtext = test}

    public class SlackMessage
    {
        public string Handler { get; private set; }
        public string HandlerQuestion { get; private set; }
        public string Subtext { get; private set; }
        public string UserName { get; private set; }

        internal static SlackMessage Create(NameValueCollection nvc)
        {
            var msg = new SlackMessage();

            msg.Subtext = nvc["subtext"];
            msg.UserName = nvc["user_name"];

            var questionAndHandler = msg.Subtext.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (questionAndHandler.Length > 0)
            {
                msg.Handler = questionAndHandler[0].Trim().ToLowerInvariant();
                msg.HandlerQuestion = string.Join(" ", questionAndHandler);
            }

            return msg;
        }
    }
}
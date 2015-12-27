using D11Bot.AzureWebApi.Models;
using D11Bot.AzureWebApi.SlackCommandHandlers;
using System.Collections.Specialized;
using System.Web.Http;

namespace D11Bot.AzureWebApi.Controllers
{
    public class SlackTestController : ApiController
    {
        // http://d11botazurewebapi.azurewebsites.net/api/slacktest/mandril
        [HttpGet]
        public string Mandril()
        {
            var nvc = new NameValueCollection();
            nvc.Add("subtext", "mandril");
            nvc.Add("user_name", "toke");

            var sm = SlackMessage.Create(nvc);

            var handler = new MandrilHandler();
            var result = handler.ExecuteAsync(sm).Result;

            return result;
        }

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}

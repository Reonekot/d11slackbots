using D11Bot.AzureWebApi.Models.MandrilQuote;
using System.Collections.Generic;
using System.Web.Hosting;

namespace D11Bot.AzureWebApi.DataParsers
{
    public class WikiQuoteParser
    {
        public string[] ReadDataFile()
        {
            string mappedPath = null;

            if (HostingEnvironment.IsHosted)
            {
                mappedPath = HostingEnvironment.MapPath("~/App_Data/MandrilData.txt");
            }
            else
            {
                mappedPath = "App_Data\\MandrilData.txt";
            }
            
            return System.IO.File.ReadAllLines(mappedPath);
        }

        public List<MandrilQuoteSection> ParseLines(string[] lines)
        {
            var result = new List<MandrilQuoteSection>();
            MandrilQuoteSection currentSection = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("#"))
                {
                    continue;
                }

                if (line.StartsWith("==="))
                {
                    if (currentSection != null)
                    {
                        result.Add(currentSection);
                    }

                    currentSection = ParseHeader(line);
                }

                if (currentSection == null)
                {
                    continue;
                }

                if (line.StartsWith("''"))
                {
                    FillRole(currentSection, line);
                }

                if (line.StartsWith("{{citat|"))
                {
                    AddQuote(currentSection, line);
                }
            }

            return result;
        }

        public List<MandrilFullQuote> Flatten(List<MandrilQuoteSection> sections)
        {
            var flatten = new List<MandrilFullQuote>();

            foreach (var x in sections)
            {
                foreach (var y in x.Quotes)
                {
                    flatten.Add(new MandrilFullQuote(x.Character, x.Actor, x.Role, y.QuoteText));
                }
            }

            return flatten;
        }

        private void AddQuote(MandrilQuoteSection currentSection, string line)
        {
            var start = line.IndexOf("citat|") + "citat|".Length;
            var end = line.IndexOf("}}");

            var quote = line.Substring(start, end - start);

            currentSection.Quotes.Add(new MandrilQuote(quote));
        }

        private void FillRole(MandrilQuoteSection currentSection, string line)
        {
            currentSection.Role = line.Replace("''", "");
        }

        private MandrilQuoteSection ParseHeader(string line)
        {
            var currentSection = new MandrilQuoteSection();

            var actorStart = line.IndexOf(" (", 3);
            var headerEnd = line.IndexOf("===", 3);

            if (actorStart != -1)
            {
                currentSection.Actor = line.Substring(actorStart + 2, (headerEnd - actorStart - 3));
            }
            else
            {
                actorStart = headerEnd;
            }
            currentSection.Character = line.Substring(3, actorStart - 3);

            return currentSection;
        }
    }
}
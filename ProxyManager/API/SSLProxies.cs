using ProxyManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyManager.API
{
    internal sealed class SSLProxies
    {
        public static IEnumerable<string> Scrape(CancellationTokenSource cts)
        {
            var scraped = new List<string>();

            string htmlResponse = RequestHelper.PerformGET(cts, "http://sslproxies24.blogspot.com/");
            foreach (Match siteMatch in Regex.Matches(htmlResponse, @"itemprop='name'>\s<a href='(.*?)'"))
            {
                string response = RequestHelper.PerformGET(cts, siteMatch.Groups[1].Value);

                foreach (Match proxyMatch in Regex.Matches(response, @"(([1-9][0-9]{2}|[1-9][0-9]|[1-9])\.([1-9][0-9]|[1-9][0-9]{2}|[0-9]))\.([0-9]|[1-9][0-9]|[1-9][0-9]{2})\.([0-9]|[1-9][0-9]|[1-9][0-9]{2})\:([1-9][0-9]{4}|[1-9][0-9]{3}|[1-9][0-9]{2}|[1-9][0-9]|[1-9])"))
                {
                    scraped.Add(proxyMatch.Groups[0].Value);
                }
            }

            return scraped.Distinct();
        }
    }
}

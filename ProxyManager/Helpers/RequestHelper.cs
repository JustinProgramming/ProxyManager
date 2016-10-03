using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyManager.Helpers
{
    internal sealed class RequestHelper
    {
        public static string PerformGET(CancellationTokenSource cts, string url)
        {
            try
            {
                var request = WebRequest.CreateHttp(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";

                IAsyncResult asyncResult = request.BeginGetResponse(null, null);
                WaitHandle.WaitAny(new WaitHandle[] { asyncResult.AsyncWaitHandle, cts.Token.WaitHandle });

                if (cts.IsCancellationRequested)
                {
                    request.Abort();
                    return string.Empty;
                }

                using (var response = (HttpWebResponse)request.EndGetResponse(asyncResult))
                {
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (WebException)
            {
                return string.Empty;
            }
        }

        public static bool PerformGET(CancellationTokenSource cts, string url, string proxy, int timeout)
        {
            if (string.IsNullOrEmpty(proxy))
            {
                return false;
            }

            try
            {
                var request = WebRequest.CreateHttp(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
                request.Proxy = new WebProxy(proxy);
                request.Timeout = timeout;

                IAsyncResult asyncResult = request.BeginGetResponse(null, null);
                WaitHandle.WaitAny(new WaitHandle[] { asyncResult.AsyncWaitHandle, cts.Token.WaitHandle });     
                
                if (cts.IsCancellationRequested)
                {
                    request.Abort();
                    return false;
                } 

                using (var response = (HttpWebResponse)request.EndGetResponse(asyncResult))
                {
                    return ((int)response.StatusCode) >= 200 && ((int)response.StatusCode) < 300;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

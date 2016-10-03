using ProxyManager.Helpers;
using ProxyManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyManager.Controllers
{
    internal sealed class ProxyController
    {
        public static bool CheckValidity(Proxy proxy, CancellationTokenSource cts, Setting setting)
        {
            var sw = new Stopwatch();

            sw.Start();
            bool success = RequestHelper.PerformGET(cts, "https://www.google.com/", proxy.IP, setting.Timeout);
            sw.Stop();

            cts.Token.ThrowIfCancellationRequested();

            proxy.Timeout = (int)Math.Round((decimal)sw.ElapsedMilliseconds, 0);
            return success;
        }
    }
}

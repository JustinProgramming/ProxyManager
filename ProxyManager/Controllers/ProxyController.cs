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
        public static bool CheckValidity(string proxy, CancellationTokenSource cts, Setting setting)
        {
            bool success = RequestHelper.PerformGET(cts, "https://www.google.com/", proxy, setting.Timeout);
            cts.Token.ThrowIfCancellationRequested();
            return success;
        }
    }
}

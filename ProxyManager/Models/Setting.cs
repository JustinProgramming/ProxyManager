using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyManager.Models
{
    public sealed class Setting
    {
        public int Timeout { get; set; } = 10000;

        public Setting() { }

        public Setting(int timeout)
        {
            Timeout = timeout;
        }
    }
}

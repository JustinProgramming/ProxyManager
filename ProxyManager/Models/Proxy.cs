using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyManager.Models
{
    public sealed class Proxy
    {
        public string IP { get; set; }
        public int Timeout { get; set; }

        public Proxy(string ip)
        {
            IP = ip;
        }
        
        public ListViewItem ToListViewItem()
        {
            var item = new ListViewItem(new string[] { IP, Timeout.ToString() }) { Tag = this };
            item.ForeColor = (Timeout <= 250) ? Color.Green : Color.Orange;

            if (Timeout > 5000)
            {
                item.ForeColor = Color.Red;
            }

            return item;
        }
    }
}

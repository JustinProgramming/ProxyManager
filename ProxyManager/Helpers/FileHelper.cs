using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyManager.Helpers
{
    internal sealed class FileHelper
    {
        public static string Save(string title)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Choose your output location";
                sfd.Filter = "Text Files |*.txt";
                sfd.FileName = $"Proxies [{DateTime.Today.ToString("dd-MM")}]";

                if (sfd.ShowDialog().Equals(DialogResult.OK))
                {
                    return sfd.FileName;
                }
            }

            return string.Empty;
        }

        public static async void WriteToFile(string fileName, IEnumerable<string> content)
        {
            using (var sw = new StreamWriter(fileName))
            {
                foreach (string line in content)
                {
                    await sw.WriteLineAsync(line);
                }
            }
        }
    }
}

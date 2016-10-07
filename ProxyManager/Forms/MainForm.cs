using ProxyManager.API;
using ProxyManager.Controllers;
using ProxyManager.Helpers;
using ProxyManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProxyManager.Forms
{
    public partial class MainForm : Form
    {
        XmlHelper _xml;
        CancellationTokenSource _cts = new CancellationTokenSource();

        Setting _setting = new Setting();

        public delegate void UpdateScraperCallBack(List<string> scraped);
        public delegate void AddToListBoxCallBack(string proxy);
        public delegate void UpdateStatisticsCallBack();

        List<string> _scraped = new List<string>();
        List<string> _checked = new List<string>();
        int _checkedCounter = 0;

        bool _scraperActive = false;
        bool _checkerActive = false;

        public MainForm()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Proxy Manager\Settings.xml";
            _xml = new XmlHelper(filePath);

            InitializeComponent();

            var settingNodes = _xml.Read();
            if (settingNodes.Count < 1)
            {
                return;
            }

            _setting.Timeout = int.Parse(_xml.GetValue(settingNodes[0], "Timeout"));
            UpdateSettingsOnUI();
        }

        #region Scraping

        private async void btnStartScraping_Click(object sender, EventArgs e)
        {
            if (_checkerActive)
            {
                MessageBox.Show("You have to stop checking!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SwitchScraperButtons();
            _scraperActive = true;

            _cts = new CancellationTokenSource();
            _scraped = new List<string>();
            gbScraped.Text = "Scraped [0]";
            lbScraped.Items.Clear();

            await Task.Factory.StartNew(() =>
            {
                _scraped = SSLProxies.Scrape(_cts).ToList();
            });

            Invoke(new UpdateScraperCallBack(UpdateScraper), _scraped);

            SwitchScraperButtons();
            _scraperActive = false;
        }

        private void btnStopScraping_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }

        private void SwitchScraperButtons()
        {
            btnStartScraping.Enabled = !btnStartScraping.Enabled;
            btnStopScraping.Enabled = !btnStopScraping.Enabled;
        }

        public void UpdateScraper(List<string> scraped)
        {
            gbScraped.Text = $"Scraped [{_scraped.Count}]";
            lbScraped.Items.AddRange(_scraped.ToArray());
        }

        #endregion

        #region Checking

        private async void btnStartChecking_Click(object sender, EventArgs e)
        {
            if (_scraperActive)
            {
                MessageBox.Show("You have to stop scraping!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_scraped.Count == 0)
            {
                MessageBox.Show("There are no proxies to check!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SwitchCheckerButtons();
            _checkerActive = true;

            _cts = new CancellationTokenSource();
            _checked = new List<string>();
            _checkedCounter = 0;
            lbChecked.Items.Clear();
            UpdateStatistics();

            await Task.Factory.StartNew(() =>
            {
                ParallelOptions po = new ParallelOptions() { CancellationToken = _cts.Token };

                try
                {
                    Parallel.ForEach(_scraped, po, (proxy) =>
                    {
                        if (ProxyController.CheckValidity(proxy, _cts, _setting))
                        {
                            _checked.Add(proxy);
                            Invoke(new AddToListBoxCallBack(AddToListBox), proxy);
                        }

                        _checkedCounter++;
                        Invoke(new UpdateStatisticsCallBack(UpdateStatistics));
                    });
                }
                catch (OperationCanceledException) { }
            });

            SwitchCheckerButtons();
            _checkerActive = false;
        }

        private void btnStopChecking_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }

        private void SwitchCheckerButtons()
        {
            btnStartChecking.Enabled = !btnStartChecking.Enabled;
            btnStopChecking.Enabled = !btnStopChecking.Enabled;
        }

        public void AddToListBox(string proxy)
        {
            lbChecked.Items.Add(proxy);
        }

        public void UpdateStatistics()
        {
            gbChecked.Text = $"Checked [{_checkedCounter}/{_scraped.Count}]";
            lblWorking.Text = $"Working: {_checked.Count}";
        }

        #endregion

        #region Settings

        private void btnReset_Click(object sender, EventArgs e)
        {
            _setting = new Setting();
            UpdateSettingsOnUI();

            SaveSettingsToFile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _setting.Timeout = (int)nudTimeout.Value;

            SaveSettingsToFile();
        }

        private void SaveSettingsToFile()
        {
            _xml.ResetFileContents();

            var timeoutNode = _xml.CreateNode("Timeout", _setting.Timeout.ToString());

            _xml.Save(new XmlNode[] { timeoutNode }); 
        }

        private void UpdateSettingsOnUI()
        {
            nudTimeout.Value = _setting.Timeout;
        }

        #endregion

        #region Exporting

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_checked.Count < 1)
            {
                MessageBox.Show("There are no working proxies to save!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            string fileName = FileHelper.Save("Choose your output location");

            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            FileHelper.WriteToFile(fileName, _checked);

            MessageBox.Show("The proxies have successfuly been saved!", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}

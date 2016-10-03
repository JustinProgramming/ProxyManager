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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyManager.Forms
{
    public partial class MainForm : Form
    {
        CancellationTokenSource _cts = new CancellationTokenSource();

        Setting _setting = new Setting();

        public delegate void UpdateScraperCallBack(List<Proxy> scraped);
        public delegate void UpdateCheckerCallBack(Proxy proxy);

        List<Proxy> _scraped = new List<Proxy>();
        List<Proxy> _checked = new List<Proxy>();

        bool _scraperActive = false;
        bool _checkerActive = false;

        public MainForm()
        {
            InitializeComponent();
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
            _scraped = new List<Proxy>();
            gbScraped.Text = "Scraped [0]";
            lbScraped.Items.Clear();

            await Task.Factory.StartNew(() =>
            {
                _scraped = SSLProxies.Scrape(_cts).Select(x => new Proxy(x)).ToList();
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

        public void UpdateScraper(List<Proxy> scraped)
        {
            gbScraped.Text = $"Scraped [{_scraped.Count}]";
            lbScraped.Items.AddRange(_scraped.Select(x => x.IP).ToArray());
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
            _checked = new List<Proxy>();
            gbChecked.Text = "Checked [0]";
            lvChecked.Items.Clear();

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
                            Invoke(new UpdateCheckerCallBack(UpdateChecker), proxy);
                        }
                    });
                }
                catch (OperationCanceledException) { }
            });

            Invoke(new UpdateScraperCallBack(UpdateScraper), _checked);

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

        public void UpdateChecker(Proxy proxy)
        {
            gbChecked.Text = $"Checked [{_checked.Count}]";
            lvChecked.Items.Add(proxy.ToListViewItem());
        }

        #endregion

        #region Settings

        private void btnReset_Click(object sender, EventArgs e)
        {
            _setting = new Setting();
            nudTimeout.Value = _setting.Timeout;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}

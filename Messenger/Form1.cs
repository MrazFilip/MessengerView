using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Windows.Forms;

namespace Messenger
{
    public partial class Form1 : Form
    {
        private WebView2 webView;

        public Form1()
        {
            InitializeComponent();

            this.Icon = new Icon(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "messengerView.ico")
            );

            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            var env = await CoreWebView2Environment.CreateAsync(
                null,
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "MyMessengerApp"
                )
            );

            await webView.EnsureCoreWebView2Async(env);

            webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
            webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;

            Controls.Add(webView);

            try
            {
                webView.Source = new Uri("https://www.messenger.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Startup error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}

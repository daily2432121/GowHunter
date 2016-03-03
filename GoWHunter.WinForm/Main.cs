using System;
using System.Configuration;
using System.Windows.Forms;
using GoWHunter.Fiddler;
using MaterialSkin;
using MaterialSkin.Controls;

namespace GoWHunter.WinForm
{
    public partial class Main : MaterialForm
    {
        private readonly LiteFiddlerApp _app = new LiteFiddlerApp(ReplaceConfig.GenerateFromJson("HackList.json"),
            int.Parse(ConfigurationManager.AppSettings["FiddlerPort"]));

        public Main()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnHack_Click(object sender, EventArgs e)
        {
            if (_app.IsStarted)
            {
                return;
            }
            _app.Listen();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_app.IsClosing && _app.IsStarted)
            {
                _app.Stop();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (_app.IsClosing)
            {
                return;
            }
            if (_app.IsStarted)
            {
                _app.Stop();
            }
            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnExit_Click(sender, e);
        }
    }
}
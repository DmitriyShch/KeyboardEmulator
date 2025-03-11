using System.Text.Json;
using System.Text.RegularExpressions;

namespace KeyboardEmulator
{
    public partial class MainForm : Form
    {
        private const string SETTINGS_FILE_NAME = "settings.json";
        private readonly JsonSerializerOptions options = new() { WriteIndented = true };

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtSend_Click(object sender, EventArgs e)
        {
            btSend.Enabled = false;
            try
            {
                var initTimeout = int.Parse(tbInitTimeout.Text);
                var timeout = int.Parse(tbTimeout.Text);
                var separator = Regex.Unescape(tbSeparator.Text);
                var textLines = tbTextForSend.Text
                    .Split('\r', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Replace("\n", "") + separator);
                Thread.Sleep(initTimeout);
                foreach (var item in textLines)
                {
                    KeyboardEmulator.SendFastKeys(item);
                    Thread.Sleep(timeout);
                }
            }
            finally
            {
                btSend.Enabled = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var settings = new
            {
                TextForSend = tbTextForSend.Text,
                Separator = tbSeparator.Text,
                InitTimeout = tbInitTimeout.Text,
                Timeout = tbTimeout.Text,
            };
            if (File.Exists(SETTINGS_FILE_NAME))
                File.Delete(SETTINGS_FILE_NAME);
            File.WriteAllText(SETTINGS_FILE_NAME,
                JsonSerializer.Serialize(settings, options));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(SETTINGS_FILE_NAME))
                    return;
                var settingsStr = File.ReadAllText(SETTINGS_FILE_NAME);
                var settings = JsonSerializer
                    .Deserialize<Dictionary<string, string>>(settingsStr);
                if (settings == null)
                    return;
                tbTextForSend.Text = ReadDictParam(settings, "TextForSend", tbTextForSend.Text);
                tbSeparator.Text = ReadDictParam(settings, "Separator", tbSeparator.Text);
                tbInitTimeout.Text = ReadDictParam(settings, "InitTimeout", tbInitTimeout.Text);
                tbTimeout.Text = ReadDictParam(settings, "Timeout", tbTimeout.Text);
            }
            catch { }
        }

        private static string ReadDictParam(Dictionary<string, string> dict, string paramName,
            string defaultValue) => dict.TryGetValue(paramName, out var value)
            ? value : defaultValue;
    }
}

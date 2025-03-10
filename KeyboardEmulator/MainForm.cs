using System.Text.RegularExpressions;

namespace KeyboardEmulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btSend_Click(object sender, EventArgs e)
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
    }
}

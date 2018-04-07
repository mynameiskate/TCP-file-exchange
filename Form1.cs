using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPClientApp
{
    public partial class FileSender : Form
    {
        private User _user;
        private string _savePath;
        private Progress<string> _progress;

        public FileSender()
        {
            InitializeComponent();
            sendBtn.Enabled = false;
            _progress = new Progress<string>(s => statusTextBox.Text += s);
        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.AutoUpgradeEnabled = true;
                string fileName = openFileDialog.FileName;
                IPAddress receiverIP;
                if (IPAddress.TryParse(IPBox.Text, out receiverIP))
                {
                    int receiverPort;
                    if (int.TryParse(receiverPortTB.Text, out receiverPort))
                    {
                        await _user.Send(fileName, receiverIP, receiverPort, _progress);
                    }
                    else MessageBox.Show("Incorrect port of the receiver!");

                }
                else MessageBox.Show("Incorrect IP-address of the receiver!");
            }
                
        }

        private async void startBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _savePath = folderBrowserDialog.SelectedPath;
                pathTB.Text = _savePath;
                _user = new User();
                portTextBox.Text = _user.GetPort().ToString();
                sendBtn.Enabled = true;
                userIPTextBox.Text = User.GetLocalIP().ToString();//IPAddress.Loopback.ToString();
                await _user.Listen(_savePath, _progress);
            }
            
        }

        private void FileSender_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using seer_fiddler.core;

namespace seer_fiddler
{
    public partial class FiddlerCaptureForm : Form
    {
        public FiddlerCaptureForm()
        {
            InitializeComponent();

        }

        private void FiddlerForm_Load(object sender, EventArgs e)
        {
        }
        public void AddResponse(string response)
        {
            if (this.startCapturecheckBox.Checked)
            {
                this.requestListBox.Items.Add(response);
                this.requestListBox.SelectedIndex = this.requestListBox.Items.Count - 1;
            }
        }

        private void FiddlerCaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void removeAllItemBtn_Click(object sender, EventArgs e)
        {
            this.requestListBox.Items.Clear();
        }
    }
}

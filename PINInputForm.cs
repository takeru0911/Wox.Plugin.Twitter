using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wox.Plugin.Twitter
{
    public partial class PINInputForm : Form
    {
        private string _pinCode { get; set; }
        private string _postMassage;
        public PINInputForm(string postMassage)
        {
            _postMassage = postMassage;
            InitializeComponent();
        }

        private void PINInputForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pinInputText.Text != null)
            {
                _pinCode = pinInputText.Text;
            }
        }
    }
}

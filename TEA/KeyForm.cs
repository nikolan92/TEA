using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A51
{
    public partial class KeyForm : Form
    {
        
        public KeyForm()
        {
            InitializeComponent();
        }
        public KeyForm(string fileName)
        {
            InitializeComponent();
            fileNameLbl.Text = fileName;
        }
        public string Key
        {
            get { return textBoxKey.Text; }
        }
        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKey.Text.All(chr => chr.Equals('0') || chr.Equals('1')) && !string.IsNullOrEmpty(textBoxKey.Text) && textBoxKey.Text.Length == 128)
            {
                keyStatusLbl.ForeColor = Color.Green;
                keyStatusLbl.Text = "Valid.";
                encryptBtn.Enabled = true;
            }
            else
            {
                keyStatusLbl.ForeColor = Color.Red;
                keyStatusLbl.Text = "Invalid!";
                encryptBtn.Enabled = false;
            }
        }


        private void textBoxIV_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIV.Text.All(chr => chr.Equals('0') || chr.Equals('1')) && !string.IsNullOrEmpty(textBoxIV.Text) && textBoxIV.Text.Length == 64)
            {
                IVStatusLbl.ForeColor = Color.Green;
                IVStatusLbl.Text = "Valid.";
                encryptBtn.Enabled = true;
            }
            else
            {
                IVStatusLbl.ForeColor = Color.Red;
                IVStatusLbl.Text = "Invalid!";
                encryptBtn.Enabled = false;
            }
        }
        private void KeyForm_Load(object sender, EventArgs e)
        {
            textBoxKey.Text = "11110000111010000010001101101001000101001010000101100100100010000111000010001000111000110110100101010100101100010011010010001001";
            textBoxIV.Text = "1001001010001001101011110110100111110100101000010000010010101001";//some default key
        }

    }
}

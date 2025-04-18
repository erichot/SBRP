using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SBRPData.Helpers;

namespace SBRPWinUtility
{
    public partial class PasswordCrypto : Form
    {
        public PasswordCrypto()
        {
            InitializeComponent();
        }

        private void PasswordCrypto_Load(object sender, EventArgs e)
        {

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            var str = txtEncrypt.Text.Trim();
            if (!string.IsNullOrEmpty(str))
            {
                txtDecrypt.Text = CryptoHelper.AesDecrypt(str);
                txtDecrypt.SelectAll();
                txtDecrypt.Select();
            }
            
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var str = txtDecrypt.Text.Trim();
            if (!string.IsNullOrEmpty(str))
            {
                txtEncrypt.Text = CryptoHelper.AesEncrypt(str);
                txtEncrypt.SelectAll();
                txtEncrypt.Select();
            }
           
        }
    }
}

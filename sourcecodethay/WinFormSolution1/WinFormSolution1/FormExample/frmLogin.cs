using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormExample
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void CheckLogin()
        {
            //check validate
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter user id!");
                textBox1.Focus();
                return;
            }

            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter password!");
                textBox2.Focus();
                return;
            }

            if(textBox1.Text.Equals("hairom") && textBox2.Text.Equals("123"))
            {
                //Login OK
                new frmMain(textBox1.Text).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bay goy!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                CheckLogin();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CheckLogin();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaiRomShop
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

            using (var db = new ShopDataContext())
            {
                var user = db.Users.Where(
                    x => x.UserName.Equals(txtUserName.Text))
                    .SingleOrDefault();
                if(user != null)
                {
                    if (user.Password.Equals(txtPassword.Text))
                    {
                        //ok
                        new frmMain(user).Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Password invalid!");
                    }
                }
                else
                {
                    MessageBox.Show("User name not exist!");
                }

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                CheckLogin();
            }
        }
    }
}

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
    public partial class frmMain : Form
    {
        string userid = "";

        List<string> categories = new List<string>();

        public frmMain(string userid)
        {
            InitializeComponent();
            this.userid = userid;
            this.Text += " [" + userid + "]";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Form loading...");
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show("Form shown");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var rs = MessageBox.Show("Do you want to exit?", "Warning", MessageBoxButtons.YesNo);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmProduct f = new frmProduct();
            f.Text = "Them san pham moi";

            var rs = f.ShowDialog();
            if(rs == DialogResult.OK)
            {
                MessageBox.Show("Da them!");
            }
        }

        private void LoadCategories()
        {

        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            frmCategory f = new frmCategory();
            if(f.ShowDialog() == DialogResult.OK)
            {
                categories.Add(f.textBox1.Text);
                //LoadCategories();
                listBox1.Items.Add(f.textBox1.Text);
            }
        }

        private void btnDelCategory_Click(object sender, EventArgs e)
        {

        }
    }
}

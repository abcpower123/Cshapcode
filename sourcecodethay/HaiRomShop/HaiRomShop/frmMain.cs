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
    public partial class frmMain : Form
    {
        User c_user;
        public frmMain(User c_user)
        {
            InitializeComponent();
            this.c_user = c_user;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoadOrders()
        {
            using (var db = new ShopDataContext())
            {
                DateTime b_month = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var orders = from o in db.Orders
                             //where o.OrderDate >= b_month && o.OrderDate < DateTime.Now
                             orderby o.Status, o.Id descending
                             select new
                             {
                                 o.Id,
                                 o.OrderDate,
                                 o.Customer,
                                 Employee = o.User.FullName,
                                 Total = o.OrderDetails.Count > 0 ? 
                                 o.OrderDetails.Sum(d => 
                                 d.Quantity * d.Price) : 0,
                                 Status = o.Status == 1 ? "Pending" : "Finish"
                             };
                dgvOrders.DataSource = orders.ToList();
                dgvOrders.Columns["Id"].DefaultCellStyle.Format = "D5";
                dgvOrders.Columns["Total"].DefaultCellStyle.Format = "N0";

            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            frmOrderDetails f = new frmOrderDetails(0, c_user.Id);
            f.ShowDialog();
            LoadOrders();
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int order_id = int.Parse(dgvOrders.Rows[e.RowIndex]
                .Cells["Id"].Value.ToString());

            frmOrderDetails f = new frmOrderDetails(order_id, c_user.Id);
            f.ShowDialog();
            LoadOrders();
        }
    }
}

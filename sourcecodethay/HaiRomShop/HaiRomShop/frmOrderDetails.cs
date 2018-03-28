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
    public partial class frmOrderDetails : Form
    {
        Order order;
        int user_id;
        int order_id; //flag

        ShopDataContext db = new ShopDataContext();

        public frmOrderDetails(int order_id, int user_id)
        {
            InitializeComponent();
            this.order_id = order_id;
            this.user_id = user_id;
        }

        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            if(order_id == 0)
            {
                order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Customer = "",
                    UserId = user_id,
                    Status = 1
                };
                db.Orders.InsertOnSubmit(order);
                db.SubmitChanges();
            }
            else
            {
                order = db.Orders.Where(x => x.Id == order_id).SingleOrDefault();

                //check editing permission
                if(order.UserId != user_id || order.Status != 1)
                {
                    dtpOrderDate.Enabled = false;
                    txtCustomer.ReadOnly = true;
                    //.......
                    panel1.Enabled = false;
                    btnFinish.Enabled = false;
                }
            }

            txtId.Text = order.Id.ToString("D5");
            dtpOrderDate.Value = order.OrderDate;
            txtUser.Text = order.User.FullName;//co van de
            txtCustomer.Text = order.Customer;


            LoadOrdersDetail(0);
            cbbProducts.DataSource = db.Products.ToList();
            cbbProducts.ValueMember = "Id";
            cbbProducts.DisplayMember = "ProductName";
                cbbProducts.Text = "s";
        }
        private void LoadOrdersDetail( int od_id)
        {
            var od_list = from d in db.OrderDetails
                          where d.OrderId == order.Id
                          select new
                          {
                              d.Id,
                              d.Product.ProductName,
                              d.Unit,
                              d.Price,
                              d.Quantity,
                              Total = d.Price * d.Quantity
                          };
            dgvOD.DataSource = od_list.ToList();
            int total = od_list.ToList().Count > 0 ? od_list.Sum(x => x.Total) : 0;
            lblTotal.Text = "Total: " +total.ToString("N0")+ " $";

            foreach (DataGridViewRow row in dgvOD.Rows)
            {
                if (row.Cells["Id"].Value.ToString().Equals(od_id.ToString()))
                {
                    row.Selected = true;
                    break;
                }
            }
            
        }
        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            order.Customer = txtCustomer.Text;
            db.SubmitChanges();
        }

        private void dtpOrderDate_ValueChanged(object sender, EventArgs e)
        {
            order.OrderDate = dtpOrderDate.Value;
            db.SubmitChanges();
            
        }
        Product c_product;
        private void cbbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int p_id = int.Parse(cbbProducts.SelectedValue.ToString());
                if (p_id == 0)
                {
                    btnAdd.Enabled = false;
                    txtPrice.Enabled = false;
                    txtQuantity.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                    txtPrice.Enabled = true;
                    txtQuantity.Enabled = true;

                    c_product = db.Products.Where(x => x.Id == p_id).SingleOrDefault();
                    var od = db.OrderDetails.Where(x => x.OrderId == order.Id && x.ProductId == c_product.Id).FirstOrDefault();
                    if (od==null)
                    {
                        txtPrice.Text = c_product.Price.ToString();
                        txtQuantity.Text = "1";
                        btnAdd.Text = "Add";
                    }
                    else
                    {
                        txtPrice.Text = od.Price.ToString();
                        txtQuantity.Text = od.Quantity.ToString();
                        btnAdd.Text = "Edit";
                    }

                    txtQuantity.Focus();
                    txtQuantity.SelectAll();
                }
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var od = db.OrderDetails.Where(x => x.OrderId == order.Id && x.ProductId == c_product.Id).FirstOrDefault();
            if (od==null)
            {
                //add new
                od = new OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = c_product.Id,
                    Unit = c_product.Unit,
                    Price = int.Parse(txtPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    
                };
                db.OrderDetails.InsertOnSubmit(od);
            }
            else
            {
                od.Price = int.Parse(txtPrice.Text);
                od.Quantity = int.Parse(txtQuantity.Text);

            }
            db.SubmitChanges();
            LoadOrdersDetail(od.Id);
            btnAdd.Text = "Edit";
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnAdd.PerformClick();
                cbbProducts.Focus();
            }
        }

        private void dgvOD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int od_id = int.Parse(dgvOD.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            var od = db.OrderDetails.Where(x => x.Id == od_id).SingleOrDefault();
            cbbProducts.SelectedValue = od.ProductId;
        }
        private void delete(OrderDetail od)
        {
            var rs = MessageBox.Show("Are u sure to delete this product", "Warning", MessageBoxButtons.YesNo);
            if (rs==DialogResult.Yes)
            {
                db.OrderDetails.DeleteOnSubmit(od);
                db.SubmitChanges();
                LoadOrdersDetail(0);
            }
        }
        private void tanggiam(int q)
        {
            if (dgvOD.SelectedRows.Count == 0)
            {
                return;
            }
            int od_id = int.Parse(dgvOD.SelectedRows[0].Cells["Id"].Value.ToString());
            var od = db.OrderDetails.Where(x => x.Id == od_id).SingleOrDefault();
            if (od.Quantity<=Math.Abs(q)&& q<0)
            {
                delete(od);
            }
            else 
            od.Quantity+=q;

            db.SubmitChanges();
            LoadOrdersDetail(od_id);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            tanggiam(1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tanggiam(-1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvOD.SelectedRows.Count == 0)
            {
                return;
            }
            int od_id = int.Parse(dgvOD.CurrentRow.Cells["Id"].Value.ToString());
            var od = db.OrderDetails.Where(x => x.Id == od_id).SingleOrDefault();
            delete(od);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Are u sure to finish this order", "Warning", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                order.Status = 2;
                db.SubmitChanges();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Persistence;

namespace Tour_Manager
{
    public partial class FormEditOrder : Form
    {
        public FormEditOrder()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FormEditOrder_Load(object sender, EventArgs e)
        {
            TourBL tourBL = new TourBL();
            OrderTourBL orderTourBL = new OrderTourBL();
            var get_ordertour = orderTourBL.GetAllOrderActive();
            dataGridView1.DataSource = get_ordertour;
            comboBox2.DataSource = tourBL.GetAllTour();
            comboBox2.DisplayMember = "IDTour";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            //comboBox1.DataSource = get_ordertour;
            //comboBox1.DisplayMember = "OrderID";
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.Rows[numrow].Cells[7].Value.ToString();
            textBox4.Text = dataGridView1.Rows[numrow].Cells[8].Value.ToString();
            textBox5.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBox5.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormListTourMini formListTour = new FormListTourMini();
            formListTour.Show();
        }
        public void reload()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }
        private void FormEditOrder_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Hủy Tour Sẽ Bị Phạt 20% Tổng Tiền Của Hóa Đơn - Tiếp Tụcs?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OrderTourBL orderTourBL = new OrderTourBL();
                    if (orderTourBL.DeleteOrder(Convert.ToInt32(textBox5.Text)) == true)
                    {
                        MessageBox.Show("Hóa Đơn Đã Bị Hủy");


                        var get_ordertour = orderTourBL.GetAllOrderActive();
                        dataGridView1.DataSource = get_ordertour;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox5.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Hủy Thất Bại");
                    }
                }
                else
                {

                }
            }
            catch(System.Exception)
            {
                MessageBox.Show("Bạn Chưa Chọn");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OrderTourBL orderTourBL = new OrderTourBL();


           
           try
            {
                DialogResult dialogResult = MessageBox.Show("Ban Có Chắc Muốn Thay Đổi", "Some Title", MessageBoxButtons.YesNo);
                if (Convert.ToInt16(textBox2.Text) == Convert.ToInt16(textBox3.Text) + Convert.ToInt16(textBox4.Text))
                {
                    int a = Convert.ToInt32(textBox2.Text);
                    int b = Convert.ToInt32(textBox3.Text);
                    int c = Convert.ToInt32(textBox4.Text);
                    int d = Convert.ToInt32(textBox5.Text);
                    string k = textBox1.Text;
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (orderTourBL.UpdateOrder(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), comboBox2.Text, Convert.ToInt32(textBox5.Text)) == true)
                        {
                            MessageBox.Show("Cập Nhật Thành Công");

                            var get_ordertour = orderTourBL.GetAllOrderActive();
                            dataGridView1.DataSource = get_ordertour;
                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            textBox5.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Cập Nhật Thất Bại");
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Số Khách Hàng Không Hợp Lệ");
                }
            }
            catch(System.Exception)
            {
                MessageBox.Show("Bạn Chưa Chọn");
            }
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            this.Hide();
            formMenu.ShowDialog();
        }
    }
}

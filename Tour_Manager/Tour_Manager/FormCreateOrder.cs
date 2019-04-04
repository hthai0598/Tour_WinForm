using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistence;
using BL;

namespace Tour_Manager
{
    public partial class FormCreateOrder : Form
    {

        TourBL tourBL = new TourBL();
        OrderTourBL orderTourBL = new OrderTourBL();
        OrderTour orderTour = new OrderTour();
        public FormCreateOrder()
        {
            InitializeComponent();
        }
        string email;
        public FormCreateOrder(string emaill):this()
        {
            email = emaill;
            textBox1.Text = email;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            FormMenu formMenu = new FormMenu();
            this.Hide();
            formMenu.ShowDialog();
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            var get_tour= tourBL.GetAllTour();
            dataGridView1.DataSource = get_tour;
            comboBox1.DataSource = get_tour;
            comboBox1.DisplayMember = "IDTour";
            
          
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                orderTour = new OrderTour();
                orderTour.KH_Order = new KhachHang();
                orderTour.Tour_Order = new Tour();
                orderTour.SoKH = Convert.ToInt32(textBox2.Text);
                orderTour.SoNguoiLon = Convert.ToInt32(textBox3.Text);
                orderTour.SoTreEm = Convert.ToInt32(textBox4.Text);
                string id = comboBox1.Text;

                if(orderTour.SoKH == orderTour.SoNguoiLon+orderTour.SoTreEm )
                {
                    if (orderTourBL.Create_Order(textBox1.Text, id, orderTour) == true)
                    {
                        MessageBox.Show("Tạo Thành Công");
                        var get_tour = tourBL.GetAllTour();
                        dataGridView1.DataSource = get_tour;
                    }
                    else
                    {
                        MessageBox.Show("Tạo Không Thành Công");
                    }
                }
                else
                {
                    MessageBox.Show("Số Khách Hàng Không Hợp Lệ");
                }


            }
            catch(System.Exception)
            {
                
                MessageBox.Show("Bạn Nhập Sai");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

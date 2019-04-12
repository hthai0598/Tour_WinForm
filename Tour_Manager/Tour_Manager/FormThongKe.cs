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
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gia;
            float tong = 0;
            OrderTourBL orderTourBL = new OrderTourBL();
            dataGridView1.DataSource = orderTourBL.GetOrderInDay(comboBox1.Text);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                gia = Convert.ToInt32((row.Cells[3].Value));
                tong = tong + gia;
            }

            label3.Text = "Doanh Thu: " + String.Format("{0:0,0 VNĐ}", tong);
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            OrderTourBL orderTourBL = new OrderTourBL();
            comboBox1.DataSource = orderTourBL.GetDate();
            comboBox1.DisplayMember = "date";
            dataGridView1.DataSource = orderTourBL.GetOrderInDay(comboBox1.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            this.Hide();
            formMenu.ShowDialog();
        }
    }
}

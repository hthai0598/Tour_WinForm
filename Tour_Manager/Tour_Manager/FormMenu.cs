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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCheckEmail formCheck = new FormCheckEmail();
            this.Hide();
            formCheck.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormTourManager formTourManager = new FormTourManager();
            this.Hide();
            formTourManager.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormEditOrder searchOrder = new FormEditOrder();
            this.Hide();
            searchOrder.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormThongKe formThongKe = new FormThongKe();
            this.Hide();
            formThongKe.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormKhManager formKhManager = new FormKhManager();
            this.Hide();
            formKhManager.ShowDialog();
        }
    }
}

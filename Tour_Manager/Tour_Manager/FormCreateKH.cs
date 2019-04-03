using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Persistence;
namespace Tour_Manager
{
    public partial class FormCreateKH : Form
    {
        public FormCreateKH()
        {
            InitializeComponent();
        }
        string email;
        public FormCreateKH(string emaill):this()
        {
            email = emaill;
            textBox1.Text = email;
            textBox1.Enabled = false;
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            this.Hide();
            formMenu.ShowDialog();
        }
        

        private void FormCreateKH_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KhBL khBL = new KhBL();
            
                if (khBL.InsertKH(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text)) == true)
                {
                this.Hide();
                FormCreateOrder formCreateOrder = new FormCreateOrder(textBox1.Text);
                formCreateOrder.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thêm Không Thành Công");
                }
            
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 122) || (e.KeyChar == 8));
        }
    }
}

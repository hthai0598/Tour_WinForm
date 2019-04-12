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

namespace Tour_Manager
{
    public partial class FormKhManager : Form
    {
        public FormKhManager()
        {
            InitializeComponent();
        }

        private void FormKhManager_Load(object sender, EventArgs e)
        {
            KhBL khBL = new KhBL();
            var a = khBL.GetKH();
            dataGridView1.DataSource = a;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
           
            
        }

        private void Tên(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                KhBL khBL = new KhBL();
                string kh = textBox1.Text;
                string name = textBox2.Text;
                int phone = Convert.ToInt16(textBox3.Text);
                if (khBL.UpdateKH(kh, name, phone) == true)
                {
                    MessageBox.Show("Thay Đổi thành công");
                    var a = khBL.GetKH();
                    dataGridView1.DataSource = a;
                }
                else
                {
                    MessageBox.Show("Thay Đổi Không thành công");
                }
            }
            catch(System.Exception)
            {
                MessageBox.Show("Bạn Chưa Nhập");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                KhBL khBL = new KhBL();
                string kh = textBox1.Text;
                if (khBL.DeleteKH(kh) == true)
                {
                    MessageBox.Show("Xóa thành công");
                    var a = khBL.GetKH();
                    dataGridView1.DataSource = a;
                }
                else
                {
                    MessageBox.Show("Xóa Không thành công");
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Bạn Chọn Không Hợp Lệ");
            }
        }

        private void FormKhManager_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            this.Hide();
            formMenu.ShowDialog();
        }
    }
}

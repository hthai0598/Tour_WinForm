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
    public partial class FormTourManager : Form
    {
        public FormTourManager()
        {
            InitializeComponent();
        }
        public void reload()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormTourManager_Load(object sender, EventArgs e)
        {
            TourBL tourBL = new TourBL();
            var a = tourBL.GetAllTours();
            dataGridView1.DataSource = a;
            comboBox1.Text = "Active";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TourBL tourBL = new TourBL();
            Tour tour = new Tour();

            try
            {
                DateTime ngaydi = Convert.ToDateTime(dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                int songay = Convert.ToInt32(textBox5.Text);
                int khuyenmai = Convert.ToInt32(textBox6.Text);
                int gia = Convert.ToInt32(textBox7.Text);


                if (textBox1.Text == null)
                {
                    MessageBox.Show("Mã Tour Không Được Bỏ Trống");
                }
                else if(ngaydi<=DateTime.Now)
                {
                    MessageBox.Show("Ngày Bạn Chọn Không Hợp Lệ");
                }
                else
                {
                    if (tourBL.InsertTour(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, songay, ngaydi, khuyenmai, gia,comboBox1.Text) == true)
                    {
                        var a = tourBL.GetAllTours();
                        dataGridView1.DataSource = a;
                        MessageBox.Show("Tour Đã Được Thêm!");
                        reload();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại!");
                    }
                }


            }
            catch (System.Exception)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ");
            }



        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
            
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
           
            textBox1.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[numrow].Cells[7].Value.ToString();
            textBox1.Enabled = false;
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TourBL tourBL = new TourBL();
            Tour tour = new Tour();

            try
            {
                DateTime ngaydi = Convert.ToDateTime(dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                int songay = Convert.ToInt32(textBox5.Text);
                int khuyenmai = Convert.ToInt32(textBox6.Text);
                int gia = Convert.ToInt32(textBox7.Text);


                if (textBox1.Text == null)
                {
                    MessageBox.Show("Mã Tour Không Được Bỏ Trống");
                }
                else if (ngaydi <= DateTime.Now)
                {
                    MessageBox.Show("Ngày Bạn Chọn Không Hợp Lệ");
                }
                else
                {
                    if (tourBL.EditTour(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, songay, ngaydi, khuyenmai, gia,comboBox1.Text) == true)
                    {
                        var a = tourBL.GetAllTours();
                        dataGridView1.DataSource = a;
                        MessageBox.Show("Tour Đã Được Sửa!");
                        reload();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất Bại!");
                    }
                }


            }
            catch (System.Exception)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ");
            }


        }

        private void FormTourManager_Click(object sender, EventArgs e)
        {
            reload();
            textBox1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            this.Hide();
            formMenu.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

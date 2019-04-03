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
    public partial class FormCheckEmail : Form
    {
        public FormCheckEmail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KhBL khBL = new KhBL();
            if(isEmail(textBox1.Text) == true)
            {
                var check = khBL.CheckKH(textBox1.Text);
                if (check != null)
                {
                    this.Hide();
                    FormCreateOrder formCreateOrder = new FormCreateOrder(textBox1.Text);

                    formCreateOrder.ShowDialog();
                }
                else
                {
                    FormCreateKH formCreateKH = new FormCreateKH(textBox1.Text);
                    FormMenu formMenu = new FormMenu();

                    DialogResult dialogResult = MessageBox.Show("Bạn Chưa Có Email Trong Hệ Thống - Đăng Ký Ngay ?", "Some Title", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        formMenu.Close();
                        this.Hide();
                        formCreateKH.ShowDialog();
                    }
                    else
                    {

                    }
                }
            
                
            }
            else
            {
                MessageBox.Show("Email Bạn Nhập Không Hợp Lệ");
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            this.Hide();
            formMenu.ShowDialog();
        }

        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        private void FormCheckEmail_Load(object sender, EventArgs e)
        {

        }
    }
}

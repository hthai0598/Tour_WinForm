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
    public partial class FormListTourMini : Form
    {
        public FormListTourMini()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormListTourMini_Load(object sender, EventArgs e)
        {
            TourBL tourBL = new TourBL();
            var get_tour = tourBL.GetAllTour();
            dataGridView1.DataSource = get_tour;
           
        }
    }
}

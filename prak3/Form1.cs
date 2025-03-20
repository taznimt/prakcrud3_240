using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prak3
{
    public partial class Form1: Form
    {
        private string connectionString = "Data Source=LAPTOP-GH806S35\\TASNIM;Initial Catalog=OrganisasiMahasiswa;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Metode LoadData dipanggil.");
        }
        private void ClearForm()
        {
            txtNIM.Clear();
            txtNama.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
            txtEmail.Clear();
            txtTelepon.Clear();
            txtAlamat.Clear();

            txtNIM.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT NIM AS [NIM], Nama, Email, Telepon, Alamat FROM Mahasiswa";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    // Membuat objek DataTable untuk menampung hasil query
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvMahasiswa.AutoGenerateColumns = true;

                    dgvMahasiswa.DataSource = dt;

                    ClearForm();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (labelNIM.Text == "" || labelNama.Text == "" || labelEmail.Text == "" || labelTelepon.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return; 
                    }

                    conn.Open();

                    string query = "INSERT INTO Mahasiswa (NIM, Nama, Email, Telepon, Alamat) VALUES (@NIM, @Nama, @Email, @Telepon, @Alamat)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NIM", txtNIM.Text.Trim());

                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());

                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());
                    }
                }
            }
        }
    }
}

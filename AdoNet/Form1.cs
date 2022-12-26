using System.Data.SqlClient;// SQLConnection kullanmak içi kürtüphaneyi dahil ediyoruz.

namespace AdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Northwind;uid=sa;password=123");
            cnn.Open(); // baðlantýyý aç

            // Sql ifadelerini çalýþtýr.

            cnn.Close(); // baðlantýyý kapat
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Northwind;uid=sa;password=123");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert Categories (CategoryName,Description) values('koddan', 'ado.net öðreniyoruz..')";
            cmd.Connection = cnn;

            cnn.Open();
            int result = cmd.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Kayýt Eklendi " + result);
        }
    }
}
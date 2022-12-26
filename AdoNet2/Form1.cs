using System.Data.SqlClient;

namespace AdoNet2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;database=Northwind;uid=sa;pwd=123");
        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert Shippers (CompanyName,Phone) values (@CompanyName,@Phone)";
            cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
            cmd.Parameters.AddWithValue("@Phone",txtPhone.Text);
            cmd.Connection = cnn;

            cnn.Open();
            int result = cmd.ExecuteNonQuery();
            cnn.Close();

            if (result >0)
            {
                MessageBox.Show("Kayýt ekleme iþlemi baþarýlý");
                txtCompanyName.Clear();
                txtPhone.Clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Shippers";
            cmd.Connection = cnn;

            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            //rdr.Read(); => sonraki satýrý okur. Ancak satýr varsa true döner.

            List<Nakliye> list = new List<Nakliye>();
            while (rdr.Read())
            {
                Nakliye n = new Nakliye();
                n.NakliyeID = (int)rdr["ShipperID"];
                n.Adi = (string)rdr["CompanyName"];
                n.Tel = (string)rdr["Phone"];
                list.Add(n);

            }

            cnn.Close();
            dataGridView1.DataSource = list;
        }
    }
}
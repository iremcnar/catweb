using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sql
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGönder_Click(object sender, EventArgs e)
        {
            string kullaniciadi = TextBoxKullaniciAdi.Text;
            string mesaj = TextBoxMesaj.Text;

            // SQL Server'a bağlantı yapılacak bağlantı dizesi
            string connectionString = "Data Source=DESKTOP-INN63KB;Initial Catalog=kedi;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL komutu oluştur
                string query = "INSERT INTO kediTablo (kullaniciadi, mesaj) VALUES (@kullaniciAdi, @mesaj)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@kullaniciAdi", kullaniciadi);
                command.Parameters.AddWithValue("@mesaj", mesaj);

                try
                {
                    // Bağlantıyı aç ve veritabanına ekleme işlemini gerçekleştir
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Hata durumunda burada işlemler yapılabilir (örneğin, hata mesajı gösterme)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
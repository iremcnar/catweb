using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sql
{
    public partial class kayıtkedi : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string kullanıcıadı = TextBoxKullaniciAdi.Text;
            string şifre = TextBoxMesaj.Text;

            // SQL Server'a bağlantı yapılacak bağlantı dizesi
            string connectionString = "Data Source=DESKTOP-INN63KB;Initial Catalog=KayıtOlArtık;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL komutu oluştur
                string query = "INSERT INTO  KayıtOlArtık(kullanıcıadı, şifre) VALUES (@kullanıcıadı, @şifre)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@kullanıcıadı", kullanıcıadı);
                command.Parameters.AddWithValue("@şifre", şifre);

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
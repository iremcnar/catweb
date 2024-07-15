using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sql

{
    public partial class güncellekedi : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-INN63KB;Initial Catalog=KayıtOlArtık;Integrated Security=True");
            con.Open(); // SqlConnection'ı burada açıyoruz

            SqlCommand cmd = new SqlCommand();

            // Kullanıcının var olup olmadığını kontrol et
            cmd.CommandText = "SELECT COUNT(*) FROM UserPanel WHERE kullanıcıadı = @kullanıcıadı AND şifre = @şifre";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@kullanıcıadı", TextBoxOldName.Text);
            cmd.Parameters.AddWithValue("@şifre", TextBoxOldPassword.Text);
            cmd.Connection = con; // SqlCommand'ın Connection özelliğini SqlConnection nesnesine bağlıyoruz

            int userCount = (int)cmd.ExecuteScalar();

            if (userCount > 0)
            {
                // Kullanıcı var, güncelleme işlemi yap
                cmd.CommandText = "UPDATE UserPanel SET kullanıcıadı = @newName, şifre = @newPassword WHERE kullanıcıadı = @oldName AND şifre = @oldPassword";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@newName", TextBoxNewName.Text);
                cmd.Parameters.AddWithValue("@newPassword", TextBoxNewPassword.Text);
                cmd.Parameters.AddWithValue("@oldName", TextBoxOldName.Text);
                cmd.Parameters.AddWithValue("@oldPassword", TextBoxOldPassword.Text);

                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    // Güncelleme başarılı oldu
                }
                else
                {
                    // Güncelleme başarısız oldu
                }
            }
            else
            {
                // Kullanıcı bulunamadı
            }

            con.Close(); // SqlConnection'ı kapatıyoruz




        }
    }
 }
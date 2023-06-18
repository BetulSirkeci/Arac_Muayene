using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Arac_Muayene
{
    public partial class randevusil : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["AracMuayeneConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btniptal_Click(object sender, EventArgs e)
        {
            string deger = arac_plaka.Text.Trim();

            if (string.IsNullOrEmpty(deger))
            {
                msg.Text = "Lütfen Tüm Alanları Doldurunuz.";
            }
            else
            {
                using (SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["AracMuayeneConnectionString"].ConnectionString))
                {
                    using (SqlCommand komut = new SqlCommand("sp_RandevuSil", baglanti))
                    {
                        komut.CommandType = CommandType.StoredProcedure;
                        komut.Parameters.AddWithValue("@deger", deger);

                        try
                        {
                            baglanti.Open();
                            string message = komut.ExecuteScalar().ToString();
                            msg.Text = message;
                        }
                        catch (Exception ex)
                        {
                            // Hata yönetimi
                            msg.Text = "Bir hata oluştu: " + ex.Message;
                        }
                    }
                }

            }

        }    }
}
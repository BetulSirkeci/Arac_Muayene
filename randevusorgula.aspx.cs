using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Arac_Muayene
{
    public partial class randevusorgula : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["AracMuayeneConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            il.Visible = false;
            ilce.Visible = false;
            randevu_id.Visible = false;
            sahip_TC.Visible = false;
            randevu_tarih.Visible = false;
            randevu_saati.Visible = false;
            ad.Visible = false;
            soyad.Visible = false;
            telefon.Visible = false;
            mail.Visible = false;



        }

        protected void btnbul_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(arac_plaka.Text))
            {
                msg.Text = "Lütfen Tüm Alanları Doldurunuz.";
            }
            else
            {
                
                using (SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["AracMuayeneConnectionString"].ConnectionString))
                {
                    using (SqlCommand komut = new SqlCommand("sp_RandevuSorgula", baglanti))
                    {
                        Label1.Text = "Araç Sahip Bilgileri:";
                        Label2.Text = "Muayene Randevu Bilgileri:";
                        komut.CommandType = CommandType.StoredProcedure;
                        komut.Parameters.AddWithValue("@arac_plaka", arac_plaka.Text.Trim());

                        try
                        {
                            baglanti.Open();
                            SqlDataReader oku = komut.ExecuteReader();

                            if (oku.Read())
                            {
                                il.Visible = true;
                                ilce.Visible = true;
                                randevu_id.Visible = true;
                                randevu_tarih.Visible = true;
                                randevu_saati.Visible = true;
                                sahip_TC.Visible = true;
                                ad.Visible = true;
                                soyad.Visible = true;
                                telefon.Visible = true;
                                mail.Visible = true;

                                il.ReadOnly = true;
                                ilce.ReadOnly = true;
                                randevu_id.ReadOnly = true;
                                randevu_tarih.ReadOnly = true;
                                randevu_saati.ReadOnly = true;
                                ad.ReadOnly = true;
                                telefon.ReadOnly = true;
                                mail.ReadOnly = true;
                                soyad.ReadOnly = true;

                                btsorgu.Visible = false;

                                randevu_id.Text = oku["randevu_id"].ToString();
                                il.Text = oku["il"].ToString();
                                ilce.Text = oku["ilce"].ToString();
                                DateTime randevuTarih = (DateTime)oku["randevu_tarih"];
                                randevu_tarih.Text = randevuTarih.ToString("dd.MM.yyyy");
                                randevu_saati.Text = oku["randevu_saati"].ToString();
                                mail.Text = oku["mail"].ToString();
                                telefon.Text = oku["telefon"].ToString();
                                sahip_TC.Text = oku["sahip_TC"].ToString();
                                ad.Text = oku["sahip_ad"].ToString();
                                soyad.Text = oku["soyad"].ToString();
                            }
                            else
                            {
                                msg.Text = "Kayıt Yok";
                                Label1.Text = "";
                                Label2.Text = "";
                            }

                            oku.Close();
                        }
                        catch (Exception ex)
                        {
                            // Hata yönetimi
                            msg.Text = "Bir hata oluştu: " + ex.Message;
                        }
                    }
                }
            }
        }
    }
}

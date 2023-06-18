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
    public partial class randevual : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["AracMuayeneConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                baglanti.Open();
                string tablosehir = "select * from sehir";
                SqlCommand cmmndsehir = new SqlCommand(tablosehir, baglanti);
                SqlDataReader readersehir = cmmndsehir.ExecuteReader();

                while (readersehir.Read())
                {
                    il.Items.Add(readersehir["ad"].ToString());
                }
                readersehir.Close();
                baglanti.Close();

                il.Visible = false;
                ilce.Visible = false;
                randevuTarih.Visible = false;
                randevuSaat.Visible = false;
                btRandevuKayit.Visible = false;
            }
        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            if (sahip_TC.Text == "" || arac_plaka.Text == "" || ruhsat_no.Text == "")
            {
                msg.Text = "Lütfen Tüm Alanları Doldurunuz.";
                string script = @"<script type='text/javascript'>
                    setTimeout(function() {
                        var msgElement = document.getElementById('" + msg.ClientID + @"');
                        msgElement.style.display = 'none';
                    }, 1000); // 1000ms (1 saniye) sonra mesajı gizle
                </script>";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "HideMessage", script);
            }
            else
            {
                baglanti.Open();

                string sorgu = "Select * From araclar where arac_plaka=@arac_plaka and ruhsat_no=@ruhsat_no and sahip_TC=@sahip_TC";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@arac_plaka", arac_plaka.Text.Trim());
                komut.Parameters.AddWithValue("@ruhsat_no", ruhsat_no.Text.Trim());
                komut.Parameters.AddWithValue("@sahip_TC", sahip_TC.Text.Trim());
                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    il.Visible = true;
                    ilce.Visible = true;
                    randevuTarih.Visible = true;
                    randevuSaat.Visible = true;
                    btRandevuKayit.Visible = true;

                    btnrandevuAl.Visible = false;
                    sahip_TC.Visible = false;
                    arac_plaka.Visible = false;
                    ruhsat_no.Visible = false;

                }
                else
                {
                    msg.Text = "Bilgilerinizde Hata Var. Lütfen Tekrar Konrol Ediniz.";
                    string script = @"<script type='text/javascript'>
                    setTimeout(function() {
                        var msgElement = document.getElementById('" + msg.ClientID + @"');
                        msgElement.style.display = 'none';
                    }, 1000); // 1000ms (1 saniye) sonra mesajı gizle
                </script>";
                    msg.Visible = false;

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "HideMessage", script);
                }
                oku.Close();
                baglanti.Close();

            }

        }

        protected void il_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            string sorgu = "select sehir_no, ilce_id, ilce_ad from ilce, sehir where ad='" + il.SelectedValue.Trim() + "' and sehir_id = sehir_no";

            SqlCommand cmmndilce = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter data = new SqlDataAdapter(cmmndilce);
            cmmndilce.Parameters.AddWithValue("@sehirAd", il.SelectedValue);

            SqlDataAdapter adapter = new SqlDataAdapter(cmmndilce);
            DataTable dt = new DataTable();
            data.Fill(dt);

            ilce.DataTextField = "ilce_ad";
            ilce.DataValueField = "ilce_id";

            ilce.DataSource = dt;
            ilce.DataBind();

            baglanti.Close();

        }

        protected void btRandevuKayit_Click(object sender, EventArgs e)
        {
            if (il.SelectedValue.Equals("") || ilce.SelectedValue.Equals("") || randevuTarih.Text == "" || randevuSaat.Text == "")
            {
                msg.Text = "Lütfen Tüm Alanları Doldurunuz.";
                string script = @"<script type='text/javascript'>
                    setTimeout(function() {
                        var msgElement = document.getElementById('" + msg.ClientID + @"');
                        msgElement.style.display = 'none';
                    }, 1000); // 1000ms (1 saniye) sonra mesajı gizle
                </script>";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "HideMessage", script);
            }

            else
            {

                baglanti.Open();

                if (randevuSaat.Text != "" && randevuTarih.Text != "" && !il.SelectedValue.Equals("") && !ilce.SelectedValue.Equals(""))
                {
                    SqlCommand control = new SqlCommand("SELECT COUNT(*) FROM randevu WHERE muayene_yer_ilce = @muayene_yer_ilce AND randevu_tarih = @randevu_tarih AND randevu_saati = @randevu_saati", baglanti);
                    control.Parameters.AddWithValue("@muayene_yer_ilce", ilce.SelectedValue);
                    control.Parameters.AddWithValue("@randevu_tarih", randevuTarih.Text.Trim());
                    control.Parameters.AddWithValue("@randevu_saati", randevuSaat.Text.Trim());
                    int sonuc = (int)control.ExecuteScalar();

                    if (sonuc == 0)
                    {
                        SqlCommand control2 = new SqlCommand("SELECT COUNT(*) FROM randevu WHERE arac_plaka = @arac_plaka AND randevu_tarih = @randevu_tarih AND randevu_saati = @randevu_saati", baglanti);
                        control2.Parameters.AddWithValue("@arac_plaka", arac_plaka.Text.Trim());
                        control2.Parameters.AddWithValue("@randevu_tarih", randevuTarih.Text.Trim());
                        control2.Parameters.AddWithValue("@randevu_saati", randevuSaat.Text.Trim());
                        int sonuc2 = (int)control2.ExecuteScalar();

                        if (sonuc2 == 0)
                        {
                            // Şehir ve ilçe adlarından ilgili ID değerlerini almak için
                            string sehirAd = il.SelectedItem.Text.Trim();
                            string ilceAd = ilce.SelectedItem.Text.Trim();

                            SqlCommand sehirCommand = new SqlCommand("SELECT sehir_id FROM sehir WHERE ad = @sehirAd", baglanti);
                            sehirCommand.Parameters.AddWithValue("@sehirAd", sehirAd);
                            int sehirID = (int)sehirCommand.ExecuteScalar();

                            SqlCommand ilceCommand = new SqlCommand("SELECT ilce_id FROM ilce WHERE ilce_ad = @ilceAd AND sehir_no = @sehirID", baglanti);
                            ilceCommand.Parameters.AddWithValue("@ilceAd", ilceAd);
                            ilceCommand.Parameters.AddWithValue("@sehirID", sehirID);
                            int ilceID = (int)ilceCommand.ExecuteScalar();

                            // Stored procedure'u çağırma
                            SqlCommand cmd = new SqlCommand("sp_RandevuEkle", baglanti);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sahip_TC", sahip_TC.Text.Trim());
                            cmd.Parameters.AddWithValue("@arac_plaka", arac_plaka.Text.Trim());
                            cmd.Parameters.AddWithValue("@randevuTarih", DateTime.Parse(randevuTarih.Text));
                            cmd.Parameters.AddWithValue("@randevuSaati", TimeSpan.Parse(randevuSaat.Text));
                            cmd.Parameters.AddWithValue("@muayeneYerIl", sehirID);
                            cmd.Parameters.AddWithValue("@muayeneYerIlce", ilceID);
                            cmd.ExecuteNonQuery();



                            msg.Text = "Randevu Bilgileriniz Alınmıştır.";
                            //Response.AddHeader("Refresh", "1;url=randevual.aspx");
                        }

                        string sqlLastID = "select max(randevu_id) as 'randevu_id' from randevu";
                        SqlCommand cmmndID = new SqlCommand(sqlLastID, baglanti);
                        SqlDataReader readID = cmmndID.ExecuteReader();
                        readID.Read();
                        Session["lastID"] = readID["randevu_id"].ToString();
                    }
                }


                else
                {
                    msg.Text = "Randevu Saati Uygun Değil";
                    string script = @"<script type='text/javascript'>
                    setTimeout(function() {
                        var msgElement = document.getElementById('" + msg.ClientID + @"');
                        msgElement.style.display = 'none';
                    }, 1000); // 1000ms (1 saniye) sonra mesajı gizle
                </script>";

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "HideMessage", script);
                }


            }


        }
    }
}

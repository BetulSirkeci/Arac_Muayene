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
    public partial class randevuguncelle : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["AracMuayeneConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                il.Visible = false;
                ilce.Visible = false;
                randevuTarih.Visible = false;
                randevuSaat.Visible = false;
                btGuncelle.Visible = false;
                randevu_id.Visible = false;

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
            }

        }

        protected void btnguncelle_Click(object sender, EventArgs e)
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
                //string guncelle = "update randevu set randevu_tarih=@randevu_tarih, randevu_saati=@randevu_saati, muayene_yer_il=@muayene_yer_il, muayene_yer_ilce=@muayene_yer_ilce where randevu_id=@randevu_id";


                if (randevuSaat.Text != "" && randevuTarih.Text != "" && !il.SelectedValue.Equals("") && !ilce.SelectedValue.Equals(""))
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
                    SqlCommand cmd = new SqlCommand("sp_RandevuGuncelle", baglanti);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@randevuID", int.Parse(randevu_id.Text));
                    cmd.Parameters.AddWithValue("@randevuTarih", DateTime.Parse(randevuTarih.Text));
                    cmd.Parameters.AddWithValue("@randevuSaati", TimeSpan.Parse(randevuSaat.Text));
                    cmd.Parameters.AddWithValue("@muayeneYerIl", sehirID);
                    cmd.Parameters.AddWithValue("@muayeneYerIlce", ilceID);
                    cmd.ExecuteNonQuery();


                    msg.Text = "Randevu Güncellendi";
                    arac_plaka.Visible = true;
                    btBul.Visible = true;
                    il.Visible = false;
                    ilce.Visible = false;
                    randevuTarih.Visible = false;
                    randevuSaat.Visible = false;
                    btGuncelle.Visible = false;
                    randevu_id.Visible = false;
                }
                else
                {
                    msg.Text = "Güncelleme Başarısız";
                    string script = @"<script type='text/javascript'>
                    setTimeout(function() {
                        var msgElement = document.getElementById('" + msg.ClientID + @"');
                        msgElement.style.display = 'none';
                    }, 1000); // 1000ms (1 saniye) sonra mesajı gizle
                </script>";

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "HideMessage", script);
                }
            }
            baglanti.Close();

        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            if (arac_plaka.Text == "")
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

                string sorgu = "Select * From randevu where arac_plaka=@arac_plaka";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@arac_plaka", arac_plaka.Text.Trim());
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    il.Visible = true;
                    ilce.Visible = true;
                    randevuTarih.Visible = true;
                    randevuSaat.Visible = true;
                    btGuncelle.Visible = true;
                    randevu_id.Visible = true;
                    
                    randevu_id.ReadOnly = true;

                    arac_plaka.Visible = false;
                    btBul.Visible = false;

                    randevu_id.Text = oku["randevu_id"].ToString();
                }
                else
                {
                    msg.Text = "Kayıt Yok";
                    string script = @"<script type='text/javascript'>
                    setTimeout(function() {
                        var msgElement = document.getElementById('" + msg.ClientID + @"');
                        msgElement.style.display = 'none';
                    }, 1000); // 1000ms (1 saniye) sonra mesajı gizle
                </script>";

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
    }
}
<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="randevual.aspx.cs" Inherits="Arac_Muayene.randevual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="overlay">
           <div class="box">
    <div class="baslik">
                   <asp:Label Text="Randevu Al" Font-Size="X-Large" ForeColor="White" runat="server" />              
                </div>
                <div class="inputs">
                     <asp:TextBox runat="server" CssClass="textbox" placeholder="T.C. Kimlik No" MaxLength="11" ID="sahip_TC" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"/>
                     <asp:TextBox runat="server" CssClass="textbox" placeholder="Plaka No" ID="arac_plaka"/>
                     <asp:TextBox runat="server" CssClass="textbox" placeholder="Ruhsat No" ID="ruhsat_no"/>
                    <asp:Button Text="Randevu Al" CssClass="button" runat="server" ID="btnrandevuAl" OnClick="btnbul_Click"/>
                    
                    <asp:DropDownList ID="il" runat="server" AutoPostBack="True" OnSelectedIndexChanged="il_SelectedIndexChanged" >
                        <asp:ListItem Value="-1">İl seçiniz</asp:ListItem>
                    </asp:DropDownList>
                    
                    <asp:DropDownList ID="ilce" runat="server">
                        <asp:ListItem Value="-1">İlçe seçiniz</asp:ListItem>
                    </asp:DropDownList>
                   
                    <asp:TextBox runat="server" TextMode="Date" ID="randevuTarih"/>
                     
                    <asp:TextBox runat="server" TextMode="Time" ID="randevuSaat"/>
                    <asp:Button Text="Randevuyu Onayla" CssClass="button" ID="btRandevuKayit" runat="server" OnClick="btRandevuKayit_Click"/>
                    <asp:Label Text="" ForeColor="White" Font-Size="large" ID="msg" runat="server" />
                </div>
      </div>
        </div>
</asp:Content>

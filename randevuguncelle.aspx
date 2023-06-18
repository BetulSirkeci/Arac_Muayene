<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="randevuguncelle.aspx.cs" Inherits="Arac_Muayene.randevuguncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="overlay">
           <div class="box">
               <div class="baslik">
                   <asp:Label Text="Randevu Güncelle" Font-Size="X-Large" ForeColor="White" runat="server" />
                </div>
                <div class="inputs">
                    <asp:TextBox runat="server" CssClass="textbox" placeholder="Plaka No" ID="arac_plaka"/>
                     
                  
                 <asp:Button Text="Randevu Ara" CssClass="button" runat="server" ID="btBul" OnClick="btnbul_Click" />
                    <asp:TextBox runat="server" CssClass="textbox" placeholder="Randevu No" ID="randevu_id"/>
                    <asp:DropDownList ID="il" runat="server" AutoPostBack="True" OnSelectedIndexChanged="il_SelectedIndexChanged" >
                        <asp:ListItem Value="-1">İl seçiniz</asp:ListItem>
                    </asp:DropDownList>
                    
                    <asp:DropDownList ID="ilce" runat="server">
                        <asp:ListItem Value="-1">İlçe seçiniz</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Textbox runat="server" TextMode="Date" ID="randevuTarih"></asp:Textbox>
                    <asp:Textbox runat="server" TextMode="Time" ID="randevuSaat"></asp:Textbox>

                    <asp:Button Text="Randevu Güncelle" CssClass="button" runat="server" ID="btGuncelle" OnClick="btnguncelle_Click" />
                    <asp:Label Text="" ID="msg" Font-Size="Large" ForeColor="White" runat="server" />
                </div>
            </div>
        </div>
</asp:Content>

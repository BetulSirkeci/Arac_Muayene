<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="randevusorgula.aspx.cs" Inherits="Arac_Muayene.randevusorgula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="overlay">
           <div class="box">
               <div class="baslik">
                   <asp:Label Text="Randevu Sorgulama" Font-Size="X-Large" ForeColor="White" runat="server" />
                </div>
                <div class="inputs">
                    
                      <asp:TextBox runat="server" CssClass="textbox" placeholder="Plaka No" ID="arac_plaka"/>
                    
                    <asp:Button Text="Randevu Sorgula" CssClass="button" Style="vertical-align:middle" runat="server" ID="btsorgu" OnClick="btnbul_Click" />
                    <asp:Label Text="" Style="margin-top:1px; margin-bottom:1px;" ForeColor="White" Font-Size="large" ID="msg" runat="server" />
                    
                    <asp:Label Text="" ForeColor="White" Font-Size="large" ID="Label1" runat="server" />

                  <asp:TextBox runat="server" ID="sahip_TC"/>
                    <asp:TextBox runat="server" ID="ad"/>
                    <asp:TextBox runat="server" ID="soyad"/>
                     <asp:TextBox runat="server" TextMode="Phone" ID="telefon"/>
                     <asp:TextBox runat="server" TextMode="Email" ID="mail"/>
                    <asp:Label Text="" ForeColor="White" Font-Size="large" ID="Label2" runat="server" />
                    <asp:TextBox runat="server" ID="randevu_id"/>
                    <asp:TextBox runat="server" ID="il"/>
                    <asp:TextBox runat="server" ID="ilce"/>
                    <asp:TextBox runat="server"  ID="randevu_tarih"/>
                    <asp:TextBox runat="server" TextMode="Time" ID="randevu_saati"/>
                    

                    
                </div>
            </div>
        </div>
</asp:Content>

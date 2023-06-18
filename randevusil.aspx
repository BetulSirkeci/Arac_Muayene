<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="randevusil.aspx.cs" Inherits="Arac_Muayene.randevusil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="overlay">
           <div class="box">
               <div class="baslik">
                   <asp:Label Text="Randevu İptal" Font-Size="X-Large" ForeColor="White" runat="server" />
                </div>
                <div class="inputs">
                     
                      <asp:TextBox runat="server" CssClass="textbox" placeholder="Plaka No veya Randevu No" ID="arac_plaka"/>
                  
                    <asp:Button Text="Randevu İptal" CssClass="button" runat="server" OnClick="btniptal_Click"  />
                    <asp:Label Text="" ID="msg" ForeColor="White" runat="server" />
                </div>
            </div>
        </div>
</asp:Content>

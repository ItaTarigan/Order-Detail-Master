<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="AnalisType.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.AnalisType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Literal ID="DivData" runat="server"></asp:Literal>
    <asp:TextBox ID="TxtData" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
    <br />
    <asp:Label ID="lblUpload" runat="server" Text="Upload File"></asp:Label>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server"/><br />   
    <br />
    <asp:Label ID="lblOrderDetailNo" runat="server" Text="Order Detail No"></asp:Label>
    <asp:TextBox ID="txtOrderDetailNo" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblBerat" runat="server" Text="Parameter Berat"></asp:Label>
    <asp:TextBox ID="txtBerat" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblFP" runat="server" Text="Parameter FP"></asp:Label>
    <asp:TextBox ID="txtFP" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="BtnSave" runat="server" Text="Simpan" CssClass="btn-dark" />
    <asp:Label ID="TxtStatus" ForeColor="Red" runat="server" Text=""></asp:Label>
</asp:Content>

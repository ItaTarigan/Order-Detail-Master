<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/SinglePage.Master" AutoEventWireup="true" CodeBehind="GenerateQR.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Shared.GenerateQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <%-- Judul --%>
    <div class="row mt-2">
        <div class="col-lg">
            <h2>Generate QR LHP</h2>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
            <h4>No Order:
            <asp:Label ID="txtNoOrder" runat="server" Text=""></asp:Label></h4>
        </div>
    </div>
    <%-- SideBox --%>
    <div class="row mt-2" >
        <div class="col-lg-4">
            <asp:Image ID="ImageQR" runat="server" />
        </div>
    </div>
    <div class="row mt-2" >
        <div class="col-lg-4">
            <div class="alert alert-success">
                Silakan simpan gambar diatas dan masukan ke dalam lembar LHP. 
            </div>
        </div>
    </div>
    <div class="row mt-2" >
        <div class="col-lg-4">
             <asp:Button ID="BtnBack" CssClass="btn btn-info" runat="server" Text="Kembali" />
        </div>
    </div>
</asp:Content>

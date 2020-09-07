<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/SinglePage.Master" AutoEventWireup="true" CodeBehind="ValidasiQR.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Shared.ValidasiQR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <%-- Judul --%>
    <div class="row mt-2">
        <div class="col-lg">
            <h2>Validasi QR LHP</h2>
            <div class="alert alert-info">
                Form ini digunakan untuk menguji validitas lembar LHP menggunakan QR Code.
            </div>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg-4">
             <div class="card"  runat="server" id="BtnUploadZip">
                <div class="card-body">
                    <h5 class="card-title">Upload Gambar/Foto QR LHP</h5>
                    <p class="card-text">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </p>
                    <asp:Button ID="BtnUpload" CssClass="btn btn-primary" runat="server" Text="Upload" />
                </div>
            </div>
        </div>
    </div>
    <%-- SideBox --%>
    <div class="row mt-2">
        <div class="col-lg-4">
            <asp:Image ID="ImageQR" runat="server" />
        </div>
    </div>
    <div class="row mt-2" runat="server" visible="false" id="DivWarning">
        <div class="col-lg-4">
            <div class="alert alert-warning">
                <asp:Literal ID="LitWarning" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfo" visible="false">
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body" style="background-color: lightgray;">
                    <p class="card-text">
                        <b>
                            <label for="">No Order: </label>
                        </b>
                        <asp:Label ID="txtOrderNo" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Nama Pelanggan: </label>
                        </b>
                        <asp:Label ID="txtCustomer" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Komoditas : </label>
                        </b>
                        <asp:Label ID="txtKomoditas" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Tipe Analis : </label>
                        </b>
                        <asp:Label ID="txtTipeAnalis" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Total Sample : </label>
                        </b>
                        <asp:Label ID="txtTotalSample" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Status Pesanan : </label>
                        </b>
                        <asp:Label ID="txtStatusPesanan" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg-4">
            <asp:Button ID="BtnBack" CssClass="btn btn-info" runat="server" Text="Kembali" />
        </div>
    </div>
</asp:Content>

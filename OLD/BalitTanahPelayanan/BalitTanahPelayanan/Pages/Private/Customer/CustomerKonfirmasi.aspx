<%@ Page Title="Customer - Konfirmasi" Language="C#" MasterPageFile="~/Pages/Master/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerKonfirmasi.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.CustomerKonfirmasi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="row mt-2" id="DivPesananBaru" runat="server">
        <div class="col-lg">
            <h2>
                <b>
                    <asp:Label ID="lblKonfirmasiPesananBaru" runat="server">Konfirmasi Pesanan Baru</asp:Label>
                </b>
            </h2>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfoPelanggan">
        <div class="col-lg-12">
            <h5>
                <b>
                    <asp:Label ID="lblInfoPelanggan" for="" runat="server">Info Pelanggan</asp:Label>
                </b>
            </h5>
            <div class="card">
                <div class="card-body" style="background-color: lightgray;">

                    <p class="card-text">
                        <b>
                            <asp:Label ID="name" for="" runat="server">Nama Pelanggan </asp:Label>
                        </b>
                        <asp:Label ID="lblcusname" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="instansi" for="" runat="server">Instansi</asp:Label>
                        </b>
                        <asp:Label ID="lblInstansi" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
            <br>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfoPesanan">
        <div class="col-lg-12">
            <h5>
                <b>
                    <asp:Label ID="lblInfoPesanan" for="" runat="server">Info Pesanan</asp:Label>
                </b>
            </h5>
            <div class="card">
                <div class="card-body" style="background-color: lightgray;">

                    <p class="card-text">
                        <b>
                            <asp:Label ID="tanggal" for="" runat="server">Tanggal</asp:Label>
                        </b>
                        <asp:Label ID="lblTanggal" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="noPesanan" for="" runat="server">No Pesanan</asp:Label>
                        </b>
                        <asp:Label ID="lblnoPesanan" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="komoditas" for="tanggal" runat="server">Komoditas</asp:Label>
                        </b>
                        <asp:Label ID="lblKomoditas" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="subKomoditas" for="" runat="server">Sub Komoditas</asp:Label>
                        </b>
                        <asp:Label ID="lblsubKomoditas" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="jenisAnalisis" for="tanggal" runat="server">Jenis Analisis</asp:Label>
                        </b>
                        <asp:Label ID="lbljenisAnalisis" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
            <br>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfoSampel">
        <div class="col-lg-12">
            <h5>
                <b>
                    <asp:Label ID="infoSampel" for="" runat="server">Info Sampel</asp:Label>
                </b>
            </h5>
            <div class="card">

                <%-- DG In Here --%>
            </div>
            <br>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfoParameterUji">
        <div class="col-lg-12">
            <h5>
                <b>
                    <asp:Label ID="parameterUji" for="" runat="server">Info Parameter Uji</asp:Label>
                </b>
            </h5>
            <div class="card">

                <%-- DG In Here --%>
            </div>
        </div>
    </div>
    <div class="row mt-2 alert alert-info" id="DivJumlah" runat="server" style="margin: 25px 0px 15px !important;">
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblJumlahParameterUji" runat="server">Jumlah Parameter Uji</asp:Label>
                <asp:Literal ID="LitJmlParameterUji" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblJumlahSample" runat="server">Jumlah Sampel</asp:Label>
                <asp:Literal ID="LitJumlahSampel" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblTotalBiaya" runat="server">Total Biaya</asp:Label>
                <asp:Literal ID="LitTotalBiaya" runat="server"></asp:Literal>
            </b>
        </div>
    </div>
    <br>
    <div class="row mt-2" runat="server" id="DivAgreement">
        <div class="col-lg-8">
            <asp:CheckBox ID="CheckBox1" runat="server" />
            <h5><b><asp:Label ID="SayaSetuju" for="" runat="server">Saya menyetujui untuk melanjutkan pesanan ini sesuai dengan standar prosedur yang berlaku di Balitanah</asp:Label></b></h5>
            <asp:Button ID="BtnSOP" CssClass="btn btn-success" runat="server" Text="Standar Prosedur" />
            <br>
            <br>
        </div>
    </div>

    <div class="row mt-2" runat="server" id="DivButton">
        <div class="col-lg">
            <asp:Button ID="BtnKembali" CssClass="btn btn-warning" runat="server" Text="Kembali" CommandName="back" OnClick="ActionButton" />
            <asp:Button ID="BtnSetuju" CssClass="btn btn-info" runat="server" Text="Setuju" />
        </div>
    </div>

    <div class="row mt-2" id="DivSOP" runat="server" visible="false">

        <div class="col-lg text-center">
            <img src="../../../assets/img/SOP.png" width="900" alt="sop" />
        </div>

    </div>
    <div class="row mt-2" id="DivBtnTutup" runat="server" visible="false">

        <div class="col-lg text-center">
             <asp:Button ID="BtnTutup" CssClass="btn btn-warning" runat="server" Text="Tutup" />
        </div>

    </div>
</asp:Content>

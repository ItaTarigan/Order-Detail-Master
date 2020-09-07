<%@ Page Title="Input Parameter" Async="true" Language="C#" MasterPageFile="~/Pages/Master/Analis.Master" AutoEventWireup="true" CodeBehind="InputParameter.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Analis.InputParameter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="row mt-2">
        <div class="col-lg">
            <asp:Button ID="PopUp" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal" runat="server" Text="Test PopUp" />--%>
            <%--<asp:Button ID="PopUp" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Test PopUp</asp:Button>--%>

            <div ID="myModal" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h3 class="modal-title">SILPO</h3>
                        </div>
                        <div class="modal-body">
                            <p>Hasil Data Sudah Berhasil Di Simpan</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
<%--        </div>
    </div>--%>

    <div class="row mt-2">
        <div class="col-lg">

            <h2>
                <asp:Label ID="no_balittanah" runat="server" Text="balittanah no"></asp:Label>
            <asp:Label ID="txtNoBalitTanah" runat="server" Text="Label"></asp:Label></h2>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg-4">
            <div class="card">

                <div class="card-body" style="background-color: lightgray;">
                    <p class="card-text">
                        <b>
                            <asp:Label ID="no_pesanan" runat="server" Text="No Pesanan">:</asp:Label>
                        </b>
                        <asp:Label ID="txtOrderNo" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="no_sample" runat="server" Text="No Sample">:</asp:Label>
                        </b>
                        <asp:Label ID="txtNoSample" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="nama_sample" runat="server" Text="Nama Sample">:</asp:Label>
                        </b>
                        <asp:Label ID="txtNamaSampel" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="tipe_analis" runat="server" Text="Tipe Analis">:</asp:Label>
                        </b>
                        <asp:Label ID="txtTipeAnalis" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="komoditas" runat="server" Text="Komoditas">:</asp:Label>
                        </b>
                        <asp:Label ID="txtKomoditas" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Label ID="pilihparameteruji" runat="server" Text="Pilih Parameter Uji"></asp:Label>
                    </h5>
                    <asp:DropDownList ID="CmbParameter" AutoPostBack="true" runat="server"></asp:DropDownList>

                </div>
            </div>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="UploadDiv">
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Label ID="uploadexcel" runat="server" Text="Upload Excel Hasil Pengukuran"></asp:Label>
                    </h5>
                    <asp:FileUpload ID="FileUploadManual" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Label ID="uploadfiledarialat" runat="server" Text="Upload File CSV Dari Alat"></asp:Label>
                    </h5>
                    <asp:FileUpload ID="FileUploadAlat" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DownloadDiv" visible="false">
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Label ID="dwnloadexcelpengukuran" runat="server" Text="Download Excel Hasil Pengukuran"></asp:Label>
                    </h5>
                    <asp:Button ID="BtnDownloadManual" runat="server" CssClass="btn btn-primary" Text="Download" />
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Label ID="dwnloadfilecsv" runat="server" Text="Download File CSV Dari Alat"></asp:Label>
                    </h5>
                    <asp:Button ID="BtnDownloadAlat" runat="server" CssClass="btn btn-primary" Text="Download" />
                </div>
            </div>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
            <asp:Button ID="BtnKembali" runat="server" CssClass="btn btn-light" Text="Kembali" />
            <asp:Button ID="BtnSimpan" runat="server" data-toggle="modal" data-target="#myModal" CssClass="btn btn-info" Text="Simpan" />
            <asp:Button ID="BtnUbah" runat="server" CssClass="btn btn-primary" Text="Ubah" />

        </div>
    </div>
</asp:Content>

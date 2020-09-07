<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Pages/Master/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerBayar.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.CustomerBayar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="row mt-2" >
        <div class="col-lg-12">
            <h2>
                <asp:Literal runat="server" ID="litHeader" Text="Bayar via Transfer"></asp:Literal></h2>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfoPelanggan" visible="true">
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
    <div class="row mt-2" runat="server" id="DivInfoPesanan" visible="true">
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
                            <asp:Label ID="jnsAnalisis" for="tanggal" runat="server">Jenis Analisis</asp:Label>
                        </b>
                        <asp:Label ID="lbljenisAnalisis" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
            <br>
        </div>
    </div>

    <div class="row mt-2 alert alert-info" visible="true" id="DivHarga" runat="server" style="margin: 25px 0px 15px !important;">
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblJmlParamUji" runat="server">Jumlah Parameter Uji:</asp:Label>
                <asp:Literal ID="LitJmlParamUji" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblJmlSampel" runat="server">Jumlah Sampel:</asp:Label>
                <asp:Literal ID="LitJmlSampel" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblTotBiaya" runat="server">Total Biaya: Rp </asp:Label>
                <asp:Literal ID="LitTotBiaya" runat="server"></asp:Literal>
            </b>
        </div>
    </div>
    <div class="row mt-2" id="DivRow3" runat="server">
        <div class="col-lg-4">
            <div>
                <div class="card">
                    <div class="card-body">
                        <img runat="server" width="400" visible="false" id="ImgLampiran" src="" class="card-img-top" alt="lampiran">
                        <h5 class="card-title"><asp:Literal runat="server" ID="LitBuktiPembayaran" Text="Bukti Pembayaran"></asp:Literal></h5>
                        <p class="card-text">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </p>
                        <asp:HiddenField ID="HidUrlBukti" runat="server" />
                        <asp:Button ID="BtnUpload" CssClass="btn btn-primary" runat="server" Text="Upload" CommandName="Upload" />
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title"><asp:Literal runat="server" ID="LitAttachment" Text="Lampiran lain (cth: resi pengiriman sampel)"></asp:Literal></h5>
                        <p class="card-text">
                            <asp:FileUpload ID="FileUploadLampiran" runat="server" />
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label id="lblJumlahTransfer"  for="TxtJumlahTransfer"><asp:Literal runat="server" ID="LitJumlahTransfer" Text="Jumlah Transfer"></asp:Literal></label>
                    <asp:TextBox  ID="TxtJumlahTransfer" TextMode="Number" class="form-control" aria-describedby="desc0" placeholder="0" runat="server"></asp:TextBox>
                    <small id="desc1" class="form-text text-muted"><asp:Literal runat="server" ID="LitJumlahTransferDesc" Text="nilai uang yang ditransfer"></asp:Literal></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vg1" runat="server" ControlToValidate="TxtJumlahTransfer" ErrorMessage="Silakan isi jumlah transfer"></asp:RequiredFieldValidator>
         
                </div>
                <div class="form-group">
                    <asp:Label ID="lblNamaPemilikRek" for="TxtNamaRekening" runat="server">Nama Rekening Pengirim</asp:Label>
                    <asp:TextBox TextMode="SingleLine" ID="TxtNamaRekening" class="form-control" aria-describedby="desc2" placeholder="Nama" runat="server"></asp:TextBox>
                    <small id="desc2" class="form-text text-muted">
                        <asp:Label runat="server" ID="lbNamaPemilikRek"></asp:Label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vg1" runat="server" ControlToValidate="TxtNamaRekening" ErrorMessage="Silakan isi nama rekening pengirim"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label id="lblNoRekening" runat="server" for="TxtNoRekening"><asp:Literal runat="server" ID="LitNoRekening" Text="No Rekening Pengirim"></asp:Literal></label>
                    <asp:TextBox  ID="TxtNoRekening" TextMode="Number" class="form-control" aria-describedby="desc3" placeholder="0" runat="server"></asp:TextBox>
                    <small id="desc3" class="form-text text-muted"><asp:Literal runat="server" ID="LitNoRekDesc"></asp:Literal></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="vg1" runat="server" ControlToValidate="TxtNoRekening" ErrorMessage="Silakan isi no rekening pengirim"></asp:RequiredFieldValidator>
         
                </div>
                <div class="form-group">
                    <asp:Label ID="lblBank" for="CmbBankPengirim" runat="server">Bank Pengirim</asp:Label>
                    <asp:DropDownList ID="CmbBankPengirim" class="form-control" aria-describedby="desc4" placeholder="Pilih Bank" runat="server"></asp:DropDownList>
                    <small id="desc4" class="form-text text-muted">
                        <asp:Label runat="server" ID="lbbank"></asp:Label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="vg1" runat="server" ControlToValidate="CmbBankPengirim" ErrorMessage="Silakan pilih bank"></asp:RequiredFieldValidator>

                </div>
            </div>
        </div>

    </div>
     <div class="row mt-2" id="Div1" runat="server">
        <div class="col-lg-4">
            <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Kembali" />
            <asp:Button ID="BtnSave" CssClass="btn btn-info" ValidationGroup="vg1" runat="server" Text="Kirim" />
            <asp:ValidationSummary ShowMessageBox="true" ShowValidationErrors="true" ValidationGroup="vg1" ID="ValidationSummary1" runat="server" />
        </div>
    </div>
</asp:Content>

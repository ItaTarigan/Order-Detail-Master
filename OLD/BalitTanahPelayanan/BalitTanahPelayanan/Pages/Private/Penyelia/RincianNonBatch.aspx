<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Pages/Master/Penyelia.Master" AutoEventWireup="true" CodeBehind="RincianNonBatch.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Penyelia.RincianNonBatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <%-- Judul --%>
    <div class="row mt-2">
        <div class="col-lg">
            <h2>Rincian No Pesanan:
            <asp:Label ID="txtNoOrder" runat="server" Text="Label"></asp:Label></h2>
        </div>
    </div>
    <%-- SideBox --%>
    <div class="row mt-2" runat="server" id="DivRow2">
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body" style="background-color: lightgray;">

                    <p class="card-text">
                        <b>
                            <label for="">Nama Pelanggan : </label>
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
        <%-- Btn Download --%>
        <div class="col-lg-4" >
            <div class="card" runat="server" id="BtnDownloadZip">
                <div class="card-body">
                    <h5 class="card-title">Download Hasil (LHP)</h5>
                    <asp:Button ID="BtnDownload" CssClass="btn btn-primary" runat="server" Text="Download"  />

                </div>
            </div>
            <div class="card"  runat="server" id="BtnUploadZip">
                <div class="card-body">
                    <h5 class="card-title">Upload Hasil (LHP)</h5>
                    <p class="card-text">
                        
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </p>
                    <asp:Button ID="BtnUpload" ValidationGroup="vg1" CssClass="btn btn-primary" runat="server" Text="Upload" CommandName="Upload" />
                </div>
            </div>
        </div>
        <%-- BtnUpload --%>
        <div class="col-lg-4">
            <div class="card" runat="server" id="DivDownloadLampiran">
                <div class="card-body">
                    <h5 class="card-title">Download Lampiran</h5>
                    <asp:Button ID="BtnDownloadKalkulasi" CssClass="btn btn-primary" runat="server" Text="Download"  />

                </div>
            </div>
             <div class="card"  runat="server" id="DivUploadLampiran">
                <div class="card-body">
                    <h5 class="card-title">Lampiran Perhitungan</h5>
                    <p class="card-text">
                        
                        <asp:FileUpload ID="FileUploadKalkulasi" runat="server" />
                    </p>
                    <asp:Button ID="BtnUploadKalkulasi" CssClass="btn btn-primary" runat="server" Text="Upload" CommandName="Upload" />
                </div>
            </div>
        </div>
    </div>
    <%-- Gridview Sample --%>
    <div class="row mt-2" runat="server" id="DivRow3">
        <div class="col-lg">
            <h3>Daftar Sampel</h3>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivRow4">
        <div class="col-lg">
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                    <asp:BoundField DataField="countNumber" HeaderText="No Urut" />
                    <asp:BoundField DataField="sampleCode" HeaderText="No Sample" />
                    <asp:BoundField DataField="noBalittanah" HeaderText="No Balittanah" />
                    <asp:BoundField DataField="village" HeaderText="Desa" />
                    <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                    <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                    <asp:BoundField DataField="province" HeaderText="Propinsi" />
                    <asp:BoundField DataField="longitude" HeaderText="Koordinat Gps" />
                    <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                    <asp:BoundField DataField="isReceived" HeaderText="Sample Diterima" />

                    <asp:TemplateField HeaderText="Tindakan">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lihat" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="DetailorderList" Text="Lihat">Parameter Uji</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%-- Script untuk GvSample --%>
            <script>
                function fixGridView(tableEl) {
                    var jTbl = $(tableEl);

                    if (jTbl.find("tbody>tr>th").length > 0) {
                        jTbl.find("tbody").before("<thead><tr></tr></thead>");
                        jTbl.find("thead tr").append(jTbl.find("th"));
                        jTbl.find("tbody tr:first").remove();
                    }
                }
                $(document).ready(function () {
                    fixGridView($("#<%=GvData.ClientID%>"));

                    $('#<%=GvData.ClientID%>').DataTable();
                });
            </script>
        </div>
    </div>
    <%-- Button --%>
    <div class="row mt-2" runat="server" id="DivRow5">
        <div class="col-lg">
            <asp:Button ID="BtnKembali" CssClass="btn btn-primary" runat="server" Text="Kembali" CommandName="Kembali" OnClick="ActionButton" />
            <asp:Button ID="BtnLanjut" CssClass="btn btn-success" runat="server" Text="Lanjut" CommandName="Lanjut" OnClick="ActionButton" />
            <asp:Button ID="BtnHitungUlang" CssClass="btn btn-warning" runat="server" Text="Hitung ulang" CommandName="HitungUlang" OnClick="ActionButton" />
            <asp:Button ID="BtnQR" CssClass="btn btn-info" runat="server" Text="Generate QR LHP" CommandName="GenerateQR" OnClick="ActionButton" />
        </div>
    </div>
    <%-- Baru Visible --%>
    <%-- SideBox --%>
    <div class="row mt-2" runat="server" id="DivRow6" visible="false">
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body" style="background-color: lightgray;">

                    <p class="card-text">
                        <b>
                            <label for="">No Sample : </label>
                        </b>
                        <asp:Label ID="TxtNoSample" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">No Balit Tanah : </label>
                        </b>
                        <asp:Label ID="TxtNoBalitTanah" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Desa : </label>
                        </b>
                        <asp:Label ID="TxtDesa" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Kecamatan : </label>
                        </b>
                        <asp:Label ID="TxtKecamatan" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Kabupaten : </label>
                        </b>
                        <asp:Label ID="TxtKabupaten" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Propinsi : </label>
                        </b>
                        <asp:Label ID="TxtPropinsi" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">GPS : </label>
                        </b>
                        <asp:Label ID="TxtGps" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Tipe Tanah : </label>
                        </b>
                        <asp:Label ID="TxtTipeTanah" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <%-- Gridview Parameter --%>
    <div class="row mt-2" runat="server" id="DivRow7" visible="false">
        <div class="col-lg">
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvParameter" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                    <asp:BoundField DataField="elementservicestbl.elementCode" HeaderText="Parameter Uji" />
                    <asp:BoundField DataField="status" HeaderText="Status Pengujian" />
                    <asp:TemplateField HeaderText="Hasil">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lihat" CommandArgument='<%# Eval("fileAttachmentUrl") %>' CommandName="DownloadParameter" runat="server" Text="Download">Download</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <script>
                function fixGridView(tableEl) {
                    var jTbl = $(tableEl);

                    if (jTbl.find("tbody>tr>th").length > 0) {
                        jTbl.find("tbody").before("<thead><tr></tr></thead>");
                        jTbl.find("thead tr").append(jTbl.find("th"));
                        jTbl.find("tbody tr:first").remove();
                    }
                }
                $(document).ready(function () {
                    fixGridView($("#<%=GvParameter.ClientID%>"));

                    $('#<%=GvParameter.ClientID%>').DataTable();
                });
            </script>
        </div>
    </div>

    <div class="row mt-2" runat="server" id="DivRow8" visible="false">
        <div class="col-lg">
            <asp:Button ID="BtnTutup" CssClass="btn btn-info" runat="server" Text="Tutup" />
        </div>
    </div>

</asp:Content>

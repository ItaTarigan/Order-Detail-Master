<%@ Page Title="Customer" Language="C#" MasterPageFile="~/Pages/Master/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerRincian.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.CustomerRincian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div id="divContent" class="divClass">
        <div class="row mt-2" runat="server" id="DivRow1">
            <div class="col-lg">

                <h2>
                    <asp:Label ID="rincian" runat="server"></asp:Label>
                    <asp:Label ID="txtNoOrder" runat="server" Text="Label"></asp:Label>

                </h2>
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow2">
            <div class="col-lg-4">
                <div class="card">

                    <div class="card-body" style="background-color: lightgray;">

                        <p class="card-text">
                            <b>
                                <asp:Label for="" ID="komoditas" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="txtKomoditas" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label for="" ID="tipeanalisis" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="txtTipeAnalis" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label for="" ID="totalsample" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="txtTotalSample" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label for="" ID="totalharga" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="TxtTotalHarga" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label for="" ID="status" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="txtStatusPesanan" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="card">
                    <div class="card-body" runat="server" id="DivDownload" visible="false">
                        <h5 class="card-title"> <asp:Label ID="lhpresult" runat="server"></asp:Label></h5>
                        <asp:Button ID="BtnDownload" runat="server" CssClass="btn btn-primary" Text="Download" />
                    </div>
                </div>
                 
            </div>
            <div class="col-lg-4" runat="server" id="DivDownloadLampiran" visible="false">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Download Lampiran</h5>
                        <asp:Button ID="BtnDownloadLampiran" CssClass="btn btn-primary" runat="server" Text="Download" />

                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row mt-2" runat="server" id="DivRow3">
            <div class="col-lg">
                <h2>
                    <asp:Literal ID="LitTitle" runat="server"></asp:Literal>
                </h2>
            </div>
            <div class="col-lg" style="text-align: right;">
                <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
                <a id="linkincrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-primary">+</a>
                <a id="linkdecrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-secondary">-</a>
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
                        <asp:TemplateField HeaderText="GPS">
                            <ItemTemplate>

                                <asp:Label ID="Loc" runat="server" Text='<%# Eval("latitude")+","+Eval("longitude") %>'>Parameter Uji</asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                        <asp:BoundField DataField="isReceived" HeaderText="Sample Diterima" />

                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>

                                <asp:LinkButton ID="Lihat" runat="server" CssClass="btn btn-primary" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="DetailorderList" Text="Lihat"></asp:LinkButton>
                                
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
                        fixGridView($("#<%=GvData.ClientID%>"));

                        $('#<%=GvData.ClientID%>').DataTable();
                        $('#linkincrease').click(function () {
                            $('#divContent').css('font-size', '+=3');
                        });

                        $('#linkdecrease').click(function () {
                            $('#divContent').css('font-size', '-=3');
                        });
                    });
                </script>
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow5">

            <div class="col-lg">
                <asp:Button ID="BtnKembali" CssClass="btn btn-primary" runat="server" Text="Kembali" CommandName="Kembali" OnClick="ActionButton" />
                <asp:Button ID="BtnKajiUlang" CssClass="btn btn-success" runat="server" Text="Kaji Ulang" CommandName="KajiUlang" OnClick="ActionButton" />
                <asp:Button ID="BtnCetakPermohonan" CssClass="btn btn-info" runat="server" Text="Cetak Lembar Permohonan" CommandName="Cetak" OnClick="ActionButton" />
            </div>
        </div>

        <div class="row mt-2" runat="server" id="DivRow6" visible="false">
            <div class="col-lg">
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvParameter" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="elementservicestbl.elementCode" HeaderText="Parameter Uji" />
                        <asp:BoundField DataField="status" HeaderText="Status Pengujian" />
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
                        $('#linkincrease').click(function () {
                            $('#divContent').css('font-size', '+=3');
                        });

                        $('#linkdecrease').click(function () {
                            $('#divContent').css('font-size', '-=3');
                        });
                    });
                </script>


            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow7" visible="false">
            <div class="col-lg">
                <asp:Button ID="BtnTutup" CssClass="btn btn-info" runat="server" Text="Tutup" />
            </div>
        </div>
    </div>
</asp:Content>

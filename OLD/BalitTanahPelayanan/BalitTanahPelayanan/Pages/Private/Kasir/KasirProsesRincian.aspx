<%@ Page Title="Kasir - Rincian Pesanan Diproses" Language="C#" MasterPageFile="~/Pages/Master/CommonNoHeader.Master" AutoEventWireup="true" CodeBehind="KasirProsesRincian.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Kasir.KasirProsesRincian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="row mt-2">
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="Label2" runat="server" style="font-size: 14px; font-weight:bold;" Text="Perbesar Halaman :"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div id="divContent" class="divClass">
        <div class="row mt-2">
            <div class="col-lg">
                <h2>
                    <asp:Literal ID="LitOrder" runat="server"></asp:Literal>
                    <asp:Label ID="txtNoOrder" runat="server" Text="Label"></asp:Label></h2>
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow2">
            <div class="col-lg-4">
                <div class="card">
                    <div class="card-body" style="background-color: lightgray;">
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitCustomer" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="txtCustomer" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitKomoditas" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="txtKomoditas" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitAnalisis" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="txtTipeAnalisis" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitSampel" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="txtTotalSample" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitHarga" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="txtTotalHarga" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow3">
            <div class="col-lg">
                <h3>
                    <asp:Literal ID="LitDaftarSampel" runat="server"></asp:Literal></h3>
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow4">
            <div class="col-lg">
                <asp:GridView CssClass="table table-bordered table-hover dataTable" ID="GvSample" runat="server" AutoGenerateColumns="false" AllowPaging="false">
                    <Columns>
                        <asp:BoundField DataField="countNumber" HeaderText="No Urut" />
                        <asp:BoundField DataField="sampleCode" HeaderText="No Sampel" />
                        <asp:BoundField DataField="noBalittanah" HeaderText="No Balittanah" />
                        <asp:BoundField DataField="village" HeaderText="Desa" />
                        <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                        <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                        <asp:BoundField DataField="province" HeaderText="Propinsi" />
                        <asp:TemplateField HeaderText="GPS">
                            <ItemTemplate>

                                <asp:Label ID="Loc" runat="server" Text='<%# Eval("latitude")+","+Eval("longitude") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>
                                <asp:LinkButton ID="Lihat" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="DetailorderList" Text="Lihat">Parameter Uji</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow5">
            <div class="col-lg">
                <asp:Button ID="btnKembali" CssClass="btn btn-secondary" runat="server" Text="Kembali" CommandName="Kembali" OnClick="ActionButton" />
                <asp:Button ID="btnPrint" CssClass="btn btn-success" runat="server" Text="Cetak Tanda Terima" CommandName="Cetak" OnClick="ActionButton" />
            </div>
        </div>
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
                //sample
                fixGridView($("#<%=GvSample.ClientID%>"));

                $('#<%=GvSample.ClientID%>').DataTable();

                $('#linkincrease').click(function () {
                    $('#divContent').css('font-size', '+=3');
                });

                $('#linkdecrease').click(function () {
                    $('#divContent').css('font-size', '-=3');
                });
            });
        </script>

        <div class="row mt-2" runat="server" id="DivRow6" visible="false">
            <div class="col-lg-4">
                <div class="card">
                    <div class="card-body" style="background-color: lightgray;">

                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitNoSampel" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="TxtNoSample" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitNoBalittanah" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="TxtNoBalitTanah" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitDesa" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="TxtDesa" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitKecamatan" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="TxtKecamatan" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitKabupaten" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="TxtKabupaten" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitPropinsi" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="TxtPropinsi" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitGPS" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="TxtGps" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Literal ID="LitTanah" runat="server"></asp:Literal>
                            </b>
                            <asp:Label ID="TxtTipeTanah" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-2" runat="server" id="DivRow7" visible="false">
            <div class="col-lg">
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvParameter" runat="server" AutoGenerateColumns="false" AllowPaging="false">
                    <Columns>
                        <asp:BoundField DataField="elementservicestbl.elementCode" HeaderText="Parameter Uji" />
                        <asp:BoundField DataField="status" HeaderText="Status" />
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
                        //$("#myModal").modal();
                    });
                </script>
            </div>
        </div>

        <div class="row mt-2" runat="server" id="DivRow8" visible="false">
            <div class="col-lg">
                <asp:Button ID="BtnTutup" CssClass="btn btn-info" runat="server" Text="Tutup" />
            </div>
        </div>
    </div>
</asp:Content>

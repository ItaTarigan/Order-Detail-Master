<%@ Page Title="Analis" Language="C#" MasterPageFile="~/Pages/Master/Analis.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Analis.OrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    
    <div class="row mt-2" runat="server" id="Div1">
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivRow1">
        <div class="col-lg">
            <h2><asp:Label ID="txtRincian" runat="server" Text="Rincian No Pesanan:"></asp:Label>
            <asp:Label ID="txtNoOrder" runat="server" Text="Label"></asp:Label>
            </h2>
        </div>
    </div>

    <div id="divContent" class="divClass">
        <div class="row mt-2" runat="server" id="DivRow2">
            <div class="col-lg-4">
                <div class="card">

                    <div class="card-body" style="background-color: lightgray;">

                        <p class="card-text">
                            <b>
                                <asp:Label ID="txtnamapelanggan" runat="server" Text="Nama Pelanggan  :"></asp:Label>
                            </b>
                            <asp:Label ID="txtCustomer" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txtkomoditas1" runat="server" Text="Komoditas :"></asp:Label>
                            </b>
                            <asp:Label ID="txtKomoditas" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txttipeanalis1" runat="server" Text="Tipe Analis :"></asp:Label>
                            </b>
                            <asp:Label ID="txtTipeAnalis" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txttotalsampel" runat="server" Text="Total Sample :"></asp:Label>
                            </b>
                            <asp:Label ID="txtTotalSample" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txttotalprice" runat="server" Text="Total Price :"></asp:Label>
                            </b>
                            <asp:Label ID="txtTotalHarga" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
       
        
        </div>
        <div class="row mt-2" runat="server" id="DivRow3">
            <div class="col-lg">
                <h3><asp:Label ID="txtDaftarSampel" runat="server" Text="Daftar Sampel"></asp:Label>
                </h3>
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

                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>

                                <asp:LinkButton ID="Lihat" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="DetailorderList" Text="Lihat">Parameter Uji</asp:LinkButton>

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
        <div class="row mt-2" runat="server" id="DivRow6">

            <div class="col-lg">
                <asp:Button ID="BtnKembali" CssClass="btn btn-primary" runat="server" Text="Kembali" CommandName="Kembali" OnClick="ActionButton" />
           
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow7" visible="false">
            <div class="col-lg-4">
                <div class="card">

                    <div class="card-body" style="background-color: lightgray;">

                        <p class="card-text">
                            <b>
                                <asp:Label ID="txtnosampel" runat="server" Text="No Sample :"></asp:Label>
                            </b>
                            <asp:Label ID="TxtNoSample" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txtnobalit" runat="server" Text="No Balit Tanah :"></asp:Label> 
                            </b>
                            <asp:Label ID="TxtNoBalitTanah" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txtdesa1" runat="server" Text="Desa :"></asp:Label>
                            </b>
                            <asp:Label ID="TxtDesa" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txtkecamatan1" runat="server" Text="Kecamatan :"></asp:Label>
                            </b>
                            <asp:Label ID="TxtKecamatan" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txtkabupaten1" runat="server" Text="Kabupaten :"></asp:Label>
                            </b>
                            <asp:Label ID="TxtKabupaten" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txtpropinsi1" runat="server" Text="Propinsi :"></asp:Label>
                            </b>
                            <asp:Label ID="TxtPropinsi" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txtgsp" runat="server" Text="GPS :"></asp:Label>
                            </b>
                            <asp:Label ID="TxtGps" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="txttipetanah1" runat="server" Text="Tipe Tanah :"></asp:Label>
                            </b>
                            <asp:Label ID="TxtTipeTanah" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow8" visible="false">
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
        <div class="row mt-2" runat="server" id="DivRow9" visible="false">
            <div class="col-lg">
                <asp:Button ID="BtnTutup" CssClass="btn btn-info" runat="server" Text="Tutup" />
            </div>
        </div>
    </div>
</asp:Content>
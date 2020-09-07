<%@ Page Async="true" Title="Sistem Informasi Pelayanan Online Balitanah - Daftar Pesanan" Language="C#" MasterPageFile="~/Pages/Master/Penyelia.Master" AutoEventWireup="true" CodeBehind="DaftarPesanan.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Penyelia.WebForm1" %>

<%@ Register Src="~/Usercontrols/OrderInfoBox.ascx" TagPrefix="custom" TagName="OrderInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
<script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="row mt-2">
        
    </div>
    <div id="divContent" class="divClass">
    <div class="row mt-2">
        <div class="col-lg">
            <custom:OrderInfo runat="server" ID="InfoBox1"></custom:OrderInfo>
        </div>
    </div>
    <br />
    <div class="row mt-2">
        <div class="col-lg">
            <asp:Button CssClass="btn btn-outline-primary btn-lg" ID="BtnFilterBatch" CommandName="Filter3" runat="server" Text="Batch" />
            <asp:Button CssClass="btn btn-outline-primary btn-lg" ID="BtnFilterProses" CommandName="Filter1" runat="server" Text="Daftar Pesanan" />
            <asp:Button CssClass="btn btn-outline-primary btn-lg" ID="BtnFilterSelesai" CommandName="Filter2" runat="server" Text="Pesanan Selesai" />
        </div>

    </div>
    <br />
    <div class="row mt-2">
        <div class="col-lg">
            <h2><img src="~/assets/img/sent.png" runat="server">
                        <span>
                <asp:Literal ID="LblStatus" runat="server"></asp:Literal></span></h2>
        </div>
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="PanelOrder" visible="true">
        <div class="col-lg">
            <asp:GridView ID="GridvData" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                    <asp:BoundField DataField="orderNo" HeaderText='No Pesanan' />
                    <asp:BoundField DataField="batchId" HeaderText='No Batch' />
                    <asp:BoundField DataField="customertbl.customerName" HeaderText="Nama Pelanggan" />
                    <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditas" />
                    <asp:BoundField DataField="analysisType" HeaderText="Tipe Analis" />
                    <asp:BoundField DataField="sampleTotal" HeaderText="Jumlah Sample" />
                    <asp:BoundField DataField="status" HeaderText="Status order" />
                    <asp:TemplateField HeaderText="Tindakan">
                        <ItemTemplate>

                            <asp:LinkButton ID="Lihat" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="lihatOrderList" Text="Lihat">Rincian</asp:LinkButton>

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
                    fixGridView($("#<%=GridvData.ClientID%>"));
            //$("#<%=GridvData.ClientID%>").tablesorter({ sortList: [[1, 0]] });
                    $('#<%=GridvData.ClientID%>').DataTable();
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
      <div class="row mt-2" id="PanelBatch" runat="server" visible="false">
        <div class="col-lg">
            <asp:GridView ID="GvBatch" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                    <asp:BoundField DataField="batchId" HeaderText='No Batch' />
                    <asp:BoundField DataField="employeetbl.employeeName" HeaderText="PIC Analis" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Tindakan">
                        <ItemTemplate>

                            <asp:LinkButton ID="Lihat" runat="server" CommandArgument='<%# Eval("batchId") %>' CommandName="lihatBatch" Text="Lihat">Rincian</asp:LinkButton>

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
                    fixGridView($("#<%=GvBatch.ClientID%>"));
            //$("#<%=GvBatch.ClientID%>").tablesorter({ sortList: [[1, 0]] });
                    $('#<%=GvBatch.ClientID%>').DataTable();
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
     <div class="row mt-2" id="PanelBatch2" runat="server" visible="false">
        <div class="col-lg">
            <asp:Button ID="BtnNewBatch" CssClass="btn btn-info" runat="server" Text="Batch Baru" />
        </div>
    </div>
    </div>

</asp:Content>

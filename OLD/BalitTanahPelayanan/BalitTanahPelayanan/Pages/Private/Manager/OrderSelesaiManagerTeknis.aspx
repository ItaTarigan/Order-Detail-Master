<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/ManagerTeknis.Master" AutoEventWireup="true" CodeBehind="OrderSelesaiManagerTeknis.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.OrderSelesaiManagerTeknis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <br />
    <div class="row mt-2">
        <div class="col-lg">
            <h5><i class="fa fa-check"></i>Pesanan Selesai</h5>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="Label1" runat="server" style="font-size: 14px; font-weight:bold;" Text="Perbesar Halaman :"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div id="divContent" class="divClass">
    <div class="row mt-2">
        <div class="col-lg">
            <asp:GridView CssClass="table table-bordered table-hover dataTable" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                    <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                    <asp:BoundField DataField="customertbl.customerName" HeaderText="Nama Pelanggan" />
                    <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditas" />
                    <asp:BoundField DataField="analysisType" HeaderText="Tipe Analisis" />
                    <asp:BoundField DataField="status" HeaderText="Status Pesanan" />
                    <asp:BoundField DataField="paymentStatus" HeaderText="Status Pembayaran" />
                    <asp:BoundField DataField="statusType" HeaderText="Tipe Pembayaran" />
                    <asp:TemplateField HeaderText="Tindakan">
                        <ItemTemplate>
                            <asp:Button ID="Download" runat="server" CssClass="btn btn-primary" CommandArgument='<%# Eval("orderNo") %>' CommandName="DownloadListManager" Text="Download" />
                            <asp:Button ID="Rincian" runat="server" CssClass="btn btn-primary" CommandArgument='<%# Eval("orderNo") %>' CommandName="lihatdetail" Text="Rincian"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
            fixGridView($("#<%=GvData.ClientID%>"));

            $('#<%=GvData.ClientID%>').DataTable();


            $('#linkincrease').click(function () {
                $('#divContent').css('font-size', '+=3');
            });

            $('#linkdecrease').click(function () {
                $('#divContent').css('font-size', '-=3');
        });
    </script>
</div>
</asp:Content>

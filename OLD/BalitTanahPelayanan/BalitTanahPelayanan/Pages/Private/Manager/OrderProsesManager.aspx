<%@ Page Language="C#" MasterPageFile="~/Pages/Master/ManagerTeknis.Master" AutoEventWireup="true" CodeBehind="OrderProsesManager.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.OrderProsesManager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <%--<br />--%>
    <div class="row mt-2">
        <div class="col-lg">
            <h5><i class="fa fa-check"></i>Pesanan Diproses</h5>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div id="divContent" class="divClass">
    <div class="row mt-2">
        <div class="col-lg">
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                    <asp:BoundField DataField="customertbl.customerName" HeaderText="Nama Pelanggan" />
                    <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komiditi" />
                    <asp:BoundField DataField="analysisType" HeaderText="Tipe Analisis" />
                    <asp:BoundField DataField="isPaid" HeaderText="Sudah di Bayar" />
                    <asp:BoundField DataField="statusType" HeaderText="Tipe Pembayaran" />
                    <asp:BoundField DataField="status" HeaderText="Status Pesanan" />
                    <asp:TemplateField HeaderText="Tindakan">
                        <ItemTemplate>
                            <asp:Button ID="btnlihat" CommandName="lihat" CssClass="btn btn-primary" CommandArgument='<%# Eval("Orderno") %>' Text="Rincian" runat="server" />
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

<%@ Page Title="Evaluasi" Language="C#" MasterPageFile="~/Pages/Master/Evaluator.Master" AutoEventWireup="true" CodeBehind="EvaluasiHasil.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Evaluator.EvaluasiHasil" %>

<%@ Register Src="~/Usercontrols/ManagerInfoOrderBox.ascx" TagPrefix="custom" TagName="InfoBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="row mt-2">
        <div class="col-lg">
            <custom:InfoBox runat="server" ID="Info1"></custom:InfoBox>
        </div>
    </div>
    <br />
    <div class="row mt-2">
        <div class="col-lg">
            <h2>
                <img src="~/assets/img/sent.png" runat="server">
                <span>
                    <asp:Label ID="txtevaluasihasil" runat="server" Text="Evaluasi Hasil"></asp:Label>
                </span>
            </h2>
        </div>
        <div class="col-lg" style="text-align: right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <br />
    <div id="divContent" class="divClass">
        <div class="row mt-2">
            <div class="col-lg">
                <asp:GridView ID="GridvData" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                        <asp:BoundField DataField="customertbl.customerName" HeaderText="Nama Pelanggan" />
                        <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditas" />
                        <asp:BoundField DataField="analysisType" HeaderText="Tipe Analis" />
                        <asp:BoundField DataField="status" HeaderText="Status Pesanan" />
                        <asp:BoundField DataField="paymentStatus" HeaderText="Status Pembayaran" />
                        <asp:BoundField DataField="statusType" HeaderText="Tipe Pembayaran" />
                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>
                                <asp:LinkButton ID="Lihat" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="lihatOrderList" Text="Lihat">Rincian</asp:LinkButton>
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
</asp:Content>

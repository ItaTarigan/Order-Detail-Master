<%@ Page Title="Manager Teknis" Language="C#" MasterPageFile="~/Pages/Master/ManagerTeknis.Master" AutoEventWireup="true" CodeBehind="Dash_ManagerTeknis.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Dash_ManagerTeknis" %>

<%@ Register Src="~/Usercontrols/ManagerInfoOrderBox.ascx" TagPrefix="custom" TagName="InfoBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="row mt-2">
        <div class="col-lg">
            <custom:InfoBox runat="server" ID="Info"></custom:InfoBox>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
            <asp:Button ID="BtnPesananMasuk" CssClass="btn btn-outline-primary btn-lg" CommandName="PesananMasuk" runat="server" Text="Pesanan Masuk" OnClick="ActionButtonClicked" />
            <asp:Button ID="BtnProses" CssClass="btn btn-outline-primary btn-lg" CommandName="PesananDiProses" runat="server" Text="Pesanan Diproses" OnClick="ActionButtonClicked" />
            <asp:Button ID="BtnApproval" CssClass="btn btn-outline-primary btn-lg" CommandName="PesananApproval" runat="server" Text="Approval Pesanan" OnClick="ActionButtonClicked" />
            <asp:Button ID="BtnSelesai" CssClass="btn btn-outline-primary btn-lg" CommandName="PesananSelesai" runat="server" Text="Pesanan Selesai" OnClick="ActionButtonClicked" />
            <asp:Button ID="BtnStatistik" CssClass="btn btn-outline-primary btn-lg" CommandName="StatistikPesanan" runat="server" Text="Statistik Pesanan" OnClick="ActionButtonClicked" />
            <asp:Button ID="BtnBoardTugas" CssClass="btn btn-outline-primary btn-lg" CommandName="BoardTugas" runat="server" Text="Board Tugas" OnClick="ActionButtonClicked" />
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
                <br />
                <h2>
                    <img src="~/assets/img/sent.png" runat="server">
                    <b><asp:Literal ID="LblStatus" runat="server"></asp:Literal></b></h2>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg">
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                        <asp:BoundField DataField="customertbl.customerName" HeaderText="Nama Pelanggan" />
                        <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditas" />
                        <asp:BoundField DataField="analysisType" HeaderText="Tipe Analisis" />
                        <asp:BoundField DataField="status" HeaderText="Status Pesanan" />
                        <asp:BoundField DataField="isPaid" HeaderText="Status Pembayaran" />
                        <asp:BoundField DataField="statusType" HeaderText="Tipe Pembayaran" />
                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>
                                <asp:Button ID="BtnPilihPIC" CssClass="btn btn-primary" CommandName="lihat" CommandArgument='<%# Eval("Orderno") %>' Text="Pilih Penyelia" runat="server" />
                                <asp:Button ID="BtnRincian" CssClass="btn btn-primary" CommandName="rincian" CommandArgument='<%# Eval("Orderno") %>' Text="Rincian" runat="server" />
                                <asp:Button ID="BtnDownload" CssClass="btn btn-primary" CommandName="download" CommandArgument='<%# Eval("Orderno") %>' Text="Download" runat="server" />
                                <asp:Button ID="BtnApproval" CssClass="btn btn-primary" CommandName="approval" CommandArgument='<%# Eval("Orderno") %>' Text="Approval" runat="server" />
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
            });
        </script>
    </div>
</asp:Content>

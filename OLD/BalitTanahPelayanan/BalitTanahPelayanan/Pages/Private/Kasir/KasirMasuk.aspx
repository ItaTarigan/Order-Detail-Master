<%@ Page Title="Kasir - Pesanan Masuk" Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Master/Kasir.Master" CodeBehind="KasirMasuk.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.KasirMasuk" %>

<%@ Register Src="~/Usercontrols/ManagerInfoOrderBox.ascx" TagPrefix="custom" TagName="InfoBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="row mt-2">
        <div class="col-lg">
            <custom:InfoBox runat="server" ID="Info"></custom:InfoBox>
        </div>
    </div>
    <br />
    <div class="row mt-2">
        <div class="col-lg">
            <asp:Button ID="btnMasuk" runat="server" PostBackUrl="~/Pages/Private/Kasir/KasirMasuk.aspx" class="btn btn-outline-primary btn-lg" Text="Pesanan Masuk" />
            <asp:Button ID="btnProses" runat="server" PostBackUrl="~/Pages/Private/Kasir/KasirProses.aspx" class="btn btn-outline-primary btn-lg" Text="Pesanan Diproses" />
            <asp:Button ID="btnSelesai" runat="server" PostBackUrl="~/Pages/Private/Kasir/KasirSelesai.aspx" class="btn btn-outline-primary btn-lg" Text="Pesanan Selesai" />
            <asp:Button ID="btnVerifikasi" runat="server" PostBackUrl="~/Pages/Private/Kasir/KasirVerifikasiPembayaran.aspx" class="btn btn-outline-primary btn-lg" Text="Verifikasi Pembayaran (Transfer)" />
        </div>
    </div>
    <br />
    <asp:Panel ID="PanelGridMasuk" runat="server">
        <div id="divContent" class="divClass">
            <div class="row mt-2">
                <div class="col-lg">
                    <h2>
                        <img src="~/assets/img/sent.png" runat="server">
                        <span>
                            <asp:Literal ID="LitMasuk" runat="server"></asp:Literal></span></h2>
                </div>
                <div class="col-lg" style="text-align: right;">
                    <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
                    <a id="linkincrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-primary">+</a>
                    <a id="linkdecrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-secondary">-</a>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-lg">
                    <asp:GridView runat="server" CssClass="table table-bordered table-hover" ID="GvData" AutoGenerateColumns="false">
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
                                    <asp:LinkButton ID="btnRincian" runat="server" PostBackUrl='<%# "KasirRincian.aspx?orderNo=" + Eval("orderNo") %>' CommandName="detail" Text="Rincian"></asp:LinkButton>
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
    </asp:Panel>

</asp:Content>

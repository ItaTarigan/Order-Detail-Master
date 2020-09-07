<%@ Page Title="Customer Service" Language="C#" MasterPageFile="~/Pages/Master/CS.Master" AutoEventWireup="true" CodeBehind="CustomerServiceBeranda.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.CS.CustomerServiceBeranda" %>

<%@ Register Src="~/Usercontrols/CSOrderInfoBox.ascx" TagPrefix="custom" TagName="InfoBox" %>
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
            <asp:Button ID="BtnPesananMasuk" CssClass="btn btn-outline-primary btn-lg" CommandName="PesananMasuk" runat="server" Text="Pesanan Masuk" OnClick="ActionButtonClicked" />
            <asp:Button ID="BtnProses" CssClass="btn btn-outline-primary btn-lg" CommandName="PesananDiProses" runat="server" Text="Pesanan Diproses" OnClick="ActionButtonClicked" />
            <asp:Button ID="BtnSelesai" CssClass="btn btn-outline-primary btn-lg" CommandName="PesananSelesai" runat="server" Text="Pesanan Selesai" OnClick="ActionButtonClicked" />
            <asp:Button ID="BtnValidasiQR" CssClass="btn btn-outline-primary btn-lg" CommandName="ValidasiQR" runat="server" Text="Validasi QR LHP" OnClick="ActionButtonClicked" />
        </div>
    </div>
    <br />
    <div class="row mt-2">
        <div class="col-lg">
            <h2><img src="~/assets/img/sent.png" runat="server">
                        <span>
                <asp:Literal ID="LblStatus" runat="server"></asp:Literal></span>
            </h2>
        </div>
        <div class="col-lg" style="text-align:right;">
                <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
                <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
                <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
            </div>
    </div>
    <br />
    <div id="divContent" class="divClass">
        <div class="row mt-2">
            <div class="col-lg-3">
                    <div class="input-group ml-0">
                        <asp:TextBox CssClass="form-control" ID="TxtBarcode" placeholder="Scan Barcode" runat="server"></asp:TextBox>
                        <span class="input-group-btn ml-2">
                            <asp:Button CssClass="btn btn-info" ID="BtnCari" runat="server" Text="Cari" />
                        </span>
                    </div>
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
                                <asp:Button ID="BtnTerimaSampel" CssClass="btn btn-primary" CommandName="terima-sampel" CommandArgument='<%# Eval("Orderno") %>' Text="Terima Sampel" runat="server" />
                                <asp:Button ID="BtnCetakBarcode" CssClass="btn btn-primary" CommandName="cetak-barcode" CommandArgument='<%# Eval("Orderno") %>' Text="Cetak Barcode Sampel" runat="server" />
                                <asp:Button ID="BtnProsesLab" OnClientClick="return confirm('Anda yakin ingin proses ke Lab?');" CssClass="btn btn-primary" CommandName="proses-lab" CommandArgument='<%# Eval("Orderno") %>' Text="Proses ke Lab" runat="server" />
                                <asp:Button ID="BtnLihat" CssClass="btn btn-primary" CommandName="lihat" CommandArgument='<%# Eval("Orderno") %>' Text="Rincian" runat="server" />
                                <asp:Button ID="BtnKirimNotif" CssClass="btn btn-primary" CommandName="kirim-notif" CommandArgument='<%# Eval("Orderno") %>' Text="Kirim Notifikasi Customer" runat="server" />
                                <asp:Button ID="BtnSelesai" CssClass="btn btn-primary" CommandName="ambil-lhp" OnClientClick="return confirm('Anda yakin customer sudah mengambil LHP ini?');" CommandArgument='<%# Eval("Orderno") %>' Text="Pengambilan LHP" runat="server" />
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
                    $('body').css('font-size', '+=3');
                });

                $('#linkdecrease').click(function () {
                    $('body').css('font-size', '-=3');
                });
            });
        </script>
    </div>
</asp:Content>

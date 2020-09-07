<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Kasir.Master" AutoEventWireup="true" CodeBehind="KasirVerifikasiPembayaran.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Kasir.KasirVerifikasiPembayaran" %>

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
                            <asp:BoundField DataField="customerName" HeaderText="Nama Pelanggan" />
                            <asp:BoundField DataField="priceTotal" DataFormatString="{0:n}" HeaderText="Harga Total" />
                            <asp:BoundField DataField="amount" DataFormatString="{0:n}" HeaderText="Jumlah Transfer" />
                            <asp:BoundField DataField="accountName" HeaderText="Nama Rekening" />
                            <asp:BoundField DataField="accountNo" HeaderText="No Rekening" />
                            <asp:BoundField DataField="bankName" HeaderText="Nama Bank" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Bukti Pembayaran">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnBukti" CommandArgument='<%#Eval("ImgUrl") %>' runat="server" CommandName="Lihat" Text="Lihat"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lampiran Lain (resi)">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnLampiran" CommandArgument='<%#Eval("AttachmentUrl") %>' runat="server" CommandName="Download" Text="Unduh"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tindakan">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnTerima" runat="server" CommandArgument='<%#Eval("paymentId") %>' CommandName="Terima" Text="Terima"></asp:LinkButton>
                                    <asp:LinkButton ID="BtnTolak" OnClientClick="return confirm('Anda yakin ingin menolak?'); " runat="server" CommandArgument='<%#Eval("paymentId") %>' CommandName="Tolak" Text="Tolak"></asp:LinkButton>

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
    <asp:Panel ID="DivPayment" runat="server" Visible="false">
         <div class="row mt-2">
            <div class="col-lg-4">
                <h3><asp:Literal runat="server" Text="Atur Tipe Pembayaran" ID="litSubHeader"></asp:Literal></h3>
                 </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg-4">
                <div class="card">

                    <div class="card-body" style="background-color: lightgray;">
                        <h5 class="card-title">
                            <asp:Literal ID="litStatusPembayaran" runat="server"></asp:Literal>
                        </h5>
                        <p class="card-text">
                            <asp:DropDownList ID="StatusPembayaranCmb" runat="server" CssClass="form-control"></asp:DropDownList>
                        </p>
                    </div>
                </div>
                <div class="card">

                    <div class="card-body" style="background-color: lightgray;">
                        <h5 class="card-title">
                            <asp:Literal ID="litTipePembayaran" runat="server"></asp:Literal>
                        </h5>
                        <p class="card-text">
                            <asp:DropDownList ID="TipePembayaranCmb" runat="server" CssClass="form-control"></asp:DropDownList>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg-4">
                <asp:HiddenField ID="HidPaymentID" runat="server" />
                <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Kembali" />
                <asp:Button ID="BtnSave" CssClass="btn btn-info" runat="server" Text="Proses" />
            </div>
        </div>
    </asp:Panel>

</asp:Content>

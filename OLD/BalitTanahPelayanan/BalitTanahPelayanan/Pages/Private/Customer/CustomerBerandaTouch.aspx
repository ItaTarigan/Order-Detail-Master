<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerBerandaTouch.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.CustomerBerandaTouch" %>

<%@ Register Src="~/Usercontrols/OrderInfoBox.ascx" TagPrefix="custom" TagName="OrderInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    
    <div id="divContent" class="divClass">
        <div class="row mt-2" id="DivRow1" runat="server">
            <div class="col-lg">
                <custom:OrderInfo FilterType="ByUser" runat="server" ID="InfoBox1"></custom:OrderInfo>
            </div>
        </div>
        <div class="row mt-2" runat="server">
        </div>
        <div class="row mt-2" id="DivRow2" runat="server">
            <div class="col-lg">
                <h2 class="title-icon">
                    <img src="~/assets/img/sent.png" runat="server">
                    <span>
                        <asp:Literal ID="LitTitle" runat="server"></asp:Literal>
                    </span>
                </h2>
            </div>
            <div class="col-lg" style="text-align: right;">
                <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
                <a id="linkincrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-primary">+</a>
                <a id="linkdecrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-secondary">-</a>
            </div>
        </div>
        <div class="row mt-2" id="DivRowComodity" runat="server">
            <div class="col-lg form-group">
                <asp:Label ID="cmb2Komoditas" for="CmbJenisAnalisa" runat="server" Text="Pilih Komoditas">Pilih Komoditas</asp:Label>
                <asp:DropDownList ID="CmbKomoditas" class="form-control" aria-describedby="desc4" placeholder="Pilih Komoditas" runat="server" OnSelectedIndexChanged="ChangeValueKomoditas" AppendDataBoundItems="true" AutoPostBack="true">
                    <asp:ListItem Value="001" Text="Show All"></asp:ListItem>
                </asp:DropDownList>
                <small id="desc4" class="form-text text-muted">
                    <asp:Label runat="server" ID="lbspta"></asp:Label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="vg1" runat="server" ControlToValidate="CmbKomoditas" ErrorMessage="Silakan pilih tipe analisa"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row mt-2" id="DivRow3" runat="server">
            <div class="col-lg">
                <asp:GridView ID="GridData" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="false" AllowPaging="false">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText='No Pesanan' />
                        <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditas" />
                        <asp:BoundField DataField="analysisType" HeaderText="Tipe Analis" />
                        <asp:BoundField DataField="sampleTotal" HeaderText="Jumlah Sampel" />
                        <asp:BoundField DataField="status" HeaderText="Status Pesanan" />
                        <asp:BoundField DataField="paymentStatus" HeaderText="Status Pembayaran" />
                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>

                                <asp:LinkButton ID="BtnLihat" CssClass="linkbtn" runat="server" PostBackUrl='<%# "CustomerRincian.aspx?orderNo=" + Eval("orderNo") %>' Text="Rincian"></asp:LinkButton>
                                <asp:LinkButton ID="BtnBayar" CssClass="linkbtn" runat="server" PostBackUrl='<%# "CustomerBayar.aspx?orderNo=" + Eval("orderNo") %>' Text="Bayar via Transfer"></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>
        <div class="row mt-2" id="DivRow4" runat="server">

            <div class="col-lg align-self-end">
                <asp:Button ID="BtnOrder" CssClass="btn btn-info" runat="server" Text="Pesanan Baru" />
                <asp:Button ID="BtnSOP" CssClass="btn btn-success" runat="server" Text="Standar Prosedur" />
                 <asp:Button ID="BtnValidasiQR" CssClass="btn btn-success" runat="server" Text="Validasi QR LHP" />
            </div>

        </div>
        <div class="row mt-2" id="DivRow5" runat="server" visible="false">

            <div class="col-lg text-center">
                <img src="../../../assets/img/SOP.png" width="900" alt="sop" />
            </div>

        </div>
        <div class="row mt-2" id="DivRow6" runat="server" visible="false">

            <div class="col-lg text-center">
                <asp:Button ID="BtnTutup" CssClass="btn btn-warning" runat="server" Text="Tutup" />
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
                fixGridView($("#<%=GridData.ClientID%>"));
                $('#<%=GridData.ClientID%>').DataTable();

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

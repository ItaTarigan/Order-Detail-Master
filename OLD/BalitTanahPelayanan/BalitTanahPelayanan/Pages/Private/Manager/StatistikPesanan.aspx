<%@ Page Language="C#" Title="Manager Teknis" AutoEventWireup="true" CodeBehind="StatistikPesanan.aspx.cs" MasterPageFile="~/Pages/Master/SinglePage.Master" Inherits="BalitTanahPelayanan.Pages.Private.Manager.StatistikPesanan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="row mt-2">
        <div class="col-lg">
            <h2>
                <img src="~/assets/img/sent.png" runat="server">
                <asp:Label runat="server" ID="lblStatistik">Statistik Pesanan</asp:Label></h2>
        </div>
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div id="divContent" class="divClass">
    <div class="row mt-2">
        <div class="col-lg-6">
            <h4>
                <asp:Label ID="lblpenyelia" runat="server">Customer</asp:Label></h4>
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvCustomer" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="customerName" HeaderText="Nama" />
                    <asp:BoundField DataField="analysisType" HeaderText="Lab" />
                    <asp:BoundField DataField="sampleTotal" HeaderText="Jumlah Sample" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>

                            <asp:LinkButton ID="btnPesanan" runat="server" OnClick="LinkButton_Click" CommandArgument='<%# Eval("customerNo") %>' Text="Daftar Pesanan"></asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-lg-6">
            <h4>
                <asp:Label ID="lborder" runat="server">Daftar Pesanan</asp:Label></h4>
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvPesanan" runat="server" AutoGenerateColumns="false" Visible="false">
                <Columns>
                    <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                    <asp:BoundField DataField="sampleTotal" HeaderText="Jumlah Sampel" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>

                            <asp:LinkButton ID="btnView" runat="server" CommandArgument='<%# Eval("orderNo") %>' Text="Lihat" OnClick="ViewButton_Click"></asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="row mt-2">
        <div class="col-lg">
            <h4>
                <asp:Label ID="lblSampel" runat="server">Daftar Sampel</asp:Label></h4>
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" Visible="false">
                <Columns>
                    <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                    <asp:BoundField DataField="sampleCode" HeaderText="No Sampel" />
                    <asp:BoundField DataField="noBalittanah" HeaderText="No Balitanah" />
                    <asp:BoundField DataField="village" HeaderText="Desa" />
                    <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                    <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                    <asp:BoundField DataField="province" HeaderText="Provinsi" />
                    <asp:TemplateField HeaderText="GPS">
                        <ItemTemplate>

                            <asp:Label ID="Loc" runat="server" Text='<%# Eval("latitude")+","+Eval("longitude") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                    <asp:BoundField DataField="isReceived" HeaderText="Sampel Diterima" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>

                            <asp:LinkButton ID="btnParamUji" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="parameterUji" Text="Parameter Uji"></asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
            <asp:Button ID="BtnKembali" CssClass="btn btn-primary" runat="server" Text="Kembali" OnClick="btnBalikManager_Click" />
        </div>
    </div>

    <div class="row mt-2" runat="server" id="divParamUji" visible="false">
        <div class="col-lg">
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvParamuji" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                    <asp:BoundField DataField="elementservicestbl.elementCode" HeaderText="Parameter Uji" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
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
                    fixGridView($("#<%=GvParamuji.ClientID%>"));

                    $('#<%=GvParamuji.ClientID%>').DataTable();
                });
            </script>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
            <asp:Button ID="btnBalikDah" CssClass="btn btn-info" runat="server" Text="Close" OnClick="btnBalikDah_Click" Visible="false" />
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
            //grid penyelia
            fixGridView($("#<%=GvCustomer.ClientID%>"));
            $('#<%=GvCustomer.ClientID%>').DataTable();
            $('#linkincrease').click(function () {
                $('#divContent').css('font-size', '+=3');
            });

            $('#linkdecrease').click(function () {
                $('#divContent').css('font-size', '-=3');
            });
            //grid parameter
            fixGridView($("#<%=GvPesanan.ClientID%>"));
            $('#<%=GvPesanan.ClientID%>').DataTable();
            $('#linkincrease').click(function () {
                $('#divContent').css('font-size', '+=3');
            });

            $('#linkdecrease').click(function () {
                $('#divContent').css('font-size', '-=3');
            });
            //grid data
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Analis.Master" AutoEventWireup="true" CodeBehind="AnalisBerandaNonBatch.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Analis.AnalisBerandaNonBatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="row mt-2">
        <div class="col-lg">
            <h2>Daftar Sample</h2>
        </div>

    </div>
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
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                    <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                    <asp:BoundField DataField="sampleCode" HeaderText="No Sample" />
                    <asp:BoundField DataField="noBalittanah" HeaderText="No Balittanah" />
                    <asp:BoundField DataField="village" HeaderText="Desa" />
                    <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                    <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                    <asp:BoundField DataField="province" HeaderText="Propinsi" />
                    <asp:BoundField DataField="longitude" HeaderText="Koordinat Gps" />
                    <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                    <asp:BoundField DataField="isReceived" HeaderText="Sample Diterima" />
                    <asp:TemplateField HeaderText="Tindakan">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lihat" runat="server" PostBackUrl='<%# "InputParameter.aspx?NoBalitTanah="+Eval("noBalittanah") %>' Text="Lihat">Input Parameter Uji</asp:LinkButton>
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
            //$("#<%=GvData.ClientID%>").tablesorter({ sortList: [[1, 0]] });
            $('#<%=GvData.ClientID%>').DataTable();
        });
    </script>
</asp:Content>

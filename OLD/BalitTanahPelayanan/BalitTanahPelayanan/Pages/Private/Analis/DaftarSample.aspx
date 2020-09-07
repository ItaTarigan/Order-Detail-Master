<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Analis.Master" AutoEventWireup="true" CodeBehind="DaftarSample.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Analis.DaftarSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="row mt-2">
        <div class="col-lg">
            <h2>
                <asp:Label ID="txtdaftarsample" runat="server" Text="Daftar Sample"></asp:Label>
            </h2>
        </div>
        <div class="col-lg" style="text-align: right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div id="divContent" class="divClass">
        <div class="row mt-2">
            <div class="col-lg-3">
                <div class="input-group ml-0 mb-2">
                    <asp:TextBox CssClass="form-control" ID="TxtBarcode" placeholder="Scan Barcode" runat="server"></asp:TextBox>
                    <span class="input-group-append ml-0">
                        <asp:Button CssClass="btn btn-info" ID="BtnCari" runat="server" />
                    </span>
                </div>
            </div>

        </div>
        <div class="row mt-2">
            <div class="col-lg">
                <asp:GridView CssClass="table table-bordered table-hover dataTable table-rowborder" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                        <asp:BoundField DataField="sampleCode" HeaderText="No Sample" />
                        <asp:BoundField DataField="noBalittanah" HeaderText="No Balittanah" />
                        <asp:BoundField DataField="village" HeaderText="Desa" />
                        <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                        <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                        <asp:BoundField DataField="province" HeaderText="Propinsi" />
                        <asp:TemplateField HeaderText="Koordinat GPS">
                            <ItemTemplate>
                                <asp:Label ID="Loc" runat="server" Text='<%# Eval("latitude")+","+Eval("longitude") %>'>Parameter Uji</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                        <asp:BoundField DataField="isReceived" HeaderText="Sample Diterima" />
                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>
                                <asp:LinkButton ID="Lihat" CssClass="btn linkbtn" runat="server" PostBackUrl='<%# "InputParameter.aspx?NoBalitTanah="+Eval("noBalittanah") %>' Text="Lihat">Input Parameter Uji</asp:LinkButton>
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
                 $("#<%=GvData.ClientID%>").tablesorter({ sortList: [[1, 0]] });
                 $('#<%=GvData.ClientID%>').DataTable();
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

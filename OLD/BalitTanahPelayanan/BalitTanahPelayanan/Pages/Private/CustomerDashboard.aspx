<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.CustomerDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="row mt-2">
        <div class="col-lg">
            <i class="fa fa-bookmark"><h2>Daftar Pesanan</h2></i>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
          
              
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                        <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditas" />
                        <asp:BoundField DataField="analysisType" HeaderText="Tipe Analisis" />
                        <asp:BoundField DataField="sampleTotal" HeaderText="Jumlah Sampel" />
                        <asp:BoundField DataField="priceTotal" HeaderText="Jumlah Harga" />
                        <asp:BoundField DataField="status" HeaderText="Status Pesanan" />
                        <asp:BoundField DataField="statusType" HeaderText="Staus Pembayaran" />
                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>
                                <asp:Button ID="btnlihat" CssClass="btn btn-primary" CommandName="lihat" PostBackUrl='<%# "CustomerRincian.aspx?orderNo=" + Eval("orderNo") %>' Text="Rincian" runat="server" />
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
        });
    </script>
</asp:Content>
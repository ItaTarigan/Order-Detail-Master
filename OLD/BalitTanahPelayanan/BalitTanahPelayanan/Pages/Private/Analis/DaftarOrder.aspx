<%@ Page Async="true" Title="Analis - Upload Batch" Language="C#" MasterPageFile="~/Pages/Master/Analis.Master" AutoEventWireup="true" CodeBehind="DaftarOrder.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Analis.DaftarOrder" %>

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
            <asp:Label ID="LblFontSize" runat="server" style="font-size: 14px; font-weight:bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div id="divContent" class="divClass">
        <div class="row mt-2">

            <%-- Btn Download --%>
            <div class="col-lg-4" runat="server" id="BtnDownloadDiv">
                <div class="card">
                    <div class="card-body">

                        <h5 class="card-title">
                            <asp:Literal ID="litDownload" runat="server"></asp:Literal></h5>
                        <asp:Button ID="BtnDownload" CssClass="btn btn-primary" runat="server" Text="Download Template" />

                    </div>
                </div>
            </div>
            <%-- BtnUpload --%>
            <div class="col-lg-4" runat="server" id="BtnUploadDiv">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Literal ID="litUpload" runat="server"></asp:Literal></h5>

                        <p class="card-text">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </p>

                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg">
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>

                        <asp:BoundField DataField="orderNo" HeaderText='No Pesanan' />
                        <asp:BoundField DataField="customertbl.customerName" HeaderText="Nama Pelanggan" />
                        <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditas" />
                        <asp:BoundField DataField="analysisType" HeaderText="Tipe Analis" />
                        <asp:BoundField DataField="sampleTotal" HeaderText="Jumlah Sample" />
                        <asp:BoundField DataField="status" HeaderText="Status order" />
                        <asp:TemplateField HeaderText="Pilih">
                            <ItemTemplate>
                                <asp:LinkButton ID="BtnRincian" runat="server" CommandName="Detail" CommandArgument='<%#Eval("orderNo") %>' Text="Parameter Uji"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%-- Script untuk GvSample --%>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg">

                <asp:Button ID="BtnSimpan" ValidationGroup="vg1" CssClass="btn btn-info" runat="server" Text="Simpan" />
                <asp:Button ID="BtnBack" CssClass="btn btn-success" runat="server" Text="Kembali" />
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

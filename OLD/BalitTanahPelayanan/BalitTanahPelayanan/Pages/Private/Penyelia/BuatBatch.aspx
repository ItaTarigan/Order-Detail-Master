<%@ Page Async="true" Title="Sistem Informasi Pelayanan Online Balitanah - Buat Batch" Language="C#" MasterPageFile="~/Pages/Master/Penyelia.Master" AutoEventWireup="true" CodeBehind="BuatBatch.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Penyelia.BuatBatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <%-- Judul --%>
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
            <h2>
                <asp:Literal ID="LitTitleBatch" runat="server"></asp:Literal>
            </h2>
        </div>
    </div>
    <%-- SideBox --%>
    <div class="row mt-2" id="Div1" runat="server">
                <div class="col-lg-4">
                    <div>
                        <div class="form-group">
                            <asp:Label id="LblNoBatch" for="TxtNoBatch" runat="server">No Batch</asp:Label>
                            <asp:TextBox TextMode="SingleLine" ReadOnly="true" ID="TxtNoBatch" class="form-control" aria-describedby="desc0" placeholder="No Batch" runat="server"></asp:TextBox>
                            <asp:Label id="desc0" class="form-text text-muted" for="TxtNoBatch" runat="server">No Batch (auto generated)</asp:Label>
                            <%--<small id="desc0" runat="server"></small>--%>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LblPilihPIC" for="CmbPIC" runat="server">Pilih PIC</asp:Label>
                            <asp:DropDownList ID="CmbPIC" class="form-control" aria-describedby="desc4" placeholder="Pilih PIC" runat="server" ></asp:DropDownList>
                            <small id="desc4" class="form-text text-muted">
                            <asp:Label runat="server" ID="lbpilihpic"></asp:Label></small>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="vg1" runat="server" ControlToValidate="CmbPIC" ErrorMessage="Silakan pilih PIC"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
    </div>
    <%-- Gridview Sample --%>
    <div class="row mt-2" runat="server" id="DivRow3">
        <div class="col-lg">
            <h3><asp:Label ID="LblPesananBatch" runat="server" Text="Batch Pesanan"></asp:Label></h3>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                   <asp:TemplateField HeaderText="Pilih">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkPilih" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="orderNo" HeaderText='No Pesanan' />
                    <asp:BoundField DataField="customertbl.customerName" HeaderText="Nama Pelanggan" />
                    <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditas" />
                    <asp:BoundField DataField="analysisType" HeaderText="Tipe Analis" />
                    <asp:BoundField DataField="sampleTotal" HeaderText="Jumlah Sample" />
                    <asp:BoundField DataField="status" HeaderText="Status order" />
                </Columns>
            </asp:GridView>
            <%-- Script untuk GvSample --%>
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
    </div>
  

    <div class="row mt-2" >
        <div class="col-lg">
            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="vg1" ID="ValidationSummary1" runat="server" />
            <asp:Button ID="BtnSimpan" ValidationGroup="vg1" CssClass="btn btn-info" runat="server" Text="Simpan" />
            <asp:Button ID="BtnBack" CssClass="btn btn-success" runat="server" Text="Kembali" />
        </div>
    </div>
</div>
</asp:Content>

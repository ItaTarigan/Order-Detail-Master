<%@ Page Title="Kasir - Rincian Pesanan Masuk" Language="C#" MasterPageFile="~/Pages/Master/CommonNoHeader.Master" AutoEventWireup="true" CodeBehind="KasirRincian.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Kasir.KasirRincian" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kasir - Rincian Pesanan Masuk</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div class="row mt-2">
        <div class="col-lg" style="text-align: right;">
            <asp:label id="LblFontSize" runat="server" style="font-size: 14px; font-weight: bold;" text="Perbesar Teks"></asp:label>
            <a id="linkincrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>

    <div id="divContent" class="divClass">
        <div class="row mt-2">
            <div class="col-lg">
                <h2>
                    <asp:literal id="LitOrder" runat="server"></asp:literal>
                    <asp:label id="txtNoOrder" runat="server" text="Label"></asp:label>
                </h2>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg-4">
                <div class="card">

                    <div class="card-body" style="background-color: lightgray;">

                        <p class="card-text">
                            <b>
                                <asp:literal id="LitCustomer" runat="server"></asp:literal>
                            </b>
                            <asp:label id="txtCustomer" runat="server" text="Label"></asp:label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:literal id="LitKomoditas" runat="server"></asp:literal>
                            </b>
                            <asp:label id="txtKomoditas" runat="server" text="Label"></asp:label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:literal id="LitAnalisis" runat="server"></asp:literal>
                            </b>
                            <asp:label id="txtTipeAnalisis" runat="server" text="Label"></asp:label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:literal id="LitSampel" runat="server"></asp:literal>
                            </b>
                            <asp:label id="txtTotalSample" runat="server" text="Label"></asp:label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:literal id="LitHarga" runat="server"></asp:literal>
                            </b>
                            <asp:label id="txtTotalHarga" runat="server" text="Label"></asp:label>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <asp:gridview cssclass="table table-bordered table-hover" id="GvParameter" runat="server" autogeneratecolumns="false">
                    <Columns>
                        <asp:BoundField DataField="elementCode" HeaderText="Parameter Uji" />

                    </Columns>
                </asp:gridview>
            </div>
            <div class="col-lg-4">
                <div class="card">

                    <div class="card-body" style="background-color: lightgray;">
                        <h5 class="card-title">
                            <asp:literal id="litStatusPembayaran" runat="server"></asp:literal>
                        </h5>
                        <p class="card-text">
                            <asp:dropdownlist id="StatusPembayaranCmb" runat="server" cssclass="form-control"></asp:dropdownlist>
                        </p>
                    </div>
                </div>
                <div class="card">

                    <div class="card-body" style="background-color: lightgray;">
                        <h5 class="card-title">
                            <asp:literal id="litTipePembayaran" runat="server"></asp:literal>
                        </h5>
                        <p class="card-text">
                            <asp:dropdownlist id="TipePembayaranCmb" runat="server" cssclass="form-control"></asp:dropdownlist>
                        </p>
                    </div>
                </div>
                <div class="card">                    
                    <asp:button id="BtnGenerateInvoice" cssclass="btn btn-success" runat="server" text="Kirim Invoice" OnClick="BtnGenerateInvoice_Click"/>
                </div>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg">
                <h3>
                    <asp:literal id="litDaftarSampel" runat="server"></asp:literal>
                </h3>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg">
                <asp:gridview cssclass="table table-bordered table-hover dataTable" id="GvSample" runat="server" autogeneratecolumns="false" allowpaging="false">
                    <Columns>
                        <asp:BoundField DataField="countNumber" HeaderText="No Urut" />
                        <asp:BoundField DataField="sampleCode" HeaderText="No Sampel" />
                        <asp:BoundField DataField="noBalittanah" HeaderText="No Balittanah" />
                        <asp:BoundField DataField="village" HeaderText="Desa" />
                        <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                        <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                        <asp:BoundField DataField="province" HeaderText="Propinsi" />
                        <asp:TemplateField HeaderText="GPS">
                            <ItemTemplate>

                                <asp:Label ID="Loc" runat="server" Text='<%# Eval("latitude")+","+Eval("longitude") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                    </Columns>
                </asp:gridview>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg">
                <asp:button id="btnKembali" cssclass="btn btn-secondary" runat="server" text="Kembali" commandname="Kembali" onclick="ActionButton" />
                <asp:button id="btnSimpan" cssclass="btn btn-success" runat="server" text="Simpan" />
            </div>
        </div>
        
        <div class="row mt-2">
            <div class="col-lg">
                <rsweb:reportviewer id="reportViewer" Width="100%" runat="server">
              
                </rsweb:reportviewer>
            </div>
        </div>       
        <script>
            //function notifyMe() {
            //    if (Notification.permission !== 'granted')
            //        Notification.requestPermission();
            //    else {
            //        var notification = new Notification('Notifikasi untuk anda', {
            //            icon: 'http://cdn.sstatic.net/stackexchange/img/logos/so/so-icon.png',
            //            body: 'Status pembayaran sudah berhasil diubah!',
            //        });
            //    }
            //}
            function fixGridView(tableEl) {
                var jTbl = $(tableEl);

                if (jTbl.find("tbody>tr>th").length > 0) {
                    jTbl.find("tbody").before("<thead><tr></tr></thead>");
                    jTbl.find("thead tr").append(jTbl.find("th"));
                    jTbl.find("tbody tr:first").remove();
                }
            }

            //document.addEventListener('DOMContentLoaded', function () {
            //    if (!Notification) {
            //        alert('Push notification tidak tersedia pada browser ini.');
            //        return;
            //    }

            //    if (Notification.permission !== 'granted')
            //        Notification.requestPermission();
            //});

            $(document).ready(function () {
                //sample
                fixGridView($("#<%=GvSample.ClientID%>"));

                $('#<%=GvSample.ClientID%>').DataTable();
                //parameter
                fixGridView($("#<%=GvParameter.ClientID%>"));

                $('#<%=GvParameter.ClientID%>').DataTable();

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

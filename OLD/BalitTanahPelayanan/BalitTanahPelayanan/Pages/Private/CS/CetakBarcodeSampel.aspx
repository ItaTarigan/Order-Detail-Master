<%@ Page Title="Customer Service" Language="C#" MasterPageFile="~/Pages/Master/CS.Master" AutoEventWireup="true" CodeBehind="CetakBarcodeSampel.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.CS.CetakBarcodeSampel" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="False" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="countNumber" HeaderText="No Urut" />
                        <asp:BoundField DataField="sampleCode" HeaderText="No Sample" />
                        <asp:BoundField DataField="noBalittanah" HeaderText="No Balittanah" />
                        <asp:BoundField DataField="village" HeaderText="Desa" />
                        <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                        <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                        <asp:BoundField DataField="province" HeaderText="Propinsi" />
                         <asp:TemplateField HeaderText="GPS">
                            <ItemTemplate>

                                <asp:Label ID="Loc" runat="server" Text='<%# Eval("latitude")+","+Eval("longitude") %>'>Parameter Uji</asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                        <asp:BoundField DataField="isReceived" HeaderText="Sample Diterima" />

                        <asp:TemplateField HeaderText="Jumlah Cetak">
                            <ItemTemplate>
                                <asp:TextBox ID="TxtJml" TextMode="Number" Text="1" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Printer">
                            <ItemTemplate>
                                <asp:DropDownList ID="CmbPrinter" class="form-control" placeholder="Pilih Printer" runat="server" >
                                    <asp:ListItem Selected="True" Text="All" Value="All"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="Printer1" Value="Printer1"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="Printer2" Value="Printer2"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="Printer3" Value="Printer3"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
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
        
        <div class="row mt-2">
            <div class="col-lg">
                <asp:Button ID="BtnKembali" CssClass="btn btn-info" runat="server" Text="Kembali" />
                <asp:Button ID="BtnCetak" CssClass="btn btn-success" runat="server" Text="Lihat" />
                <asp:Button ID="BtnCetak2" CssClass="btn btn-success" runat="server" Text="Cetak" />
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg">
                <rsweb:reportviewer id="reportViewer" Width="100%" runat="server">
              
                </rsweb:reportviewer>
            </div>
        </div>
    </div>
</asp:Content>

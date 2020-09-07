<%@ Page Title="Cetak Invoice" Language="C#" MasterPageFile="~/Pages/Master/Kasir.Master" AutoEventWireup="true" CodeBehind="CetakInvoice.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Kasir.CetakInvoice" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row mt-2">
        <div class="col-lg">
            <rsweb:ReportViewer ID="reportViewer" Width="100%" runat="server">
            </rsweb:ReportViewer>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
            <asp:Button ID="BtnKembali" CssClass="btn btn-info" runat="server" Text="Kembali" />
        </div>
    </div>
    

</asp:Content>

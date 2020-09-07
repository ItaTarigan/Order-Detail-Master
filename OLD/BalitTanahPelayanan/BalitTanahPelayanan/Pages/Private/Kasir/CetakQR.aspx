<%@ Page Title="Kasir - Cetak QR" Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Master/Kasir.Master" CodeBehind="CetakQR.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Kasir.CetakQR" %>

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

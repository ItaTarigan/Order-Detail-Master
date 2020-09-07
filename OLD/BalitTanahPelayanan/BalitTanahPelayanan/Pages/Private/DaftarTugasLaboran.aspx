<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Master/Board.Master" CodeBehind="DaftarTugasLaboran.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.DaftarTugasLaboran" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelGrid" runat="server" HorizontalAlign="center">
                <h3>Daftar Tugas Laboran</h3>
                <div class="form-group">
                    <asp:Label runat="server">Pesanan Diproses : </asp:Label>
                    <asp:Label runat="server" ID="lblProcessed"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label runat="server">Pesanan Selesai : </asp:Label>
                    <asp:Label runat="server" ID="lblDone"></asp:Label>
                    <asp:Button runat="server" ID="btntes" />
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
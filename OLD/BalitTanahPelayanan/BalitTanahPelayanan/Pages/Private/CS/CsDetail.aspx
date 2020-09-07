<%@ Page Title="Pelayanan Pelanggan" Language="C#" MasterPageFile="~/Pages/Master/SinglePage.Master" AutoEventWireup="true" CodeBehind="CsDetail.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.CS.CsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="MainPanel" runat="server">
                    <div class="row">
                        <h3>Detail Pesanan</h3>
                    </div>
                    <p>
                        <asp:Label runat="server">Detail No Order :</asp:Label>
                        <asp:Label runat="server" ID="lblOrdt"></asp:Label><br />
                        <asp:Label runat="server">Nama Pelanggan</asp:Label>
                        <asp:Label runat="server" ID="lblCust"></asp:Label><br />
                        <asp:Label runat="server">Komoditas</asp:Label>
                        <asp:Label runat="server" ID="lblComo"></asp:Label><br />
                        <asp:Label runat="server">Tipe Analisis</asp:Label>
                        <asp:Label runat="server" ID="lbltype"></asp:Label><br />
                        <asp:Label runat="server">Total Sample</asp:Label>
                        <asp:Label runat="server" ID="lblSample"></asp:Label><br />
                        <asp:Label runat="server">Total Harga</asp:Label>
                        <asp:Label runat="server" ID="lblHarga"></asp:Label>
                    </p>
                    </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Panel ID="SecondPanel" runat="server">
                    <asp:GridView runat="server" ID="GvSampleList">

                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

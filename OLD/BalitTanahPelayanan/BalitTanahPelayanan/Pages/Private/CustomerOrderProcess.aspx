<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="CustomerOrderProcess.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.CustomerOrderProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnOrderMasuk" runat="server" Text="Order Masuk"></asp:Button>
                <asp:Button ID="btnOrderDiproses" runat="server" Text="Order Diproses"></asp:Button>
                <asp:Button ID="btnOrderSelesai" runat="server" Text="Order Selesai"></asp:Button>
                <asp:Panel ID="PanelGrid" runat="server">
                    <div>
                        <label for="search">Filter no pesanan:</label>
                        <asp:TextBox runat="server" ID="txtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                        <asp:ImageButton runat="server" ID="btnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                        <asp:ImageButton runat="server" ID="btnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
                    </div>
                    <asp:GridView CssClass="table table-bordered table-hover dataTable" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                        <Columns>
                            <asp:BoundField DataField="orderNo" HeaderText="No Pesanan" />
                            <asp:BoundField DataField="customertbl.customerName" HeaderText="Nama Pelanggan" />
                            <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditi" />
                            <asp:BoundField DataField="analysisType" HeaderText="Tipe Analisis" />
                            <%--<asp:BoundField DataField="sampletbl.orderanalysisdetailtbl.isReceived" HeaderText="Sample Diterima" />--%>
                            <asp:BoundField DataField="paymentType" HeaderText="Tipe Pembayaran" />
                            <asp:BoundField DataField="status" HeaderText="Status Pesanan" />
                            <asp:BoundField DataField="isPayed" HeaderText="Status Pembayaran" />
                            <asp:TemplateField HeaderText="Aksi">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:LinkButton  ID="Detail" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="detailorder" Text="Detail"><i class='fa fa-eye'></i> Detail</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>                        
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerOrderDiproses.aspx.cs" MasterPageFile="~/Pages/Master/Main.Master" Inherits="BalitTanahPelayanan.Pages.Private.CustomerOrderDiproses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <ContentTemplate>
                <asp:Button ID="btnOrderMasuk" runat="server" Text="Order Masuk"></asp:Button>
                <asp:Button ID="btnOrderDiproses" runat="server" Text="Order Diproses"></asp:Button>
                <asp:Button ID="btnOrderSelesai" runat="server" Text="Order Selesai"></asp:Button></br>
                <h4><asp:Label ID="lblOrderDiproses" runat="server" Text="Order Diproses"></asp:Label></h4>
                <asp:Panel ID="PanelGrid" runat="server">
                    <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                        <Columns>
                            <asp:BoundField DataField="orderNo" HeaderText="No Order" />
                            <asp:BoundField DataField="customerName" HeaderText="Nama Customer" />
                            <asp:BoundField DataField="comodityName" HeaderText="Komoditi" />
                            <asp:BoundField DataField="analysisTypeName" HeaderText="Tipe Analisis" />
                            <asp:BoundField DataField="isAppr" HeaderText="Sample Diterima" />
                            <asp:BoundField DataField="isPayed" HeaderText="Sudah di Bayar" />
                            <asp:BoundField DataField="paymentType" HeaderText="Tipe Pembayaran" />
                            <asp:TemplateField HeaderText="Aksi">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:LinkButton  ID="Detail" ForeColor="Blue" runat="server" CommandArgument='<%# Eval("orderDetailNo") %>' CommandName="detail" Text="Detail"><i class='fa fa-edit'></i>Detail</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>                        
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
</asp:Content>


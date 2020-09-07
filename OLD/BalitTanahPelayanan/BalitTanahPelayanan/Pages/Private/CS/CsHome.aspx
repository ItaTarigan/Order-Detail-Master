<%@ Page Title="Pelayanan Pelanggan" Language="C#" MasterPageFile="~/Pages/Master/CS.Master" AutoEventWireup="true" CodeFile="CsHome.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.CS.CsHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <strong><label style="text-align:start">Pesanan Masuk</label></strong>
    <br />
        <div style="margin-bottom:15px">
            <label for="search">Filter No Order</label>
                <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                    <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
            <label>Tipe Analisis</label>
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                    <asp:ListItem>Pilih</asp:ListItem>
                        <asp:ListItem>asd</asp:ListItem>
                    <asp:ListItem>qwe</asp:ListItem>
                </asp:DropDownList>
            </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>                   
            <asp:Panel ID="PanelGridMasuk" runat="server" HorizontalAlign="Center">                
                <asp:GridView runat="server" CssClass="table table-bordered table-hover" ID="GvIn"  AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="No. Order" />
                        <asp:BoundField DataField="customertbl.customerName" HeaderText="Nama Pelanggan" />
                        <asp:BoundField DataField="comoditytbl.comodityName" HeaderText="Komoditas" />
                        <asp:BoundField DataField="analysisType" HeaderText="Tipe Analisis" />
                        <asp:BoundField DataField="isOnLab" HeaderText="Sample Diterima" />
                        <asp:BoundField DataField="paymentType" HeaderText="Tipe Pembayaran" />
                        <asp:BoundField DataField="status" HeaderText="Status Pesanan" />
                        <asp:BoundField DataField="isPayed" HeaderText="Status Pembayaran" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton  ID="btnSample" ForeColor="#3399ff" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="ubah" Text="Penerimaan Sample"></asp:LinkButton>
                                <asp:LinkButton  ID="btnProses2lab" ForeColor="#00ffcc" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="ubah" Text="Proses ke Lab"></asp:LinkButton>
                                <asp:LinkButton  ID="btnPrint" ForeColor="#66ff33" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="ubah" Text="Print"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>    
</asp:Content>
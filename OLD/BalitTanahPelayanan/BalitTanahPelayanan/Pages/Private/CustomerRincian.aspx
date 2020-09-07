<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="CustomerRincian.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.CustomerRincian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <%--<h3><asp:Button ID="BtnOrderList" OnClick="BtnOrderList_Click" runat="server" Text="Order List" /></h3>
    <h3><asp:Button ID="BtnOrderSelesai" OnClick="BtnOrderSelesai_Click" runat="server" Text="Order Selesai" /></h3>--%>
    <asp:Panel ID="Panel1" runat="server">
        <%--<div class="form-group">
            <label for="Rincian no pesanan"><h2>Rincian No Pesanan</h2></label>
            <asp:TextBox ID="txtNoPesanan" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <label for="komoditas">Komoditas</label>
            <asp:TextBox ID="txtKomoditas" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <label for="tipeanalisis">Tipe Analisis</label>
            <asp:TextBox ID="txtTipeAnalisis" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <label for="totalsampel">Total Sampel</label>
            <asp:TextBox ID="txtTotalSampel" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <label for="totalharga">Total Harga</label>
            <asp:TextBox ID="txtTotalHarga" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <label for="status">Status</label>
            <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>--%>
        <div class="card">
                    <b>
                        <h2>
                            <label for="">Rincian No Pesanan : </label>
                            <asp:Label ID="txtNoPesanan" runat="server" Text="Label"></asp:Label>
                        </h2>
                    </b>
                    <div class="card-body" style="background-color: lightgray;">
                        <p class="card-text">
                            <b>
                                <label for="">Komoditas : </label>
                            </b>
                            <asp:Label ID="txtKomoditas" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <label for="">Tipe Analisis : </label>
                            </b>
                            <asp:Label ID="txtTipeAnalisis" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <label for="">Total Sample : </label>
                            </b>
                            <asp:Label ID="txtTotalSample" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <label for="">Total Harga : </label>
                            </b>
                            <asp:Label ID="txtTotalHarga" runat="server" Text="Label"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <label for="">Status : </label>
                            </b>
                            <asp:Label ID="txtStatus" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </div>
    </asp:Panel>

    <asp:Panel ID="PanelGrid" runat="server">
        <h2>Daftar Sampel</h2>
                <asp:GridView CssClass="table table-bordered table-hover dataTable" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="No Sampel" />
                        <asp:BoundField DataField="noBalittanah" HeaderText="No Balitanah" />
                        <asp:BoundField DataField="village" HeaderText="Desa" />
                        <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                        <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                        <asp:BoundField DataField="province" HeaderText="Provinsi" />
                        <asp:BoundField DataField="longitude" HeaderText="Koordinat GPS" />
                        <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                        <asp:BoundField DataField="isReceived" HeaderText="Sampel Diterima" />
                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="lihatOrderList" Text="Lihat"><i class='fa fa-eye'></i>Lihat Daftar Servis</asp:LinkButton>
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
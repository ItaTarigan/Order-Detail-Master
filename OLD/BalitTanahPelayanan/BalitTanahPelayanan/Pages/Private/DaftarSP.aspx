<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="DaftarSP.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.DaftarSP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelGrid" runat="server">
                 <div>
                    <label for="search">Cari DaftarSP :</label>
                    <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                    <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
                </div>
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong" OnRowCommand="GvData_RowCommand1">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="Nomor Order" />
                        <asp:BoundField DataField="customerNo" HeaderText="Nomor Customer" />
                        <asp:BoundField DataField="ComodityNo" HeaderText="Nomor Komoditas" />
                        <asp:BoundField DataField="sampleTotal" HeaderText="Total Sample" />
                        <asp:BoundField DataField="priceTotal" HeaderText="Total Harga" />
                        <asp:BoundField DataField="status" HeaderText="Status" />
                        <asp:BoundField DataField="paymentType" HeaderText="Type Pembayaran" />
                        <asp:BoundField DataField="isPayed" HeaderText="Sudah Dibayar" />
                        <asp:BoundField DataField="isPayedDate" HeaderText="Tanggal Dibayarkan" />
                        <asp:BoundField DataField="isAppr" HeaderText="Diterima" />
                        <asp:BoundField DataField="pic" HeaderText="PIC" />
                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="ubah" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="lihat" Text="Lihat"><i class='fa fa-eye'></i></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton  OnClientClick="return confirm('Apakah yakin ingin menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
                <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Add Record" CommandName="add" OnClick="ActionButton"/>
            </asp:Panel>
            <asp:Panel ID="PanelInput" Visible="false" runat="server">
                <div class="form-group">
                    <label for="orderNo">Nomor Order :</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtOrderNo" TextMode="SingleLine" CssClass="form-control" name="orderNo"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtOrderNo" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silakan isi Order No."></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="customerNo">Nomor Customer :</label>
                    <asp:DropDownList ID="DDLCustomerno" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="comodityNo">Nomor Komoditas :</label>
                    <asp:DropDownList ID="DDLComodityNo" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="sampleTotal">Total Sample :</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtTotalSample" TextMode="SingleLine" CssClass="form-control" name="sampleTotal"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtTotalSample" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silakan isi Total Sample"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="priceTotal">Total Harga :</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtPriceTotal" TextMode="SingleLine" CssClass="form-control" name="priceTotal"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtPriceTotal" ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Silakan isi Total Harga"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="status">Status :</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtStatus" TextMode="SingleLine" CssClass="form-control" name="status"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtStatus" ValidationGroup="vg1" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Silakan isi Status"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="paymentType">Tipe Payment :</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtTipePayment" TextMode="SingleLine" CssClass="form-control" name="paymentType"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtTipePayment" ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Silakan isi Tipe Payment"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="isPayed">Sudah Dibayar :</label>
                    <asp:DropDownList ID="DDLPayed" CssClass="form-control" runat="server">
                        <asp:ListItem>Sudah</asp:ListItem>
                        <asp:ListItem>Belum</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="isPayedDate">Tanggal Dibayarkan :</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtPayedDate" TextMode="SingleLine" CssClass="form-control" name="isPayedDate"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtPayedDate" ValidationGroup="vg1" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Silakan isi Tanggal Dibayarkan"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="isAppr">Diterima :</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtAppr" TextMode="SingleLine" CssClass="form-control" name="isAppr"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtAppr" ValidationGroup="vg1" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Silakan isi Diterima"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="pic">PIC :</label>
                    <asp:DropDownList ID="DDLPIC" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <asp:Button ID="BtnSave" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" CommandName="save" Text="Save" OnClick="ActionButton" />
                <asp:Button ID="BtnUpdate" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" CommandName="update" Text="Update" OnClick="ActionButton" />
                <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" CommandName="cancel" Text="Cancel" OnClick="ActionButton" />
                <asp:ValidationSummary ValidationGroup="vg1" ShowSummary="false" ShowMessageBox="false" ID="ValidationSummary1" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel ID="PanelGrid" runat="server">
        <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("customerNo") %>' CommandName="Ubah" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("customerNo") %>' CommandName="Lihat" Text="Lihat"><i class='fa fa-eye'></i></asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton  OnClientClick="return confirm('Yakin mau menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("customerNo") %>' CommandName="Hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton></td>
                            </tr>
                        </table>



                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button CssClass="btn btn-success" ID="BtnAdd2" runat="server" Text="Add Record" />
    </asp:Panel>
    <asp:Panel ID="PanelInput" Visible="false" runat="server">
        <h3>Registrasi</h3>
        <asp:HiddenField ID="TxtID" runat="server" />
        <%--<div class="form-group">
            <label for="employeeno">Employee No:</label>
            <asp:TextBox runat="server" ReadOnly="false" ID="TxtEmployeeNo" placeholder="Contoh : 'M001'" TextMode="SingleLine" CssClass="form-control" name="employeeno"></asp:TextBox>
        </div>--%>
        <div class="form-group">
            <label for="lblNama">Name :</label>
            <asp:TextBox runat="server" ValidationGroup="vg1" ID="txtNama" TextMode="SingleLine" CssClass="form-control" name="lblNama"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtNama" ValidationGroup="vg1" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Silakan isi name"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="lblPerusahaan">Perusahaan :</label>
            <asp:TextBox runat="server" ID="txtPerusahaan" TextMode="SingleLine" CssClass="form-control" name="lblPerusahaan"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtPerusahaan" ValidationGroup="vg1" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Silakan isi Perusahaan"></asp:RequiredFieldValidator>
        </div>        
        <div class="form-group">
            <label for="lblAlamat">Alamat :</label>
            <asp:TextBox runat="server" ID="txtAlamat" TextMode="SingleLine" CssClass="form-control" name="lblPerusahaan"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtAlamat" ValidationGroup="vg1" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Silakan isi Alamat"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="lblNoTelepon">No Telepon :</label>
            <asp:TextBox runat="server" ID="txtNoTelepon" TextMode="SingleLine" CssClass="form-control" name="lblNoTelepon"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtNoTelepon" ValidationGroup="vg1" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Silakan isi phone"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="lblEmail">Email :</label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" name="lblEmail"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtEmail" ValidationGroup="vg1" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Silakan isi Email"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Masukan email dengan benar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label for="lblCompanyEmail">Company Email :</label>
            <asp:TextBox runat="server" ID="txtCompanyEmail" CssClass="form-control" name="lblCompanyEmail"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtCompanyEmail" ValidationGroup="vg1" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Silakan isi latitude"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="lblPassword">Password :</label>
            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" Type="password" name="lblPassword"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtPassword" ValidationGroup="vg1" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Silakan isi latitude"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="BtnSubmit" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Save"/>
        <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" />
        <asp:Label ID="TxtStatus" ForeColor="Red" runat="server" Text=""></asp:Label>
        <asp:ValidationSummary ValidationGroup="vg1" ShowSummary="false" ShowMessageBox="false" ID="ValidationSummary1" runat="server" />
    </asp:Panel>

    <script>
        $(document).ready(function () {
            $('#<%= GvData.ClientID %>').DataTable();
        });
    </script>

</asp:Content>
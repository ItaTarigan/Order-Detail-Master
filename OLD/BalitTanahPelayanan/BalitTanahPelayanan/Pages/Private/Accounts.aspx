<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Accounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelGrid" runat="server">
                <div>
                    <label for="search">Cari Akun:</label>
                    <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                    <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
                </div>
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="AccountNo" HeaderText="No" />
                        <asp:BoundField DataField="username" HeaderText="Nama user" />
                        <asp:BoundField DataField="password" HeaderText="Kata sandi" />
                        <asp:BoundField DataField="roleName" HeaderText="Hak Akses" />
                        <asp:BoundField DataField="isEmailVerified" HeaderText="Verifikasi Email" />
                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("AccountNo") %>' CommandName="ubah" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("AccountNo") %>' CommandName="lihat" Text="Lihat"><i class='fa fa-eye'></i></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton  OnClientClick="return confirm('Apakah yakin ingin menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("AccountNo") %>' CommandName="hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
                <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Tambah Data" CommandName="add" OnClick="ActionButton" />
            </asp:Panel>
            <asp:Panel ID="PanelInput" Visible="false" runat="server">
                <div class="form-group">
                    <label>Akun No:</label>
                    <asp:Label ID="TxtAccountNo" runat="server" Visible="true" Text="Otomatis"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="username">Nama Pengguna:</label>
                    <asp:TextBox runat="server" ID="TxtUsername" TextMode="SingleLine" CssClass="form-control" name="username" onkeypress="return RestrictSpace()"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtUsername" ValidationGroup="vg1" ID="TxtUsernameValidator" runat="server" ErrorMessage="Silahkan isi nama user"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="password">Kata Sandi:</label>
                    <asp:TextBox runat="server" ID="TxtPassword" TextMode="SingleLine" CssClass="form-control" name="password"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtPassword" ValidationGroup="vg1" ID="TxtPasswordValidator" runat="server" ErrorMessage="Silahkan isi kata sandi"></asp:RequiredFieldValidator>
                </div>                
                <div class="form-group">
                    <label for="rolename">Hak Akses:</label>
                    <asp:DropDownList runat="server" ID="TxtRoleName" CssClass="form-control" name="rolename" AppendDataBoundItems="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="TxtRoleName" ValidationGroup="vg1" ID="TxtRoleNameValidator" runat="server" ErrorMessage="Silahkan isi hak akses"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="emailverified">Verifikasi email:</label>
                    <asp:TextBox runat="server" ID="TxtEmailVerified" TextMode="SingleLine" CssClass="form-control" name="emailverified" ReadOnly="true"></asp:TextBox>
                </div> 
                <asp:Button ID="BtnSave" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Simpan" CommandName="save" OnClick="ActionButton"/>
                <asp:Button ID="BtnUpdate" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Ubah" CommandName="update" OnClick="ActionButton"/>
                <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Kembali" CommandName="cancel" OnClick="ActionButton"/>
                <asp:ValidationSummary ValidationGroup="vg1" ShowSummary="false" ShowMessageBox="false" ID="ValidationSummary1" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/assets/img/ajax-loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <script>
        $(document).ready(function () {
            $('#<%= GvData.ClientID %>').DataTable();
        });

        function RestrictSpace() {
            if (event.keyCode == 32) {
                event.returnValue = false;
                return false;
            }
        }
    </script>

</asp:Content>

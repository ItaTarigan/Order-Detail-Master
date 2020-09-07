<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelGrid" runat="server">
                 <div>
                    <label for="search">Cari Komoditas:</label>
                    <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                    <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
                </div>
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="employeeNo" HeaderText="No" />
                        <asp:BoundField DataField="employeeName" HeaderText="Nama Pegawai" />
                        <asp:BoundField DataField="position" HeaderText="Posisi" />
                        <asp:BoundField DataField="employeeEmail" HeaderText="Email" />
                        <asp:BoundField DataField="derivativeToEmployee" HeaderText="Bawahan Dari" />
                        <asp:BoundField DataField="accountNo" HeaderText="Nomor Akun" />
                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("employeeNo") %>' CommandName="ubah" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("employeeNo") %>' CommandName="lihat" Text="Lihat"><i class='fa fa-eye'></i></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton  OnClientClick="return confirm('Apakah yakin ingin menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("employeeNo") %>' CommandName="hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton>
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
                    <label >Nomor Pegawai:</label>
                    <asp:Label ID="TxtEmployeeNo" runat="server" Visible="true" Text="Otomatis"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="employeename">Nama Pegawai:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtEmployeeName" TextMode="SingleLine" CssClass="form-control" name="employeename"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtEmployeeName" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silahkan isi nama pegawai"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="position">Posisi:</label>
                    <asp:TextBox runat="server" ID="TxtPosition" TextMode="SingleLine" CssClass="form-control" name="position"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtPosition" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silahkan isi posisi"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="empemail">Email:</label>
                    <asp:TextBox runat="server" ID="TxtEmpEmail" TextMode="SingleLine" CssClass="form-control" name="empemail"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtEmpEmail" ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Silahkan isi email"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ErrorMessage="Invalid Email" ControlToValidate="TxtEmpEmail"
                        SetFocusOnError="True"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="dvemp">Penangung jawab pegawai:</label>
                    <asp:DropDownList runat="server" ID="TxtDerivativeEmp" CssClass="form-control" name="dvemp" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="accountno">Nomor Akun</label>
                    <asp:DropDownList runat="server" ID="TxtAccountNo" CssClass="form-control" name="accountno" AppendDataBoundItems="true"></asp:DropDownList>
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
    </script>

</asp:Content>

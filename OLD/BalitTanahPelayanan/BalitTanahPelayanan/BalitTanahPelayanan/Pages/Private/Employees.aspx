<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel ID="PanelGrid" runat="server">
        <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("employeeno") %>' CommandName="Ubah" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("employeeno") %>' CommandName="Lihat" Text="Lihat"><i class='fa fa-eye'></i></asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton  OnClientClick="return confirm('Yakin mau menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("employeeno") %>' CommandName="Hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton></td>
                            </tr>
                        </table>



                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Add Record" />
    </asp:Panel>
    <asp:Panel ID="PanelInput" Visible="false" runat="server">
        <asp:HiddenField ID="TxtID" runat="server" />
        <%--<div class="form-group">
            <label for="employeeno">Employee No:</label>
            <asp:TextBox runat="server" ReadOnly="false" ID="TxtEmployeeNo" placeholder="Contoh : 'M001'" TextMode="SingleLine" CssClass="form-control" name="employeeno"></asp:TextBox>
        </div>--%>
        <div class="form-group">
            <label for="employeename">Employee Name:</label>
            <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtEmployeeName" TextMode="SingleLine" CssClass="form-control" name="employeename"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtEmployeeName" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silakan isi Employee name"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="position">Position:</label>
            <asp:TextBox runat="server" ID="TxtPosition" TextMode="SingleLine" CssClass="form-control" name="position"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtPosition" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silakan isi position"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="empemail">Email:</label>
            <asp:TextBox runat="server" ID="TxtEmpEmail" TextMode="SingleLine" CssClass="form-control" name="empemail"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtEmpEmail" ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Silakan isi email"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="dvemp">Derivative To Employee:</label>
            <asp:TextBox runat="server" ID="Txtdvemp" TextMode="SingleLine" CssClass="form-control" name="dvemp"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="Txtdvemp" ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Silakan isi phone"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="accountno">Account No:</label>
            <asp:TextBox runat="server" ID="TxtAccountNo" CssClass="form-control" name="accountno"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtAccountNo" ValidationGroup="vg1" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Silakan isi latitude"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="BtnSubmit" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Save" />
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

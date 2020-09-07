<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="ElementServices.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.ElementServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel ID="PanelGrid" runat="server">
        <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("elementCode") %>' CommandName="Ubah" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("elementCode") %>' CommandName="Lihat" Text="Lihat"><i class='fa fa-eye'></i></asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton  OnClientClick="return confirm('Yakin mau menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("elementCode") %>' CommandName="Hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Add Record" />
    </asp:Panel>
    <asp:Panel ID="PanelInput" Visible="false" runat="server">
        <%--<asp:HiddenField ID="TxtID" runat="server" />--%>
        <%--<div class="form-group">
            <label for="comodityNo">Employee No:</label>
            <asp:TextBox runat="server" ReadOnly="false" ID="TxtcomodityNo" placeholder="Contoh : 'M001'" TextMode="SingleLine" CssClass="form-control" name="comodityNo"></asp:TextBox>
        </div>--%>
        <div class="form-group">
            <label for="elementcode">Element Code:</label>
            <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtElementCode" TextMode="SingleLine" CssClass="form-control" name="elementcode"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtElementCode" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silakan isi element code"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="analysis">Analysis Type Name:</label>
            <%--<asp:TextBox runat="server" ID="TxtDerivative" TextMode="SingleLine" CssClass="form-control" name="derivative"></asp:TextBox>--%>
            <asp:DropDownList ID="AnaylysisName" CssClass="form-control" runat="server" ></asp:DropDownList>
            <asp:RequiredFieldValidator ControlToValidate="AnaylysisName" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silakan isi analysis type name"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="svcgroup">Service Group:</label>
            <asp:TextBox runat="server" ID="TxtServiceGroup" TextMode="SingleLine" CssClass="form-control" name="svcgroup"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtServiceGroup" ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Silakan isi service group"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="svcrate">Service Rate:</label>
            <asp:TextBox runat="server" ID="TxtServiceRate" TextMode="Number" CssClass="form-control" name="svcrate"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtServiceRate" ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Silakan isi service rate"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="svcstatus">Service Status:</label>
            <asp:TextBox runat="server" ID="TxtServiceStatus" TextMode="SingleLine" CssClass="form-control" name="svcstatus"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtServiceStatus" ValidationGroup="vg1" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Silakan isi service status"></asp:RequiredFieldValidator>
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

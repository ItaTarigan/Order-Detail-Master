﻿<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="Comodities.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Comodities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel ID="PanelGrid" runat="server">
        <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("comodityNo") %>' CommandName="Ubah" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("comodityNo") %>' CommandName="Lihat" Text="Lihat"><i class='fa fa-eye'></i></asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton  OnClientClick="return confirm('Yakin mau menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("comodityNo") %>' CommandName="Hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton></td>
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
            <label for="comodityNo">Employee No:</label>
            <asp:TextBox runat="server" ReadOnly="false" ID="TxtcomodityNo" placeholder="Contoh : 'M001'" TextMode="SingleLine" CssClass="form-control" name="comodityNo"></asp:TextBox>
        </div>--%>
        <div class="form-group">
            <label for="comodityname">Comodity Name:</label>
            <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtComodityName" TextMode="SingleLine" CssClass="form-control" name="comodityname"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtComodityName" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silakan isi comodity name"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="derivative">Derivative To:</label>
            <%--<asp:TextBox runat="server" ID="TxtDerivative" TextMode="SingleLine" CssClass="form-control" name="derivative"></asp:TextBox>--%>
            <asp:DropDownList ID="DDDerivative" CssClass="form-control" runat="server" ></asp:DropDownList>
            <asp:RequiredFieldValidator ControlToValidate="DDDerivative" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silakan isi derivative to"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="desc">Description:</label>
            <asp:TextBox runat="server" ID="TxtDescription" TextMode="SingleLine" CssClass="form-control" name="desc"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="TxtDescription" ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Silakan isi Description"></asp:RequiredFieldValidator>
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

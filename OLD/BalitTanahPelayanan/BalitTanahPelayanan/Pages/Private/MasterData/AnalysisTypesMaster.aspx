<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Admin.Master" AutoEventWireup="true" CodeBehind="AnalysisTypesMaster.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.MasterData.AnalysisTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../../../assets/js/scripts.js" />
    <link rel="stylesheet" href="../../../assets/css/fonts.css">
    <link rel="stylesheet" href="../../../assets/css/styles.css">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelGrid" runat="server">
                <%--<div>
                    <label for="search">Cari Analisis:</label>
                    <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton" />
                    <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton" />
                </div>--%>
                <asp:GridView CssClass="table table-bordered dataTable no-footer" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="analysisTypeName" HeaderText="Analisis Tipe" />
                        <asp:BoundField DataField="description" HeaderText="Deskripsi" />
                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("analysisTypeName") %>' CommandName="ubah" Text="Ubah"></asp:LinkButton>
                                <asp:LinkButton ID="btnLihat" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("analysisTypeName") %>' CommandName="lihat" Text="Lihat"></asp:LinkButton>
                                <asp:LinkButton ID="btnHapus" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("analysisTypename") %>' CommandName="hapus" Text="Hapus" OnClientClick="return confirm('Apakah anda yakin ingin menghapus?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Tambah Data" CommandName="add" OnClick="ActionButton" />
            </asp:Panel>
            <asp:Panel ID="PanelInput" Visible="false" runat="server">
                <div class="form-group">
                    <label for="analysisname">Analisis Tipe:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtAnalysisTypeName" TextMode="SingleLine" CssClass="form-control" name="analysisname"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtAnalysisTypeName" ValidationGroup="vg1" ID="TxtAnalysisTypeNameValidator" runat="server" ErrorMessage="Silahkan isi tipe analisis"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="desc">Deskripsi:</label>
                    <asp:TextBox runat="server" ID="TxtDescription" TextMode="SingleLine" CssClass="form-control" name="desc"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtDescription" ValidationGroup="vg1" ID="TxtDescriptionValidator" runat="server" ErrorMessage="Silahkan isi deskripsi"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="BtnSave" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Simpan" CommandName="save" OnClick="ActionButton" />
                <asp:Button ID="BtnUpdate" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Ubah" CommandName="update" OnClick="ActionButton" />
                <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Kembali" CommandName="cancel" OnClick="ActionButton" />
                <asp:ValidationSummary ValidationGroup="vg1" ShowSummary="false" ShowMessageBox="false" ID="ValidationSummary1" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/assets/img/ajax-loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <script>
        function fixGridView(tableEl) {
            var jTbl = $(tableEl);

            if (jTbl.find("tbody>tr>th").length > 0) {
                jTbl.find("tbody").before("<thead><tr></tr></thead>");
                jTbl.find("thead tr").append(jTbl.find("th"));
                jTbl.find("tbody tr:first").remove();
            }
        }
        $(document).ready(function () {
            fixGridView($("#<%=GvData.ClientID%>"));
            $('#<%=GvData.ClientID%>').DataTable();

            $('#linkincrease').click(function () {
                $('#divContent').css('font-size', '+=3');
            });

            $('#linkdecrease').click(function () {
                $('#divContent').css('font-size', '-=3');
            });
        });
    </script>

</asp:Content>

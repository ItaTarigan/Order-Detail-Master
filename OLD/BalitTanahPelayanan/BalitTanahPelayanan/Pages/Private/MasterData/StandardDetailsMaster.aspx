<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Admin.Master" AutoEventWireup="true" CodeBehind="StandardDetailsMaster.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.MasterData.StandardDetails" %>

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
                    <label for="search">Cari Standar:</label>
                    <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                    <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
                </div>--%>
                <div class="row mt-2" id="DivRow3" runat="server">
                    <div class="col-lg">
                        <asp:GridView CssClass="table table-bordered table-hover dataTable" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                            <Columns>
                                <asp:BoundField DataField="stdDetailId" HeaderText="Kode Detail" />
                                <asp:BoundField DataField="stdId" HeaderText="Kode Standar" />
                                <asp:BoundField DataField="elementCode" HeaderText="Kode Layanan" />
                                <asp:TemplateField HeaderText="Aksi">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("stdDetailId") %>' CommandName="ubah" Text="Ubah"></asp:LinkButton>
                                        <asp:LinkButton ID="btnLihat" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("stdDetailId") %>' CommandName="lihat" Text="Lihat"></asp:LinkButton>
                                        <asp:LinkButton ID="btnHapus" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("stdDetailId") %>' CommandName="hapus" Text="Hapus" OnClientClick="return confirm('Apakah anda yakin ingin menghapus?');"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Tambah Data" CommandName="add" OnClick="ActionButton" />
            </asp:Panel>
            <asp:Panel ID="PanelInput" Visible="false" runat="server">
                <div class="form-group">
                    <label>Kode Detail:</label>
                    <asp:Label ID="TxtStdDetailId" runat="server" Visible="true" Text="Otomatis"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="stdid">Nomor Standar:</label>
                    <asp:DropDownList runat="server" ID="TxtStdId" CssClass="form-control" name="stdid" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="elementcode">Kode Layanan:</label>
                    <asp:DropDownList runat="server" ID="TxtElementCode" CssClass="form-control" name="elementcode" AppendDataBoundItems="true"></asp:DropDownList>
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
                $('body').css('font-size', '+=3');
            });

            $('#linkdecrease').click(function () {
                $('body').css('font-size', '-=3');
            });
        });
    </script>

</asp:Content>

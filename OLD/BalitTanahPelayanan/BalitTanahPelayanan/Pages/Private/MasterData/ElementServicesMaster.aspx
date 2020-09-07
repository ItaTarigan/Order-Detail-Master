<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Admin.Master" AutoEventWireup="true" CodeBehind="ElementServicesMaster.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.MasterData.ElementServices" %>

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
                <%--<div class="row mt-2">  
                    <div class="col-6">
                        <div class="row">
                            <div class="col-6">
                                <h3>Cari Elemen Service:</h3>
                                <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <asp:ImageButton runat="server" ID="BtnSearch" CssClass="btn btn-light btn-sm" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                                <asp:ImageButton runat="server" ID="BtnRefresh" CssClass="btn btn-light btn-sm" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
                            </div>
                        </div>
                    </div>
                </div>--%>
                <div class="row mt-2" id="DivRow3" runat="server">
                    <div class="col-lg">
                        <asp:GridView CssClass="table table-bordered table-hover dataTable no-footer" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                            <Columns>
                                <asp:BoundField DataField="elementId" HeaderText="Id Layanan" />
                                <asp:BoundField DataField="elementCode" HeaderText="Nama Layanan" />
                                <asp:BoundField DataField="analysisTypeName" HeaderText="Analisis Tipe" />
                                <asp:BoundField DataField="serviceGroup" HeaderText="Grup Layanan" />
                                <asp:BoundField DataField="serviceRate" DataFormatString="{0:C}" HeaderText="Harga" />
                                <asp:BoundField DataField="serviceStatus" HeaderText="Status" />
                                <asp:TemplateField HeaderText="Aksi">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("elementCode") %>' CommandName="ubah" Text="Ubah"></asp:LinkButton>
                                        <asp:LinkButton ID="btnLihat" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("elementCode") %>' CommandName="lihat" Text="Lihat"></asp:LinkButton>
                                        <asp:LinkButton ID="btnHapus" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("elementCode") %>' CommandName="hapus" Text="Hapus" OnClientClick="return confirm('Apakah anda yakin ingin menghapus?');"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Tambah Data" CommandName="add" OnClick="ActionButton" />
            </asp:Panel>
            <asp:Panel ID="PanelInput" Visible="false" runat="server">
                <div class="row mt-2">
                    <div class="col-6">
                        <div class="form-group">
                            <label for="id">Id Layanan:</label>
                            <asp:TextBox runat="server" ID="Id" TextMode="SingleLine" CssClass="form-control" name="id" ReadOnly="true" Text="Otomatis"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="elementcode">Nama Layanan:</label>
                            <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtElementCode" TextMode="SingleLine" CssClass="form-control" name="elementcode"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="TxtElementCode" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silahkan isi Layanan"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="comodityno">No Komoditas:</label>
                            <asp:DropDownList runat="server" ID="TxtComodity" CssClass="form-control" name="comodityNo" AppendDataBoundItems="true"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="analysistypename">Analisis Tipe:</label>
                            <asp:DropDownList runat="server" ID="TxtAnalysisTypeName" CssClass="form-control" name="analysisTypeName" AppendDataBoundItems="true"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="valueunit">Satuan:</label>
                            <asp:TextBox runat="server" ID="TxtValueUnit" TextMode="SingleLine" CssClass="form-control" name="valueUnit"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-group">
                            <label for="servicegroup">Grup Layanan:</label>
                            <asp:TextBox runat="server" ID="TxtServiceGroup" TextMode="SingleLine" CssClass="form-control" name="servicegroup"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="servicerate">Harga:</label>
                            <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtServiceRate" TextMode="SingleLine" CssClass="form-control" name="servicerate" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="TxtServiceRate" ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Silahkan isi harga"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="servicestatus">Status:</label>
                            <asp:DropDownList runat="server" ID="TxtServiceStatus" CssClass="form-control" name="servicestatus">
                                <Items>
                                    <asp:ListItem Text="Tersedia" Value="Tersedia"></asp:ListItem>
                                    <asp:ListItem Text="Tidak Tersedia" Value="Tidak Tersedia"></asp:ListItem>
                                </Items>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="TxtServiceStatus" ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Silahkan isi status layanan"></asp:RequiredFieldValidator>
                        </div>
                    </div>
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
        jQuery(document).ready(function GridStyle() {
            fixGridView($("#<%=GvData.ClientID%>"));

            $('#<%=GvData.ClientID%>').DataTable();
            $('#linkincrease').click(function () {
                $('body').css('font-size', '+=3');
            });

            $('#linkdecrease').click(function () {
                $('body').css('font-size', '-=3');
            });
        });

        function RestrictSpace() {
            if (event.keyCode == 32) {
                event.returnValue = false;
                return false;
            }
        }
    </script>

</asp:Content>

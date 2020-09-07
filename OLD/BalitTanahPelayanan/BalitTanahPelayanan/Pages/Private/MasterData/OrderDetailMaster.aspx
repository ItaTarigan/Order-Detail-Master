<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Admin.Master" AutoEventWireup="true" CodeBehind="OrderDetailMaster.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.MasterData.OrderDetailMaster" %>

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
                    <label for="search">Cari Detail Pesanan:</label>
                    <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton" />
                    <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton" />
                </div>--%>
                <div class="row mt-2" id="DivRow3" runat="server">
                    <div class="col-lg">
                        <asp:GridView CssClass="table table-bordered table-hover dataTable no-footer" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                            <Columns>
                                <asp:BoundField DataField="orderDetailNo" HeaderText="Kode Detail Pesanan" />
                                <asp:BoundField DataField="orderNo" HeaderText="Kode Pesanan" />
                                <asp:BoundField DataField="sampleNo" HeaderText="Kode Contoh" />
                                <asp:BoundField DataField="elementId" HeaderText="Kode Elemen" />
                                <asp:BoundField DataField="parametersNo" HeaderText="Kode Parameter" />
                                <asp:BoundField DataField="elementValue" HeaderText="Isi Elemen" />
                                <asp:BoundField DataField="status" HeaderText="Status Pembayaran" />
                                <asp:BoundField DataField="pic" HeaderText="Disetujui" />
                                <asp:TemplateField HeaderText="Aksi">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("orderDetailNo") %>' CommandName="ubah" Text="Ubah"></asp:LinkButton>
                                        <asp:LinkButton ID="btnLihat" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("orderDetailNo") %>' CommandName="lihat" Text="Lihat"></asp:LinkButton>
                                        <asp:LinkButton ID="btnHapus" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("orderDetailNo") %>' CommandName="hapus" Text="Hapus" OnClientClick="return confirm('Apakah anda yakin ingin menghapus?');"></asp:LinkButton>
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
                    <label>Kode Detail Pesanan:</label>
                    <asp:Label ID="TxtOrderDetailNo" runat="server" Visible="true" Text="Otomatis"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="orderno">Kode Pesanan:</label>
                    <asp:DropDownList runat="server" ID="TxtOrderNo" CssClass="form-control" name="orderno" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="sampleno">Kode Sample:</label>
                    <asp:DropDownList runat="server" ID="TxtSampleNo" CssClass="form-control" name="sampleno" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="elementcode">Kode Elemen:</label>
                    <asp:DropDownList runat="server" ID="TxtElementCode" CssClass="form-control" name="elementcode" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="parametersno">Kode Parameter:</label>
                    <asp:DropDownList runat="server" ID="TxtParametersNo" CssClass="form-control" name="parametersno" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="elementvalue">Isi Elemen:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtElementValue" TextMode="SingleLine" CssClass="form-control" name="elementvalue"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="status">Status:</label>
                    <asp:DropDownList runat="server" ID="TxtStatus" CssClass="form-control" name="status" AppendDataBoundItems="true">
                        <Items>
                            <asp:ListItem Text="Menunggu Diproses" Value="Menunggu Diproses"></asp:ListItem>
                            <asp:ListItem Text="Diproses" Value="Diproses"></asp:ListItem>
                            <asp:ListItem Text="Selesai" Value="Selesai"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="recalculate">Hitung Ulang:</label>
                    <asp:DropDownList runat="server" ID="TxtRecalculate" CssClass="form-control" name="recalculate" AppendDataBoundItems="true">
                        <Items>
                            <asp:ListItem Text="Tidak" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Hitung Ulang" Value="1"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="pic">Kode PIC:</label>
                    <asp:DropDownList runat="server" ID="TxtPic" CssClass="form-control" name="pic" AppendDataBoundItems="true"></asp:DropDownList>
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

        function RestrictSpace() {
            if (event.keyCode == 32) {
                event.returnValue = false;
                return false;
            }
        }
    </script>

</asp:Content>

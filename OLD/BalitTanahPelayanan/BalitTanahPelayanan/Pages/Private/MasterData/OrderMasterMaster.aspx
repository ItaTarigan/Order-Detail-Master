<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Admin.Master" AutoEventWireup="true" CodeBehind="OrderMasterMaster.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.MasterData.OrderMaster" %>

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
                <div class="row mt-2" id="DivRow3" runat="server">
                    <div class="col-lg">
                        <asp:GridView CssClass="table table-bordered table-hover dataTable no-footer" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                            <Columns>
                                <asp:BoundField DataField="orderNo" HeaderText="Kode Pesanan" />
                                <asp:BoundField DataField="customerNo" HeaderText="Kode Pelanggan" />
                                <asp:BoundField DataField="comodityNo" HeaderText="Kode Komoditas" />
                                <asp:BoundField DataField="sampleTotal" HeaderText="Total Contoh" />
                                <asp:BoundField DataField="priceTotal" HeaderText="Total Harga" />
                                <asp:BoundField DataField="status" HeaderText="Status" />
                                <asp:BoundField DataField="statusType" HeaderText="Tipe Pembayaran" />
                                <asp:BoundField DataField="paymentStatus" HeaderText="Status Pembayaran" />
                                <asp:BoundField DataField="paymentDate" HeaderText="Tanggal Pembayaran" />
                                <asp:BoundField DataField="ApprEvaluator" HeaderText="Disetujui" />
                                <asp:BoundField DataField="pic" HeaderText="Penanggung Jawab" />
                                <asp:TemplateField HeaderText="Aksi">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="ubah" Text="Ubah"></asp:LinkButton>
                                        <asp:LinkButton ID="btnLihat" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="lihat" Text="Lihat"></asp:LinkButton>
                                        <asp:LinkButton ID="btnHapus" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="hapus" Text="Hapus" OnClientClick="return confirm('Apakah anda yakin ingin menghapus?');"></asp:LinkButton>
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
                    <label>Kode Pesanan:</label>
                    <asp:Label ID="TxtOrderNo" runat="server" Visible="true" Text="Otomatis"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="customerno">Kode Pelanggan:</label>
                    <asp:DropDownList runat="server" ID="TxtCustomerNo" CssClass="form-control" name="customerno" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="comodityno">Kode Komoditas:</label>
                    <asp:DropDownList runat="server" ID="TxtComodityNo" CssClass="form-control" name="comodityno" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="sampletotal">Total Contoh:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtSampleTotal" TextMode="Number" CssClass="form-control" name="sampletotal" Text="0" ReadOnly="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtSampleTotal" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silahkan isi total contoh"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="pricetotal">Total Harga:</label>
                    <asp:TextBox runat="server" ID="TxtPriceTotal" TextMode="SingleLine" CssClass="form-control" name="pricetotal" ReadOnly="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtPriceTotal" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silahkan isi total harga"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="status">Status:</label>
                    <asp:DropDownList runat="server" ID="TxtStatus" CssClass="form-control" name="status" AppendDataBoundItems="true">
                        <Items>
                            <asp:ListItem Text="Pesanan Masuk" Value="Pesanan Masuk"></asp:ListItem>
                            <asp:ListItem Text="Baru" Value="Baru"></asp:ListItem>
                            <asp:ListItem Text="Hitung Ulang" Value="Hitung Ulang"></asp:ListItem>
                            <asp:ListItem Text="Menunggu Approval" Value="Menunggu Approval"></asp:ListItem>
                            <asp:ListItem Text="Approve" Value="Approve"></asp:ListItem>
                            <asp:ListItem Text="Kaji Ulang" Value="Kaji Ulang"></asp:ListItem>
                            <asp:ListItem Text="Pesanan Selesai" Value="Kaji Ulang"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ispayed">Status Pembayaran:</label>
                    <asp:DropDownList runat="server" ID="TxtIsPayed" CssClass="form-control" name="ispayed" AppendDataBoundItems="true">
                        <Items>
                            <asp:ListItem Text="Belum Dibayar" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Sudah Dibayar" Value="1"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="isapprove">Disetujui:</label>
                    <asp:DropDownList runat="server" ID="TxtIsApprove" CssClass="form-control" name="isapprove" AppendDataBoundItems="true">
                        <Items>
                            <asp:ListItem Text="Belum Disetujui" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Hitung Ulang" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Disetujui" Value="2"></asp:ListItem>
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
    </script>

</asp:Content>

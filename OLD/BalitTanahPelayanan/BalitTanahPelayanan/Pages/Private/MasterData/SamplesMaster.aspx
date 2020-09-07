<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Admin.Master" AutoEventWireup="true" CodeBehind="SamplesMaster.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.MasterData.SamplesMaster" %>

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
                    <label for="search">Cari Contoh:</label>
                    <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton" />
                    <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton" />
                </div>--%>
                <div class="row mt-2" id="DivRow3" runat="server">
                    <div class="col-lg">
                        <asp:GridView CssClass="table table-bordered table-hover dataTable" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                            <Columns>
                                <asp:BoundField DataField="noBalittanah" HeaderText="Nomor BalitTanah" />
                                <asp:BoundField DataField="orderNo" HeaderText="Kode Pesanan" />
                                <asp:BoundField DataField="countNumber" HeaderText="Nomor Urut" />
                                <asp:BoundField DataField="sampleCode" HeaderText="Kode Contoh" />
                                <asp:BoundField DataField="sampleDescription" HeaderText="Deskripsi" />
                                <asp:BoundField DataField="samplingDate" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Tanggal Pengambilan" />
                                <asp:BoundField DataField="village" HeaderText="Desa" />
                                <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                                <asp:BoundField DataField="district" HeaderText="Kota/Kabupaten" />
                                <asp:BoundField DataField="province" HeaderText="Provinsi" />
                                <asp:BoundField DataField="longitude" HeaderText="Koordinat GPS" />
                                <asp:BoundField DataField="landUse" HeaderText="Jenis Tanah" />
                                <asp:BoundField DataField="isReceived" HeaderText="Sudah Diterima" />
                                <asp:TemplateField HeaderText="Aksi">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="ubah" Text="Ubah"></asp:LinkButton>
                                        <asp:LinkButton ID="btnLihat" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="lihat" Text="Lihat"></asp:LinkButton>
                                        <asp:LinkButton ID="btnHapus" CssClass="linkbtn" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="hapus" Text="Hapus" OnClientClick="return confirm('Apakah anda yakin ingin menghapus?');"></asp:LinkButton>
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
                    <lable><h4>Informasi Contoh:</h4></lable>
                </div>
                <div class="form-group">
                    <label>Nomor Balittanah:</label>
                    <asp:Label ID="TxtNoBalittanah" runat="server" Visible="true" Text="Otomatis"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="orderno">Kode Pesanan:</label>
                    <asp:DropDownList runat="server" ID="TxtOrderNo" CssClass="form-control" name="orderno" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="countnumber">Nomor Urut:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtCountNumber" TextMode="Number" CssClass="form-control" name="countnumber"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtCountNumber" ValidationGroup="vg1" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Silahkan isi kode contoh"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="samplecode">Kode Contoh:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtSampleCode" TextMode="SingleLine" CssClass="form-control" name="samplecode"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtSampleCode" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silahkan isi kode contoh"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="sampledescription">Deskripsi:</label>
                    <asp:TextBox runat="server" ID="TxtDescription" TextMode="SingleLine" CssClass="form-control" name="sampledescription"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtDescription" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silahkan isi Deskripsi"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="samplingdate">Tanggal Pengambilan:</label>
                    <asp:TextBox runat="server" ID="TxtSamplingDate" TextMode="Date" CssClass="form-control" name="samplingdate"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtSamplingDate" ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Silahkan isi Tanggal Pengambilan contoh"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <lable><h4>Informasi Daerah:</h4></lable>
                </div>
                <div class="form-group">
                    <label for="village">Desa:</label>
                    <asp:TextBox runat="server" ID="TxtVillage" TextMode="SingleLine" CssClass="form-control" name="village"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="subdistrict">Kecamatan:</label>
                    <asp:TextBox runat="server" ID="TxtSubDistrict" TextMode="SingleLine" CssClass="form-control" name="subdistrict"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="district">Kabupaten / Kota:</label>
                    <asp:TextBox runat="server" ID="TxtDistrict" TextMode="SingleLine" CssClass="form-control" name="district"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="province">Provinsi:</label>
                    <asp:TextBox runat="server" ID="TxtProvince" TextMode="SingleLine" CssClass="form-control" name="province"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="gpscoordinate">Koordinat GPS:</label>
                    <asp:TextBox runat="server" ID="TxtGps" TextMode="SingleLine" CssClass="form-control" name="TxtGps"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="landuse">Jenis Tanah:</label>
                    <asp:DropDownList runat="server" ID="TxtLandUSe" CssClass="form-control" name="landuse" AppendDataBoundItems="true">
                        <Items>
                            <asp:ListItem Text="Tanpa Keterangan" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Lahan Sawah" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Lahan Kering" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Lahan Hutan" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Lahan Sulfat Asam" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Lahan Lebag" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Lahan Gambut" Value="6"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="isreceived">Sampe Diterima:</label>
                    <asp:DropDownList runat="server" ID="TxtIsReceived" CssClass="form-control" name="isreceived" AppendDataBoundItems="true">
                        <Items>
                            <asp:ListItem Text="Belum Diterima" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Sudah Diterima" Value="1"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
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

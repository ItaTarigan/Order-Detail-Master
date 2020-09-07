<%@ Page Title="Customer - Tambah Pesanan" Language="C#" MasterPageFile="~/Pages/Master/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerBuatPesanan.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.CustomerBuatPesanan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="row mt-2" id="DivRow1" runat="server">
        <div class="col-lg">
            <h2>
            <asp:Label ID="lblTambahPesananBaru" runat="server">Tambah Pesanan Baru</asp:Label>
            </h2>
        </div>

    </div>
    <div class="row mt-2" id="DivRow2" runat="server">
        <div class="col-lg">
            <h4>
                <asp:Label ID="lblSilahkanInput" runat="server">Silakan input data-data berikut untuk melakukan pesanan baru</asp:Label>
            </h4>
        </div>

    </div>
    <div class="row mt-2" id="DivRow3" runat="server">
        <div class="col-lg-4">
            <div>
                <div class="form-group">                    
                    <label id="txtNoOrder" for="TxtNoOrder">No.Order</label>
                    <asp:TextBox TextMode="SingleLine" ReadOnly="true" ID="TxtNoOrder" class="form-control" aria-describedby="desc0" placeholder="No Order" runat="server"></asp:TextBox>
                    <small id="desc0" class="form-text text-muted">No Order (auto generated)</small>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTanggalDiterima" for="TxtTanggalDiterima" runat="server">Tanggal Diterima</asp:Label>
                    <asp:TextBox TextMode="Date" ID="TxtTanggalDiterima" class="form-control" aria-describedby="desc1" placeholder="Pilih Tanggal" runat="server"></asp:TextBox>
                    <small id="desc1" class="form-text text-muted"><asp:label runat="server" ID="lbtp"></asp:label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vg1" runat="server" ControlToValidate="TxtTanggalDiterima" ErrorMessage="Silakan isi tanggal diterima"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="form-group">
                <asp:label ID="cmb2Komoditas" for="CmbKomoditas" runat="server">Pilih Komoditas</asp:label>

                <asp:DropDownList ID="CmbKomoditas" class="form-control" aria-describedby="desc2" placeholder="Pilih Komoditas" runat="server" OnSelectedIndexChanged="GenerateChildKomoditas" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                <small id="desc2" class="form-text text-muted"><asp:label runat="server" ID="lbspk"></asp:label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vg1" runat="server" ControlToValidate="CmbKomoditas" ErrorMessage="Silakan pilih komoditas"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:label ID="cmb2SubKomoditas" for="CmbSubKomoditas" runat="server">Pilih Sub Komoditas</asp:label>
                <asp:DropDownList ID="CmbSubKomoditas" class="form-control" aria-describedby="desc3" placeholder="Pilih Sub Komoditas" runat="server" OnSelectedIndexChanged="GenerateParameterUji" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                <small id="desc3" class="form-text text-muted"><asp:label runat="server" ID="lbspsk"></asp:label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="vg1" runat="server" ControlToValidate="CmbSubKomoditas" ErrorMessage="Silakan pilih sub komoditas"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:label ID="cmb2JenisAnalisa" for="CmbJenisAnalisa" runat="server">Jenis Analisis</asp:label>
                <asp:DropDownList ID="CmbJenisAnalisa" class="form-control" aria-describedby="desc4" placeholder="Pilih Analisa" runat="server" OnSelectedIndexChanged="GenerateParameterUji" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                <small id="desc4" class="form-text text-muted"><asp:label runat="server" ID="lbspta"></asp:label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="vg1" runat="server" ControlToValidate="CmbJenisAnalisa" ErrorMessage="Silakan pilih tipe analisa"></asp:RequiredFieldValidator>

            </div>

        </div>
    </div>
    <div class="row mt-2" id="DivRow4" runat="server">
        <div class="col-lg">
            <h4>
                <asp:Label ID="lblDaftarParameter" runat="server">Daftar Parameter Uji</asp:Label>
            </h4>
        </div>
    </div>
    <div class="row mt-2" id="DivRow5" runat="server">
        <div class="col-lg-8">
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvParameter" runat="server" AutoGenerateColumns="false" AllowPaging="false" >
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="ChkAll" Visible="false" OnCheckedChanged="CheckedAll" AutoPostBack="true" runat="server"></asp:CheckBox>
                            <asp:Label ID="lblPilih" runat="server">Pilih</asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="isChecked" Checked="true" runat="server" OnCheckedChanged="DoChecked" AutoPostBack="true"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Parameter Uji" Visible="false">
                        <ItemTemplate>
                            <asp:HiddenField ID="HidMandatory" Value='<%# Eval("elementservicestbl.isMandatory") %>' runat="server" />
                            <asp:Label runat="server" ID="txtParameterId" Text='<%# Eval("elementservicestbl.elementId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Parameter Uji">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="txtParameterUji" Text='<%# Eval("elementservicestbl.elementCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tarif per Contoh">
                        <ItemTemplate>
                            <b>
                                <asp:Label runat="server" ID="txtTarif" Text='<%# float.Parse( Eval("elementservicestbl.serviceRate").ToString()) %>'></asp:Label></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jumlah Contoh">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ReadOnly="true" ID="txtJumlahContoh" onkeypress="return isNumberKey(event)" Text="1" OnTextChanged="CalculateTotal" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Biaya">
                        <ItemTemplate>
                            <b>
                                <asp:Label runat="server" ID="txtBiaya" Text="0"></asp:Label></b>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div id="GvParameterAllFields" style="display:none" ></div>
            <script>
                var GvDTableFields;
                function isNumberKey(evt) {
                    var charCode = (evt.which) ? evt.which : evt.keyCode;
                    if (charCode > 31 && (charCode < 48 || charCode > 57))
                        return false;
                    return true;
                }
                function fixGridView(tableEl) {
                    var jTbl = $(tableEl);

                    if (jTbl.find("tbody>tr>th").length > 0) {
                        jTbl.find("tbody").before("<thead><tr></tr></thead>");
                        jTbl.find("thead tr").append(jTbl.find("th"));
                        jTbl.find("tbody tr:first").remove();
                    }
                }
                $(document).ready(function () {
                    fixGridView($("#<%=GvParameter.ClientID%>"));
                    GvDTableFields = $('#<%=GvParameter.ClientID%>').find(':input').clone();
                    GvDTableFields.each(function (i, f) {
                        $(f).appendTo($('#GvParameterAllFields'));
                    });
                    $('#<%=GvParameter.ClientID%>').DataTable();
                    $('#<%=GvParameter.ClientID%>').on('draw.dt', function () {
                        //console.log('page')
                        dataTableSync();
                    });
                    dataTableSync();
                });
                function dataTableSync() {
                    $('#GvParameterAllFields :input').prop('disabled', false);
                    var items = $('#<%=GvParameter.ClientID%> :input').map((a, f) => f.id);
                    $('#GvParameterAllFields :input').each(function (i, f) {
                        if (items.filter((a, b) => b == f.id).length > 0) {
                            $(f).prop('disabled', true);
                        }
                    })
                }
                $('form').submit(function () {
                    //$(GvDTable.fnGetHiddenNodes()).find('input:checked').appendTo(this);
                });

            </script>
        </div>
    </div>
    <div class="row mt-2" id="DivRow6" runat="server">
        <div class="col-lg">
            <h4>
                <asp:Label ID="lblDaftarSample" runat="server">Daftar Sampel</asp:Label>
            </h4>
        </div>
    </div>
    <div class="row mt-2" id="DivRow7" runat="server">
        <div class="col-lg">
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" >
                <Columns>
                    <asp:BoundField DataField="countNumber" HeaderText="No Urut" />
                    <asp:BoundField DataField="sampleCode" HeaderText="No Sample" />
                    <asp:BoundField DataField="noBalittanah" HeaderText="No Balittanah" />
                    <asp:BoundField DataField="village" HeaderText="Desa" />
                    <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                    <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                    <asp:BoundField DataField="province" HeaderText="Propinsi" />
                    <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                    <asp:TemplateField HeaderText="Koordinat GPS">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("latitude") +"," +Eval("longitude")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tindakan">
                        <ItemTemplate>
                            <asp:LinkButton ID="BtnUbah" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="Ubah" Text="Ubah" CssClass="btn btn-success"></asp:LinkButton>
                            <asp:LinkButton ID="BtnHapus" runat="server" OnClientClick="return confirm('Yakin ingin menghapus sampel ini?');" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="Hapus" Text="Hapus" CssClass="btn btn-danger"></asp:LinkButton>
                            <asp:LinkButton ID="BtnDuplikat" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="Duplikat" Text="Duplikat" CssClass="btn btn-warning"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <%-- Script untuk GvSample --%>
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
                        });
            </script>
        </div>
        <div class="w-100">
        </div>
        <div class="col-lg mt-2">
            <asp:Button ID="BtnAddSampel" CssClass="btn btn-success" runat="server" Text="Tambah Sampel" CommandName="add" OnClick="ActionButton" />
        </div>
    </div>
    <div class="row mt-2 alert alert-info" id="DivRow8" runat="server" style="margin: 25px 0px 15px !important;">
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblJumlahParameterUji" runat="server">Jumlah Parameter Uji:</asp:Label>
                <asp:Literal ID="LitJmlParameterUji" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblJumlahSample" runat="server">Jumlah Sampel:</asp:Label>
                <asp:Literal ID="LitJumlahSampel" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblTotalBiaya" runat="server">Total Biaya: </asp:Label>
                <asp:Literal ID="LitTotalBiaya" runat="server"></asp:Literal>
            </b>
        </div>
    </div>
    <div class="row mt-2" id="DivRow9" runat="server">
        <div class="col-lg">
            <asp:Button ID="BtnBatal" CssClass="btn btn-warning" runat="server" Text="Kembali" CommandName="cancel" OnClick="ActionButton" />
            <asp:Button ID="BtnSimpan" ValidationGroup="vg1" CssClass="btn btn-info" runat="server" Text="Simpan" CommandName="proses" OnClick="ActionButton" />
            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="vg1" ShowMessageBox="true" ShowSummary="false" runat="server" />
        </div>
    </div>
    <div class="row mt-2" id="DivRow10" visible="false" runat="server">
        <div class="col-lg">
            <h4>
                <asp:Label ID="lblInputDataSample" runat="server">Input Data Sampel</asp:Label>
            </h4>
        </div>
    </div>
    <div class="row mt-2" id="DivRow11" visible="false" runat="server">
        <div class="col-lg-4">
            <div>

                <div class="form-group">
                    <asp:label id="lblNoSample" for="TxtNoSampel" runat="server">Nomor sample</asp:label>
                    <asp:TextBox TextMode="SingleLine" ID="TxtNoSampel" class="form-control" aria-describedby="desc1" placeholder="No Sampel Customer" runat="server"></asp:TextBox>
                    <small id="desc1" class="form-text text-muted"<asp:label runat="server" ID="Nsc"></asp:label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="vg2" runat="server" ControlToValidate="TxtNoSampel" ErrorMessage="Silakan isi no sampel"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:label ID="lblNoBalittanah" runat="server" for="TxtNoBalitTanah">No. Balit Tanah</asp:label>
                    <asp:TextBox TextMode="SingleLine" ID="TxtNoBalitTanah" ReadOnly="true" class="form-control" aria-describedby="desc2" placeholder="Auto generated No." runat="server"></asp:TextBox>
                    <small id="desc2" class="form-text text-muted"><asp:label runat="server" ID="nsbt"></asp:label></small>

                </div>
                <div class="form-group">
                    <asp:label ID="lblTglSampling" runat="server" for="TxtTglSampling">Tanggal Sampling</asp:label>
                    <asp:TextBox ID="TxtTglSampling" TextMode="Date" class="form-control" aria-describedby="desc6" placeholder="Tanggal Sampling" runat="server"></asp:TextBox>
                    <small id="desc6" class="form-text text-muted"><asp:label runat="server" ID="sits"></asp:label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="vg2" runat="server" ControlToValidate="TxtTglSampling" ErrorMessage="Silakan isi tanggal sampling"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:label ID="cmb2TipeTanah" runat="server" for="CmbTipeTanah">Tipe Tanah</asp:label>
                    <asp:DropDownList ID="CmbTipeTanah" class="form-control" aria-describedby="desc7" placeholder="Pilih Tipe Tanah" runat="server">
                        <asp:ListItem Text="Lahan Sawah" Value="Lahan Sawah"></asp:ListItem>
                        <asp:ListItem Text="Lahan Kering" Value="Lahan Kering"></asp:ListItem>
                        <asp:ListItem Text="Lahan Hutan" Value="Lahan Hutan"></asp:ListItem>
                        <asp:ListItem Text="Lahan Sulfat Masam" Value="Lahan Sulfat Masam"></asp:ListItem>
                        <asp:ListItem Text="Lahan Lebag" Value="Lahan Lebag"></asp:ListItem>
                        <asp:ListItem Text="Lahan Gambut" Value="Lahan Gambut"></asp:ListItem>
                    </asp:DropDownList>
                    <small id="desc7" class="form-text text-muted"><asp:label runat="server" ID="sptt"></asp:label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="vg2" runat="server" ControlToValidate="CmbTipeTanah" ErrorMessage="Silakan pilih tipe tanah"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:label ID="lblKeterangan" runat="server" for="TxtKeterangan">Keterangan Sampel</asp:label>
                    <asp:TextBox ID="TxtKeterangan" TextMode="MultiLine" class="form-control" aria-describedby="desc6"  runat="server"></asp:TextBox>
                    <small id="desc6" class="form-text text-muted"><asp:label runat="server" ID="sikts"></asp:label></small>

                </div>

                <asp:Button ID="BtnSimpanSampel" ValidationGroup="vg2" CssClass="btn btn-success" CommandName="add-sampel" OnClick="ActionButton" runat="server" Text="Simpan" />
                <asp:Button ID="BtnBatalSampel" CssClass="btn btn-warning" CommandName="cancel-sampel" OnClick="ActionButton" runat="server" Text="Batal" />
                <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="vg2" ShowMessageBox="true" ShowSummary="false" runat="server" />
            </div>
        </div>
        <div class="col-lg-4">
            <div class="form-group">
                <asp:label ID="cmb2Provinsi" runat="server" for="CmbPropinsi">Propinsi</asp:label>
                <asp:DropDownList ID="CmbPropinsi" OnSelectedIndexChanged="CmbPropinsi_SelectedIndexChanged" AutoPostBack="true" class="form-control" aria-describedby="desc3" placeholder="Propinsi" runat="server"></asp:DropDownList>
                <small id="desc3" class="form-text text-muted"><asp:label runat="server" ID="spp"></asp:label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="vg2" runat="server" ControlToValidate="CmbPropinsi" ErrorMessage="Silakan pilih propinsi"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:label ID="cmb2Kabupaten" runat="server" for="CmbKabupaten">Kabupaten</asp:label>
                <asp:DropDownList ID="CmbKabupaten" OnSelectedIndexChanged="CmbKabupaten_SelectedIndexChanged" AutoPostBack="true" class="form-control" aria-describedby="desc4" placeholder="Kabupaten" runat="server"></asp:DropDownList>
                <small id="desc4" class="form-text text-muted"><asp:label runat="server" ID="spk"></asp:label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="vg2" runat="server" ControlToValidate="CmbKabupaten" ErrorMessage="Silakan pilih kabupaten"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:label ID="cmb2Kecamatan" runat="server" for="CmbKecamatan">Kecamatan</asp:label>
                <asp:DropDownList ID="CmbKecamatan" OnSelectedIndexChanged="CmbKecamatan_SelectedIndexChanged" AutoPostBack="true" class="form-control" aria-describedby="desc4" placeholder="Kecamatan" runat="server"></asp:DropDownList>
                <small id="desc5" class="form-text text-muted"><asp:label runat="server" ID="sknk"></asp:label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="vg2" runat="server" ControlToValidate="CmbKecamatan" ErrorMessage="Silakan isi kecamatan"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:label ID="cmb2Desa" runat="server" for="CmbDesa">Desa</asp:label>
                <asp:DropDownList ID="CmbDesa" class="form-control" aria-describedby="desc4" placeholder="Desa" runat="server"></asp:DropDownList>
                <small id="desc6" class="form-text text-muted"><asp:label runat="server" ID="sknd"></asp:label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="vg2" runat="server" ControlToValidate="CmbDesa" ErrorMessage="Silakan isi desa"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:label ID="lblLokasi" runat="server" for="TxtLokasi">Lokasi GPS</asp:label>
                <div class="row">
                    <div class="col-lg-5">
                        <asp:TextBox TextMode="SingleLine" ID="TxtLatitude" Text="0" class="form-control" aria-describedby="desc8" placeholder="Latitude" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-lg-5 ml-1">
                        <asp:TextBox TextMode="SingleLine" ID="TxtLongitude" Text="0" class="form-control" aria-describedby="desc8" placeholder="Longitude" runat="server"></asp:TextBox>
                    </div>
                </div>

                <small id="desc8" class="form-text text-muted"><asp:label runat="server" ID="sildl"></asp:label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="vg2" runat="server" ControlToValidate="TxtLatitude" ErrorMessage="Silakan isi latitude"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="vg2" runat="server" ControlToValidate="TxtLongitude" ErrorMessage="Silakan is longitude"></asp:RequiredFieldValidator>

            </div>
        </div>
    </div>
    <%-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
    <div class="row mt-2" id="DivPesananBaru" runat="server" visible="false">
        <div class="col-lg">
            <h2>
                <b>
                    <asp:Label ID="lblKonfirmasiPesananBaru" runat="server">Konfirmasi Pesanan Baru</asp:Label>
                </b>
            </h2>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfoPelanggan" visible="false">
        <div class="col-lg-12">
            <h5>
                <b>
                    <asp:Label ID="lblInfoPelanggan" for="" runat="server">Info Pelanggan</asp:Label>
                </b>
            </h5>
            <div class="card">
                <div class="card-body" style="background-color: lightgray;">

                    <p class="card-text">
                        <b>
                            <asp:Label ID="name" for="" runat="server">Nama Pelanggan </asp:Label>
                        </b>
                        <asp:Label ID="lblcusname" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="instansi" for="" runat="server">Instansi</asp:Label>
                        </b>
                        <asp:Label ID="lblInstansi" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
            <br>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfoPesanan" visible="false">
        <div class="col-lg-12">
            <h5>
                <b>
                    <asp:Label ID="lblInfoPesanan" for="" runat="server">Info Pesanan</asp:Label>
                </b>
            </h5>
            <div class="card">
                <div class="card-body" style="background-color: lightgray;">

                    <p class="card-text">
                        <b>
                            <asp:Label ID="tanggal" for="" runat="server">Tanggal</asp:Label>
                        </b>
                        <asp:Label ID="lblTanggal" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="noPesanan" for="" runat="server">No Pesanan</asp:Label>
                        </b>
                        <asp:Label ID="lblnoPesanan" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="komoditas" for="tanggal" runat="server">Komoditas</asp:Label>
                        </b>
                        <asp:Label ID="lblKomoditas" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="subKomoditas" for="" runat="server">Sub Komoditas</asp:Label>
                        </b>
                        <asp:Label ID="lblsubKomoditas" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <asp:Label ID="jenisAnalisis" for="tanggal" runat="server">Jenis Analisis</asp:Label>
                        </b>
                        <asp:Label ID="lbljenisAnalisis" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
            <br>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfoSampel" visible="false">
        <div class="col-lg-12">
            <h5>
                <b>
                    <asp:Label ID="infoSampel" for="" runat="server">Info Sampel</asp:Label>
                </b>
            </h5>
            <div class="card">

                <%-- DG In Here --%>
            </div>
            <br>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivInfoParameterUji" visible="false">
        <div class="col-lg-12">
            <h5>
                <b>
                    <asp:Label ID="parameterUji" for="" runat="server">Info Parameter Uji</asp:Label>
                </b>
            </h5>
            <div class="card">

                <%-- DG In Here --%>
            </div>
        </div>
    </div>
    <div class="row mt-2 alert alert-info" id="DivJumlah" runat="server" style="margin: 25px 0px 15px !important;" visible="false">
        <div class="col-lg-3">
            <b>
                <asp:Label ID="Label2" runat="server">Jumlah Parameter Uji</asp:Label>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="Label3" runat="server">Jumlah Sampel</asp:Label>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="Label4" runat="server">Total Biaya</asp:Label>
                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
            </b>
        </div>
    </div>
    <br>
    <div class="row mt-2" runat="server" id="DivAgreement" visible="false">
        <div class="col-lg-8">
            <asp:CheckBox ID="CheckBox1" runat="server" />
            <h5><b><asp:Label ID="SayaSetuju" for="" runat="server">Saya menyetujui untuk melanjutkan pesanan ini sesuai dengan standar prosedur yang berlaku di Balitanah</asp:Label></b></h5>
            <asp:Button ID="BtnSOP" CssClass="btn btn-success" runat="server" Text="Standar Prosedur" CommandName="sop" OnClick="ActionButton" />
            <br>
            <br>
        </div>
    </div>

    <div class="row mt-2" runat="server" id="DivButton" visible="false">
        <div class="col-lg">
            <asp:Button ID="BtnKembali" CssClass="btn btn-warning" runat="server" Text="Kembali" CommandName="back" OnClick="ActionButton" />
            <asp:Button ID="BtnSetuju" CssClass="btn btn-info" runat="server" Text="Setuju" />
        </div>
    </div>

    <div class="row mt-2" id="DivSOP" runat="server" visible="false">

        <div class="col-lg text-center">
            <img src="../../../assets/img/SOP.png" width="900" alt="sop" />
        </div>

    </div>
    <div class="row mt-2" id="DivBtnTutup" runat="server" visible="false">

        <div class="col-lg text-center">
             <asp:Button ID="BtnTutup" CssClass="btn btn-warning" runat="server" Text="Tutup" CommandName="close" OnClick="ActionButton"/>
        </div>

    </div>
</asp:Content>

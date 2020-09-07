<%@ Page Title="Customer - Tambah Pesanan" Language="C#" MasterPageFile="~/Pages/Master/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerBuatPesanan.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.CustomerBuatPesanan" %>

<%@ Register Src="~/Usercontrols/OrderNavigation.ascx" TagPrefix="custom" TagName="nav" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="row mt-2" id="DivRow1" runat="server">
        <div class="col-lg">
            <h2>
                <asp:Label ID="lblTambahPesananBaru" runat="server">Tambah Pesanan Baru</asp:Label>
                <asp:HiddenField ID="hidIsPackage" runat="server" />
            </h2>
        </div>
        <div class="col-lg" style="text-align: right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight: bold;" href="#" class="btn btn-outline-secondary">-</a>
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
                    <small id="desc1" class="form-text text-muted">
                        <asp:Label runat="server" ID="lbtp"></asp:Label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vg1" runat="server" ControlToValidate="TxtTanggalDiterima" ErrorMessage="Silakan isi tanggal diterima"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="form-group">
                <asp:Label ID="cmb2JenisAnalisa" for="CmbJenisAnalisa" runat="server">Jenis Analisis</asp:Label>
                <asp:DropDownList ID="CmbJenisAnalisa" class="form-control" aria-describedby="desc4" placeholder="Pilih Analisa" runat="server" OnSelectedIndexChanged="GenerateParameterUji" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                <small id="desc4" class="form-text text-muted">
                    <asp:Label runat="server" ID="lbspta"></asp:Label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="vg1" runat="server" ControlToValidate="CmbJenisAnalisa" ErrorMessage="Silakan pilih tipe analisa"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:Label ID="cmb2Komoditas" for="CmbKomoditas" runat="server">Pilih Komoditas</asp:Label>
                <div class="input-group">
                    <asp:TextBox TextMode="SingleLine" ReadOnly="true" ID="TxtKomoditas" class="form-control" aria-describedby="desc2" placeholder="Pilih Komoditas" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnPilihCommodity" CssClass="btn btn-primary input-group-append" runat="server" Text="Pilih" />
                </div>
                <asp:HiddenField ID="HidCommodityNo" runat="server" />
                <small id="desc2" class="form-text text-muted">
                    <asp:Label runat="server" ID="lbspk"></asp:Label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vg1" runat="server" ControlToValidate="TxtKomoditas" ErrorMessage="Silakan pilih komoditas"></asp:RequiredFieldValidator>

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
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvParameter" runat="server" AutoGenerateColumns="false" AllowPaging="false">
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
                            <asp:HiddenField ID="HidMandatory" Value='<%# Eval("isMandatory") %>' runat="server" />
                            <asp:Label runat="server" ID="txtParameterId" Text='<%# Eval("elementId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Parameter Uji">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="txtParameterUji" Text='<%# Eval("elementCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tarif per Contoh">
                        <ItemTemplate>
                            <b>
                                <asp:Label runat="server" ID="txtTarif" Text='<%# float.Parse( Eval("serviceRate").ToString()) %>'></asp:Label></b>
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
            <br />
            <div id="GvParameterAllFields" style="display: none"></div>
            <div id="SpanKeterangan" class="alert alert-success" runat="server" visible="false">
                <p>
                    <asp:Literal ID="LitKeterangan" runat="server"></asp:Literal>
                </p>
            </div>
            <div id="SpanHargaPaket" class="alert alert-info" runat="server" visible="false">
                <b>Harga Paket : Rp.<asp:Literal ID="LitTotalHargaPaket" runat="server"></asp:Literal></b>
                <br />
                <p>
                    *) harga paket tidak dihitung per-parameter tapi harga paket dikali jumlah sampel
                </p>
            </div>
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
                    initForm();
                    setFontResizer();
                });

                function initForm() {
                    var grid = (document.getElementById("<%=GvParameter.ClientID%>")) ? document.getElementById("<%=GvParameter.ClientID%>") : null;
                            if (grid) {
                                if (grid.rows.length > 1) {
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
                        }
                    }

                }
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
                        /*
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                if (prm != null) {
                    prm.add_endRequest(function (sender, e) {
                        if (sender._postBackSettings.panelsToUpdate != null) {
                            initForm();
                        }
                    });
                };*/
            </script>
        </div>
    </div>
    <div class="row mt-2" id="DivTambahanBiayaTitle" visible="false" runat="server">
        <div class="col-lg">
            <h4>
                <asp:Label ID="LblTambahanBiaya" runat="server">Tambahan Biaya</asp:Label>
                <asp:HiddenField ID="HidTambahanBiaya" runat="server" />
            </h4>
        </div>
    </div>
    <div class="row mt-2" id="DivTambahanBiayaGenus" visible="false" runat="server">
        <div class="col-lg-4">
            <div>
                <div class="form-group">
                    <asp:Label ID="LblJumlahGenus" for="TxtJmlGenus" runat="server">Jumlah Genus</asp:Label>
                    <asp:TextBox TextMode="Number" AutoPostBack="true" ID="TxtJmlGenus" class="form-control" aria-describedby="desc1" placeholder="0" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="LblHargaPerGenus" runat="server" for="TxtHargaGenus">Harga per-Genus (Rp.)</asp:Label>
                    <asp:TextBox TextMode="SingleLine" ID="TxtHargaGenus" ReadOnly="true" class="form-control" aria-describedby="desc2" placeholder="Rp." runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="LblTotalHargaGenus" runat="server" for="TxtTotalHargaGenus">Total Biaya Tambahan (Jumlah Sampel x Genus x Harga per-Genus)</asp:Label>
                    <asp:TextBox ID="TxtTotalHargaGenus" TextMode="SingleLine" ReadOnly="true" class="form-control" aria-describedby="desc6" placeholder="0" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="row mt-2" id="DivTambahanBiayaLogamBerat" visible="false" runat="server">
        <div class="col-lg-4">
            <div>
                <div class="form-group">

                    <asp:CheckBox ID="ChkLogamBerat" Text="Uji Logam Berat" AutoPostBack="true" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblHargaLogam" runat="server" for="TxtHargaLogamBerat">Harga Uji Logam Berat per-Sampel (Rp.)</asp:Label>
                    <asp:TextBox TextMode="SingleLine" ID="TxtHargaUjiLogamBerat" ReadOnly="true" class="form-control" aria-describedby="desc2" placeholder="Rp." runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTotalTambahan" runat="server" for="TxtTotalHargaLogamBerat">Total Biaya Tambahan (Jumlah Sampel x Harga Uji Logam Berat per-Sampel)</asp:Label>
                    <asp:TextBox ID="TxtTotalHargaLogamBerat" TextMode="SingleLine" ReadOnly="true" class="form-control" aria-describedby="desc6" placeholder="0" runat="server"></asp:TextBox>
                </div>
            </div>
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
            <asp:HiddenField ID="DuplicateRequestInput" runat="server" Value="0" />
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false">
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
                            <asp:LinkButton ID="BtnDuplikat" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="Duplikat" Text="Duplikat" CssClass="btn btn-warning" OnClientClick="requstDuplicate()"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <script>
                function requstDuplicate() {
                    var total = prompt("Masukan total yang ingin di duplikat", "1");
                    if (total != null && total != "") {
                        document.getElementById("<%=DuplicateRequestInput.ClientID%>").value = total;
                        }
                        else {
                            document.getElementById("<%=DuplicateRequestInput.ClientID%>").value = "0";
                    }
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
                    initForm2();
                    
                    //setFontResizer();
                    //initForm2();
                    //setFontResizer();
                });
                function setFontResizer() {
                    $('#linkincrease').click(function () {
                        $('body').css('font-size', '+=3');
                    });

                    $('#linkdecrease').click(function () {
                        $('body').css('font-size', '-=3');
                    });
                }
                function initForm2() {
                    var grid = (document.getElementById("<%=GvData.ClientID%>")) ? document.getElementById("<%=GvData.ClientID%>") : null;
                        if (grid) {
                            if (grid.rows.length > 1) {
                                fixGridView($("#<%=GvData.ClientID%>"));
                                    $('#<%=GvData.ClientID%>').DataTable();
                        }
                    }


                }
                       
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
            <asp:Button ID="BtnSimpan" ValidationGroup="vg1" CssClass="btn btn-info" runat="server" Text="Simpan" CommandName="confirm" OnClick="ActionButton" />
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
                    <asp:Label ID="lblNoSample" for="TxtNoSampel" runat="server">Nomor sample</asp:Label>
                    <asp:TextBox TextMode="SingleLine" ID="TxtNoSampel" class="form-control" aria-describedby="desc1" placeholder="No Sampel Customer" runat="server"></asp:TextBox>
                    <small id="desc1" class="form-text text-muted">
                        <asp:Label runat="server" ID="Nsc"></asp:Label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="vg2" runat="server" ControlToValidate="TxtNoSampel" ErrorMessage="Silakan isi no sampel"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:Label ID="lblNoBalittanah" runat="server" for="TxtNoBalitTanah">No. Balit Tanah</asp:Label>
                    <asp:TextBox TextMode="SingleLine" ID="TxtNoBalitTanah" ReadOnly="true" class="form-control" aria-describedby="desc2" placeholder="Auto generated No." runat="server"></asp:TextBox>
                    <small id="desc2" class="form-text text-muted">
                        <asp:Label runat="server" ID="nsbt"></asp:Label></small>

                </div>
                <div class="form-group">
                    <asp:Label ID="lblTglSampling" runat="server" for="TxtTglSampling">Tanggal Pengambilan Sampel</asp:Label>
                    <asp:TextBox ID="TxtTglSampling" TextMode="Date" class="form-control" aria-describedby="desc6" placeholder="Tanggal Pengambilan Sampel" runat="server"></asp:TextBox>
                    <small id="desc6" class="form-text text-muted">
                        <asp:Label runat="server" ID="sits"></asp:Label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="vg2" runat="server" ControlToValidate="TxtTglSampling" ErrorMessage="Silakan isi tanggal pengambilan sampel"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:Label ID="cmb2TipeTanah" runat="server" for="CmbTipeSampel">Tipe Sampel</asp:Label>
                    <asp:DropDownList ID="CmbTipeSampel" class="form-control" aria-describedby="desc7" placeholder="Pilih Tipe Sampel" runat="server">
                        <%-- <asp:ListItem Text="Tanah Sawah" Value="Tanah Sawah"></asp:ListItem>
                                <asp:ListItem Text="Tanah Kering" Value="Tanah Kering"></asp:ListItem>
                                <asp:ListItem Text="Tanah Hutan" Value="Tanah Hutan"></asp:ListItem>
                                <asp:ListItem Text="Tanah Sulfat Masam" Value="Tanah Sulfat Masam"></asp:ListItem>
                                <asp:ListItem Text="Tanah Lebag" Value="Tanah Lebag"></asp:ListItem>
                                <asp:ListItem Text="Tanah Gambut" Value="Tanah Gambut"></asp:ListItem>
                                <asp:ListItem Text="Tanaman" Value="Tanaman"></asp:ListItem>
                                <asp:ListItem Text="Air" Value="Air"></asp:ListItem>
                                <asp:ListItem Text="Pupuk Organik" Value="Pupuk Organik"></asp:ListItem>
                                <asp:ListItem Text="Pupuk Anorganik Padat" Value="Pupuk Anorganik Padat"></asp:ListItem>
                                <asp:ListItem Text="Pupuk Anorganik Cair" Value="Pupuk Anorganik Cair"></asp:ListItem>--%>
                    </asp:DropDownList>
                    <small id="desc7" class="form-text text-muted">
                        <asp:Label runat="server" ID="sptt"></asp:Label></small>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="vg2" runat="server" ControlToValidate="CmbTipeSampel" ErrorMessage="Silakan pilih tipe tanah"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <asp:Label ID="lblKeterangan" runat="server" for="TxtKeterangan">Keterangan Sampel</asp:Label>
                    <asp:TextBox ID="TxtKeterangan" TextMode="MultiLine" class="form-control" aria-describedby="desc6" runat="server"></asp:TextBox>
                    <small id="desc6" class="form-text text-muted">
                        <asp:Label runat="server" ID="sikts"></asp:Label></small>

                </div>

                <asp:Button ID="BtnSimpanSampel" ValidationGroup="vg2" CssClass="btn btn-success" CommandName="add-sampel" OnClick="ActionButton" runat="server" Text="Simpan" />
                <asp:Button ID="BtnBatalSampel" CssClass="btn btn-warning" CommandName="cancel-sampel" OnClick="ActionButton" runat="server" Text="Batal" />
                <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="vg2" ShowMessageBox="true" ShowSummary="false" runat="server" />
            </div>
        </div>
        <div class="col-lg-4">
            <div class="form-group">
                <asp:Label ID="cmb2Provinsi" runat="server" for="CmbPropinsi">Propinsi</asp:Label>
                <asp:DropDownList ID="CmbPropinsi" OnSelectedIndexChanged="CmbPropinsi_SelectedIndexChanged" AutoPostBack="true" class="form-control" aria-describedby="desc3" placeholder="Propinsi" runat="server"></asp:DropDownList>
                <small id="desc3" class="form-text text-muted">
                    <asp:Label runat="server" ID="spp"></asp:Label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="vg2" runat="server" ControlToValidate="CmbPropinsi" ErrorMessage="Silakan pilih propinsi"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:Label ID="cmb2Kabupaten" runat="server" for="CmbKabupaten">Kabupaten</asp:Label>
                <asp:DropDownList ID="CmbKabupaten" OnSelectedIndexChanged="CmbKabupaten_SelectedIndexChanged" AutoPostBack="true" class="form-control" aria-describedby="desc4" placeholder="Kabupaten" runat="server"></asp:DropDownList>
                <small id="desc4" class="form-text text-muted">
                    <asp:Label runat="server" ID="spk"></asp:Label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="vg2" runat="server" ControlToValidate="CmbKabupaten" ErrorMessage="Silakan pilih kabupaten"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:Label ID="cmb2Kecamatan" runat="server" for="CmbKecamatan">Kecamatan</asp:Label>
                <asp:DropDownList ID="CmbKecamatan" OnSelectedIndexChanged="CmbKecamatan_SelectedIndexChanged" AutoPostBack="true" class="form-control" aria-describedby="desc4" placeholder="Kecamatan" runat="server"></asp:DropDownList>
                <small id="desc5" class="form-text text-muted">
                    <asp:Label runat="server" ID="sknk"></asp:Label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="vg2" runat="server" ControlToValidate="CmbKecamatan" ErrorMessage="Silakan isi kecamatan"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:Label ID="cmb2Desa" runat="server" for="CmbDesa">Desa</asp:Label>
                <asp:DropDownList ID="CmbDesa" class="form-control" aria-describedby="desc4" placeholder="Desa" runat="server"></asp:DropDownList>
                <small id="desc6" class="form-text text-muted">
                    <asp:Label runat="server" ID="sknd"></asp:Label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="vg2" runat="server" ControlToValidate="CmbDesa" ErrorMessage="Silakan isi desa"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:Label ID="lblLokasi" runat="server" for="TxtLokasi">Lokasi GPS</asp:Label>
                <div class="row">
                    <div class="col-lg-5">
                        <asp:TextBox TextMode="SingleLine" ID="TxtLatitude" Text="0" class="form-control" aria-describedby="desc8" placeholder="Latitude" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-lg-5 ml-1">
                        <asp:TextBox TextMode="SingleLine" ID="TxtLongitude" Text="0" class="form-control" aria-describedby="desc8" placeholder="Longitude" runat="server"></asp:TextBox>
                    </div>
                </div>

                <small id="desc8" class="form-text text-muted">
                    <asp:Label runat="server" ID="sildl"></asp:Label></small>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="vg2" runat="server" ControlToValidate="TxtLatitude" ErrorMessage="Silakan isi latitude"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="vg2" runat="server" ControlToValidate="TxtLongitude" ErrorMessage="Silakan is longitude"></asp:RequiredFieldValidator>

            </div>
        </div>
    </div>
    <div class="row mt-2" id="DivRow12" visible="false" runat="server">
        <div class="col-lg tree-nav-container">

            <custom:nav ID="OrderNav" runat="server" Mode="TreeNav"></custom:nav>

        </div>

    </div>
    <%--Ini untuk Konfirmasi--%>
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
                            <asp:Label ID="jnsAnalisis" for="tanggal" runat="server">Jenis Analisis</asp:Label>
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

                <asp:GridView CssClass="table table-bordered table-hover" ID="GvSample2" runat="server" AutoGenerateColumns="false" AllowPaging="false">
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
                    </Columns>
                </asp:GridView>
                <%--Untuk notif--%>
                <script>

</script>
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

                <asp:GridView CssClass="table table-bordered table-hover" ID="GvParameter2" runat="server" AutoGenerateColumns="false" AllowPaging="false">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblPilih" runat="server">Pilih</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="isChecked" Checked="true" runat="server" Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Parameter Uji" Visible="false">
                            <ItemTemplate>
                                <asp:HiddenField ID="HidMandatory" Value='<%# Eval("isMandatory") %>' runat="server" />
                                <asp:Label runat="server" ID="txtParameterId" Text='<%# Eval("elementId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Parameter Uji">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="txtParameterUji" Text='<%# Eval("elementCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tarif per Contoh">
                            <ItemTemplate>
                                <b>
                                    <asp:Label runat="server" ID="txtTarif" Text='<%# float.Parse( Eval("serviceRate").ToString()) %>'></asp:Label></b>
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
                <div id="SpanHargaPaket2" class="alert alert-info" runat="server" visible="false">
                    <b>Harga Paket : Rp.<asp:Literal ID="LitTotalHargaPaket2" runat="server"></asp:Literal></b>
                    <br />
                    <p>
                        *) harga paket tidak dihitung per-parameter tapi harga paket dikali jumlah sampel
                    </p>
                </div>
                <div id="SpanTambahanHarga" class="alert alert-success" runat="server" visible="false">
                    <b>
                        <asp:Literal ID="litTambahanHarga" runat="server"></asp:Literal>
                    </b>
                </div>
                <%-- Script untuk GvSample --%>
                <script>
                    function requstDuplicate() {
                        var total = prompt("Masukan total yang ingin di duplikat", "1");
                        if (total != null && total != "") {
                            document.getElementById("<%=DuplicateRequestInput.ClientID%>").value = total;
                            }
                            else {
                                document.getElementById("<%=DuplicateRequestInput.ClientID%>").value = "0";
                        }
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
                        //initForm2();
                        initForm3();
                        initForm4();
                        setFontResizer();
                        //initForm2();
                        //setFontResizer();
                    });
                    function setFontResizer() {
                        $('#linkincrease').click(function () {
                            $('body').css('font-size', '+=3');
                        });

                        $('#linkdecrease').click(function () {
                            $('body').css('font-size', '-=3');
                        });
                    }
                    function initForm2() {
                        var grid = (document.getElementById("<%=GvData.ClientID%>")) ? document.getElementById("<%=GvData.ClientID%>") : null;
                            if (grid) {
                                if (grid.rows.length > 1) {
                                    fixGridView($("#<%=GvData.ClientID%>"));
                                    $('#<%=GvData.ClientID%>').DataTable();
                            }
                        }


                    }
                    function initForm3() {
                        var grid = (document.getElementById("<%=GvSample2.ClientID%>")) ? document.getElementById("<%=GvSample2.ClientID%>") : null;
                            if (grid) {
                                if (grid.rows.length > 1) {
                                    fixGridView($("#<%=GvSample2.ClientID%>"));

                                    $('#<%=GvSample2.ClientID%>').DataTable();
                            }
                        }

                    }

                    function initForm4() {
                        var grid = (document.getElementById("<%=GvParameter2.ClientID%>")) ? document.getElementById("<%=GvParameter2.ClientID%>") : null;
                            if (grid) {
                                if (grid.rows.length > 1) {
                                    fixGridView($("#<%=GvParameter2.ClientID%>"));
                                    $('#<%=GvParameter2.ClientID%>').DataTable();
                            }
                        }

                    }
                        /*
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    if (prm != null) {
                        prm.add_endRequest(function (sender, e) {
                            if (sender._postBackSettings.panelsToUpdate != null) {
                                initForm2();
                                initForm3();
                                initForm4();
                                setFontResizer();
                            }
                        });
                    };*/
                </script>
            </div>
        </div>
    </div>
    <div class="row mt-2 alert alert-info" visible="false" id="DivHarga" runat="server" style="margin: 25px 0px 15px !important;">
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblJmlParamUji" runat="server">Jumlah Parameter Uji:</asp:Label>
                <asp:Literal ID="LitJmlParamUji" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblJmlSampel" runat="server">Jumlah Sampel:</asp:Label>
                <asp:Literal ID="LitJmlSampel" runat="server"></asp:Literal>
            </b>
        </div>
        <div class="col-lg-3">
            <b>
                <asp:Label ID="lblTotBiaya" runat="server">Total Biaya: Rp </asp:Label>
                <asp:Literal ID="LitTotBiaya" runat="server"></asp:Literal>
            </b>
        </div>
    </div>
    <br>
    <div class="row mt-2" runat="server" id="DivAgreement" visible="false">
        <div class="col-lg-8">
            <asp:CheckBox ID="ChkSetuju" OnCheckedChanged="ChkSetuju_CheckedChanged" AutoPostBack="true" runat="server" />
            <h5><b>
                <asp:Label ID="SayaSetuju" for="" runat="server">Saya menyetujui untuk melanjutkan pesanan ini sesuai dengan standar prosedur yang berlaku di Balitanah</asp:Label></b></h5>
            <asp:Button ID="BtnSOP" CssClass="btn btn-success" runat="server" Text="Standar Prosedur" CommandName="SOP" OnClick="ActionButton" />
            <br>
            <br>
        </div>
    </div>

    <div class="row mt-2" runat="server" id="DivButton" visible="false">
        <div class="col-lg">
            <asp:Button ID="BtnKembali" CssClass="btn btn-warning" runat="server" Text="Kembali" CommandName="cancel-sampel" OnClick="ActionButton" />
            <asp:Button ID="BtnSetuju" Enabled="false" CssClass="btn btn-info" runat="server" Text="Setuju" CommandName="save" OnClick="ActionButton" OnClientClick="notifyAddData()" />
        </div>
    </div>

    <div class="row mt-2" id="DivSOP" runat="server" visible="false">

        <div class="col-lg text-center">
            <img src="../../../assets/img/SOP.png" width="900" alt="sop" />
        </div>

    </div>
    <div class="row mt-2" id="DivBtnTutup" runat="server" visible="false">

        <div class="col-lg text-center">
            <asp:Button ID="BtnTutup" CssClass="btn btn-warning" runat="server" Text="Tutup" CommandName="close" OnClick="ActionButton" />
        </div>
    </div>
    <script>
        function notifyAddData() {
            if (Notification.permission !== 'granted')
                Notification.requestPermission();
            else {
                var notification = new Notification('Notifikasi untuk anda', {
                    icon: 'http://cdn.sstatic.net/stackexchange/img/logos/so/so-icon.png',
                    body: 'Data baru berhasil ditambahkan!',
                });
            }
        }

        document.addEventListener('DOMContentLoaded', function () {
            if (!Notification) {
                alert('Push notification tidak tersedia pada browser ini.');
                return;
            }

            if (Notification.permission !== 'granted')
                Notification.requestPermission();
        });
    </script>
</asp:Content>

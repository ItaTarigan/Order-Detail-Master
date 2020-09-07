<%@ Page Language="C#" MasterPageFile="~/Pages/Master/SinglePage.Master" AutoEventWireup="true" CodeBehind="CustomerPesananBaru.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.CustomerPesananBaru"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="MainPanel" runat="server">
                <div>                    
                  <h3>Tambah Pesanan Baru</h3>
                    <h5>silahkan input data dengan akurat untuk melakukan pesanan baru</h5>
                </div>
                <div>
                    <div class="row">
                        <label for="tanggalterima">Tanggal Terima</label>
                        <asp:TextBox ID="txtTanggalTerima" runat="server" name="tanggalterima" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="row">
                        <label for="jenisanalisis">Pilih Jenis Analisis</label>
                        <asp:DropDownList ID="txtJenisAnalisis" runat="server" CssClass="form-control" name="jenisanalisis" OnSelectedIndexChanged="GenerateParameterUji" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="row">
                        <label for="komoditas">Pilih Komoditas</label>
                        <asp:DropDownList ID="txtKomoditas" runat="server" CssClass="form-control" name="komoditas" OnSelectedIndexChanged="GenerateChildKomoditas" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="row">
                        <label for="komoditaschild">Pilih Sub Komoditas</label>
                        <asp:DropDownList ID="txtKomoditasChild" runat="server" CssClass="form-control" name="komoditaschild" OnSelectedIndexChanged="GenerateParameterUji" AppendDataBoundItems="true" AutoPostBack="true">
                            <asp:ListItem Text="Pilih" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="row">       
                        <div class="row">                            
                        <label for="parameteruji">Daftar Prameter Uji</label>
                        </div>
                        <div class="row">
                        <asp:GridView ID="GvParameter" runat="server" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                            CellPadding="4" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox CssClass="form-control" ID="checkedAll" OnCheckedChanged="CheckedAll" runat="server" AutoPostBack="true"/>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox CssClass="form-control" ID="isChecked" runat="server" OnCheckedChanged="DoChecked" AutoPostBack="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parameter Uji">
                                    <ItemTemplate>
                                        <asp:Label CssClass="form-control" ID="txtParameterUji" runat="server" Text='<%# Bind("elementCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tarif Percontoh">
                                    <ItemTemplate>
                                        <asp:Label CssClass="form-control" ID="txtTarif" runat="server" Text='<%# Bind("elementservicestbl.serviceRate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Jumlah Contoh">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="form-control" TextMode="Number" ID="txtJumlahContoh" runat="server" Text="0" OnTextChanged="CalculateTotal" AutoPostBack="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Biaya">
                                    <ItemTemplate>
                                        <asp:Label CssClass="form-control" ID="txtBiaya" runat="server" Text="0,00"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />  
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />  
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />  
                            <RowStyle BackColor="#F7F7DE" />  
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />  
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />  
                            <SortedAscendingHeaderStyle BackColor="#848384" />  
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />  
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>

                        </div>
                    </div>               
                </div>
                <div>
                <div class="row">
                    <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" 
                        ShowHeaderWhenEmpty="true" EmptyDataText="Silahkan Masukan Sampel" AutoGenerateColumns="false" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                        BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                         <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="countNumber" HeaderText="Nomor Urut" />
                            <asp:BoundField DataField="sampleCode" HeaderText="No Sampel" />
                            <asp:BoundField DataField="noBalittanah" HeaderText="No Balittanah" />
                            <asp:BoundField DataField="village" HeaderText="Desa" />
                            <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                            <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                            <asp:BoundField DataField="province" HeaderText="Propinsi" />
                            <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                            <asp:BoundField DataField="gpsCoordinat" HeaderText="Koordinat Gps" /> 
                            <asp:TemplateField HeaderText="Tindakan">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="Hapus" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="hapus" AlternateText="Hapus" OnClick="ActionImageButton"></asp:ImageButton>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="Duplikat" runat="server" CommandArgument='<%# Eval("countNumber") %>' CommandName="duplikat" AlternateText="Duplikat" OnClick="ActionImageButton"></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />  
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />  
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />  
                        <RowStyle BackColor="#F7F7DE" />  
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />  
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />  
                        <SortedAscendingHeaderStyle BackColor="#848384" />  
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />  
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </div>
                <div class="row">
                    <asp:TextBox CssClass="form-control" ID="txtInputNoSample" runat="server"></asp:TextBox>
                    <%--<asp:Label CssClass="form-control" ID="txtInputNoBalittanah" runat="server"></asp:Label>--%>
                    <asp:TextBox CssClass="form-control" ID="txtInputDesa" runat="server"></asp:TextBox>
                    <asp:TextBox CssClass="form-control" ID="txtInputKecamatan" runat="server"></asp:TextBox>
                    <asp:TextBox CssClass="form-control" ID="txtInputKabupaten" runat="server"></asp:TextBox>
                    <asp:TextBox CssClass="form-control" ID="txtInputPropinsi" runat="server"></asp:TextBox>
                    <asp:DropDownList CssClass="form-control" ID="txtInputTipeSampel" runat="server">
                    </asp:DropDownList>
                    <asp:TextBox CssClass="form-control" ID="txtGps" runat="server"></asp:TextBox>
                    <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Tambah Data" CommandName="add" OnClick="ActionButton" />
                </div>
                </div>
            </asp:Panel>
            <div class="row">
                <label>Jumlah Parameter Uji</label>
                <asp:Label CssClass="form-control" ID="txtTotalParameter" runat="server" Text="0"></asp:Label>
                <label>Jumlah Sampel</label>
                <asp:Label CssClass="form-control" ID="txtJumlahSampel" runat="server" Text ="0"></asp:Label>
                <label>Jumlah Harga</label>
                <asp:Label CssClass="form-control" ID="txtJumlahHarga" runat="server" Text="0"></asp:Label>
            </div>
            <div class="row">
                <asp:Button CssClass="btn btn-success" ID="btnSave" runat="server" Text="Simpan" CommandName="save" OnClick="ActionButton" />
                <asp:Button CssClass="btn btn-success" ID="btnCancel" runat="server" Text="Batalkan" CommandName="cancel" OnClick="ActionButton" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/assets/img/ajax-loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>

</asp:Content>


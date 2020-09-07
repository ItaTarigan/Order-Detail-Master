<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="DaftarSuratPermohonan.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.DaftarSuratPermohonan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group">
                <label for="comodityNo">Pilih Komoditas :</label>
                <asp:DropDownList ID="DDLComodity" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="analysisType">Pilih Jenis Analisa :</label>
                <asp:DropDownList ID="DDLAnalysis" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="daftarLayanan">Daftar Layanan :</label>
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvDataLayanan" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                    <asp:TemplateField HeaderText="Tindakan">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="CBLLayanan" runat="server"></asp:CheckBox>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="elementCode" HeaderText="Jenis Analisa" />--%>
                    <asp:BoundField DataField="priceTotal" HeaderText="Harga" />
                </Columns>
            </asp:GridView>
            </div>
            <div class="form-group">
                <label for="daftarSample">Daftar Sample :</label>
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvDataSample" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                <Columns>
                    <asp:BoundField DataField="noBalittanah" HeaderText="No Sample" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tfoot>
                                    <label for="noSample">Nomor Sample :</label>
                                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="Txt1" TextMode="SingleLine" CssClass="form-control" name="noSample"></asp:TextBox>
                                </tfoot>
                            </table>                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="village" HeaderText="Desa" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tfoot>
                                    <asp:DropDownList ID="DDL1" CssClass="form-control" runat="server"></asp:DropDownList>
                                </tfoot>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tfoot>
                                    <asp:DropDownList ID="DDL2" CssClass="form-control" runat="server"></asp:DropDownList>
                                </tfoot>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tfoot>
                                    <asp:DropDownList ID="DDL3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </tfoot>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="province" HeaderText="Provinsi" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tfoot>
                                    <asp:DropDownList ID="DDL4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </tfoot>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tindakan"> 
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:LinkButton  OnClientClick="return confirm('Apakah yakin ingin menghapus ?');" ID="Delete" ForeColor="Red" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="hapus" Text="Hapus"><i class='fa fa-trash'></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
            <div class="form-group">
                <label for="noSample">Nomor Sample :</label>
                <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtNoSample" TextMode="SingleLine" CssClass="form-control" name="noSample"></asp:TextBox>
                <asp:DropDownList ID="DDLDesa" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="DDLKecamatan" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="DDLKabupaten" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="DDLProvinsi" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Jumlah Analisis :</label>
                <label>0</label>
                <label>Jumlah Sample :</label>
                <label>0</label>
                <label>Jumlah Harga :</label>
                <label>0</label>
            </div>
            <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Tambah Sample" CommandName="addsample" OnClick="ActionButton"/>
            <asp:Button ID="BtnPesan" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" CommandName="pesan" Text="Pesan" OnClick="ActionButton" />
            <asp:Button ID="BtnPrint" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" CommandName="print" Text="Print" OnClick="ActionButton" />
            <asp:Button ID="BtnBatalkan" CssClass="btn btn-danger" runat="server" CommandName="batal" Text="Batalkan" OnClick="ActionButton" />
            <asp:ValidationSummary ValidationGroup="vg1" ShowSummary="false" ShowMessageBox="false" ID="ValidationSummary1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
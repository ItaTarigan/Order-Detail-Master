<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Customer.Master" AutoEventWireup="true" CodeBehind="FormKajiUlang.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.FormKajiUlang" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="row mt-2" runat="server">
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div id="divContent" class="divClass">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="MainPanel" runat="server">
                <div class="row">
                    <div class="col-sm-5">
                        <h3>Formulir Kaji Ulang</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label for="noorder">No Pesanan:</label>
                        <asp:Label ID="TxtNoOrder" runat="server" name="noorder" Text="01212121221"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label for="receiptdate">Tanggal Terima:</label>
                        <asp:TextBox ID="TxtReceiptDate" runat="server" TextMode="Date" CssClass="form-control" name="receiptDate"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label for="customername">Nama Pengirim:</label>
                        <asp:Label ID="TxtCustomerName" runat="server" name="noorder" Text="nama pengirim"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label for="companyname">Nama Perusahaan:</label>
                        <asp:Label ID="TxtCompanyName" runat="server" name="companyname" Text="company name"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label for="companyaddress">Alamat Perusahaan:</label>
                        <asp:TextBox ID="TxtCompanyAddress" runat="server" TextMode="MultiLine" CssClass="form-control" name="companyname" Text="company name"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label for="sampletotal">Jumlah Contoh:</label>
                        <asp:Label ID="TxtSampleTotal" runat="server" name="sampletotal" Text="1"></asp:Label>
                        <label for="comodityname">Dari Komoditas:</label>
                        <asp:Label ID="TxtComodityType" runat="server" name="comodityname" Text="Tanah"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label for="elementcode">Parameter Uji :</label>
                        <asp:GridView ID="GvParam" runat="server" OnRowCommand="GvParam_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="action">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="isChecked" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parameter Uji">
                                    <ItemTemplate>
                                        <asp:Label ID="txtParameterUji" runat="server" Text='<%# Bind("elementservicestbl.elementCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label>Alat Laboratorium Sudah Memadai:</label>
                        <asp:RadioButton ID="TxtLabUtility1" GroupName="labutilitygroup" runat="server" Text="Ya"></asp:RadioButton>
                        <asp:RadioButton ID="TxtLabUtility2" GroupName="labutilitygroup" runat="server" Text="Tidak"></asp:RadioButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label>Sumber Daya Manusia Sudah Memadai:</label>
                        <asp:RadioButton ID="TxtLabHumanResource1" GroupName="labhumanresourcegroup" runat="server" Text="Ya"></asp:RadioButton>
                        <asp:RadioButton ID="TxtLabHumanResource2" GroupName="labhumanresourcegroup" runat="server" Text="Tidak"></asp:RadioButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label>Bahan Kimia:</label>
                        <asp:RadioButton ID="TxtLabChemicalMat1" GroupName="labchemicalmatgroup" runat="server" Text="Ya"></asp:RadioButton>
                        <asp:RadioButton ID="TxtLabChemicalMat2" GroupName="labchemicalmatgroup" runat="server" Text="Tidak"></asp:RadioButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label>Volume/Berat Contoh:</label>
                        <asp:RadioButton ID="TxtVolume1" GroupName="labvolumegroup" runat="server" Text="Sesuai"></asp:RadioButton>
                        <asp:RadioButton ID="TxtVolume2" GroupName="labvolumegroup" runat="server" Text="Tidak"></asp:RadioButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label for="workday">Jangka Waktu Penyelesaian:</label>
                        <asp:TextBox ID="TxtWorkDay" runat="server" TextMode="Number" CssClass="form-control" name="workday" Text="workday"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label>Metode:</label>
                        <asp:RadioButton ID="TxtMethode1" GroupName="labmethodegroup" runat="server" Text="Ya"></asp:RadioButton>
                        <asp:RadioButton ID="TxtMethode2" GroupName="labmethodegroup" runat="server" Text="Tidak"></asp:RadioButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label>Standar Mutu:</label>
                        <asp:RadioButton ID="TxtQualityStandard1" GroupName="labqualitystandardgroup" runat="server" Text="Ya"></asp:RadioButton>
                        <asp:RadioButton ID="TxtQualityStandard2" GroupName="labqualitystandardgroup" runat="server" Text="Tidak"></asp:RadioButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <asp:Button ID="BtnSave" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Simpan" CommandName="save" OnClick="ActionButton" />
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Kembali" CommandName="cancel" OnClick="ActionButton" />
                    </div>
                </div>
            </asp:Panel>
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
                     fixGridView($("#<%=GvParam.ClientID%>"));

                     $('#<%=GvParam.ClientID%>').DataTable();
                     $('#linkincrease').click(function () {
                         $('#divContent').css('font-size', '+=3');
                     });

                     $('#linkdecrease').click(function () {
                         $('#divContent').css('font-size', '-=3');
                     });
                });
            </script>
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
</script>
</div>
</asp:Content>

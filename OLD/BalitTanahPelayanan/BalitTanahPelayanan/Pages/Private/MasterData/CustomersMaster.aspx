<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Admin.Master" AutoEventWireup="true" CodeBehind="CustomersMaster.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.MasterData.Customers" %>

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
                    <label for="search">Cari Pelanggan:</label>
                    <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                    <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
                </div>--%>
                <asp:GridView CssClass="table table-bordered table-hover dataTable" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="customerNo" HeaderText="Kode" />
                        <asp:BoundField DataField="customerName" HeaderText="Pelanggan" />
                        <asp:BoundField DataField="customerEmail" HeaderText="Email" />
                        <asp:BoundField DataField="companyName" HeaderText="Perusahaan" />
                        <asp:BoundField DataField="companyAddress" HeaderText="Alamat Perusahaan" />
                        <asp:BoundField DataField="companyPhone" HeaderText="Nomor Telpon Perusahaan" />
                        <asp:BoundField DataField="companyEmail" HeaderText="Email Perusahaan" />
                        <asp:BoundField DataField="accountNo" HeaderText="Kode Akun" />
                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CssClass="linkbtn" CommandArgument='<%# Eval("customerNo") %>' CommandName="ubah" Text="Ubah"></asp:LinkButton>
                                <asp:LinkButton ID="btnLihat" runat="server" CssClass="linkbtn" CommandArgument='<%# Eval("customerNo")%>' CommandName="lihat" Text="Lihat"></asp:LinkButton>
                                <asp:LinkButton ID="btnHapus" runat="server" CssClass="linkbtn" CommandArgument='<%# Eval("customerNo") %>' CommandName="hapus" Text="Hapus" OnClientClick="return confirm('Apakah yakin ingin menghapus?');"></asp:LinkButton>  
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
                <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Tambah Data" CommandName="add" OnClick="ActionButton"/>
            </asp:Panel>
            <asp:Panel ID="PanelInput" Visible="false" runat="server">
                <div class="form-group">
                    <label>Kode Pelanggan:</label>
                    <asp:Label ID="TxtCustomerNo" runat="server" Visible="true" Text="Otomatis"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="customername">Nama Pelanggan:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtCustomerName" TextMode="SingleLine" CssClass="form-control" name="customername"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtCustomerName" ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Silahkan isi nama pelanggan"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="cusemail">Email Pelanggan:</label>
                    <asp:TextBox runat="server" ID="TxtCusEmail" TextMode="SingleLine" CssClass="form-control" name="cusemail"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtCusEmail" ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Silahkan isi email pelanggan"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="Invalid Email" ControlToValidate="TxtCusEmail"
                        SetFocusOnError="True"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="companyname">Nama Perusahaan:</label>
                    <asp:TextBox runat="server" ID="TxtCompanyName" TextMode="SingleLine" CssClass="form-control" name="companyname"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtCompanyName" ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Silahkan isi nama perusahaan"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="comaddress">Alamat Perusahaan:</label>
                    <asp:TextBox runat="server" ID="TxtCompanyAddress" TextMode="MultiLine" CssClass="form-control" name="comaddress"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtCompanyAddress" ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Silahkan isi alamat perusahaan"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="commphone">Nomor Telpon Perusahaan</label>
                    <asp:TextBox runat="server" ID="TxtPhoneNo" TextMode="SingleLine" CssClass="form-control" name="comphone" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="TxtPhoneNo" ValidationGroup="vg1" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Silahkan isi nomor telpon perusahaan"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="commpemail">Email Perusahaan</label>
                    <asp:TextBox runat="server" ID="TxtComEmail" TextMode="SingleLine" CssClass="form-control" name="comphone"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ControlToValidate="TxtComEmail" ValidationGroup="vg1" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Silahkan isi email perusahaan"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ErrorMessage="Invalid Email" ControlToValidate="TxtComEmail"
                        SetFocusOnError="True"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="accountno">Kode Akun</label>
                    <asp:DropDownList runat="server" ID="TxtAccountNo" CssClass="form-control" name="accountno" AppendDataBoundItems="true"></asp:DropDownList>
                </div>
                <asp:Button ID="BtnSave" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Simpan" CommandName="save" OnClick="ActionButton"/>
                <asp:Button ID="BtnUpdate" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Ubah" CommandName="update" OnClick="ActionButton"/>
                <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Kembali" CommandName="cancel" OnClick="ActionButton"/>
                <asp:ValidationSummary ValidationGroup="vg1" ShowSummary="false" ShowMessageBox="false" ID="ValidationSummary1" runat="server" />
            </asp:Panel>
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

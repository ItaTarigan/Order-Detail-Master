<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Admin.Master" AutoEventWireup="true" CodeBehind="ParametersMaster.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.MasterData.ParametersMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript" src="../../../assets/js/scripts.js" />
    <link rel="stylesheet" href="../../../assets/css/fonts.css">
    <link rel="stylesheet" href="../../../assets/css/styles.css">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
            <asp:Panel ID="PanelInput" Visible="false" runat="server">
                <div class="form-group">
                    <label >Kode Parameter:</label>
                    <asp:Label ID="TxtParameterNo" runat="server" Visible="true" Text="Otomatis"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="string0">string0:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString0" TextMode="SingleLine" CssClass="form-control" name="string0"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="string1">string1:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString1" TextMode="SingleLine" CssClass="form-control" name="string1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="string2">string2:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString2" TextMode="SingleLine" CssClass="form-control" name="string2"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="string3">string3:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString3" TextMode="SingleLine" CssClass="form-control" name="string3"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="string4">string4:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString4" TextMode="SingleLine" CssClass="form-control" name="string4"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="string5">string5:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString5" TextMode="SingleLine" CssClass="form-control" name="string5"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="string6">string6:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString6" TextMode="SingleLine" CssClass="form-control" name="string6"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="string7">string7:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString7" TextMode="SingleLine" CssClass="form-control" name="string7"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="string8">string8:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString8" TextMode="SingleLine" CssClass="form-control" name="string8"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="string9">string9:</label>
                    <asp:TextBox runat="server" ValidationGroup="vg1" ID="TxtString9" TextMode="SingleLine" CssClass="form-control" name="string9"></asp:TextBox>
                </div>
                <asp:Button ID="BtnSave" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Simpan" CommandName="save" OnClick="ActionButton"/>
                <asp:Button ID="BtnUpdate" ValidationGroup="vg1" CssClass="btn btn-success" runat="server" Text="Ubah" CommandName="update" OnClick="ActionButton"/>
                <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Kembali" CommandName="cancel" OnClick="ActionButton"/>
                <asp:ValidationSummary ValidationGroup="vg1" ShowSummary="false" ShowMessageBox="false" ID="ValidationSummary1" runat="server" />
            </asp:Panel>
            <asp:Panel ID="PanelGrid" runat="server">
                <asp:GridView CssClass="table table-bordered table-hover dataTable" ID="GvData" runat="server" AutoGenerateColumns="true" AllowCustomPaging="true" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CssClass="linkbtn" CommandArgument='<%# Eval("parametersNo") %>' CommandName="edit" Text="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="btnLihat" runat="server" CssClass="linkbtn" CommandArgument='<%# Eval("parametersNo") %>' CommandName="lihat" Text="Lihat"></asp:LinkButton>                               
                            </ItemTemplate>
                        </asp:TemplateField>             
                    </Columns>
                </asp:GridView>
                <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Tambah Data" CommandName="add" OnClick="ActionButton"/>
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
                    $('#divContent').css('font-size', '+=3');
                });

                $('#linkdecrease').click(function () {
                    $('#divContent').css('font-size', '-=3');
                });
            });
    </script>

</asp:Content>


<%@ Page Title="Customer Service" Language="C#" MasterPageFile="~/Pages/Master/CS.Master" AutoEventWireup="true" CodeBehind="CustomerServiceDetail.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.CS.CustomerServiceDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="row mt-2" runat="server">
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div class="row mt-2" runat="server" id="DivRow1">
        <div class="col-lg">
            <h2><asp:Literal ID="litRincianNoPesanan" runat="server"></asp:Literal>:<asp:Label ID="lblorder" runat="server"></asp:Label></h2>
        </div>
    </div>
    
    <div id="divContent" class="divClass">
        <div class="row mt-2" runat="server" id="DivRow2">
            <div class="col-lg-4">
                <div class="card">

                    <div class="card-body" style="background-color: lightgray;">

                        <p class="card-text">
                            <b>
                                <asp:Label ID="name" for="" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="lblcusname" runat="server"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="komoditas" for="" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="lblKomoditi" runat="server"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label ID="analisystype" for="" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="lblanalisis" runat="server"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label for="" id="sampletotal" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="lblSampel" runat="server"></asp:Label>
                        </p>
                        <p class="card-text">
                            <b>
                                <asp:Label for="" id="pricetotal" runat="server"></asp:Label>
                            </b>
                            <asp:Label ID="lblTotalHarga" runat="server"></asp:Label>
                        </p>
                    </div>
                    
                </div>
            </div>
            <div class="col-lg-4">
                <div class="card">
                    <div class="card-body" runat="server" id="DivDownload" visible="false">
                        <h5 class="card-title"> <asp:Label ID="lhpresult" runat="server"></asp:Label></h5>
                        <asp:Button ID="BtnDownload" runat="server" CssClass="btn btn-primary" Text="Download" />
                    </div>
                </div>
                 
            </div>
            <div class="col-lg-4" runat="server" id="DivDownloadLampiran" visible="false">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Download Lampiran</h5>
                        <asp:Button ID="BtnDownloadLampiran" CssClass="btn btn-primary" runat="server" Text="Download" />

                    </div>
                </div>
            </div>
            <div class="col-lg-8">
                <asp:GridView CssClass="table table-bordered table-hover" ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="elementCode" HeaderText="Parameter Uji" />
                        <asp:BoundField DataField="status" HeaderText="Status Pengujian" />
                        <asp:TemplateField HeaderText="Hasil">
                            <ItemTemplate>
                                <asp:LinkButton ID="Lihat" CommandArgument='<%# Eval("fileAttachmentUrl") %>' CommandName="DownloadParameter" runat="server" Text="Download">Download</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <%--<div class="col-lg-4" id="DivDownload" runat="server" visible="false">
                <div class="card">
                   <div class="card-body">
                        <h5 class="card-title">Hasil (LHP)</h5>
                        <asp:Button ID="BtnDownload" runat="server" CssClass="btn btn-primary" Text="Download" />
                    </div>
                </div>
            </div>--%>

        </div>
        <div class="row mt-2" runat="server" id="DivRow3">
            <div class="col-lg">
                <h3> <asp:Label ID="samplelist" runat="server"></asp:Label></h3>
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow4">
            <div class="col-lg">
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="countNumber" HeaderText="No Urut" />
                        <asp:BoundField DataField="sampleCode" HeaderText="No Sampel" />
                        <asp:BoundField DataField="noBalittanah" HeaderText="No Balitanah" />
                        <asp:BoundField DataField="village" HeaderText="Desa" />
                        <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                        <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                        <asp:BoundField DataField="province" HeaderText="Propinsi" />
                        <%--<asp:BoundField DataField="longitude" HeaderText="GPS" />--%>
                        <asp:TemplateField HeaderText="GPS">
                            <ItemTemplate>

                                <asp:Label ID="Loc" runat="server" Text='<%# Eval("latitude")+","+Eval("longitude") %>'>Parameter Uji</asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                        <asp:TemplateField HeaderText="Progress">
                            <ItemTemplate>

                                <asp:Label ID="LblProgress" runat="server" Text="%"></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sampel Diterima">
                            <HeaderTemplate>
                                <asp:CheckBox ID="ChkReceivedHeader" AutoPostBack="true" OnCheckedChanged="ChkReceivedHeader_CheckedChanged" runat="server" />
                                Sampel Diterima
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="HidReceived" Value='<%# Eval("isReceived") %>' runat="server" />
                                <asp:CheckBox ID="ChkReceived" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>

                                <asp:LinkButton ID="Lihat" runat="server" CommandArgument='<%# Eval("noBalittanah") %>' CommandName="DetailorderList" Text="Lihat">Parameter Uji</asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
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
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow5" visible="false">
            <div class="col-lg-6">
                <div class="card" >
                  <div class="card-body">
                    <h5 class="card-title">Keterangan</h5>
                      <asp:TextBox ID="TxtKeterangan" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                  </div>
                </div>
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow6">
            <div class="col-lg">
                <asp:Button ID="BtnKembali" CssClass="btn btn-primary" OnClick="BtnKembali_Click" runat="server" Text="Kembali" />
                <asp:Button ID="BtnSimpan" CssClass="btn btn-info" Visible="false" OnClick="BtnSimpan_Click" runat="server" Text="Simpan" />
                <asp:Button ID="BtnApprove" CssClass="btn btn-success" Visible="false" onclick="BtnApprove_Click" runat="server" Text="Setujui" />
                <asp:Button ID="BtnReject" CssClass="btn btn-warning" Visible="false" OnClick="BtnReject_Click" runat="server" Text="Analisis Ulang" />
            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow7" visible="false">
            <div class="col-lg">
                <asp:GridView CssClass="table table-bordered table-hover" ID="GvParameter" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="elementservicestbl.elementCode" HeaderText="Parameter Uji" />
                        <asp:BoundField DataField="status" HeaderText="Status Pengujian" />
                        <asp:TemplateField HeaderText="Hasil">
                            <ItemTemplate>
                                <asp:LinkButton ID="Lihat" CommandArgument='<%# Eval("fileAttachmentUrl") %>' CommandName="DownloadParameter" runat="server" Text="Download">Download</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
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
                        fixGridView($("#<%=GvParameter.ClientID%>"));

                        $('#<%=GvParameter.ClientID%>').DataTable();
                        $('#linkincrease').click(function () {
                            $('#divContent').css('font-size', '+=3');
                        });

                        $('#linkdecrease').click(function () {
                            $('#divContent').css('font-size', '-=3');
                        });
                    });
                </script>


            </div>
        </div>
        <div class="row mt-2" runat="server" id="DivRow8" visible="false">
            <div class="col-lg">
                <asp:Button ID="BtnTutup" CssClass="btn btn-info" runat="server" Text="Tutup" />
            </div>
        </div>
    </div>
</asp:Content>

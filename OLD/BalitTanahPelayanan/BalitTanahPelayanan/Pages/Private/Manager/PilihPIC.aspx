<%@ Page Language="C#" MasterPageFile="~/Pages/Master/ManagerTeknis.Master" AutoEventWireup="true" CodeBehind="PilihPIC.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Manager.PilihPIC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="row mt-2">
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="LblFontSize" runat="server" Style="font-size: 14px; font-weight: bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div>
    <div id="divContent" class="divClass">
    <div class="row mt-2">
        <div class="col-lg">
            <h2>Rincian No Pesanan:<asp:Label ID="lblorder" runat="server"></asp:Label></h2>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg-4">
            <div class="card">

                <div class="card-body" style="background-color: lightgray;">

                    <p class="card-text">
                        <b>
                            <label for="">Nama Pelanggan : </label>
                        </b>
                        <asp:Label ID="lblcusname" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Komoditas : </label>
                        </b>
                        <asp:Label ID="lblKomoditi" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Tipe Analis : </label>
                        </b>
                        <asp:Label ID="lblanalisis" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Total Sample : </label>
                        </b>
                        <asp:Label ID="lblSampel" runat="server"></asp:Label>
                    </p>
                    <p class="card-text">
                        <b>
                            <label for="">Total Harga : </label>
                        </b>
                        <asp:Label ID="lblTotalHarga" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvParameter" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="elementCode" HeaderText="Parameter Uji" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body" style="background-color: white;">
                    <h5 class="card-title">Nama PIC</h5>
                    <p class="card-text">
                        <asp:DropDownList ID="DdlPIC" runat="server" CssClass="form-control w3-blue"></asp:DropDownList>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
            <h3>Daftar Sample</h3>
        </div>
    </div>
    <div class="row mt-2">
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
                    <asp:TemplateField HeaderText="GPS">
                            <ItemTemplate>

                                <asp:Label ID="Loc" runat="server" Text='<%# Eval("latitude")+","+Eval("longitude") %>'>Parameter Uji</asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-lg">
            <asp:Button ID="BtnKembali" CssClass="btn btn-primary" OnClick="BtnKembali_Click" runat="server" Text="Kembali" />
            <asp:Button ID="BtnLanjut" CssClass="btn btn-info" OnClick="BtnLanjut_Click" runat="server" Text="Lanjut" />
        </div>
    </div>
    
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
            //grid parameter
            fixGridView($("#<%=GvParameter.ClientID%>"));
            $('#<%=GvParameter.ClientID%>').DataTable();
            $('#linkincrease').click(function () {
                $('#divContent').css('font-size', '+=3');
            });

            $('#linkdecrease').click(function () {
                $('#divContent').css('font-size', '-=3');
            });
            //grid data
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
</asp:Content>

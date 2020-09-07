<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/SinglePage.Master" AutoEventWireup="true" CodeBehind="ApprovalEvaluasi.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.ApprovalEvaluasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel ID="DTOrder" runat="server">
        <div class="form-group">
            <h2>Nomor order <asp:Label ID="txtNoOreder" runat="server" Text="Label"></asp:Label></h2>
            

            <label for="">Nama Pelanggan : </label>
            <asp:Label ID="txtCustomer" runat="server" Text="Label"></asp:Label>
            <br />

            <label for="">Komoditas : </label>
            <asp:Label ID="txtKomoditas" runat="server" Text="Label"></asp:Label>
            <br />

            <label for="">Tipe Analis : </label>
            <asp:Label ID="txtTipeAnalis" runat="server" Text="Label"></asp:Label>
            <br />

            <label for="">Total Sample : </label>
            <asp:Label ID="txtTotalSample" runat="server" Text="Label"></asp:Label>
            <br />

            <label for="">Status Pesanan : </label>
            <asp:Label ID="txtStatusPesanan" runat="server" Text="Label"></asp:Label>
            <br />


            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData3" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="countNumber" HeaderText="No Urut" />
                        <asp:BoundField DataField="sampleCode" HeaderText="No Sample" />
                        <asp:BoundField DataField="noBalittanah" HeaderText="No Balittanah" />
                        <asp:BoundField DataField="village" HeaderText="Desa" />
                        <asp:BoundField DataField="subDistrict" HeaderText="Kecamatan" />
                        <asp:BoundField DataField="district" HeaderText="Kabupaten" />
                        <asp:BoundField DataField="province" HeaderText="Propinsi" />
                        <asp:BoundField DataField="longitude" HeaderText="Koordinat Gps" />
                        <asp:BoundField DataField="landUse" HeaderText="Tipe Tanah" />
                        <asp:BoundField DataField="isReceived" HeaderText="Sample Diterima" />
                        
                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="DetailorderList" Text="Lihat">Parameter Uji</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
        </div>


         <asp:Button ID="Button1" runat="server" Text="Button" />
                <asp:Button ID="Button2" runat="server" Text="Button" />
                <asp:Button ID="Button3" runat="server" Text="Button" />
        <div class="row">
            <div class="col-md-4">
                <h2>Download Hasil</h2>
                <asp:Button ID="Button4" runat="server" Text="Download" />
            </div>
       </div>
       </asp:Panel>
</asp:Content>

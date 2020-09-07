<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Main.Master" AutoEventWireup="true" CodeBehind="CustomerDetail.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.CustomerDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelGrid" runat="server">
                
                <asp:Label ID="Label2" runat="server" Text="Komoditas"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Tipe Analisis"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Total Sampel"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                
            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="nomor order" />
                        <asp:BoundField DataField="ordermastertbl.customertbl.customerName" HeaderText="nama customer" />
                       <asp:BoundField DataField="sampleNo" HeaderText="nomor sample" />
                        <asp:BoundField DataField="ordersampletbl.sampleDescription" HeaderText="nama sample" />
                        <asp:BoundField DataField="status" HeaderText="Status order" />

                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("orderDetailNo") %>' CommandName="lihat" Text="Lihat"><i class='fa fa-eye'></i> Detail</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelOrderMasuk" Visible="false" runat="server">
                <%--<div>
                    <label for="search">Cari:</label>
                    <asp:TextBox runat="server" ID="TextBox1" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                    <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
                </div>--%>
            <asp:GridView CssClass="table table-bordered table-hover" Visible="true" ID="gv2" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <%--<asp:BoundField DataField="_pics" Visible="false" HeaderText="ID PIC" />--%>
                        <asp:BoundField DataField="_empname" HeaderText="Nama PIC" />
                        <asp:BoundField DataField="_count" HeaderText="Total Order" />

                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("_pics") %>' CommandName="lihatproses" Text="Lihat"><i class='fa fa-eye'></i> Detail</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelPIC" Visible="false" runat="server">
                <div>
                    <asp:Label ID="lblpic" runat="server" Text="Pic"></asp:Label>
                </div>
            <asp:GridView CssClass="table table-bordered table-hover" ID="gvPIC" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="nomor order" />
                        <asp:BoundField DataField="ordermastertbl.customertbl.customerName" HeaderText="nama customer" />
                       <asp:BoundField DataField="sampleNo" HeaderText="nomor sample" />
                        <asp:BoundField DataField="ordersampletbl.sampleDescription" HeaderText="nama sample" />
                        <asp:BoundField DataField="status" HeaderText="Status order" />

                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton  ID="Lihat" runat="server" CommandArgument='<%# Eval("orderDetailNo") %>' CommandName="lihat" Text="Lihat"><i class='fa fa-eye'></i> Detail</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelPICDetail" Visible="false" runat="server">
                <div>
                    <h2><asp:Label ID="Label1" runat="server" Text="Pic"></asp:Label></h2>
                    <br /><br />

                </div>
    </asp:Panel>
    <asp:Panel ID="DTOrder"  Visible="false" runat="server">
        <%--<div class="col-2 offset-1">--%>
                  <div class="form-group">
                      <h2>Detail No order</h2>
                      <asp:TextBox ID="txtNoOreder" runat="server" CssClass="form-control" ReadOnly="true">
                      </asp:TextBox>
                      <label for="">Nama Customer</label>
                      <asp:TextBox ID="txtCustomer" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                      <label for="">No Sample</label>
                      <asp:TextBox ID="txtNoSample" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                      <label for="">Nama Sample</label>
                      <asp:TextBox ID="txtSample" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                      <h2>Nama PIC</h2>
                      <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                      <h2>Daftar Layanan</h2>
                        <table class="table table-bordered">
                            <tr>
                                <td class="text-center">Jenis Analisis</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Jenis" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                      <asp:Button ID="BtnKembali" CssClass="button" OnClick="BtnKembali_Click" runat="server" Text="Kembali" />
                      <asp:Button ID="BtnLanjut" CssClass="btn-primary" OnClick="BtnLanjut_Click" runat="server" Text="Lanjut" />
                      <asp:FileUpload ID="FileUpload1" runat="server" />
                  </div>
        <%--</div>--%>

    <%--<div class="row">  
        <div class="col-6 offset-5">     
            <button type="button" class="fa fa-download btn btn-success col-5 ">  Generate template</button>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-6 offset-5">     
            <button type="button" class="fa fa-upload btn btn-success col-5 ">  Upload result</button>
        </div>
    </div>

    <div class="row">
        
            <button type="button" class="btn btn-success col-2 offset-1 ">Lanjut</button>
            <button type="button" class="btn btn-success col-2">Hitung ulang</button>
        
    </div>--%>
    </asp:Panel>



</asp:Content>


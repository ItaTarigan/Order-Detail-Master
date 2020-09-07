<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Board.Master" AutoEventWireup="true" CodeBehind="BoardTugas.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.BoardTugas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelGrid" runat="server" HorizontalAlign="center">
                <div>
                    <h4>
                        <asp:Label ID="lblPapanTugas" runat="server">Papan Tugas</asp:Label>                        
                    </h4>                    
                </div>
                <asp:Label ID="lblAnalisisTipe" runat="server">Analisis Tipe</asp:Label>                
                <asp:Label runat="server" ID="noOrder"></asp:Label>
                <asp:GridView CssClass="table table-bordered table-hover dataTable" ID="GvTask" runat="server" AutoGenerateColumns="false" AllowSorting="true">
                    <Columns>
                        <asp:BoundField DataField="orderNo" HeaderText="Nomor Order" />
                        <asp:BoundField DataField="sampleNo" HeaderText="Nomor Sample" />
                        <asp:BoundField DataField="elementservicestbl.elementcode" HeaderText="Kode Elemen" />
                        <asp:BoundField DataField="status" HeaderText="Status" /> 
                        <asp:BoundField DataField="employeetbl.employeeName" HeaderText="PIC" />
                        <asp:TemplateField HeaderText="Aksi">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnlihat" CommandName="lihat" CommandArgument='<%# Eval("Orderdetailno") %>' Text="Lihat Tugas" runat="server">LinkButton</asp:LinkButton>                                
                            </ItemTemplate>
                        </asp:TemplateField>                       
                    </Columns>
                </asp:GridView>                
                </asp:Panel>
            <asp:Panel ID="PanelUpdate" Visible="false" runat="server" HorizontalAlign="center">
                <div class="form-group">                   
                    <asp:Label ID="lblNoOrder" runat="server">Nomor Order :</asp:Label>
                    <asp:Label ID="TxtorderNo" runat="server" name="orderno"></asp:Label>                    
                </div>
                <div>                    
                    <asp:Label ID="lblNoOrderDetail" runat="server">Nomor Order Detail :</asp:Label>
                    <asp:Label ID="TxtDetailNo" runat="server"></asp:Label>
                </div>
                <asp:label ID="Txtdtlno" runat="server"></asp:label>
                <div class="form-group">
                    <label>Parameter :</label>
                    <asp:Label runat="server" ID="TxtParameter" name="parameter"></asp:Label>                    
                </div>
                <div class="form-group">
                    <label>Status :</label>
                    <asp:Label runat="server" ID="TxtStatus" name="status" ></asp:Label>
                </div>                                                
                <asp:Button ID="BtnUpdate" CssClass="btn btn-success" runat="server" Text="Ambil Tugas" CommandName="update" OnClick="ActionButton" Visible="false"/>
                <asp:Button ID="BtnCancel" CssClass="btn btn-danger" runat="server" Text="Kembali" CommandName="cancel" OnClick="ActionButton"/>                
            </asp:Panel>
            </ContentTemplate>
     </asp:UpdatePanel>
    </asp:Content>
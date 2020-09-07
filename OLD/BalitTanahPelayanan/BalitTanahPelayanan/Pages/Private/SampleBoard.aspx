<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/SinglePage.Master" AutoEventWireup="true" CodeBehind="SampleBoard.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.SampleBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GvData" CssClass="table table-bordered table-hover dataTable" runat="server" >
        <%--<Columns>    
            <asp:TemplateField HeaderText="Order No">
                <ItemTemplate>
                    <asp:label ID="lblOrderNo" CommandName="update" Text='<%# Eval("OrderNo") %>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NoSample">
                <ItemTemplate>
                    <asp:label ID="lblNoSample" CommandName="update" Text='<%# Eval("NoSample") %>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Analisis Type">
                <ItemTemplate>
                    <asp:label ID="lblAnalisisType" CommandName="update" Text='<%# Eval("AnalisisType") %>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="C">
                <ItemTemplate>
                    <asp:LinkButton ID="btnC" CssClass="btn btn-primary" CommandArgument='<%# Eval("C") %>'  CommandName='<%# Eval("C") %>' Text='<%# Eval("C") %>'  runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="N">
                <ItemTemplate>
                    <asp:Button ID="btnN" CssClass="btn btn-primary" CommandName="update" Text='<%# Eval("N") %>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="E-Coli">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" CssClass="btn btn-primary" CommandName="update" Text='<%# Eval("E.Coli") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>--%>

    </asp:GridView>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

</asp:Content>

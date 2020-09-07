<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderNavigation.ascx.cs" Inherits="BalitTanahPelayanan.Usercontrols.OrderNavigation" %>
<h2><asp:Literal ID="LitCommodity" runat="server"></asp:Literal></h2>
<div class="row mt-2" runat="server" id="TreePanel" visible="true">
    
    <asp:TreeView ID="TreeNav" runat="server" ImageSet="Simple" NodeIndent="10">
        <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle Font-Underline="True" ForeColor="#DD5555" HorizontalPadding="0px" VerticalPadding="0px" />
    </asp:TreeView>
</div>

<div class="row mt-2" runat="server" id="ButtonPanel" visible="false">

    <asp:Repeater ID="RptButton" runat="server">
        <ItemTemplate>
            <div class="col-lg-1">
                <asp:Button ID="BtnNode" CommandName="Select" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-info" runat="server" Text='<%# Eval("CommodityName") %>' />
            </div>
        </ItemTemplate>
    </asp:Repeater>

</div>
<div class="row mt-2">
    <div class="col-lg">
        <asp:Button ID="BtnExit" CssClass="btn btn-danger" runat="server" Text="Kembali" />
    </div>
</div>

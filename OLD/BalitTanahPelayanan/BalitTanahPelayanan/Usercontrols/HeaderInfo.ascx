<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderInfo.ascx.cs" Inherits="BalitTanahPelayanan.Usercontrols.HeaderInfo" %>
<div class="mainHeader">
    <header class="header-left">
        <img src="~/assets/img/Logo.PNG" alt="logo" runat="server" />
    </header>
    <header class="header-right" style="text-align: right">
        <img src="~/assets/img/icon-man.png" runat="server" class="userlogo" />
        <span class="username"><span>
            <asp:Literal ID="LitWelcome" runat="server"></asp:Literal> <strong>
            <asp:Literal ID="LitUserName" runat="server"></asp:Literal></strong></span>
        </span>
        <br />
         <span><asp:LinkButton ID="BtnEN" OnClick="BtnLang_Click" CommandName="en" runat="server"><b>EN</b></asp:LinkButton> | <asp:LinkButton CommandName="id" ID="BtnID" OnClick="BtnLang_Click" runat="server"><b>ID</b></asp:LinkButton></span>
        <br />
        <asp:LinkButton ID="LogOutBtn" runat="server"><img src="~/assets/img/logout.png" runat="server" /> <span>Keluar</span></asp:LinkButton>
    </header>
</div>

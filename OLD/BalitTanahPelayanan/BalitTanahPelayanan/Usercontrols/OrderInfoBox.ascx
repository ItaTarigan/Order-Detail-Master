<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderInfoBox.ascx.cs" Inherits="BalitTanahPelayanan.Usercontrols.OrderInfoBox" %>
<style>
    .box-info {
        max-width: 1200px;
        display: block;
    }
    .box-info>.box1>.w3-container {
        background: #F1F5F8 !important;color: #000 ;
    }
    .box-info>.box2>.w3-container {
        background: #00CCB3 !important; color:#fff !important;
    }
    .box-info>.box3>.w3-container {
        background: #3E8AFB !important;color:#fff !important;
    }
    .box-info>.w3-quarter>.w3-container {
        color: #000 ;
        text-align: center;
        font-family: 'montserratbold' !important;
        padding-bottom: 15px !important;
    }
    .box-info>.w3-quarter>.w3-container h4 {font-family: 'montserratbold';text-transform: uppercase;font-size: 16px;}
    .box-info>.w3-quarter>.w3-container h4>span {font-family: 'montserratregular';text-transform: uppercase;font-size: 50px;}
    .box-info>.w3-quarter>.w3-container h3>span {font-family: 'montserratbold';text-transform: uppercase;font-size: 16px;}
</style>

<div class="w3-margin-bottom box-info">
    <div class="w3-quarter box1">
        <div class="w3-container w3-padding-32">
            <div class="w3-center">
                <h3>
                    <asp:Label runat="server" ID="Labelr"></asp:Label></h3>
            </div>
            <div class="w3-clear"></div>
            <h4>
                <asp:Label runat="server" ID="lblTotal"></asp:Label></h4>
        </div>
    </div>
    <div class="w3-quarter box2">
        <div class="w3-container w3-padding-32">
            <div class="w3-center">
                <h3><asp:Label runat="server" ID="Label3"></asp:Label></h3>
            </div>
            <div class="w3-clear"></div>
            <h4>
                <asp:Label runat="server" ID="lblOrderProses"></asp:Label></h4>
        </div>
    </div>
    <div class="w3-quarter box3">
        <div class="w3-container w3-text-white w3-padding-32">
            <div class="w3-center">
                <h3><asp:Label runat="server" ID="Label3a"></asp:Label></h3>
            </div>
            <div class="w3-clear"></div>
            <h4>
                <asp:Label runat="server" ID="lblOrderDone"></asp:Label></h4>
        </div>
    </div>
</div>


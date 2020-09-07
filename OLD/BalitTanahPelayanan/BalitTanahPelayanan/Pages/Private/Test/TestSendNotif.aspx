<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSendNotif.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Test.TestSendNotif" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script
        src="https://code.jquery.com/jquery-3.4.1.min.js"
        integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo="
        crossorigin="anonymous"></script>
    <link type="text/css" rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <link rel="icon" type="image/png" href="<%= ResolveUrl("~/assets/img/favicon.png") %>" />
    <title>Test Notification</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <h3>Message
                    </h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:textbox id="TxtMsg" width="100%" textmode="MultiLine" runat="server"></asp:textbox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:button id="BtnSend" cssclass="btn btn-info" runat="server" text="Send" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>

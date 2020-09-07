<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterDone.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.RegisterDone" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />

    <link rel="icon" type="image/png" href="../../assets/img/tube.png" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/fonts.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/styles.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/responsive.css" />
    <script type="text/javascript" src="../../assets/js/jquery.min.js"></script>
    <script type="text/javascript" src="../../assets/js/scripts.js"></script>
    <title>Balitanah</title>
</head>
<body>
    <div class="container">
        <div class="container-inner bg-lab">
            <!-- tambahkan class form-ready untuk mengubah tombol menjadi biru -->
            <form id="loginForm" action="" runat="server" method="post" class="form-container form-ready">
                <h3><img src="../../assets/img/tube.png" class="icon" /> Pelayanan Jasa Balitanah</h3>
                <h1>Pendaftaran Berhasil, silahkan masuk</h1>
                <div class="main-note">
                   
                </div>
                <div class="control-block">
                    <asp:Button ID="BtnLogin" OnClick="BtnLogin_Click" class="button primary" runat="server" Text="Login" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
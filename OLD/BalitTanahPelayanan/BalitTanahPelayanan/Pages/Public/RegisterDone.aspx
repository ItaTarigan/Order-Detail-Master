<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterDone.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.RegisterDone" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />

    <link rel="icon" type="image/png" href="../../assets/img/favicon.png" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/fonts.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/styles.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/responsive.css" />
    <script type="text/javascript" src="../../assets/js/jquery.min.js"></script>
    <script type="text/javascript" src="../../assets/js/scripts.js"></script>
    <title>Sistem Informasi Pelayanan Online Balitanah - Registrasi User</title>
</head>
<body>
    <div class="container">
        <div class="container-inner bg-lab">
            <div class="mainLogo"><img src="../../assets/img/title.png" /></div>
            <!-- tambahkan class form-ready untuk mengubah tombol menjadi biru -->
            <form id="loginForm" action="" runat="server" method="post" class="form-container form-ready">
                <div class="head-logos">
                    <img src="~/assets/img/logo-sealnet.png" runat="server" />
                    <img src="~/assets/img/logo-aspac.png" runat="server" />
                    <img src="~/assets/img/logo-fftc.png" runat="server" />
                </div>
                <h1>Pendaftaran Berhasil, silahkan masuk</h1>
                <div class="main-note">
                   
                </div>
                <div class="control-block">
                    <asp:Button ID="BtnLogin" OnClick="BtnLogin_Click" class="button primary" runat="server" Text="Login" />
                </div>
            </form>
            <div class="footer-logos">
                <div class="logo-right">
                    <img src="~/assets/img/logo-kan.png" runat="server" />
                    <span class="box-text">LP-846 IDN<br/>SNI ISO/IEC 17025:2017</span>
                    <span class="box-text">PUP-012-IDN<br/>ISO/IEC 17043-2010</span>
                </div>
                <div class="logo-left">
                    <img src="~/assets/img/logo-agro.png" runat="server" />
                    <span class="nobox-text">Laboratorium Tanah, Tanaman, Pupuk dan Air<br>Badan Penelitian dan Pengembangan Pertanian<br>Laboratorium Penguji BALAI PENELITIAN TANAH </span>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
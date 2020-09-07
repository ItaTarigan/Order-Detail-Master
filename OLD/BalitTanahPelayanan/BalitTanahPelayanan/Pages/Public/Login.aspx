<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.Login" %>

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
    <title>Balitanah</title>
</head>
<body>
    <div class="container">
        <div class="container-inner bg-lab">
            <div class="mainLogo"><img src="../../assets/img/title.png" /></div>
            <form id="loginForm" action="" method="post" class="form-container" runat="server">
                <div class="head-logos">
                    <img src="~/assets/img/logo-sealnet.png" runat="server" />
                    <img src="~/assets/img/logo-aspac.png" runat="server" />
                    <img src="~/assets/img/logo-fftc.png" runat="server" />
                </div>
                <h1>Selamat Datang</h1>
                <div class="main-note">
                    Kami siap melayani kebutuhan anda untuk melakukan penelitian sampel tanah
                </div>
                <div class="control-boxes">
                    <div class="control-box">
                        <label class="input input-text">
                            <input runat="server" id="txtUsername" type="email" class="icon-mail" placeholder="Alamat Email" name="username" required data-message="Masukkan alamat email anda" />
                        </label>
                        <label class="input input-password">
                            <a class="input-btn noselect" title="Tampilkan kata sandi">
                                <img src="../../assets/img/eye.png" /></a>
                            <input runat="server" id="txtPassword" type="password" class="icon-lock" placeholder="Kata Sandi" name="username" required data-message="Masukkan kata sandi anda" />
                        </label>
                         <div id="DivError" runat="server" visible="false" class="error-box" onclick="_bt_msgDismiss(this);" title="Klik untuk menghapus pesan">
                             <asp:Literal ID="TxtError" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="control-block">
                    <label class="input input-checkbox pull-left">
                        <input id="cbremember" type="checkbox" runat="server" checked="checked" />
                        <span class="check"></span>
                        <span class="label">Ingat saya</span>
                    </label>
                    <a href="ForgotPasswordForm.aspx" class="link pull-right">Lupa Kata Sandi?</a>
                  
                </div>
                <div class="control-block">
                    <asp:Button ID="btnLogin" OnClick="btnLogin_Click" class="button primary" runat="server" Text="Submit" />&nbsp;&nbsp;
                    <%--<asp:Button ID="btnRegister" OnClick="btnRegister_Click" class="button" runat="server" Text="Daftar" />--%>
                    <a class="button" href="RegisterForm.aspx">Daftar</a>
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
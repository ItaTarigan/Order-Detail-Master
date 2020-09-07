﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.Login" %>

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
            <form id="loginForm" action="" method="post" class="form-container" runat="server">
                <h3><img src="../../assets/img/tube.png" class="icon" /> Pelayanan Jasa Balitanah</h3>
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
                            <a class="input-btn noselect" title="Tampilkan kata sandi"><img src="../../assets/img/eye.png" /></a>
                            <input runat="server" id="txtPassword" type="password" class="icon-lock" placeholder="Kata Sandi" name="username" required data-message="Masukkan kata sandi anda" />
                        </label>
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
        </div>
    </div>
</body>
</html>
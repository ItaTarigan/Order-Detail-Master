<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPasswordForm.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.ForgotPasswordForm" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />

    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="../../assets/img/favicon.png" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/fonts.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/styles.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/responsive.css" />
    <script type="text/javascript" src="../../assets/js/jquery.min.js"></script>
    <script type="text/javascript" src="../../assets/js/scripts.js"></script>
    <title>Sistem Informasi Pelayanan Online Balitanah - Reset Password</title>
</head>
<body>
    <div class="container">
        <div class="container-inner bg-lab">
            <div class="mainLogo"><img src="../../assets/img/title.png" /></div>
            <form id="loginForm" action="" method="post" runat="server" class="form-container ">
                <div class="head-logos">
                    <img src="~/assets/img/logo-sealnet.png" runat="server" />
                    <img src="~/assets/img/logo-aspac.png" runat="server" />
                    <img src="~/assets/img/logo-fftc.png" runat="server" />
                </div>
                <h1>Lupa Kata Sandi</h1>
                <div class="main-note">
                    Kami akan mengirimkan link untuk melakukan reset kata sandi anda, masukkan alamat email anda
                </div>
                <div class="control-boxes">
                    <div class="control-box">
                        <label class="input input-text">
                            <input id="txtemail" runat="server" type="email" class="icon-mail" placeholder="Alamat Email" name="username" required data-message="Masukkan alamat email anda" />
                        </label>
                    </div>
                </div>
                    <asp:Label ID="lblMessage" Visible="false" CssClass="alert alert-danger" runat="server" ></asp:Label>
                    <div class="control-block">
                    <a class="button" href="Login.aspx">Batal</a> &nbsp;&nbsp;
                    <asp:Button ID="btnSent" OnClick="btnSent_Click" class="button primary" runat="server" Text="Kirim Link" />
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPasswordForm.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.ForgotPasswordForm" %>

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
            <form id="loginForm" action="" method="post" runat="server" class="form-container ">
                <h3><img src="../../assets/img/tube.png" class="icon" /> Pelayanan Jasa Balitanah</h3>
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
                <div class="control-block">
                    <a class="button" href="Login.aspx">Batal</a> &nbsp;&nbsp;
                    <!-- Ganti line ini dengan input type submit -->
                    <asp:Button ID="btnSent" OnClick="btnSent_Click" class="button primary" runat="server" Text="Kirim Link" />
                    <%--<a class="button primary" href="forgot-pass-sent.htm">Kirim Link</a>--%>
                    <!--<input type="submit" class="button primary" value="Kirim Link" onclick="document.location = 'forgot-pass-sent.htm'; return false;" />-->
                </div>
            </form>
        </div>
    </div>
</body>
</html>
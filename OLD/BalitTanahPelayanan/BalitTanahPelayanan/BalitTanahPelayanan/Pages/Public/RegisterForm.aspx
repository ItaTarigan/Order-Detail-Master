<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.RegisterForm" %>

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
        <div class="container-inner bg-lab2">
            <form id="loginForm" action="" runat="server" method="post" class="form-container wide ">
                <h3><img src="../../assets/img/tube.png" class="icon" /> Pelayanan Jasa Balitanah</h3>
                <h1>Silahkan Mendaftar</h1>
                <div class="main-note">
                    Kami siap melayani kebutuhan anda untuk melakukan penelitian sampel tanah
                </div>
                <div class="control-boxes">
                    <div class="control-box">
                        <label class="input input-text">
                            <input id="txtusername" runat="server" type="text" class="icon-user" placeholder="Nama" name="username" required />
                        </label>
                        <label class="input input-text">
                            <input id="txtphone" runat="server" type="text" class="icon-phone" placeholder="No Telp" name="phone" required data-message="Masukkan nomor telepon anda" />
                        </label>
                        <label class="input input-text">
                            <input id="txtcompanyname" runat="server" type="text" class="icon-plant" placeholder="Nama Instansi / Perusahaan" name="work" required />
                        </label>
                        <label class="input input-text">
                            <textarea id="txtaddress" runat="server" class="icon-addr autoresize" placeholder="Alamat Instansi / Perusahaan" name="workAddr" required ></textarea>
                        </label>
                    </div>
                    <div class="control-box">
                        <label class="input input-text">
                            <input id="txtemail" runat="server" type="email" class="icon-mail" placeholder="Alamat Email" name="username" required />
                        </label>
                        <label class="input input-password">
                            <a class="input-btn noselect" title="Tampilkan kata sandi"><img src="../../assets/img/eye.png" /></a>
                            <input id="txtpassword" runat="server" type="password" class="icon-lock" placeholder="Kata Sandi" name="username" required />
                        </label>
                        <label class="input input-password">
                            <a class="input-btn noselect" title="Tampilkan kata sandi"><img src="../../assets/img/eye.png" /></a>
                            <input id="txtpassword2" runat="server" type="password" class="icon-lock" placeholder="Ulangi Kata Sandi" name="username" required data-message="Ulangi kata sandi anda" />
                        </label>
                    </div>

                </div>
                <br><br><br>
                <div class="control-block text-right">
                    <a class="button" href="Login.aspx">Batal</a>&nbsp;&nbsp;
                    
                    <!-- Ganti elemen berikut dengan input type submit -->
                    <asp:Button ID="BtnDaftar" OnClick="BtnDaftar_Click" class="button primary" runat="server" Text="Daftar" />
                    <!--<input type="submit" class="button primary" value="Daftar" />-->

                </div>
            </form>
        </div>
    </div>
</body>
</html>
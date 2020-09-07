<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.RegisterForm" %>

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
        <div class="container-inner bg-lab2">
            <div class="mainLogo"><img src="../../assets/img/title.png" /></div>
            <form id="loginForm" runat="server" method="post" class="form-container wide ">
                <h1>Silahkan Mendaftar</h1>
                <div class="main-note">
                    Kami siap melayani kebutuhan anda untuk melakukan penelitian sampel tanah
                </div>
                <div class="control-boxes">
                    <div class="control-box">
                        <asp:HiddenField ID="TxtID" runat="server" />
                        <label class="input input-text">                           
                            <asp:TextBox ID="txtusername" runat="server" type="text" class="icon-user" placeholder="Nama" name="username" required></asp:TextBox>
                        </label>
                        <label class="input input-text">
                            <asp:TextBox ID="txtphone" runat="server" type="text" class="icon-phone" placeholder="No Telp" name="phone" required data-message="Masukkan nomor telepon anda"></asp:TextBox>                                                       
                        </label>                        
                        <label class="input input-text">                            
                            <asp:TextBox ID="txtcompanyname" runat="server" type="text" class="icon-plant" placeholder="Nama Instansi / Perusahaan" name="work" required></asp:TextBox>
                        </label>                        
                        <label class="input input-text">                            
                            <asp:TextBox ID="txtaddress" TextMode="MultiLine" runat="server" class="icon-addr autoresize" placeholder="Alamat Instansi / Perusahaan" name="workAddr" required></asp:TextBox>
                        </label>
                    </div>                     
                    <div class="control-box">
                        <label class="input input-text">                            
                            <asp:TextBox ID="txtemail" runat="server" type="email" class="icon-mail" placeholder="Alamat Email" name="username" required></asp:TextBox>                            
                        </label>
                        <label class="input input-text">                            
                            <asp:TextBox ID="txtcompanyemail" runat="server" type="email" class="icon-mail" placeholder="Email Instansi / Perusahaan" name="work" required></asp:TextBox>
                        </label>
                        <label class="input input-password">
                            <a class="input-btn noselect" title="Tampilkan kata sandi"><img src="../../assets/img/eye.png" /></a>                            
                            <asp:TextBox ID="txtpassword" runat="server" type="password" class="icon-lock" placeholder="Kata Sandi" name="username" required></asp:TextBox>
                        </label>
                        <label class="input input-password">
                            <a class="input-btn noselect" title="Tampilkan kata sandi"><img src="../../assets/img/eye.png" /></a>                            
                            <asp:TextBox ID="txtpassword2" runat="server" type="password" class="icon-lock" placeholder="Ulangi Kata Sandi" name="username" required data-message="Ulangi kata sandi anda"></asp:TextBox>                           
                        </label>                          
                    </div>       
                </div>   
                <br />
                <asp:CompareValidator Font-Bold Font-Size="Small" ID="CompareValidator1" runat="server" 
                 ControlToValidate="txtpassword2"
                 CssClass="ValidationError"
                 ControlToCompare="txtpassword"
                 ErrorMessage="Kata sandi harus sama" />
                <br />
                <asp:RegularExpressionValidator Font-Bold Font-Size="Small" ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtphone" ErrorMessage="No.Phone Harus Angka" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                <br />
                <asp:RegularExpressionValidator Font-Bold Font-Size="Small" ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtphone" ErrorMessage="No.Phone Minimal 10 Angka" ValidationExpression=".{10}.*"></asp:RegularExpressionValidator>                            
                <br />
                <br />
                <div class="control-block text-right">
                    <a class="button" href="Login.aspx">Batal</a>&nbsp;&nbsp;
                    
                    <!-- Ganti elemen berikut dengan input type submit -->
                    <asp:Button ID="BtnDaftar" class="button primary" runat="server" Text="Daftar" 
                        UseSubmitBehavior="false"
                        OnClientClick="this.disabled='true'; this.value='please wait...';"
                        OnClick="BtnDaftar_Click"/>
                    <asp:Label ID="TxtStatus" ForeColor="Red" runat="server" Text=""></asp:Label>
                    <!--<input type="submit" class="button primary" value="Daftar" />-->

                </div>
            </form>
        </div>
    </div>
    <div style="display:none">SendGrid</div>
</body>
</html>
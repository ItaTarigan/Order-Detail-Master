<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />

    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="../../assets/img/tube.png" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/fonts.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/styles.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/responsive.css" />
    <script type="text/javascript" src="../../assets/js/jquery.min.js"></script>
    <script type="text/javascript" src="../../assets/js/scripts.js"></script>
    <title>Balitanah</title>
</head>
<body>
     <style>
        #form1{
            margin-left: 200px;
        }
    </style>
     <div class="container">       
            <form id="form1" runat="server">
                <h1>Reset Password</h1>
        <div>
             <div class="control-boxes">
                    <div class="control-box">
                        <label class="input input-text">
                            <input id="txtuser" runat="server" type="text" class="" placeholder="Username" required data-message="Masukkan Passwod baru anda" />
                        </label>
                    </div>
              </div>
            <div class="control-boxes"> 
                    <div class="control-box">
                         <label class="input input-password">
                            <a class="input-btn noselect" title="Tampilkan kata sandi"><img src="../../assets/img/eye.png" /></a>
                            <input id="txtoldpass" runat="server" type="password" class="" placeholder="Password Lama" required data-message="Masukkan kata sandi anda" />
                        </label>
                    </div>
              </div>
            <div class="control-boxes">
                    <div class="control-box">
                         <label class="input input-password">
                            <a class="input-btn noselect" title="Tampilkan kata sandi"><img src="../../assets/img/eye.png" /></a>
                            <input id="txtnewpass" runat="server" type="password" class="" placeholder="Password Baru" required data-message="Masukkan kata sandi anda" />
                        </label>
                    </div>
              </div>
        </div>
                <div>
                    <asp:Label ID="lblMassage" Visible="false" CssClass="alert alert-danger" runat="server" ></asp:Label>
                <br />
                <asp:Button ID="BtnReset" OnClick="BtnReset_Click" class="button primary" runat="server" Text="Reset" />
                    </div>
            </form>          
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.Activation" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />



    <script type="text/javascript" src="../../assets/js/jquery.min.js"></script>

    <link type="text/css" rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <link rel="icon" type="image/png" href="../../assets/img/favicon.png" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/fonts.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/styles.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/responsive.css" />
    <script type="text/javascript" src="../../assets/js/scripts.js"></script>

    <title>Sistem Informasi Pelayanan Online Balitanah - Aktivasi</title>

</head>
<body>
    <div class="container">
        <div class="container-inner bg-lab">
            <div class="mainLogo"><img src="../../assets/img/title.png" /></div>
            <form id="form1" runat="server" class="form-container form-ready">
                <div class="head-logos">
                    <img src="~/assets/img/logo-sealnet.png" runat="server" />
                    <img src="~/assets/img/logo-aspac.png" runat="server" />
                    <img src="~/assets/img/logo-fftc.png" runat="server" />
                </div>
                    <h1>Aktivasi User</h1>
                    <p class="lead">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal></p>
                    <hr class="my-4">
                    <p>
                        <asp:Literal ID="TxtStatus" runat="server"></asp:Literal></p>
                    <p class="lead">
                        <asp:Button ID="btnAktif" CssClass="btn btn-primary btn-lg" runat="server" Text="Login" />

                    </p>
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


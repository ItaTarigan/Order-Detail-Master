<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPesanan.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Customer.CustomerPesanan" %>

<!DOCTYPE html>
<html>
<head runat="server">
   <title><%: Page.Title %> - BalitTanah Management Web</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="/assets/css/pdjaya.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Material+Icons">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        html, body, h1, h2, h3, h4, h5 {
            font-family: "Raleway", sans-serif
        }
    </style>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js" integrity="sha256-ZosEbRLbNQzLpnKIkEdrPv7lOy9C27hHQ+Xp8a4MxAQ=" crossorigin="anonymous"></script>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css">  
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body class="w3-light-grey">
    <form runat="server">
    <!-- Top container -->
    <!--div class="w3-bar w3-top w3-black w3-large" style="z-index: 4"-->
        <!--hr /-->
        <!--<button class="w3-bar-item w3-button w3-hide-large w3-hover-none w3-hover-text-light-grey" onclick="w3_open();"><i class="fa fa-bars"></i>&nbsp;Menu</button>                
            <asp:Label runat="server" Font-Bold>Pasar Jaya</asp:Label>-->
    <!--/div-->
     
    <!-- Sidebar/menu -->
    <nav class="w3-sidebar w3-collapse w3-white w3-animate-left" style="z-index: 3; width: 300px;" id="mySidebar">
        <br>
        <div class="w3-container w3-row">
            <div class="w3-col s4">
                <i class="fa fa-user fa-fw"></i>
            </div>
            <div class="w3-col s8 w3-bar">
                <span>Welcome, <strong>
                    <asp:Label ID="lbCurrentUser" runat="server"></asp:Label>
                </strong></span>
            </div>
            <br />
            <%--<asp:Button CssClass="btn btn-block btn-success" ID="btnOut" runat="server" Text="Logout" OnClick="btnOut_Clicked" />--%>
        </div>
        <hr>
        <div class="w3-container">
            <h5>Dashboard</h5>
        </div>
        <div class="w3-bar-block">
            <a href="#" class="w3-bar-item w3-button w3-padding-16 w3-hide-large w3-dark-grey w3-hover-black" onclick="w3_close()" title="close menu"><i class="fa fa-remove fa-fw"></i>&nbsp; Close Menu</a>
            <a href="/Pages/Private/Customer/CustomerPesanan.aspx" class="w3-bar-item w3-button w3-padding">Daftar Pesanan</a>
            <a href="/Pages/Private/Customer/AccountsMaster.aspx" class="w3-bar-item w3-button w3-padding">Pesanan Diproses</a>
            <a href="/Pages/Private/Customer/AnalysisTypesMaster.aspx" class="w3-bar-item w3-button w3-padding">Pesanan Selesai</a>
        </div>
    </nav>


    <!-- Overlay effect when opening sidebar on small screens -->
    <div class="w3-overlay w3-hide-large w3-animate-opacity" onclick="w3_close()" style="cursor: pointer" title="close side menu" id="myOverlay"></div>

    <!-- !PAGE CONTENT! -->
    <div class="w3-main" style="margin-left: 300px;">


        <!-- Header -->
        <header class="w3-container" style="padding-top: 22px">
            <%--<h5><b><i class="fa fa-dashboard"></i>&nbsp<%: Page.Title %></b></h5>--%>
        </header>
        <div style="margin:5px">
            <div style="overflow-x:auto;">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="MainPanel" runat="server">
                             <div>
                                <label for="search">Cari Pesanan:</label>
                                <asp:TextBox runat="server" ID="TxtSearch" TextMode="SingleLine" CssClass="form-control" name="search"></asp:TextBox>
                                <asp:ImageButton runat="server" ID="BtnSearch" ImageUrl="~/assets/img/search-24.png" CommandName="search" AlternateText="Cari" OnClick="ActionImageButton"/>
                                <asp:ImageButton runat="server" ID="BtnRefresh" ImageUrl="~/assets/img/refresh-32.png" CommandName="refresh" AlternateText="Segarkan" OnClick="ActionImageButton"/>
                            </div>
                            <asp:GridView CssClass="table table-bordered table-hover" ID="GvData" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                                <Columns>
                                    <asp:BoundField DataField="orderNo" HeaderText="Nomor Pesanan" />
                                    <asp:BoundField DataField="username" HeaderText="Nama Pelanggan" />
                                    <asp:BoundField DataField="password" HeaderText="Komoditas" />
                                    <asp:BoundField DataField="roleName" HeaderText="Tipe Analisis" />
                                    <asp:BoundField DataField="isEmailVerified" HeaderText="Jumlah Sampel" />
                                    <asp:BoundField DataField="isEmailVerified" HeaderText="Jumlah Harga" />
                                    <asp:BoundField DataField="isEmailVerified" HeaderText="Status Pesanan" />
                                    <asp:BoundField DataField="isEmailVerified" HeaderText="Status Pembayaran" />
                                    <asp:TemplateField HeaderText="Tindakan">
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton  ID="Edit" ForeColor="Green" runat="server" CommandArgument='<%# Eval("orderNo") %>' CommandName="rincian" Text="Ubah"><i class='fa fa-edit'></i></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>                        
                                </Columns>
                            </asp:GridView>
                            <asp:Button CssClass="btn btn-success" ID="BtnAdd" runat="server" Text="Pesanan Baru" CommandName="add" OnClick="ActionButton" />
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
             </div>
        </div>
        <!-- Footer -->
        <%--<footer class="w3-container w3-padding-16 w3-light-grey">
            <h4>FOOTER</h4>
            <p>Powered by <a href="https://www.w3schools.com/w3css/default.asp" target="_blank">w3.css</a></p>
        </footer>--%>

        <!-- End page content -->
    </div>

    <script>
        // Get the Sidebar
        var mySidebar = document.getElementById("mySidebar");

        // Get the DIV with overlay effect
        var overlayBg = document.getElementById("myOverlay");

        // Toggle between showing and hiding the sidebar, and add overlay effect
        function w3_open() {
            if (mySidebar.style.display === 'block') {
                mySidebar.style.display = 'none';
                overlayBg.style.display = "none";
            } else {
                mySidebar.style.display = 'block';
                overlayBg.style.display = "block";
            }
        }

        // Close the sidebar with the close button
        function w3_close() {
            mySidebar.style.display = "none";
            overlayBg.style.display = "none";
        }
    </script>
    </form>
</body>
</html>

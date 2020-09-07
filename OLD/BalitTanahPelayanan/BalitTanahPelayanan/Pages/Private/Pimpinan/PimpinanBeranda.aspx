<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Pimpinan.Master" AutoEventWireup="true" CodeBehind="PimpinanBeranda.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Pimpinan.PimpinanBeranda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
            <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
            <div class="row mt-2" id="DivRow1" runat="server">
                <div class="col-lg">
                    <h2>
                        Dashboard Kinerja Pelayanan Balittanah - SILPO
                    </h2>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-lg">
                    <!--DASHBOARD POWER BI DISINI-->
                    <iframe width="800" height="600" src="https://app.powerbi.com/view?r=eyJrIjoiZjhiNzUwODAtZDY2ZC00ZjQyLWJmM2YtMTQxM2QyODFkMDA4IiwidCI6ImU0YTVjZDM2LWU1OGYtNGY5OC04YTFhLTdhOGU1NDVmYzY1YSIsImMiOjEwfQ%3D%3D" frameborder="0" allowFullScreen="true"></iframe>
                </div>

            </div>
</asp:Content>

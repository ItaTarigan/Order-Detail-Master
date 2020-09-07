﻿<%@ Page Language="C#" MasterPageFile="~/Pages/Master/Board.Master" AutoEventWireup="true" CodeBehind="BoardTugas.aspx.cs" Inherits="BalitTanahPelayanan.Pages.BoardTugas.BoardTugas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src="/Scripts/jquery.signalR-2.4.1.min.js"></script>
    <!--Reference the autogenerated SignalR hub script. -->
    <script src="/signalr/hubs"></script>
    <!--Add script to update the page and send messages.-->
    <style>
        table {
            font-family : Arial, Helvetica, sans-serif;
        }

        table thead tr th {
            font-size: 20px;
        }

        table tbody tr td {
            font-size: 18px;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelGrid" runat="server" HorizontalAlign="center">
                <input type="hidden" id ="txtUser" value="" runat="server" />
                <table id="tblData" class="table table-striped">
                    <thead>
                        <tr>
                            <th>Batch No</th>
                            <th>Sample No</th>
                            <th>Parameter</th>
                            <th>Status Pengerjaan</th>
                            <th>Pic</th>
                        </tr>
                    </thead>
                    <tbody>

                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>    
    <script type="text/javascript">// Basic example
        $(document).ready(function () {
            $('#tblData').DataTable({
                "pagingType": "simple" // "simple" option for 'Previous' and 'Next' buttons only
            });
            $('.dataTables_length').addClass('bs-select');
        });

        $(function () {
            var hubconn = $.connection.BoardTugasHub;
            var vuser = $('#<%= txtUser.ClientID %>').val();

            hubconn.client.populateDataTugas = function (datas) {
                console.log('refresh data ...');
                var tbl = $('#tblData tbody');
                tbl.find('tr').remove();

                for (var i = 0; i < datas.length; i++) {
                    if (tbl != '' && tbl != undefined) {
                        var _batchNo = "-";
                        if (datas[i].BatchNo != null && datas[i].BatchNo != "" && datas[i].BatchNo != undefined) {
                            _batchNo = datas[i].BatchNo;
                        }
                        tbl.append('<tr><td>' + _batchNo + '</td><td>' + datas[i].SampleNo + '</td><td>' + datas[i].ParameterName + '</td><td>' + datas[i].SampleStatus + '</td><td>' + datas[i].Pic + '</td></tr>');
                    }
                }
            }

            $.connection.hub.start().done(function () {
                console.log('signalr is connected..');
                hubconn.server.RequestData(vuser);
            });

            window.setInterval(function () {
                hubconn.server.RequestData(vuser);}, 15000);
        });
    </script>
</asp:Content>
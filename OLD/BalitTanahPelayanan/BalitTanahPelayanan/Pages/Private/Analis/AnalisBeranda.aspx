<%@ Page Title="Analis" Language="C#" Async="true" MasterPageFile="~/Pages/Master/Analis.Master" AutoEventWireup="true" CodeBehind="AnalisBeranda.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Private.Analis.AnalisBeranda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    
    <div class="row mt-2">
        <div class="col-lg">
            <h2>
                <asp:Label ID="txtdaftarbatch" runat="server" Text="Daftar Batch"></asp:Label>
            </h2>
        </div>
        <div class="col-lg" style="text-align:right;">
            <asp:Label ID="LblFontSize" runat="server" style="font-size: 14px; font-weight:bold;" Text="Perbesar Teks"></asp:Label>
            <a id="linkincrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-primary">+</a>
            <a id="linkdecrease" style="font-size: 16px; font-weight:bold;" href="#" class="btn btn-outline-secondary">-</a>
        </div>
    </div> 
    <div id="divContent" class="divClass">
        <div class="row mt-2">
            <div class="col-lg">
               <asp:GridView ID="GvBatch" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="false" AllowPaging="false" EmptyDataText="Data Kosong">
                    <Columns>
                        <asp:BoundField DataField="batchId" HeaderText='No Batch' />
                        <asp:BoundField DataField="employeetbl.employeeName" HeaderText="PIC Analis" />
                        <asp:BoundField DataField="status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Tindakan">
                            <ItemTemplate>

                                <asp:LinkButton ID="Lihat" runat="server" CommandArgument='<%# Eval("batchId") %>' CommandName="lihatBatch" Text="Lihat">Rincian</asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
          
            </div>
        </div>
        <script>
          function fixGridView(tableEl) {
              var jTbl = $(tableEl);

              if (jTbl.find("tbody>tr>th").length > 0) {
                  jTbl.find("tbody").before("<thead><tr></tr></thead>");
                  jTbl.find("thead tr").append(jTbl.find("th"));
                  jTbl.find("tbody tr:first").remove();
              }
          }
          $(document).ready(function () {
              fixGridView($("#<%=GvBatch.ClientID%>"));

                    $('#<%=GvBatch.ClientID%>').DataTable();
                    $('#linkincrease').click(function () {
                        $('#divContent').css('font-size', '+=3');
                    });

                    $('#linkdecrease').click(function () {
                        $('#divContent').css('font-size', '-=3');
                    });
                });
            </script>
    </div>
</asp:Content>

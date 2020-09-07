<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Public.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BalitTanahPelayanan.Pages.Public.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                 <div id="myCarousel" class="carousel slide" data-ride="carousel">
              <!-- Indicators -->
              <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
              </ol>

              <!-- Wrapper for slides -->
              <div class="carousel-inner">
                <div class="item active">
                  <img src="../../Assets/img/kantor11.jpg"/>
                    <div class="carousel-caption d-none d-md-block">
                      <h3>BalitTanah</h3>
                      <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                    </div>
                </div>

                <div class="item">
                  <img src="../../Assets/img/kantor11.jpg" />
                    <div class="carousel-caption d-none d-md-block">
                      <h3>BalitTanah</h3>
                      <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                    </div>
                </div>

                <div class="item">
                  <img src="../../Assets/img/kantor11.jpg" />
                    <div class="carousel-caption d-none d-md-block">
                      <h3>BalitTanah</h3>
                      <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                    </div>
                </div>
              </div>

              <!-- Left and right controls -->
              <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left"></span>
                <span class="sr-only">Previous</span>
              </a>
              <a class="right carousel-control" href="#myCarousel" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right"></span>
                <span class="sr-only">Next</span>
              </a>
            </div>
            </div>
            <div class="col-md-2"></div>
        </div>
        </asp:Panel>
</asp:Content>
  
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-lg-4">
          <img class="img-circle center-block" src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" alt="" width="140" height="140">
          <h2 class="text-center">Heading</h2>
          <p class="text-center">Donec sed odio dui. Etiam porta sem malesuada magna mollis euismod. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna.</p>
          <p class="text-center"><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
        </div><!-- /.col-lg-4 -->
        <div class="col-lg-4">
          <img class="img-circle center-block" src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" alt="" width="140" height="140">
          <h2 class="text-center">Heading</h2>
          <p class="text-center">Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Cras mattis consectetur purus sit amet fermentum. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh.</p>
          <p class="text-center"><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
        </div><!-- /.col-lg-4 -->
        <div class="col-lg-4">
          <img class="img-circle center-block" src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" alt="" width="140" height="140">
          <h2 class="text-center">Heading</h2>
          <p class="text-center">Donec sed odio dui. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Vestibulum id ligula porta felis euismod semper. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>
          <p class="text-center"><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
        </div><!-- /.col-lg-4 -->
      </div><!-- /.row -->
    </div>    
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div class="container">
          <div class="row featurette">
        <div class="col-md-7">
          <h2 class="featurette-heading">Lorem ipsum sure.<span class="text-muted">It'll blow your mind.</span></h2>
          <p class="lead">Donec ullamcorper nulla non metus auctor fringilla. Vestibulum id ligula porta felis euismod semper. Praesent commodo cursus magna, vel scelerisque nisl consectetur. Fusce dapibus, tellus ac cursus commodo.</p>
        </div>
        <div class="col-md-5">
          <img class="featurette-image img-responsive center-block" src="../../Assets/img/kantor11.jpg" alt="Generic placeholder image">
        </div>
      </div>
    </div> 
</asp:Content>    

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
     <section class="page-section bg-primary text-white mb-0" id="about">
    <div class="container">
      <!-- About Section Heading -->
        <div class="col-md-12">
            <h2 class="text-center text-white">Lorem Ipsum</h2>
            <hr />
        </div>
      <!-- About Section Content -->
      <div class="row">
        <div class="col-lg-4 ml-auto">
          <p class="lead">Donec sed odio dui. Etiam porta sem malesuada magna mollis euismod. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna.</p>
        </div>
        <div class="col-lg-4 ml-auto">
          <p class="lead">Donec sed odio dui. Etiam porta sem malesuada magna mollis euismod. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna.</p>
        </div>
        <div class="col-lg-4 mr-auto">
          <p class="lead">Donec sed odio dui. Etiam porta sem malesuada magna mollis euismod. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna.</p>
        </div>
      </div>

    </div>
  </section>
</asp:Content>   

<asp:Content ID="Content6" ContentPlaceHolderID="footer" runat="server">
      <%--<div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
          <p class="navbar-text pull-left">© 2014 - Site Built By Mr. M.
               <a href="http://tinyurl.com/tbvalid" target="_blank" >HTML 5 Validation</a>
          </p>
          <a href="http://youtu.be/zJahlKPCL9g" class="navbar-btn btn-danger btn pull-right">
          <span class="glyphicon glyphicon-star"></span>  Subscribe on YouTube</a>
        </div>
    </div>--%>
</asp:Content>   




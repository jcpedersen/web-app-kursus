<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="gameHanoi._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="http://jquery-json.googlecode.com/files/jquery.json-2.3.min.js" type="text/javascript"></script>
    <script src="Scripts/HanoiTowers/hanoiVariables.js" type="text/javascript"></script>
    <script src="Scripts/HanoiTowers/arrayToJSON.js" type="text/javascript"></script>
    <script src="Scripts/HanoiTowers/moveDisks.js" type="text/javascript"></script>
    <script src="Scripts/HanoiTowers/hanoiGameSetup.js" type="text/javascript"></script>


<script  type="text/javascript">

    $(document).ready(function () {
        hanoiNewGame(9);

        $(document).on("click", function (event) {
            event.preventDefault();
            moveCheck(event);

            jsonArray = "[5,[-1,-1,-1,9,8,7,6,5,4],[-1,-1,-1,-1,-1,-1,-1,3,1],[-1,-1,-1,-1,-1,-1,-1,-1,2]]"
            $("#logView").html(_jsonOfTowers);
        });

    });
    </script>

<style type="text/css">

.towers
{
position:relative;
float:left;
margin: 2px 2px 2px 2px;
background-color:Gray;
height: 200px;
width: 100px;
border-color: Blue;
}

</style>

    <!-- Le styles -->
    <link href="Scripts/assets/css/bootstrap.css" rel="stylesheet">
    <link href="Scripts/assets/css/bootstrap-responsive.css" rel="stylesheet">
    <link href="Scripts/assets/js/google-code-prettify/prettify.css" rel="stylesheet">

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="btn-group">
        <button class="btn btn-info">Info</button>
        <button class="btn btn-info dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></button>
        <ul class="dropdown-menu">
            <li><a href="#"><i class="icon-file"></i> Load</a></li>
            <li><a href="#"><i class="icon-pencil"></i> Settings</a></li>              
            <li class="divider"></li>
            <li><a href="#"><i class="icon-trash"></i> Delete</a></li>
            <li class="divider"></li>
            <li><a href="#"><i class="icon-off"></i> Close</a></li>
        </ul>
    </div><!-- /btn-group -->

<div id="gameContainer">
    <div id="tower1" class="allowClick towers" ></div>
    <div id="tower2" class="allowClick towers"></div>
    <div id="tower3" class="allowClick towers"></div>
</div>
<div id="logView"></div>

    <script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
    <script src="Scripts/assets/js/google-code-prettify/prettify.js"></script>
    <script src="Scripts/assets/js/bootstrap-transition.js"></script>
    <script src="Scripts/assets/js/bootstrap-alert.js"></script>
    <script src="Scripts/assets/js/bootstrap-modal.js"></script>
    <script src="Scripts/assets/js/bootstrap-dropdown.js"></script>
    <script src="Scripts/assets/js/bootstrap-scrollspy.js"></script>
    <script src="Scripts/assets/js/bootstrap-tab.js"></script>
    <script src="Scripts/assets/js/bootstrap-tooltip.js"></script>
    <script src="Scripts/assets/js/bootstrap-popover.js"></script>
    <script src="Scripts/assets/js/bootstrap-button.js"></script>
    <script src="Scripts/assets/js/bootstrap-collapse.js"></script>
    <script src="Scripts/assets/js/bootstrap-carousel.js"></script>
    <script src="Scripts/assets/js/bootstrap-typeahead.js"></script>
    <script src="Scripts/assets/js/application.js"></script>

</asp:Content>

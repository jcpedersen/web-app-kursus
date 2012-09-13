<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="TowersOfHanoi.aspx.cs" Inherits="TowersOfHanoi._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

<title>Towers of Hanoi - using jQuery UI</title>

<link rel="stylesheet" type="text/css" href="jQueryUI/themes/base/jquery.ui.all.css" />
<link rel="stylesheet" type="text/css" href="jQueryUI/css/demos.css" />

<script type="text/javascript" src="jQueryUI/js/jquery-1.8.0.min.js"></script>
<script type="text/javascript" src="jQueryUI/ui/jquery.effects.core.js"></script>
<script type="text/javascript" src="jQueryUI/ui/jquery.ui.core.js"></script>
<script type="text/javascript" src="jQueryUI/ui/jquery.ui.widget.js"></script>
<script type="text/javascript" src="jQueryUI/ui/jquery.ui.mouse.js"></script>
<script type="text/javascript" src="jQueryUI/ui/jquery.ui.draggable.js"></script>
<script type="text/javascript" src="jQueryUI/ui/jquery.ui.droppable.js"></script>

<style type="text/css">
	p.clear { clear: both; }
	h1 {text-align: left}  /* or center ? */
	h2 {position:relative; text-align: center; bottom: 0; }
	li {margin: 0 0 0 2em; list-style-type: square;}  /* or circle ? */
	
	.tower { float: left; width: 170px; height: 200px; padding: 0.5em; margin: 10px; }

	.disk { position:relative; margin-right:auto; height: 18px; padding: 0.5em; }
	#disk1 { width: 40px; left: 60px; top: 10px; background: red}
	#disk2 { width: 50px; left: 55px; top: 10px; background: green}
	#disk3 { width: 60px; left: 50px; top: 10px; background: blue}
	#disk4 { width: 70px; left: 45px; top: 10px; background: orange}
	#disk5 { width: 80px; left: 40px; top: 10px; background: yellow}
</style>
	
<script>
    $(function () {
        //$( "#disk1" ).draggable({ revert: "valid" });
        $(".disk").draggable({ revert: "invalid" });

        $(".tower").droppable({
            activeClass: "ui-state-hover",
            hoverClass: "ui-state-active",
            drop: function (event, ui) {
                //console.log("Break here on drop!"); //NOT for IE !
                $(this)
                //.addClass( "ui-state-highlight" )
					.find("p").html("Dropped!");
            }
        });
    });
</script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<div class="demo">

<h1>Towers of Hanoi</h1>


<div id="tower1" class="tower ui-widget-header">
	<h2>Tower 1</h2>
	<div id="disk1" class="disk ui-widget-content">
		<p>Disk 1</p>
	</div>
	<div id="disk2" class="disk ui-widget-content">
		<p>Disk 2</p>
	</div>
	<div id="disk3" class="disk ui-widget-content">
		<p>Disk 3</p>
	</div>
	<div id="disk4" class="disk ui-widget-content">
		<p>Disk 4</p>
	</div>
	<div id="disk5" class="disk ui-widget-content">
		<p>Disk 5</p>
	</div>
</div>

<div id="tower2" class="tower ui-widget-header">
	<h2>Tower 2</h2>
</div>

<div id="tower3" class="tower ui-widget-header">
	<h2>Tower 3</h2>
</div>

<!-- Disks to be placed on the rods -->
<p class="clear">
</p>

</div><!-- End demo -->

</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoreTowers.aspx.cs" Inherits="Hanoi2.MoreTowers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
	<link rel="stylesheet" href="Styles/themes/base/jquery.ui.all.css" />
	<script type="text/javascript" src="Scripts/jquery-1.8.0.js"></script>
	<script type="text/javascript" src="Scripts/ui/jquery.ui.core.js"></script>
	<script type="text/javascript" src="Scripts/ui/jquery.ui.widget.js"></script>
	<script type="text/javascript" src="Scripts/ui/jquery.ui.mouse.js"></script>
	<script type="text/javascript" src="Scripts/ui/jquery.ui.draggable.js"></script>
	<script type="text/javascript" src="Scripts/ui/jquery.ui.droppable.js"></script>
	<link rel="stylesheet" href="Styles/demos.css" />

	<script  type="text/javascript">

	    $(document).ready(function() {
	        var lastdragged = "";

	        function dodrop(_fromtowerid, _totowerid) {


	            //$("#rightTower").append("from peg: " + _fromtowerid + ", move to peg " + _totowerid);

	            //Ajax call, try move...
	            act = "";
	            $.post('ajaxDoMove.aspx', { option: "load", script: "", fromtowerid: _fromtowerid, totowerid: _totowerid }, function(data) {

	                switch (act) {
	                    default:
	                        break;
	                }
	            });

	            //Refresh page
	            document.form1.submit();
	            //window.location = "../MoreTowers.aspx"

	        }


	        $("#<%= LeftTowerTopElement %>").draggable({

	            drag: function(event, ui) {
	                lastdragged = "#" + $(event.target).attr("id");
	            }
	        });
	        $("#<%= MiddleTowerTopElement %>").draggable({

	            drag: function(event, ui) {
	                lastdragged = "#" + $(event.target).attr("id");
	            }
	        });
	        $("#<%= RightTowerTopElement %>").draggable({

	            drag: function(event, ui) {
	                lastdragged = "#" + $(event.target).attr("id");
	            }
	        });

	        //$("#<%= LeftTowerTopElement %>").draggable("option", "revert", true);


	        $(".ui-widget-header").droppable({
	            drop: function(event, ui) {

	                totowerid = $(event.target).data("towerid");
	                fromtowerid = $(lastdragged).data("towerid");
	                //barsize = $(lastdragged).data("barsize");

	                dodrop(fromtowerid, totowerid);
	            }
	        });
	    });
	</script>

<style  type="text/css">
	#leftTower { width: 250px; height: 450px; padding: 0.5em; float: left; margin: 10px; }
	#middleTower { width: 250px; height: 450px; padding: 0.5em; float: left; margin: 10px; }
	#rightTower { width: 250px; height: 450px; padding: 0.5em; float: left; margin: 10px; }
	</style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="leftTower" runat="server" class="ui-widget-header" data-towerid="1" style="overflow: hidden">	        
        </div>

        <div id="middleTower" runat="server" class="ui-widget-header" data-towerid="2" style="overflow: hidden">	        
        </div>

        <div id="rightTower" runat="server" class="ui-widget-header" data-towerid="3" style="overflow: hidden">	        
        
            <div id='Div1' data-barsize='100' data-towerid='3' class='ui-widget-content' style='width: 200px; height: 30px; padding: 0.5em; float: left; margin: 10px 10px 10px 0; position: relative; top: 320px; left: 15px;' > <p>BarTest1</p> </div><div class='clear' style=' clear:both;  height:0;  width:100%;'></div>
            <div id='bar100' data-barsize='100' data-towerid='3' class='ui-widget-content' style='width: 200px; height: 30px; padding: 0.5em; float: left; margin: 10px 10px 10px 0; position: relative; top:320px; left: 15px;' > <p>BarTest2</p> </div> <div class='clear' style=' clear:both;  height:0;  width:100%;'></div>
        </div>
        <div class='clear' style=' clear:both;  height:0;  width:100%;'></div>
        <br />HINT: Drap-and-drop elementerne, fra den venstre mod den højre div. Undgå at droppe uden for de grå zoner... klik refresh hvis du alligevel gjorde det
        <br />
        <hr />
    <asp:Label ID="Label1" runat="server" Text="Antal Barrer"></asp:Label>
    <asp:TextBox ID="tbBars" runat="server" Text="3"></asp:TextBox>
        <asp:Button ID="btnRestart" runat="server" Text="Genstart" 
            onclick="btnRestart_Click" />
            &nbsp;
        <asp:Button ID="btnRefresh" runat="server" Text="Refresh siden" />
        <br />
        <hr />
        <div id="resultset" runat="server" 
            style="font-size: large; color: #FF0000; text-decoration: blink; font-weight: bold"></div>
        <br />

        
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDroppable.aspx.cs" Inherits="Hanoi2.TestDroppable" %>

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
	        $("#draggable").draggable();
	        $("#droppable").droppable({
	        drop: function(event, ui) {
	            //Source innerHTML
	            newtxt = $(event.currentTarget).find("p").html();
	            
	            //target...
	            $(event.target).find("p")
						.html(newtxt);
                //target
	                $(this)
					.addClass("ui-state-highlight")
	            }
	        });
	    });
	</script>

<style  type="text/css">
	#draggable { width: 100px; height: 100px; padding: 0.5em; float: left; margin: 10px 10px 10px 0; }
	#droppable { width: 150px; height: 150px; padding: 0.5em; float: left; margin: 10px; }
	</style>

</head>
<body>
    <form id="form1" runat="server">

        <div class="demo">
        	
        <div id="draggable" class="ui-widget-content">
	        <p>Drag me to my target</p>
        </div>

        <div id="droppable" class="ui-widget-header">
	        <p>Drop here</p>
        </div>

        </div><!-- End demo -->



    </form>
</body>
</html>

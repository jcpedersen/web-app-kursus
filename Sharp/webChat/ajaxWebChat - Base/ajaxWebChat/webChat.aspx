<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webChat.aspx.cs" Inherits="ajaxWebChat.webChat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>webChat 0.1</title>
    <script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <link href="style/chatStyle.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
	    .clsLoginBox {
		    background-color: Lime;
		    display: none;
		    height: 150px; 			    /* 150px */
		    width: 280px; 			    /* 280px */
		    /*position: absolute;*/
		    left:10%; right:10%;	/* 50% 50%*/
		    margin-left: 0; 		/* -50px */
		    margin-top: 0;	    	/* -50px */
	    }
    </style>


    <script  type="text/javascript">

        function chatLoad() {
            $.post("ajax/ajaxMsgLoad.aspx", { count: "", script: "msgLoad" }, function (data) {
                $("#msgView").prepend($("<div />").html(data).find("#container").html());
            });  //Post
        }

        function chatCount() {
            $.post("ajax/ajaxMsgLoad.aspx", { count: "", script: "msgCount" }, function (data) {
                tmpCount = $("<div />").html(data).find("#container").html();

                if (0 < tmpCount) {
                    chatLoad();

                }
                //setTimeout(function () { chatCount(); }, 1000); //Reload timer
            });     //Post
       }

       $(document).ready(function () {
           setTimeout(function () { chatCount(); }, 1000);
           //Code here execute  on page load
           $(document).on("click", function (event) {

               console.log(event.target);
               if ($(event.target).hasClass("btnSend")) {
                   event.preventDefault();
                   currentMsg = $("#msgSend").val();
                   $.post("ajax/ajaxMsgSave.aspx", { script: "save", msg: currentMsg }, function (data) {
                       $("#msgSend").val("");
                   }); //Post
               } //if btn check

               if ($(event.target).hasClass("btnLogin")) {
                   event.preventDefault();
                   $(".clsLoginBox").show();
                   //$(".clsLoginBox").show("fast");
                   //$(".clsLoginBox").css("display", "inline");
                   //console.log($("#clsLoginBox"));
                   //$.post("ajax/ajaxMsgSave.aspx", { script: "save", msg: currentMsg }, function (data) {
                   //}); //Post
               } //if btn check

           }); // onclick

       });       // document ready. 
    </script>

</head>
<body>
    <div id="msgView">
    </div>

<input id="msgSend" type="text" />
<button id="sendButton" type="button" class="btn btn-info btnSend" >Send Message</button>
<p></p>
<p>
    <button id="loginButton" type="button" class="btn btn-success btnLogin" >Login or Register</button>
</p>


<div class="clsLoginBox clsLoginGroup">
    <p>
	<input id="idUsername" type="text" value="Username or Email" />
    </p><p>
	<input id="idPassword" type="password" value="Password"/>
    </p>
	<!-- <input id="idRun" type="submit" value="Run"> -->
	<button id="idLoginAction" class="btn-success" url="" >
		<span>Login</span>
	</button>
</div>

</body>
</html>


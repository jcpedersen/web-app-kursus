<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ChatChatChat.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<%--<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script> --%>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" type="text/javascript"></script>

		<style type="text/css">
			.clsLoginBox {
				background-color: Lime;
				display: none;
				height: 0; 			    /* 150px */
				width: 0; 			    /* 280px */
				position: absolute;
				left:10%; right:10%;	/* 50% 50%*/
				margin-left: 0; 		/* -50px */
				margin-top: 0;	    	/* -50px */
			}
		</style>

		<script type="text/javascript">
		    $(document).ready(function () {
		        //alert('Document ready!');

		        $(".clsLoginBox").show();
		        $(".clsLoginBox").animate(
                     {width: "280px", height: "150px",
		             left: "50%",
		             opacity: 1.0
	    	         },
                 1000);
		        
                $("#idLoginAction").on("click", function (event) {
                    $(".clsLoginGroup").hide();
                    //$(".clsReadMe").html("Hej " + $("#idUsername").val());
		            //$("#idLogin").hide();
		        });

//		        $('#idPassword').keyup(function () {
//		            alert('Handler for .keyup() called.');
//		        });

//		        $("#idLogin").click(function () {
//		            $(".clsLoginBox").show();
//		            //$(".clsLoginBox").fadeTo("slow", 0.3);
//		            $(".clsLoginBox").animate({ width: "280px", height: "150px",
//		                left: "50%",
//		                opacity: 1.0
//		            }, 1000);
//		            //$(".clsLoginBox").fadeTo("slow", 1.0);
//		        });

		    });
		</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Login or register
    </h2>
	<div class="clsLoginBox clsLoginGroup">
		<p>Username or Email:</p>
		<input id="idUsername" type="text" value="Username or Email" />
		<p>Password:</p>
		<input id="idPassword" type="password" />
		<!-- <input id="idRun" type="submit" value="Run"> -->
		<button id="idLoginAction" class="btn-success" url="" >
			<span>Login</span>
		</button>
	</div>
</asp:Content>

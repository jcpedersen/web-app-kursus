<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HelloJson._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
	<script src="Scripts/assets/jquery-1.8.1.min.js" type="text/javascript"></script>
	<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/i18n/jquery-ui-i18n.min.js" type="text/javascript"></script>
	<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js" type="text/javascript"></script>
	<link rel="Stylesheet" href ="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/themes/base/jquery-ui.css" />

	<script type="text/javascript">

		function jsonRequest(event, targetType, targetSelector){
			event.preventDefault();
			$.ajax({
				url: "AjaxJson.asmx/TestTargetTypes",
				data: "{ targetType: '" + targetType + "', targetSelector: '" + targetSelector + "' }",
				type: "POST",
				datatype: 'json',
				contentType: "application/json",
				success: function (resultData) {
					jsonResponse(resultData);
				}
			});
		}

		function jsonResponse(jsonResult) {
			var result = $.parseJSON(jsonResult.d);
			$(result).each(function (i, elem) {
				switch (elem.TargetType) {
					case "dialogbox":
						$('<div></div>')
							.html(elem.Data.Body)
							.dialog({
								autoOpen: true,
								title: elem.Data.Title,
								buttons: [{
									text: elem.Data.ButtonText,
									click: function () { $(this).dialog("close"); }
								}]
							});
						break;
					case "javascript":
						$(elem.TargetSelector).html(elem.ScriptFunction);
						eval(elem.ScriptCallStatement);

						/* Andre javascript-load metoder:

						// jQuery load js-fil, og execute når loaded:
						$.getScript('lazy.js', function(jd) {
							CheckJS();
							});

						Headjs - http://headjs.com/
						curl - https://github.com/cujojs/curl		(understøtter load af jQuery & jQueryUI)
						*/
						break;
				}
			});
		}

		$(document).ready(function () {
			$("#testDialog").click(function (evnt) {
				jsonRequest(evnt, 'dialogbox', '');
			})

			$("#testScript").click(function (evnt) {
				jsonRequest(evnt, 'javascript', '#scriptPlaceHolder');
			})
		});
	</script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
		json
	</h2>
	<button id="testDialog">
		test dialog
	</button>
	<button id="testScript">
		test script
	</button>
	<div id="scriptPlaceHolder">
	</div>
</asp:Content>

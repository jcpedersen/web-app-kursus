<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebChat._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

<script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            function myTimer() {
                act = 'replace';
                currentscript = 'refresh';
                currenttarget = '#lbMessages';
                currentNewMsg = '';

                $.post('ajaxLoadFromEntityDB.aspx', { option: "load", script: currentscript, message: currentNewMsg }, function (data) {

                    switch (act) {
                        case "replace":
                            $(currenttarget).html(data);
                            break;
                    }
                });
            }

            setInterval(function () { myTimer() }, 1000);

            $(document).on("click", function (event) {
                // Global on click function


                if ($(event.target).hasClass("btn")) {

                    event.preventDefault();  // Prevent default events on links and buttons..

                    act = $(event.target).data("act");

                    currentscript = $(event.target).data("script");
                    currenttarget = '#' + $(event.target).data("target");

                    currentSource = '#' + $(event.target).data("source");
                    currentNewMsg = $(currentSource).val();
                    //currentNewMsg = document.getElementById("tbNewMessage").value;

                    //Database
                    $.post('ajaxLoadFromEntityDB.aspx', { option: "load", script: currentscript, message: currentNewMsg }, function (data) {

                        switch (act) {
                            case "replace":

                                $(currenttarget).html(data);
                                break;

                            case "append":

                                $(currenttarget).append(data);

                                break;
                            case "prepend":
                                break;
                            default:
                                break;
                        }
                    });
                }

            });
        });
	
    </script>


</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="lbMessages"
        style="border: thin dashed #00FF00; width: 500px; height: 300px" ></div>
    <br />
    <textarea style="width: 500px; border-style: solid; border-width: thin" 
        id="tbNewMessage" name="tbNewMessage" rows="1"></textarea>
    <br />
    <button type="button" class="btn" data-script="postmessage" data-act="append" data-target="lbMessages" data-source="tbNewMessage">Send Besked</button>
    <button type="button" class="btn" data-script="refresh" data-act="replace" data-target="lbMessages" data-source="tbNewMessage">Refresh Chat</button>
    <button type="button" class="btn" data-script="clear" data-act="replace" data-target="lbMessages" data-source="tbNewMessage">Slet Chat</button>
</asp:Content>

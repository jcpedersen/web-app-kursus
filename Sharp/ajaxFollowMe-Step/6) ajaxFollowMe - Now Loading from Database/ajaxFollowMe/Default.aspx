<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ajaxFollowMe._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>

    <script  type="text/javascript">
        $(document).ready(function () {
            //Code here execute on page load
            $(document).on("click", function (event) {
                //Global on click function

                if ($(event.target).hasClass("btn")) {
                    event.preventDefault();  //prevent default action of link and buttons
                    $("#theTarget").load("ajaxLoadFromServer.aspx #container");
                }

            });
        });
    </script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
This the Client.
  <button type="button" class="btn">Action</button>
<div id="theTarget"></div>
</asp:Content>

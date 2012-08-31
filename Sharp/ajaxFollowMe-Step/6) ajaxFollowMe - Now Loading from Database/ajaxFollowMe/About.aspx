<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="ajaxFollowMe.About" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>

    <script  type="text/javascript">
        $(document).ready(function () {
            //Code here execute on page load
            $(document).on("click", function (event) {
                //Global on click function

                if ($(event.target).hasClass("btn")) {
                    event.preventDefault();  //prevent default action of link and buttons
                    $.post('ajaxLoadFromDatabase.aspx', { option: "load", script: "Facebook" }, function (data) {
                        $('#theTarget').html(data);
                    });
                }

            });
        });
    </script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
This the Client.
  <button type="button" class="btn" data-script="helloWorld">Action</button>
<div id="theTarget"></div>
</asp:Content>

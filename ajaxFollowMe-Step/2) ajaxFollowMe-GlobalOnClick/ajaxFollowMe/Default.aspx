<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ajaxFollowMe._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>

    <script>
        $(document).ready(function () {
            //Code here execute on page load
            $(document).on("click", function (event) { 
                //Global on click function
            });
        });
    </script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
This the Client.

<div id="theTarget"></div>
</asp:Content>

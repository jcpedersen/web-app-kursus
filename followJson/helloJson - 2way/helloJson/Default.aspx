<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="helloJson._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

 <script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>

<script  type="text/javascript">

    $(document).ready(function () {
        var jsonString = '[{"OldIndex":2,"NewIndex":1},{"OldIndex":4,"NewIndex":3},{"OldIndex":6,"NewIndex":5}]';


        $.ajax({
            type: "POST",
            url: "ajaxJson.asmx/ProcessIndexes",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{'jsonValue': '" + jsonString + "'}",
            success: onsuccess,
            error: onerror
        });

        function onerror(result) {
            // Do something onerror.
        }

        function onsuccess(result) {
            // Do something onsuccess.
        }
    });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Json!
    </h2>

</asp:Content>

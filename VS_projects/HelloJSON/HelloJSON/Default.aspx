<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HelloJSON._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

<script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>

<script  type="text/javascript">

    $(document).ready(function () {

        $.ajax({
            // url: 'ajaxJson.asmx/HelloWorld',
            url: 'ajaxJson.asmx/baseJson',
            data: "{name: 'Jens Chr. Pedersen', email: 'jcpedersen@gmail.com'}",
            type: 'POST',
            dataType: 'json',
            contentType: "application/json",
            success: function (resultData) {
                //var localResult = $.parseJSON(resultData.d); //eller:
                var localResult = JSON.parse(resultData.d);

                $(localResult).each(function (i, elm) {
                    alert(elm.username + ", " + elm.Email);
                });
                // alert(resultData.d);
            }
        });
    });
    </script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Json!
    </h2>
    
</asp:Content>

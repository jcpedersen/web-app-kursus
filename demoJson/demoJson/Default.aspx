<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="demoJson._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

 <script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>

<script  type="text/javascript">

$(document).ready(function () {

        $.ajax({
                        url: 'ajaxJson.asmx/myJson',
                        data: "{data1: 'TextData1' ,data2: 'TextData2'}",
                        type: 'POST',
                        dataType: 'json',
                        contentType: "application/json",
                        success: function (resultData) {
                             var localResult = $.parseJSON(resultData.d);

                             $(localResult).each(function (i, elm) {
                                alert(elm.email1);
                              });
                            
                        }
               });
});
    </script>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
<div id="outPut"></div>
</asp:Content>

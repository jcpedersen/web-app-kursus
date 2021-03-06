﻿<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
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
                    currentScript = $(event.target).data("script");
                    act = $(event.target).data("act"); //<--- Add
                    currentTarget = "#" + $(event.target).data("target"); //<--- Add
                    $.post('ajaxLoadFromDatabase.aspx', { option: "load", script: currentScript }, function (data) {

                        //Add begin  
                        switch (act) {
                            case "replace":
                                  
                                $(currentTarget).html(data);
                                break;
                            case "append":
                                $(currentTarget).append(data);
                                break;
                            case "prepend":
                                $(currentTarget).prepend(data);
                                break;
                            default:
                        }
                        //Add End
                      
                    });
                }

            });
        });
    </script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
This the Client.
  <button type="button" class="btn" data-act="replace" data-script="helloWorld" data-target="theTarget">Hello World</button>
  <button type="button" class="btn" data-act="append" data-script="Facebook" data-target="secondTarget" >Facebook</button>
  <button type="button" class="btn" data-act="prepend" data-script="helloWorld" data-target="secondTarget">Prepend Hello World</button>
<br />
div theTarget: <br /> <!-- dette er bare html text <br /> == newline-->
<div id="theTarget"></div>
div secondTarget: <br /> <!-- dette er bare html text <br /> == newline-->
<div id="secondTarget"></div>
</asp:Content>

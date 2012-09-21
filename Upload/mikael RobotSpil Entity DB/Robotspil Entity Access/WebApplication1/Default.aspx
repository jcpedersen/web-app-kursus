<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>


    <script type="text/javascript">
        var r1, r2, gamedata;
        function displayGameFlow(_r1, _r2, _gamedata, _rounds) {
            r1 = $.parseJSON(_r1);
            r2 = $.parseJSON(_r2);
            gamedata = $.parseJSON(_gamedata);

            r1ShootCss = { fontSize: 250, opacity: 1, left: 300};
            r2ShootCss = { fontSize: 250, opacity: 1, left: -300};
            defendCss = { fontSize: 150, opacity: 1};

            for (var i = 0; i < gamedata.R1VAL.length; i++) {
                delay1 = i * 500;
                delay2 = (i * 500) + 500;

                if ((i % 2) == 0) {
                
                    //Robot1 angriber
                    $('<div class="r1 weapon">' + gamedata.R1VAL[i] + '</div>').appendTo('#robot1').hide().delay(delay1).show().animate(r1ShootCss).fadeOut();

                    $('<div class="r2 shield">' + gamedata.R2VAL[i] + '</div>').appendTo('#robot2').hide().delay(delay1).show().animate(defendCss).fadeOut();

                }
                else {
                
                    //Robot2 angriber. R2VAL er nu våben for Robot2...
                    $('<div class="r2 weapon">' + gamedata.R2VAL[i] + '</div>').appendTo('#robot2').hide().delay(delay1).show().animate(r2ShootCss).fadeOut();

                    $('<div class="r1 shield">' + gamedata.R1VAL[i] + '</div>').appendTo('#robot1').hide().delay(delay1).show().animate(defendCss).fadeOut();
                }

            }
            /*
            for (var i = 0; i < _rounds; i++) {
                delay1 = i * 500;
                delay2 = (i *500) + 500;

                l = i;
                if (i >= r1.vaaben.length) l = i % r1.vaaben.length;
                $('<div class="r1 weapon">' + r1.vaaben[l] + '</div>').appendTo('#robot1').hide().delay(delay1).show().animate(r1ShootCss).fadeOut();

                l = i;
                if (i >= r2.skjold.length) l = i % r2.skjold.length;
                $('<div class="r2 shield">' + r2.skjold[l] + '</div>').appendTo('#robot2').hide().delay(delay1).show().animate(defendCss).fadeOut();
                
                l = i;
                if (i >= r2.vaaben.length) l = i % r2.vaaben.length;
                $('<div class="r2 weapon">' + r2.vaaben[l] + '</div>').appendTo('#robot2').hide().delay(delay2).show().animate(r2ShootCss).fadeOut();

                l = i;
                if (i >= r1.skjold.length) l = i % r1.skjold.length;
                $('<div class="r1 shield">' + r1.skjold[l] + '</div>').appendTo('#robot1').hide().delay(delay2).show().animate(defendCss).fadeOut();
            }
            */
            $('.status').css({ opacity: 0 }).delay((gamedata.R1VAL.length * 2000) + 1000).animate({ opacity: 1 });

            /*$('.robot span[data-new]').each(function (i, el) {
                $(el).text($(el).data('new'));
            });*/
        }

    </script>

    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Robotspil
    </h2>
    
    <div ID="StatusDiv" class="status" runat="server">Vælg 2 robotter fra db eller upload 2. klik for at spille</div>
        

        <div id="robot1" class="robot">
            <asp:Label ID="Label1" runat="server" Text="Spiller 1, upload/vælg din robot"></asp:Label>
            <asp:ListBox ID="lbPerson1" runat="server"></asp:ListBox><br />

            <asp:FileUpload ID="FileUpload1" runat="server" />
            <div id="Robot1_Data" runat="server"></div>

            <a ID="A2" class="btn" runat="server" >Download</a>
        </div>

        <div id="robot2" class="robot">
            <asp:Label ID="Label2" runat="server" Text="Spiller 2, upload/vælg din robot"></asp:Label>
            <asp:ListBox ID="lbPerson2" runat="server"></asp:ListBox><br />

            <asp:FileUpload ID="FileUpload2" runat="server" />
            <div id="Robot2_Data" runat="server"></div>

            <a ID="A3" class="btn" runat="server" >Download</a>
        </div>
        <p>
        
        <asp:Button ID="Button1" class="btn btn-large btn-primary" runat="server" Text="Fight!!!" onclick="Button1_Click" />

        
    </p>

        
    
</asp:Content>

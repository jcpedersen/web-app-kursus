<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
    
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Prebens Robot spil
    </h2>
    <p>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" Text="Save file 1" onclick="btnSave_Click" />
        <asp:Button ID="btnLoad" runat="server" Text="Load file 1" onclick="btnLoad_Click" />
    </p>
    <p>
        <asp:Button ID="btnSave2" runat="server" Text="Save file 2" 
            onclick="btnSave2_Click" />
        <asp:Button ID="btnLoad2" runat="server" Text="Load file 2" 
            onclick="btnLoad2_Click" />
    </p>
    <p>
        <!-- -->
        <!-- User info window -->
        <asp:TextBox ID="tbResult" TextMode="MultiLine" Rows="15" Columns="100" runat="server"></asp:TextBox>
    </p>
    <p>
        <!-- Error message -->
        <asp:Label ID="Label9" runat="server" Text="    Error message:"></asp:Label>
        <asp:TextBox ID="tbErrorMessage" runat="server" Width="377px"></asp:TextBox>
    </p>
    <p>
        <!-- Add play data to one of the robot files -->
        <asp:Button ID="btnAddToFile1" runat="server" Text="Add to Robot1" 
            Width="104px" onclick="btnAddToFile1_Click" />
        <asp:Button ID="btnAddToFile2" runat="server" Text="Add to Robot2" 
            Width="104px" onclick="btnAddToFile2_Click" />
        <asp:Label ID="Label6" runat="server" Text="navn:"></asp:Label>
        <asp:TextBox ID="tbNavn" runat="server" Width="96px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="tab:"></asp:Label>
        <asp:TextBox ID="tbTab" runat="server" Width="77px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="sejre:"></asp:Label>
        <asp:TextBox ID="tbSejre" runat="server" Width="69px"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="liv:"></asp:Label>
        <asp:TextBox ID="tbLiv" runat="server" Width="95px"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="uafgjort:"></asp:Label>
        <asp:TextBox ID="tbUafgjort" runat="server" Width="69px"></asp:TextBox>
   </p>
   <p>
       <!-- Add one runde to one of the robot files -->
       <asp:Button ID="bdnAddRundeToFile1" runat="server" Text="Add to Robot1" 
           Width="103px" onclick="bdnAddRundeToFile1_Click" />
       <asp:Button ID="btnAddRundeToFile2" runat="server" Text="Add to Robot2" 
           Width="104px" onclick="btnAddRundeToFile2_Click" />

       <asp:Label ID="lbSkjold" runat="server" Text="skjold:"></asp:Label>
       <asp:TextBox ID="tbSkjold" runat="server" Width="93px"></asp:TextBox>
       <asp:Label ID="lbVaaben" runat="server" Text="vaaben:"></asp:Label>
       <asp:TextBox ID="tbVaaben" runat="server" Width="83px"></asp:TextBox>
   </p>
   <p>
       <asp:Button ID="btnPlay" runat="server" Font-Bold="true"  Font-Size="XX-Large" 
           Text="Play" Height="81px" 
           Width="209px" onclick="btnPlay_Click" />
       <asp:Label ID="Label7" runat="server" Text="Max. antal runder:"></asp:Label>
       <asp:TextBox ID="tbNumberOfRunder" runat="server"></asp:TextBox>
   </p>
    
</asp:Content>

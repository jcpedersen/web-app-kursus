<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="RobotSpil_WebApplikation._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Robot spil (unfinished)</h2>
    <h2>
        <asp:TextBox ID="LoadRobot1TextBox" runat="server" 
            ontextchanged="TextBox1_TextChanged"></asp:TextBox>
    </h2>
    <p>
        <asp:TextBox ID="LoadRobot2TextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Run" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Robot1UploadButton" runat="server" 
            onclick="Robot1UploadButton_Click" Text="Upload Robot 1" />
        <asp:Label ID="Label1" runat="server" 
            Text="The upload function is not used not, but now i know how it works and that's enough."></asp:Label>
    </p>
    <p>
        
        <asp:Label ID="GameWindow" runat="server" Text="Label"></asp:Label>
        
    </p>
</asp:Content>

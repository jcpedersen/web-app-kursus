<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ChatChatChat._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to the CHAT
    </h2>
    <p>
        <asp:Button ID="LoginButton" runat="server" Text="Login på chatten" PostBackUrl="~/LoginForm.aspx" />
        
    </p>
    <p>
        Paragraph 2
    </p>
</asp:Content>

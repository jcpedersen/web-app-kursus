<%@ Page Title="Help Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Settings.aspx.cs" Inherits="TowersOfHanoi.Settings" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Settings for the Towers Of Hanoi Puzzle
    </h2>
<h2>&nbsp;</h2>
<strong>Numbers of disks to play with: &nbsp</strong>

    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Selected="True">3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
    </asp:DropDownList>
  
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
  
</asp:Content>

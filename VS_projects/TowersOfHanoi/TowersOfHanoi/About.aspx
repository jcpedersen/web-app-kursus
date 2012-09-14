<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="TowersOfHanoi.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Towers Of Hanoi Rules
    </h2>

<strong>The objective of the puzzle is to move the entire stack to another rod, obeying the following rules:</strong>
<br /><p></p>
<ul>
    <li>Only one disk may be moved at a time.</li>
    <li>Each move consists of taking the upper disk from one of the rods and sliding it onto another rod, on top of the other disks that may already be present on that rod.</li>
    <li>No disk may be placed on top of a smaller disk.</li>
</ul>
    <hr></hr>
<h3>If you want to contact me, you can use this form:</h3>
    <p>
        <textarea id="TextArea1" cols="20" name="S1" rows="2"></textarea>
    </p>

    <asp:Button ID="SendMail" runat="server" onclick="SendMail_Click"  Text="Send Mail" />
    
</asp:Content>

﻿<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="TowersOfHanoi.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Towers Of Hanoi Rules
    </h2>
    <p>
The objective of the puzzle is to move the entire stack to another rod, obeying the following rules:
<li>Only one disk may be moved at a time.</li>
<li>Each move consists of taking the upper disk from one of the rods and sliding it onto another rod, on top of the other disks that may already be present on that rod.</li>
<li>No disk may be placed on top of a smaller disk.</li>
    </p>
</asp:Content>
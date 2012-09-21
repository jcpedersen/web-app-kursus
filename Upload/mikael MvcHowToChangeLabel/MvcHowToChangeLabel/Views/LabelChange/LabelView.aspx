<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcHowToChangeLabel.Models.LabelChangeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LabelView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h2>LabelView</h2>

    <% using (Html.BeginForm()) { %>
            <%: Html.ValidationSummary(true, "") %>

        <div>
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                </div>
                <p>
                    <input type="submit" name="Command" value="Skift Textbox Metode1" />
                    <br />
                    <input type="submit" name="Command" value="Skift Textbox Metode2" />
                    <br />
                    <input type="submit" name="Command" value="Skift Label" />
                </p>
            </fieldset>
        </div>
    <% } %>

</asp:Content>

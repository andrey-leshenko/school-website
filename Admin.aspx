<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">
ניהול
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
    <style>
        table, th, td
        {
            border-width: thin;
            border-style: solid;
            
        }
        th, td
        {
            padding: 0.2em;
            margin: 0;
        }
    </style>
    <script src="Scripts/FormValidation.js"></script>
    <script>
        function deleteUser(email) {
            var form = document.getElementsByTagName("form")[0];
            form.deleteUser.value = email;
            form.submit();
        }
        function setAdmin(email) {
            var form = document.getElementsByTagName("form")[0];
            form.setAdmin.value = email;
            form.submit();
        }
        function unsetAdmin(email) {
            var form = document.getElementsByTagName("form")[0];
            form.unsetAdmin.value = email;
            form.submit();
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" Runat="Server">
    ניהול
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" Runat="Server">
    <p>
        מונה מבקרים: <%=visitors %>
    </p>
    <form runat="server" method="post" onsubmit="cleanForm(document.forms[0])">
        <input type="hidden" value="" name="deleteUser"/>
        <input type="hidden" value="" name="setAdmin" />
        <input type="hidden" value="" name="unsetAdmin" />

        <input type="text" value="" name="search" runat="server" id="searchString"/>
        <input type="submit" value="חפש"/>
    </form>
    <br />
    <%=usersTable %>
</asp:Content>


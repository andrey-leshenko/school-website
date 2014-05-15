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

    <script>
        function deleteUser(email) {
            aspnetForm.deleteUser.value = email;
            aspnetForm.submit();
        }
        function setAdmin(email) {
            aspnetForm.setAdmin.value = email;
            aspnetForm.submit();
        }
        function unsetAdmin(email) {
            aspnetForm.unsetAdmin.value = email;
            aspnetForm.submit();
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
    
    <form runat="server" method="post" >
        <input type="hidden" value="" name="deleteUser"/>
        <input type="hidden" value="" name="setAdmin" />
        <input type="hidden" value="" name="unsetAdmin" />

        <input type="text" value="" name="search" runat="server" id="searchString"/>
        <input type="submit" value="חפש"/>
    </form>
    <br />
    <%=usersTable %>
</asp:Content>


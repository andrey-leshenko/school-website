<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
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
            adminActions.deleteUser.value = email;
            adminActions.submit();
        }
        function setAdmin(email) {
            adminActions.setAdmin.value = email;
            adminActions.submit();
        }
        function unsetAdmin(email) {
            adminActions.unsetAdmin.value = email;
            adminActions.submit();
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" Runat="Server">
    ניהול
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" Runat="Server">
    <form id="adminActions" name="adminActions" runat="server" method="post" >
        <input type="hidden" value="" name="deleteUser"/>
        <input type="hidden" value="" name="setAdmin" />
        <input type="hidden" value="" name="unsetAdmin" />
    </form>

    <table>
    <tr>
        <th>Email</th>
        <th>ID</th>
        <th>First Name</th>
        <th>Last Name</th>
        <th>Admin</th>
        <th>Delete</th>
    </tr>
    <%=usersTable %>
    </table>

</asp:Content>


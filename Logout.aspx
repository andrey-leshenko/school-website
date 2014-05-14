<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Default3" %>

<%--Normally this page shouldn't be seen--%>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">
...
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" Runat="Server">
    Logging out...
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" Runat="Server">
<p>
    If you aren't redirected automatically press the link below
</p>
<a href="Default.aspx">
    Back to homepage
</a>
</asp:Content>


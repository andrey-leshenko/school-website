<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" Runat="Server">
    התחברות
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" Runat="Server">
    <div class="form-container">
        <form runat="server" method="post">
            <div class="form-descriptions">
                כתובת דוא"ל:<br />
                סיסמא:
            </div>
            <div class="form-fileds">
                <input type="text" name="loginEmail"/><br />
                <input type="password" name="loginPassword"/>
            </div>
            <div class="submit-container">
                <input type="submit" name="submit"/>
            </div>
            <div>
                <%=loginResponse %>
             </div>
        </form>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" Runat="Server">
    התחברות
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" Runat="Server">
    <div id="login-wrapper">
        <form runat="server">
            <div class="form-descriptions">
                אמייל :<br />
                סיסמא :
            </div>
            <div class="form-fileds">
                <input type="text" name="loginEmail" />
                <br />
                <input type="password" name="loginPassword" />
                <input type="submit" name="submit"/>
            </div>
             <%=loginResponse %>
        </form>
    </div>
</asp:Content>


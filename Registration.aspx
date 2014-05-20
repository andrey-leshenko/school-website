<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="Server">
    הרשמה
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="Server">
    <script type="text/javascript" src="Scripts/FormValidation.js">
        // Exports: checkDetailsForm(form)
        // Requires:
        //          form.firstName
        //          form.lastName
        //          form.id
        //          form.userPassword
        //          form.repeatPassword
        //          form.email
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" runat="Server">
    הרשמה
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" runat="Server">
<div class="form-container">
<script>
    function getForm() {
        return asd;
    }
    </script>
    <form runat="server" onsubmit="return checkDetailsForm(document.forms[0])">
        <div class="form-descriptions">
            שם:         <br />
            שם משפחה:   <br />
            מספר ת"ז:   <br />
            סיסמא:      <br />
            סיסמא שוב:  <br />
            מייל:
        </div>
        <div class="form-fileds">
            <input type="text"      name="firstName" />         <br />
            <input type="text"      name="lastName" />          <br />
            <input type="text"      name="id" />                <br />
            <input type="password"  name="userPassword" />      <br />
            <input type="password"  name="repeatPassword" />    <br />
            <input type="text"      name="email" />
        </div>
        <div class="submit-container">
            <input type="submit" name="submit" />
        </div>
    </form>
    <p>
        <%=serverResponse%>
    </p>
</div>
</asp:Content>
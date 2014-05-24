<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateDetails.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="Server">
    עדכון פרטים
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="Server">
    <script type="text/javascript" src="Scripts/FormValidation.js">
        // Exports: checkDetailsForm(form)
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" runat="Server">
    עדכון פרטים
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" runat="Server">
<div class="form-container">
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
            <%=formInputs %>
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
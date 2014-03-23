<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function checkForm() {
            var firstName = inputForm.firstName.value;
            var lastName = inputForm.lastName.value;
            var firstPassword = inputForm.userPassword.value;
            var secondPassword = inputForm.repeatPassword.value;
            var email = inputForm.email.value;

            if (firstName == "" || lastName == "" || firstPassword == "" || secondPassword == "" || email == "") {
                alert("The entire form must be filled");
                return false;
            }

            if (!isValidName(firstName)) {
                alert("Invalid first name");
                return false;
            }
            if (!isValidName(lastName)) {
                alert("Invalid lastName name");
                return false;
            }

            if (firstPassword != secondPassword) {
                alert("passwords don't match");
                return false;
            }

            if (!isValidEmail(email)) {
                alert("Invalid email");
                return false;
            }

            alert("everything is fine!");
            return true;
        }
        function isValidName(name) {
            name = name.toLowerCase();
            var i;
            for (i = 0; i < name.length; i++) {
                if ((name.charCodeAt(i) < 'a'.charCodeAt(0) || name.charCodeAt(i) > 'z'.charCodeAt(0)) && name.charAt(i) != ' ' && name.charAt(i) != '-') {
                    return false;
                };
            }
            return true;
        }
        function isValidEmail(email) {
            if (email.indexOf('.') == -1 || email.indexOf('.') == 0 || email.indexOf('.') == email.length - 1 || email.lastIndexOf('.') < email.indexOf('@')) {
                return false;
            }
            if (email.indexOf('@') == -1 || email.indexOf('@') == 0 || email.indexOf('@') == email.length - 1 || email.indexOf('@') != email.lastIndexOf('@')) {
                return false;
            }
            if (isContinuous(email)) {
                return false;
            }
            return true;
        }
	</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" Runat="Server">
    הרשמה
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" Runat="Server">
    <form id="inputForm" runat="server" name="inputForm" onsubmit="return checkForm()" method="post">
        <table>
	        <tr><td><label>שם</label><td>               <td><input type="text"     name="firstName"/></td></tr>
	        <tr><td><label>שם משפחה</label><td>         <td><input type="text"      name="lastName"/></td></tr>
            <tr><td><label>מספר ת"ז</label><td>         <td><input type="text"      name="id" /></td></tr>
	        <tr><td><label>סיסמא</label><td>            <td><input type="password"  name="userPassword"/></td></tr>
	        <tr><td><label>סיסמא שנית</label><td>       <td><input type="password"  name="repeatPassword"/></td></tr>
	        <tr><td><label>מייל</label><td>             <td><input type="text"      name="email"/></td></tr>
        </table>

        <button type="submit" name="submit" value="Submit">Submit</button>

	</form>
    <p>
        <%=serverResponse%>
    </p>
</asp:Content>



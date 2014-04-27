<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateDetails.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function checkForm() {
            var firstName = inputForm.firstName.value;
            var lastName = inputForm.lastName.value;
            var id = inputForm.id.value;
            var firstPassword = inputForm.userPassword.value;
            var secondPassword = inputForm.repeatPassword.value;
            var email = inputForm.email.value;

            if (firstName == "" || lastName == "" || firstPassword == "" || secondPassword == "" || email == "" || id == "") {
                alert("The entire form must be filled");
                return false;
            }

            if (firstName != "" && !isValidName(firstName)) {
                alert("Invalid first name");
                return false;
            }
            if (lastName != "" && !isValidName(lastName)) {
                alert("Invalid lastName name");
                return false;
            }

            if (id != "" && !isValidId(id)) {
                alert("Invalid ID number");
                return false;
            }

            if (firstPassword != secondPassword) {
                alert("passwords don't match");
                return false;
            }

            if (email != "" && !isValidEmail(email)) {
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
        function isValidId(id) {
            if (id.trim().length != 9 || isNaN(id))
                return false;
            else
                return true;
        }
	</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" Runat="Server">
    עדכון פרטים
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" Runat="Server">
    <form id="inputForm" runat="server" name="inputForm" onsubmit="return checkForm()" method="post">
        <table>
	        <tr><td><label>שם</label>               <input type="text"     name="firstName" value="hi"/></td></tr>
	        <tr><td><label>שם משפחה</label>         <input type="text"      name="lastName"/></td></tr>
	        <tr><td><label>סיסמא</label>            <input type="password"  name="userPassword"/></td></tr>
	        <tr><td><label>סיסמא שנית</label>       <input type="password"  name="repeatPassword"/></td></tr>
	        <tr><td><label>מייל</label>             <input type="text"      name="email"/></td></tr>
        </table>

        <button type="submit" name="submit" value="Submit">Submit</button>

	</form>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="Server">
    הרשמה
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkForm() {
            var firstName = inputForm.firstName.value;
            var lastName = inputForm.lastName.value;
            var id = inputForm.id.value;
            var firstPassword = inputForm.userPassword.value;
            var secondPassword = inputForm.repeatPassword.value;
            var email = inputForm.email.value;

            if (firstName == "" || lastName == "" || firstPassword == "" || secondPassword == "" || email == "" || id == "")
                return failWithMessage("The entire form must be filled");

            if (!isValidName(firstName))
                return failWithMessage("Invalid first name");

            if (!isValidName(lastName))
                return failWithMessage("Invalid lastName name");

            if (!isValidId(id))
                return failWithMessage("Invalid ID number");

            if (firstPassword != secondPassword)
                return failWithMessage("passwords don't match");

            if (!isValidEmail(email))
                return failWithMessage("Invalid email");

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
        function failWithMessage(message) {
            alert(message);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainTitleText" runat="Server">
    הרשמה
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageBodyText" runat="Server">
    <form id="inputForm" runat="server" name="inputForm" onsubmit="return checkForm()" method="post">
        <table>
            <tr>
                <td>שם</td>
                <td><input type="text" name="firstName" /></td>
            </tr>
            <tr>
                <td>שם משפחה</td>
                <td><input type="text" name="lastName" /></td>
            </tr>
            <tr>
                <td>מספר ת"ז</td>
                <td><input type="text" name="id" /></td>
            </tr>
            <tr>
                <td>סיסמא</td>
                <td><input type="password" name="userPassword" /></td>
            </tr>
            <tr>
                <td>סיסמא שנית</td>
                <td><input type="password" name="repeatPassword" /></td>
            </tr>
            <tr>
                <td>מייל</td>
                <td><input type="text" name="email" /></td>
            </tr>
        </table>

        <button type="submit" name="submit" value="Submit">Submit</button>
    </form>
    <p>
        <%=serverResponse%>
    </p>
</asp:Content>
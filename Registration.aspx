﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<style type="text/css">
	</style>

	<script type="text/javascript">

	    function checkForm() {
	        var firstName = inputForm.firstName.value;
	        var lastName = inputForm.lastName.value;
	        var phone = inputForm.phone.value;
	        var firstPassword = inputForm.userPassword.value;
	        var secondPassword = inputForm.repeatPassword.value;
	        var email = inputForm.email.value;

	        if (firstName == "" || lastName == "" || phone == ""
                || firstPassword == "" || secondPassword == "" || email == "") {
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
	        if (!isValidPhone(phone)) {
	            alert("Invalid phone");
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
	    function isValidPhone(phone) {
	        var i;
	        if (phone.charAt(0) != 0) {
	            return false;
	        }
	        for (i = 0; i < phone.length; i++) {
	            if (isNaN(parseInt(phone.charAt(i))) && phone.charAt(i) != '-') {
	                return false;
	            }
	        }
	        return true;
	    }

	</script>
</head>

<body>
	<form id="inputForm" runat="server" name="inputForm" onsubmit="return checkForm()" method="post">
	First name:         <input type="text"      name="firstName"/><br/>
	Last name:          <input type="text"      name="lastName"/><br/>
	Phone:              <input type="text"      name="phone"/><br/>
	Password:           <input type="password"  name="userPassword"/><br/>
	Repeat Password:    <input type="password"  name="repeatPassword"/><br/>
	Email:              <input type="text"      name="email"/><br/>

    <button type="submit" name="submit" value="Submit">Submit</button>

	</form>
    <p>
        <%=serverResponse%>
    </p>
</body>
</html>



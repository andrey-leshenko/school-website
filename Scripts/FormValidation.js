// This script's main function checks if the form is filled
// with legit values, and can be processes at server side

// It's important the the names of the inputs don't change

function checkDetailsForm(form) {
    var firstName = form.firstName.value;
    var lastName = form.lastName.value;
    var id = form.id.value;
    var firstPassword = form.userPassword.value;
    var secondPassword = form.repeatPassword.value;
    var email = form.email.value;

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
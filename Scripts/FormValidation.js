function checkDetailsForm(form) {
    var firstName       = form.firstName.value;
    var lastName        = form.lastName.value;
    var id              = form.id.value;
    var firstPassword   = form.userPassword.value;
    var secondPassword  = form.repeatPassword.value;
    var email           = form.email.value;

    if (firstName == "" || lastName == "" || firstPassword == "" || secondPassword == "" || email == "" || id == "")
        return failWithMessage("The entire form must be filled");
    if (firstName.length > 30)
        return failWithMessage("The first name can't be longer than 30 characters");
    if (lastName.length > 30)
        return failWithMessage("The last name can't be longer than 30 characters");
    if (email.length > 50)
        return failWithMessage("The email can't be longer than 50 characters");
        

    if (!isValidName(firstName))
        return failWithMessage("Invalid first name.\nMust contain only hebrew letters, spaces, and hypens");
    if (!isValidName(lastName))
        return failWithMessage("Invalid last name.\nMust contain only hebrew letters, spaces, and hypens");
    if (!isValidId(id))
        return failWithMessage("Invalid ID number");
    if (firstPassword != secondPassword)
        return failWithMessage("Passwords don't match");
    if (!isValidEmail(email))
        return failWithMessage("Invalid email");

    return true;
}

function isValidName(name) {
    name = name.toLowerCase();
    
    for (var i = 0; i < name.length; i++) {
        var c = name.charAt(i);
        if ((c < 'א' || c > 'ת') && c != ' ' && c != '-')
            return false;
    }
    return true;
}
function isValidEmail(email) {
    name = name.toLowerCase();
    var atIndex = email.indexOf('@');
    if (email.indexOf('.') == -1 || email.indexOf('.') == 0 || email.lastIndexOf('.') < atIndex)
        return false;
    if (atIndex == -1 || atIndex == 0 || atIndex == email.length - 1 || atIndex != email.lastIndexOf('@'))
        return false;
    for (var i = 0; i < email.length; i++) {
        var c = email.charAt(i);
        if ((c < 'a' || c > 'z') && (c < '0' || c > '9') && c != '-' && c != "_" && c != '.' && c != '@')
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
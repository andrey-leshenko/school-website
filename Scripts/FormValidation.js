// This script's main function checks if the form is filled
// with legit values, and can be processes at server side

// It's important the the names of the inputs don't change

function checkDetailsForm(form) {
    cleanForm(form);

    var firstName = form.firstName.value;
    var lastName = form.lastName.value;
    var id = form.id.value;
    var firstPassword = form.userPassword.value;
    var secondPassword = form.repeatPassword.value;
    var email = form.email.value;

    if (firstName == "" || lastName == "" || firstPassword == "" || secondPassword == "" || email == "" || id == "")
        return failWithMessage("The entire form must be filled");

    if (firstName.length > 30)
        return failWithMessage("The first name can't be longer than 30 characters");
    if (lastName.length > 30)
        return failWithMessage("The last name can't be longer than 30 characters");
    if (email.length > 50)
        return failWithMessage("The email can't be longer than 50 characters");
        

    if (!isValidName(firstName))
        return failWithMessage("Invalid first name.\nMust contain only hebrew or english letters, spaces, and hypens");

    if (!isValidName(lastName))
        return failWithMessage("Invalid last name.\nMust contain only hebrew or english letters, spaces, and hypens or single qoutes");

    if (!isValidId(id))
        return failWithMessage("Invalid ID number");

    if (firstPassword != secondPassword)
        return failWithMessage("passwords don't match");

    if (!isValidEmail(email))
        return failWithMessage("Invalid email");

    return true;
}

function cleanForm(form) {
    for (var i = 0; i < form.elements.length; i++) {
        if (form.elements[i].type == "text") {
            form.elements[i].value = form.elements[i].value.trim();
            // replacing single qoute by backtick, saves us from sql errors
            form.elements[i].value = form.elements[i].value.replace("'", "`");
        }
    }
}

function isValidName(name) {
    name = name.toLowerCase();
    
    for (var i = 0; i < name.length; i++) {
        var c = name.charAt(i);
        if ((c < 'a' || c > 'z') && (c < 'א' || c > 'ת') && c != ' ' && c != '-' && c != "`")
            return false;
    }
    return true;
}
function isValidEmail(email) {
    if (email.indexOf('.') == -1 || email.indexOf('.') == 0 || email.indexOf('.') == email.length - 1 || email.lastIndexOf('.') < email.indexOf('@'))
        return false;
    if (email.indexOf('@') == -1 || email.indexOf('@') == 0 || email.indexOf('@') == email.length - 1 || email.indexOf('@') != email.lastIndexOf('@'))
        return false;
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
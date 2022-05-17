function passwordStrengthChecker() {
    var passwordField = document.getElementById("passwordTextBox");
    var password = passwordField.value;
    var passwordStrength = 0;

    if (/[a-z]/.test(password)) {
        passwordStrength += 20;
    }
    if (/[A-Z]/.test(password)) {
        passwordStrength += 20;
    }
    if (/[\d]/.test(password)) {
        passwordStrength += 20;
    }
    if (password.length >= 14) {
        passwordStrength += 20;
    }
    if (password.length >= 18) {
        passwordStrength += 20;
    }

    var strength = "";
    var backgroundColor = "";

    if (passwordStrength >= 100) {
        strength = "Password is very strong";
        backgroundColor = "green";
    }
    else if (passwordStrength >= 80) {
        strength = "Password is strong";
        backgroundColor = "lightgreen";
    }
    else if (passwordStrength >= 60) {
        strength = "Password is okay";
        backgroundColor = "yellow";
    }
    else if (passwordStrength >= 40) {
        strength = "Password is weak";
        backgroundColor = "orange";
    }
    else if (passwordStrength >= 20) {
        strength = "Password is insecure";
        backgroundColor = "red";
    }
    document.getElementById("strengthOfPassword").innerHTML = strength;
    passwordField.style.color = "white";
    passwordField.style.backgroundColor = backgroundColor;
}


async function signUp() {
    const mail = document.querySelector("#newUserName")
    const userfirstname = document.querySelector("#newFirstName")
    const userlastname = document.querySelector("#newLastName")
    const password = document.querySelector("#newPassword")
    const user = {
        userId: 1,
        gmail: mail.value,
        userfirstname: userfirstname.value,
        userlastname: userlastname.value,
        password: password.value
    };
    const response = await fetch('api/users',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

    if (response.status === 201) {
        alert("ברוך הבא");
    }
};

async function signIn() {
    const mail = document.querySelector(".userName")
    const password = document.querySelector(".password")
    const user = {
        userId: -15,
        gmail: mail.value,
        userfirstname: "",
        userlastname: "",
        password: password.value
    };
    const response = await fetch('api/users/Login',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
    if (response.status === 200) {
        const responseJson = await response.json();
        sessionStorage.setItem("mySessionStore", JSON.stringify(responseJson))
        alert("משתמש קיים!");
        window.location.href = "home.html";
    }
    else if (response.status === 404) {
        alert("משתמש לא קיים!");
    }
    else {
        alert("שגיאה בשרת!");
    }

};
function openSignUp() {
    const newuser = document.querySelector(".newUser")
    newuser.style.display = "block"
};


async function checkStrength() {
    console.log("login.js loaded");
    const p = document.querySelector("#newPassword");
    const strengthElement = document.querySelector("progress");
    const newPassword = {
        Password: p.value,
        Strength: 100
    };
    const response = await fetch('api/password/pass',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newPassword)
        });
    console.log("login.js loaded 2");
   
    const data = await response.json();
    console.log(data.strength);
    if (response.status === 200) {
        strengthElement.value = data.strength+1;
    }
    else {
        strengthElement.value = 0;
    }

};


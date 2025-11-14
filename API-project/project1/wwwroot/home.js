const name = document.querySelector(".name")
const mySessionData = sessionStorage.getItem("mySessionStore")
const currentName = JSON.parse(mySessionData)
name.textContent = currentName.userFirstName;
async function   update() {
    const mail = document.querySelector("#userName")
    const userfirstname = document.querySelector("#firstName")
    const userlastname = document.querySelector("#lastName")
    const password = document.querySelector("#password")
    const user = {
        userId: currentName.userId,
        gmail: mail.value,
        userFirstName: userfirstname.value,
        userLastName: userlastname.value,
        password: password.value
    };

    const userJson = await JSON.stringify(user)
    sessionStorage.setItem("mySessionStore", userJson)
    
    const response = await fetch(`api/users/${user.userId}`,
        {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'

            },
            body:  JSON.stringify(user)
        });
    alert("השינויים עודכנו 1");
    const t = document.querySelector(".name")
    t.textContent = userfirstname.value;
}
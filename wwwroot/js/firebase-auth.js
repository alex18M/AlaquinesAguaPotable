async function firebaseLogin(email, password) {
    try {
        await firebase.auth().signInWithEmailAndPassword(email, password);
        return "success";
    } catch (error) {
        console.error(error);
        return "error";
    }
}

function firebaseLogout() {
    firebase.auth().signOut();
}

function firebaseGetUserEmail() {
    const user = firebase.auth().currentUser;
    return user ? user.email : null;
}

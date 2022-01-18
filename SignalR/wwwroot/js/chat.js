"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

let enterGroupForm = document.getElementById("enterGroupForm");
let leaveGroupBtn = document.getElementById("leaveGroupBtn")
let SendMessageForm = document.getElementById("sendMessageForm")

enterGroupForm.addEventListener("submit", function (ev) {
    ev.preventDefault();
    let user = {
        username: document.getElementById("username").value,
        group: document.getElementById("group").value
    }
    localStorage.setItem("user", JSON.stringify(user));
    showArea();
    document.getElementById("joinArea").classList.add("d-none");
})

leaveGroupBtn.addEventListener("click", function (ev) {
    localStorage.removeItem("user");
    document.getElementById("messageArea").classList.add("d-none");
    document.getElementById("joinArea").classList.remove("d-none");
})

SendMessageForm.addEventListener("submit", function (ev) {
    ev.preventDefault();
    let message = document.querySelector("textarea").value;
    let user = JSON.parse(localStorage.getItem("user"));
    let li = ` <li class="list-group-item">
                    <b>${user.username}</b>
                    <p>${message}</p>
                </li>`;
    document.getElementById("messages").innerHTML += li;
    document.querySelector("textarea").value = " ";

})

function showArea() {
    document.getElementById("messageArea").classList.remove("d-none");
    document.getElementById("joinArea").classList.remove("d-none");
}

function Status() {
    document.getElementById("joinGroup").addEventListener("submit", (ev) =>) {
        ev.preventDefault();

    }
}
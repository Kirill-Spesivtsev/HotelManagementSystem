"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var currUserNick = document.getElementById("userInput").value;
    var li = document.createElement("li");
    var div1 = document.createElement("div");
    var div2 = document.createElement("h6");
    var divExt = document.createElement("div");
    document.getElementById("messagesList").appendChild(li);
    li.classList.add("list-group-item");
    li.classList.add("list-group-item-primary");
    div2.classList.add("alert");
    div2.classList.add("alert-warning");
    div2.classList.add("chat-msg-block");
    if (user != currUserNick) {
        div2.classList.add("leaned-right");
        divExt.classList.add("leaned-right");
    }
    li.appendChild(divExt)
    divExt.appendChild(div1);
    divExt.appendChild(div2);
    div1.textContent = user;
    div2.textContent = message;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


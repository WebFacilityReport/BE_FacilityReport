"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/connectionHub").build();

connection.start();

connection.on("CreateFeedbackSuccessfully", function (message) {
    console.log("CreateFeedbackSuccessfully: " + message);
});


function updateNotifications(message) {
    var button = document.getElementById("numNotifications");
    var list = document.getElementById("listNotifications");

    button.innerText = message.length;

    list.innerHTML = "";

    message.forEach(function (notification) {
        var listItem = document.createElement("li");
        listItem.innerHTML = '<li><a class="dropdown-item" href="#">' + notification.message + '</a></li>';
        list.appendChild(listItem);
    });
}

connection.on("CreateFeedbackSuccessfullyNotify", function (message) {
    updateNotifications(message);
});


function createFeedback(feedback) {
    //var comment = feedback.comment;
    //var equipmentId = feedback.equipmentId;

    connection.invoke("CreateFeedback", feedback)
}

var createFeedbackButton = document.getElementById("createFeedbackButton");
createFeedbackButton.addEventListener("click", function () {
    var feedback = {
        accountId: document.getElementById("accountIdInput").value,
        comment: document.getElementById("commentInput").value,
        equipmentId: document.getElementById("equipmentIdInput").value
    };

    console.log(feedback)

    createFeedback(feedback);
});
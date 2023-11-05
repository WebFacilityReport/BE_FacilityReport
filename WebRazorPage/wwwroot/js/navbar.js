"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/connectionHub").build();
function redirectToIndexPage() {
    window.location.href = '/Index'; // Đặt URL của trang thành trang "index"
}
connection.start();




function updateNotifications(message) {
    var button = document.getElementById("numNotifications");
    var list = document.getElementById("listNotifications");

    button.innerText = message.length;

    list.innerHTML = "";

    message.forEach(function (notification) {
        var listItem = document.createElement("li");
        listItem.innerHTML = '<li><a class="dropdown-item" href="#">' + notification.title + '</a></li>';
        list.appendChild(listItem);
    });
}


function createFeedback(feedback) {
    //var comment = feedback.comment;
    //var equipmentId = feedback.equipmentId;

    connection.invoke("CreateFeedback", feedback)
        .then(function () {
            redirectToIndexPage(); // Chuyển hướng người dùng đến trang "index"
        })
        .catch(function (error) {
            alert("Error: " + error);
        });
}

try {
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

} catch (e) {
    console.log(e)
}


connection.on("UpdateNotify", function (message) {
    updateNotifications(message);
});

function createFixTask(job) {
    //var comment = feedback.comment;
    //var equipmentId = feedback.equipmentId;

    connection.invoke("CreateFixEquipmentJob", job)
        .then(function () {
            redirectToIndexPage(); // Chuyển hướng người dùng đến trang "index"
        })
        .catch(function (error) {
            alert("Error: " + error);
        });
}

try {
    var createFixTaskButton = document.getElementById("createFixTaskButton");
    createFixTaskButton.addEventListener("click", function () {
        var fileInput = document.getElementById("imageEquipInput");
        var fixTask = {
            creatorId: document.getElementById("accountIdInput").value,
            employeeId: document.getElementById("employeeIdInput").value,
            equipmentId: document.getElementById("equipmentIdInput").value,
            title: document.getElementById("titleInput").value,
            descriptionJob: document.getElementById("descriptionJobInput").value,
            deadline: document.getElementById("deadlineInput").value,
            imageEquip: ""
        };
        createFixTask(fixTask);

       
       

    });
} catch (e) {
    console.log(e)
}

function createEquipmentTask(job) {
    //var comment = feedback.comment;
    //var equipmentId = feedback.equipmentId;

    connection.invoke("CreateEquipmentJob", job)
        .then(function () {
            redirectToIndexPage(); // Chuyển hướng người dùng đến trang "index"
        })
        .catch(function (error) {
            alert("Error: " + error);
        });
    
}


try {
    var createEquipmentTaskButton = document.getElementById("createEquipmentTaskButton");
    createEquipmentTaskButton.addEventListener("click", function () {
   
        var fileInput = document.getElementById("imageEquipInput");
        var equipmentTask = {
            creatorId: document.getElementById("accountIdInput").value,
            employeeId: document.getElementById("employeeIdInput").value,
            resourceId: document.getElementById("resourceIdInput").value,
            title: document.getElementById("titleInput").value,
            descriptionJob: document.getElementById("descriptionJobInput").value,
            deadline: document.getElementById("deadlineInput").value,
            location: document.getElementById("locationInput").value,
            imageEquip: ""
        };
        createEquipmentTask(equipmentTask);
       
        
    });
} catch (e) {
    console.log(e)
}

function createResourceTask(job) {
    //var comment = feedback.comment;
    //var equipmentId = feedback.equipmentId;

    connection.invoke("CreateResourceJob", job)
        .then(function () {
            redirectToIndexPage(); // Chuyển hướng người dùng đến trang "index"
        })
        .catch(function (error) {
            alert("Error: " + error);
        });
   
}


try {
    var createResourceTaskButton = document.getElementById("createResourceTaskButton");
    createResourceTaskButton.addEventListener("click", function () {

        var fileInput = document.getElementById("imageInput");
        var task = {
            creatorId: document.getElementById("accountIdInput").value,
            employeeId: document.getElementById("employeeIdInput").value,
            title: document.getElementById("titleInput").value,
            descriptionJob: document.getElementById("descriptionJobInput").value,
            deadline: document.getElementById("deadlineInput").value,
            nameResource: document.getElementById("nameResourceInput").value,
            description: document.getElementById("descriptionInput").value,
            totalQuantity: Number.parseInt(document.getElementById("totalQuantityInput").value),
            size: document.getElementById("sizeInput").value,
            image: ""
        }
        createResourceTask(task);

});
} catch (e) {
    console.log(e)
}


// responses
connection.on("UpdateNotify", function (message) {
    updateNotifications(message);
});


connection.on("Response", function (message) {
    alert(message);
});

connection.on("Error", function (message) {
    alert(message);
});

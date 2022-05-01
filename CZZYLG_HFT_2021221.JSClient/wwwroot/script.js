let students = [];
let connection = null;

let studentIdToUpdate = -1;

fetchData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:49692/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StudentCreated", (user, message) => {
        fetchData();
    });

    connection.on("StudentDeleted", (user, message) => {
        fetchData();
    });

    connection.on("StudentUpdated", (user, message) => {
        fetchData();
    });

    connection.onclose(async () => {
        await start();
    });

    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function fetchData() {
    await fetch("http://localhost:49692/student")
        .then(x => x.json())
        .then(y => {
            students = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = ""
    students.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id +
            "</td><td>" + t.name +
        "</td><td>" + t.grade + '</td><td>' +
        `<button type="button" onclick="remove(${t.id})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.id})">Update</button></td></tr>`
        console.log(t.name)
    });
}
function create() {
    let nameToAdd = document.getElementById('studentname').value;
    let classroomIdtoAdd = document.getElementById('stud_classroomid').value;
    let gradeToadd = document.getElementById('studentgrade').value;
    fetch('http://localhost:49692/student', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            name: nameToAdd,
            grade: gradeToadd,
            classroomId: classroomIdtoAdd
        })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            fetchData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });   
}

function remove(id) {
    fetch('http://localhost:49692/student/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            fetchData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showupdate(id) {
    document.getElementById('updateformdiv').style.display = 'flex';
    document.getElementById('studentnametoupdate').value = students.find(t => t['id'] == id)['name'];
    document.getElementById('studentgradetoupdate').value = students.find(t => t['id'] == id)['grade'];
    document.getElementById('stud_classroomidtoupdate').value = students.find(t => t['id'] == id)['classroomId'];
    studentIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';

    let studentNameToUpdate = document.getElementById('studentnametoupdate').value;
    let studentGradeToUpdate = document.getElementById('studentgradetoupdate').value;
    let classroomIdToUpdate = document.getElementById('stud_classroomidtoupdate').value;

    fetch('http://localhost:49692/student', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            id: studentIdToUpdate,
            name: studentNameToUpdate,
            grade: studentGradeToUpdate,
            classroomId: classroomIdToUpdate
        })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            fetchData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
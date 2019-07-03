var tokenKey = "accessToken";
var token;
var users;
$(document).ready(function (e) {
    var loginData = {
        grant_type: 'password',
        username: $('#userName').val(),
        password: ''
    };
    $.ajax({
        type: 'POST',
        url: '/Account/Token',
        data: loginData,
        success: function (data) {
            sessionStorage.setItem(tokenKey, data.access_token);
            $.ajax({
                type: 'GET',
                url: '/api/User/GetUsers',
                beforeSend: function (xhr) {
                    token = sessionStorage.getItem(tokenKey);
                    xhr.setRequestHeader("Authorization", "Bearer " + token);
                },
                success: function (data) {
                    var elemen = document.getElementById("list-users");
                    users = data;
                    elemen.innerHTML = "";
                    for (var i = 0; i < data.length; i++) {
                        elemen.innerHTML += "<br/><br/><div>" + data[i].name + " " + "<input type=\"button\" value=\"Delete\" id=\"deleteUser\"onclick=\"DeleteUserEvent(" + i + ")\"/>" + " " +
                            "<input type=\"button\" value=\"Change Role\" id=\"changeRole\" onclick=\"ChangeRoleEvent(" + i + ")\"/>" + "</div>"
                    }
                },
                fail: function (data) {
                    console.log(data);
                }
            });
        }
    });

});

function ChangeRoleEvent(index) {
    let user = users[index];
    $('.modal').css("display", "block");
    $('#userNameEdit').val(user.name);
};

function Filtering(roleArray) {
    return roleArray.checked;
};

function Mappnig(roleArray) {
    return roleArray.value;
};

function EditFriend() {
    var roleArray = [];
    roleArray = document.getElementsByClassName("roles");
    var roleFilter = Array.prototype.filter.call(roleArray, Filtering);
    var roleMapping = roleFilter.map(Mappnig);
    var name = $('#userNameEdit').val();
    var json = JSON.stringify({
        Id: $('#userNameEdit').val(),
        Roles: roleMapping
    })
    $.ajax({
        type: 'POST',
        url: '/api/User/EditUser',
        beforeSend: function (xhr) {
            token = sessionStorage.getItem(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },
        contentType: "application/json",
        data: json,
        success: function (data) {
            alert("Roles changed");
            Close();
        },
        fail: function (data) {
            console.log(data);
        }
    });
};
function Close() {
    $('.modal').css("display", "none");
};
function DeleteUserEvent(index) {
    let user = users[index];
    $.ajax({
        type: 'POST',
        url: '/api/User/DeleteUser/' + user.name,
        beforeSend: function (xhr) {
            token = sessionStorage.getItem(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            //TODO reload page
            location.load();
        },
        fail: function (data) {
            console.log(data);
        }
    });
};

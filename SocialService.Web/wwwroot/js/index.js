var tokenKey = "accessToken";
var token;
var urll = "http://localhost:44396/api/friendapi";
var request = new XMLHttpRequest();
var friends;
$(document).ready(function (e) {
    $('.modal').hide();
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
            $('.friendList').css('display', 'block');
            $('.friendForm').css('display', 'none');
            sessionStorage.setItem(tokenKey, data.access_token);
            $.ajax({
                type: 'GET',
                url: 'api/FriendAPI',
                beforeSend: function (xhr) {
                    token = sessionStorage.getItem(tokenKey);
                    xhr.setRequestHeader("Authorization", "Bearer " + token);
                },
                success: function (data) {


                    var elemen = document.getElementById("list-friends");
                    friends = data;
                    elemen.innerHTML = "";
                    for (var i = 0; i < data.length; i++) {
                        elemen.innerHTML += "<br/><br/><div>" + data[i].name + " " + "<input type=\"button\" value=\"Delete\" id=\"deleteFriend\"onclick=\"DeleteFriendEvent(" + i + ")\"/>" + " " +
                            "<input type=\"button\" value=\"Edit\" id=\"editFriend\" onclick=\"EditFriendEvent(" + i + ")\"/>" + "</div>"
                    }
                },
                fail: function (data) {
                    console.log(data);
                }
            });
        }
    });

});

function DeleteFriendEvent(index) {
    let user = friends[index];
    debugger;
    $.ajax({
        type: 'POST',
        url: '/api/FriendAPI/DeleteFriend/' + user.id,
        beforeSend: function (xhr) {
            token = sessionStorage.getItem(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            $.ajax({
                type: 'GET',
                url: 'api/FriendAPI',
                beforeSend: function (xhr) {
                    token = sessionStorage.getItem(tokenKey);
                    xhr.setRequestHeader("Authorization", "Bearer " + token);
                },
                success: function (data) {


                    var elemen = document.getElementById("list-friends");
                    friends = data;
                    elemen.innerHTML = "";
                    for (var i = 0; i < data.length; i++) {
                        elemen.innerHTML += "<br/><br/><div>" + data[i].name + " " + "<input type=\"button\" value=\"Delete\" id=\"deleteFriend\"onclick=\"DeleteFriendEvent(" + i + ")\"/>" + " " +
                            "<input type=\"button\" value=\"Edit\" id=\"editFriend\" onclick=\"EditFriendEvent(" + i + ")\"/>" + "</div>"
                    }
                },
                fail: function (data) {
                    console.log(data);
                }
            });
        },
        fail: function (data) {
            console.log(data);
        }
    });
};
function EditFriendEvent(index) {
    let user = friends[index];
    $('.modal').css("display", "block");
    $('#nameEdit').val(user.name);
    $('#emailEdit').val(user.email);
    $('#phoneEdit').val(user.phone);
    $('#idEdit').val(user.id);
    


}
$('#createFriend').click(function () {
    $.ajax({
        type: 'POST',
        url: '/api/FriendAPI/CreateFriend',
        beforeSend: function (xhr) {
            token = sessionStorage.getItem(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },
        contentType: "application/json",
        data: JSON.stringify({
            name:  $('#nameFriend').val(),
            email: $('#emailFriend').val(),
            phone: $('#phoneFriend').val(),
            userId: $('#userName').val(),
        }),
        success: function (data) {
            $.ajax({
                type: 'GET',
                url: 'api/FriendAPI',
                beforeSend: function (xhr) {
                    token = sessionStorage.getItem(tokenKey);
                    xhr.setRequestHeader("Authorization", "Bearer " + token);
                },
                success: function (data) {


                    var elemen = document.getElementById("list-friends");
                    friends = data;
                    elemen.innerHTML = "";
                    for (var i = 0; i < data.length; i++) {
                        elemen.innerHTML += "<br/><br/><div>" + data[i].name + " " + "<input type=\"button\" value=\"Delete\" id=\"deleteFriend\"onclick=\"DeleteFriendEvent(" + i + ")\"/>" + " " +
                            "<input type=\"button\" value=\"Edit\" id=\"editFriend\" onclick=\"EditFriendEvent(" + i + ")\"/>" + "</div>"
                    }
                },
                fail: function (data) {
                    console.log(data);
                }
            });
        },
        fail: function (data) {
            console.log(data);
        }
    });
});
function EditFriend() {
    $.ajax({
        type: 'POST',
        url: '/api/FriendApi/EditFriend',
        beforeSend: function (xhr) {
            token = sessionStorage.getItem(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },
        contentType: "application/json",
        data: JSON.stringify({
            id:    $('#idEdit').val(),
            name:  $('#nameEdit').val(),
            email: $('#emailEdit').val(),
            phone: $('#phoneEdit').val(),
            userId: $('#userName').val()
        }),
        success: function (data) {
            location.reload();
        },
        fail: function (data) {
            console.log(data);
        }
    });
};
function Close() {
    $('.modal').hide();
};

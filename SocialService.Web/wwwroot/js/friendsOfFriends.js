var tokenKey = "accessToken";
var token;
var friends;
var user;
$(document).ready(InitData);

function InitData() {

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
                url: '/api/FriendAPI/GetAllFriends',
                beforeSend: function (xhr) {
                    token = sessionStorage.getItem(tokenKey);
                    xhr.setRequestHeader("Authorization", "Bearer " + token);
                },
                success: function (data) {
                    friends = JSON.parse(data);
                },
                fail: function (data) {
                    console.log(data);
                }
            });
        }
    });

};

function ClickFriendEvent(index) {

    user = friends.find(x => x.Id === index);
    $.ajax({
        type: 'GET',
        url: '/api/FriendAPI/GetFriendsOfFriends/' + user.Name,
        beforeSend: function (xhr) {
            token = sessionStorage.getItem(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },
        success: function (data) {
            var elemen = document.getElementById("listFriendsOfFriends" + user.Id);
            elemen.innerHTML = "";
            for (var i = 0; i < data.length; i++) {
                elemen.innerHTML += "<label>" + data[i].name + "</label><br/>";
            }
        },
        fail: function (data) {
            console.log(data);
        }
    });
}
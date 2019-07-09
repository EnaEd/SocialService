﻿var tokenKey = "accessToken";
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
                url: '/api/FriendAPI',
                beforeSend: function (xhr) {
                    token = sessionStorage.getItem(tokenKey);
                    xhr.setRequestHeader("Authorization", "Bearer " + token);
                },
                success: function (data) {
                    friends = data;
                },
                fail: function (data) {
                    console.log(data);
                }
            });
        }
    });

};

function ClickFriendEvent(index) {

    user = friends.find(x => x.id === index);
    $.ajax({
        type: 'GET',
        url: '/api/FriendAPI/GetFriendsOfFriends/' + user.name,
        beforeSend: function (xhr) {
            token = sessionStorage.getItem(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },
        success: function (data) {
            var elemen = document.getElementById("listFriendsOfFriends" + user.id);
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
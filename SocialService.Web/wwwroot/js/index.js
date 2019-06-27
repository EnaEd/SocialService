
//<script>
var tokenKey = "accessToken";
var token;
var urll = "http://localhost:44396/api/friendapi";
var request = new XMLHttpRequest();
var friends;
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
    debugger;
    $.ajax({
        type: 'POST',
        url: '/api/FriendApi/Put',
        beforeSend: function (xhr) {
            token = sessionStorage.getItem(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },
        data: JSON.stringify({
            id: user.id,
            name: user.name,
            email: user.email,
            phone: user.phone,
            userId: user.userId
        }),
        success: function (data) {

            debugger;
            var elemen = document.getElementById("list-friends");

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


//</script>

//<script>
var tokenKey = "accessToken";
var token;
var urll = "http://localhost:44396/api/friendapi";
var request = new XMLHttpRequest();
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

                    elemen.innerHTML = "";
                    for (var i = 0; i < data.length; i++) {
                        elemen.innerHTML += "<div>" + data[i].name + "</div>"
                    }

                },
                fail: function (data) {
                    console.log(data);
                }
            });
        }
    });

});
//</script>
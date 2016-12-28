tacdisDeluxeApp.controller("AccountController", function ($scope, $http, $route) {


    $scope.logIn = function(){
        var req = {
            method: 'POST',
            url: 'http://localhost:57661/Token',
            headers: {},
            data: {
                username: $scope.username,
                password: $scope.password,
                grant_type: 'password'
            },
        }
        $http(req).
         then(function (response) {
             $route.reload();
             feedbackPopup('YEY', { level: 'success', timeout: 2000 });
             $scope.token = response.data.access_token;
         }, function (response) {
             feedbackPopup('Something went wrong', { level: 'warning', timeout: 2000 });
             $scope.statusCode = response.statusCode;
         });
    }

    $scope.register = function () {
       
        var req = {
            method: 'POST',
            url: 'http://localhost:57661/api/Account/Register',
            headers: {},
            data: {
                email: $scope.usernameR,
                password: $scope.passwordR,
                confirmpassword: $scope.confPasswordR,
            },
        }
        $http(req).
            then(function (response) {
                $route.reload();
                feedbackPopup('Account created', { level: 'success', timeout: 2000 });
                $scope.ok = "It's good";
            }, function (response) {
                feedbackPopup('Something went wrong', { level: 'warning', timeout: 2000 });
                $scope.statusCode = response.statusCode;
            });
        
    }

});
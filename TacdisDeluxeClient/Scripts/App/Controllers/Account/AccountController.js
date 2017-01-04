'use strict';
tacdisDeluxeApp.controller('AccountController', function ($scope, $location, $timeout, IsAuthFactory, AuthService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
        username: "",
        password: "",
        confirmPassword: ""
    };

    $scope.loginData = {
        username: "",
        password: ""
    };

    $scope.auth = {
        isAuth: false,
        username: ""
    }

    $scope.auth = AuthService.isAuth();

    $scope.$watch('isAuth', function (newValue, oldValue) {
        if (newValue !== oldValue) IsAuthFactory.setAuth(newValue);
    });

    $scope.message = "";

    

    $scope.logOut = function () {
        AuthService.logOut();
        $scope.isAuth = false;
        $scope.username = ""; 
    };

    $scope.logIn = function () {

        AuthService.login($scope.loginData, '/sales').then(function (response) {
            $scope.username = response.data.username;
            $scope.isAuth = true;
        },
         function (err) {
             $scope.username = "";
             $scope.isAuth = false;
             $scope.message = err.error_description;
             feedbackPopup('Wrong username or password!', { level: 'warning', timeout: 2000 });
         });
    };

    $scope.signUp = function () {

        AuthService.saveRegistration($scope.registration).then(function (response) {
            feedbackPopup('User has been created', { level: 'success', timeout: 2000 });
            $scope.savedSuccessfully = true;
            startTimer();

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             feedbackPopup('Something went terribly wrong', { level: 'warning', timeout: 2000 });
             $scope.message = "Failed to register user due to:" + errors.join(' ');
         });
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 2000);
    }

});
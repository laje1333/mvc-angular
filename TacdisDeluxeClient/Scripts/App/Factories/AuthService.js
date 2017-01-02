'use strict';
tacdisDeluxeApp.factory('AuthService', ['$http', '$q', function ($http, $q) {

    var serviceBase = 'http://localhost:57661/';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        username: ""
    };

    var _isAuth = function (){
        return _authentication.isAuth;
    };

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {

        var defer = $q.defer();
        var req = {
            method: 'POST',
            url: serviceBase + 'token',
            headers: {},
            data: {
                grant_type: 'password',
                username: loginData.username,
                password: loginData.password
            },
        }
        $http(req).
            then(function (response) {
                window.sessionStorage.setItem('authorizationData', response.data.access_token);
                window.sessionStorage.setItem('signedInUser', loginData.username);
                _authentication.isAuth = true;
                _authentication.username = loginData.username;
                defer.resolve(response);
            }, function (response) {
                defer.reject(response);
                _logOut();
                
            });
        
        return defer.promise;
    };

    var _logOut = function () {

        window.sessionStorage.removeItem('authorizationData');
        window.sessionStorage.removeItem('signedInUser');
        _authentication.isAuth = false;
        _authentication.username = "";

    };

    var _fillAuthData = function () {

        var authData = window.sessionStorage.getItem('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }

    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.isAuth = _isAuth;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;
}]);
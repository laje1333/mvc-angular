'use strict';
tacdisDeluxeApp.factory('AuthInterceptorService', ['$q', '$location', function ($q, $location) {

    var AuthInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = window.sessionStorage.getItem('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData;
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            window.location = '/home';
        }
        return $q.reject(rejection);
    }

    AuthInterceptorServiceFactory.request = _request;
    AuthInterceptorServiceFactory.responseError = _responseError;

    return AuthInterceptorServiceFactory;
}]);
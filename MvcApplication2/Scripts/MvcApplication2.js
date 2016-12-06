var MvcApplication2 = angular.module('MvcApplication2', ['ui.router', 'ui.bootstrap']);

MvcApplication2.controller('StuffController', StuffController);
MvcApplication2.controller('LoginController', LoginController);
MvcApplication2.controller('RegisterController', RegisterController);

MvcApplication2.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
MvcApplication2.factory('LoginFactory', LoginFactory);
MvcApplication2.factory('RegistrationFactory', RegistrationFactory);

var configFunction = function ($stateProvider, $httpProvider, $locationProvider) {

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
    $stateProvider
        .state('stateOne', {
            url: '/stateOne?stuff',
            views: {
                "containerOne": {
                    templateUrl: function (params) { return '/Route/One?stuff=' + params.stuff; } 
                },
                "containerTwo": {
                    templateUrl: '/Route/Two'
                }
            }
        })
        .state('stateTwo', {
            url: '/stateTwo?stuff',
            views: {
                "containerOne": {
                    templateUrl: function (params) { return '/Route/One?stuff=' + params.stuff; }
                },
                "containerTwo": {
                    templateUrl: '/Route/Three'
                }
            }
        })
        .state('stateThree', {
            url: '/stateThree',
            views: {
                "containerOne": {
                    templateUrl: '/Route/Two'
                },
                "containerTwo": {
                    templateUrl: '/Route/Three'
                },
                "nestedView@stateThree": {
                    templateUrl: '/Route/Four'
                }
            }
        })
        .state('loginRegister', {
            url: '/loginRegister?returnUrl',
            views: {
                "containerOne": {
                    templateUrl: '/Account/Login',
                    controller: LoginController
                },
                "containerTwo": {
                    templateUrl: '/Account/Register',
                    controller: RegisterController
                }
            }
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$stateProvider', '$httpProvider', '$locationProvider'];

MvcApplication2.config(configFunction);
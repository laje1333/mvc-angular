tacdisDeluxeApp.controller('LayoutController',function ($scope, $http, AuthService, IsAuthFactory) {

    $scope.logOut = function () {
        AuthService.logOut();
        window.location = '/home'
    }

    $scope.auth = AuthService.isAuth();

    $scope.checkUser = function () {
        if (!$scope.auth.isAuth && window.location.pathname != '/home') {
            window.location = '/home'
        }
    };

    $scope.$watch(function () { return IsAuthFactory.getAuth(); }, function (newValue, oldValue) {
        if (newValue !== oldValue) $scope.auth = newValue;
    });
});
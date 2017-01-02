tacdisDeluxeApp.controller('LayoutController',function ($scope, $http, AuthService) {

    $scope.isAuth = AuthService.isAuth();
});
tacdisDeluxeApp.controller("AccountController", function ($scope, $http, $route) {


    $scope.logIn = function(){

        $http({
            method: 'POST',
            url: "http://localhost:57661/api/Account/AddCar",
            data: vehicleData
        }).success(function () {

        });
    }

});
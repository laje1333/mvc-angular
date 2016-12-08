


tacdisDeluxeApp.controller("VehicleController", function ($scope) {
    $scope.mechanicsVisible = true;
    $scope.packagesVisible = false;


    $scope.setVisibility = function (tab) {
        switch (tab) {
            case "mechanics":
                $scope.mechanicsVisible = true;
                $scope.packagesVisible = false;
                return;
            case "packages":
                $scope.mechanicsVisible = false;
                $scope.packagesVisible = true;
                return;
        }

    }
});


tacdisDeluxeApp.config(function ($routeProvider) {
    $routeProvider
        .when('/buildVehicle', {
            templateUrl: '/AngularTemplates/Vehicle/BuildVehicle/BuildVehicle.html',
            controller: 'VehicleController'
        });
});
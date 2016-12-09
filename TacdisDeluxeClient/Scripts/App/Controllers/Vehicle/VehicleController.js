


tacdisDeluxeApp.controller("VehicleController", function ($scope, $http) {
    
    $scope.brandDisabled = true;

    $scope.brandSelector = function () {

        $scope.urlString = 'http://localhost:57661/api/vehicle/?brand=' + $scope.selectedBrand;


        $http.get($scope.urlString).
                then(function (response) {
                $scope.carmodel = response.data.split(',');

                var components = response.data.split('=');

                $scope.year = components[0].split(',');
                $scope.carmodel = components[1].split(',');
                
      });
    }

    $scope.brandEnabler = function () {
        $scope.brandDisabled = false;
    }

    
});


tacdisDeluxeApp.config(function ($routeProvider) {
    $routeProvider
        .when('/newVehicle', {
            templateUrl: '/AngularTemplates/Vehicle/Sales/NewVehicle.html',
            controller: 'VehicleController'
        })
        .when('/usedVehicle', {
        templateUrl: '/AngularTemplates/Vehicle/Sales/UsedVehicle.html',
        controller: 'VehicleController'
    });
});
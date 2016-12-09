


tacdisDeluxeApp.controller("VehicleController", function ($scope, $http) {
    $http.get('http://localhost:57661/api/vehicle').
         then(function(response) {
             $scope.carmodel = response.data;
         });
    
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



tacdisDeluxeApp.controller("VehicleController", function ($scope, $http) {
    $http.get('http://localhost:57661/api/vehicle').
         then(function (response) {
             $scope.carmodel = response.data.split(',');

             var components = response.data.split('=');
             
             $scope.carmodel = components[0].split(',');
             $scope.year     = components[1].split(',');
               
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
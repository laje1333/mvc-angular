


tacdisDeluxeApp.controller("VehicleController", function ($scope) {
    
    
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
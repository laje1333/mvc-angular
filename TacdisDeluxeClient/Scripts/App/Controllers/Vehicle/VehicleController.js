


tacdisDeluxeApp.controller("VehicleController", function ($scope, $http, $route) {


    //Get

    $scope.initializeBrands = function () {
        $scope.urlString = 'http://localhost:57661/api/Brand';
        $http.get($scope.urlString).
                then(function (response) {
                    $scope.brands = response.data;
                });
    }




    var urlBeginning = 'http://localhost:57661/api/Vehicle';
    $scope.brandSelector = function () {

        $http.get('http://localhost:57661/api/vehicle?brand=' + $scope.selectedBrand).
                then(function (response) {
                    $scope.modelType = response.data;
                });
    }

    $scope.modelSelector = function () {

        $http.get('http://localhost:57661/api/vehicle?model=' + $scope.selectedModelYear).
                then(function (response) {
                    $scope.modelYear = response.data;
                });
    }
    $scope.yearSelector = function () {
        

        $http.get('http://localhost:57661/api/vehicle?year=' + $scope.modelYear + "&mod=" + $scope.modelType + "&brnd=" + $scope.selectedBrand).
                then(function (response) {
                    var properties = response.data;
                    $scope.engineType = [];
                    $scope.engineGroup = [];
                    $scope.engineDescription = [];

                    for (i = 0; i < properties.length; i++) {
                        var temp = properties[i].Name.split("=");
                        $scope.engineType.push(temp[0]);
                        $scope.engineGroup.push(temp[1]);
                        $scope.engineDescription.push(temp[2]);
                    }
                    
                   

                });
    }


    //Post

    //Glöm för helvete inte api i pathen
    //Skapa ett objekt, matcha objektets properties namn and baam, woorks.

    $scope.engineType = [];
    $scope.engineGroup = [];
    $scope.engineDescription = [];

    $scope.selectedBrand = "";
    $scope.selectedModelYear = "";
    $scope.selectedModel = "";

    $scope.selectedEngineType = "";
    $scope.selectedEngineGroup = "";
    $scope.selectedEngineDesc = "";

    $scope.selectedTransmissionType = "";
    $scope.selectedTransmissionGroup = "";
    $scope.selectedTransmissionDesc = "";

    $scope.selectedPaintType = "";
    $scope.selectedPaintDescription = "";
    $scope.selectedPaintGroup = "";

    $scope.selectedInteriorMaterial = "";
    $scope.selectedInteriorColorDesc = "";
    $scope.selectedInteriorColor = "";

    $scope.saveData = function () {

        var vehicleData = {
            Brand: $scope.selectedBrand,
            ModelYear: $scope.selectedModelYear,
            Model: $scope.selectedModel,

            EngineType: $scope.selectedEngineType,
            EngineGroup: $scope.selectedEngineGroup,
            EngineDescription: $scope.selectedEngineDesc,

            TransmissionType: $scope.selectedTransmissionType,
            TransmissionGroup: $scope.selectedTransmissionGroup,
            TransmissionDescription: $scope.selectedTransmissionDesc,

            PaintType: $scope.selectedPaintType,
            PaintDescription: $scope.selectedPaintDescription,
            PaintGroup: $scope.selectedPaintGroup,

            InteriorMaterial: $scope.selectedInteriorMaterial,
            InteriorColorDescription: $scope.selectedInteriorColorDesc,
            InteriorColor: $scope.selectedInteriorColor,

        }

        $http({
            method: 'POST',
            url: "http://localhost:57661/api/Vehicle/AddCar",
            data: vehicleData
        }).success(function () {
            $scope.showPopup();

        });

    }


    //General
    $scope.brandDisabled = true;
    $scope.brandEnabler = function () {
        $scope.brandDisabled = false;
    }

    $scope.modelDisabled = true;
    $scope.modelEnabler = function () {
        $scope.modelDisabled = false;
    }


    //Engine
    $scope.engineGroupDisabled = true;
    $scope.engineGroupEnabler = function () {
        $scope.engineGroupDisabled = false;
    }

    $scope.engineDescDisabled = true;
    $scope.engineDescEnabler = function () {
        $scope.engineDescDisabled = false;
    }

    //Transmission
    $scope.transmissionGroupDisabled = true;
    $scope.transmissionGroupEnabler = function () {
        $scope.transmissionGroupDisabled = false;
    }

    $scope.transmissionDescriptionDisabled = true;
    $scope.transmissionDescriptionEnabler = function () {
        $scope.transmissionDescriptionDisabled = false;
    }

    //Paint
    $scope.paintDescriptionDisabled = true;
    $scope.paintDescriptionEnabler = function () {
        $scope.paintDescriptionDisabled = false;
    }

    $scope.paintGroupDisabled = true;
    $scope.paintGroupEnabler = function () {
        $scope.paintGroupDisabled = false;
    }

    //Interior
    $scope.interiorDescDisabled = true;
    $scope.interiorDescEnabler = function () {
        $scope.interiorDescDisabled = false;
    }

    $scope.interiorColorDisabled = true;
    $scope.interiorColorEnabler = function () {
        $scope.interiorColorDisabled = false;
    }

    //Save
    $scope.saveDisabled = true;
    $scope.saveEnabler = function () {
        $scope.saveDisabled = false;

    }

    $scope.extendElement = function (id) {
        $("#" + id).slideDown("fast");
    }

    $scope.reloadRoute = function () {
        $route.reload();
    }

    $scope.showPopup = function (id) {
        $("#" + id).popover();
        setTimeout(function () { $("#" + id).popover('hide') }, 1000);
    }

});

tacdisDeluxeApp.controller("VehicleMaintenanceController", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {

    $scope.newVehicleTable = this;

    $scope.getNewVehicles = function () {
        $http.get("http://localhost:57661/api/vehicle/GetVehicleMaintenanceList")
    .then(function (response) {
        var obj = JSON.parse(response.data);
        $scope.records = obj.VehMain;
        $scope.newVehicles.push(obj.VehMain);

        $scope.newVehicleTable = new ngTableParams({

        },
            {
                dataset: $scope.newVehicles[0]
            });
    });
    };

    $scope.newVehicles = [];
    $scope.deleteRow = function (id) {
        var index = -1;

        for (i = 0; i < $scope.newVehicles[0].length; i++) {
            var tempID = $scope.newVehicles[0][i].REGNR;
            if (tempID === id) {
                index = i;
                break;
            }
        }
        if (index === -1) {
            alert("Something gone wrong");
        }

        $scope.newVehicles[0].splice(index, 1);
        //update database aswell!
    }


    $scope.reverseSort = false;
    $scope.orderByField = "REGNR";
}]);



tacdisDeluxeApp.config(function ($routeProvider) {
    $routeProvider
        .when('/newVehicle', {
            templateUrl: '/AngularTemplates/Vehicle/Sales/NewVehicle.html',
            controller: 'VehicleController'
        })
        .when('/vehicleMaintenance', {
            templateUrl: '/AngularTemplates/Vehicle/Sales/NewVehicleMaintenance.html',
            controller: 'VehicleMaintenanceController'
        })
        .when('/vehicleExtensions', {
            templateUrl: '/AngularTemplates/Vehicle/Sales/VehicleExtensions.html',
            controller: 'VehicleController'
        })
        .when('/createInventoryRecord', {
            templateUrl: '/AngularTemplates/Vehicle/Administration/CreateInventoryRecord.html',
            controller: 'VehicleController'
        })
        .when('/inventoryAdjustments', {
            templateUrl: '/AngularTemplates/Vehicle/Administration/InventoryAdjustments.html',
            controller: 'VehicleController'
        })
        .when('/vehicleValuation', {
            templateUrl: '/AngularTemplates/Vehicle/Administration/VehicleValuation.html',
            controller: 'VehicleController'
        });
});
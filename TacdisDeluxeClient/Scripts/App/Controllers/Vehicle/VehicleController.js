


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
                    $scope.engineTypes = [];
                    $scope.engineGroups = [];
                    $scope.engineDescriptions = [];

                    for (i = 0; i < properties.length; i++) {

                        if (properties[i].Field === "Engine-Type") {
                            $scope.engineTypes.push(properties[i]);
                        } else if (properties[i].Field === "Engine-Group") {
                            $scope.engineGroups.push(properties[i]);
                        } else if (properties[i].Field === "Engine-Description") {
                            $scope.engineDescriptions.push(properties[i]);
                        } else if (properties[i].Field === "Transmission-Type") {
                            $scope.transmissionTypes.push(properties[i]);
                        } else if (properties[i].Field === "Transmission-Group") {
                            $scope.transmissionGroups.push(properties[i]);
                        } else if (properties[i].Field === "Transmission-Description") {
                            $scope.transmissionDescriptions.push(properties[i]);
                        }
                    }
                    
                   

                });
    }



    $scope.selectEngineType = function () {
        for (i = 0; i < $scope.engineTypes.length; i++) {
            if ($scope.engineTypes[i].Name === $scope.selectedEngineType) {
                var id = $scope.engineTypes[i].Id;
                $scope.displayableEngineGroups = [];
                for (x = 0; x < $scope.engineGroups.length; x++) {
                    if ($scope.engineGroups[x].ParentId === id) {
                        $scope.displayableEngineGroups.push($scope.engineGroups[x]);
                    }
                }
            }
        }
        $scope.engineGroupDisabled = false;
    }

    $scope.selectEngineGroup = function () {
        for (i = 0; i < $scope.displayableEngineGroups.length; i++) {
            if ($scope.displayableEngineGroups[i].Name === $scope.selectedEngineGroup) {
                var id = $scope.displayableEngineGroups[i].Id;
                $scope.displayableEngineDescriptions = [];
                for (x = 0; x < $scope.engineDescriptions.length; x++) {
                    if ($scope.engineDescriptions[x].ParentId === id) {
                        $scope.displayableEngineDescriptions.push($scope.engineDescriptions[x]);
                    }
                }
            }
        }
        $scope.engineDescDisabled = false;
    }

    $scope.selectTransmissionType = function () {
        for (i = 0; i < $scope.transmissionTypes.length; i++) {
            if ($scope.transmissionTypes[i].Name === $scope.selectedTransmissionType) {
                var id = $scope.transmissionTypes[i].Id;
                $scope.displayableTransmissionGroups = [];
                for (x = 0; x < $scope.transmissionGroups.length; x++) {
                    if ($scope.transmissionGroups[x].ParentId === id) {
                        $scope.displayableTransmissionGroups.push($scope.transmissionGroups[x]);
                    }
                }
            }
        }
        $scope.transmissionGroupDisabled = false;
    }

    $scope.selectTransmissionGroup = function () {
        for (i = 0; i < $scope.displayableTransmissionGroups.length; i++) {
            if ($scope.displayableTransmissionGroups[i].Name === $scope.selectedTransmissionGroup) {
                var id = $scope.displayableTransmissionGroups[i].Id;
                $scope.displayableTransmissionDescriptions = [];
                for (x = 0; x < $scope.transmissionDescriptions.length; x++) {
                    if ($scope.transmissionDescriptions[x].ParentId === id) {
                        $scope.displayableTransmissionDescriptions.push($scope.transmissionDescriptions[x]);
                    }
                }
            }
        }
        $scope.transmissionDescriptionDisabled = false;
    }

    //Post

    //Glöm för helvete inte api i pathen
    //Skapa ett objekt, matcha objektets properties namn and baam, woorks.


    //Engine
    $scope.engineTypes = [];
    $scope.engineGroups = [];
    $scope.displayableEngineGroups = [];
    $scope.engineDescriptions = [];
    $scope.displayableEngineDescriptions = [];

    //Transmission
    $scope.transmissionTypes = [];
    $scope.transmissionGroups = [];
    $scope.displayableTransmissionGroups = [];
    $scope.transmissionDescriptions = [];
    $scope.displayableTransmissionDescriptions = [];



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
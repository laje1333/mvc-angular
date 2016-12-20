


tacdisDeluxeApp.controller("VehicleController", function ($scope, $http, $route) {


    //Get
    $scope.spinner = false;

    $scope.idOffset = 0;
    $scope.offsetMultiplier = 0;

    $scope.initializeBrands = function () {
        $scope.spinner = true;
        $scope.urlString = 'http://localhost:57661/api/Brand';
        $http.get($scope.urlString).
                then(function (response) {
                    $scope.brands = response.data;
                    $scope.spinner = false;
                    feedbackPopup('Successefully fetched data', { level: 'success', timeout: 2000 });
                }, function (response) {
                    feedbackPopup('Could not fetch data', { level: 'warning', timeout: 2000 });
                });
    }




    var urlBeginning = 'http://localhost:57661/api/Vehicle';
    $scope.brandSelector = function () {

        $http.get('http://localhost:57661/api/vehicle?brand=' + $scope.selectedBrand).
                then(function (response) {
                    $scope.modelType = response.data;
                }, function (response) {
                    feedbackPopup("Could not fetch data", { level: 'warning', timeout: 2000 });
                });
    }

    $scope.modelSelector = function () {

        $http.get('http://localhost:57661/api/vehicle?model=' + $scope.selectedModelYear).
                then(function (response) {
                    $scope.modelYear = response.data;
                }, function (response) {
                    feedbackPopup("Could not fetch data", { level: 'warning', timeout: 2000 });
                });
    }
    $scope.yearSelector = function () {
        

        $http.get('http://localhost:57661/api/vehicle?year=' + $scope.modelYear + "&mod=" + $scope.modelType + "&brnd=" + $scope.selectedBrand).
                then(function (response) {
                    var properties = response.data;
                    $scope.allProps = properties;
                    $scope.engineTypes = [];
                    $scope.engineGroups = [];
                    $scope.engineDescriptions = [];
                    $scope.idOffset = properties.length * $scope.offsetMultiplier;
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
                        } else if (properties[i].Field === "Exterior-Type") {
                            $scope.exteriorTypes.push(properties[i]);
                        } else if (properties[i].Field === "Exterior-Group") {
                            $scope.exteriorGroups.push(properties[i]);
                        } else if (properties[i].Field === "Exterior-Description") {
                            $scope.exteriorDescriptions.push(properties[i]);
                        } else if (properties[i].Field === "Interior-Material") {
                            $scope.interiorMats.push(properties[i]);
                        } else if (properties[i].Field === "Interior-Color") {
                            $scope.interiorColors.push(properties[i]);
                        } else if (properties[i].Field === "Interior-Description") {
                            $scope.interiorDescriptions.push(properties[i]);
                        }
                    }

                }, function (response) {
                    feedbackPopup("Could not fetch data", { level: 'warning', timeout: 2000 });
                });
    }




    $scope.selectEngineType = function () {
        for (i = 0; i < $scope.engineTypes.length; i++) {
            if ($scope.engineTypes[i].Name === $scope.selectedEngineType) {
                var id = $scope.engineTypes[i].Id;
                $scope.displayableEngineGroups = [];
                for (x = 0; x < $scope.engineGroups.length; x++) {
                    if ($scope.engineGroups[x].ParentId + $scope.idOffset === id) {
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
                    if ($scope.engineDescriptions[x].ParentId + $scope.idOffset === id) {
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
                    if ($scope.transmissionGroups[x].ParentId + $scope.idOffset === id) {
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
                    if ($scope.transmissionDescriptions[x].ParentId + $scope.idOffset === id) {
                        $scope.displayableTransmissionDescriptions.push($scope.transmissionDescriptions[x]);
                    }
                }
            }
        }
        $scope.transmissionDescriptionDisabled = false;
    }

    $scope.selectExteriorType = function () {
        for (i = 0; i < $scope.exteriorTypes.length; i++) {
            if ($scope.exteriorTypes[i].Name === $scope.selectedPaintType) {
                var id = $scope.exteriorTypes[i].Id;
                $scope.displayableExteriorGroups = [];
                for (x = 0; x < $scope.exteriorGroups.length; x++) {
                    if ($scope.exteriorGroups[x].ParentId + $scope.idOffset === id) {
                        $scope.displayableExteriorGroups.push($scope.exteriorGroups[x]);
                    }
                }
            }
        }
        $scope.paintGroupDisabled = false;
    }

    $scope.selectExteriorGroup = function () {
        for (i = 0; i < $scope.displayableExteriorGroups.length; i++) {
            if ($scope.displayableExteriorGroups[i].Name === $scope.selectedPaintGroup) {
                var id = $scope.displayableExteriorGroups[i].Id;
                $scope.displayableExteriorDescriptions = [];
                for (x = 0; x < $scope.exteriorDescriptions.length; x++) {
                    if ($scope.exteriorDescriptions[x].ParentId + $scope.idOffset === id) {
                        $scope.displayableExteriorDescriptions.push($scope.exteriorDescriptions[x]);
                    }
                }
            }
        }
        $scope.paintDescriptionDisabled = false;
    }

    $scope.selectInteriorMats = function () {
        for (i = 0; i < $scope.interiorMats.length; i++) {
            if ($scope.interiorMats[i].Name === $scope.selectedInteriorMaterial) {
                var id = $scope.interiorMats[i].Id;
                $scope.displayableInteriorColors = [];
                for (x = 0; x < $scope.interiorColors.length; x++) {
                    if ($scope.interiorColors[x].ParentId + $scope.idOffset === id) {
                        $scope.displayableInteriorColors.push($scope.interiorColors[x]);
                    }
                }
            }
        }
        $scope.interiorColorDisabled = false;
    }

    $scope.selectInteriorColors = function () {
        for (i = 0; i < $scope.displayableInteriorColors.length; i++) {
            if ($scope.displayableInteriorColors[i].Name === $scope.selectedInteriorColor) {
                var id = $scope.displayableInteriorColors[i].Id;
                $scope.displayableInteriorDescriptions = [];
                for (x = 0; x < $scope.interiorDescriptions.length; x++) {
                    if ($scope.interiorDescriptions[x].ParentId + $scope.idOffset === id) {
                        $scope.displayableInteriorDescriptions.push($scope.interiorDescriptions[x]);
                    }
                }
            }
        }
        $scope.paintDescriptionDisabled = false;
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

    //Exterior
    $scope.exteriorTypes = [];
    $scope.exteriorGroups = [];
    $scope.displayableExteriorGroups = [];
    $scope.exteriorDescriptions = [];
    $scope.displayableExteriorDescriptions = [];

    //Interior
    $scope.interiorMats = [];
    $scope.interiorColors = [];
    $scope.displayableInteriorColors = [];
    $scope.interiorDescriptions = [];
    $scope.displayableInteriorDescriptions = [];


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



    $scope.fetchParentProperties = function (property, treeLevel) {
        if (treeLevel === 1) {
            for (i = 0; i < $scope.allProps.length; i++) {
                if ($scope.allProps[i].Id === property.ParentId + $scope.idOffset) {
                    return $scope.allProps[i];
                }
            }
        } else if (treeLevel === 2) {
            for (i = 0; i < $scope.allProps.length; i++) {
                if ($scope.allProps[i].Id === property.ParentId + $scope.idOffset) {
                    var groupLevelID = $scope.allProps[i].ParentId + $scope.idOffset;
                    for (x = 0; x < $scope.allProps.length; x++) {
                        if (groupLevelID === $scope.allProps[x].Id) {
                            return $scope.allProps[x];
                        }
                    }
                }
            }
        }



    }

    $scope.saveData = function () {

        var props = [];
        props.push($scope.fetchParentProperties($scope.displayableEngineDescriptions[0], 2));
        props.push($scope.fetchParentProperties($scope.displayableEngineDescriptions[0], 1));
        props.push($scope.displayableEngineDescriptions[0]);

        props.push($scope.fetchParentProperties($scope.displayableTransmissionDescriptions[0], 2));
        props.push($scope.fetchParentProperties($scope.displayableTransmissionDescriptions[0], 1));
        props.push($scope.displayableTransmissionDescriptions[0]);

        props.push($scope.fetchParentProperties($scope.displayableExteriorDescriptions[0], 2));
        props.push($scope.fetchParentProperties($scope.displayableExteriorDescriptions[0], 1));
        props.push($scope.displayableExteriorDescriptions[0]);

        props.push($scope.fetchParentProperties($scope.displayableInteriorDescriptions[0], 2));
        props.push($scope.fetchParentProperties($scope.displayableInteriorDescriptions[0], 1));
        props.push($scope.displayableInteriorDescriptions[0]);


        var vehicleData = {
            Brand: $scope.selectedBrand,
            ModelYear: $scope.selectedModelYear,
            Model: $scope.selectedModel,

            Properties: props,
        }
        
        $http({
            method: 'POST',
            url: "http://localhost:57661/api/Vehicle/AddCar",
            data: vehicleData
        }).success(function () {
            feedbackPopup('Successefully saved new vehicle', { level: 'success', timeout: 2000 });
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

    $scope.spinner = false;

    $scope.getNewVehicles = function () {
        $scope.spinner = true;
        $http.get("http://localhost:57661/api/vehicle/GetAllVehicles")
    .then(function (response) {
        feedbackPopup("Successefully fetched data", { level: 'success', timeout: 2000 });
        var obj = response.data;
        $scope.records = obj;
        $scope.newVehicles.push(obj);
        $scope.spinner = false;

        $scope.newVehicleTable = new ngTableParams({

        },
            {
                dataset: $scope.newVehicles[0]
            });
    }, function (response) {
        feedbackPopup("Could not fetch data", { level: 'warning', timeout: 2000 });
    });
    };

    $scope.newVehicles = [];
    $scope.deleteRow = function (id) {
        var index = -1;

        for (i = 0; i < $scope.newVehicles[0].length; i++) {
            var tempID = $scope.newVehicles[0][i].RegNo;
            if (tempID === id) {
                index = i;
                break;
            }
        }
        if (index === -1) {
            alert("Something gone wrong");
        } else {

            var path = "http://localhost:57661/api/vehicle/Delete?regNumber=" + $scope.newVehicles[0][index].RegNo;

            $http.delete(path)
            .then(
                function (response) {
                    feedbackPopup($scope.newVehicles[0][index].RegNo + " sucessefully deleted", { level: 'info', timeout: 3000 });
                    $scope.newVehicles[0].splice(index, 1);
                    $scope.newVehicleTable.reload();
                    
            },
                function (response) {
                    feedbackPopup("Could not delete vehicle", { level: 'warning', timeout: 2000 });
       }
    );
            
        }

        //update database aswell!
    }


    $scope.reverseSort = false;
    $scope.orderByField = "REGNR";
}]);

tacdisDeluxeApp.controller("VehicleInventoryController", function($scope, $http){

    $scope.regNumber = "";

    $scope.regNrSearch = function () {
        if ($scope.regNumber.length == 6) {
            $scope.regNumber = $scope.regNumber.toUpperCase();
            $http.get("http://localhost:57661/api/VehicleInventory/GetSingleVehicleByRegnumber?regNumber=" + $scope.regNumber)
            .then(function (response) {
                feedbackPopup("Successefully fetched data", { level: 'success', timeout: 2000 });
                $scope.regNumber = response.data.RegNo;
                $scope.orderNumber = response.data.ItemId;
                var itemName = response.data.ItemName.split(" ");
                $scope.brand = itemName[0];
                $scope.model = itemName[1];
                $scope.year = itemName[2];
                $scope.itemDesc = response.data.ItemDesc;

            }, function (response) {
                feedbackPopup("Could fetch data", { level: 'warning', timeout: 2000 });
            });
        }
    }


    

});

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
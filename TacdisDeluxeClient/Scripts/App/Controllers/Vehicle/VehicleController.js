﻿


tacdisDeluxeApp.controller("VehicleController", function ($scope, $http, $route) {
    

    //Get
    var urlBeginning = 'http://localhost:57661/api/vehicle/GetModelYears/';
    $scope.brandSelector = function () {

        $scope.urlString = urlBeginning + '?brand=' + $scope.selectedBrand;


        $http.get($scope.urlString).
                then(function (response) {
                $scope.year = response.data.split(',');
                
                
      });
    }

    $scope.modelYearSelector = function () {

        $scope.urlString = urlBeginning + '?modelyear=' + $scope.selectedModelYear + '&brand=' + $scope.selectedBrand;


        $http.get($scope.urlString).
                then(function (response) {
                    $scope.modelyear = response.data.split(',');


                });
    }
    $scope.modelSelector = function () {

        $scope.urlString = urlBeginning + '?model=' + $scope.selectedModel + '&modelyear=' + $scope.selectedModelYear + '&brand=' + $scope.selectedBrand;


        $http.get($scope.urlString).
                then(function (response) {

                    var engineProperties = response.data.split('=');

                    //Engine
                    $scope.engineType = engineProperties[0].split(',');
                    $scope.engineGroup = engineProperties[1].split(',');
                    $scope.engineDescription = engineProperties[2].split(',');

                    //Transmission
                    $scope.transmissionType = engineProperties[3].split(',');
                    $scope.transmissionGroup = engineProperties[4].split(',');
                    $scope.transmissionDescription = engineProperties[5].split(',');

                    //Exterior
                    $scope.paintType = engineProperties[6].split(',');
                    $scope.paintDescription = engineProperties[7].split(',');
                    $scope.paintGroup = engineProperties[8].split(',');

                    //Interior
                    $scope.interiorMaterial = engineProperties[9].split(',');
                    $scope.interiorDescription = engineProperties[10].split(',');
                    $scope.interiorColor = engineProperties[11].split(',');

                });
    }


    //Post

    //Glöm för helvete inte api i pathen
    //Skapa ett objekt, matcha objektets properties namn and baam, woorks.

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
        .when('/usedVehicle', {
        templateUrl: '/AngularTemplates/Vehicle/Sales/NewVehicleMaintenance.html',
        controller: 'VehicleController'
    });
});
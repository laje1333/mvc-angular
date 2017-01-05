


tacdisDeluxeApp.controller("VehicleController", function ($scope, $http, $route) {
    $scope.$on('$viewContentLoaded', hotlinkToMenu);

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

tacdisDeluxeApp.controller("VehicleMaintenanceController", function ($scope, NgTableParams, $http) {
    $scope.$on('$viewContentLoaded', hotlinkToMenu);
    $scope.spinner = false;

    $scope.getNewVehicles = function () {
        $scope.spinner = true;
        $http.get("http://localhost:57661/api/vehicle/GetAllVehicles")
    .then(function (response) {
        feedbackPopup("Successefully fetched data", { level: 'success', timeout: 2000 });
        var obj = response.data;
        $scope.records = obj.length;
        $scope.newVehicles.push(obj);
        $scope.spinner = false;

        $scope.newVehicleTable = new NgTableParams({

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

    }


    $scope.reverseSort = false;
    $scope.orderByField = "REGNR";
});

tacdisDeluxeApp.controller("VehicleInventoryController", function($scope, $http){
    $scope.$on('$viewContentLoaded', hotlinkToMenu);
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

    $scope.displayFurtherInformation = function (id) {
        $("#" + id).popover({
            title: "Specifications",
            trigger: 'focus',
            placement: 'right',
            html: true,
            content: $scope.popoverLines($scope.itemDesc)
        });
        $("#" + id).popover('show');
    }

    $scope.hidePopover = function () {
        $("#info").popover('hide');
    }
    
    $scope.popoverLines = function (text) {
        var temp = text.split("\n");
        var result = "<table class='table table-hover'><thead><tr><th>Engine</th><th>Transmission</th><th>Exterior</th><th>Interior</th></tr></thead><tbody><tr>";


	
        for (i = 0; i < temp.length; i++) {
            result += "<td>" + temp[i] + "</td>";
        }
        result += "</tr></tbody></table>";
        result += "<button type='button' class='btn btn-warning btn-md' onclick='hidePopover()'>Close</button>";
        return result;
    }


    $scope.tableItems = [];

    $scope.order = function () {

        var data = {
            Name: $scope.itemName,
            Amount: ($scope.limitInvAmount - $scope.mainInvAmount),
            ItemID: $scope.itemId,
        };

        $scope.checkForDuplicates(data);
        $scope.transferDisabled = false;
        

    }

    $scope.deleteRow = function (id) {
        var index = -1;

        for (i = 0; i < $scope.tableItems.length; i++) {
            var tempID = $scope.tableItems[i].ItemID;
            if (tempID === id) {
                index = i;
                break;
            }
        }
        if (index === -1) {
            alert("Something gone wrong");
        }

        feedbackPopup($scope.tableItems[index].ItemID + " sucessefully deleted", { level: 'info', timeout: 3000 });
        $scope.tableItems.splice(index, 1);
    }


    $scope.checkForDuplicates = function (data) {
        for (i = 0; i < $scope.tableItems.length; i++) {
            if (data.Name === $scope.tableItems[i].Name) {
                $scope.tableItems[i].Amount += data.Amount;
                return;
            }
        }
        $scope.tableItems.push(data);
    }

    $scope.transferDisabled = true;

    $scope.transfer = function () {

        var invData = $scope.tableItems;

        $http({
            method: 'POST',
            url: "http://localhost:57661/api/Inventory/PostTransfer",
            data: { '': invData }
        }).success(function () {
            feedbackPopup('Successefully saved new vehicle', { level: 'success', timeout: 2000 });
            $scope.initializeCharts();
            $scope.tableItems = [];
            $scope.mainInvAmount = 0;
            $scope.workshopInvAmount = 0;
            $scope.limitInvAmount = 0;
            $scope.itemName = "";
            $scope.itemId = 0;
            $scope.decreaseDisabled = false;
            $scope.orderButtonDisabled = true;
            $scope.transferDisabled = true;
        });
    }

    $scope.searchFieldText = "";

    $scope.searchForInventoryItems = function () {
        $scope.inventoryData = [];
        $scope.inventoryTypes = [];
        $scope.mainInventoryAmounts = [];
        $scope.shopInventoryAmounts = [];

        $http.get("http://localhost:57661/api/Inventory/GetAllWorkshopItems?partName=" + $scope.searchFieldText)
            .then(function (response) {
                feedbackPopup("Successefully fetched data", { level: 'success', timeout: 2000 });
                $scope.inventoryData = response.data;
                $scope.filterInventoryItems();
                $scope.initializeCharts();

            }, function (response) {
                feedbackPopup("Could not fetch data", { level: 'warning', timeout: 2000 });
            });

    }



    $scope.filterInventoryItems = function () {
        for (i = 0; i < $scope.inventoryData.length; i++) {
            $scope.inventoryTypes.push($scope.inventoryData[i].PartName);
            $scope.mainInventoryAmounts.push($scope.inventoryData[i].MainInventoryAmount);
            $scope.shopInventoryAmounts.push($scope.inventoryData[i].WorkshopInventoryAmount);
        }
    }

    $scope.mainInvAmount = 0;
    $scope.workshopInvAmount = 0;
    $scope.limitInvAmount = 0;
    $scope.itemName = "";
    $scope.itemId = 0;
    $scope.decreaseDisabled = false;
    $scope.orderButtonDisabled = true;

    $scope.updateAdjustments = function (type) {
        for (i = 0; i < $scope.inventoryData.length; i++) {
            if (type === $scope.inventoryData[i].PartName) {
                $scope.mainInvAmount = $scope.inventoryData[i].MainInventoryAmount;
                $scope.workshopInvAmount = $scope.inventoryData[i].WorkshopInventoryAmount;
                $scope.itemName = $scope.inventoryData[i].PartName;
                $scope.limitInvAmount = $scope.mainInvAmount;
                $scope.itemId = $scope.inventoryData[i].itemID;
                $scope.chartActivated = false;
                $scope.$apply();
            }
        }
    }

    $scope.increaseWorkshopAmount = function () {
            $scope.workshopInvAmount += 1;
            $scope.mainInvAmount -= 1;
            $scope.orderButtonDisabled = false;
    }

    $scope.descreaseWorkshopAmount = function () {
        if ($scope.limitInvAmount - $scope.mainInvAmount > 1) {
            $scope.workshopInvAmount -= 1;
            $scope.mainInvAmount += 1;
            $scope.orderButtonDisabled = false;
        } else {
            $scope.orderButtonDisabled = true;
            $scope.workshopInvAmount -= 1;
            $scope.mainInvAmount += 1;
        }
    }

    $scope.updateCachedData = function () {
        for (i = 0; i < $scope.tableItems.length; i++) {

            for (x = 0; x < $scope.inventoryData.length; x++) {

                if ($scope.tableItems[i].Name === $scope.inventoryData[x].PartName) {
                    $scope.mainInventoryAmounts[x] -= $scope.tableItems[i].Amount;
                    $scope.shopInventoryAmounts[x] += $scope.tableItems[i].Amount;
                }
            }
        }

    }

    $scope.extendElement = function (id) {
        $("#" + id).slideDown("fast");
        $scope.extended = true;
    }
    $scope.extended = false;

    $scope.chartActivated = true;

    $scope.initializeCharts = function () {
        $(function () {
            $('#container').highcharts({
                chart: {
                    type: 'column',

                },
                title: {
                    text: 'Inventory records'
                },
                subtitle: {
                    text: 'Parts and vehicles'
                },
                xAxis: {
                    categories: $scope.inventoryTypes,
                    crosshair: true
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Amount'
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.0f}</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {

                    series: {
                        cursor: 'pointer',
                        point: {
                            events: {
                                click: function () {
                                    $scope.updateAdjustments(this.category);
                                    
                                }
                            }
                        }
                    },

                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: [{
                    name: 'Main inventory',
                    data: $scope.mainInventoryAmounts

                }, {
                    name: 'Workshop inventory',
                    data: $scope.shopInventoryAmounts

                }]
            });

            $('#transfer').click(function () {
                var chart = $('#container').highcharts();

                $scope.updateCachedData();


                chart.series[0].setData($scope.mainInventoryAmounts, false);
                chart.series[1].setData($scope.shopInventoryAmounts, true);
                
            });
        });
    }
});


tacdisDeluxeApp.controller("VehicleCreateInventoryController", function ($scope, $http) {
    $scope.$on('$viewContentLoaded', hotlinkToMenu);
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
                
                var t = 'name';
                var binaryHeap = new Maths.Datastructures.BinaryHeap(t);
                
                var testObj = function (n, v) {
                    var ex = function(val){
                        this.exact = val;
                    }

                    this.saken = {
                        haha: {
                            tjo : v
                        }
                    }

                    this.name = n;
                    this.value = v;

                }

                binaryHeap.insert(new testObj("aa", 5));
                binaryHeap.insert(new testObj("b", 123));
                binaryHeap.insert(new testObj("c", 23));
                binaryHeap.insert(new testObj("d", 654));
                binaryHeap.insert(new testObj("e", 63463));
                binaryHeap.insert(new testObj("f", 232));
                binaryHeap.insert(new testObj("g", 765));
                binaryHeap.insert(new testObj("h", 1324));
                binaryHeap.insert(new testObj("i", 3457));
                binaryHeap.insert(new testObj("j", 4645));
                binaryHeap.insert(new testObj("k", 876));
                binaryHeap.insert(new testObj("l", 4644632));
                
                var xx = binaryHeap.getMaximum();
                xx = xx;
                xx = binaryHeap.getMaximum();
                xx = xx;
                xx = binaryHeap.getMaximum();
                xx = xx;

            }, function (response) {
                feedbackPopup("Could fetch data", { level: 'warning', timeout: 2000 });
            });
        }


    }



    $scope.displayFurtherInformation = function (id) {
        $("#" + id).popover({
            title: "Specifications",
            trigger: 'focus',
            placement: 'right',
            html: true,
            content: $scope.popoverLines($scope.itemDesc)
        });
        $("#" + id).popover('show');


    }

    $scope.hidePopover = function () {
        $("#info").popover('hide');
    }

    $scope.popoverLines = function (text) {
        var temp = text.split("\n");
        var result = "<table class='table table-hover'><thead><tr><th>Engine</th><th>Transmission</th><th>Exterior</th><th>Interior</th></tr></thead><tbody><tr>";



        for (i = 0; i < temp.length; i++) {
            result += "<td>" + temp[i] + "</td>";
        }
        result += "</tr></tbody></table>";
        result += "<button type='button' class='btn btn-warning btn-md' onclick='hidePopover()'>Close</button>";
        return result;
    }

    $scope.selectedInventory = "";

    $scope.selectInventory = function (name) {
        $scope.selectedInventory = name;
        $scope.$apply();
    }

    $(function () {
        Highcharts.chart('container', {
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: 0,
                plotShadow: false
            },
            title: {
                text: 'Inventory<br>space<br>',
                align: 'center',
                verticalAlign: 'middle',
                y: 40
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    dataLabels: {
                        enabled: true,
                        distance: -50,
                        style: {
                            fontWeight: 'bold',
                            color: 'white'
                        }
                    },
                    startAngle: -90,
                    endAngle: 90,
                    center: ['50%', '75%']
                },
                series: {
                    cursor: 'pointer',
                    point: {
                        events: {
                            click: function () {
                                
                                $scope.selectInventory(this.name);
                            }
                        }
                    }
                },

            },
            series: [{
                type: 'pie',
                name: 'Inventory space',
                innerSize: '50%',
                
                data: [
                    ['Workshop inventory', 10.38],
                    ['Main inventory', 56.33],
                    {
                        name: 'Proprietary or Undetectable',
                        y: 0.2,
                        dataLabels: {
                            enabled: false
                        }
                    }
                ]
            }]
        });
    });

});

hidePopover = function () {
    $("#info").popover('hide');
}

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


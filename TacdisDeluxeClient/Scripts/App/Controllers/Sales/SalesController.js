'use strict';

tacdisDeluxeApp.controller("SalesController", function ($scope, $rootScope, $http, SaleFactory) {

    $scope.init = function () {
        
    }
    //Used for searching  vehicles
    $scope.vehName = "";
    $scope.vehNr = "";
    $scope.vehReg = "";

    //Used for searching parts
    $scope.artName = "";
    $scope.artNum = "";

    //Record that holds SaleItems
    $rootScope.record = [];

    //TotalCost of the sale
    $rootScope.totalCost = 0;

    //SaleRec holds the sale items
    $scope.saleRec = {};
    $scope.saleRec.PartIds = [];
    $scope.saleRec.VehicleIds = [];
    $scope.saleRec.AddonIds = [];

    $scope.salesman = {};

    $scope.panes = [
        { title: "Vehicles", template: "AngularTemplates/Sales/Panes/Vehicles.html", active: true },
        { title: "Parts", template: "AngularTemplates/Sales/Panes/Parts.html" },
        { title: "Add Ons", template: "AngularTemplates/Sales/Panes/Addons.html" }];


    $scope.active = function (index) {    
        return $scope.panes.filter(function (pane) {
            $rootScope.selectedTypeOfThingy = index;
            return pane.active;
        })[0];
    };

    
    $scope.calcTotal = function (r) {
        $rootScope.totalCost += parseFloat(r);
    };

    
    $scope.addRow = function () {
        switch ($scope.selectedTypeOfThingy) {
            case 0:
                $scope.saleRec.VehicleIds.push(this.r.ItemId);           
                break;
            case 1:
                $scope.saleRec.PartIds.push(this.r.ItemId);
                break;
            case 2:
                $scope.saleRec.AddonIds.push(this.r.ItemId);
                break;
        }
        
        $rootScope.record.push({ 'Type': 'Part', 'Name': this.r.ItemName, 'Number': this.r.ItemId, 'Price': this.r.ItemPrice });
        $scope.calcTotal(this.r.ItemPrice);
    };
    $scope.onlyNumbers = /^\d+(?:\.\d+|)$/;

    $scope.changeTypeOfSearch = function () {
        $('.searchOptions').hide();
        $('#Search' + $scope.searchTypeOfItem).show();
    };

    $scope.PostSale = function () {
        var req = {
            method: 'POST',
            url: 'http://localhost:57661/api/sales',
            headers: {},
            data: { Salesman: $scope.saleRec.Salesman,
                    VehicleIds: $scope.saleRec.VehicleIds, 
                    PartIds: $scope.saleRec.PartIds, 
                    Status: $scope.saleRec.Status, 
                    AddonIds: $scope.saleRec.AddonIds, 
                    PayerIds: $scope.saleRec.PayerIds,
                    PaymentType: $scope.saleRec.PaymentType,
                    DateCreated: $scope.saleRec.DateCreated,
                    DateEdited: $scope.saleRec.DateEdited},
        }
        $http(req).
         then(function (response) {
             $scope.ok = "It's good";
         }, function (response) {
             $scope.statusCode = response.statusCode;
         }
         );
    }

    $scope.GetSearchVeh = function (Data) {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/vehicle',
            headers: {
                //'Authorization': 'Bearer='+ 'token'
            },
            params: { regNR: $scope.vehReg, itemNR: $scope.vehNr, name: $scope.vehName }
        }
        $http(req).
         then(function (response) {
             $scope.vehRec = [];
             for (var i = 0; i < response.data.length; i++) {
                 $scope.vehRec.push(response.data[i]);
             }
         }, function (response) {
             $scope.statusCode = response.statusCode;
         }
         );
    }

    $scope.showInfo = function(){
        null;
    }

    $scope.GetAllSales = function (Data) {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/sales',
            headers: {
                //'Authorization': 'Bearer='+ 'token'
            },
        }
        $http(req).
         then(function (response) {
             $scope.types = response.data;
         }, function (response) {
             $scope.statusCode = response.statusCode;
         }
         );
    }

    $scope.GetSearchSales = function () {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/sales',
            headers: {
                //'Authorization': 'Bearer='+ 'token'
            },
        }
        $http(req).
         then(function (response) {
             $scope.types = response.data;
         }, function (response) {
             $scope.statusCode = response.statusCode;
         }
         );
    }

    $scope.GetParts = function () {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/part',
        }
        $http(req).
         then(function (response) {
             $scope.types = response.data;
         }, function (response) {
             $scope.statusCode = response.statusCode;
         }
         );
    }

    $scope.GetSearchParts = function () {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/part',
            params: { ItemId: $scope.artNum, ItemName: $scope.artName }
        }
        $http(req).
         then(function (response) {
             $scope.partsRec = [];
             for (var i = 0; i < response.data.length; i++) {
                 $scope.partsRec.push(response.data[i]);
             }
                 
         }, function (response) {
             $scope.statusCode = response.statusCode;
         }
         );
    }

    $scope.$watch(function () { return SaleFactory.getSalesman(); }, function (newValue, oldValue) {
        if (newValue !== oldValue) $scope.salesman = newValue;
    });

    $scope.init();

});

tacdisDeluxeApp.config(function ($routeProvider) {
    $routeProvider
        .when('/newSale', {
            templateUrl: '/AngularTemplates/Sales/NewSale.html',
            controller: 'SalesController'
        })
        .when('/oldSale', {
            templateUrl: '/AngularTemplates/Sales/OldSale.html',
            controller: 'SalesController'
        })
        .when('/newSalesman', {
            templateUrl: '/AngularTemplates/Sales/NewSalesman.html',
            controller: 'PayerSalesmanController'
        })
        .when('/newPayer', {
            templateUrl: '/AngularTemplates/Sales/NewPayer.html',
            controller: 'PayerSalesmanController'
        })
        .when('/oldSalesmen', {
            templateUrl: '/AngularTemplates/Sales/OldSalesmen.html',
            controller: 'PayerSalesmanController'
        });
});
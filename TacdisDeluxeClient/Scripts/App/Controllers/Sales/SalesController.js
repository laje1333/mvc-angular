'use strict';

tacdisDeluxeApp.controller("SalesController", function ($scope, $rootScope, $http) {

    $scope.init = function () {
        
    }

    //Record that holds SaleItems
    $rootScope.record = [];
    //TotalCost
    $rootScope.totalCost = 0;
    //SaleRec
    $scope.saleRec = {};
    $scope.saleRec.PartIds = [];
    $scope.saleRec.VehicleIds = [];
    $scope.saleRec.AddonIds = [];

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

    
    $scope.calcTotal = function () {
        $rootScope.selectedTypeOfThingy;
        $rootScope.totalCost += parseFloat($scope.selected.price);
    };

    
    $scope.addRow = function () {
        switch ($scope.selectedTypeOfThingy) {
            case 0:
                $scope.saleRec.VehicleIds.push($scope.selected.id);           
                break;
            case 1:
                $scope.saleRec.PartIds.push($scope.selected.id);
                break;
            case 2:
                $scope.saleRec.AddonIds.push($scope.selected.id);
                break;
        }
        
        $rootScope.record.push({ 'Type': 'Part', 'Name': $scope.selected.ItemName, 'Number': $scope.selected.ItemId, 'Price': $scope.selected.ItemPrice });
        $scope.calcTotal();
        $rootScope.selected = '';
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

    $scope.PostSalesman = function(obj){
        var req = {
            method: 'POST',
            url: 'http://localhost:57661/api/sales',
            headers: { },
            data: { FirstName: 'Pelle', LastName: 'Chanslos' },
        }
        $http(req).
         then(function (response) {
             $scope.ok = "It's good";
         }, function (response) {
             $scope.statusCode = response.statusCode;
         }
         );
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
    $rootScope.selected = null;
    $scope.selectedRow = null;
    $scope.setSelected = function () {
        $scope.selected = this.r;
        switch ($scope.selectedTypeOfThingy) {
            case 0:
                $scope.selected.id = this.r.Id;
                break;
            case 1:
                $scope.selected.id = this.r.Id;
                break;
            case 2:
                $scope.selected.id = this.r.Id;
                break;
        }
        $scope.selectedRow = this.$index;
        
    };

    $scope.GetSearchParts = function () {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/part',
            params: { articleNumber: $scope.artNum, articleName: $scope.artName }
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
        });
});
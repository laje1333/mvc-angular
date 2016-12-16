'use strict';

tacdisDeluxeApp.controller("SalesController", function ($scope, $rootScope, $http) {

    $scope.init = function () {
        
    }

    $scope.panes = [
        { title: "Vehicles", template: "AngularTemplates/Sales/Panes/Vehicles.html", active: true },
        { title: "Parts", template: "AngularTemplates/Sales/Panes/Parts.html" },
        { title: "Add Ons", template: "AngularTemplates/Sales/Panes/Addons.html" }];


    $scope.active = function () {    
        return $scope.panes.filter(function (pane) {
            return pane.active;
        })[0];
    };

    $rootScope.totalCost = 0;
    $scope.calcTotal = function () {
        $rootScope.totalCost += parseFloat($scope.selected.price);
    };

    $rootScope.record = [];
    $scope.addRow = function () {
        $rootScope.record.push({ 'type': $scope.selected.type, 'name': $scope.selected.name, 'cost': $scope.selected.price });
        $scope.calcTotal();
        $rootScope.selected = '';
    };
    $scope.onlyNumbers = /^\d+(?:\.\d+|)$/;

    $scope.changeTypeOfSearch = function () {
        $('.searchOptions').hide();
        $('#Search' + $scope.searchTypeOfItem).show();
    };

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
        $scope.selectedRow = this.$index;
    };

    $scope.GetSearchParts = function () {
        if (!($scope.artNum)) {
            $scope.artNum = "";
        }
        if (!($scope.artName)) {
            $scope.artName = "";
        }
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/part',
            params: { articleNumber: $scope.artNum, articleName: $scope.artName }
        }
        $http(req).
         then(function (response) {
             $scope.partsRec = [];
             for (var i = 0; i < response.data.length; i++) {
                 $scope.partsRec.push({ 'number': response.data[i].ArticleNumber, 'name': response.data[i].ArticleName, 'price': response.data[i].Price, 'type': 'Part' });
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
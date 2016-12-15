'use strict';

tacdisDeluxeApp.controller("SalesController", function ($scope, $rootScope, $http) {

    $scope.init = function () {
        $scope.sendGet();
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
        $rootScope.totalCost += parseFloat($scope.cost);
    };

    $rootScope.record = [];
    $scope.addRow = function () {
        $rootScope.record.push({ 'type': $scope.type, 'info': $scope.info, 'cost': $scope.cost });
        $scope.calcTotal();
        $scope.type = '';
        $scope.info = '';
        $scope.cost = '';
    };
    $scope.onlyNumbers = /^\d+(?:\.\d+|)$/;

    $scope.changeTypeOfSearch = function () {
        $('.searchOptions').hide();
        $('#Search' + $scope.searchTypeOfItem).show();
    };

    $scope.sendPut = function(obj){
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

    $scope.sendGet = function (Data) {
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
    
    //$http.get('http://localhost:57661/api/sales').
    //     then(function (response) {
    //         $scope.types = response.data.split(',');
    //     });

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
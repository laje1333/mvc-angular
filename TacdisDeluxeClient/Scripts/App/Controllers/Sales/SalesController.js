'use strict';

tacdisDeluxeApp.controller("SalesController", function ($scope, $http) {

    $scope.init = function () {
        $scope.sendGet();
    }

    $scope.totalCost = 0;
    $scope.calcTotal = function () {
        $scope.totalCost += parseFloat($scope.cost);
    };

    $scope.record = [];
    $scope.addRow = function () {
        $scope.record.push({ 'type': $scope.type, 'info': $scope.info, 'cost': $scope.cost });
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

    $scope.sendPut = function(Data){
        var req = {
            method: 'PUT',
            url: 'http://localhost:57661/api/sales',
            data: Data,
            headers: {
                //'Authorization': 'Bearer='+ 'token'
            },
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
             $scope.types = response.data.split(',');
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
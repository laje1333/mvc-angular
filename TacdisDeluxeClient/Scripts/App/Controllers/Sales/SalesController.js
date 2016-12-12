﻿'use strict';



tacdisDeluxeApp.controller("SalesController", function ($scope, $http) {
    $http.get('http://localhost:57661/api/sales').
         then(function (response) {
             $scope.types = response.data.split(',');
         });
    $scope.record = [];
    $scope.addRow = function () {
        $scope.record.push({ 'type': $scope.type, 'info': $scope.info, 'cost': $scope.cost });
        $scope.type = '';
        $scope.info = '';
        $scope.cost = '';
    };
    $scope.onlyNumbers = /^\d+$/;

    $scope.changeTypeOfSearch = function () {
        $('.searchOptions').hide();
        $('#Search' + $scope.searchTypeOfItem).show();
    };
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
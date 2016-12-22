'use strict'

tacdisDeluxeApp.controller("PayerSalesmanController", function ($scope, $rootScope, $http, SaleFactory) {

    $scope.allSalesmen = [];
    $scope.firstName = "";
    $scope.lastName = "";
    $scope.company = "";
    $scope.salesman = "";

    $scope.PostPayer = function (obj) {
        var req = {
            method: 'POST',
            url: 'http://localhost:57661/api/payer',
            headers: {},
            data: {
                FirstName: $scope.firstName,
                LastName: $scope.lastName,
                Trusted: $scope.trusted,
                Address: $scope.address,
                ZipCity: $scope.zipCity,
                Country: $scope.country
            },
        }
        $http(req).
         then(function (response) {
             $scope.ok = "It's good";
         }, function (response) {
             $scope.statusCode = response.statusCode;
         });
    }

    $scope.PostSalesman = function (obj) {
        var req = {
            method: 'POST',
            url: 'http://localhost:57661/api/salesman',
            headers: {},
            data: {
                FirstName: $scope.firstName,
                LastName: $scope.lastName,
                Company: $scope.company,
                Address: $scope.address,
                ZipCity: $scope.zipCity,
                Country: $scope.country
            },
        }
        $http(req).
         then(function (response) {
             $scope.ok = "It's good";
         }, function (response) {
             $scope.statusCode = response.statusCode;
         });
    }
    $scope.showInfo = function () {
        null;
    }

    $scope.GetSalesmanById = function () {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/salesman',
            params: { empNr: parseInt($scope.empNr) }
        }
        
        $http(req).
         then(function (response) {
             document.getElementById('searchIcon').className = 'glyphicon glyphicon-ok-sign';
             document.getElementById('searchButton').className = 'btn btn-success';
             $scope.salesman = response.data;
         }, function (response) {
             document.getElementById('searchIcon').className = 'glyphicon glyphicon-search';
             document.getElementById('searchButton').className = 'btn btn-default';
             $scope.statusCode = response.statusCode;
         });
    }

    $scope.$watch('salesman', function (newValue, oldValue) {
        if (newValue !== oldValue) SaleFactory.setSalesman(newValue);
    });

    $scope.GetSalesmen = function () {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/salesman',
            params: { FirstName: $scope.firstName, LastName: $scope.lastName, Company: $scope.company }
        }
        $http(req).
         then(function (response) {
             $scope.allSalesmen = [];
             for (var i = 0; i < response.data.length; i++) {
                 $scope.allSalesmen.push(response.data[i]);
             }
         }, function (response) {
             $scope.statusCode = response.statusCode;
         });
    }

});
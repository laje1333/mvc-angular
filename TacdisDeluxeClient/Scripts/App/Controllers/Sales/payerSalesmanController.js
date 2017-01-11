'use strict'

tacdisDeluxeApp.controller("PayerSalesmanController", function ($scope, $rootScope, $http, SaleFactory, $route) {

    $scope.allSalesmen = [];
    $scope.firstName = "";
    $scope.lastName = "";
    $scope.company = "";
    $scope.salesman = "";

    $scope.PostPayer = function (obj) {
        var req = {
            method: 'POST',
            url: 'http://localhost:57661/api/payer',
            headers: { Authorization: 'bearer ' + window.sessionStorage.getItem('Token') },
            data: {
                FirstName: $scope.firstName,
                LastName: $scope.lastName,
                Trusted: $scope.trusted,
                StreeatAddress: $scope.address,
                ZipCity: $scope.zipCity,
                Country: $scope.country
            },
        }
        $http(req).
         then(function (response) {
             $route.reload();
             feedbackPopup('Payer saved', { level: 'success', timeout: 2000 });
             $scope.ok = "It's good";
         }, function (response) {
             feedbackPopup('Something went wrong', { level: 'warning', timeout: 2000 });
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
             $route.reload();
             feedbackPopup('Salesman saved', { level: 'success', timeout: 2000 });
             $scope.ok = "It's good";
         }, function (response) {
             feedbackPopup('Salesman saved', { level: 'warning', timeout: 2000 });
             $scope.statusCode = response.statusCode;
         });
    }
    $scope.showInfo = function () {
        null;
    }

    $scope.GetPayerById = function () {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/payer',
            params: { CustNr: parseInt($scope.CustNr) }
        }

        $http(req).
         then(function (response) {
             window.sessionStorage.getItem('Token');
             document.getElementById('searchIconP').className = 'glyphicon glyphicon-ok-sign';
             document.getElementById('searchButtonP').className = 'btn btn-success';
             feedbackPopup('Payer found', { level: 'success', timeout: 2000 });
             $scope.payer = response.data;
         }, function (response) {
             document.getElementById('searchIconP').className = 'glyphicon glyphicon-search';
             document.getElementById('searchButtonP').className = 'btn btn-default';
             feedbackPopup('No payer found', { level: 'warning', timeout: 2000 });
             $scope.payer = {};
             $scope.statusCode = response.statusCode;
         });
    }

    $scope.checkIfEmpty = function (str, btnId, iconId) {
        if (str.length == 0) {
            document.getElementById(iconId).className = 'glyphicon glyphicon-search';
            document.getElementById(btnId).className = 'btn btn-default';
        }
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
             feedbackPopup('Salesman found', { level: 'success', timeout: 2000 });
             $scope.salesman = response.data;
         }, function (response) {
             document.getElementById('searchIcon').className = 'glyphicon glyphicon-search';
             document.getElementById('searchButton').className = 'btn btn-default';
             feedbackPopup('No salesman found', { level: 'warning', timeout: 2000 });
             $scope.salesman = {};
             $scope.statusCode = response.statusCode;
         });
    }

    $scope.$watch('salesman', function (newValue, oldValue) {
        if (newValue !== oldValue) SaleFactory.setSalesman(newValue);
    });
    $scope.$watch('payer', function (newValue, oldValue) {
        if (newValue !== oldValue) SaleFactory.setPayer(newValue);
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
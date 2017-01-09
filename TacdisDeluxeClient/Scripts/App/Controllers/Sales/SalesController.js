'use strict';

tacdisDeluxeApp.controller("SalesController", function ($scope, $rootScope, $http, SaleFactory, NgTableParams) {

    $scope.$on('$viewContentLoaded', hotlinkToMenu);

    $scope.init = function () {

    }
    //Used for searching  vehicles
    $scope.vehName = "";
    $scope.vehNr = "";
    $scope.vehReg = "";

    $scope.amount = 1;
    //Used for searching parts
    $scope.artName = "";
    $scope.artNum = "";

    //Record that holds SaleItems
    $rootScope.record = [];

    //TotalCost of the sale
    $rootScope.totalCost = 0;

    //SaleRec holds the sale items
    $rootScope.saleRec = {};
    $rootScope.saleRec.PartIds = [];
    $rootScope.saleRec.VehicleIds = [];
    $rootScope.saleRec.AddonIds = [];
    $rootScope.saleRec.Salesman = {};
    $rootScope.saleRec.Payers = [];
    $rootScope.saleRec.PayerIds = [];

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

        var Exists = false;

        switch ($scope.selectedTypeOfThingy) {
            case 0:
                for (var i = 0; i < $rootScope.record.length; i++) {
                    if (this.r.ItemId === $rootScope.record[i].Number) {
                        Exists = true;
                    } 
                }
                if (!Exists) {
                    $rootScope.saleRec.VehicleIds.push(this.r.ItemId);
                    $rootScope.record.push({ 'Type': 'Vehicle', 'Name': this.r.ItemName, 'Number': this.r.ItemId, 'Price': this.r.ItemPrice, 'Amount': 1 });
                    $scope.calcTotal(this.r.ItemPrice);
                }
                break;
            case 1:
                var x = Maths.Arrays.BinarySearch($rootScope.saleRec.PartIds, this.r.ItemId, 'Id');
                if (x == null) {
                    $rootScope.record.push({ 'Type': 'Part', 'Name': this.r.ItemName, 'Number': this.r.ItemId, 'Price': this.r.ItemPrice, 'Amount': 1 });
                    $rootScope.saleRec.PartIds.push({ Id: this.r.ItemId, Amount: 1});
                } else {
                    for (var i = 0; i < $rootScope.record.length; i++) {
                        if (this.r.ItemId === $rootScope.record[i].Number) {
                            $rootScope.record[i].Amount += 1;
                            $rootScope.saleRec.PartIds[x].Amount += 1;
                        }
                    }
                }
                $scope.calcTotal(this.r.ItemPrice);
                break;
            case 2:
                $rootScope.saleRec.AddonIds.push(this.r.ItemId);
                $scope.calcTotal(this.r.ItemPrice);
                break;
        }

        
        
        
    };

    $scope.getSales = function () {
        var req = {
            method: 'GET',
            url: 'http://localhost:57661/api/Sales/AllSales',
            headers: {},
        }
        $http(req).
         then(function (response) {
             $scope.allSales = response.data;
         }, function (response) {
             feedbackPopup('Something went wrong!', { level: 'warning', timeout: 4000 });
             $scope.statusCode = response.statusCode;
         }
         );
    }

    $scope.PostOrUpdateSale = function () {
        var url = 'http://localhost:57661/api/Sales'
        var type = 'POST';
        if ($rootScope.saleRec.Id == null) {
            url += '/NewSale';
        } else {
            type = 'PUT';
            url += '/UpdateSale';
        }
        var req = {
            method: type,
            url: url,
            headers: {},
            data: {
                Id: $rootScope.saleRec.Id,
                Salesman: $rootScope.saleRec.Salesman,
                VehicleIds: $rootScope.saleRec.VehicleIds,
                PartIds: $rootScope.saleRec.PartIds,
                Status: 1,
                AddonIds: $rootScope.saleRec.AddonIds,
                PayerIds: $rootScope.saleRec.PayerIds,
                PaymentType: 1,
                DateCreated: new Date().toLocaleString(),
                DateEdited: new Date().toLocaleString()
            },
        }
        $http(req).
         then(function (response) {
             feedbackPopup('Sale has been saved!', { level: 'success', timeout: 4000 });
             $rootScope.saleRec.Id = response.data;
         }, function (response) {
             feedbackPopup('Something went wrong!', { level: 'warning', timeout: 4000 });
             $scope.statusCode = response.statusCode;
         }
         );
    }

     $scope.PostSale = function () {
        var req = {
            method: 'POST',
            url: 'http://localhost:57661/api/invoice/CreatInvoice/CreateInvoiceFromSales',
            headers: {},
            data: {
                Salesman: $rootScope.saleRec.Salesman,
                VehicleIds: $rootScope.saleRec.VehicleIds,
                PartIds: $rootScope.saleRec.PartIds,
                Status: 1,
                AddonIds: $rootScope.saleRec.AddonIds,
                PayerIds: $rootScope.saleRec.PayerIds,
                PaymentType: 1,
                DateCreated: new Date().toLocaleString(),
                DateEdited: new Date().toLocaleString()
            },
        }
        $http(req).
         then(function (response) {
             feedbackPopup('Invoice has been created!', { level: 'success', timeout: 4000 });
             $scope.ok = "It's good";
         }, function (response) {
             feedbackPopup('All data needed was not provided!', { level: 'warning', timeout: 4000 });
             $scope.statusCode = response.statusCode;
         }
         );
    }

    $scope.increaseAmount = function () {
        $scope.calcTotal(this.r.Price);
        this.r.Amount += 1;
        var x = Maths.Arrays.BinarySearch($rootScope.saleRec.PartIds, this.r.Number, 'Id');
        if (x != null) {
            $rootScope.saleRec.PartIds[x].Amount = this.r.Amount;
        }

    }

    $scope.decreaseAmount = function () {
        $rootScope.totalCost -= parseFloat(this.r.Price);
        this.r.Amount -= 1;
        var x = Maths.Arrays.BinarySearch($rootScope.saleRec.PartIds, this.r.ItemId, 'Id');
        if (x != null) {
            $rootScope.saleRec.PartIds[x].Amount = this.r.Amount;
        }
    }

    $scope.onlyNumbers = /^\d+(?:\.\d+|)$/;

    $scope.changeTypeOfSearch = function () {
        $('.searchOptions').hide();
        $('#Search' + $scope.searchTypeOfItem).show();
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

    $scope.showInfo = function () {
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
             $scope.PartsTable = new NgTableParams({
                 sorting: { ItemName: "asc" }
             },
             {
                 dataset: response.data
             });

         }, function (response) {
             $scope.statusCode = response.statusCode;
         }
         );
       
    }

    $scope.$watch(function () { return SaleFactory.getPayer(); }, function (newValue, oldValue) {
        if (newValue.Id !== oldValue.Id) {
            $rootScope.saleRec.Payers = newValue;
            $rootScope.saleRec.PayerIds = newValue.Id;
        }
    });

    $scope.$watch(function () { return SaleFactory.getSalesman(); }, function (newValue, oldValue) {
        if (newValue !== oldValue) $rootScope.saleRec.Salesman = newValue;
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
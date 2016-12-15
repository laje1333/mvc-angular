'use strict';

var invoices = [
    {
        "Name": "Alfreds Futterkiste",
        "Country": "Germany"
    },
    {
        "Name": "Berglunds snabbköp",
        "Country": "Sweden"
    },
    {
        "Name": "Centro comercial Moctezuma",
        "Country": "Mexico"
    },
    {
        "Name": "Ernst Handel",
        "Country": "Austriaaa"
    }
];


tacdisDeluxeApp.controller("PartsController", function ($scope, $http, $dialog) {
    $scope.showez = false;

    $scope.records = invoices;
    $scope.listParts = function () {
        $dialog.dialog({}).open('/AngulatTemplates/Parts/_modal_search_retail_sale_orders.html');
    };







    $scope.showezMoi = function () {
        $http({
            method: 'GET',
            url: 'http://localhost:57661/api/Part/Kalle?id=1234444'
        }).then(function successCallback(response) {
            console.log(response);
            $scope.showez = true;
        }, function errorCallback(response) {
            console.log(response);
        });
    };

    $scope.postez = function () {
        $http.post('http://localhost:57661/api/Part/Kaka', 
            {
                'name': 'Kalle',
                'email': 'kalle.henriksson@gmail.com'
            },
            {
                'headers': {
                    'Content-Type': 'application/json; charset=UTF-8'
                }
            }
            ).success(function (data) {
        });
    };
});



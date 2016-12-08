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


tacdisDeluxeApp.controller("PartsController", function ($scope) {
    $scope.listParts = function () {
        $scope.records = invoices;
    };
});



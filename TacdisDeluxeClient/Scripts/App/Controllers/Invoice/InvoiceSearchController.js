invoices = [
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


tacdisDeluxeApp.controller("InvoiceSearchCtrl", function ($scope) {
    $scope.searchInvoices = function () {
        $scope.records = invoices;
    };

});
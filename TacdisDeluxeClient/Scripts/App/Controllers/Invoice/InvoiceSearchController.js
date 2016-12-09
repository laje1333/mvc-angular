//invoices = [
//    {
//        "Name": "Alfreds Futterkiste",
//        "Country": "Germany"
//    },
//    {
//        "Name": "Berglunds snabbköp",
//        "Country": "Sweden"
//    },
//    {
//        "Name": "Centro comercial Moctezuma",
//        "Country": "Mexico"
//    },
//    {
//        "Name": "Ernst Handel",
//        "Country": "Austriaaa"
//    }
//];


tacdisDeluxeApp.controller("InvoiceSearchCtrl", function ($scope, $http) {
    $scope.searchInvoices = function () {
        $http.get("http://localhost:57661/api/invoice/GetInvoice?query=1")
    .then(function (response) {
        $scope.testget = response.data;
    });
       // $scope.records = invoices;
    };
});
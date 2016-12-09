


tacdisDeluxeApp.controller("InvoiceSearchCtrl", function ($scope, $http) {
    $scope.searchInvoices = function () {
        $http.get("http://localhost:57661/api/invoice/GetInvoice?query=1")
    .then(function (response) {
        var obj = JSON.parse(response.data);
        $scope.records = obj.invoices;
    });
      
    };
});
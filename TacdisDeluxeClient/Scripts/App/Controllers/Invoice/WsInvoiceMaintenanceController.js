
tacdisDeluxeApp.controller("WsInvoiceMaintenanceCtrl", ["$scope", "wsInvoiceMaintenanceService", function ($scope, wsInvoiceMaintenanceService) {
    $scope.MaintenanceInvoice = [];

   
    $scope.page_load = function () {
        console.log("page load");
        $scope.invoices = wsInvoiceMaintenanceService.getInvoice();
        $scope.MaintenanceInvoice = $scope.invoices[0];
    };
   
}]);

tacdisDeluxeApp.service("wsInvoiceMaintenanceService", function () {
    var invoiceList = [];

    var addInvoice = function (newObj) {
        invoiceList.push(newObj);
    };

    var getInvoice = function () {
        return invoiceList;
    };

    return {
        addInvoice: addInvoice,
        getInvoice: getInvoice
    };

});


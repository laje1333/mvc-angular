
tacdisDeluxeApp.controller("WsInvoiceMaintenanceCtrl", ["$scope", "wsInvoiceMaintenanceService", function ($scope, wsInvoiceMaintenanceService) {
    $scope.InvoiceNumber ="";

    $scope.getInvoiceFromOverview = function () {
        console.log('getInvoice');
        $scope.invoices = wsInvoiceMaintenanceService.getInvoice();
        $scope.InvoiceNumber = $scope.invoices[0].InvoiceNumber;
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


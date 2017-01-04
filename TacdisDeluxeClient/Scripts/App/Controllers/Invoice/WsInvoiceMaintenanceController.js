
tacdisDeluxeApp.controller("WsInvoiceMaintenanceCtrl", ["$scope", "wsInvoiceMaintenanceService", "$http", "$rootScope", function ($scope, wsInvoiceMaintenanceService, $http, $rootScope) {
    //$rootScope.MaintenanceInvoice = [];
    $scope.cancelDisable = false;
    $scope.approveInvoice = true;

    $scope.page_load = function () {
        console.log("page load");
        $scope.invoices = wsInvoiceMaintenanceService.getInvoice();
        $scope.MaintenanceInvoice = $scope.invoices[0];
        //$scope.Rows = $scope.invoices[0].InvoiceRows;
        if ($scope.MaintenanceInvoice.InvoiceState == 3) {
            $scope.cancelDisable = true;
        }
        if ($scope.MaintenanceInvoice.InvoiceState == 1) {
            $scope.approveInvoice = false;
        }
    };

    $scope.update_invoice = function () {

        $http({
            url: 'http://localhost:57661/api/invoice/CreatInvoice/Create',//http://localhost:57661/api/invoice/UpdateInvoice/Update
            method: "POST",
            data: JSON.stringify($scope.MaintenanceInvoice),
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data, status, headers, config) {
            feedbackPopup('Saving invoice changes succeeded', { level: 'success', timeout: 2000 });
        }).error(function (data, status, headers, config) {
            feedbackPopup('Saving invoice changes failed', { level: 'warning', timeout: 2000 });
        });
        
    };

    $scope.cancel_invoice = function () {

        $scope.MaintenanceInvoice.InvoiceState = 3;
        $scope.cancelDisable = true;
    };

    $scope.approve_invoice = function () {

        $scope.MaintenanceInvoice.InvoiceState = 2;
        $scope.approveInvoice = true;
    };

    $scope.removeRow = function (idx, rowAmount) {
        $scope.MaintenanceInvoice.InvoiceAmount -= rowAmount;
        $scope.MaintenanceInvoice.InvoiceRows.splice(idx, 1);
    };

}]);

tacdisDeluxeApp.service("wsInvoiceMaintenanceService", function () {
    var invoiceList = [];

    var addInvoice = function (newObj) {
        invoiceList.length = 0;
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


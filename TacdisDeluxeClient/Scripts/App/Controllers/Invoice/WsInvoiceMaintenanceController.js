
tacdisDeluxeApp.controller("WsInvoiceMaintenanceCtrl", ["$scope", "wsInvoiceMaintenanceService", "$http",function ($scope, wsInvoiceMaintenanceService, $http) {
    $scope.MaintenanceInvoice = [];

   
    $scope.page_load = function () {
        console.log("page load");
        $scope.invoices = wsInvoiceMaintenanceService.getInvoice();
        $scope.MaintenanceInvoice = $scope.invoices[0];
    };

    $scope.update_invoice = function () {

        $http({
            url: 'http://localhost:57661/api/invoice/CreatInvoice',
            method: "POST",
            data: JSON.stringify($scope.MaintenanceInvoice),
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data, status, headers, config) {
            console.log("test success");
        }).error(function (data, status, headers, config) {
            console.log("test error");
        });
        
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


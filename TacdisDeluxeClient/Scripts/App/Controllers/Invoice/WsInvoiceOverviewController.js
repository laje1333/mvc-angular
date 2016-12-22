


tacdisDeluxeApp.controller("WsInvoiceOverviewCtrl", ["$scope", "NgTableParams", "$http", "wsInvoiceMaintenanceService", "$filter", function ($scope, ngTableParams, $http, wsInvoiceMaintenanceService, $filter) {
    
    $scope.spinner = false;
    $scope.showModal = false;
    $scope.invoceviewed = "";
    
    $scope.SearchInvoices = function () {
        $scope.spinner = true;
        $http.get("http://localhost:57661/api/invoice/GetInvoice?query=" + $scope.inputVal)
    .then(function (response) {
        $scope.spinner = false;
        
        $scope.records = response.data;
        $scope.invoiceTable = new ngTableParams({
          
        },{
            dataset: $scope.records
        });
    });
    };
   
    $scope.sendToMaintenance = function (invoice) {
        console.log('sendToMaintenance');

        wsInvoiceMaintenanceService.addInvoice(invoice);
    };

   
    $scope.toggleModal = function (invoiceClicked) {
        $scope.invoceviewed = invoiceClicked;
        $scope.showModal = !$scope.showModal;
    };


}]);

tacdisDeluxeApp.filter('valuta', function () {
    return function (item) {
        return item + " Kr";
    };
});

tacdisDeluxeApp.directive('modal', function () {
    return {
        template: '<div class="modal fade">' +
            '<div class="modal-dialog">' +
              '<div class="modal-content">' +
                '<div class="modal-header">' +
                  '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                  '<h4 class="modal-title"> Invoice {{ invoceviewed }} </h4>' +
                '</div>' +
                '<div class="modal-body" ng-transclude></div>' +
              '</div>' +
            '</div>' +
          '</div>',
        restrict: 'E',
        transclude: true,
        replace: true,
        scope: true,
        link: function postLink(scope, element, attrs) {
            scope.$watch(attrs.visible, function (value) {
                if (value == true)
                    $(element).modal('show');
                else
                    $(element).modal('hide');
            });

            $(element).on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = true;
                });
            });

            $(element).on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.$parent[attrs.visible] = false;
                });
            });
        }
    };
});
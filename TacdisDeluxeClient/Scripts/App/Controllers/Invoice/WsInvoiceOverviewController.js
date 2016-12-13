


tacdisDeluxeApp.controller("WsInvoiceOverviewCtrl", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {
    
    $scope.SearchInvoices = function () {
        $http.get("http://localhost:57661/api/invoice/GetInvoice?query=1")
    .then(function (response) {
        var obj = JSON.parse(response.data);
        $scope.records = obj.invoices;

        $scope.invoiceTable = new ngTableParams({

        }, {
            dataset: $scope.records
        });
    });
    };
   

 $scope.showModal = false;
    $scope.invoceviewed = "";
    $scope.toggleModal = function (invoiceClicked) {
        $scope.invoceviewed = invoiceClicked;
        $scope.showModal = !$scope.showModal;
    };
}]);

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
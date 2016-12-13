

tacdisDeluxeApp.config(function ($routeProvider) {
    $routeProvider
        .when('/WsInvoiceOverview', {
            templateUrl: '/AngularTemplates/Invoice/WsInvoiceOverview.html',
            controller: 'WsInvoiceOverviewCtrl'
        })
    .when('/WsInvoiceMaintenance', {
        templateUrl: '/AngularTemplates/Invoice/WsInvoiceMaintenance.html',
        controller: 'WsInvoiceMaintenanceCtrl'
    });


});

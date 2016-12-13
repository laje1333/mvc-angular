
// route
tacdisDeluxeApp.config(function ($routeProvider) {
    $routeProvider
        .when('/search', {
            templateUrl: '/AngularTemplates/Invoice/invoice_search.html',
            controller: 'InvoiceSearchCtrl'
        });


});

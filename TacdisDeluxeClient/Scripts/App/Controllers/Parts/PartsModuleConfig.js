'use strict';


tacdisDeluxeApp.config(function ($routeProvider) {
    $routeProvider
        .when('/query', {
            templateUrl: '/AngularTemplates/Parts/price_query_form.html',
            controller: 'PartsController'
        })
        .when('/list', {
            templateUrl: '/AngularTemplates/Parts/parts_list.html',
            controller: 'PartsController'
        });
});



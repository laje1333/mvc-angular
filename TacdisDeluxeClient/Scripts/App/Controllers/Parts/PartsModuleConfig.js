'use strict';


tacdisDeluxeApp.config(function ($routeProvider) {
    $routeProvider
        .when('/list', {
            templateUrl: '/AngularTemplates/Parts/parts_list.html',
            controller: 'PartsController'
        });
});



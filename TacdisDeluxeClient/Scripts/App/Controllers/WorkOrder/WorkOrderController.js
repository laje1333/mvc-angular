tacdisDeluxeApp.controller("WorkOrderController", function ($scope, $http, $rootScope) {
    $scope.woh_regNr = $rootScope.woh_regNr;

    $scope.WOH_AddNewWOH = function () {
        $scope.urlString = 'http://localhost:57661/api/workorder/GetNewWO?addNew=' + "WOH&" + currentWoh;
        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $scope.currentWoh = components + "";//[0].split(',');
            $rootScope.woh_regNr = "";
        });
    }

    $scope.WOH_GetCurrentWOH = function () {
        $scope.urlString = 'http://localhost:57661/api/workorder/GetCurrentWO?getCurrent=' + "WOH";
        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $scope.currentWoh = components + "";//[0].split(',');
        });
    }
    $scope.WOH_GetCurrentWOH();

    $scope.WOH_AddNewWOJ = function () {
        $scope.urlString = 'http://localhost:57661/api/workorder/GetNewWO?addNew=' + "WOJ&" + currentWoh;
        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $scope.currentWoJ = components[0] + "";//[0].split(',');
        });
    }

    $scope.WOH_GetCurrentWOJ = function () {
        $scope.urlString = 'http://localhost:57661/api/workorder/GetCurrentWO?getCurrent=' + "WOJ";
        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $scope.currentWoJ = components[0] + "";//[0].split(',');
        });
    }
    $scope.WOH_GetCurrentWOJ();

    $scope.RegNrChanged = function () {
        $rootScope.woh_regNr = $scope.woh_regNr;

        $scope.WOH_GetCurrentWOH();
        $scope.urlString = 'http://localhost:57661/api/workorder/GetRegNr?WOH=' + $scope.currentWoh + '&regnr=' + $scope.woh_regNr;

        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $scope.woh_vehDesc = components[0].split(',');
            $scope.woh_regDate = components[1].split(',');
            $scope.woh_owner = components[2].split(',');
            $scope.woh_driver = components[3].split(',');
            $scope.woh_phone = components[4].split(',');
            $scope.woh_lastVisDate = components[5].split(',');
            $scope.woh_lastVisMileage = components[6].split(',');
        });
    }
    $scope.RegNrChanged();
});

tacdisDeluxeApp.controller("WorkOrderSearchController", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {
    $scope.SearchWoH = function () {
        $http.get("http://localhost:57661/api/workorder/GetWoHList?search=" + $scope.woh_Search)
        .then(function (response) {
            var obj = JSON.parse(response.data);
            $scope.records = obj.woh;

            $scope.wohTable = new ngTableParams({

            }, {
                dataset: $scope.records
            });
        });
    };
    //$scope.SearchWoH();
}]);


tacdisDeluxeApp.config(function ($routeProvider) {
    $routeProvider
        .when('/WOH_CustData', {
            templateUrl: '/AngularTemplates/WorkOrder/WOH_CustData.html',
            controller: 'WorkOrderController'
        })
        .when('/WOH_Manage', {
            templateUrl: '/AngularTemplates/WorkOrder/WOH_Manage.html',
            controller: 'WorkOrderController'
        })
        .when('/WOH_Select', {
            templateUrl: '/AngularTemplates/WorkOrder/WOH_Select.html',
            controller: 'WorkOrderController'
        })
        .when('/WOJ_Kit', {
            templateUrl: '/AngularTemplates/WorkOrder/WOJ_Kit.html',
            controller: 'WorkOrderController'
        })
        .when('/WOJ_Manage', {
            templateUrl: '/AngularTemplates/WorkOrder/WOJ_Manage.html',
            controller: 'WorkOrderController'
        })
        .when('/WOJ_Operations', {
            templateUrl: '/AngularTemplates/WorkOrder/WOJ_Operations.html',
            controller: 'WorkOrderController'
        })
        .when('/WOJ_Parts', {
            templateUrl: '/AngularTemplates/WorkOrder/WOJ_Parts.html',
            controller: 'WorkOrderController'
        })
        .when('/WOJ_Select', {
            templateUrl: '/AngularTemplates/WorkOrder/WOJ_Select.html',
            controller: 'WorkOrderController'
        })
        .when('/WOH_Finalize', {
            templateUrl: '/AngularTemplates/WorkOrder/WOH_Finalize.html',
            controller: 'WorkOrderController'
        });
});


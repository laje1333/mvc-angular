tacdisDeluxeApp.controller("WorkOrderController", function ($scope, $http, $rootScope) {
    $scope.currentWoh = $rootScope.currentWoh;

    $scope.WOH_GetCurrentWOH = function () {
        $scope.urlString = 'http://localhost:57661/api/workorder/GetCurrentWO?getCurrent=' + "WOH";
        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $scope.currentWoh = components + "";//[0].split(',');
        });
    }
    $scope.WOH_GetCurrentWOH();

    $scope.WOH_GetCurrentWOJ = function () {
        $scope.urlString = 'http://localhost:57661/api/workorder/GetCurrentWO?getCurrent=' + "WOJ";
        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $scope.currentWoJ = components[0] + "";//[0].split(',');
        });
    }
    $scope.WOH_GetCurrentWOJ();

    $scope.GetRegNr = function () {
        $scope.currentWoh = $rootScope.currentWoh;
        $scope.urlString = 'http://localhost:57661/api/workorder/GetRegNr?WOHID=' + $scope.currentWoh;

        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $rootScope.woh_regNr = $scope.woh_regNr = components[0].split(',');
            $scope.RegNrChanged();
        });
    }

    $scope.RegNrChanged = function () {
        $rootScope.woh_regNr = $scope.woh_regNr;
        $scope.WOH_GetCurrentWOH();
        $scope.urlString = 'http://localhost:57661/api/workorder/GetRegNrInfo?WOHID=' + $scope.currentWoh + '&regnr=' + $scope.woh_regNr;

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
});

tacdisDeluxeApp.controller("WorkOrderHeaderController", ["$scope", "$rootScope", "NgTableParams", "$http", function ($scope, $rootScope, ngTableParams, $http) {
    $scope.currentWoh = $rootScope.currentWoh;

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

    $scope.WOH_AddWOH = function () {

        var wohData = {
            WoNr: 10,
            Status: "New",

            RegNr : "",
            VehRegDate: "",
            VehOwner: "",
            VehDriver: "",
            VehPhoneNr: "",
            VehLastVisDate: "",
            VehLastVisMil: "",

            CurrentMilage: "",
            PlannedMechID: 0,
            PlannedMechName: "",

            CreatedDate: "",
            PlannedDate: "",
            CheckedInDate: "",

            MainPayer: "",
            RespBy: "",
            TotCost: 0,

            WOJ_Ids: ""
        }

        $http({
            method: 'POST',
            url: "http://localhost:57661/api/workorder/PostWOH",
            data: wohData
        }).success(function () {
            feedbackPopup('Successefully added new Workorder', { level: 'success', timeout: 2000 });
        });

        $scope.SearchWoH();
    }

    $scope.WOH_AddNewWOH = function () {
        $scope.urlString = 'http://localhost:57661/api/workorder/GetNewWO?addNew=' + "WOH" + "&wohId=" + $scope.currentWoh;
        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $rootScope.currentWoh = $scope.currentWoh = components + "";
            $rootScope.woh_regNr = $scope.woh_regNr = ""
        });
        $scope.SearchWoH();
    }

    $scope.WOH_SetCurrentWOH = function (itemWoh) {
        $scope.urlString = 'http://localhost:57661/api/workorder/SetCurrentWO?setCurrent=' + "WOH" + "&itemId=" + itemWoh;
        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $rootScope.currentWoh = $scope.currentWoh = components + "";
        });
    }


}]);

tacdisDeluxeApp.controller("WorkOrderJobController", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {
    $scope.WOH_AddNewWOJ = function () {
        $scope.urlString = 'http://localhost:57661/api/workorder/GetNewWO?addNew=' + "WOJ" + "&wohId=" + $scope.currentWoh;
        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $scope.currentWoJ = components[0] + "";
        });
    }

    $scope.SearchWoJ = function () {
        $http.get('http://localhost:57661/api/workorder/GetWoJobList?wohid=' + $scope.currentWoh)
        .then(function (response) {
            var obj = JSON.parse(response.data);
            $scope.records = obj.woj;

            $scope.wojTable = new ngTableParams({

            }, {
                dataset: $scope.records
            });
        });
    };
}]);


tacdisDeluxeApp.controller("WOActiveKitsController", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {
    $scope.AddNewKit = function () {
        $http.get("http://localhost:57661/api/workorder/GetWJKList?wjkcode=" + $scope.wjkCode + '&wohId=' + $scope.currentWoh + '&wojId=' + $scope.currentWoJ)
        .then(function (response) {
            var obj = JSON.parse(response.data);
            $scope.wjkRec = obj.wjk;

            $scope.wjkTable = new ngTableParams({

            }, {
                dataset: $scope.wjkRec
            });
        });
    };
}]);

tacdisDeluxeApp.controller("WOActiveOpController", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {
    $scope.AddNewOp = function () {
        $http.get("http://localhost:57661/api/workorder/GetWJOList?wjocode=" + $scope.wjoCode + '&wohId=' + $scope.currentWoh + '&wojId=' + $scope.currentWoJ)
        .then(function (response) {
            var obj = JSON.parse(response.data);
            $scope.wjoRec = obj.wjo;

            $scope.wjoTable = new ngTableParams({

            }, {
                dataset: $scope.wjoRec
            });
        });
    };
}]);

tacdisDeluxeApp.controller("WOActivePartController", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {
    $scope.AddNewPart = function () {
        $http.get("http://localhost:57661/api/workorder/GetWJPList?wjpcode=" + $scope.wjpCode + '&wohId=' + $scope.currentWoh + '&wojId=' + $scope.currentWoJ)
        .then(function (response) {
            var obj = JSON.parse(response.data);
            $scope.wjpRec = obj.wjp;

            $scope.wjpTable = new ngTableParams({

            }, {
                dataset: $scope.wjpRec
            });
        });
    };
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


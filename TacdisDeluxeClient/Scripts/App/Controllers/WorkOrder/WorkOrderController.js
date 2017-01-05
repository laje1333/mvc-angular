tacdisDeluxeApp.controller("WorkOrderController", function ($scope, $http, $rootScope) {

    $scope.GetStatus = function () {
        $http({
            method: 'GET',
            url: "http://localhost:57661/api/workorder/GetWoh?wohId=" + $rootScope.currentWoh
        })
        .then(function (response) {
            $scope.woh_Status = response.data.Status;
            $scope.woh_PlannedDate = response.data.PlannedDate;
            $scope.woh_IsCheckedIn = response.data.IsCheckedIn;
            $scope.woh_CheckedInDate = response.data.CheckedInDate;
            $scope.woh_CurrentMilage = response.data.CurrentMilage;
            $scope.woh_PlannedMechID = response.data.PlannedMechID;
            $scope.woh_PlannedMechName = response.data.PlannedMechName;
        });
    }

    $scope.SaveStatusData = function () {
        $scope.currentWoh = $rootScope.currentWoh;
        var statusData = {
            wohId: $scope.currentWoh,
            plannedDate: $scope.woh_PlannedDate,
            isCheckedIn: $scope.woh_IsCheckedIn,
            checkedInDate: $scope.woh_CheckedInDate,
            currentMilage: $scope.woh_CurrentMilage,
            plannedMechID: $scope.woh_PlannedMechID
        }

        $http({
            method: 'POST',
            url: "http://localhost:57661/api/workorder/PostStatusData",
            data: statusData
        }).success(function () {
            feedbackPopup('Successefully saved', { level: 'success', timeout: 2000 });
        });
    }

    $scope.GetRegNr = function () {
        $scope.urlString = 'http://localhost:57661/api/workorder/GetRegNr?WOHID=' + $rootScope.currentWoh;

        $http.get($scope.urlString)
        .then(function (response) {
            var components = response.data;

            $rootScope.woh_regNr = $scope.woh_regNr = components[0].split(',');
            $scope.RegNrChanged();
        });
    }

    $scope.RegNrChanged = function () {
        $rootScope.woh_regNr = $scope.woh_regNr;
        //$scope.WOH_GetCurrentWOH();
        $scope.urlString = 'http://localhost:57661/api/workorder/GetRegNrInfo?WOHID=' + $rootScope.currentWoh + '&regnr=' + $scope.woh_regNr;

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
    $scope.GetWOHList = function () {
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

            RegNr: "",
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
    }

    $scope.WOH_SetCurrentWOH = function (itemWoh) {
        $rootScope.currentWoh = itemWoh;
    }


}]);

tacdisDeluxeApp.controller("WorkOrderJobController", ["$scope", "$rootScope", "NgTableParams", "$http", function ($scope, $rootScope, ngTableParams, $http) {
    $scope.WOH_AddWOJ = function () {
        $http({
            method: 'POST',
            url: "http://localhost:57661/api/workorder/PostWOJ",
            params: { wohId: $rootScope.currentWoh }
        }).success(function () {
            feedbackPopup('Successefully added new Workorder Job', { level: 'success', timeout: 2000 });
        });
    }

    $scope.GetWOJList = function () {
        $http({
            method: 'GET',
            url: "http://localhost:57661/api/workorder/GetWoJobList",
            params: { wohId: $rootScope.currentWoh }
        })
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

tacdisDeluxeApp.controller("WOActiveKitsController", ["$scope", "$rootScope", "NgTableParams", "$http", function ($scope, $rootScope, ngTableParams, $http) {
    $scope.WOH_AddWJK = function () {
        $http({
            method: 'POST',
            url: "http://localhost:57661/api/workorder/AddWJK",
            params: { wjkcode: $scope.wjkCode, wohId: $rootScope.currentWoh, wojId: $rootScope.currentWoJ }
        }).success(function () {
            feedbackPopup('Successefully added new Kit', { level: 'success', timeout: 2000 });
        });
    }

    $scope.GetWJKList = function () {
        $http({
            method: 'GET',
            url: "http://localhost:57661/api/workorder/GetWJKList",
            params: { wohId: $rootScope.currentWoh, wojId: $rootScope.currentWoJ }
        })
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

tacdisDeluxeApp.controller("WOActiveOpController", ["$scope", "$rootScope", "NgTableParams", "$http", function ($scope, $rootScope, ngTableParams, $http) {
    $scope.WOH_AddWJO = function () {
        $http({
            method: 'POST',
            url: "http://localhost:57661/api/workorder/AddWJO",
            params: { wjocode: $scope.wjoCode, wohId: $rootScope.currentWoh, wojId: $rootScope.currentWoJ }
        }).success(function () {
            feedbackPopup('Successefully added new Operation', { level: 'success', timeout: 2000 });
        });
    }

    $scope.GetWJOList = function () {
        $http({
            method: 'GET',
            url: "http://localhost:57661/api/workorder/GetWJOList",
            params: { wohId: $rootScope.currentWoh, wojId: $rootScope.currentWoJ }
        })
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

tacdisDeluxeApp.controller("WOActivePartController", ["$scope", "$rootScope", "NgTableParams", "$http", function ($scope, $rootScope, ngTableParams, $http) {
    $scope.WOH_AddWJP = function () {
        $http({
            method: 'POST',
            url: "http://localhost:57661/api/workorder/AddWJP",
            params: { wjpcode: $scope.wjpCode, wohId: $rootScope.currentWoh, wojId: $rootScope.currentWoJ }
        }).success(function () {
            feedbackPopup('Successefully added new Part', { level: 'success', timeout: 2000 });
        });
    }

    $scope.GetWJPList = function () {
        $http({
            method: 'GET',
            url: "http://localhost:57661/api/workorder/GetWJPList",
            params: { wohId: $rootScope.currentWoh, wojId: $rootScope.currentWoJ }
        })
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


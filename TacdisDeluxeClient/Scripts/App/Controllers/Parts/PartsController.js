'use strict';



tacdisDeluxeApp.controller("PartsController", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {
    $scope.showez = false;

    $http({
        method: 'GET',
        url: 'http://localhost:57661/api/Part/'
    }).then(function successCallback(response) {
        //$scope.parts = response.data;
        var d = response.data;

        $scope.tblParts = new ngTableParams({},
        {
            dataset: d
        });
    },
    function errorCallback(response) {
        if (console) {
            console.log(response);
        }
    });
}],

function ($scope, $http) {
    
    $scope.showezMoi = function () {
        $http({
            method: 'GET',
            url: 'http://localhost:57661/api/Part/Kalle?id=1234444'
        }).then(function successCallback(response) {
            console.log(response);
            $scope.showez = true;
        }, function errorCallback(response) {
            console.log(response);
        });
    };

    $scope.postez = function () {
        $http.post('http://localhost:57661/api/Part/Kaka', 
            {
                'name': 'Kalle',
                'email': 'kalle.henriksson@gmail.com'
            },
            {
                'headers': {
                    'Content-Type': 'application/json; charset=UTF-8'
                }
            }
            ).success(function (data) {
        });
    };
});



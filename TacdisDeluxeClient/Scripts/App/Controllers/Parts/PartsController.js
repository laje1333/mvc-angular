'use strict';



tacdisDeluxeApp.controller("PartsController", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {
    $scope.showez = false;

    angular.element(document).ready(function () {
        $('#modalEditPart').on('shown.bs.modal', function () {
            $(this).find('input:visible:first').focus();
        });
    });

    $http({
        method: 'GET',
        url: 'http://localhost:57661/api/Part/'
    }).then(function successCallback(response) {
        var d = response.data;

        $scope.tblParts = new ngTableParams({},
        {
            dataset: d
        });
    }, function errorCallback(response) {
        if (console) {
            console.log(response);
        }
    });

    $scope.savePart = function () {
        var data = {
            ItemId: $scope.ItemId,
            ItemName: $scope.ItemName,
            ItemPrice: $scope.ItemPrice,
            VAT: $scope.VAT,
            SpecFsg: $scope.SpecFsg
        };

        var config = {
            //headers: {
            //    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            //}
        };

        $http.post('http://localhost:57661/api/Part/', data, config)
            .success(function (data, status, headers, config) {
                $scope.PostDataResponse = data;
                feedbackPopup('Part saved.');
                $('#modalEditPart').modal('hide');
            })
            .error(function (data, status, header, config) {
                //feedbackMessage('Failed to save part.', { level: 'warning' });
                $scope.ResponseDetails = "Data: " + data +
                    "<hr />status: " + status +
                    "<hr />headers: " + header +
                    "<hr />config: " + config;
        });
    };
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



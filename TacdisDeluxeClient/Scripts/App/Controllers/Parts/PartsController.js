'use strict';

var p = null;

tacdisDeluxeApp.controller("PartsController", ["$scope", "NgTableParams", "$http", function ($scope, ngTableParams, $http) {
    $scope.showez = false;
    $scope.reverseSort = false;

    angular.element(document).ready(function () {
        getPartsList();

        $('#modalEditPart').on('shown.bs.modal', function () {
            $(this).find('input:visible:first').focus();
        });
    });


    //$scope.tableParamsTwo = getNgTableParams('name', 'desc', 'name', $scope.myDataTwo);

    //function getNgTableParams(sortingField, sortingOrder, groupByField, tableDatas) {
    //    return new ngTableParams({
    //        sorting: {
    //            sortingField: sortingOrder
    //        }
    //    }, {
    //        groupBy: groupByField,
    //        getData: function ($defer, params) {
    //            var orderedData = $filter('orderBy')(tableDatas, params.orderBy());
    //            $defer.resolve(orderedData);
    //        }
    //    });
    //}

    var getPartsList = function () {
        $http({
            method: 'GET',
            url: 'http://localhost:57661/api/Part/'
        }).then(function successCallback(response) {
            var d = response.data;

            $scope.tblParts = new ngTableParams({},
            {
                dataset: d
            });
            p = $scope.tblParts;

        }, function errorCallback(response) {
            if (console) {
                console.log(response);
            }
        });
    };


    $scope.searchParts = function(s){
        var searchButton = $('#searchButton');
        var searchText = searchButton.prev();
        //searchText.animate({ width: 'toggle' }, 150).focus();
        var animating = false;
        searchText.show();
        searchText.animate({ width: 200 }, { duration: 150, queue: 'daShit' }).focus();
        searchText.blur(function () {
                $(this).dequeue('daShit').animate({ width: 0 }, 150, 'linear', function () {
                    $(this).hide();
                });
            });
            //.show()
            //.focus()
            //.blur(function () {
            //    $(this).hide();
            //});
    }

    $scope.deletePart = function (item) {
        console.log(item);
        $scope.tblParts.push(item)
        $scope.tblParts.reload();
        return;



        if (!confirm("This will delete the current item.")) {
            return;
        }

        var id = item.Id;

        var data = { id : id };

        var config = {};

        $http.delete('http://localhost:57661/api/Part/' + id, {params: { id: id }})
            .success(function (data, status, headers, config) {
                feedbackPopup('Part deleted.');
                //array.splice(index, 1)
                //dina table params.reload()

                $('#modalEditPart').modal('hide');
            })
            .error(function (data, status, header, config) {
                $scope.ResponseDetails = "Data: " + data +
                    "<hr />status: " + status +
                    "<hr />headers: " + header +
                    "<hr />config: " + config;
                if (console) {
                    console.log($scope.ResponseDetails);
                }
            });
    };

    $scope.savePart = function () {
        var data = {
            ItemId: $scope.ItemId,
            ItemName: $scope.ItemName,
            ItemPrice: $scope.ItemPrice,
            VAT: $scope.VAT,
            SpecFsg: $scope.SpecFsg
        };

        var config = {};

        $http.post('http://localhost:57661/api/Part/', data, config)
            .success(function (data, status, headers, config) {
                $scope.PostDataResponse = data;
                feedbackPopup('Part saved.');
                $('#modalEditPart').modal('hide');
                getPartsList();
            })
            .error(function (data, status, header, config) {
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



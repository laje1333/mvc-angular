var StuffController = function ($scope) {
    $scope.models = {
        helloAngular: 'I work!'
    };
    $scope.navbarProperties = {
        isCollapsed: true
    };
}

StuffController.$inject = ['$scope'];

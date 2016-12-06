var RegisterController = function ($scope) {
    $scope.registerForm = {
        emailAddress: '',
        password: '',
        confirmPassword: ''
    };

    $scope.register = function () {
        var result = RegistrationFactory($scope.registerForm.emailAddress, $scope.registerForm.password, $scope.registerForm.confirmPassword);
        result.then(function (result) {
            if (result.success) {
                $location.path('/routeThree');
            } else {
                $scope.registerForm.registrationFailure = true;
            }
        });
    }
}

RegisterController.$inject = ['$scope', '$location', 'RegistrationFactory'];
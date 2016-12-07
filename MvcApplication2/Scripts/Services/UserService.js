
spoonbendrApp.factory('userService', function ($http) {
    return {
        getAllUsers: function () {
            // https://jsonplaceholder.typicode.com/users
            // return $http.get('https://jsonplaceholder.typicode.com/users');
            // return $http.get('http://spoonbendr.com/lab/visitors');
            return $http.get('http://localhost:8000/users.json');
        }
    };
});

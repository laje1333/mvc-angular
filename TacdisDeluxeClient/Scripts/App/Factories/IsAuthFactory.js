tacdisDeluxeApp.factory('IsAuthFactory', function () {

    var data = {
        Auth: {}
    };

    return {
        getAuth: function () {
            return data.Auth;
        },
        setAuth: function (Auth) {
            data.IsAuth = Auth;
        }
    };
});
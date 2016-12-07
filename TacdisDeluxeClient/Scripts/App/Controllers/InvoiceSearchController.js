invoices = [
    {
        "Name": "Alfreds Futterkiste",
        "Country": "Germany"
    },
    {
        "Name": "Berglunds snabbköp",
        "Country": "Sweden"
    },
    {
        "Name": "Centro comercial Moctezuma",
        "Country": "Mexico"
    },
    {
        "Name": "Ernst Handel",
        "Country": "Austria"
    }
];


app.controller("myCtrl", function ($scope) {
    $scope.myFunc = function () {
        $scope.records = invoices;
    };

});
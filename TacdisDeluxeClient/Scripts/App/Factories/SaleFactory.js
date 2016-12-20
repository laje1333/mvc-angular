tacdisDeluxeApp.factory('SaleFactory', function () {

    var data = {
        salesman: {}
    };

    return {
        getSalesman: function () {
            return data.salesman;
        },
        setSalesman: function (salesman) {
            data.salesman = salesman;
        }
    };
});
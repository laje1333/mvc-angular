tacdisDeluxeApp.factory('SaleFactory', function () {

    var data = {
        salesman: {},
        payer: {}
    };

    return {
        getPayer: function (){
            return data.payer;
        },

        setPayer: function (payer) {
            data.payer = payer;
        },

        getSalesman: function () {
            return data.salesman;
        },
        setSalesman: function (salesman) {
            data.salesman = salesman;
        }
    };
});
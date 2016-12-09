tacdisDeluxeApp.directive('panelheader', function() {
    return {
        restrict: 'AE',
        template: '<div class="panel-heading">{{title}}</div>',

        scope:{
            title: '@title'
        },
        replace: true,
        link: function (scope, element, attrs) {
                $(element).click(function () {
                    $(element).next().slideToggle("fast");
                });
            
            
        }
    };
})


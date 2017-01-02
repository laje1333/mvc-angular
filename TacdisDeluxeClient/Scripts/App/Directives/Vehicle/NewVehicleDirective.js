tacdisDeluxeApp.directive('panelheader', function() {
    return {
        restrict: 'AE',
        template: '<div class="panel-heading">{{title}}</div>',

        scope:{
            title: '@title'
        },
        replace: true,
        link: function (scope, element, attrs) {
            
        }
    };
})

tacdisDeluxeApp.directive('panelheaderwithclick', function () {
    return {
        restrict: 'AE',
        template: '<div class="panel-heading">{{title}}</div>',

        scope: {
            title: '@title'
        },
        replace: true,
        link: function (scope, element, attrs) {
            $(element).click(function () {
                $(element).next().slideToggle();
            });

        }
    };
})

tacdisDeluxeApp.directive("tframe", function () {



    var controller = ['$scope', function ($scope) {

        $scope.generateFrameId = function () {
            var text = "";
            var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            for (var i = 0; i < 10; i++)
                text += possible.charAt(Math.floor(Math.random() * possible.length));

            return text;
        }

        window.onload = addListeners();
        var offX;
        var offY;



        function addListeners() {
            $scope.frameId = $scope.generateFrameId();
            $scope.frameBodyId = $scope.generateFrameId();
            document.getElementById("frame").id = $scope.frameId;
            document.getElementById("framebody").id = $scope.frameBodyId;

            frameTracker.push($scope.frameId);
            selectedFrame = $scope.frameId;

            document.getElementById($scope.frameId).addEventListener('mousedown', mouseDown, false);
            window.addEventListener('mouseup', mouseUp, false);
            
        }

        function mouseUp() {
            window.removeEventListener('mousemove', divMove, true);
        }

        function mouseDown(e) {
            if ($scope.frameIsMinimized == false) {
                var div = document.getElementById($scope.frameId);

                offY = e.clientY - parseInt(div.offsetTop);
                offX = e.clientX - parseInt(div.offsetLeft);
                window.addEventListener('mousemove', divMove, true);
            }
        }

        function divMove(e) {
            if ($scope.frameIsMinimized == false) {
                var div = document.getElementById($scope.frameId);
                div.style.position = 'absolute';
                div.style.top = (e.clientY - offY) + 'px';
                div.style.left = (e.clientX - offX) + 'px';
            }
        }






        $scope.frameIsVisible = true;
        $scope.frameIsMinimized = false;

        $scope.exitRequest = function () {
            $scope.frameIsVisible = false;
        }


        $scope.fullScreen = function () {
            var index = minimizedSlots.indexOf($scope.frameId);

            if (index > -1) {
                minimizedSlots.splice(index, 1);
            }

            document.getElementById($scope.frameId).style.position = "relative";
            document.getElementById($scope.frameId).style.width = "1138px";
            document.getElementById($scope.frameId).style.height = "auto";
            document.getElementById($scope.frameId).style.top = "auto";
            document.getElementById($scope.frameId).style.left = "auto";
            $scope.showFrame();
            $scope.frameIsMinimized = false;
            
        }

        $scope.minimize = function () {
            if ($scope.frameIsMinimized == false) {
                var widthOffset = 365;

                for (i = 0; i < minimizedSlots.length; i++) {
                    widthOffset += document.getElementById(minimizedSlots[i]).offsetWidth;
                }


                document.getElementById($scope.frameId).style.position = "fixed";
                document.getElementById($scope.frameId).style.width = "auto";
                document.getElementById($scope.frameId).style.top = "908px";
                document.getElementById($scope.frameId).style.left = widthOffset + "px";

                $scope.frameIsMinimized = true;
                $scope.hideFrame();


                minimizedSlots.push($scope.frameId);
            }
        }

        $scope.hideFrame = function () {
            $(document.getElementById($scope.frameBodyId)).slideUp(1);
        }

        $scope.showFrame = function () {
            $(document.getElementById($scope.frameBodyId)).slideDown();
        }

    }];



    return {
        restrict: 'AE',
        templateUrl: "/AngularTemplates/shared/TFrame.html",
        replace: true,
        transclude: true,
        scope: {
            title: '@title'
        },
        controller: controller
    };
})


var minimizedSlots = [];
var frameTracker = [];
var selectedFrame = "";



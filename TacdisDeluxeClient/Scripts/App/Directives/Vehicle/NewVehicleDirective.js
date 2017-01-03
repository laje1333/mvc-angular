﻿tacdisDeluxeApp.directive('panelheader', function() {
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

        var p;

        function addListeners() {
            $scope.frameId = $scope.generateFrameId();
            $scope.frameBodyId = $scope.generateFrameId();
            $scope.frameHeaderId = $scope.generateFrameId();
            $scope.resizeId = $scope.generateFrameId();
            document.getElementById("frame").id = $scope.frameId;
            document.getElementById("framebody").id = $scope.frameBodyId;
            document.getElementById("frameheader").id = $scope.frameHeaderId;
            document.getElementById("resize").id = $scope.resizeId;
            frameTracker.push($scope.frameId);
            selectedFrame = $scope.frameId;

            document.getElementById($scope.frameHeaderId).addEventListener('mousedown', mouseDown, false);
            window.addEventListener('mouseup', mouseUp, false);
            
            var resizer = document.getElementById($scope.resizeId);
            resizer.addEventListener('mousedown', initDrag, false);
            resizer.style.width = document.getElementById($scope.frameId).offsetWidth + "px";
            document.getElementById($scope.resizeId).style.left = tempX + "px";
            document.getElementById($scope.resizeId).style.top = (tempY + document.getElementById($scope.frameBodyId).offsetHeight + 50) + "px";
            p = document.getElementById($scope.frameId);
        }

        



        function mouseUp() {
            window.removeEventListener('mousemove', divMove, true);
            var div = document.getElementById($scope.frameId);
            if (div.offsetLeft < 0) {
                div.style.left = "1px";
            }
            if (div.offsetTop < 0) {
                div.style.top = "auto";
            }
            
        }

        function mouseDown(e) {
            selectedFrame = $scope.frameId;
            if ($scope.frameIsMinimized == false) {
                var div = document.getElementById($scope.frameId);
                var header = document.getElementById($scope.frameHeaderId);
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
                tempX = (e.clientX - offX);
                tempY = (e.clientY - offY);
            }
        }

        var tempX, tempY;
        var startX, startY, startWidth, startHeight;
        function initDrag(e) {
            startX = e.clientX;
            startY = e.clientY;
            startWidth = parseInt(document.defaultView.getComputedStyle(p).width, 10);
            startHeight = parseInt(document.defaultView.getComputedStyle(p).height, 10);
            document.documentElement.addEventListener('mousemove', doDrag, false);
            document.documentElement.addEventListener('mouseup', stopDrag, false);
        }

        function doDrag(e) {

            p.style.width = (startWidth + e.clientX - startX) + 'px';
            p.style.height = (startHeight + e.clientY - startY) + 'px';
            document.getElementById($scope.frameBodyId).style.width = (document.getElementById($scope.frameId).offsetWidth-50) + "px";
            document.getElementById($scope.frameBodyId).style.height = (document.getElementById($scope.frameId).offsetHeight - 50) + "px";
            document.getElementById($scope.resizeId).style.width = document.getElementById($scope.frameId).offsetWidth + "px";
            document.getElementById($scope.resizeId).style.left = tempX + "px";
            document.getElementById($scope.resizeId).style.top = (tempY + document.getElementById($scope.frameBodyId).offsetHeight + 50) + "px";
        }

        function stopDrag(e) {
            document.documentElement.removeEventListener('mousemove', doDrag, false); document.documentElement.removeEventListener('mouseup', stopDrag, false);
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
                var widthOffset = 300;

                for (i = 0; i < minimizedSlots.length; i++) {
                    widthOffset += document.getElementById(minimizedSlots[i]).offsetWidth;
                }


                document.getElementById($scope.frameId).style.position = "fixed";
                document.getElementById($scope.frameId).style.width = "auto";
                document.getElementById($scope.frameId).style.top = (document.getElementById("appcontainer").clientHeight - 75) + "px";
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



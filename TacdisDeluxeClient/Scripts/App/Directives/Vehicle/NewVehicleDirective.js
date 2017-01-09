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

        var tframe, tbody, theader, southResize, southEastResize, eastResize;
        var fullScreenSize = "1150px";
        var offX;
        var offY;
        var tempX, tempY;
        var startX, startY, startWidth, startHeight;
        var srcId;

        $scope.frameIsVisible = true;
        $scope.frameIsMinimized = false;

        $scope.generateFrameId = function () {
            var text = "";
            var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            for (var i = 0; i < 10; i++)
                text += possible.charAt(Math.floor(Math.random() * possible.length));
            return text;
        }

        $scope.initializeElements = function () {
            $scope.frameId = $scope.generateFrameId();
            $scope.frameBodyId = $scope.generateFrameId();
            $scope.frameHeaderId = $scope.generateFrameId();
            $scope.resizeId = $scope.generateFrameId();
            $scope.rightResizeId = $scope.generateFrameId();
            $scope.cornerResizeId = $scope.generateFrameId();

            tframe = document.getElementById("frame");
            tframe.id = $scope.frameId;
            tbody = document.getElementById("framebody");
            tbody.id = $scope.frameBodyId;
            theader = document.getElementById("frameheader");
            theader.id = $scope.frameHeaderId;
            southResize = document.getElementById("resize");
            southResize.id = $scope.resizeId;
            eastResize = document.getElementById("right-resize");
            eastResize.id = $scope.rightResizeId;
            southEastResize = document.getElementById("corner-resize");
            southEastResize.id = $scope.cornerResizeId;
            selectedFrame = tframe;
            currentFrames.push(tframe);
            
        }

        window.onload = addListeners();

        function addListeners() {
            $scope.initializeElements();
            theader.addEventListener('mousedown', mouseDown, false);
            window.addEventListener('mouseup', mouseUp, false);
            southEastResize = document.getElementById($scope.cornerResizeId);
            eastResize.addEventListener('mousedown', initDrag, false);
            southResize.addEventListener('mousedown', initDrag, false);
            southEastResize.addEventListener('mousedown', initDrag, false);
            eastResize.style.height = tframe.offsetHeight + "px";
            southResize.style.width = tframe.offsetWidth + "px";
       
            
            southResize.style.left = tframe.style.position.left + "px";
            southResize.style.top = (tframe.offsetHeight + tframe.offsetTop) + "px";
            southResize.style.width = tframe.offsetWidth + "px";
            eastResize.style.left = (tframe.style.position.left + tframe.offsetWidth) + "px";
            eastResize.style.top = "60px";
            eastResize.style.height = tframe.offsetHeight + "px"

        }



        function mouseUp() {
            window.removeEventListener('mousemove', divMove, true);
            var div = tframe;
            if (div.offsetLeft < 0) {
                div.style.left = "1px";
                southResize.style.left = 1 + "px";
                eastResize.style.left = (1 + 50 + tbody.offsetWidth + "px");
                southEastResize.style.left = (1 + 50 + tbody.offsetWidth + "px");
            }
            if (div.offsetTop < 0) {
                div.style.top = "auto";
                southResize.style.top = (tbody.offsetHeight + 65 + tbody.offsetTop) + "px";
                eastResize.style.top = (tbody.offsetTop + 60) + "px";
                southEastResize.style.top = (tbody.offsetHeight + tbody.offsetTop + 65) + "px";
            }
            
        }

        function mouseDown(e) {
            selectedFrame = tframe;
            if ($scope.frameIsMinimized == false) {
                var header = theader;
                offY = e.clientY - parseInt(tframe.offsetTop);
                offX = e.clientX - parseInt(tframe.offsetLeft);
                    window.addEventListener('mousemove', divMove, true);
            }
        }

        

        function divMove(e) {
            if ($scope.frameIsMinimized == false) {
                tframe.style.position = 'absolute';
                tframe.style.top = (e.clientY - offY) + 'px';
                tframe.style.left = (e.clientX - offX) + 'px';
                tempX = (e.clientX - offX);
                tempY = (e.clientY - offY);
                southResize.style.width = tframe.offsetWidth + "px";
                eastResize.style.height = (tframe.offsetHeight - 42) + "px";
                eastResize.style.left = (tempX + 50 + tbody.offsetWidth) + "px";
                eastResize.style.top = (tempY + 42) + "px";
                southResize.style.left = tempX + "px";
                southResize.style.top = (tempY + tbody.offsetHeight + 50) + "px";
                southEastResize.style.top = (tempY + tbody.offsetHeight + 50) + "px";
                southEastResize.style.left = (tempX + tbody.offsetWidth + 50) + "px";
            }
        }

        function initDrag(e) {
            srcId = e.currentTarget.id;
            startX = e.clientX;
            startY = e.clientY;
            startWidth = parseInt(document.defaultView.getComputedStyle(tframe).width, 10);
            startHeight = parseInt(document.defaultView.getComputedStyle(tframe).height, 10);
            document.documentElement.addEventListener('mousemove', doDrag, false);
            document.documentElement.addEventListener('mouseup', stopDrag, false);
        }

        function doDrag(e) {
            if (srcId == $scope.resizeId) {
                tframe.style.height = (startHeight + e.clientY - startY) + 'px';
            } else if (srcId == $scope.rightResizeId) {
                tframe.style.width = (startWidth + e.clientX - startX) + 'px';
            } else if (srcId == $scope.cornerResizeId) {
                tframe.style.width = (startWidth + e.clientX - startX) + 'px';
                tframe.style.height = (startHeight + e.clientY - startY) + 'px';
            }
            

            tbody.style.width = (tframe.offsetWidth - 50) + "px";
            tbody.style.height = (tframe.offsetHeight - 50) + "px";
            southResize.style.width = tframe.offsetWidth + "px";
            eastResize.style.height = (tframe.offsetHeight - 42) + "px";
            eastResize.style.left = (tempX + 50 + tbody.offsetWidth) + "px";
            eastResize.style.top = (tempY + 42) + "px";
            southResize.style.left = tempX + "px";
            southResize.style.top = (tempY + tbody.offsetHeight + 50) + "px";
            southEastResize.style.top = (tempY + tbody.offsetHeight + 50) + "px";
            southEastResize.style.left = (tempX + tbody.offsetWidth + 50) + "px";
        }

        function stopDrag(e) {
            document.documentElement.removeEventListener('mousemove', doDrag, false); document.documentElement.removeEventListener('mouseup', stopDrag, false);
        }

        $scope.exitRequest = function () {
            $scope.frameIsVisible = false;
        }


        $scope.fullScreen = function () {
            var index = minimizedSlots.indexOf($scope.frameId);

            if (index > -1) {
                minimizedSlots.splice(index, 1);
            }

            tframe.style.position = "relative";
            tframe.style.width = fullScreenSize;
            tframe.style.height = "auto";
            tframe.style.top = "auto";
            tframe.style.left = "auto";
            $scope.showFrame();
            $scope.frameIsMinimized = false;
            
        }

        $scope.minimize = function () {
            if ($scope.frameIsMinimized == false) {
                var widthOffset = 300;

                for (i = 0; i < minimizedSlots.length; i++) {
                    widthOffset += document.getElementById(minimizedSlots[i]).offsetWidth;
                }


                tframe.style.position = "fixed";
                tframe.style.width = "auto";
                tframe.style.height = "auto";
                tframe.style.top = (document.getElementById("appcontainer").clientHeight - 75) + "px";
                tframe.style.left = widthOffset + "px";

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
var selectedFrame = "";
var currentFrames = [];





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

        var tframe, tbody, theader, southResize, southEastResize, eastResize;
        var fullScreenSize = "auto";
        var offX;
        var offY;
        var tempX, tempY;
        var startX, startY, startWidth, startHeight;
        var srcId;
        var tframeContentHolderId;

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
            tframeContentHolderId = $scope.generateFrameId();
            document.getElementById("tframecontentholder").id = tframeContentHolderId;
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
            theader.addEventListener('mouseup', mouseUp, false);
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

            mouseDown({ clientY: 650, clientX: 600 });
            divMove({ clientY: 651, clientX: 600 });
            mouseUp();
            initDrag({ clientY: 651, clientX: 600, currentTarget: { id: $scope.resizeId } });
            doDrag({ clientY: 651, clientX: 600 });
            stopDrag();
            
            tbody.style.height = "600px";
            tbody.style.width = "1200px";
            tframe.style.height = "650px";
            refreshComponents();
        }

        function clearSelection() {
            if (document.selection) {
                document.selection.empty();
            } else if (window.getSelection) {
                window.getSelection().removeAllRanges();
            }
        }

        function refreshComponents() {
            tbody.style.width = (tframe.offsetWidth - 2) + "px";
            tbody.style.height = (tframe.offsetHeight - 50) + "px";
            southResize.style.width = tframe.offsetWidth + "px";
            eastResize.style.height = (tframe.offsetHeight - 42) + "px";
            eastResize.style.left = (tframe.offsetLeft + 2 + tbody.offsetWidth) + "px";
            eastResize.style.top = (tframe.offsetTop + 42) + "px";
            southResize.style.left = tframe.offsetLeft + "px";
            southResize.style.top = (tframe.offsetTop + tbody.offsetHeight + 50) + "px";
            southEastResize.style.top = (tframe.offsetTop + tbody.offsetHeight + 50) + "px";
            southEastResize.style.left = (tframe.offsetLeft + tbody.offsetWidth + 2) + "px";
        }



        function mouseUp() {
                window.removeEventListener('mousemove', divMove, true);
                var div = tframe;
                if (div.offsetLeft < 0) {
                    div.style.left = "1px";
                    southResize.style.left = 1 + "px";
                    eastResize.style.left = (1 + tbody.offsetWidth + "px");
                    southEastResize.style.left = (1 + tbody.offsetWidth + "px");
                }
                if (div.offsetTop < 0) {
                    div.style.top = "auto";
                    southResize.style.top = (tbody.offsetHeight + 55 + tbody.offsetTop) + "px";
                    eastResize.style.top = (tbody.offsetTop + 55) + "px";
                    southEastResize.style.top = (tbody.offsetHeight + tbody.offsetTop + 55) + "px";
                }
                if (parentTframe != null && parentTframe != "") {
                    if (div.offsetLeft + div.offsetWidth > document.getElementById(parentTframe).offsetWidth) {
                        div.style.left = (document.getElementById(parentTframe).offsetWidth - div.offsetWidth-2) + "px";
                    }
                    if (div.offsetTop + div.offsetHeight > document.getElementById(parentTframe).offsetHeight) {
                        div.style.top = (document.getElementById(parentTframe).offsetHeight - div.offsetHeight+38) + "px";
                    }
                }
        }


        function mouseDown(e) {
            selectedFrame = tframe;
            parentTframe = document.getElementById(tframeContentHolderId).parentElement.id;
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
                eastResize.style.height = (tframe.offsetHeight - theader.offsetHeight) + "px";
                eastResize.style.left = (tempX + tframe.offsetWidth) + "px";
                eastResize.style.top = (tempY + theader.offsetHeight) + "px";
                southResize.style.left = tempX + "px";
                southResize.style.top = (tempY + tframe.offsetHeight) + "px";
                southEastResize.style.top = (tempY + tframe.offsetHeight) + "px";
                southEastResize.style.left = (tempX + tframe.offsetWidth) + "px";
                
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
            tframe.className += " noselect";
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
            

            tbody.style.width = (tframe.offsetWidth-2) + "px";
            tbody.style.height = (tframe.offsetHeight - theader.offsetHeight) + "px";
            southResize.style.width = tframe.offsetWidth + "px";
            eastResize.style.height = (tframe.offsetHeight - theader.offsetHeight) + "px";
            eastResize.style.left = (tempX + 2 + tbody.offsetWidth) + "px";
            eastResize.style.top = (tempY + theader.offsetHeight) + "px";
            southResize.style.left = tempX + "px";
            southResize.style.top = (tempY + tframe.offsetHeight) + "px";
            southEastResize.style.top = (tempY + tframe.offsetHeight) + "px";
            southEastResize.style.left = (tempX + tframe.offsetWidth + 2) + "px";
        }

        function stopDrag(e) {
            document.documentElement.removeEventListener('mousemove', doDrag, false); document.documentElement.removeEventListener('mouseup', stopDrag, false);
            tframe.className = tframe.className.replace(new RegExp('(?:^|\\s)' + 'noselect' + '(?:\\s|$)'), 'frame-select');
            clearSelection();
        }

        $scope.exitRequest = function () {
            $scope.frameIsVisible = false;
        }


        $scope.fullScreen = function () {
            var index = minimizedSlots.indexOf($scope.frameId);

            if (index > -1) {
                minimizedSlots.splice(index, 1);
            }
            tframe.style.minHeight = "150px";
            tframe.style.position = "relative";
            tframe.style.width = fullScreenSize;
            tframe.style.height = "auto";
            tframe.style.top = "auto";
            tframe.style.left = "auto";
            $scope.showFrame();
            $scope.frameIsMinimized = false;
            southResize.style.top = tframe.style.height;
            southResize.style.left = tframe.offsetLeft + "px";
            southResize.style.width = tframe.offsetWidth + "px";
            eastResize.style.top = (tframe.offsetTop + theader.offsetHeight) + "px";
            eastResize.style.left = (tframe.offsetLeft + tframe.offsetWidth) + "px";
            southEastResize.style.top = (tframe.style.height);
            southEastResize.style.left = (tframe.offsetLeft + tframe.offsetWidth) + "px";
            tbody.style.width = (tframe.offsetWidth - 2) + "px";
            tbody.style.height = (tframe.offsetHeight - 50) + "px";
            
        }

        $scope.minimize = function () {
            if ($scope.frameIsMinimized == false) {
                var widthOffset = 300;
                for (i = 0; i < minimizedSlots.length; i++) {
                    widthOffset += document.getElementById(minimizedSlots[i]).offsetWidth;
                }
                tframe.style.minHeight = "0px";
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
            title: '@title',

        },
        controller: controller
    };
})


var minimizedSlots = [];
var selectedFrame = "";
var currentFrames = [];
var parentTframe = null;




tacdisDeluxeApp.controller("chatcontroller", function ($scope, $http) {
    
    var chatContainer;



    $scope.initialize = function(){
        chatContainer = new Element("div", document.getElementById("chatcontainer"));
    }


    $scope.appendChatElement = function(from, text) {
        var dateObject = new Date();
        var elementRow = new Element("div", chatContainer);
        elementRow.addStyle("width: 100%;");


        var panelContainer = new Element("div", elementRow);
        if (from == "self") {
            panelContainer.addClass("panel panel-info");
        } else {
            panelContainer.addClass("panel panel-default");
        }

        var panelHeader = new Element("div", panelContainer);
        panelHeader.addClass("panel-heading");
        panelHeader.addStyle("text-align: right; padding-top: 2px; padding-right: 2px; padding-bottom: 2px; font-size: 10px");
        panelHeader.setText(dateObject.getHours() + ":" + dateObject.getMinutes());

        var contentRow = new Element("div", panelContainer);
        contentRow.addClass("panel-body-nopadding");

        var chatElement = new Element("h5", contentRow);
        chatElement.addStyle("margin-left: 4px; margin-right: 4px; word-wrap: break-word;");
        chatElement.setText(text);


        if (from == "self") {
            panelContainer.addStyle("float:right; max-width: 70%; margin-right: 6px; margin-bottom: 10px");


        } else {
            panelContainer.addStyle("float:left; max-width: 70%; margin-left: 6px; margin-bottom: 10px");
        }


        elementRow.addStyle("clear: both");

    }
});
/*
    --------------------Asynchronous action events--------------------

    Action syntax:
    @params
        - Object = Any object to attach the action to.
        - new ActionEvent... = Name of the action and what should happen upon invoke.

    addActionEvent(Object, new ActionEvent("ActionName", function () {
        
        #Code to be executed upon action goes here#

    }));


----------------------------------------------------------------------------------------------------------------
    To call an action with the name Y, on a single object X, use:
        -X.InvokeAction("Y");

    To call all objects with a specific action name Y, use:
        -InvokeActionBroadcast("Y");

----------------------------------------------------------------------------------------------------------------
    Example:

        var testObject = function(){
            this.amount = 100;

            this.increaseAmount = function(x){
                this.amount += x;
            }
        }

        addActionEvent(testObject, new ActionEvent("IncreaseAmount", function () {
        
            testObject.increaseAmount(200);

        }));

        InvokeActionBroadcast("IncreaseAmount");        // testObject.amount is now increased by 200.
*/


function ActionEvent(triggerMessage, action) {
    this.Trigger = triggerMessage;
    this.Action = action;

}
ActionEvent.InvokableObjects = {};

function addActionEvent(object, actionevent) {
    if (object["Actions"] == undefined) {
        object.Actions = {};
        object.InvokeAction = function (trigger) {
            if (object.Actions[trigger] != undefined) {
                object.Actions[trigger]();
            }
        }
    }
    if (actionevent instanceof ActionEvent) {
        object.Actions[actionevent.Trigger] = actionevent.Action;
        if (ActionEvent.InvokableObjects[actionevent.Trigger] == undefined) {
            ActionEvent.InvokableObjects[actionevent.Trigger] = [];

        }
        ActionEvent.InvokableObjects[actionevent.Trigger].push(object);
    } else {
        return new ActionResult("No instance of action event has been passed as a parameter", (actionevent));
    }
    return new ActionResult("OK", null);
}

function InvokeActionBroadcast(trigger) {
    if (ActionEvent.InvokableObjects[trigger] != undefined) {
        var objects = ActionEvent.InvokableObjects[trigger];
        for (i = 0; i < objects.length; i++) {
            objects[i].InvokeAction(trigger);
        }
    } else {
        return new ActionResult("Trigger is undefined",("There is no action event called " + trigger));
    }
    return new ActionResult("OK", null);
}

function ActionResult(mess, caus) {
    this.message = mess;
    this.cause = caus;
}





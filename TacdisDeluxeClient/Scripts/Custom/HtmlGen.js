class Element{
    constructor(typ, par, location){
        if(location == undefined){
            location = null;
        }
        this.type = "";
        this.parent = par;
        this.ElementObject = null;
        this.setType(typ);
        this.generateHtml(par, location);
        
        
    }

    setLayout(lay){
        lay.generateLayout(this.parent);
        this.layout = lay;
    }

    addClass(className){
        var att = null;
        if(!this.ElementObject.hasAttributes("class")){
            att = document.createAttribute("class");
        }else{
            att = this.ElementObject.getAttributeNode("class");
        }
        var i = 0;
        if(arguments.length > 0){
            for(i; i < arguments.length; i++){
                att.value += arguments[i] + " ";
            }
        }
        this.ElementObject.setAttributeNode(att);
    }

    addText(txt){

        var text = document.createTextNode(txt);
        this.ElementObject.appendChild(text);

    }

    setText(txt){
        this.ElementObject.textContent = txt;
    }

    addStyle(){
        if(!this.ElementObject.hasAttributes("class")){
            var att = document.createAttribute("class");
            att.value = "";
            this.ElementObject.setAttributeNode(att);

        }
        var att = null;
        var result = !this.ElementObject.hasAttributes("style");
        if(result == false){
            att = document.createAttribute("style");
        }else{
            att = this.ElementObject.getAttributeNode("style");
        }
        
        var i = 0;
        if(arguments.length > 0){
            for(i; i < arguments.length; i++){
                att.value += arguments[i] + " ";
            }
        }
        this.ElementObject.setAttributeNode(att);
    }

    setId(id){
        this.ElementObject.id = id;
    }

    setTitle(tit){
        var att = document.createAttribute("title");
        att.value = tit;
        this.ElementObject.setAttributeNode(att);
    }

    setDisabled(disable){
        this.ElementObject.disabled = disable;
    }

    isDisabled(){
        return this.ElementObject.disabled;
    }

    getElementObject(){
        return this.ElementObject;
    }

    setType(typ){
        if(typeof typ === 'string'){
            typ = typ.toUpperCase();
            this.type = typ;
        }
    }

    addEvent(eventType, action, trigger){
        var eventId;
        if(trigger == undefined){
            eventId = Maths.Random.String(15);
        }else{
            eventId = trigger;
        }
        addActionEvent(this, new ActionEvent(eventId, action));

        var att = document.createAttribute(eventType);
        att.value = "InvokeActionBroadcast('" + eventId + "')";
        this.ElementObject.setAttributeNode(att);
    }

    addTriggerEvent(trigger, action){
        addActionEvent(this, new ActionEvent(trigger, action));
    }
    
    generateHtml(parent, location){
        this.ElementObject = document.createElement(this.type);
        if(parent == null || parent == undefined){
        }else if(!(parent instanceof Element)){
            parent.appendChild(this.ElementObject);
        }else{
            
            if(parent.getLayout() != null && location != null){
                parent.getLayout().addElement(this.ElementObject, location);
            }else{
                parent.getElementObject().appendChild(this.ElementObject);
            }
        }

    }

    getLayout(){
        return this.layout;
    }

}

class BorderLayout{

    constructor(){
        
    }

    generateLayout(container){
        this.North = new Element("div", container);
        this.North.addClass("col-md-12");
        this.North.addStyle("padding: 0px");

        this.CenterContainer = new Element("div", container);
        this.CenterContainer.addClass("flex-container");
        this.West = new Element("div", this.CenterContainer);
        this.Center = new Element("div", this.CenterContainer);
        this.East = new Element("div", this.CenterContainer);
        this.South = new Element("div", container);
        this.South.addClass("col-md-12");
        this.South.addStyle("padding: 0px");
    }

    static get North() {
        return "north";
    }

    static get South() {
        return "south";
    }

    static get Center() {
        return "center";
    }

    static get East() {
        return "east";
    }

    static get West() {
        return "west";
    }


    addElement(element, location){
        var loc = location.toLowerCase();
        
        switch(loc){
            case "north":
                this.North.getElementObject().appendChild(element);
                break;
            case "south":
                this.South.getElementObject().appendChild(element);
                break;
            case "west":
                this.West.getElementObject().appendChild(element);
                break;
            case "east":
                this.East.getElementObject().appendChild(element);
                break;
            case "center":
                this.Center.getElementObject().appendChild(element);
                break;
        }
    }

}
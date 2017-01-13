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
        lay.generateLayout(this);
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

    setInputType(typ){
        var att = document.createAttribute("type");
        att.value = typ;
        this.ElementObject.setAttributeNode(att);
    }

    setValue(val){
        var att = document.createAttribute("value");
        att.value = val;
        this.ElementObject.setAttributeNode(att);
    }

    setReadOnly(val){
        if(val){
            var att = document.createAttribute("readonly");
            this.ElementObject.setAttributeNode(att);
        }else{
            this.ElementObject.removeAttribute("readonly");
        }
        
        
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

        if(this.layout instanceof FlowLayout){
            this.location = "flow";
        }

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

class FlowLayout{

    //direction types: left, center, right, top, bottom
    //flow types: horizontal, vertical
    constructor(fl, dir){
        
        if(fl == undefined){
            this.flow = "horizontal";
        }else{
            this.flow = fl;
        }
        if(dir == undefined){
            this.direction = "left";
        }else{
            this.direction = dir;
        }
    }

    generateLayout(container){
        this.MainContainer = new Element("div", container);
        if(this.flow == "horizontal"){
            //horizontal
            if(this.direction == "left"){
                this.MainContainer.addClass("flex-container-horizontal-start");
            }else if(this.direction == "center"){
                this.MainContainer.addClass("flex-container-horizontal-center");
            }else if(this.direction == "right"){
                this.MainContainer.addClass("flex-container-horizontal-end");
            }
        }else{
            //vertical
            if(this.direction == "top"){
                this.MainContainer.addClass("flex-container-vertical");
            }else if(this.direction == "center"){

            }else if(this.direction == "bottom"){
                this.MainContainer.addClass("flex-container-vertical-reverse");
            }
        }
    }

    addElement(element, location){
        this.MainContainer.getElementObject().appendChild(element);
    }
}



class BorderLayout{

    constructor(){
        
    }

    generateLayout(container){
        this.Main = new Element("div", container);
        this.Main.addClass("flex-container-vertical");

        this.North = new Element("div", this.Main);
        this.North.addClass("flex-container-center");
        this.North.addStyle("padding: 0px; height: 33%");

        this.CenterContainer = new Element("div", this.Main);
        this.CenterContainer.addClass("flex-container");
        this.CenterContainer.addStyle("height: 33%");
        this.West = new Element("div", this.CenterContainer);
        this.Center = new Element("div", this.CenterContainer);
        this.East = new Element("div", this.CenterContainer);
        this.South = new Element("div", this.Main);
        this.South.addClass("flex-container-center");
        this.South.addStyle("padding: 0px; height: 33%");
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
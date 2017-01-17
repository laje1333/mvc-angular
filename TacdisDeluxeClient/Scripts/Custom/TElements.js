


class TVoteComponent{

    constructor(container, location){
        this.valueIncrease = 1;
        if(container == null && location == null){
            this.NorthContainer = new Element("div");
        }else{
            this.NorthContainer = new Element("div", container, location);
        }
        
        this.NorthContainer.setLayout(new FlowLayout("vertical", "top"));
        this.NorthContainer.addStyle("width: 40px");


        this.North = new Element("button", this.NorthContainer, "none");
        this.North.addClass("btn btn-primary btn-sm glyphicon glyphicon-chevron-up");
        this.North.addStyle("border-bottom-left-radius: 0px; border-bottom-right-radius: 0px;");
        this.North.addEvent("onclick", function(){
            
        }, Maths.Random.String(15));

        this.Center = new Element("input", this.NorthContainer, "none");
        this.Center.setInputType("text");
        this.Center.addStyle("text-align: center; margin-bottom: -1px; margin-top: 1px");
        this.Center.setValue(0);
        this.Center.setReadOnly(true);

        this.South = new Element("button", this.NorthContainer, "none");
        this.South.addClass("btn btn-primary btn-sm glyphicon glyphicon-chevron-down");
        this.South.addStyle("border-top-left-radius: 0px;border-top-right-radius: 0px;");
        this.South.addEvent("onclick", function(){
            
        }, Maths.Random.String(15));
    }


    getElementObject(){
        return this.NorthContainer;
    }

    setValue(x){
        this.Center.setValue(50);
    }

    

}

class TFrame{
    constructor(parent, layout){
        this.RootPane = new Element("div", parent);
        this.RootPane.addClass("panel panel-primary");

        this.Header = new Element("div", this.RootPane);
        this.Header.addClass("panel-heading");

        this.Container = new Element("div", this.RootPane);
        if(layout != null || layout != undefined){
            this.Container.setLayout(layout);
        }
        this.Container.addClass("panel-body-nopadding");
        this.Container.addStyle("padding: 0px;");


        this.Footer = new Element("div", this.RootPane);
        this.Footer.addClass("panel-footer");
        this.Footer.setLayout(new FlowLayout("horizontal", "left"));
    }

    setDimension(width, height){
        this.RootPane.addStyle("width:" + width + "px;" + "height:" + height + "px;");
        var containerHeight = height - this.Header.getElementObject().offsetHeight - this.Footer.getElementObject().offsetHeight*2-2;
        this.Container.addStyle("height:" + containerHeight + "px");
    }

    setTitle(title){
        this.Header.setText(title);
    }

    addComponentToFooter(element){
        var layout = this.Footer.getLayout();
        layout.addElement(element.getElementObject(), "none");

    }

    addComponent(element, location){
        var layout = this.Container.getLayout();
        if(layout != null){
            layout.addElement(element.getElementObject(), location);
        }else{
            this.Container.getElementObject().appendChild(element.getElementObject());
        }
    }

}
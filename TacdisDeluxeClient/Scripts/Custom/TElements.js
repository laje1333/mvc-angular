


class VoteComponent{

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

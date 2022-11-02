(function (me){

    var alertSample = {}

    alertSample.width = 300;
    alertSample.height = 150;
    alertSample.left = 250;
    alertSample.top = 250;
    alertSample.title = "Alert Sample";

    alertSample.html =
    '<center><b>Hellow World</b> <br>Alert Sample<br></center>';

    var f = new File("AlertSample.json");
    if (this.open("w")){
        try{
            this.write(alertSample.toSource());
            this.close();
            ret = true;
        }catch(e){
        }
    }


})(this);
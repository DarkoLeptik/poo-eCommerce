using System;
using System.Collections.Generic;

class Ship : Container{
    private int[] itinéraire;
    private int position;
    private bool currentAction = null;
    private int targetProduct;

    //A modifier avec le constructeur de Container
    public Ship(int[] itin, int pos, bool currentAct, int targetProd){
        itinéraire = itin;
        position = pos;
        currentAction = currentAct;
        targetProduct = targetProd;
    }
    
    public int[] Itineraire{
        get { return itinéraire;}
        set { itinéraire = value;}
    }

    public int Position{
        get { return position;}
        set { position = value;}
    }

    public bool CurrentAction{
        get { return currentAction;}
        set { currentAction = value;}
    }

    public int TargetProduct{
        get { return targetProduct;}
        set { targetProduct = value;}
    }


}
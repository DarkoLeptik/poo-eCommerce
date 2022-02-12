using System;
using System.Collections.Generic;

class Ship : Container{
    private int[] itinerary;
    private int position;
    private bool currentAction;
    private int targetProduct;

    //A modifier avec le constructeur de Container
    public Ship(int[] myMaxGoods, int[] itin, int pos, bool currentAct, int targetProd): base(myMaxGoods){
        itinerary = itin;
        position = pos;
        currentAction = currentAct;
        targetProduct = targetProd;
    }
    
    public int[] Itinerary{
        get { return itinerary;}
        set { itinerary = value;}
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

    public void updatePosition(){
        for(int i = 0; i<itinerary.Length; i++){
            if(position == itinerary[i]){
                if(i == itinerary.Length){
                    position = itinerary[0];
                }
                else{
                    position = itinerary[i+1];
                    currentAction = travelling;
                }
            }
        }
    }


}

enum shipAction{
    buyGoods,
    sellGoods,
    leave, 
    noAction,
    travelling

}
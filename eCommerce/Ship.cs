using System;
using System.Collections.Generic;

class Ship : Container{
    private int[] itinerary;
    private int position;
    private bool currentAction;
    private int targetProduct;

    private int nb_cycles;

    //A modifier avec le constructeur de Container
    public Ship(int[] myMaxGoods, int[] itin, int pos, bool currentAct, int targetProd, int nb_cycl): base(myMaxGoods){
        itinerary = itin;
        position = pos;
        currentAction = currentAct;
        targetProduct = targetProd;
        nb_cycles = nb_cycl;
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
                    updateCyclesLeft();
                }
                else{
                    position = itinerary[i+1];
                    currentAction = travelling;
                }
            }
        }
    }

    public bool updateCyclesLeft(){
        nb_cycles --;
        if(nb_cycles>0){
            return true;
        }
        else{
            return false;
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
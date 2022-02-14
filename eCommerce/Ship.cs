using System;
using System.Collections.Generic;
namespace  eCommerce;
internal enum shipAction
{
    buyGoods,
    sellGoods,
    leave, 
    noAction,
    travelling
}
internal class Ship : Container{
    private int[] itinerary;
    private int position;
    private shipAction currentAction;
    private int targetProduct;

    private int nbCycles;
    
    public Ship(int[] myMaxGoods, int[] itin, int nbCycl): base(myMaxGoods){
        itinerary = itin;
        position = itin[0];
        currentAction = shipAction.travelling;
        targetProduct = -1;
        nbCycles = nbCycl;
    }
    
    public int[] Itinerary{
        get { return itinerary;}
        private set { itinerary = value;}
    }

    public int Position{
        get { return position;}
        set { position = value;}
    }

    public shipAction CurrentAction{
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
                if(i == itinerary.Length-1){
                    position = itinerary[0];
                }
                else{
                    position = itinerary[i+1];
                    currentAction = shipAction.travelling;
                }
            }
        }
    }

    public bool updateCyclesLeft(){
        nbCycles --;
        if(nbCycles>0){
            return true;
        }
        else{
            return false;
        }
    }


}
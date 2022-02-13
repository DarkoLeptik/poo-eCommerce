using System;
using System.Collections.Generic;
 internal class Goods {
    
    private bool isDangerous;
    public Goods(bool dangerousness){
        this.isDangerous=dangerousness;
        
        
    }  
    internal int quantity2load(){
        if(isDangerous){
            return 20;
        }
        else{
            return 50;
        }

    }
    internal int quantity2unload(){
        if(isDangerous){
            return 10;
        }
        else{
            return 25;
        }

    }
}
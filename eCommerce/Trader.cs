using System;

class Trader{
    private Goods[] listOfGoods;
    public Trader(int goodsNb){
         listOfGoods=new Goods[goodsNb];

    }
    internal void Trade(Planet[] planets){
        Ship ship;
        bool a;
        foreach(Planet planet in planets){
            for(int k=0; k<planet.harbor_nb;k++){
                ship=planet.harbors[0,k];
                if(ship!=null){
                    a=true;
                    if (ship.CurrentAction==buyGoods){
                        a=ship.AddGoodsFrom(planet,ship.TargetProduct(),listOfGoods[ship.TargetProduct].quantity2load());
                        
                        
                    }
                    else if(ship.CurrentAction==sellGoods){
                        a=planet.AddGoodsFrom(ship,ship.TargetProduct(),listOfGoods[ship.TargetProduct].quantity2unload());

                    }
                    if(!a){
                        ship.CurrentAction = leave;
                    }
                }
            }
        }
    }
}


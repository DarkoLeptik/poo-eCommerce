using System;

class Trader{
    internal searchForMax(Ship ship, Planet planet){
        int shipCapacity=ship.myMaxGoods[ship.TargetProduct()]-ship.goods[ship.TargetProduct()];
        if (ship.ShipAction==buyGoods){  //vaisseau non chargé
            if(planet.myMaxGoods[ship.TargetProduct()]!=0){
                if(shipCapacity>=planet.goods[ship.TargetProduct()]){
                    return planet.goods[ship.TargetProduct()];
                }
                else{
                    return shipCapacity;
                }
            }
            else{
                return 0;
            }
        }
    
        else if(ship.ShipAction==sellGoods){ //vaisseau chargé
            if(planet.myMaxGoods[ship.TargetProduct()]!=0){
                return ship.goods[ship.TargetProduct()];

            }
            else{
                return 0;
            }

        }
    }

    static void Trade(Planet[] planets){
        Ship ship;
        foreach(Planet planet in planets){
            for(int k=0; k<planet.harbor_nb;k++){
                ship=*planet.harbors[0,k];
                if (ship.ShipAction==buyGoods){
                    ship.AddGoods(ship.TargetProduct(),searchForMax(ship,planet));
                    planet.RemoveGoods(ship.TargetProduct(),searchForMax(ship,planet));
                }
                else if(ship.ShipAction==sellGoods){
                    planet.AddGoods(ship.TargetProduct(),searchForMax(ship,planet));
                    ship.RemoveGoods(ship.TargetProduct(),searchForMax(ship,planet));

                }
            }
        }

    }
}


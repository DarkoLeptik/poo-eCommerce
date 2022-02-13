using System;

class Trader{
    private Goods[] listOfGoods;

    //constructor of class "Trader" 
    public Trader(int goodsNb){
        listOfGoods=new Goods[goodsNb];
        for (int i = 0; i < goodsNb-1; i++)
        {
            Random rd = new Random(2);
            //random affectation of the dangerousness of goods
            if(rd==0){  
                listOfGoods[i] = new Goods(false);

            }
            else{
                listOfGoods[i] = new Goods(true);
            }
            
        }
    }

    //method which permits to make the exchange between the different ship and planets
    internal void Trade(Planet[] planets){
        Ship? ship;
        bool a;
        Random rdm = new Random();
        for(int i = 0; i < planets.Length; i++){ //for each planets
            for(int k=0; k<planets[i].Harbor.Length/2;k++){ //for each principal harbours (not waiting ones)
                ship= planets[i].Harbor[0,k];  //we access the ship which is in the concerned harbour
                if(ship!=null){  //we assure that the ship actually exists
                    a=true;
                    //Depending of the action of the ship, it will exchange goods with the planets (sell or buy)
                    if (ship.CurrentAction==shipAction.buyGoods){
                        a=ship.AddGoodsFrom(planets[i],ship.TargetProduct,listOfGoods[ship.TargetProduct].quantity2load());
                    }
                    else if(ship.CurrentAction==shipAction.sellGoods){
                        a=planets[i].AddGoodsFrom(ship,ship.TargetProduct,listOfGoods[ship.TargetProduct].quantity2unload());
                    }
                    else if (ship.CurrentAction == shipAction.noAction)
                    {
                        ship.CurrentAction = (rdm.Next(2) > 0)
                            ?  shipAction.buyGoods
                            :  shipAction.sellGoods;
                        ship.TargetProduct = rdm.Next(listOfGoods.Length); // TODO: choose depending on stock
                    }
                    if(!a){
                        ship.CurrentAction = shipAction.leave;
                    }
                }
            }
        }
    }
}


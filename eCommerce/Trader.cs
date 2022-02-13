using System;

class Trader{
    private Goods[] listOfGoods;
    public Trader(int goodsNb){
        listOfGoods=new Goods[goodsNb];
        for (int i = 0; i < goodsNb-1; i++)
        {
            listOfGoods[i] = new Goods(false);
        }
        listOfGoods[goodsNb-1] = new Goods(true);
    }
    internal void Trade(Planet[] planets){
        Ship? ship;
        bool a;
        Random rdm = new Random();
        for(int i = 0; i < planets.Length; i++){
            for(int k=0; k<planets[i].Harbor.Length/2;k++){
                ship= planets[i].Harbor[0,k];
                if(ship!=null){
                    a=true;
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


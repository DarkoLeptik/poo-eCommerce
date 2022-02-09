using System;
using System.Collections.Generic;
class Container{
    protected int[] goods;
    protected int[] maxGoods;
    public Container(){
        goods=new int[3];
        maxGoods=new int[3];
        for(int k=0;k<3;k++){
            goods[k]=(k+1)*10;
            maxGoods[k]=(k+1)*100;
        }
    }
    public int[] getGoods{
        get {
            return goods;
        }
    }
    public int[] getMaxGoods{
        get {
            return maxGoods;
        }
    }
}
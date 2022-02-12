using System;
using System.Collections.Generic;
class Planet : Container
{
	// Attributes.
    
    private Ship?[,] harbors;
    private int harbor_nb;
    
	// Contructor.
    
	//limite de 5 products : Réguliers=1 à 3     ;     Dangereux: 4 et 5
    public Planet(int[] myMaxGoods,int[] mystock, int harborsNb)
        :base(myMaxGoods,mystock)
    {
        // 1ère ligne: port  ;  2ème ligne: file d'attente   ; argument : nom du vaisseau
        // Harbor initalization
        harbor_nb = harborsNb;
        harbors=new Ship[2,harbor_nb]; 
        for(int k=0;k<harbor_nb;k++){
            harbors[0,k]=null;
            harbors[1,k]=null;
        }
    }
    
    public Ship?[,] Harbor
    {    
      // Getter
      get { return harbors; }
      private set { harbors=value;}
    }  
    
    public void Land(Ship ship){
        int k=0; //compteur pour arrêter de chercher une place au port lorsqu'on en a trouvé une
        for(int j=0;((j<2)&&(k==0));j++){
            for(int i=0;((i<harbor_nb)&&(k==0));i++){
                if(Harbor[j,i]==null){
                    Harbor[j,i]=ship;
                    k++;   
                }
            }
        }

        if (k == 0)
        {
            throw new CommercialException("Ship couldn't land");
        }
    }

    public void TakeOff(Ship ship){
        for(int i=0;i<harbor_nb;i++){
            for(int j=0;j<2;j++){
                //System.Console.WriteLine("i:{0} j: {1} \n",i,j);
                if(Harbor[j,i]==ship){
                    Harbor[j,i]=null;
                }
            }
        }
    }
}

[Serializable]
internal class CommercialException : Exception
{
    internal CommercialException(string message) : base(message) {}
    internal CommercialException(string message, Exception inner) : base(message, inner) { }
}
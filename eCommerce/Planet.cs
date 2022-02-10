using System;
using System.Collections.Generic;
class Planet : Container
{
	// Attributes.
    
    private int[,] products;
    private int[,] harbors;
    private Dictionary<string, int> storage;
    private int harbor_nb=3;
    
	// Contructor.
    
	//limite de 5 products : Réguliers=1 à 3     ;     Dangereux: 4 et 5
    public Planet(int[] myMaxGoods, int harbor_nb,int stock1,int stock2,int stock3,int stock4,int stock5)
        :base(myMaxGoods)
    {
        // 1ère ligne: port  ;  2ème ligne: file d'attente   ; argument : nom du vaisseau
        // Harbor initalization
        harbors=new int[2,harbor_nb]; 
        for(int k=0;k<harbor_nb;k++){
            harbors[0,k]=-1;
            harbors[1,k]=-1;
        }
        
        // storage initialization
        storage = new Dictionary<string, int>();
        storage.Add("stock1", stock1);
        storage.Add("stock2", stock2);
        storage.Add("stock3", stock3);
        storage.Add("stock4", stock4);
        storage.Add("stock5", stock5);

		// products initialization
        products = new int[2,5]; //ligne1 : capacité_storage  ;    ligne2: products en stock
        Random rdm= new Random();
        for(int i=1;i<6;i++)
        {  
        	//on remplie les différentes capacités de storage des products et leur nombre (initialisé aléatoirement)
            products[0,i-1]=storage["stock"+i.ToString()];
            products[1,i-1]=rdm.Next(0,storage["stock"+i.ToString()]+1);  //génération aléatoire
        }
    }
    public int[,] Products
    {    
      // Getter
      get { return products; }
      set{ products=value;}
    }  
    
    public int[,] Harbor
    {    
      // Getter
      get { return harbors; }
      set{ harbors=value;}
    }  
    
    public void Land(int ship_nb){
        int k=0; //compteur pour arrêter de chercher une place au port lorsqu'on en a trouvé une
        for(int j=0;((j<2)&&(k==0));j++){
            for(int i=0;((i<harbor_nb)&&(k==0));i++){
                if(Harbor[j,i]==-1){
                    
                    Harbor[j,i]=ship_nb;
                    k++;   
                }
            }
        }
    }

    public void TakeOff(int ship_nb){
        for(int i=0;i<harbor_nb;i++){
            for(int j=0;j<2;j++){
                //System.Console.WriteLine("i:{0} j: {1} \n",i,j);
                if(Harbor[j,i]==ship_nb){
                    Harbor[j,i]=-1;
                }
            }
        }
    }
}   
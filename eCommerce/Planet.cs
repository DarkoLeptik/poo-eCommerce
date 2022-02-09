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
    public Planet(int harbor_nb,int stock1,int stock2,int stock3,int stock4,int stock5)
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
    public static void Main(string[] args)
    {
        Planet p=new Planet(3,200,100,20,40,80);
        //Planet p2=new Planet(2,300,30,10,30,60);
        p.Land(10);
        p.Land(11);
        p.Land(12);
        p.Land(13);
        p.Land(14);
        p.Land(15);
        //p2.Atterrir(1);
        //p2.Atterrir(2);
        //p2.Atterrir(1,p2)
        /*
        foreach (int elem in p.Products)
        {
        	Console.WriteLine(elem);
        }    
        */
        Console.WriteLine(p.Harbor[0,0]);
        Console.WriteLine(p.Harbor[0,1]);
        Console.WriteLine(p.Harbor[0,2]);
        Console.WriteLine(p.Harbor[1,0]);
        Console.WriteLine(p.Harbor[1,1]);
        Console.WriteLine(p.Harbor[1,2]);
        p.TakeOff(11);
        p.TakeOff(14);
        p.TakeOff(15);
        Console.WriteLine();
        Console.WriteLine(p.Harbor[0,0]);
        Console.WriteLine(p.Harbor[0,1]);
        Console.WriteLine(p.Harbor[0,2]);
        Console.WriteLine(p.Harbor[1,0]);
        Console.WriteLine(p.Harbor[1,1]);
        Console.WriteLine(p.Harbor[1,2]);



        Container c = new Container();
        Console.WriteLine();
        Console.WriteLine(c.getGoods[0]);
        Console.WriteLine(c.getMaxGoods[0]);
        Console.WriteLine(c.getGoods[1]);
        Console.WriteLine(c.getMaxGoods[1]);
        
    }
}   
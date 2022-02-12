class Universe{

    static void TestContainer()
    {
        int[] maxValues = {50, 0, 100};
        Container myContainer = new Container(maxValues);

        int spaceLeft1 = myContainer.AddGoods(0, 75);
        int spaceLeft2 = myContainer.AddGoods(2, 60);
        int goodsRemoved1 = myContainer.RemoveGoods(0, 60);
        int goodsRemoved2 = myContainer.RemoveGoods(2, 25);

        string message = $"First load: {spaceLeft1}\nSecond load: {spaceLeft2}\nFirst unload: {goodsRemoved1}\nSecond unload: {goodsRemoved2}\n\n";
        Console.Write(message);

        string historyMessage = "";
        
        foreach (var historyLine in myContainer.TransactionHistory())
        {
            historyMessage += $"Exchanged: {historyLine.Item1} from: {historyLine.Item2}, changed: {historyLine.Item3}, result: {historyLine.Item4}\n";
        }
        
        Console.Write(historyMessage);
    }

    static void TestPlanet()
    {
        int[] maxGoods = {200, 100, 20, 40, 80};
        Planet p=new Planet(maxGoods, 1);

        Ship ship1 = new Ship(maxGoods, maxGoods, 0, true, 0);
        Ship ship2 = new Ship(maxGoods, maxGoods, 0, true, 0);
        Ship ship3 = new Ship(maxGoods, maxGoods, 0, true, 0);
        try
        {
            p.Land(ship1);
            p.Land(ship2);
            p.Land(ship3);
        }
        catch (CommercialException e)
        {
            Console.WriteLine(e);
            //TODO: remove the ship from the universe
        }
        
        //foreach (int elem in p.Products)
        //{
        //	Console.WriteLine(elem);
        //}    
        /*
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
        */
    }

    static void ManageShips(Planet[] planets, Ship[] ships){
        foreach(Planet planet in planets){
            for(int i = 0; i<planet.harbor_nb; i++){
                Ship tempShip = planet.Harbor[0,i];
                if(planet.Harbor[0,i].CurrentAction == leave){   
                    planet.TakeOff(planet.Harbor[0,i]);
                    tempShip.updatePosition();
                }
            }
            planet.Advance();
        }
        foreach(Ship ship in ships){
            if(ship.CurrentAction == travelling){
                try{
                    planets[position].Land(ship);
                }
                catch(CommercialException e){
                    //TODO : Retirer vaisseau de l'univers
                }
            }
        }
    }

    static void Main(string[] args){
        Console.WriteLine("-*-*- Welcome to the eCommerce! -*-*-");
        TestContainer();
        TestPlanet();
    }
}
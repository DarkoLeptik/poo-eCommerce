enum ShipType
{
    Xwing = 0,
    Yt1300,
    StarDestroyer
}

internal class Creator
{
    private int goodsNb;
    private int planetsNb;
    private List<int[]> shipsMaxGoods;
    
    internal Creator(int goodsNb, int planetsNb, List<int[]> shipsStocks)
    {
        this.goodsNb = goodsNb;
        this.planetsNb = planetsNb;
        shipsMaxGoods = shipsStocks;
    }
    
    private int[] CreateItinerary() // tirage sans remise
    { 
        Random rdm= new Random(); 
        int[] result = new int[rdm.Next(2,planetsNb)];

        List<int> planetsAvailable = new List<int>(planetsNb);
        for (int i = 0; i < planetsNb; i++)
        {
            planetsAvailable.Add(i);
        }

        for (int j = 0; j < result.Length; j++)
        {
            int randomIndex = rdm.Next(0, planetsAvailable.Count);
            result[j] = planetsAvailable[randomIndex];
            planetsAvailable.Remove(result[j]);
        }
        
        return result;
    }

    internal Ship CreateShip(ShipType shipType) 
    {
        // creates the stockage depending on the ship type
        int[] maxGoods = shipsMaxGoods[(int) shipType];
        
        // creates the intinerary
        int[] itinerary = CreateItinerary();
        
        // choose the lifetime
        Random rdm= new Random();
        int lifetime = rdm.Next(1, 50);

        Ship newShip = new Ship(maxGoods, itinerary, lifetime);
        
        Console.WriteLine($"New ship created of type {shipType}");
        
        return newShip;
    }

    internal Planet CreatePlanet()
    {
        Random rdm= new Random();
        
        int[] maxGoods = new int[goodsNb];
        int[] goods = new int[goodsNb];
        for (int i = 0; i < goodsNb; i++)
        {
            maxGoods[i] = rdm.Next(1, 20) * 10;
            goods[i] = rdm.Next(0, maxGoods[i]+1);
        }

        int randomHarbors = rdm.Next(1,3);
        
        Planet newPlanet = new Planet(maxGoods, goods, randomHarbors);
        return newPlanet;
    }
}
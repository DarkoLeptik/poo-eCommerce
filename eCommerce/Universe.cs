
class Universe
{
    private static List<Ship> allShips;
    private static Planet[] allPlanets;
    private static Creator myCreator;
    private static Trader myTrader;
    private static int goodsNb = 3;

    private static void DisplayHistory(Container myContainer)
    {
        // Displays the history of a container, to complete
        string historyMessage = "";
        
        foreach (var historyLine in myContainer.TransactionHistory())
        {
            historyMessage += $"Exchanged: {historyLine.Item1} from: {historyLine.Item2}, changed: {historyLine.Item3}, result: {historyLine.Item4}\n";
        }
        
        Console.Write(historyMessage);
    }
    
    private static void CreateShips(int n)
    {
        Random rdm = new Random();
        for (int i = 0; i < n; i++)
        {
            allShips.Add(myCreator.CreateShip((ShipType)rdm.Next(2)));
        }
    }

    private static List<int[]> InitializeShipsCapacity()
    {
        int[] XwingCapacity = {10, 20, 0};
        int[] Yt1300Capacity = {40, 0, 10};
        int[] StarDestroyerCapacity = {10, 50, 70};

        List<int[]> shipsCapacity = new List<int[]>();
        shipsCapacity.Add(XwingCapacity);
        shipsCapacity.Add(Yt1300Capacity);
        shipsCapacity.Add(StarDestroyerCapacity);
        
        return shipsCapacity;
    }
    
    private static void InitializeSpace()
    {
        myCreator = new Creator(goodsNb,5, InitializeShipsCapacity());
        myTrader = new Trader(goodsNb);
        
        allPlanets = new Planet[5];
        for (int i = 0; i < 5; i++)
        {
            allPlanets[i] = myCreator.CreatePlanet();
        }

        allShips = new List<Ship>();
        CreateShips(4);
    }

    static void ManageShips(){
        foreach(Planet planet in allPlanets){
            for(int i = 0; i<planet.Harbor.Length/2; i++){
                Ship? tempShip = planet.Harbor[0,i];
                if ((tempShip != null) && (tempShip.CurrentAction == shipAction.leave)){   
                    planet.TakeOff(tempShip);
                    tempShip.updatePosition();
                }
            }
            planet.Advance();
        }
        Console.WriteLine(allShips);
        foreach(Ship ship in allShips.ToList()){
            // checks if it has some time left
            if (!ship.updateCyclesLeft())
            {
                allShips.Remove(ship);
            }
            
            if(ship.CurrentAction == shipAction.travelling){
                try{
                    allPlanets[ship.Position].Land(ship);
                }
                catch(CommercialException e){
                    allShips.Remove(ship);
                    Console.WriteLine(e);
                }
            }
        }
    }

    static void DisplayFullHistory()
    {
        foreach (var planet in allPlanets)
        {
            planet.DisplayGoods();
            DisplayHistory(planet);
        }
    }

    static void Main(string[] args){
        Console.WriteLine("-*-*- Welcome to the eCommerce! -*-*-");
        InitializeSpace();
        for (int i = 0; i < 3; i++)
        {
            DisplayFullHistory();
            ManageShips();
            myTrader.Trade(allPlanets);
            CreateShips(1);
            Thread.Sleep(2000);
        }
    }
}
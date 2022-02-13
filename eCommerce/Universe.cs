
class Universe
{
    private static List<Ship> allShips;
    private static Planet[] allPlanets;
    private static Creator myCreator;
    private static Trader myTrader;
    private static int goodsNb = 4;
    private static int planetsNb = 5;

    private static void DisplayHistory(Container myContainer)
    {
        // Displays the history of a container, to complete
        if (myContainer.TransactionHistory().Length > 0)
        {
            string historyMessage = "";
        
            foreach (var historyLine in myContainer.TransactionHistory())
            {
                historyMessage += $"Traded good of type {historyLine.Item1}: had {historyLine.Item2}, attempted to move {historyLine.Item3}, stock at the end {historyLine.Item4}\n";
            }
        
            Console.WriteLine(historyMessage);   
        }
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
        int[] XwingCapacity = {10, 20, 0, 10};
        int[] Yt1300Capacity = {40, 0, 10, 40};
        int[] StarDestroyerCapacity = {10, 50, 70, 30};

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
        
        allPlanets = new Planet[planetsNb];
        
        Console.WriteLine("--Planets initial state--");
        for (int i = 0; i < planetsNb; i++)
        {
            Console.WriteLine($"Planet {i}");
            allPlanets[i] = myCreator.CreatePlanet();
            allPlanets[i].DisplayGoods();
            Console.WriteLine("");
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
        foreach(Ship ship in allShips.ToList()){
            // checks if it has some time left
            if (!ship.updateCyclesLeft())
            {
                allShips.Remove(ship);
                Console.WriteLine("A ship has left the eCommerce !");
            }
            
            if(ship.CurrentAction == shipAction.travelling){
                try{
                    allPlanets[ship.Position].Land(ship);
                    ship.CurrentAction = shipAction.noAction;
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
        Console.WriteLine("--Planets history--");
        foreach (var planet in allPlanets)
        {
            DisplayHistory(planet);
        }
        Console.WriteLine("\n--Ships history--");
        foreach (var ship in allShips)
        {
            DisplayHistory(ship);
        }
    }

    static void Main(string[] args){
        Console.WriteLine("-*-*- Welcome to the eCommerce! -*-*-");
        InitializeSpace();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\n---TURN {i}---");
            DisplayFullHistory();
            ManageShips();
            myTrader.Trade(allPlanets);
            CreateShips(1);
            
            Thread.Sleep(2000);
        }
    }
}
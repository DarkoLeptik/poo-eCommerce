
class Universe
{
    private static List<Ship> allShips;
    private static Planet[] allPlanets;
    private static Creator myCreator;

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
        myCreator = new Creator(3,5, InitializeShipsCapacity());
        
        allPlanets = new Planet[5];
        for (int i = 0; i < 5; i++)
        {
            allPlanets[i] = myCreator.CreatePlanet();
        }

        allShips = new List<Ship>();
        CreateShips(4);
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
        InitializeSpace();
    }
}
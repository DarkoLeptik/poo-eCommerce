
class Universe
{
    private static List<Ship> allShips;
    private static Planet[] allPlanets;
    private static Creator myCreator;

    static void DisplayHistory(Container myContainer)
    {
        // Displays the history of a container, to complete
        string historyMessage = "";
        
        foreach (var historyLine in myContainer.TransactionHistory())
        {
            historyMessage += $"Exchanged: {historyLine.Item1} from: {historyLine.Item2}, changed: {historyLine.Item3}, result: {historyLine.Item4}\n";
        }
        
        Console.Write(historyMessage);
    }
    
    static void CreateShips(int n)
    {
        Random rdm = new Random();
        for (int i = 0; i < n; i++)
        {
            allShips.Add(myCreator.CreateShip((ShipType)rdm.Next(2)));
        }
    }
    
    static void InitializeSpace()
    {
        allPlanets = new Planet[5];
        for (int i = 0; i < 5; i++)
        {
            allPlanets[i] = myCreator.CreatePlanet();
        }

        allShips = new List<Ship>();
        CreateShips(4);
    }

    static void Main(string[] args){
        Console.WriteLine("-*-*- Welcome to the eCommerce! -*-*-");
    }
}
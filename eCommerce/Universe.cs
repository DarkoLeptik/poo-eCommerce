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
/*
    static void TestPlanet()
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
        
        //foreach (int elem in p.Products)
        //{
        //	Console.WriteLine(elem);
        //}    
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
    }
*/
    static void Main(string[] args){
        Console.WriteLine("-*-*- Welcome to the eCommerce! -*-*-");
        TestContainer();
    }
}
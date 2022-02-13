
internal class Container
{
    private int[] goods;
    private int[] maxGoods;

    private List<(int, int, int, int)> history;

    internal Container(int[] myMaxGoods)
    {
        maxGoods = myMaxGoods;
        goods = new int[maxGoods.Length];
        history = new List<(int, int, int, int)>();
    }
    
    internal Container(int[] myMaxGoods, int[] myGoods) 
        : this(myMaxGoods)
    {
        for (int i = 0; i < myMaxGoods.Length && i < myGoods.Length; i++)
        {
            if (myGoods[i] > myMaxGoods[i])
            {
                goods[i] = myMaxGoods[i];
            }
            else
            {
                goods[i] = myGoods[i];
            }
        }
    }

    
    // Add goodAmount of type goodIndex to the container
    // Return true if the action can be performed again
    // Return false if the ship should leave the planet
    internal bool AddGoodsFrom(Container otherContainer,int goodIndex, int goodAmount)
    {
        int goodsToMove = 0;
        
        // Count how many goods can be moved
        goodsToMove = Math.Min(otherContainer.goods[goodIndex], goodAmount);
        goodsToMove = Math.Min(maxGoods[goodIndex] - goods[goodIndex], goodsToMove);
        
        // Move the goods
        otherContainer.goods[goodIndex] -= goodsToMove;
        goods[goodIndex] += goodsToMove;
        
        // Add the operation to the containers
        otherContainer.history.Add((goodIndex, otherContainer.goods[goodIndex] + goodsToMove, -goodAmount, otherContainer.goods[goodIndex]));
        history.Add((goodIndex, goods[goodIndex] - goodsToMove, goodAmount, goods[goodIndex]));
        
        if ((otherContainer.goods[goodIndex] == 0) || (maxGoods[goodIndex] == goods[goodIndex]))
        {
            return false;
        }
        
        return goodsToMove == goodAmount;
    }

    // This method only returns raw datas:
    // The first item is the exchanged good index
    // The second Item represents the amount of designated goods stored before the transaction
    // The third one the transaction attempted
    // the last one the storage after the transaction
    public (int,int,int,int)[] TransactionHistory()
    {
        (int, int, int, int)[] historyArray = new (int, int, int, int)[history.Count];
        history.CopyTo(historyArray);
        return historyArray;
    }

    internal void DisplayGoods()
    {
        string displayMessage = "";
        for(int i = 0; i<goods.Length; i++ )
        {
            displayMessage += $"{i}: {goods[i]}/{maxGoods[i]}\n";
        }
        Console.Write(displayMessage);
    }
}
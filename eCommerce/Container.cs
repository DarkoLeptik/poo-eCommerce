
class Container
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

    
    // Add goodAmount of type goodIndex to the container
    // Return the amount of unloaded goods
    // if negative, then some space's left
    internal int AddGoods(int goodIndex, int goodAmount)
    {
        int goodsBefore = goods[goodIndex];
            
        // Adds the goods in the container
        goods[goodIndex] += goodAmount;
        int spaceLeft = goods[goodIndex] - maxGoods[goodIndex];
        if (spaceLeft > 0)
        {
            goods[goodIndex] = maxGoods[goodIndex];
        }
        
        // Add the operation to the container
        history.Add((goodIndex, goodsBefore, goodAmount, goods[goodIndex]));
        
        return spaceLeft;
    }
    
    // Remove goodAmount goods of type goodIndex
    // return the amount of goods effectively removed
    internal int RemoveGoods(int goodIndex, int goodAmount)
    {
        int goodsBefore = goods[goodIndex];
        
        // Remove as much goods as possible from the container, with a max of goodAmount
        int goodsUnremoved = Math.Max(goodAmount - goods[goodIndex], 0);
        int goodsRemoved = (goodAmount - goodsUnremoved);
        goods[goodIndex] -= goodsRemoved;

        // Add the operation to the container
        history.Add((goodIndex, goodsBefore, -goodAmount, goods[goodIndex]));
        
        return goodsRemoved;
    }

    // This method only returns raw datas:
    // The first item is the exchanged good index
    // The second Item represents the amount of designated goods stored before the transaction
    // The third one the transaction attempted
    // the last one the storage after the transaction
    internal (int,int,int,int)[] TransactionHistory()
    {
        (int, int, int, int)[] historyArray = new (int, int, int, int)[history.Count];
        history.CopyTo(historyArray);
        return historyArray;
    }
}
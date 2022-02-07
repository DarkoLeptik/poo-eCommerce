
class Container
{
    private int[] goods;
    private int[] maxGoods;

    internal Container(int[] myMaxGoods)
    {
        maxGoods = myMaxGoods;
        goods = new int[maxGoods.Length];
    }
    
    // Add goodAmount of type goodIndex to the container
    // Return the amount of unloaded goods
    // if negative, then some space's left
    internal int AddGoods(int goodIndex, int goodAmount)
    {
        // Adds the goods in the container
        goods[goodIndex] += goodAmount;
        int spaceLeft = goods[goodIndex] - maxGoods[goodIndex];
        if (spaceLeft > 0)
        {
            goods[goodIndex] = maxGoods[goodIndex];
        }
        
        // Add the operation to the container
        
        return spaceLeft;
    }
    
    // Remove the 
    internal int RemoveGoods(int goodIndex, int goodAmount)
    {
        // Remove as much goods as possible from the container, with a max of goodAmount
        int goodsUnremoved = Math.Max(goodAmount - goods[goodIndex], 0);
        int goodsRemoved = (goodAmount - goodsUnremoved);
        goods[goodIndex] -= goodsRemoved;

        // Add the operation to the container
        
        
        return goodsRemoved;
    }
}
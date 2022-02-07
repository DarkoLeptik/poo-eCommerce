class Ship : Container{
    private int[] itinéraire;
    private int position;
    private bool currentAction = null;
    private int targetProduct;

    public Ship(int[] itin, int pos, bool currentAct, int targetProd){
        itinéraire = itin;
        position = pos;
        currentAction = currentAct;
        targetProduct = targetProd;
    }
}
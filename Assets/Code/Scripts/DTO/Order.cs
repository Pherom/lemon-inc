

[System.Serializable]

public class Order
{
    public EDrinkType drinkType;
    public int sugerCubeCount;
    public bool addedIngredient;
    
    public enum EDrinkType {
        LEMONADE, PINK_LEMONADE
    } 

    public Order()
    {
        drinkType = EDrinkType.LEMONADE;
        sugerCubeCount = 0;
        addedIngredient = false; 
    }

    public Order(EDrinkType drinkType, int sugerCount, bool added)
    {
        this.drinkType = drinkType;
        this.sugerCubeCount = sugerCount;
        this.addedIngredient = added;
    }


    public void AddSuger() { sugerCubeCount++; }

}

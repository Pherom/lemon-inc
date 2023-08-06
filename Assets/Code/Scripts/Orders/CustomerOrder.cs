using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DrinkType
{
    EMPTY,
    LEMONADE,
    PINK_LEMONADE,
}
public class CustomerOrder : UnityEngine.Object
{
    [SerializeField] int sugarCount;
    bool additionalIngredient;
    DrinkType type; 

    
    public CustomerOrder()
    {
        sugarCount = Random.Range(0, 3);
        additionalIngredient = Random.Range(1, 11) > 6;
        type = Random.Range(1, 11) <= 6 ? DrinkType.LEMONADE : DrinkType.PINK_LEMONADE;
    }

    public CustomerOrder(int sugar, bool addIngredient, DrinkType type)
    {
        this.sugarCount = sugar;
        this.additionalIngredient = addIngredient;
        this.type = type;
    }
    public int GetSugarCount() { return this.sugarCount; }

    public DrinkType GetDrinkType() { return this.type; }
    public void AddSugar() { this.sugarCount++;  }

    public void AddAdditionalIngredient() { this.additionalIngredient = true;  }

    public void SetDrinkType(DrinkType newType) { this.type = newType;  }
    public static CustomerOrder GetEmptyOrder()
    {
        return new CustomerOrder(0, false, DrinkType.EMPTY);
    }

    public bool IsAddedIngredientIncluded() { return this.additionalIngredient; }


    public override string ToString()
    {
        string orderType = this.type.ToString().ToLower().Replace("_", " ");
        string result =  string.Format("I would like {0}\nWith {1} sugar cubes\n", orderType, sugarCount);
        result += additionalIngredient ? "Mint included" : "";
        return result;
    }



}

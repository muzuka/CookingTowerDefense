using System.Collections;
using System.Collections.Generic;

public class Order {

    public List<string> ingredients;

    public Order() 
    {
        ingredients = new List<string>();
    }

    public Order(List<string> ingredients) 
    {
        this.ingredients = ingredients;
    }

    public string toString()
    {
        string ret = "";

        for (int i = 0; i < ingredients.Count; i++)
        {
            ret += ingredients[i] + ", ";
        }

        return ret;
    }
}

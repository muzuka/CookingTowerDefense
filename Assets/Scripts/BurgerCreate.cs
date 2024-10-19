using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCreate : MonoBehaviour {

    Stack<GameObject> burger;
    Stack<string> burgerStrings;

    public float burgerThickness;
    public List<string> toppingNames;
    public List<GameObject> toppingObjects;

    GameController gameController;

	// Use this for initialization
	void Start () 
    {
        burger = new Stack<GameObject>();
        burgerStrings = new Stack<string>();

        gameController = FindObjectOfType<GameController>();
	}

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P)) 
        {
            addTopping("Patty");
        }

        if(Input.GetKeyUp(KeyCode.M))
        {
            addTopping("Mustard");
        }

        if(Input.GetKeyUp(KeyCode.K))
        {
            addTopping("Ketchup");
        }

        if(Input.GetKeyUp(KeyCode.T))
        {
            addTopping("TopBun");
        }

        if(Input.GetKeyUp(KeyCode.B))
        {
            addTopping("BottomBun");
        }

        if(Input.GetKeyUp(KeyCode.Return))
        {
            sendBurger();
        }

        if(Input.GetKeyUp(KeyCode.Backspace))
        {
            deleteBurger();
        }
    }

    public void addTopping(string topping)
    {
        GameObject burgerTopping = Instantiate(
                toppingObjects[toppingNames.IndexOf(topping)], transform);
        burgerTopping.transform.localPosition = new Vector3(0.0f, burgerThickness * burger.Count, 0.0f);
        Debug.Log($"Spawned {topping} at {burgerTopping.transform.position.ToString()}");
        burger.Push(burgerTopping);
        burgerStrings.Push(topping);
    }

    public void sendBurger()
    {
        gameController.sendBurger(burgerStrings);
        deleteBurger();
    }

    public void deleteBurger() 
    {
        while (burger.Count > 0)
        {
            Destroy(burger.Pop());
        }
        burger.Clear();
        burgerStrings.Clear();
    }
}

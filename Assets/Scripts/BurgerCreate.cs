using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCreate : MonoBehaviour {

    Stack<GameObject> burger;

    public float burgerThickness;
    public List<string> toppingNames;
    public List<GameObject> toppingObjects;

	// Use this for initialization
	void Start () {
        burger = new Stack<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addTopping(string topping)
    {
        GameObject burgerTopping = Instantiate(toppingObjects[toppingNames.IndexOf(topping)], transform.position + new Vector3(0.0f, burgerThickness * burger.Count, 0.0f), Quaternion.identity, transform);
        burger.Push(burgerTopping);
    }

    public void sendBurger()
    {
        deleteBurger();
    }

    public void deleteBurger() {
        while (burger.Count > 0)
        {
            Destroy(burger.Pop());
        }
    }
}

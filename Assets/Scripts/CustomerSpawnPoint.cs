using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnPoint : MonoBehaviour {

    public GameObject customer;
    public List<Vector3> destinations;
    [Tooltip("Indexes into the orderList object in the script.")]
    public List<int> customerOrders;
    public float spawnInterval;
    public float rotation;

    GameController gameController;

    int customerCount = 0;

    List<Order> orderList;

    Timer spawnTimer;
    GameObject newCustomer;

	// Use this for initialization
	void Start () {
        Order a = new Order();
        a.ingredients.Add("BottomBun");
        a.ingredients.Add("Patty");
        a.ingredients.Add("TopBun");

        Order b = new Order();
        b.ingredients.Add("BottomBun");
        b.ingredients.Add("Patty");
        b.ingredients.Add("Ketchup");
        b.ingredients.Add("TopBun");

        Order c = new Order();
        c.ingredients.Add("BottomBun");
        c.ingredients.Add("Patty");
        c.ingredients.Add("Mustard");
        c.ingredients.Add("TopBun");

        orderList = new List<Order>();
        orderList.Add(a);
        orderList.Add(b);
        orderList.Add(c);

        gameController = FindObjectOfType<GameController>();

        spawnTimer = new Timer(spawnInterval);
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer.update(spawnCustomer);
	}

    void spawnCustomer()
    {
        if (customerCount < customerOrders.Count)
        {
            newCustomer = Instantiate(customer, transform.position, Quaternion.Euler(0.0f, rotation, 0.0f));
            newCustomer.GetComponent<CustomerMover>().destination = destinations;
            gameController.AddCustomer(newCustomer.GetComponent<CustomerOrderController>());
            if (customerOrders[customerCount] < orderList.Count)
            {
                newCustomer.GetComponent<CustomerOrderController>().setOrder(orderList[customerOrders[customerCount]]);
                Debug.Log("Customer " + customerCount + ": " + orderList[customerOrders[customerCount]].toString());
            }
            else
            {
                newCustomer.GetComponent<CustomerOrderController>().setOrder(orderList[0]);
            }
            customerCount++;
        }
    }

    public void restart()
    {
        customerCount = 0;
    }
}

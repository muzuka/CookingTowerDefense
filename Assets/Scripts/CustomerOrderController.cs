using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerOrderController : MonoBehaviour {

    public Sprite[] sprites;

    public Canvas customerCanvas;

    public Order currentOrder { get; set; }

    List<Order> orders;
	
	// Update is called once per frame
	void Update () 
    {
        customerCanvas.transform.position = new Vector3(transform.position.x, customerCanvas.transform.position.y, transform.position.z);
	}

    private void OnDisable()
    {
        if (customerCanvas.gameObject != null)
            Destroy(customerCanvas.gameObject);
    }

    public void setOrder(Order order)
    {
        customerCanvas = Instantiate(customerCanvas, new Vector3(transform.position.x, customerCanvas.transform.position.y, transform.position.z), customerCanvas.transform.rotation);
        currentOrder = order;
        Image[] images = customerCanvas.gameObject.GetComponentsInChildren<Image>();

        images[1].sprite = sprites[0];
        images[2].sprite = sprites[1];

        if (currentOrder.ingredients[2] == "TopBun")
        {
            images[3].sprite = sprites[2];
        }
        else if (currentOrder.ingredients[2] == "Ketchup")
        {
            images[3].sprite = sprites[3];
        }
        else if (currentOrder.ingredients[2] == "Mustard")
        {
            images[3].sprite = sprites[4];
        }

        if (currentOrder.ingredients.Count == 4)
        {
            images[4].sprite = sprites[2];
        }
        else
        {
            Destroy(images[4]);
        }
    }
}

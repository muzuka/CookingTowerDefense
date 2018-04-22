using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerOrderController : MonoBehaviour {

    public Canvas customerCanvas;

    Order currentOrder;

	// Use this for initialization
	void Start () {
        customerCanvas = Instantiate(customerCanvas);

        GameObject panel = customerCanvas.gameObject.GetComponentInChildren<Image>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        customerCanvas.transform.position = new Vector3(transform.position.x, customerCanvas.transform.position.y, transform.position.z);
	}
}

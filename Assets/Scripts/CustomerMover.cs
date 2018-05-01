using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMover : MonoBehaviour {

    public List<Vector3> destination;
    public GameObject marker;
    public bool debug;

    NavMeshAgent agent;
    int currentDestination = 0;

	// Use this for initialization
	void Start () 
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination[currentDestination];
        if (debug)
            marker = Instantiate(marker, destination[currentDestination], Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (agent.remainingDistance < agent.stoppingDistance) 
        {
            currentDestination++;
            if (currentDestination >= destination.Count) 
            {
                Debug.Log("Destroyed customer at " + currentDestination);
                EventManager.TriggerEvent("CustomerLeft");
                if (debug)
                    Destroy(marker);
                Destroy(this.gameObject);
                return;
            }
            agent.destination = destination[currentDestination];
            if (debug)
                marker.transform.position = agent.destination;
        }
	}

    void OnDestroy()
    {
        if (debug)
            Destroy(marker);
    }
}

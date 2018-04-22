using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMover : MonoBehaviour {

    public List<Vector3> destination;

    NavMeshAgent agent;
    int currentDestination = 0;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination[currentDestination++];
	}
	
	// Update is called once per frame
	void Update () {
        if (agent.remainingDistance < agent.stoppingDistance) {
            agent.destination = destination[currentDestination++];
            if (currentDestination > destination.Count) {
                Destroy(gameObject);
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMovement : MonoBehaviour {

    public Transform target;
    public float chaseSpeed = 50f;

    public float stopDistance = 2f;
    Vector3 distance, directionToTarget, velocity;
   // Vector3 directionToTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        distance = target.position - transform.position;
        directionToTarget = distance.normalized;
        velocity = directionToTarget * chaseSpeed;
        if(distance.magnitude >= stopDistance)
            transform.Translate(velocity*Time.deltaTime);
	}
}

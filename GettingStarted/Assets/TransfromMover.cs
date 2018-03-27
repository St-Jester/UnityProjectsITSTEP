using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransfromMover : MonoBehaviour {

    public float moveSpeed = 10f;
    Vector3 movementVector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementVector = new Vector3(horizontal, 0f, vertical);
        Vector3 direction = movementVector.normalized;
        Vector3 velocity = direction * moveSpeed;
        Vector3 moveAmount = velocity * Time.deltaTime;

        this.transform.Translate(moveAmount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement1 : MonoBehaviour {
    public float speed = 10f;
    public float turnSpeed = 2f;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce(Vector3.forward * speed);

        if(Input.GetKey("d")|| Input.GetKey("right"))
        {
            rb.AddForce(Vector3.right * turnSpeed);
        }
        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(Vector3.left * turnSpeed);
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        Debug.Log("collided!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Debug.Log(other.gameObject.name);
        }
        else
        {
            Debug.Log("Not a pickup");
        }
    }
}

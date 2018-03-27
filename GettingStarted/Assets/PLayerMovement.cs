using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovement : MonoBehaviour {

    public float speed = 10f;
    public float sideSpeed = 2f;
    public Rigidbody rb; 

	// Use this for initialization
	void Start () {
        
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * speed);

       if(Input.GetKey("d"))
        {
            rb.AddForce(Vector3.right * sideSpeed, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector3.left * sideSpeed, ForceMode.VelocityChange);
        }

        if(this.gameObject.transform.position.y < -1)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("Finish"))
        {
            FindObjectOfType<GameManager>().WinGame();
        }
       Debug.Log("Collided");
    }
}

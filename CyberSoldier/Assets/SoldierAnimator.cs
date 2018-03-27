using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SoldierAnimator : MonoBehaviour {

    Animator anim;
    float move, turn;
    int jumpId = Animator.StringToHash("Jump");

    public float jumpForce = 100f;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        move = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", move);
        anim.SetFloat("Turn", turn);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(jumpId);
            rb.AddForce(Vector3.up *jumpForce);
            //anim.SetFloat("JumpUp", rb.velocity.y);
            Debug.Log(rb.velocity.y);
        }
        //Debug.Log(rb.velocity.y);

        anim.SetFloat("JumpUp", rb.velocity.y);
    }
}

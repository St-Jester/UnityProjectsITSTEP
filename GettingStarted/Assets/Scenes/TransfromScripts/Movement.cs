using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public int counter = 0;

    public float speed = 10f;

    public float jumpVelocity = 500f;

    [Space]
    public float fallMultiplier = 2.5f;
    public float lowJumpgravity = 2f;

    [Space]
    public LayerMask layermask;

    private bool isFacingLeft = false;
    private Rigidbody rb;

    
    private float moveHorizontal;
    private float moveVertical;

    private Collider coll;

    private Vector3 movement;
    private bool isGrounded;

    private bool isDoubleJump = false;//is jumping second time

    void Start () {
        rb = GetComponent<Rigidbody>();
        coll = gameObject.GetComponent<Collider>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, 0, moveVertical);

        if (isFacingLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
        if (Input.GetButtonDown("Jump") && (isGrounded || !isDoubleJump))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpVelocity * Time.deltaTime, ForceMode.VelocityChange);
            Debug.Log(rb.velocity);

            isGrounded = false;
            
            isDoubleJump = true;
        }        
    }
    //void FixedUpdate () {
        
    //    //rb.AddForce(movement * speed, ForceMode.Acceleration); //for lateral movement

    //    if (Physics.Raycast(transform.position, Vector3.down,
    //         coll.bounds.extents.y + 0.1f, layermask))
    //    {
    //        Debug.DrawLine(transform.position, Vector3.down + new Vector3(0, coll.bounds.extents.y + 0.1f), Color.red);
    //        isGrounded = true;
    //        isDoubleJump = false;
    //    }

        
    //        if (rb.velocity.y < 0)//if falling
    //        {
    //            rb.AddForce(Vector3.up * Physics.gravity.y * (fallMultiplier) * Time.fixedDeltaTime, ForceMode.Acceleration);
    //        }
    //        else
    //        if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
    //        {
    //            isGrounded = false;
    //            rb.AddForce(Vector3.up * Physics.gravity.y * (lowJumpgravity) * Time.fixedDeltaTime, ForceMode.Acceleration);
    //        }
            
    //}

    private void OnTriggerEnter(Collider other)
    {
        isFacingLeft = !isFacingLeft;
    }
    private void OnCollisionEnter(Collision collision)
    {
        isFacingLeft = !isFacingLeft;
    }
}




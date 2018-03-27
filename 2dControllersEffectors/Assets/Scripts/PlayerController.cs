using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public bool isRight = true;

    //checks for the jumps
    bool isGrounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask groundMask;

    bool doubleJump = false;
    public float jumpForce = 700f;

    Animator animtr;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        animtr = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if((isGrounded||!doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            animtr.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, jumpForce));

            if(!doubleJump && !isGrounded)
            {
                doubleJump = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);

        animtr.SetBool("Ground", isGrounded);
        animtr.SetFloat("vSpeed", rb.velocity.y);

        if (isGrounded)
            doubleJump = false;

        float move = Input.GetAxis("Horizontal");

        animtr.SetFloat("Speed", Mathf.Abs(move));
       rb.velocity = new Vector2(move * speed, rb.velocity.y);
		
        if(move > 0 && !isRight)
        {
            Flip();
        }
        else
        if(move < 0 && isRight)
        {
            Flip();
        }
	}

    void Flip()
    {
        isRight = !isRight;
        Vector3 currScale = transform.localScale;
        currScale.x *= -1;
        transform.localScale = currScale;
    }
}

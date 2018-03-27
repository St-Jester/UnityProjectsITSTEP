using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private bool isDead = false;
    private Rigidbody2D rb;
    private Animator anim;
    public float force = 200f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.AddForce(Vector3.up * 10f, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update () {
		if(!isDead)
        {
#if UNITY_EDITOR||UNITY_STANDALONE || UNITY_WEBPLAYER
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * force, ForceMode2D.Force);
                anim.SetTrigger("Flap");

            }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
            
            if (Input.touchCount > 0)
            {
                //Store the first touch detected.
                Touch myTouch = Input.touches[0];
                //if it's start of touch then store position
                if(myTouch.phase == TouchPhase.Began)
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * force, ForceMode2D.Force);
                }
            }
#endif
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Dead"))
        {
            rb.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("Dead");
            GameManager.instance.PlayerDie();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            GameManager.instance.Scored();
        }
    }
}

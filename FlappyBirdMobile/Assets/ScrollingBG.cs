using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(GameManager.instance.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update () {
		if(GameManager.instance.isGameOver)
        {
            rb.velocity = Vector2.zero;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float Width;
	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        Width = groundCollider.size.x;
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x<-Width)
        {
            Reposition();
        }
	}

    void Reposition()
    {
        Vector2 offset = new Vector2(Width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}

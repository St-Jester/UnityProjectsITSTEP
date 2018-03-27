using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    private float damage;
    private float range;
    public float bulletSpeed = 10f;
    Vector3 originalPos, currentPos;
    public void SetBullet(float _range, float _damage)
    {
        range = _range;
        damage = _damage;
        originalPos = transform.position;
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        if(Mathf.Abs(Vector3.Distance(currentPos,originalPos)) > range)
        {
            Debug.Log(Mathf.Abs(Vector3.Distance(currentPos, originalPos)) + " " + range);
            //good for objectpooling!!!
            Destroy(this.gameObject);
        }
        currentPos = transform.position;
        transform.Translate(transform.forward.normalized*bulletSpeed*Time.deltaTime);
        Debug.Log(Mathf.Abs(Vector3.Distance(currentPos, originalPos)));

    }
}

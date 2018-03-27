using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleTarget : MonoBehaviour {

    public float health = 50f;
    public GameObject Cracked;

	public void TakeDamage(float _amount)
    {
        health -= _amount;
        if (health<=0)
        {
            Destuct();
        }

    }

    private void Destuct()
    {
        Instantiate(Cracked,transform.position,transform.rotation);
        Destroy(this.gameObject);
    }
}

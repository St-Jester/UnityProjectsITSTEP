using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float force = 0.2f;
    public Camera fpsCam;

    public Transform firepoint;
    public GameObject impactEffect;
    public ParticleSystem flash;
    // Update is called once per frame
    void Update () {
		if(Input.GetButtonDown("Fire1")) //getmousebuttonDown(0)
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        RaycastHit hit;
        flash.Play();
        if (Physics.Raycast
            (new Ray(fpsCam.transform.position, 
            fpsCam.transform.forward), out hit, range))
        {
            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
            Debug.Log(hit.transform.name);

            DestructibleTarget target = hit.transform.GetComponent<DestructibleTarget>();
            if(target!=null)
            {
                target.TakeDamage(damage);
                
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal* force,ForceMode.Impulse);
            }

        }
    }
}

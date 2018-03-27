using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    public float offset = -15f;

    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, this.transform.position.y, player.position.z + offset);
            
    }




}


//public float offset = -5f;
//public Transform player;

//Use this for initialization
//void Start()
//{

//}

//Update is called once per frame
//void LateUpdate()
//{
//    this.transform.position = new Vector3
//        (player.position.x,
//        transform.position.y,
//        player.position.z + offset);
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;

    public float smoothSpeed = .125f;
    public Vector3 offset;


    //public float borders = 10f;
    //public float camSpeed = 15f;
    Camera cam;

    void Start () {
        cam = GetComponent<Camera>();
	}
	
	
	void LateUpdate () {
        Vector3 DesiredPosition = player.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = SmoothedPosition;
    }
}


//WARNING!!! GOES VERY WILD 
//while (screenPos.x < borders 
//    || screenPos.x > Screen.width - borders 
//    || screenPos.y < borders 
//    || screenPos.y > Screen.height - borders)
//{
//    transform.position = 
//        Vector3.MoveTowards(transform.position, 
//        new Vector3(player.position.x, this.transform.position.y, player.position.z), camSpeed*Time.deltaTime);
//}

//SHAKING TERRIBLY
//if (screenPos.x< borders)
//{
//    transform.Translate(Vector3.left * camSpeed * Time.deltaTime, Space.World);
//}
//if (screenPos.x > Screen.width - borders)
//{
//    transform.Translate(Vector3.right * camSpeed * Time.deltaTime, Space.World);
//}
//if(screenPos.y < borders)
//{
//    transform.Translate(Vector3.back * camSpeed * Time.deltaTime, Space.World);
//}
//if(screenPos.y > Screen.height - borders)
//{
//    transform.Translate(Vector3.forward * camSpeed * Time.deltaTime, Space.World);
//}

//ALWAYS CENTERED
//    screenPos.x< borders|| screenPos.x>Screen.width - borders ||screenPos.y <borders||screenPos.y>Screen.height-borders)

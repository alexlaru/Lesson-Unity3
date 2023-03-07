using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow_snake : MonoBehaviour
{
    public GameObject Snake;
   // public Vector3 PlatformToCameraOffset;
    public float Speed=1;
 


    // Update is called once per frame
    void Update()
    {

      //  if (Player.CurrentPlatform == null) return;

        Vector3 targetPosition = Snake.transform.position;// + PlatformToCameraOffset;
        //         transform.position=targetPosition;
        transform.position += new Vector3(0, 0, Speed*Time.deltaTime);// targetPosition.y;



    }
}

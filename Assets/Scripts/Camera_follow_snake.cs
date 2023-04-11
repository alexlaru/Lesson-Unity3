using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow_snake : MonoBehaviour
{
    public GameObject Snake;
   
    public float Speed=1;
    public bool Stop_moving=false;


    
    void Update()
    {

      

        Vector3 targetPosition = Snake.transform.position;
  
        transform.position += new Vector3(0, 0, Speed*Time.deltaTime);



    }
}

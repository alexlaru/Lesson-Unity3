using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchWall : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (!collision.collider.TryGetComponent(out Control_Snake control_snake)) return;
        Renderer SectorRenderer = GetComponent<Renderer>();



        GameObject.Find("Snake_head").transform.Rotate(0, 10, 0);


    }
}

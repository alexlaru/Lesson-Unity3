using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  static void bonus(int prize)
    {

        prize += prize;
    }

    internal static void crash(int count_bad)
    {
        count_bad -= count_bad;
    }
}

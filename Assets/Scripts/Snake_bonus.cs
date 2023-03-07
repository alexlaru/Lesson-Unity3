using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_bonus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        //    Debug.Log("Бонус");
        Snake.bonus(prize);
    }
}

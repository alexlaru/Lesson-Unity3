using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_bonus : MonoBehaviour
{
    public int prize = 0;
    // Start is called before the first frame update
    void Start()
    {
        prize = Random.Range(1, 5);
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

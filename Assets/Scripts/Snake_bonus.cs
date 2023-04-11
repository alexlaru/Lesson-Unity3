using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Snake_bonus : MonoBehaviour
{
   // public Snake snake;
   public int Level_Number=1;
   public  int  prize = 3;
    // Start is called before the first frame update
    void Start()
    {

        //     GameObject Text_bonus = this.transform.GetChild(0).gameObject;//.SetActive(false);
        //     Text_bonus.transform.GetChild(0).gameObject.GetComponent<Text>().text= "P";
      
    }

    // Update is called once per frame
    void Update()
    {
   //    GameObject Text_bonus = this.transform.GetChild(0).gameObject;//.SetActive(false);
   //     Text_bonus.transform.GetChild(0).gameObject.GetComponent<Text>().text = prize.ToString();
     //   Debug.Log("Á: " + prize);
        //     Debug.Log(value_bonus);
    }

    


        public  void OnCollisionEnter(Collision collision)
        {
             int prize = int.Parse(this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        
            if (GameObject.Find("Snake_head"))
            {
               int count_snake = int.Parse(GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
              count_snake += prize;
              GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = count_snake.ToString();
           //   GameObject.Find("CanvasPlaying").transform.GetChild(0).gameObject.GetComponent<Text>().text = count_snake.ToString();
           //   GameObject.Find("CanvasPlaying").transform.GetChild(1).gameObject.GetComponent<Text>().text = Level_Number.ToString();

            }
        gameObject.SetActive(false);

    
        }

    public   void  Count(int value_bonus)
    {

    }

    public static void Count_return()
    {
    //    return prize;
    }
}

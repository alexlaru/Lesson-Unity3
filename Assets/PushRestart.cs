using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PushRestart : MonoBehaviour
{
    private int count_snake = 0;
   
    
    public void OnClick()
    {
        count_snake = 0;
    
        GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = count_snake.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  
}

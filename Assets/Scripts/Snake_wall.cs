using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake_wall : MonoBehaviour
{
    public int Level_Number = 1;
  
    public Material WallMaterial;

    private int score_game = 0;


    private void Awake()
    {
       
    }

    public int count_bad = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        score_game = int.Parse(GameObject.Find("CanvasPlaying").transform.GetChild(0).gameObject.GetComponent<Text>().text);
        Debug.Log(score_game + "  ++++ " );
        if (!collision.collider.TryGetComponent(out Snake snake)) return;
        Renderer SectorRenderer = GetComponent<Renderer>();

        int count_bad = int.Parse(this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);

        if (GameObject.Find("Snake_head"))
        {
            int count_snake = int.Parse(GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            count_snake -= count_bad;
            score_game += count_bad;

            Debug.Log(score_game+"  ---- " + count_bad);


            if (count_snake >= 0)
            {
                GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = count_snake.ToString();
                GameObject.Find("CanvasPlaying").transform.GetChild(0).gameObject.GetComponent<Text>().text = score_game.ToString();
            //    GameObject.Find("CanvasPlaying").transform.GetChild(1).gameObject.GetComponent<Text>().text = Level_Number.ToString();
                StartCoroutine(Bad_sound(snake));
            }
            else
            {
                snake.Die();
            
            }
           
        }
        gameObject.SetActive(false);



    }

    IEnumerator Bad_sound(Snake snake)
    {
       
        
        //   Color color = new Color(1f, 1f, 1f);

        //    color.r = player.GetComponent<Renderer>().material.GetColor("_Color").r + 1f;
        //   color.g = player.GetComponent<Renderer>().material.GetColor("_Color").g - 0.5f;
        //    color.b = 0;// layer.GetComponent<Renderer>().material.GetColor("_Color").b - 0.5f;
        //     player.transform.GetChild(2).gameObject.SetActive(true);

        //      player.GetComponent<Renderer>().material.SetColor("_Color", color);
      
        yield return new WaitForSeconds(1f);// Clip_length);

      


    }

    IEnumerator Dead_sound(Snake snake)
    {
        
        

        //   Color color = new Color(1f, 1f, 1f);

        //    color.r = player.GetComponent<Renderer>().material.GetColor("_Color").r + 1f;
        //   color.g = player.GetComponent<Renderer>().material.GetColor("_Color").g - 0.5f;
        //    color.b = 0;// layer.GetComponent<Renderer>().material.GetColor("_Color").b - 0.5f;
        //     player.transform.GetChild(2).gameObject.SetActive(true);

        //      player.GetComponent<Renderer>().material.SetColor("_Color", color);
       
        yield return new WaitForSeconds(1f);// Clip_length);
       
        snake.Die();
        

    }
}
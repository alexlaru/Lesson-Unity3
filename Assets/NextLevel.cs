using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class NextLevel : MonoBehaviour
{
    public int TotalCount = 0;


    public int MinBonus = 1, MaxBonus = 10;
    public int MinCrash = 1, MaxCrash = 10;
    public int value_bonus;
    public int value_crash;
    public bool exist_object = false;
    public GameObject Bonus;
    public GameObject Crash;

    public Camera_follow_snake camera_main;

    private AudioSource _audio;
    public AudioClip AudioClip_finish;
    



    [Min(0)]
    public float volume;

    // Start is called before the first frame update
    private void Awake()
    {
       

    }
    void Start()
    {



        GameObject.Find("CanvasPlaying").transform.GetChild(0).gameObject.GetComponent<Text>().text = "0";

        int levelIndex = LevelIndex;

   //     Debug.Log(levelIndex + "  ====");
        // if (levelIndex == 0)
        // {
        //     LevelIndex++;
        //     levelIndex = LevelIndex;
        // }
        Random random = new Random(levelIndex);
        GameObject.Find("CanvasWin").transform.GetChild(1).gameObject.GetComponent<Text>().text = levelIndex.ToString();
        GameObject.Find("CanvasPlaying").transform.GetChild(1).gameObject.GetComponent<Text>().text = levelIndex.ToString();
        float color_level_for_wall = 0;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 8; j++)
            {


                //   exist_object = Random.Range(0, 2)==1? true:false;

                exist_object = RandomRange(random, 0, 2) == 1 ? true : false; ;

                if (exist_object)
                {
                    //        value_bonus = Random.Range(MinBonus, MaxBonus);

                    value_bonus = RandomRange(random, MinBonus, MaxBonus);

                    GameObject Bonus1 = Instantiate(Bonus);
                    Bonus1.transform.position = new Vector3(i * 0.5f - 2, 0, (j * 2 + 1) * 2 + 2);
                    GameObject Text_bonus = Bonus1.transform.GetChild(0).gameObject;
                    Text_bonus.transform.GetChild(0).gameObject.GetComponent<Text>().text = value_bonus.ToString();

                }



            }

            for (int j = 0; j < 8; j++)
            {



                //   exist_object = Random.Range(0, 2) == 1 ? true : false;

                exist_object = RandomRange(random, 0, 2) == 1 ? true : false;

        //        Debug.Log("j " + exist_object);
                if (exist_object)
                {
                    //        value_crash = Random.Range(MinCrash, MaxCrash);

                    value_crash = RandomRange(random, MinBonus, MaxBonus);

                    GameObject Crash1 = Instantiate(Crash);
                    Crash1.transform.position = new Vector3(i * 0.5f - 2, 0, j * 2 * 2 + 6);
                    GameObject Text_crash = Crash1.transform.GetChild(0).gameObject;
                    Text_crash.transform.GetChild(0).gameObject.GetComponent<Text>().text = value_crash.ToString();

                    color_level_for_wall = 1 - (MaxCrash - value_crash) / (MaxCrash - MinCrash + 0.2f);
                    Crash1.GetComponent<Renderer>().material.color = new Color(1f - color_level_for_wall, 1f - color_level_for_wall, 1f - color_level_for_wall);

                }



            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    private int RandomRange(Random random, int min, int max)
    {
        int number = random.Next();
        int length = max - min;
        number %= length;
        return min + number;
    }

    //   private float RandomRange(Random random, float min, float max)
    //   {
    //       float t = (float)random.NextDouble();
    //       return Mathf.Lerp(min, max, t);

    //   }

    public void OnCollisionEnter(Collision collision)
    {

      
        if (GameObject.Find("Snake_head"))
        {

            int count_snake = int.Parse(GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            //int.Parse(GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);

            GameObject.Find("CanvasPlaying").GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;

            GameObject.Find("CanvasWin").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

            camera_main.Speed = 0;

            PlayerPrefs.SetInt("SavedInteger", count_snake);
            PlayerPrefs.Save();

        
            GameObject.Find("CanvasWin").transform.GetChild(0).gameObject.GetComponent<Text>().text = GameObject.Find("CanvasPlaying").transform.GetChild(0).gameObject.GetComponent<Text>().text.ToString();
      //      GameObject.Find("CanvasWin").transform.GetChild(1).gameObject.GetComponent<Text>().text = GameObject.Find("CanvasPlaying").transform.GetChild(1).gameObject.GetComponent<Text>().text.ToString();

        }
    }

    IEnumerator NextLevel_pause(int count_snake, float time_wait)
    {

        _audio.PlayOneShot(AudioClip_finish, volume);
        float Clip_length = AudioClip_finish.length;

        yield return new WaitForSeconds(time_wait);
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = count_snake.ToString();


    }



    public void OnPlayerReachedFinish()
    {

        LevelIndex++;

        ReloadLevel();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    public void PlayNext()
    {




        GameObject.Find("CanvasPlaying").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

        GameObject.Find("CanvasWin").GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        OnPlayerReachedFinish();
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    public int LevelIndex
    {

        get => PlayerPrefs.GetInt(LevelIndexKey, 1);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();

        }


    }
    private const string LevelIndexKey = "LevelIndex";



}





   

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Snake : MonoBehaviour 
{
    public float speed_tail = 10f;

    // public Camera camera_main;

    public Camera_follow_snake camera_main;


    public GameObject Snake_link;
    
    private float Sensitivity = 0.1f;

    public LinkedList<GameObject> snake_tail = new LinkedList<GameObject>();

    private float _moveSpeed = 2f;
    private float _rotateSpeed = 1f;
    private float _bonesDistance = 0.02f;

    private  int Level_Number=10;
    public int Count_Player;
    private  int count_snake;
    private float time_Particle = 3f;

    private AudioSource _audio;
    public AudioClip AudioClip_dead;
    public AudioClip AudioClip_bad_wall;
    public AudioClip AudioClip_bonus;



    [Min(0)]
    public float volume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
       
    }


    void Start()
    {
      
        //  int count_snake = 7;// int.Parse(GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        count_snake = PlayerPrefs.GetInt("SavedInteger");

        GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = count_snake.ToString();
        GameObject.Find("CanvasPlaying").transform.GetChild(0).gameObject.GetComponent<Text>().text = "0";// count_snake.ToString();
      
        
        for (int i = 1; i <= count_snake; i++)
            snake_tail.AddLast(Instantiate(Snake_link));
            
     



        int j = 0;

        foreach (GameObject i in snake_tail)
        {
            j++;
            i.transform.position=i.transform.position - new Vector3(0,0, _bonesDistance * j);
        }

       
    }

    public void Die()
    {
        float temp_moveSpeed;

        if (GameObject.Find("Snake_head"))
        {
            int count_snake = int.Parse(GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
 
           
            GameObject.Find("Snake_head").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = count_snake.ToString();

            GameObject.Find("CanvasPlaying").GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            temp_moveSpeed = _moveSpeed;

            _moveSpeed = 0;
            camera_main.Speed = 0;

            GameObject.Find("CanvasLoose").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

            PlayerPrefs.SetInt("SavedInteger", 3);
            PlayerPrefs.Save();



        }


    }

    void Update()
    {
       
        MoveHead(_moveSpeed);
        MoveTail();
        Rotate(_rotateSpeed);
        
    }

    private void Rotate(float rotateSpeed)
    {
        float angle = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        GameObject.Find("Snake_head").transform.Rotate(0, angle, 0);
    }

    private void MoveTail()
    {
        float sqrDistance = Mathf.Sqrt(_bonesDistance);
        Vector3 _previousTailPosition = GameObject.Find("Snake_head").transform.position;
        foreach (GameObject bone in snake_tail)
        {
            if((bone.transform.position - _previousTailPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 currentBonePosition = bone.transform.position;
                bone.transform.position = _previousTailPosition;// - new Vector3(0, 0, 0.1f); 
                _previousTailPosition = currentBonePosition;

            }
            else
            {
                break;
            }
        }
    }

    private void MoveHead(float moveSpeed)
    {
        GameObject.Find("Snake_head").transform.position = GameObject.Find("Snake_head").transform.position + transform.forward * moveSpeed * Time.deltaTime;
    }

    
    public void OnCollisionEnter(Collision collision)
    {

        string Name_Particle;



        if (collision.gameObject.name=="Prize(Clone)")
        {
            Name_Particle = "Prize(Clone)";
            int prize = int.Parse(collision.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            for (int i = 1; i < prize; i++)
                snake_tail.AddLast(Instantiate(Snake_link));

            this.transform.GetChild(2).gameObject.SetActive(true);
            time_Particle = 0.1f;
            StartCoroutine(Wait_Particle(Name_Particle, time_Particle));
          
     
        }

        if (collision.gameObject.name == "Wall(Clone)")
        {

            Name_Particle = "Wall(Clone)";
            int count_snake = int.Parse(collision.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            if (count_snake >= 0)
            {
                for (int i = 1; i < count_snake; i++)
                {

                    snake_tail.RemoveLast();
                }

            }

            this.transform.GetChild(3).gameObject.SetActive(true);
            time_Particle = 0.1f;
            StartCoroutine(Wait_Particle(Name_Particle, time_Particle));


        }

        if (collision.gameObject.name == "Finish")
        {
            Name_Particle = "Finish";
            this.transform.GetChild(4).gameObject.SetActive(true);
            time_Particle = 5f;
            // _audio.PlayOneShot(AudioClip_bonus_sector, volume);
        }
    }

    IEnumerator Wait_Particle(string Name_Particle, float time_Particle)
    {
        if (Name_Particle == "Prize(Clone)")
        {
            _audio.PlayOneShot(AudioClip_bonus, volume);
            float Clip_length = AudioClip_bonus.length;
        }
        if (Name_Particle == "Wall(Clone)")
        {
            _audio.PlayOneShot(AudioClip_bad_wall, volume);
            float Clip_length = AudioClip_bad_wall.length;

           
        }
     


        yield return new WaitForSeconds(time_Particle);

        if (Name_Particle == "Prize(Clone)")
        {
            this.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (Name_Particle == "Wall(Clone)")
        {
            

            this.transform.GetChild(3).gameObject.SetActive(false);
        }
        if (Name_Particle == "Finish")
        {
            this.transform.GetChild(4).gameObject.SetActive(false);
        }

    }

}










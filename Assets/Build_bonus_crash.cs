using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Build_bonus_crash : MonoBehaviour
{
    //public int a[4];
    public int MinBonus=1, MaxBonus=10;
    public int MinCrash=1, MaxCrash=10;
    public int value_bonus;
    public int value_crash;
    public bool exist_object = false;
    public GameObject Bonus;
    public GameObject Crash;

    // Start is called before the first frame update
    void Start()
    {
        float color_level_for_wall = 0;

        for(int i=0;i<9;i++)
        {
            for (int j = 0; j < 8; j++)
            {
               

                exist_object = Random.Range(0, 2)==1? true:false;

           //     exist_object = RandomRange(random, 0, 2);

                if (exist_object)
                {
                    value_bonus = Random.Range(MinBonus, MaxBonus);

              //      value_bonus = RandomRange(random, MinBonus, MaxBonus);

                    GameObject Bonus1 = Instantiate(Bonus);
                    Bonus1.transform.position = new Vector3(i * 0.5f - 2, 0, (j * 2 + 1) * 2 + 2);
                    GameObject Text_bonus = Bonus1.transform.GetChild(0).gameObject;
                    Text_bonus.transform.GetChild(0).gameObject.GetComponent<Text>().text = value_bonus.ToString();
                   
                }
                
               
              
            }

            for (int j = 0; j < 8; j++)
            {
                
                

                exist_object = Random.Range(0, 2) == 1 ? true : false;

            //    exist_object = RandomRange(random, 0, 2);

                Debug.Log("j "+exist_object);
                if (exist_object)
                {
                    value_crash = Random.Range(MinCrash, MaxCrash);

             //       value_crash = RandomRange(random, MinBonus, MaxBonus);

                    GameObject Crash1 = Instantiate(Crash);
                    Crash1.transform.position = new Vector3(i*0.5f -2, 0, j * 2 * 2 + 6);
                    GameObject Text_crash = Crash1.transform.GetChild(0).gameObject;
                    Text_crash.transform.GetChild(0).gameObject.GetComponent<Text>().text = value_crash.ToString();

                    color_level_for_wall=1- (MaxCrash- value_crash)/(MaxCrash-MinCrash+0.2f);
                    Crash1.GetComponent<Renderer>().material.color= new Color(1f- color_level_for_wall, 1f- color_level_for_wall, 1f- color_level_for_wall);
                    
                }
               

                
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }




}

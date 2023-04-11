using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class ButtonNextWin : MonoBehaviour
{

    public NextLevel next_level;
   private AudioSource _audio;
    public AudioClip AudioClip_finish;




    [Min(0)]
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   

}

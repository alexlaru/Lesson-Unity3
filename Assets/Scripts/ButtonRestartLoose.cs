using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRestartLoose : MonoBehaviour
{
    private Text textToEdit;
    private int totalClicks = 0;
    void Start()
    {
 
    }

    public void PlayAgain()
    {
    

       // Debug.Log("ButtonRestartLoose");

        GameObject.Find("CanvasPlaying").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;

        //_moveSpeed = 0;

        GameObject.Find("CanvasLoose").GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

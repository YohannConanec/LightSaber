using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPauseManager : MonoBehaviour
{
    public GameObject buzzer; 
    public GameObject menuPause;
    public GameObject song1;
    public GameObject songClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void PauseOn(){
        buzzer.SetActive(false);
        menuPause.SetActive(true);
        song1.GetComponent<LevelManager>().SetSpeed(0);
        songClip.GetComponent<AudioSource>().Pause();

    }
    public void PauseOff(){
        buzzer.SetActive(true);
        menuPause.SetActive(false);
        song1.GetComponent<LevelManager>().SetSpeed(4);
        songClip.GetComponent<AudioSource>().Play();
    }
    
}

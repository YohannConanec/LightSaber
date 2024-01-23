using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPauseManager : MonoBehaviour
{
    public GameObject buzzer; 
    public GameObject menuPause;
    public GameObject song1;
    public GameObject songClip;
    private bool pause = false;
    
    // Cette méthode est appelée lorsque la pause est activée
    public void PauseOn(){
        buzzer.SetActive(false); // Désactive l'objet buzzer
        menuPause.SetActive(true); // Active l'objet menuPause
        song1.GetComponent<LevelManager>().SetSpeed(0); // Récupère le composant LevelManager de l'objet song1 et définit sa vitesse à 0
        songClip.GetComponent<AudioSource>().Pause(); // Met en pause l'audio source de l'objet songClip
        pause = true; // Indique que la pause est activée
    }
    
    // Cette méthode est appelée lorsque la pause est désactivée
    public void PauseOff(){
        buzzer.SetActive(true); // Active l'objet buzzer
        menuPause.SetActive(false); // Désactive l'objet menuPause
        song1.GetComponent<LevelManager>().SetSpeed(4); // Récupère le composant LevelManager de l'objet song1 et définit sa vitesse à 4
        songClip.GetComponent<AudioSource>().Play(); // Joue l'audio source de l'objet songClip
        pause = false; // Indique que la pause est désactivée
    }
    public bool GetPause()
    {
        return pause;
    }
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObjects : MonoBehaviour
{
    public AudioSource audioSource;
    private GameObject manager;
    private ParticleSystem particles;
    void Start()
    {
        manager=GameObject.FindGameObjectsWithTag("MenuManager")[0];
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "ObjectToHit":
                if (this.CompareTag("BladeLeft") || this.CompareTag("BladeRight"))
                {
                    bool isLeft = other.GetComponent<DestroyableObject>().isLeft;
                    if ((isLeft && this.CompareTag("BladeLeft")) || (!isLeft && this.CompareTag("BladeRight")))
                    {
                    particles = isLeft ? GameObject.Find("fire_blue").GetComponent<ParticleSystem>() : GameObject.Find("fire_pink").GetComponent<ParticleSystem>();
                    particles.transform.position = other.transform.position;
                    Destroy(other.gameObject/*,particles.main.duration*/);
                    particles.Play();
                    if(isLeft){
                        VibL();
                    }else{
                        VibR();
                    }
                    audioSource.Play();
                    GlobalScore.Score += 1;
                    }
                }
                break;
            case "buzzer_pause":
                manager.GetComponent<MenuPauseManager>().PauseOn();
                break;
            case "Resume":
                manager.GetComponent<MenuPauseManager>().PauseOff();
                break;
            case "GoToPrincipal":
                SceneManager.LoadScene("Menu");
                break;
            case "MenuPlay":
                particles = GameObject.Find("fire_blue").GetComponent<ParticleSystem>();
                particles.transform.position = other.transform.position;
                particles.Play();
                audioSource.Play();
                GameObject.Find("cube_Play").SetActive(false);
                GameObject.Find("cube_Quit").SetActive(false);
                GameObject.Find("animDown").GetComponent<AnimGoDown>().AnimMenuDown();
                break;
            case "MenuQuit":
                Application.Quit();
                break;
        }
    }

    public void VibR()
    {
        Invoke("startVibR", .0001f);
        Invoke("stopVibR", .1f);
    }
    public void startVibR()
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
    }
    public void stopVibR()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
     public void VibL()
    {
        Invoke("startVibL", .0001f);
        Invoke("stopVibL", .15f);
    }
    public void startVibL()
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
    }
    public void stopVibL()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}
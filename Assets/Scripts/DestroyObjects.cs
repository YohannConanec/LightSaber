using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObjects : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("ObjectToHit"))
        {
            if (this.CompareTag("BladeLeft") || this.CompareTag("BladeRight"))
            {
                bool isLeft = other.GetComponent<DestroyableObject>().isLeft;
                if ((isLeft && this.CompareTag("BladeLeft")) || (!isLeft && this.CompareTag("BladeRight")))
                {
                    var particles = isLeft ? GameObject.Find("fire_blue").GetComponent<ParticleSystem>() : GameObject.Find("fire_pink").GetComponent<ParticleSystem>();
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
            else
            {
                Destroy(other.gameObject);
            }
        }else if(other.CompareTag("buzzer_pause")){
            Debug.Log("buzzer_pause");
            other.transform.parent.gameObject.SetActive(false);
            GameObject manager=GameObject.FindGameObjectsWithTag("MenuPauseManager")[0];

            manager.GetComponent<MenuPauseManager>().menuPause.SetActive(true);

        }
        else if (other.CompareTag("MenuPlay"))
        {
            GameObject.Find("animDown").GetComponent<AnimGoDown>().AnimMenuDown();
            //SceneManager.LoadScene("FirstSong");

        }
        else if (other.CompareTag("MenuQuit"))
        {
            Application.Quit();
        }
    }

    public void VibR()
    {
        Invoke("startVibR", .1f);
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
        Invoke("startVibL", .1f);
        Invoke("stopVibL", .1f);
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
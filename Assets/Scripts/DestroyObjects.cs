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
                    particles.Play();
                    if(isLeft){
                        VibL();
                    }else{
                        VibR();
                    }
                    audioSource.Play();
                    Destroy(other.gameObject,particles.main.duration);
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
            SceneManager.LoadScene("FirstSong");
        }
        else if (other.CompareTag("MenuQuit"))
        {
            Application.Quit();
        }
    }

    public void VibR()
    {
        Invoke("startVib", .1f);
        Invoke("stopVib", .1f);
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
        Invoke("startVib", .1f);
        Invoke("stopVib", .1f);
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
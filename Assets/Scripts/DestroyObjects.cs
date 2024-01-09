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
                    Vib();
                    audioSource.Play();
                    Destroy(other.gameObject,particles.main.duration);
                    //Destroy(other.gameObject);
                    GlobalScore.Score += 1;
                    Debug.Log(GlobalScore.Score);
                }

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

    public void Vib()
    {
        Invoke("startVib", .1f);
        Invoke("stopVib", .2f);
    }
    public void startVib()
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
    }
    public void stopVib()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
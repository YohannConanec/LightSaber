using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    var particles = isLeft ? GameObject.Find("fire_pink").GetComponent<ParticleSystem>() : GameObject.Find("fire_blue").GetComponent<ParticleSystem>();
                    particles.transform.position = other.transform.position;
                    particles.Play();
                    Destroy(other.gameObject, particles.main.duration);
                    //Destroy(other.gameObject);
                    audioSource.Play();
                    GlobalScore.Score += 1;
                    Debug.Log(GlobalScore.Score);
                }

            }
            else
            {
                Destroy(other.gameObject);
                if (this.CompareTag("Blade"))
                {
                    audioSource.Play();
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

    }
}